
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Models.Bancontact;
using Rij62.Services;

namespace Rij62.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly PaymentService _paymentService;
    private readonly BancontactService _bancontactService;
    private readonly ILogger<PaymentController> _logger;
    private readonly OrderService _orderService;
    public PaymentController(AppDbContext context, ILogger<PaymentController> logger, PaymentService paymentService, OrderService orderService, BancontactService bancontactService)
    {
        _context = context;
        _logger = logger;
        _paymentService = paymentService;
        _orderService = orderService;
        _bancontactService = bancontactService;
    }

    [HttpPost("pay/{orderId}")]
    public async Task<IActionResult> Pay(Guid orderId)
    {
        string redirectUrl;
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
            redirectUrl = resp.Links.Deeplink;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return Ok(new ApiPostPaymentResponse { RedirectUrl = redirectUrl });
    }

    [HttpGet("callback")]
    public async Task<IActionResult> BankcontactCallback([FromBody] PaymentCallbackRequest req)
    {
        var result = await Request.BodyReader.ReadAsync();
        string? sig = Request.Headers["signature"];
        if (sig == null)
        {
            _logger.LogError("Request made to the bancontact callback without a 'signature' header");
            return BadRequest("'signature' header is required");
        }
        await _bancontactService.ValidateCallbackSignature(sig, result.Buffer);

        await _paymentService.ProcessPaymentStatusUpdate(req);

        return Ok();
    }
}
