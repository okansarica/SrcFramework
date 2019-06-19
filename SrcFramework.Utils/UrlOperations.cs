namespace SrcFramework.Utils
{
    public class UrlOperations
    {
        public static string GenerateUrl(string value)
        {
            value = value.ToLower();
            value = value.Replace("ü", "u");
            value = value.Replace("ğ", "g");
            value = value.Replace("ş", "s");
            value = value.Replace("ı", "i");
            value = value.Replace("ö", "o");
            value = value.Replace("ç", "c");
            value = value.Replace("ı", "i");
            value = value.Replace("/", "-");
            value = value.Replace("&", "-");
            value = value.Replace("%", "-");
            value = value.Replace("*", "-");
            value = value.Replace(" ", "-");
            value = value.Replace(".", "");
            value = value.Replace("'", "");
            return value; 
        }
    }
}
