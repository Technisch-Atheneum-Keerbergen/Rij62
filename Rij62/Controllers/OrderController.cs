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

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        
        // ************************************************************
        //                      *** CREATE ***
        //       POST: api/orders/AddOrder - Add a new order
        // ************************************************************

        [HttpPost("AddOrder")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrders", new { id = order.Id }, order);        
        }

        // ************************************************************ 
        //                      *** READ ***
        //   GET: api/orders/GetOrders - Get all orders or with id
        // ************************************************************

        [HttpGet("GetOrders/{id?}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int? id = null)
        {
            var orders = await _context.Orders.ToListAsync();
            if (orders == null || orders.Count == 0)
            {
                return NotFound();
            }
            if (id.HasValue)
            {
                orders = orders.Where(s => s.Id == id.Value).ToList();
            }
            return Ok(orders);
        }
        // ************************************************************
        //                      *** UPDATE ***
        //       PUT: api/orders/UpdateOrder/{id} - Update an order
        // ************************************************************
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order updatedOrder)
        {
            if (id != updatedOrder.Id)
            {
                return BadRequest();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.TableId = updatedOrder.TableId;
            order.PickupTime = updatedOrder.PickupTime;
            order.Status = updatedOrder.Status;

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }   

        // ************************************************************
        //                      *** DELETE ***
        //       DELETE: api/orders/DeleteOrder/{id} - Delete an order
        // ************************************************************
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}