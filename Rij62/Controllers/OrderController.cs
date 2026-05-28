using System.Diagnostics;
using System.Net.WebSockets;
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
        private readonly OrderValidationService _orderValidationService;
        private readonly UrlService _urlService;
        private readonly OrderEventsService _orderEventsService;
        private readonly OrderEventsWebsocketService _orderEventsWebsocketService;


        public OrderController(AppDbContext context, LocalizationService localization, OrderService orderService, UrlService urlService, OrderEventsService chefWebsocketService, OrderEventsWebsocketService orderEventsWebsocketService, OrderValidationService orderValidationService)
        {
            _context = context;
            _localization = localization;
            _orderService = orderService;
            _urlService = urlService;
            _orderEventsService = chefWebsocketService;
            _orderEventsWebsocketService = orderEventsWebsocketService;
            _orderValidationService = orderValidationService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("events")]
        public async Task Events([FromQuery] OrderFilter filter)
        {
            if (!HttpContext.WebSockets.IsWebSocketRequest)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _orderEventsWebsocketService.HandleWebsocketConnection(webSocket, filter);

        }


        [Authorize(Policy = "AdminOnly")]
        [HttpGet("")]
        public async Task<IActionResult> GetOrders([FromQuery] OrderFilter filter)
        {
            var orders = await _orderService.GetOrders(filter);
            var localizer = await _localization.GetLocalizer();
            return Ok(orders.Select((o) => ApiGetOrderResponse.FromOrder(o, localizer, _urlService, _orderService)));
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
            return Ok(ApiGetOrderResponse.FromOrder(order, localizer, _urlService, _orderService));
        }


        [HttpPost("validate")]
        public async Task<IActionResult> ValidateOrder([FromBody] ApiCreateOrderRequest apiOrder)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var errors = await _orderValidationService.ValidateOrder(apiOrder);
                await transaction.CommitAsync();
                return Ok(errors);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> PostOrder([FromBody] ApiCreateOrderRequest apiOrder)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var validationErrors = await _orderValidationService.ValidateOrder(apiOrder);
                if (validationErrors.Count > 0)
                {
                    return UnprocessableEntity(new ApiCreateOrderResponse
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

                    var orderItems = await OrderItem.FromApiPostOrderItem(item, order.Id, orderProduct.Id);
                    _context.OrderItems.AddRange(orderItems);
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

                        _context.OrderItemChoices.AddRange(OrderItemChoice.FromOrderItemsAndChoice(orderItems, chosenOrderProduct));
                        await _context.SaveChangesAsync();

                    }
                }

                await transaction.CommitAsync();

                var fetchedOrder = await _orderService.FetchOrders().Where((o) => o.Id == order.Id).FirstOrDefaultAsync();
                if (fetchedOrder == null)
                {
                    throw new Exception("BUG: Somehow an order has not been created but we just did?");
                }

                var localizer = await _localization.GetLocalizer();
                await _orderEventsService.BroadcastEvent(new ApiOrderAddedEvent(ApiGetOrderResponse.FromOrder(fetchedOrder, localizer, _urlService, _orderService)));
                return Ok(new ApiCreateOrderResponse { OrderId = order.PublicId, ValidationErrors = new List<OrderValidationError>() });
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
            var orderItems = _context.OrderItems.Where((oi) => oi.OrderId == order.Id).Select((oi) => ApiGetOrderItemStatusResponse.FromOrderItem(oi));
            return Ok(orderItems);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}/status/{orderItemid}")]
        public async Task<IActionResult> SetOrderStatus(Guid id, int orderItemid, [FromBody] ApiSetOrderItemStatusRequest status)
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

            item.Status = status.Status;

            await _context.SaveChangesAsync();

            await _orderEventsService.BroadcastEvent(new ApiOrderItemStatusUpdatedEvent(ApiGetOrderItemStatusResponse.FromOrderItem(item)));
            return Ok();
        }

    }
}
