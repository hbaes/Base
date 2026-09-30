namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enums Extensions
    /// </summary>
    /// <remarks>
    /// <c>History:</c>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Date</term>
    ///     <term>User</term>
    ///     <term>Description</term>
    ///   </listheader>
    ///   <item>
    ///     <term>2013.02.23</term><term>hbaes</term><term>finished documentation.</term>
    ///   </item>
    /// </list>
    /// </remarks>
    public static partial class EnumExtensions
    {

        /// <summary>
        /// Test if bit in bit field is set
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is set; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">TEnum must be an enumerated type</exception>
        public static bool IsSet<TEnum>(this TEnum value, TEnum flag) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            long valueBase = Convert.ToInt64(value);
            long flagBase = Convert.ToInt64(flag);
            return (valueBase & flagBase) == flagBase;
        }

        /// <summary>
        /// Converts to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumString">The enum string.</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }
    }
}

