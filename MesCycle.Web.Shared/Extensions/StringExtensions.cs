namespace MesCycle.Web.Shared.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Author: Can DOĞU
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
