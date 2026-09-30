namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Remove vowels (selbstlaute) from a given string
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <example>
        /// remove -&gt; rmv
        /// </example>
        public static string RemoveVowels(string input)
        {
            string ret = "";
            string currentLetter;
            for (int i = 0; i < input.Length; i++)
            {
                currentLetter = input.Substring(i, 1);

                if (string.Compare(currentLetter, "a", true) != 0 &&
                    string.Compare(currentLetter, "e", true) != 0 &&
                    string.Compare(currentLetter, "i", true) != 0 &&
                    string.Compare(currentLetter, "o", true) != 0 &&
                    string.Compare(currentLetter, "u", true) != 0)
                {
                    //Not a vowel, add it
                    ret += currentLetter;
                }
            }
            return ret;
        }

        /// <summary>
        /// Get vowels from a given string
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <example>
        /// remove -&gt; eoe
        /// </example>
        public static string GetVowels(string input)
        {
            string ret = "";
            string currentLetter;
            for (int i = 0; i < input.Length; i++)
            {
                currentLetter = input.Substring(i, 1);

                if (string.Compare(currentLetter, "a", true) == 0 ||
                    string.Compare(currentLetter, "e", true) == 0 ||
                    string.Compare(currentLetter, "i", true) == 0 ||
                    string.Compare(currentLetter, "o", true) == 0 ||
                    string.Compare(currentLetter, "u", true) == 0)
                {
                    //A vowel, add it
                    ret += currentLetter;
                }
            }
            return ret;
        }

    }
}
