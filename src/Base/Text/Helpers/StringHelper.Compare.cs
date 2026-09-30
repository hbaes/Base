namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class StringHelper
    {
        /// <summary>
        /// Returns <c>true</c> if the two strings match.
        /// </summary>
        /// <param name="firstString">First string</param>
        /// <param name="secondString">Second string</param>
        /// <returns>
        /// <c>true</c>or <c>false</c>
        /// </returns>
        /// <remarks>
        /// The strings are trimmed and compared in a case-insensitive, culture neutral fashion.
        /// </remarks>
        public static bool Compare(string firstString, string secondString)
        {
            return Compare(firstString, secondString, CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Returns <c>true</c> if the two strings match.
        /// </summary>
        /// <param name="firstString">First string.</param>
        /// <param name="secondString">Second string.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        /// <c>true</c>or <c>false</c>
        /// </returns>
        /// <remarks>
        /// The strings are trimmed and compared based on the given <paramref name="culture"/>.
        /// </remarks>
        public static bool Compare(string firstString, string secondString, CultureInfo culture)
        {
            int pos = string.Compare(firstString.Trim(), secondString.Trim(), true, culture);
            return (pos == 0);
        }


        /// <summary>
        /// Returns <c>true</c> if the two strings match.
        /// </summary>
        /// <param name="firstString">First string</param>
        /// <param name="secondString">Second string</param>
        /// <param name="ignoreCase">Should case (upper/lower) be ignored?</param>
        /// <returns>
        /// <c>true</c>or <c>false</c>
        /// </returns>
        /// <remarks>
        /// The strings are trimmed and compared in a case-insensitive, culture neutral fashion.
        /// </remarks>
        public static bool Compare(string firstString, string secondString, bool ignoreCase)
        {
            return Compare(firstString, secondString, ignoreCase, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns <c>true</c> if the two strings match.
        /// </summary>
        /// <param name="firstString">First string.</param>
        /// <param name="secondString">Second string.</param>
        /// <param name="ignoreCase">Should case (upper/lower) be ignored?</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        /// <c>true</c>or <c>false</c>
        /// </returns>
        /// <remarks>
        /// The strings are trimmed and compared based on the given <paramref name="culture"/>.
        /// </remarks>
        public static bool Compare(string firstString, string secondString, bool ignoreCase, CultureInfo culture)
        {
            int pos = string.Compare(firstString.Trim(), secondString.Trim(), ignoreCase, culture);
            return (pos == 0);
        }

    }
}
