namespace Rij62.Models.Api;

public class ApiCreateTimeSlotRequest
{
    public required int StartTime { get; set; } // Time in seconds since midnight
    public required int EndTime { get; set; } // Time in seconds since midnight
    public required bool Locked { get; set; }
}