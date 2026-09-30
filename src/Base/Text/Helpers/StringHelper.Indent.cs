namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Indents block of lines.
        /// </summary>
        /// <param name="textToIndent">The textToIndent to indent.</param>
        /// <returns>
        /// Returns the indented textToIndent.
        /// </returns>
        public static string Indent(string textToIndent)
        {
            return Indent(textToIndent, @"    ");
        }

        /// <summary>
        /// Indents block of lines.
        /// </summary>
        /// <param name="textToIndent">The textToIndent to indent.</param>
        /// <param name="linePrefix">The prefix to add before every
        /// found line.</param>
        /// <returns>
        /// Returns the indented textToIndent.
        /// </returns>
        public static string Indent(string textToIndent, string linePrefix)
        {
            if (textToIndent == null)
            {
                return textToIndent;
            }
            else
            {
                textToIndent = textToIndent.Replace(@"" + Environment.NewLine, "\n");
                textToIndent = textToIndent.Replace('\r', '\n');
                if (textToIndent.IndexOf('\n') < 0)
                {
                    return linePrefix + textToIndent;
                }
                else
                {
                    string[] lines = textToIndent.Split('\n');
                    StringBuilder result = new StringBuilder();
                    foreach (string line in lines)
                    {
                        if (result.Length > 0)
                        {
                            result.Append(Environment.NewLine);
                        }
                        result.Append(linePrefix);
                        result.Append(line);
                    }
                    return result.ToString();
                }
            }
        }

    }
}
