namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;    
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Reflection;
    using Newtonsoft.Json;


    /// <summary>
    /// 
    /// </summary>
    public partial class ObjectHelper
    {

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static string ToJSON(this object @object) => JsonConvert.SerializeObject(@object, Newtonsoft.Json.Formatting.None);

        /// <summary>
        /// Safely converts a value into a string or returns string.Empty if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string or string.Empty</returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// string myString = dataSet.Tables[0].Rows[0]["name"].ToStringSave();
        /// </code>
        /// </example>
        public static string ToStringSafe(object value)
        {
            try
            {
                if (null == value)
                    return String.Empty;
                if (value != DBNull.Value)
                    return value.ToString();
                return value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the instance.
        /// <para />
        /// If the <paramref name="instance"/> is <c>null</c>, this method will return "null". This
        /// method is great when the value of a property must be logged.
        /// </summary>
        /// <param name="instance">The instance, can be <c>null</c>.</param>
        /// <returns>A <see cref="string"/> that represents the instance.</returns>
        public static string ToString(object instance)
        {
            return ObjectToStringHelper.ToString(instance);
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the type name of the instance.
        /// <para />
        /// If the <paramref name="instance"/> is <c>null</c>, this method will return "null". This
        /// method is great when the value of a property must be logged.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>A <see cref="string"/> that represents the type of the instance.</returns>
        public static string ToTypeString(object instance)
        {
            return ObjectToStringHelper.ToTypeString(instance);            
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the full type name of the instance.
        /// <para />
        /// If the <paramref name="instance"/> is <c>null</c>, this method will return "null". This
        /// method is great when the value of a property must be logged.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>A <see cref="string"/> that represents the type of the instance.</returns>
        public static string ToFullTypeString(object instance)
        {
            return ObjectToStringHelper.ToFullTypeString(instance);
        }

        /// <summary>
        /// Use this to convert a SQL-timestamp field to a printable
        /// string (e.g. for debugging purposes).
        /// </summary>
        /// <param name="buffer">The buffer to convert.</param>
        /// <returns>
        /// Returns the textual representation of the buffer
        /// or a NULL string if the buffer is NULL or a NULL
        /// if the buffer is empty.
        /// </returns>
        public static string ToStringByte(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }
            else if (buffer.Length <= 0)
            {
                return null;
            }
            else
            {
                StringBuilder s = new StringBuilder();
                foreach (byte b in buffer)
                {
                    if (s.Length > 0)
                    {
                        s.Append(@"-");
                    }
                    s.Append(Convert.ToString(b));
                }
                return s.ToString();
            }
        }

        
    
        /// <summary>
        /// Safely converts a value into a Guid or returns Guid.Empty if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Guid</returns>
        /// <remarks>
        /// This method is an extension method.
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// Guid myGuid = dataSet.Tables[0].Rows[0]["id"].ToGuidSave();
        /// </code>
        /// </example>
        public static Guid ToGuidSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (Guid)value;
                return Guid.Empty;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Safely converts a value into a boolean or returns false if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// bool myBool = dataSet.Tables[0].Rows[0]["active"].ToBooleanSave();
        /// </code>
        /// </example>
        public static bool ToBooleanSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (bool)value;
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Safely converts a value into a DateTime or returns DateTime.MinValue if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// DateTime myDate = dataSet.Tables[0].Rows[0]["timeStamp"].ToDateTimeSave();
        /// </code>
        /// </example>
        public static DateTime ToDateTimeSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (DateTime)value;
                return DateTime.MinValue;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Safely converts a value into an integer or returns 0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// int myInt = dataSet.Tables[0].Rows[0]["number"].ToIntegerSave();
        /// </code>
        /// </example>
        public static int ToIntegerSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (int)value;
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Safely converts a value into a double or returns 0.0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// int myDouble = dataSet.Tables[0].Rows[0]["number"].ToDoubleSave();
        /// </code>
        /// </example>
        public static double ToDoubleSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (double)value;
                return 0.0;
            }
            catch
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Safely converts a value into a decimal or returns 0.0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// decimal myDec = dataSet.Tables[0].Rows[0]["price"].ToDecimalSave();
        /// </code>
        /// </example>
        public static decimal ToDecimalSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (decimal)value;
                return 0m;
            }
            catch
            {
                return 0m;
            }
        }

        /// <summary>
        /// Safely converts a value into a char or returns ' ' if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// char myChar = dataSet.Tables[0].Rows[0]["character"].ToCharSave();
        /// </code>
        /// </example>
        public static char ToCharSafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (char)value;
                return ' ';
            }
            catch
            {
                return ' ';
            }
        }

        /// <summary>
        /// Safely converts a value into a byte array or returns an empty byte array if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// byte[] myBytes = dataSet.Tables[0].Rows[0]["image"].ToByteArraySave();
        /// </code>
        /// </example>
        public static byte[] ToByteArraySafe(object value)
        {
            try
            {
                if (value != DBNull.Value)
                    return (byte[])value;
                return new byte[0];
            }
            catch
            {
                return new byte[0];
            }
        }


        #region Converting routines with default fallbacks.
        // ------------------------------------------------------------------

        /// <summary>
        /// Toes the T.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static T ToT<T>(object o)
        {
            return ToT<T>(o, default(T));
        }

        
        /// <summary>
        /// Convert to a string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string ToString(object o, IFormatProvider provider)
        {
            return ToString(o, null, provider);
        }

        /// <summary>
        /// Convert a string to a double, returns 0.0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static double ToDouble(object o)
        {
            return ToDouble(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a double, returns 0.0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static double ToDouble(object o, IFormatProvider provider)
        {
            return ToDouble(o, 0.0, provider);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static int ToInt32(object o)
        {
            return ToInt32(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static int ToInt32(object o, IFormatProvider provider)
        {
            return ToInt32(o, 0, provider);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static long ToInt64(object o)
        {
            return ToInt64(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static long ToInt64(object o, IFormatProvider provider)
        {
            return ToInt64(o, 0, provider);
        }

        /// <summary>
        /// Convert a string to a decimal, returns zero if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static decimal ToDecimal(object o)
        {
            return ToDecimal(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a decimal, returns zero if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static decimal ToDecimal(object o, IFormatProvider provider)
        {
            return ToDecimal(o, decimal.Zero, provider);
        }

        /// <summary>
        /// Convert a string to a date time, returns DateTime.MinValue if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object o)
        {
            return ToDateTime(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a date time, returns DateTime.MinValue if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object o, IFormatProvider provider)
        {
            return ToDateTime(o, DateTime.MinValue, provider);
        }

        /// <summary>
        /// Convert a string to a boolean, returns FALSE if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static bool ToBoolean(object o)
        {
            return ToBoolean(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a boolean, returns FALSE if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static bool ToBoolean(object o, IFormatProvider provider)
        {
            return ToBoolean(o, false, provider);
        }

        /// <summary>
        /// Toes the GUID.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static Guid ToGuid(object o)
        {
            return ToGuid(o, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Toes the GUID.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Guid ToGuid(object o, IFormatProvider provider)
        {
            return ToGuid(o, Guid.Empty, provider);
        }

        // ------------------------------------------------------------------
        #endregion

        #region Converting routines with user-defined fallbacks.
        // ------------------------------------------------------------------

        /// <summary>
        /// Toes the T.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <typeparam name="T">Type of ...</typeparam>
        /// <returns></returns>
        public static T ToT<T>(object o, T fallbackTo)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(T))
            {
                return (T)o;
            }
            else if (typeof(T).IsEnum)
            {
                if (Enum.IsDefined(typeof(T), o))
                {
                    return (T)Enum.Parse(typeof(T), o.ToString(), true);
                }
                else
                {
                    return fallbackTo;
                }
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert to a string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static string ToString(object o, string fallbackTo)
        {
            return ToString(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert to a string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static string ToString(object o, string fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(string))
            {
                return (string)o;
            }
            else
            {
                return Convert.ToString(o, provider);
            }
        }

        /// <summary>
        /// Convert a string to a double, returns 0.0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static double ToDouble(object o, double fallbackTo)
        {
            return ToDouble(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a double, returns 0.0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static double ToDouble(object o, double fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(double))
            {
                return (double)o;
            }
            else if (IsFloat(o, provider))
            {
                return Convert.ToDouble(o, provider);
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static int ToInt32(object o, int fallbackTo)
        {
            return ToInt32(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static int ToInt32(object o, int fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(int))
            {
                return (int)o;
            }
            else if (IsInteger(o, provider))
            {
                return Convert.ToInt32(o, provider);
            }
            else if (o is Enum)
            {
                return (int)o;
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static long ToInt64(object o, long fallbackTo)
        {
            return ToInt64(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to an integer, returns 0 if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static long ToInt64(object o, long fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(long))
            {
                return (long)o;
            }
            else if (IsInt64(o, provider))
            {
                return Convert.ToInt64(o, provider);
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert a string to a decimal, returns zero if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static decimal ToDecimal(object o, decimal fallbackTo)
        {
            return ToDecimal(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a decimal, returns zero if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static decimal ToDecimal(object o, decimal fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(decimal))
            {
                return (decimal)o;
            }
            else if (IsDecimal(o, provider))
            {
                return Convert.ToDecimal(o, provider);
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert a string to a date time,
        /// returns DateTime.MinValue if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object o, DateTime fallbackTo)
        {
            return ToDateTime(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a date time,
        /// returns DateTime.MinValue if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object o, DateTime fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(DateTime))
            {
                return (DateTime)o;
            }
            else if (IsDateTime(o, provider))
            {
                return Convert.ToDateTime(o, provider);
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert a string to a boolean, returns FALSE if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">if set to <c>true</c> [fallback to].</param>
        /// <returns></returns>
        public static bool ToBoolean(object o, bool fallbackTo)
        {
            return ToBoolean(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert a string to a boolean, returns FALSE if fails.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">if set to <c>true</c> [fallback to].</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static bool ToBoolean(object o, bool fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(bool))
            {
                return (bool)o;
            }
            else if (IsBoolean(o, provider))
            {
                try
                {
                    string s = Convert.ToString(o, provider).Trim().ToLowerInvariant();

                    if (s.Length <= 0)
                    {
                        return fallbackTo;
                    }
                    else if (string.Compare(s, bool.TrueString, true) == 0 || s == @"1" || s == @"-1")
                    {
                        return true;
                    }
                    else if (string.Compare(s, bool.FalseString, true) == 0 || s == @"0")
                    {
                        return false;
                    }
                    else
                    {
                        return bool.Parse(Convert.ToString(o, provider));
                    }
                }
                catch (FormatException)
                {
                    return fallbackTo;
                }
            }
            else
            {
                return fallbackTo;
            }
        }

        /// <summary>
        /// Convert to a Guid.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static Guid ToGuid(object o, Guid fallbackTo)
        {
            return ToGuid(o, fallbackTo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert to a Guid.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Guid ToGuid(object o, Guid fallbackTo, IFormatProvider provider)
        {
            if (o == null)
            {
                return fallbackTo;
            }
            // This is the fastest way, see
            // http://www.google.de/url?sa=t&ct=res&cd=4&url=http%3A%2F%2Fblogs.msdn.com%2Fvancem%2Farchive%2F2006%2F10%2F01%2F779503.aspx&ei=nOuTRY7TAoXe2QLi7qX3Dg&usg=__GUu0brYrkgjJl63ZZ3JBOzJCVH8=&sig2=1wvt78Kof6Bw7Drs3LL_ng
            else if (o.GetType() == typeof(Guid))
            {
                return (Guid)o;
            }
            else if (IsGuid(o, provider))
            {
                if (o is byte[])
                {
                    return new Guid(o as byte[]);
                }
                else
                {
                    return new Guid(Convert.ToString(o, provider));
                }
            }
            else
            {
                return fallbackTo;
            }
        }

        // ------------------------------------------------------------------
        #endregion
    }
}
