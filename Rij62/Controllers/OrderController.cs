// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Controllers/OrderController.cs
// **********************************

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

        public OrderController(AppDbContext context, LocalizationService localization)
        {
            _context = context;
            _localization = localization;
        }


        [HttpPost("")]
        public async Task<ActionResult> PostOrder([FromBody] ApiPostOrder apiOrder)
        {

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                foreach (var item in apiOrder.Items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        return BadRequest($"Unknown product with id {item.ProductId}");
                    }

                    foreach (var choice in item.Choices)
                    {
                        // Check if the option exists on the product
                        var chosenStepOption = await _context.ProductStepOptions.Include((o) => o.ProductStep).Where((stepOption) => stepOption.ProductId == choice && stepOption.ProductStep.ProductId == item.ProductId).FirstOrDefaultAsync();
                        if (chosenStepOption == null)
                        {
                            return BadRequest($"Unknown product choice {choice} on product with id {item.ProductId}");
                        }
                    }
                }

                var order = Order.FromApiPostOrder(apiOrder);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in apiOrder.Items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        throw new UnreachableException("Validation has already happened above");
                    }
                    var orderItem = await OrderItem.FromProduct(product, _localization, order.Id);
                    _context.OrderItems.Add(orderItem);
                    await _context.SaveChangesAsync();

                    foreach (var choice in item.Choices)
                    {
                        var chosenProduct = await _context.Products.FindAsync(choice);
                        if (chosenProduct == null)
                        {
                            return BadRequest($"Unknown choice {choice} on product {item.ProductId}");
                        }
                        var orderItemChoice = new OrderItemChoice
                        {
                            OrderItemId = orderItem.Id,
                            StepNumber = 0,
                            ChosenProductId = choice,
                        };

                        _context.OrderItemChoices.Add(orderItemChoice);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(order.Id);
            }

        }

        [Authorize(Policy = "AdminOnly")]
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