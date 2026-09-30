namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Globalization;

    public static partial class StringHelper
    {
        /// <summary>
        /// Formats the decimal.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string FormatDecimal(decimal val)
        {
            return FormatDecimal(val, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// Formats the decimal.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string FormatDecimal(decimal val, IFormatProvider provider)
        {
            return val.ToString(@"D", provider);
        }

    }
}
