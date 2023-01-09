namespace Models.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToISOString(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            return "";
        }
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDefaultString(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("yyyy-MM-dd");
            }
            return "";
        }
    }
}
