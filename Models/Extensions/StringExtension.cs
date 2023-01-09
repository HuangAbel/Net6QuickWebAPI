namespace Models.Extensions
{
    public static class StringExtension
    {
        public static DateTime? ToDateTime(this string? str)
        {
            DateTime parseDatetime;
            if (!string.IsNullOrWhiteSpace(str) && DateTime.TryParse(str, out parseDatetime))
            {
                return parseDatetime;
            }
            return null;
        }
    }
}
