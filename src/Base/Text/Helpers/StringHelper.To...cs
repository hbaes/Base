namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    /// <summary>
    /// String to object helper class that converts a string to the right object if possible.
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Converts a string to a boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The boolean value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static bool ToBool(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            if (string.Equals("0", value, StringComparison.Ordinal))
            {
                return false;
            }

            if (string.Equals("1", value, StringComparison.Ordinal))
            {
                return true;
            }

            return bool.Parse(value);
        }

        /// <summary>
        /// Converts a string to a byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The byte array value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static byte[] ToByteArray(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);

            var encoding = new UTF8Encoding();
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// Converts a string to a date/time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The date/time value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static DateTime ToDateTime(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return DateTime.Parse(value);
        }

        /// <summary>
        /// Converts a string to a decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The decimal value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static Decimal ToDecimal(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return Decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a string to a double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The double value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static Double ToDouble(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return Double.Parse(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a string to a float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The float value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static float ToFloat(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return float.Parse(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a string to a guid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The guid value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static Guid ToGuid(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return new Guid(value);
        }

        /// <summary>
        /// Converts a string to an integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The integer value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static int ToInt(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return int.Parse(value);
        }

        /// <summary>
        /// Converts a string to a long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The long value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static long ToLong(string value)
        {
            Argument.IsNotNullOrWhitespace("value", value);
            value = CleanString(value);

            return long.Parse(value);
        }

        /// <summary>
        /// Converts a string to a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string value of the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="value"/> is <c>null</c> or whitespace.</exception>
        public static string ToString(string value)
        {
            return value;
        }

        /// <summary>
        /// Converts a string to the right target type.
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="value">The value.</param>
        /// <returns>The converted value. If the <paramref name="value"/> is <c>null</c>, this method will return <c>null</c>.</returns>
        /// <exception cref="NotSupportedException">The specified <paramref name="targetType"/> is not supported.</exception>
        public static object ToRightType(Type targetType, string value)
        {
            if (value == null)
            {
                return null;
            }

            if (targetType == typeof(string))
            {
                return value;
            }

            if (targetType == typeof(bool))
            {
                return ToBool(value);
            }

            if (targetType == typeof(bool?))
            {
                return ToBool(value);
            }

            if (targetType == typeof(byte[]))
            {
                return ToByteArray(value);
            }

            if (targetType == typeof(DateTime))
            {
                return ToDateTime(value);
            }

            if (targetType == typeof(DateTime?))
            {
                return ToDateTime(value);
            }

            if (targetType == typeof(decimal))
            {
                return ToDecimal(value);
            }

            if (targetType == typeof(decimal?))
            {
                return ToDecimal(value);
            }

            if (targetType == typeof(double))
            {
                return ToDouble(value);
            }

            if (targetType == typeof(double?))
            {
                return ToDouble(value);
            }

            if (targetType == typeof(float))
            {
                return ToFloat(value);
            }

            if (targetType == typeof(float?))
            {
                return ToFloat(value);
            }

            if (targetType == typeof(Guid))
            {
                return ToGuid(value);
            }

            if (targetType == typeof(Guid?))
            {
                return ToGuid(value);
            }

            if (targetType == typeof(int))
            {
                return ToInt(value);
            }

            if (targetType == typeof(int?))
            {
                return ToInt(value);
            }

            if (targetType == typeof(long))
            {
                return ToLong(value);
            }

            if (targetType == typeof(long?))
            {
                return ToLong(value);
            }

            throw new NotSupportedException(string.Format("Type '{0}' is not yet supported", targetType.FullName));
        }


    }
}
