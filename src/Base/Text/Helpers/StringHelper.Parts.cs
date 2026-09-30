namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Parts from String
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Mimics the CString.Left() function.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static string Left(string s, int count)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            else
            {
                return s.Substring(0, Math.Min(count, s.Length));
            }
        }

        /// <summary>
        /// Mimics the CString.Right() function.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static string Right(string s, int count)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            else
            {
                int length = s.Length;

                if (s.Length <= count)
                {
                    return s;
                }
                else
                {
                    return s.Substring(length - count);
                }
            }
        }

        /// <summary>
        /// Overloaded method for SubStr() that receives starting position and length
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="startPosition">Start Position</param>
        /// <param name="length">Length</param>
        /// <returns>
        /// Substring
        /// </returns>
        public static string SubStr(string expression, int startPosition, int length)
        {
            if (startPosition >= expression.Length) return string.Empty;
            return (length + startPosition - 1) > expression.Length ?
                expression.Substring(startPosition - 1) :
                expression.Substring(startPosition - 1, length);
        }

        /// <summary>
        /// Splits the extended.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string[] SplitExtended(string s, string separator)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                List<string> list = new List<string>();

                int lastPos = 0;
                int pos = 0;
                while ((pos = s.IndexOf(separator, lastPos)) >= 0)
                {
                    list.Add(s.Substring(lastPos, pos - lastPos + 1));

                    lastPos = pos + separator.Length;
                }

                if (lastPos < s.Length - 1)
                {
                    list.Add(s.Substring(lastPos));
                }

                return list.ToArray();
            }
        }

        /// <summary>
        /// Splits the extended.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string[] SplitExtended(string s, params char[] separator)
        {
            string[] t = s.Split(separator);

            // remove empties.
            List<string> list = new List<string>();
            foreach (string u in t)
            {
                if (u.Length > 0)
                    list.Add(u);
            }

            return list.ToArray();
        }

    }
}
