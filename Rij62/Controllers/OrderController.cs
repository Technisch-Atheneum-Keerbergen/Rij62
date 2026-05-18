using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Services;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LocalizationService _localization;
        private readonly OrderService _orderService;
        private readonly UrlService _urlService;

        public OrderController(AppDbContext context, LocalizationService localization, OrderService orderService, UrlService urlService)
        {
            _context = context;
            _localization = localization;
            _orderService = orderService;
            _urlService = urlService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders(int count = 100)
        {
            var localizer = await _localization.GetLocalizer();
            var orders = await _orderService.FetchOrders()
              .Where((o) => !o.OrderItems.All((o) => o.Status == OrderStatus.PickedUp))
              .OrderBy((o) => o.PickupTime)
              .Take(count)
              .ToArrayAsync();

            return Ok(orders.Select((o) => ApiGetOrder.FromOrder(o, localizer, _urlService)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {

            var order = await _orderService.FetchOrders()
              .Where((o) => o.PublicId == id).FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }
            var localizer = await _localization.GetLocalizer();
            return Ok(ApiGetOrder.FromOrder(order, localizer, _urlService));
        }


        [HttpPost("validate")]
        public async Task<IActionResult> ValidateOrder([FromBody] ApiPostOrder apiOrder)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var errors = await _orderService.ValidateOrder(apiOrder);
                await transaction.CommitAsync();
                return Ok(errors);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> PostOrder([FromBody] ApiPostOrder apiOrder)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var validationErrors = await _orderService.ValidateOrder(apiOrder);
                if (validationErrors.Count > 0)
                {
                    return UnprocessableEntity(new ApiPostOrderResponse
                    {
                        OrderId = null,
                        ValidationErrors = validationErrors
                    });
                }

                var order = Order.FromApiPostOrder(apiOrder);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in apiOrder.Items)
                {
                    var product = await _context.Products
                      .Include((p) => p.Category)
                      .Where((p) => p.Id == item.ProductId)
                      .FirstOrDefaultAsync();

                    if (product == null)
                    {
                        throw new UnreachableException("Validation has already happened above");
                    }
                    var orderProduct = await OrderProduct.FromProduct(product, _localization);
                    _context.OrderProducts.Add(orderProduct);
                    await _context.SaveChangesAsync();

                    var orderItem = await OrderItem.FromApiPostOrderItem(item, order.Id, orderProduct.Id);
                    _context.OrderItems.Add(orderItem);
                    await _context.SaveChangesAsync();

                    foreach (var choice in item.Choices)
                    {
                        var chosenProduct = await _context.Products
                          .Include((p) => p.Category)
                          .Where((p) => p.Id == choice)
                          .FirstOrDefaultAsync();

                        if (chosenProduct == null)
                        {
                            throw new UnreachableException("Validation has already happened above");
                        }

                        var chosenOrderProduct = await OrderProduct.FromProduct(chosenProduct, _localization);
                        _context.OrderProducts.Add(chosenOrderProduct);
                        await _context.SaveChangesAsync();

                        var orderItemChoice = new OrderItemChoice
                        {
                            ChosenOrderProductId = chosenOrderProduct.Id,
                            OrderItemId = orderItem.Id,
                            StepNumber = 0, // We may in the future use this.
                        };
                        _context.OrderItemChoices.Add(orderItemChoice);
                        await _context.SaveChangesAsync();

                    }
                }

                await transaction.CommitAsync();
                return Ok(new ApiPostOrderResponse { OrderId = order.PublicId, ValidationErrors = new List<OrderValidationError>() });
            }

        }


        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetOrderStatus(Guid id)
        {
            var order = await _context.Orders.Where((o) => o.PublicId == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound();
            }
            var orderItems = _context.OrderItems.Where((oi) => oi.OrderId == order.Id).Select((oi) => ApiOrderItemStatus.FromOrderItem(oi));
            return Ok(orderItems);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}/status/{orderItemid}")]
        public async Task<IActionResult> SetOrderStatus(Guid id, int orderItemid, [FromBody] OrderStatus status)
        {

            var order = await _context.Orders.Where((o) => o.PublicId == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order was found");
            }
            var item = await _context.OrderItems.Where((oi) => oi.Id == orderItemid && oi.OrderId == order.Id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound("Order item was not found");
            }
            item.Status = status;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
