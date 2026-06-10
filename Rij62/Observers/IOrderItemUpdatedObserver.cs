
using Rij62.Models;

namespace Rij62.Observers;

public interface IOrderItemUpdatedObserver
{
    public Task OnOrderItemUpdated(OrderItem item);
}