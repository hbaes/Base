namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Wraps the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="lineLen">The line len.</param>
        /// <returns></returns>
        public static string Wrap(string text, int lineLen)
        {
            return Wrap(@"", text, lineLen);
        }

        /// <summary>
        /// Wraps the specified interim.
        /// </summary>
        /// <param name="interim">The interim.</param>
        /// <param name="text">The text.</param>
        /// <param name="lineLen">The line len.</param>
        /// <returns></returns>
        public static string Wrap(string interim, string text, int lineLen)
        {
            return Wrap(interim, text, lineLen, @"\n");
        }

        /// <summary>
        /// Wraps the specified interim.
        /// </summary>
        /// <param name="interim">The interim.</param>
        /// <param name="text">The text.</param>
        /// <param name="lineLen">The line len.</param>
        /// <param name="split">The split.</param>
        /// <returns></returns>
        public static string Wrap(string interim, string text, int lineLen, string split)
        {
            Argument.IsNotNullOrEmpty("split", split);
            Argument.IsMinimal<int>("lineLen", lineLen, 1);

            if (String.IsNullOrEmpty(text)) return interim;
            var line = text.Substring(0, Math.Min(text.Length, lineLen));
            var rest = lineLen >= text.Length
                ? ""
                : text.Substring(lineLen, text.Length - line.Length);
            if (!line.EndsWith(" ") && !rest.StartsWith(" "))
            {
                var index_of_last_whitespace = line.LastIndexOf(" ");
                if (index_of_last_whitespace > 0)
                {
                    var wordHead = line.Substring(index_of_last_whitespace + 1);
                    line = line.Substring(0, index_of_last_whitespace);
                    rest = wordHead + rest;
                }
            }
            line = line.Trim();
            rest = rest.Trim();
            interim += (interim == "" ? "" : split) + line;
            return Wrap(interim, rest, lineLen, split);

        }

    }
}
