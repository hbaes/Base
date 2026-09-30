namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.ComponentModel;

    /// <summary>
    /// Helpers for Enum
    /// </summary>
    public static class EnumHelper
    {

        #region private

        /// <summary>
        /// Much faster access by storing previously read values.
        /// </summary>
        private static Dictionary<Enum, string> recentEnumDescriptions = new Dictionary<Enum, string>();

        #endregion

        /// <summary>
        /// Reads the description value from an enumeration.
        /// </summary>
        /// <param name="value">The description of the enum value to
        /// read.</param>
        /// <returns>
        /// Returns the description string or the enum value
        /// as a string, if no description was found.
        /// </returns>
        /// <seealso href="http://www.codeproject.com/csharp/EnumDescConverter.asp."/>
        public static string GetEnumDescription(Enum value)
        {
            string result;
            if (recentEnumDescriptions.TryGetValue(value, out result))
            {
                return result;
            }
            else
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                {
                    result = attributes[0].Description;
                }
                else
                {
                    result = value.ToString();
                }

                recentEnumDescriptions[value] = result;
                return result;
            }
        }

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }
}

