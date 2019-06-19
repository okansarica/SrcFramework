
namespace System
{
    public static class NullableExtensions
    {
        public static int? ParseToNullableInt(this string text)
        {
            if (int.TryParse(text, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
