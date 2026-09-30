namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Inserts a separator after every Count letters
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <example>
        /// InsertSeperator("hello","-") ==&gt; "h-e-l-l-o"
        /// InsertSeperator("hello","-",2) ==&gt; "he-ll-o"
        /// </example>
        public static string InsertSeparator(string input, string separator, int count = 1)
        {
            string ret = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i + count < input.Length)
                    ret += input.Substring(i, count);
                else
                    ret += input.Substring(i);

                if (i != input.Length - 1)
                    ret += separator;
            }
            return ret;
        }

    }
}
