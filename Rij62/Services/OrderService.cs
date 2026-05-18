using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Services;


public struct OrderValidationError
{
    public int? ProductId { get; set; }
    public int? ChoiceProductId { get; set; }
    public required OrderValidationErrorType Type { get; set; }

    public static OrderValidationError InvalidTableNumber()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.InvalidTableNumber };
    }
    public static OrderValidationError PastPickupTime()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.PastPickupTime };
    }
    public static OrderValidationError PickupTimeTooFar()
    {
        return new OrderValidationError { Type = OrderValidationErrorType.PickupTimeTooFar };
    }

    public static OrderValidationError QuantityRange(int productId)
    {
        return new OrderValidationError { ProductId = productId, Type = OrderValidationErrorType.QuantityRange };
    }
    public static OrderValidationError InvalidProduct(int productId, int? choiceId = null)
    {
        return new OrderValidationError { ProductId = productId, ChoiceProductId = choiceId, Type = OrderValidationErrorType.InvalidProduct };
    }
    public static OrderValidationError ProductInactiveOrDisabled(int productId, int? choiceProductId = null)
    {
        return new OrderValidationError { ProductId = productId, ChoiceProductId = choiceProductId, Type = OrderValidationErrorType.ProductInactiveOrDisabled };
    }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderValidationErrorType
{
    InvalidTableNumber,

    QuantityRange,

    InvalidProduct,

    ProductInactiveOrDisabled,

    PastPickupTime,

    PickupTimeTooFar,
}


public class OrderService
{

    private AppDbContext _context;
    private MenuPresetService _menuPresets;

    private ILogger<OrderService> _logger;
    public OrderService(AppDbContext context, MenuPresetService menuPreset, ILogger<OrderService> logger)
    {
        _context = context;
        _menuPresets = menuPreset;
        _logger = logger;
    }

    public decimal CalcTotalOrderPayAmount(Order order)
    {
        if (order.OrderItems == null)
        {
            throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
        }

        decimal total = 0;
        foreach (var item in order.OrderItems)
        {

            if (item.OrderProduct == null)
            {
                throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
            }
            if (item.Choices == null)
            {
                throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
            }

            total += item.OrderProduct.Price;
            foreach (var choice in item.Choices)
            {
                if (choice.ChosenOrderProduct == null)
                {
                    throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
                }
                total += choice.ChosenOrderProduct.Price;
            }
        }
        return total;
    }

    public IIncludableQueryable<Order, OrderProduct> FetchOrders()
    {
        return _context.Orders
          .Include((o) => o.OrderItems)
          .ThenInclude((oi) => oi.OrderProduct)
          .Include((o) => o.OrderItems)
          .ThenInclude((oi) => oi.Choices)
          .ThenInclude((choice) => choice.ChosenOrderProduct);
    }

    public async Task<List<OrderValidationError>> ValidateOrder(ApiPostOrder order)
    {
        var errors = new List<OrderValidationError>();
        var date = DateTime.Now;
        var presets = await _menuPresets.GetPresets();

        var dateUnix = ((DateTimeOffset)date).ToUnixTimeSeconds();

        if (order.PickupTime != null && order.PickupTime < dateUnix)
        {
            errors.Add(OrderValidationError.PastPickupTime());
        }
        if (order.PickupTime > dateUnix + (60 * 60 * 24 * 7))
        {
            errors.Add(OrderValidationError.PickupTimeTooFar());
        }

        if (order.TableNumber != null)
        {
            var table = await _context.Tables.Where((t) => t.TableNumber == order.TableNumber).FirstOrDefaultAsync();
            if (table == null)
            {
                errors.Add(OrderValidationError.InvalidTableNumber());
            }
        }

        foreach (var item in order.Items)
        {
            if (item.Quantity < 1 || item.Quantity > 50)
            {
                errors.Add(OrderValidationError.QuantityRange(item.ProductId));
            }
            var product = await _context.Products.FindAsync(item.ProductId);
            if (product == null)
            {
                errors.Add(OrderValidationError.InvalidProduct(item.ProductId));
                continue;
            }
            if (!presets.IsProductActiveAndAvailable(product, date))
            {
                errors.Add(OrderValidationError.ProductInactiveOrDisabled(item.ProductId));
            }
            foreach (var choice in item.Choices)
            {
                // Check if the option exists on the product
                var chosenStepOption = await _context.ProductStepOptions.Include((o) => o.ProductStep).Where((stepOption) => stepOption.ProductId == choice && stepOption.ProductStep.ProductId == item.ProductId).FirstOrDefaultAsync();

                if (chosenStepOption == null)
                {
                    errors.Add(OrderValidationError.InvalidProduct(item.ProductId, choice));
                    continue;
                }
                var chosenProduct = await _context.Products.FindAsync(chosenStepOption.ProductId);
                if (chosenProduct == null)
                {
                    _logger.LogError($"BUG: Product step option in the database that points to non existant product {chosenProduct}.");
                    continue;
                }
                if (!presets.IsProductActiveAndAvailable(product, date))
                {
                    errors.Add(OrderValidationError.ProductInactiveOrDisabled(item.ProductId, choice));
                }
            }
        }
        return errors;
    }

    public async Task DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);

        _context.OrderItems.RemoveRange(order.OrderItems);
        _context.OrderProducts.RemoveRange(order.OrderItems.Select((oi) => oi.OrderProduct));

        foreach (var item in order.OrderItems)
        {
            _context.OrderItemChoices.RemoveRange(item.Choices);
            _context.OrderProducts.Remove(item.OrderProduct);
        }
    }

}
