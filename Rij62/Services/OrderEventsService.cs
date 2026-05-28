using System.Collections.Immutable;
using System.Threading.Channels;
using Rij62.Models.Api;

namespace Rij62.Services;

public struct EventReader
{
    public ChannelReader<ApiOrderEvent> Channel { private set; get; }
    private Guid _id;
}


public class OrderEventsService
{

    private ImmutableArray<Channel<ApiOrderEvent>> _channels = ImmutableArray<Channel<ApiOrderEvent>>.Empty;

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


    public async Task BroadcastEvent(ApiOrderEvent ev)
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
}
