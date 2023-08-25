namespace SalesDataAnalysis.Extensions
{
    /// <summary>
    /// Extensions for working with strings
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// Casts first letter to upper case
        /// </summary>
        /// <param name="source">your string</param>
        /// <returns>string</returns>
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            
            var letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            
            return new string(letters);
        }
    }
}