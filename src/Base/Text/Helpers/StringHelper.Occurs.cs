namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Returns the number of occurrences of a character within a string
        /// </summary>
        /// <param name="character">Search Character</param>
        /// <param name="stringSearched">Expression</param>
        /// <returns>
        /// Number of occurrences
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.Occurs('o', "Joe Doe"); // returns 2
        /// </code>
        /// </example>
        public static int Occurs(char character, string stringSearched)
        {
            int counter, occured = 0;

            //Loop through the string
            for (counter = 0; counter < stringSearched.Length; counter++)
                //Check if each expression is equal to the one we want to check against
                if (stringSearched[counter] == character)
                    //if  so increment the counter
                    occured++;
            return occured;
        }

        /// <summary>
        /// Returns the number of occurrences of one string within another string
        /// </summary>
        /// <param name="searchString">Search String</param>
        /// <param name="stringSearched">Expression</param>
        /// <returns>
        /// Number of occurrences
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.Occurs("oe", "Joe Doe"); //returns 2
        /// StringHelper.Occurs("Joe", "Joe Doe"); //returns 1
        /// </code>
        /// </example>
        public static int Occurs(string searchString, string stringSearched)
        {
            int position = 0;
            int occured = 0;
            do
            {
                //Look for the search string in the expression
                position = stringSearched.IndexOf(searchString, position);

                if (position < 0) break;
                //Increment the occured counter based on the current mode we are in
                occured++;
                position++;
            } while (true);

            //Return the number of occurrences
            return occured;
        }

    }
}
