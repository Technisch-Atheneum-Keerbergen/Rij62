using System.Text.Json.Serialization;

namespace Rij62.Models;

[JsonConverter(typeof(JsonStringFlagsEnumConverter))]
[Flags]
public enum WeekDayRepeat
{
    None = 0,
    Monday = 1 << 0,
    Tuesday = 1 << 1,
    Wednesday = 1 << 2,
    Thureday = 1 << 3,
    Friday = 1 << 4,
    Saturday = 1 << 5,
    Sunday = 1 << 6,
}

public static class WeekDayRepeatHelper
{

    public static WeekDayRepeat FromDayOfWeek(DayOfWeek week)
    {
        switch (week)
        {
            case DayOfWeek.Monday:
                return WeekDayRepeat.Monday;
            case DayOfWeek.Tuesday:
                return WeekDayRepeat.Tuesday;
            case DayOfWeek.Wednesday:
                return WeekDayRepeat.Wednesday;
            case DayOfWeek.Thursday:
                return WeekDayRepeat.Thureday;
            case DayOfWeek.Friday:
                return WeekDayRepeat.Friday;
            case DayOfWeek.Saturday:
                return WeekDayRepeat.Saturday;
            case DayOfWeek.Sunday:
                return WeekDayRepeat.Sunday;
        }
        return WeekDayRepeat.None;
    }
}
