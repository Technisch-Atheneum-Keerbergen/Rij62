
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

    private readonly bool _allowBypassPayment;
    public PaymentController(AppDbContext context, ILogger<PaymentController> logger, PaymentService paymentService, OrderService orderService, BancontactService bancontactService, IConfiguration configuration)
    {
        _context = context;
        _logger = logger;
        _paymentService = paymentService;
        _orderService = orderService;
        _bancontactService = bancontactService;
        _allowBypassPayment = configuration.GetValue<bool?>("AllowBypassPayment") ?? false;
    }

    [HttpPost("pay/{orderId}")]
    public async Task<IActionResult> Pay(Guid orderId, bool bypassPayment)
    {
        if (bypassPayment && !_allowBypassPayment)
        {
            return StatusCode(418); // I'm a tea pot
        }

        string redirectUrl;
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var order = await _orderService.FetchOrders().Where((o) => o.PublicId == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order not found");
            }
            if (order.PaymentStatus != PaymentStatus.NotPaid)
            {
                return BadRequest("Payment has already started for this order");
            }
            if (order.PaymentId != null)
            {
                return BadRequest("Order payment is already in progress");
            }

            var amount = _orderService.CalcTotalOrderPrice(order);
            var resp = await _paymentService.CreatePayment(amount, order.OrderNumber, order.PublicId, bypassPayment);
            order.PaymentId = resp.PaymentId;
            redirectUrl = resp.Links.Deeplink;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            if (bypassPayment)
            {
                await _paymentService.ProcessPaymentStatusUpdate(new PaymentCallbackRequest { PaymentId = order.PaymentId, Status = "SUCCEEDED" });
            }
        }

        return Ok(new ApiCreatePaymentResponse { RedirectUrl = redirectUrl });
    }

    [HttpPost("callback")]
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
