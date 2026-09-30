namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Base;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// String helper class
    /// </summary>
    public static partial class StringHelper
    {

        /// <summary>
        /// The <see cref="ILog">log</see> object.
        /// </summary>
        private static readonly ILogger Log = ApplicationLogging.CreateLogger("Base.StringHelper");


        /// <summary>
        /// Cleans up the string, for example by removing the braces.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The cleaned up string.</returns>
        public static string CleanString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            while (value.StartsWith("(") && value.EndsWith(")"))
            {
                value = value.Substring(1, value.Length - 2);
            }

            return value.Trim();
        }

        /// <summary>
        /// Fills the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="len">The length.</param>
        /// <param name="filler">The filler.</param>
        /// <returns></returns>
        public static string Fill(string value, int len, char filler)
        {
            if (String.IsNullOrWhiteSpace(value)) value = "";
            string result = value;
            if (value.Length < len)
            {
                result += new String(filler, len);
                result = Left(result, len);
            }
            return result;
        }

        /// <summary>
        /// Fills the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="len">The length.</param>
        /// <returns></returns>
        public static string Fill(string value, int len)
        {
            return Fill(value, len, ' ');
        }


    }
}
