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
        /// Formats WITH currency symbol, default precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val)
        {
            // "C": With currency symbol.
            return FormatCurrency(val, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// Formats WITH currency symbol, default precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, IFormatProvider provider)
        {
            // "C": With currency symbol.
            return val.ToString(@"C", provider);
        }

        /// <summary>
        /// Formats WITH currency symbol.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="precision">Gives the number of decimals digits
        /// after the point.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, int precision)
        {
            return FormatCurrency(val, precision, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// Formats WITH currency symbol.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="precision">Gives the number of decimals digits
        /// after the point.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, int precision, IFormatProvider provider)
        {
            NumberFormatInfo nfi =
                (provider.GetFormat(typeof(NumberFormatInfo)) as
                NumberFormatInfo).Clone() as NumberFormatInfo;
            nfi.CurrencyDecimalDigits = precision;

            // "C": With currency symbol.
            return val.ToString(@"C", nfi);
        }

        /// <summary>
        /// WITH or WITHOUT currency symbol, default precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="addCurrencySymbol">if set to <c>true</c> [add currency symbol].</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, bool addCurrencySymbol)
        {
            return FormatCurrency(val, addCurrencySymbol, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// WITH or WITHOUT currency symbol, default precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="addCurrencySymbol">if set to <c>true</c> [add currency symbol].</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, bool addCurrencySymbol, IFormatProvider provider)
        {
            if (addCurrencySymbol)
            {
                return FormatCurrency(val);
            }
            else
            {
                return val.ToString(@"n", provider);
            }
        }

        /// <summary>
        /// WITH or WITHOUT currency symbol, user-defined precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="addCurrencySymbol">if set to <c>true</c> [add currency symbol].</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, int precision, bool addCurrencySymbol)
        {
            return FormatCurrency(val, precision, addCurrencySymbol, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// WITH or WITHOUT currency symbol, user-defined precision.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="addCurrencySymbol">if set to <c>true</c> [add currency symbol].</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string FormatCurrency(decimal val, int precision, bool addCurrencySymbol, IFormatProvider provider)
        {
            if (addCurrencySymbol)
            {
                return FormatCurrency(val, precision, provider);
            }
            else
            {
                NumberFormatInfo nfi =
                    (provider.GetFormat(typeof(NumberFormatInfo)) as
                    NumberFormatInfo).Clone() as NumberFormatInfo;
                nfi.NumberDecimalDigits = precision;

                return val.ToString(@"n", nfi);
            }
        }

    }
}
