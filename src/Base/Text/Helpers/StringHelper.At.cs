namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// At...
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Receives two strings as parameters and searches for 
        /// one string within another. If found, returns the beginning 
        /// numeric position otherwise returns 0
        /// </summary>
        /// <param name="searchFor">String to search for</param>
        /// <param name="searchIn">String to search in</param>
        /// <returns>
        /// Position
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.At("D", "Joe Doe");	//returns 5
        /// </code>
        /// </example>
        public static int At(string searchFor, string searchIn)
        {
            return searchIn.IndexOf(searchFor) + 1;
        }

        /// <summary>
        /// Receives two strings and an occurrence position (1st, 2nd etc) as parameters and
        /// searches for one string within another for that position.
        /// If found, returns the beginning numeric position otherwise returns 0
        /// </summary>
        /// <param name="searchFor">String to search for</param>
        /// <param name="searchIn">String to search in</param>
        /// <param name="occurrence">The occurrence of the string</param>
        /// <returns>
        /// Position
        /// </returns>
        /// <example>
        /// StringHelper.At("o", "Joe Doe", 1);	//returns 2
        /// StringHelper.At("o", "Joe Doe", 2);	//returns 6
        /// </example>
        public static int At(string searchFor, string searchIn, int occurrence)
        {
            int counter;
            var occured = 0;
            var position = 0;

            //Loop through the string and get the position of the requiref occurrence
            for (counter = 1; counter <= occurrence; counter++)
            {
                position = searchIn.IndexOf(searchFor, position);

                if (position < 0) break;
                //Increment the occured counter based on the current mode we are in
                occured++;

                //Check if this is the occurrence we are looking for
                if (occured == occurrence) return position + 1;
                position++;
            }
            return 0;
        }

        /// <summary>
        /// Receives a string and converts it to an integer
        /// </summary>
        /// <param name="searchExpression">Search Expression</param>
        /// <param name="expressionSearched">Expression Searched</param>
        /// <returns>
        /// Line number
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.AtLine("Is", "Is Life Beautiful? \r\n It sure is"); // returns 1
        /// </code>
        /// </example>
        public static int AtLine(string searchExpression, string expressionSearched)
        {
            var counter = 0;
            var position = At(searchExpression, expressionSearched);
            if (position > 0 && position < expressionSearched.Length)
            {
                string text = SubStr(expressionSearched, 1, position - 1);
                counter = Occurs(@"\r", text) + 1;
            }
            return counter;
        }

    }
}
