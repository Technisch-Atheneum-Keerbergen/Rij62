
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services;

public class PaymentRecoveryService : BackgroundService
{
    private IServiceProvider _services { get; }

    public PaymentRecoveryService(IServiceProvider services)
    {
        _services = services;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("tick");
        using (var scope = _services.CreateScope())
        {
            var paymentService = scope.ServiceProvider.GetRequiredService<PaymentService>();

            await paymentService.RecoverOrders();

        }
    }



}