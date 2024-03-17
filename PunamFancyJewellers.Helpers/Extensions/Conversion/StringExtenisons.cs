namespace PunamFancyJewellers.Helpers.Extensions.Conversion
{
    public static class StringExtenisons
    {
        public static bool ToBoolean(this string? str, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return defaultValue;
            }
            return str.ToLower() == "true";
        }

        public static int ToInt(this string? str, int defaultValue = 0)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return defaultValue;
            }
            return int.Parse(str);
        }
    }
}