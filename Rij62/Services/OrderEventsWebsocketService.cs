namespace Rij62.Services;

using System.Net.WebSockets;
using System.Threading.Channels;
using Rij62.Models.Api;

public class OrderEventsWebsocketService
{

    private readonly LocalizationService _localization;
    private readonly OrderService _orderService;
    private readonly UrlService _urlService;
    private readonly OrderEventsService _orderEventService;
    private readonly IHostApplicationLifetime _lifetime;

    public OrderEventsWebsocketService(LocalizationService localizationService, OrderService orderService, UrlService urlService, OrderEventsService orderEventsService, IHostApplicationLifetime lifetime)
    {
        _localization = localizationService;
        _orderService = orderService;
        _urlService = urlService;
        _orderEventService = orderEventsService;
        _lifetime = lifetime;

    }

    public async Task HandleWebsocketConnection(WebSocket socket, OrderFilter filter)
    {

        var localizer = await _localization.GetLocalizer();

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(_lifetime.ApplicationStopping);

        var channel = _orderEventService.SubscribeReader();
        try
        {

            var orders = (await _orderService.GetOrders(filter)).Select((o) => new ApiOrderAddedEvent(ApiGetOrderResponse.FromOrder(o, localizer, _urlService))).ToAsyncEnumerable();


            await Task.WhenAny(ReceiveLoop(socket, cts), HandleSending(socket, orders, channel.Reader, cts.Token));
        }
        finally
        {
            _orderEventService.Unsubscribe(channel);
        }
    }

    private async Task HandleSending(WebSocket socket, IAsyncEnumerable<ApiOrderEvent> initialEvents, ChannelReader<ApiOrderEvent> reader, CancellationToken ct)
    {
        await SendEvents(socket, initialEvents);
        await SendEvents(socket, reader.ReadAllAsync(ct));
    }


    private async Task SendEvents(WebSocket socket, IAsyncEnumerable<ApiOrderEvent> events)
    {
        await foreach (var ev in events)
        {
            if (socket.State != WebSocketState.Open)
            {
                break;
            }
            var json = ev.Serialize();
            await socket.SendAsync(
                json,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }

    private async Task ReceiveLoop(
        WebSocket socket,
        CancellationTokenSource cts)
    {
        try
        {
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(
                    new ArraySegment<byte>(new byte[1]),
                    cts.Token);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    cts.Cancel();
                    return;
                }
            }
        }
        catch
        {
            cts.Cancel();
            throw;
        }
    }

}
