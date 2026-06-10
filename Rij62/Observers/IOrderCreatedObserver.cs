using Rij62.Models;

namespace Rij62.Observers;

public interface IOrderCreatedObserver
{
    public Task OnOrderCreated(Order order);
}