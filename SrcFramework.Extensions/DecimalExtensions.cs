using System.Globalization;
// ReSharper disable CheckNamespace

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

        public static string ToMoneyString(this decimal value,string currencyCode)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencySymbol = currencyCode;
            culture.NumberFormat.CurrencyPositivePattern = 2;

            return string.Format(culture, "{0:C2}", value);
        }
    }
}
