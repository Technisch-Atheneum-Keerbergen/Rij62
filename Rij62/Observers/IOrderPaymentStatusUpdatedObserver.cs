using Rij62.Models;

namespace Rij62.Observers;

public interface IOrderPaymentStatusUpdatedObserver
{
    public Task OnOrderPaymentStatusUpdated(Order order, PaymentStatus status);
}