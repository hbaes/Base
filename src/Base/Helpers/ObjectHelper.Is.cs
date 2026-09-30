namespace Base
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;


    /// <summary>
    /// 
    /// </summary>
    public partial class ObjectHelper
    {

        /// <summary>
        /// Determines whether the specified object is <c>null</c> or <c>DBNull.Value</c>.
        /// </summary>
        /// <param name="obj">The object to chec..</param>
        /// <returns>
        ///   <c>true</c> if the specified object is <c>null</c> or <c>DBNull.Value</c>; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(object obj)
        {
            if (obj == null)
            {
                return true;
            }

#if NET
            if (obj == DBNull.Value)
            {
                return true;
            }
#endif

            return false;
        }


        #region Conversion checkings.
        // ------------------------------------------------------------------

        /// <summary>
        /// Checks whether a string contains a valid boolean.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if is a boolean, <c>false</c> if not.
        /// </returns>
        public static bool IsBoolean(object o)
        {
            return IsBoolean(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid boolean.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if is a boolean, <c>false</c> if not.
        /// </returns>
        public static bool IsBoolean(object o, IFormatProvider provider)
        {
            try
            {
                if (o == null)
                {
                    return false;
                }
                // This is the fastest way, see
                // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
                else if (o.GetType() == typeof(bool))
                {
                    return true;
                }
                else
                {
                    string s = Convert.ToString(o, provider).Trim().ToLowerInvariant();
                    if (s.Length <= 0)
                    {
                        return false;
                    }
                    else if (o is bool)
                    {
                        return true;
                    }
                    else if (string.Compare(s, bool.TrueString, true) == 0 || s == @"1" || s == @"-1")
                    {
                        return true;
                    }
                    else if (string.Compare(s, bool.FalseString, true) == 0 || s == @"0")
                    {
                        return true;
                    }
                    else
                    {
                        bool.Parse(Convert.ToString(o, provider));
                    }
                }
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether a string contains a valid date and/or time.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if is date/time, <c>false</c> if not.
        /// </returns>
        public static bool IsDateTime(object o)
        {
            return IsDateTime(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid date and/or time.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if is date/time, <c>false</c> if not.
        /// </returns>
        public static bool IsDateTime(object o, IFormatProvider provider)
        {
            if (o == null ||
                Convert.ToString(o, provider).Trim().Length <= 0)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(DateTime))
            {
                return true;
            }
            else
            {
                DateTime r;
                return DateTime.TryParse(
                    Convert.ToString(o, provider),
                    provider,
                    DateTimeStyles.None,
                    out r);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid float.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a float,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsNumeric(object o)
        {
            return IsNumeric(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid float.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns TRUE if the string contains a float,
        /// FALSE if not.
        /// </returns>
        public static bool IsNumeric(object o, IFormatProvider provider)
        {
            return DoIsNumeric(o, floatNumberStyle, provider);
        }

        /// <summary>
        /// Checks whether a string contains a valid decimal.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a decimal,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsDecimal(object o)
        {
            return IsDecimal(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid decimal.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a decimal,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsDecimal(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(decimal))
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, floatNumberStyle, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid float.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a float,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsFloat(object o)
        {
            return IsFloat(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid float.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a float,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsFloat(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(float))
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, floatNumberStyle, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid double.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a double,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsDouble(object o)
        {
            return IsDouble(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid double.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a double,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsDouble(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(double))
            {
                return true;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(float))
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, floatNumberStyle, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInteger(object o)
        {
            return IsInteger(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInteger(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(int))
            {
                return true;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(long))
            {
                return true;
            }
            else if (o is Enum)
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, NumberStyles.Integer, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInt32(object o)
        {
            return IsInt32(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInt32(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(Int32))
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, NumberStyles.Integer, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInt64(object o)
        {
            return IsInt64(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid integer.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains an integer,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsInt64(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(Int64))
            {
                return true;
            }
            else
            {
                return DoIsNumeric(o, NumberStyles.Integer, provider);
            }
        }

        /// <summary>
        /// Checks whether a string contains a valid currency number.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a currency,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsCurrency(object o)
        {
            return IsCurrency(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string contains a valid currency number.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string contains a currency,
        /// <c>false</c> if not.
        /// </returns>
        public static bool IsCurrency(object o, IFormatProvider provider)
        {
            return DoIsNumeric(o, NumberStyles.Currency, provider);
        }

        /// <summary>
        /// Checks whether a string is a valid Guid.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the string is a Guid, <c>false</c> if not.
        /// </returns>
        public static bool IsGuid(object o)
        {
            return IsGuid(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks whether a string is a valid Guid.
        /// </summary>
        /// <param name="o">The string to check.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Returns <c>true</c> if the string is a Guid, <c>false</c> if not.
        /// </returns>
        public static bool IsGuid(object o, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(Guid))
            {
                return true;
            }
            else if (o is byte[])
            {
                try
                {
                    Guid ignore = new Guid(o as byte[]);
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    Guid ignore = new Guid(o.ToString());
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Does the is numeric.
        /// </summary>
        /// <param name="o">The string to check</param>
        /// <param name="styles">The <see cref="NumberStyles"/>.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private static bool DoIsNumeric(object o, NumberStyles styles, IFormatProvider provider)
        {
            if (o == null)
            {
                return false;
            }
            else if (Convert.ToString(o, provider).Length <= 0)
            {
                return false;
            }
            else
            {
                double result;
                return double.TryParse(
                    o.ToString(),
                    styles,
                    provider,
                    out result);
            }
        }

        #endregion

    }
}
