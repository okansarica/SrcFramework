using System.Globalization;

namespace System
{
    public static class DecimalExtensions
    {
        public static string ToTurkishMoneyString(this decimal value)
        {
            return value.ToString("n2", new CultureInfo("tr-tr"));
        }

        public static string ToTurkishMoneyString(this decimal? value)
        {
            return value?.ToString("n2", new CultureInfo("tr-tr"));
        }        
    }
}
