using Rij62.Models;

namespace Rij62.Models.Api;

public class ApiCreateMenuPresetRequest
{
    public required string Name { get; set; }
    public required WeekDayRepeat Repeat { get; set; }
    public required bool Enabled { get; set; }
    public required int[] Products { get; set; }
}
