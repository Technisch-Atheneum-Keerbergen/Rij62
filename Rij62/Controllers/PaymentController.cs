
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Bancontact;
using Rij62.Services;

namespace Rij62.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly PaymentService _paymentService;
    private readonly ILogger<PaymentController> _logger;
    private readonly OrderService _orderService;
    public PaymentController(AppDbContext context, ILogger<PaymentController> logger, PaymentService paymentService, OrderService orderService)
    {
        _context = context;
        _logger = logger;
        _paymentService = paymentService;
        _orderService = orderService;
    }

    [HttpPost("pay/{orderId}")]
    public async Task<IActionResult> Pay(Guid orderId)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var order = await _orderService.FetchOrders().Where((o) => o.PublicId == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order not found");
            }
            if (order.PaymentStatus != PaymentStatus.NotStarted)
            {
                return BadRequest("Payment has already started for this order");
            }
            if (order.PaymentId != null)
            {
                return BadRequest("Order payment is already in progress");
            }

            var amount = _orderService.CalcTotalOrderPayAmount(order);
            var resp = await _paymentService.CreatePayment(amount);
            order.PaymentId = resp.PaymentId;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return Ok();
    }

    [HttpGet("callback")]
    public async Task<IActionResult> BankcontactCallback([FromBody] PaymentCallbackRequest req)
    {
        //TODO: validate bancontact jwt token.
        //TODO: fallback to Get Payment Details

        var order = await _context.Orders.Where((o) => o.PaymentId == req.PaymentId).FirstOrDefaultAsync();
        if (order == null)
        {
            // mmmm this shouldn't happen.
            _logger.LogError("No order with PaymentId returned from Bancontact callback was found");
            // Return OK because else Bancontact will retry the request.
            return Ok();
        }


        //TODO: figure this out better
        if (req.Status == "VOIDED" || req.Status == "EXPIRED" || req.Status == "CANCELLED" || req.Status == "FAILED")
        {
            await _orderService.DeleteOrder(order);
        }

        if (req.Status == "SUCCEEDED")
        {
            if (order.PaymentStatus == PaymentStatus.Success)
            {
                _logger.LogError("Somehow two payments were made for the same order???? There should be validation in place when the payment gets created????");
            }

            order.PaymentStatus = PaymentStatus.Success;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
