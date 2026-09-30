namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;

    public static partial class StringHelper
    {
        /// <summary>
        /// Receives a string as a parameter and counts the number of words in that string
        /// </summary>
        /// <param name="sourceString">String</param>
        /// <returns>
        /// Word Count
        /// </returns>
        /// <example>
        /// <code>
        /// string lcString = "Joe Doe is a good man";
        /// StringHelpers.GetWordCount(lcString); // returns 6
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static long GetWordCount(string sourceString)
        {
            int counter;
            long length = sourceString.Length;
            long wordCount = 0;

            //Begin by checking for the first word
            if (!Char.IsWhiteSpace(sourceString[0])) wordCount++;

            //Now look for white spaces and count each word
            for (counter = 0; counter < length; counter++)
                //Check for a space to begin counting a word
                if (Char.IsWhiteSpace(sourceString[counter]))
                    //We think we encountered a word
                    //Remove any following white spaces if any after this word
                    do
                    {
                        //Check if we have reached the limit and if so then exit the loop
                        counter++;
                        if (counter >= length) break;
                        if (!Char.IsWhiteSpace(sourceString[counter]))
                        {
                            wordCount++;
                            break;
                        }
                    } while (true);
            return wordCount;
        }

        /// <summary>
        /// Based on the position specified, returns a word from a string.
        /// Receives a string as a parameter and counts the number of words in that string.
        /// </summary>
        /// <param name="sourceString">String</param>
        /// <param name="wordPosition">Word Position</param>
        /// <returns>
        /// Word number
        /// </returns>
        /// <example>
        /// <code>
        /// string lcString = "Joe Doe is a good man";
        /// StringHelper.GetWordNumb(lcString, 5); // returns "good"
        /// </code>
        /// </example>
        [Browsable(false)]
        public static string GetWordNumber(string sourceString, int wordPosition)
        {
            if (wordPosition < 1) return string.Empty;
            var words = sourceString.Split(' ');
            return wordPosition <= words.Length ? words[wordPosition - 1] : string.Empty;
        }

    }
}
