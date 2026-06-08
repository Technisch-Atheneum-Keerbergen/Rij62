
using Rij62.Models;
using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetTimeSlotResponse
{
    public required int Id { get; set; }
    public required int StartTime { get; set; } // Time in seconds since midnight
    public required int EndTime { get; set; } // Time in seconds since midnight
    public required bool Locked { get; set; }
    public required int Occupation { get; set; }

    public static async Task<ApiGetTimeSlotResponse> FromTimeSlot(TimeSlot slot, OrderService? orderService)
    {
        var occupation = orderService != null ? await orderService.OrdersInTimeSlot(slot) : -1;
        return new ApiGetTimeSlotResponse
        {
            Id = slot.Id,
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            Locked = slot.Locked,
            Occupation = occupation,
        };
    }
}