using System.Text.Json.Serialization;
using Rij62.Data;
using Rij62.Models.Api;
using Microsoft.EntityFrameworkCore;
using Rij62.Models;

namespace Rij62.Services;


public struct OrderValidationProduct
{
    public int Id { get; set; }
    public int Index { get; set; }
    public OrderValidationProduct(int id, int index)
    {
        Id = id;
        Index = index;
    }
}

public class OrderValidationError
{
    public OrderValidationProduct? Product { get; set; }
    public OrderValidationProduct? ChoiceProduct { get; set; }
    public required OrderValidationErrorType Type { get; set; }

    public static OrderValidationError InvalidTableNumber()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.InvalidTableNumber };
    }
    public static OrderValidationError InvalidTimeSlot()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.InvalidTimeSlot };
    }
    public static OrderValidationError TimeSlotNotAvailable()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.TimeSlotNotAvailable };
    }
    public static OrderValidationError EmptyOrder()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.EmptyOrder };
    }

    public static OrderValidationError QuantityRange(OrderValidationProduct product)
    {
        return new OrderValidationError { Product = product, Type = OrderValidationErrorType.QuantityRange };
    }
    public static OrderValidationError InvalidProduct(OrderValidationProduct product, OrderValidationProduct? choice = null)
    {
        return new OrderValidationError { Product = product, ChoiceProduct = choice, Type = OrderValidationErrorType.InvalidProduct };
    }
    public static OrderValidationError ProductInactiveOrDisabled(OrderValidationProduct product, OrderValidationProduct? choiceProduct = null)
    {
        return new OrderValidationError { Product = product, ChoiceProduct = choiceProduct, Type = OrderValidationErrorType.ProductInactiveOrDisabled };
    }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderValidationErrorType
{
    InvalidTableNumber,

    QuantityRange,

    InvalidProduct,

    ProductInactiveOrDisabled,

    InvalidTimeSlot,

    TimeSlotNotAvailable,

    EmptyOrder,
}

public class OrderValidationService
{

    private AppDbContext _context;
    private MenuPresetService _menuPresets;
    private TimeSlotService _timeSlotService;
    private ILogger<OrderValidationService> _logger;

    public OrderValidationService(AppDbContext context, MenuPresetService menuPresetService, ILogger<OrderValidationService> logger, TimeSlotService timeSlotService)
    {
        _context = context;
        _menuPresets = menuPresetService;
        _logger = logger;
        _timeSlotService = timeSlotService;

    }

    public async Task<List<OrderValidationError>> ValidateOrder(ApiCreateOrderRequest order, DateTime? date = null)
    {
        if (date == null)
        {
            date = DateTime.Now;
        }
        var presets = await _menuPresets.GetPresets();
        var errors = new List<OrderValidationError>();
        var dateUnix = ((DateTimeOffset)date).ToUnixTimeSeconds();

        var timeSlot = await _context.TimeSlots.FindAsync(order.TimeSlotId);
        if (timeSlot == null)
        {
            errors.Add(OrderValidationError.InvalidTimeSlot());
        }
        else
        {
            if (!_timeSlotService.IsSlotAvailable(timeSlot))
            {
                errors.Add(OrderValidationError.TimeSlotNotAvailable());
            }
        }


        if (order.TableNumber != null)
        {
            var table = await _context.Tables.Where((t) => t.TableNumber == order.TableNumber).FirstOrDefaultAsync();
            if (table == null)
            {
                errors.Add(OrderValidationError.InvalidTableNumber());
            }
        }
        if (order.Items.Count == 0)
        {
            errors.Add(OrderValidationError.EmptyOrder());
        }

        for (int itemIndex = 0; itemIndex < order.Items.Count; itemIndex++)
        {
            ApiCreateOrderItemRequest? item = order.Items[itemIndex];

            if (item.Quantity < 1 || item.Quantity > 50)
            {
                errors.Add(OrderValidationError.QuantityRange(new OrderValidationProduct(item.ProductId, itemIndex)));
            }
            var product = await _context.Products.FindAsync(item.ProductId);
            if (product == null)
            {
                errors.Add(OrderValidationError.InvalidProduct(new OrderValidationProduct(item.ProductId, itemIndex)));
                continue;
            }
            if (!presets.IsProductActiveAndAvailable(product, date))
            {
                errors.Add(OrderValidationError.ProductInactiveOrDisabled(new OrderValidationProduct(item.ProductId, itemIndex)));
            }
            for (int choiceIndex = 0; choiceIndex < item.Choices.Count; choiceIndex++)
            {
                int choice = item.Choices[choiceIndex];
                // Check if the option exists on the product
                var chosenStepOption = await _context.ProductStepOptions.Include((o) => o.ProductStep).Where((stepOption) => stepOption.ProductId == choice && stepOption.ProductStep.ProductId == item.ProductId).FirstOrDefaultAsync();

                if (chosenStepOption == null)
                {
                    errors.Add(OrderValidationError.InvalidProduct(new OrderValidationProduct(item.ProductId, itemIndex), new OrderValidationProduct(choice, choiceIndex)));
                    continue;
                }
                var chosenProduct = await _context.Products.FindAsync(chosenStepOption.ProductId);
                if (chosenProduct == null)
                {
                    _logger.LogError($"BUG: Product step option in the database that points to non existant product {chosenProduct}.");
                    continue;
                }
                if (!presets.IsProductActiveAndAvailable(chosenProduct, date))
                {
                    errors.Add(OrderValidationError.ProductInactiveOrDisabled(new OrderValidationProduct(item.ProductId, itemIndex), new OrderValidationProduct(choice, choiceIndex)));
                }
            }
        }
        return errors;
    }
}
