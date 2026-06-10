using System.Collections.Immutable;
using System.Threading.Channels;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Observers;

namespace Rij62.Services;

public struct EventReader
{
    public ChannelReader<ApiOrderEvent> Channel { private set; get; }
    private Guid _id;
}


public class OrderEventsService : IOrderCreatedObserver, IOrderItemUpdatedObserver, IOrderPaymentStatusUpdatedObserver
{

    private readonly LocalizationService _localizationService;
    private readonly UrlService _urlService;
    private readonly OrderService _orderService;

    private ImmutableArray<Channel<ApiOrderEvent>> _channels = ImmutableArray<Channel<ApiOrderEvent>>.Empty;

    public OrderEventsService(LocalizationService localizationService, UrlService urlService, OrderService orderService)
    {
        _localizationService = localizationService;
        _urlService = urlService;
        _orderService = orderService;
    }

    public Channel<ApiOrderEvent> SubscribeReader()
    {
        var channel = Channel.CreateBounded<ApiOrderEvent>(new BoundedChannelOptions(10)
        {
            SingleReader = true,
        });
        ImmutableInterlocked.Update(ref _channels, old => old.Add(channel));
        return channel;
    }

    public void Unsubscribe(Channel<ApiOrderEvent> reader)
    {
        reader.Writer.Complete();
        ImmutableInterlocked.Update(ref _channels, old =>
        {
            return old.Remove(reader);
        });
    }


    private async Task BroadcastEvent(ApiOrderEvent ev)
    {
        await Task.WhenAll(
            _channels.Select(c =>
            {
                using var cts = new CancellationTokenSource(1000);
                try
                {
                    return c.Writer.WriteAsync(ev, cts.Token).AsTask();
                }
                catch (OperationCanceledException)
                {
                    // Consumer too slow.
                    return Task.CompletedTask;
                }
                catch (ChannelClosedException)
                {
                    // This only happens during an Unsubscribe. Ignore this because it will be handled by the reset of the Unsubscribe code.
                    return Task.CompletedTask;
                }
            }));
    }

    public async Task OnOrderCreated(Order order)
    {
        var localizer = await _localizationService.GetLocalizer();
        await BroadcastEvent(new ApiOrderAddedEvent(ApiGetOrderResponse.FromOrder(order, localizer, _urlService, _orderService)));

    }

    public async Task OnOrderItemUpdated(OrderItem item)
    {
        await BroadcastEvent(new ApiOrderItemStatusUpdatedEvent(ApiGetOrderItemStatusResponse.FromOrderItem(item)));
    }

    public async Task OnOrderPaymentStatusUpdated(Order order, PaymentStatus status)
    {
        await BroadcastEvent(new ApiOrderPaymentStatusUpdatedEvent(ApiGetOrderPaymentStatusResponse.FromOrderIdAndStatus(order.PublicId, status)));

    }

}
