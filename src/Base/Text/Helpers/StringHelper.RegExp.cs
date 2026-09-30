namespace Base.Text
{
    using Base.Collections;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Regular expression String helpers
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Much faster access by storing previously read values.
        /// </summary>
        private static Dictionary<string, RegexOptions> recentRegexOptions =
            new Dictionary<string, RegexOptions>();


        /// <summary>
        /// Performs a regular expression replace like ( )~ s/ / / in Perl.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <param name="flags">"i":ignore case and "g":global,
        /// "m":multiline.</param>
        /// <returns></returns>
        public static string RXReplace(
            string text,
            string pattern,
            string replacement,
            string flags)
        {
            RegexOptions options =
                ConvertRXOptionsFromString(flags);

            Regex rx = new Regex(pattern, options);
            if (flags.Contains(@"g"))
            {
                return rx.Replace(text, replacement);
            }
            else
            {
                return rx.Replace(text, replacement, 1);
            }
        }

        /// <summary>
        /// Performs a regular expression test like ( )~ m/ / in Perl.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="flags">"i":ignore case and "m":multiline.</param>
        /// <returns></returns>
        public static bool RXTest(
            string text,
            string pattern,
            string flags)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            else
            {
                RegexOptions options =
                    ConvertRXOptionsFromString(flags);

                Regex rx = new Regex(
                    pattern,
                    options);
                return rx.IsMatch(text);
            }
        }

        /// <summary>
        /// Performs a regular expression test like ( )~ m/ / in Perl.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="flags">"i":ignore case and "m":multiline.</param>
        /// <returns>Returns the number of matches.</returns>
        public static int RXTestCount(
            string text,
            string pattern,
            string flags)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            else
            {
                RegexOptions options =
                    ConvertRXOptionsFromString(flags);

                Regex rx = new Regex(
                    pattern,
                    options);
                return rx.Matches(text).Count;
            }
        }

        /// <summary>
        /// Converts between Perl-style RX flags and .NET RX options.
        /// </summary>
        /// <param name="flags">The Perl-style RX flags.</param>
        /// <returns>Returns the .NET RX options.</returns>
        public static RegexOptions ConvertRXOptionsFromString(
            string flags)
        {
            RegexOptions options;

            if (recentRegexOptions.TryGetValue(flags, out options))
            {
                return options;
            }
            else
            {
                options = RegexOptions.None;

                if (flags.Contains(@"i"))
                {
                    options |= RegexOptions.IgnoreCase;
                }
                if (flags.Contains(@"x"))
                {
                    options |= RegexOptions.IgnorePatternWhitespace;
                }
                if (flags.Contains(@"m"))
                {
                    options |= RegexOptions.Multiline;
                }
                if (flags.Contains(@"s"))
                {
                    options |= RegexOptions.Singleline;
                }

                recentRegexOptions[flags] = options;
                return options;
            }
        }

        /// <summary>
        /// Escape special RX characters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ignoreChars">The ignore chars.</param>
        /// <returns></returns>
        public static string EscapeRXCharacters(
            string text,
            params char[] ignoreChars)
        {
            Set<char> ignores = new Set<char>(ignoreChars);

            // As first!
            if (!ignores.Contains('\\'))
            {
                text = text.Replace(@"\", @"\\");
            }

            if (!ignores.Contains('+'))
            {
                text = text.Replace(@"+", @"\+");
            }
            if (!ignores.Contains('+'))
            {
                text = text.Replace(@"?", @"\?");
            }
            if (!ignores.Contains('.'))
            {
                text = text.Replace(@".", @"\.");
            }
            if (!ignores.Contains('*'))
            {
                text = text.Replace(@"*", @"\*");
            }
            if (!ignores.Contains('^'))
            {
                text = text.Replace(@"^", @"\^");
            }
            if (!ignores.Contains('$'))
            {
                text = text.Replace(@"$", @"\$");
            }
            if (!ignores.Contains('('))
            {
                text = text.Replace(@"(", @"\(");
            }
            if (!ignores.Contains(')'))
            {
                text = text.Replace(@")", @"\)");
            }
            if (!ignores.Contains('['))
            {
                text = text.Replace(@"[", @"\[");
            }
            if (!ignores.Contains(']'))
            {
                text = text.Replace(@"]", @"\]");
            }
            if (!ignores.Contains('{'))
            {
                text = text.Replace(@"{", @"\{");
            }
            if (!ignores.Contains('}'))
            {
                text = text.Replace(@"}", @"\}");
            }
            if (!ignores.Contains('|'))
            {
                text = text.Replace(@"|", @"\|");
            }

            return text;
        }

    }
}

