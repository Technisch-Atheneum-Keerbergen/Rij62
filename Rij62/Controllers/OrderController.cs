// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Controllers/OrderController.cs
// **********************************

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

        public OrderController(AppDbContext context, LocalizationService localization)
        {
            _context = context;
            _localization = localization;
        }


        [HttpPost("")]
        public async Task<ActionResult> PostOrder([FromBody] ApiPostOrder apiOrder)
        {
            var order = Order.FromApiPostOrder(apiOrder);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderItems = new List<OrderItem>();
            foreach (var item in apiOrder.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return BadRequest("Unknown product id " + item.ProductId);
                }
                orderItems.Add(await OrderItem.FromProduct(product, _localization, order.Id));

            }

            _context.OrderItems.AddRange(orderItems);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.Include((o) => o.OrderItems).FirstOrDefaultAsync((o) => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var localizer = await _localization.GetLocalizer();
            return Ok(ApiGetOrder.FromOrder(order, localizer));
        }

        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetOrderStatus(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.Status);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> SetOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = status;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}