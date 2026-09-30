namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Array helpers
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Returns true if the array contains the string we are looking for
        /// </summary>
        /// <param name="hostArray">The host array.</param>
        /// <param name="searchText">The search string.</param>
        /// <returns>
        /// True or false
        /// </returns>
        /// <example>
        /// <code>
        /// string[] testArray = new string[] { "One", "Two", "Three" };
        /// bool result1 = StringHelper.ArrayContainsString(testArray, "one", true); // returns true
        /// bool result2 = StringHelper.ArrayContainsString(testArray, "one"); // returns false
        /// bool result3 = StringHelper.ArrayContainsString(testArray, "One"); // returns true
        /// bool result4 = StringHelper.ArrayContainsString(testArray, "Four"); // returns false
        /// </code>
        /// </example>
        public static bool ArrayContainsString(string[] hostArray, string searchText)
        {
            return ArrayContainsString(hostArray, searchText, false);
        }

        /// <summary>
        /// Returns true if the array contains the string we are looking for
        /// </summary>
        /// <param name="hostArray">The host array.</param>
        /// <param name="searchText">The search string.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>
        /// True or false
        /// </returns>
        /// <example>
        /// <code>
        /// string[] testArray = new string[] { "One", "Two", "Three" };
        /// bool result1 = StringHelper.ArrayContainsString(testArray, "one", true); // returns true
        /// bool result2 = StringHelper.ArrayContainsString(testArray, "one"); // returns false
        /// bool result3 = StringHelper.ArrayContainsString(testArray, "One"); // returns true
        /// bool result4 = StringHelper.ArrayContainsString(testArray, "Four"); // returns false
        /// </code>
        /// </example>
        public static bool ArrayContainsString(string[] hostArray, string searchText, bool ignoreCase)
        {
            return hostArray.Any(item => Compare(item, searchText, ignoreCase));
        }

        /// <summary>
        /// Check if given <paramref name="searchedText" /> has element of array <paramref name="search" /> inside.
        /// </summary>
        /// <param name="searchedText">The searched text.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public static bool StringContainsArrayElement(string searchedText, string[] search)
        {
            bool result = false;
            foreach (string x in search)
            {
                if (searchedText.Contains(x))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}

