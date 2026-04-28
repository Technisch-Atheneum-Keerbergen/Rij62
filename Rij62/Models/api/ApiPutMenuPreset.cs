using Rij62.Models;

namespace Rij62.Models.Api;

public class ApiPutMenuPreset
{
    public required string Name { get; set; }
    public WeekDayRepeat Repeat { get; set; }
    public bool Enabled { get; set; }
}
