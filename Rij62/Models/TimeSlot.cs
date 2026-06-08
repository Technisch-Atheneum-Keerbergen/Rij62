
using Rij62.Models.Api;

namespace Rij62.Models;

public class TimeSlot
{
    public int Id { get; set; }

    public bool Locked { get; set; }
    public bool HasAutoLockedToday { get; set; }
    public required int StartTime { get; set; } // Seconds since midnight
    public required int EndTime { get; set; } // Seconds since midnight

    public TimeSlot FromApiCreateTimeSlotRequest(ApiCreateTimeSlotRequest req)
    {
        return new TimeSlot
        {
            Locked = req.Locked,
            HasAutoLockedToday = false,
            StartTime = req.StartTime,
            EndTime = req.EndTime,
        };
    }
}