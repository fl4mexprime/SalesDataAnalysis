﻿namespace SalesDataAnalysis.Extensions
{
    public static class StringExtensions {
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