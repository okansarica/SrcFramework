using System.Globalization;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class DateTimeExtensions
    {
        public static string ToTurkishShortDateString(this DateTime value)
        {
            return value.ToString("dd.MM.yyyy");
        }

        public static string ToTurhish24Time(this DateTime value)
        {
            return value.ToString("HH:mm", new CultureInfo("tr-tr"));
        }

        public static string ToTurkishLongDateString(this DateTime value)
        {
            return value.ToString("dd.MM.yyyy HH:mm");
        }

        public static string ToTurkishLongDateStringWithDay(this DateTime value)
        {
            return value.ToString("dddd dd.MMM.yyyy", new CultureInfo("tr-tr"));
        }
    }
}
