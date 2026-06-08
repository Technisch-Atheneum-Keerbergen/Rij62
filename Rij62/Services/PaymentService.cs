
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Bancontact;

namespace Rij62.Services;

public class PaymentService
{

    private AppDbContext _context;
    private ILogger<PaymentService> _logger;
    private BancontactService _bancontactService;
    private OrderService _orderService;
    private UrlService _urlService;

    public PaymentService(BancontactService bancontactService, AppDbContext context, ILogger<PaymentService> logger, OrderService orderService, UrlService urlService)
    {
        _context = context;
        _logger = logger;
        _bancontactService = bancontactService;
        _orderService = orderService;
        _urlService = urlService;
    }


    public async Task<CreatePaymentResponse> CreatePayment(decimal amount, int orderNumber, Guid orderId, bool bypassPayment = false)
    {
        if (bypassPayment)
        {
            var paymentId = "bypassedPayment-" + Guid.NewGuid().ToString();
            return new CreatePaymentResponse
            {
                PaymentId = paymentId,
                Links = new CreatePaymentResponse.LinksResponse
                {
                    Deeplink = new CreatePaymentResponse.Link { Href = _urlService.GetPaymentReturnUrl(orderId) }
                }

            };
        }

        return await _bancontactService.CreatePayment(amount, orderNumber, orderId);
    }

    public async Task RecoverOrders()
    {
        var orders = await _context.Orders.Include((o) => o.OrderItems).Where((o) => o.PaymentId != null && o.PaymentStatus == PaymentStatus.NotPaid && !o.IsPickedUp()).ToArrayAsync();
        foreach (var order in orders)
        {
            _logger.LogInformation("Trying to recover order");
            var info = await _bancontactService.GetPaymentInfo(order.PaymentId!);
            var success = await ProcessPaymentStatusUpdate(info, order);
            if (success)
            {
                _logger.LogInformation("Order successfully recovered");
            }
        }
    }

    public async Task<bool> ProcessPaymentStatusUpdate(PaymentCallbackRequest callbackRequest, Order? order = null)
    {
        if (order == null)
        {
            order = await _context.Orders.Where((o) => o.PaymentId == callbackRequest.PaymentId).FirstOrDefaultAsync();
        }
        if (order == null)
        {
            // mmmm this shouldn't happen.
            _logger.LogError("BUG: No order with PaymentId returned from Bancontact callback was found");
            return false;
        }

        var status = callbackRequest.Status;
        if (status == "VOIDED" || status == "EXPIRED" || status == "CANCELLED" || status == "FAILED" || status == "AUTHORIZATION_FAILED")
        {
            await _orderService.UpdateOrderPaymentStatus(order, PaymentStatus.Failed);
            return true;
        }

        if (status == "SUCCEEDED")
        {
            // The order may be picked up by the recovery service early. This may cause a callback to be summitted for an order that has an already completed payment.
            if (order.PaymentStatus == PaymentStatus.Success)
            {
                return true;
            }

            await _orderService.UpdateOrderPaymentStatus(order, PaymentStatus.Success);
            return true;
        }
        return false;
    }

}
