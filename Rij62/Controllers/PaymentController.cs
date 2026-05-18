
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;

namespace Rij62.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{

    private readonly AppDbContext _context;
    public PaymentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("pay/{orderId}")]
    public async Task<IActionResult> Pay(Guid orderId)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var order = await _context.Orders.Where((o) => o.PublicId == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order not found");
            }
            if (order.PaymentComplete)
            {
                return BadRequest("Payment has already ");
            }
            if (order.PaymentId != null)
            {
                return BadRequest("Order payment is already in progress");
            }
            

            await transaction.CommitAsync();
        }

        return Ok();
    }

    [HttpGet("callback")]
    public async Task<IActionResult> BankcontactCallback()
    {

    }
}