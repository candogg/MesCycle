namespace MesCycle.ClientApp.Extensions
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public static class StringExtensions
    {
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
