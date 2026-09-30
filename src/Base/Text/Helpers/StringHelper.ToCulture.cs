namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public static partial class StringHelper
    {
        /// <summary>
        /// Toes the culture info.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <returns></returns>
        public static CultureInfo ToCultureInfo(string languageCode)
        {
            return ToCultureInfo(languageCode, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Toes the culture info.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static CultureInfo ToCultureInfo(string languageCode, CultureInfo fallbackTo)
        {
            if (string.IsNullOrEmpty(languageCode) ||
                languageCode.Trim().Length < 2)
            {
                return fallbackTo;
            }
            else
            {
                string c4;
                string c2;

                if (languageCode.Length == 2)
                {
                    c2 = languageCode;
                    c4 = c2 + @"-" + c2;
                }
                else if (languageCode.Length == 4)
                {
                    c2 = languageCode.Substring(0, 2);
                    c4 = languageCode;
                }
                else
                {
                    c2 = languageCode.Substring(0, 2);
                    c4 = c2 + @"-" + c2;
                }

                try
                {
                    CultureInfo info = new CultureInfo(
                        c4);
                    return info;
                }
                catch (ArgumentException)
                {
                    try
                    {
                        // if languageCode 4 failed, try languageCode 2.
                        CultureInfo info = new CultureInfo(
                            c2);
                        return info;
                    }
                    catch
                    {


                        return fallbackTo;
                    }
                }
            }
        }

    }
}
