
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Observers;

namespace Rij62.Services;

public class TimeSlots
{
    private TimeSlot[] _slots;
    public TimeSlots(TimeSlot[] slots)
    {
        _slots = slots;
    }
    public TimeSlot? GetSlot(int id)
    {
        return _slots.FirstOrDefault((s) => s.Id == id);
    }
    public IEnumerable<TimeSlot> Slots()
    {
        return _slots;
    }
}

public class TimeSlotService : IMidnightResetObserver
{
    private readonly AppDbContext _context;

    private const int PaddingSeconds = 30;

    private TimeSlots? _timeSlots = null;

    public TimeSlotService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<TimeSlots> GetTimeSlots()
    {
        if (_timeSlots != null)
        {
            return _timeSlots;
        }
        _timeSlots = new TimeSlots(await _context.TimeSlots.ToArrayAsync());
        return _timeSlots;
    }

    private bool ShouldAutoLock(TimeSlot slot, TimeOnly now)
    {
        if (slot.HasAutoLockedToday)
        {
            return false;
        }

        var startTime = TimeSpan.FromSeconds(slot.StartTime - PaddingSeconds);

        return !now.IsBetween(TimeOnly.FromTimeSpan(startTime), TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(slot.EndTime)));
    }



    public async Task AutoLockIfNeeded(TimeSlot slot)
    {
        if (ShouldAutoLock(slot, TimeOnly.FromDateTime(DateTime.UtcNow)))
        {
            slot.HasAutoLockedToday = true;
            slot.Locked = true;
            _context.Entry(slot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public bool IsSlotAvailable(TimeSlot slot)
    {
        return !slot.Locked;
    }

    public async Task MidnightReset()
    {
        await _context.TimeSlots.ExecuteUpdateAsync((s) => s
            .SetProperty((s) => s.HasAutoLockedToday, (_) => false)
            .SetProperty((s) => s.Locked, (_) => false)
        );
    }
}