using System;
using System.Globalization;
namespace Stockify.Extensions;
public static class DateTimeExtensions
{
    public static string ToBelgianFormat(this DateTime? dateTime, string format = "dd/MM/yyyy HH:mm")
    {
        if (!dateTime.HasValue)
            return string.Empty;

        return dateTime.Value.ToBelgianFormat(format);
    }
    public static string ToBelgianFormat(this DateTime utcDateTime, string format = "dd/MM/yyyy HH:mm")
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        var localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
        return localTime.ToString(format, new CultureInfo("nl-BE"));
    }
}
