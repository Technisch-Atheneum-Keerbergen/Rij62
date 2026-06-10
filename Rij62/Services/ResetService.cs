
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Observers;

namespace Rij62.Services;

public class ResetService : BackgroundService
{

    private IServiceProvider _services { get; }

    public ResetService(IServiceProvider services)
    {
        _services = services;
    }

    public async Task Reset(IServiceProvider provider)
    {

        await Task.WhenAll(provider.GetRequiredService<IEnumerable<IMidnightResetObserver>>().Select((t) => t.MidnightReset()));
        var ctx = provider.GetRequiredService<AppDbContext>();
        ctx.midnightResetLogs.Add(new MidnightResetLog { Timestamp = new DateTimeOffset(DateTime.UtcNow) });
        await ctx.SaveChangesAsync();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _services.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var lastReset = await ctx.midnightResetLogs.OrderBy((l) => l.Timestamp).Take(1).SingleOrDefaultAsync();
            if (lastReset != null)
            {
                var timeSinceLastReset = DateTime.UtcNow - lastReset.Timestamp;
                if (timeSinceLastReset.TotalDays >= 1)
                {
                    await Reset(scope.ServiceProvider);
                }
            }

        }
        while (!stoppingToken.IsCancellationRequested)
        {
            var timeUntilMidnight = DateTime.UtcNow.TimeOfDay - TimeSpan.FromHours(24);

            await Task.Delay((int)timeUntilMidnight.TotalMilliseconds);

            using (var scope = _services.CreateScope())
            {
                await Reset(scope.ServiceProvider);
            }
        }
    }
}
