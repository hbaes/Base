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
        /// Generate a MD5 hash from a given string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string GenerateHash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                return input.GetHashCode().ToString(@"X", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Generates a matchCode, based on 'name', if 'matchCode' is
        /// currently NOT a valid matchCode.
        /// otherwise just returns 'matchCode'.
        /// </summary>
        /// <param name="matchCode">Matchcode to check.</param>
        /// <param name="name">Base for possible matchCode to generate.</param>
        /// <returns>Returns the ready-to-use matchCode.</returns>
        public static string GenerateMatchCode(string matchCode, string name)
        {
            if (IsValidMatchCode(matchCode))
            {
                return matchCode;
            }
            else
            {
                matchCode = name.ToLower();
                matchCode = matchCode.Trim();

                matchCode = RXReplace(matchCode, @"^[^a-z_]", @"_", @"gs");			// first char.
                matchCode = RXReplace(matchCode, @"[^a-z0-9_]", @"_", @"gs");		// second+ chars.

                return matchCode;
            }
        }

        /// <summary>
        /// Generates the match code.
        /// </summary>
        /// <param name="matchCode">The match code.</param>
        /// <returns></returns>
        public static string GenerateMatchCode(string matchCode)
        {
            return GenerateMatchCode(matchCode, matchCode);
        }

        /// <summary>
        /// Check whether a given matchCode is valid.
        /// </summary>
        /// <param name="matchCode">The matchCode to check.</param>
        /// <returns>Returns TRUE if valid, FALSE otherwise.</returns>
        public static bool IsValidMatchCode(string matchCode)
        {
            return RXTest(matchCode, @"^[a-z_][a-z0-9_]*$", @"si");
        }


    }
}
