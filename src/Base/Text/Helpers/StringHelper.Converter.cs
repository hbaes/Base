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
        /// Receives a character as a parameter and returns its ANSI code
        /// </summary>
        /// <param name="character">Character</param>
        /// <returns>
        /// ASCII value
        /// </returns>
        /// <example>
        /// <code>
        /// Asc('#'); //returns 35
        /// </code>
        /// </example>
        public static int Asc(char character)
        {
            return character;
        }

        /// <summary>
        /// Receives an integer ANSI code and returns a character associated with it
        /// </summary>
        /// <param name="ansiCode">Character Code</param>
        /// <returns>
        /// Char that corresponds with the ascii code
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.Chr(35); //returns '#'
        /// </code>
        /// </example>
        public static char Chr(int ansiCode)
        {
            return (char)ansiCode;
        }

        /// <summary>
        /// Returns a culture-neutral to-lower operation on the string.
        /// </summary>
        /// <param name="originalString">Original string</param>
        /// <returns>
        /// Lower-case string
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelpers.Lower("IWantThis");    // return "iwantthis"
        /// </code>  
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static string Lower(string originalString)
        {
            return originalString.ToLower(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a culture-neutral to-upper operation on the string.
        /// </summary>
        /// <param name="originalString">Original string</param>
        /// <returns>
        /// Upper-case string
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelpers.Upper("IWantThis");    // return "IWANTTHIS"
        /// </code>  
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static string Upper(string originalString)
        {
            return originalString.ToUpper(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Swaps the cases in a string culture-neutral
        /// </summary>
        /// <param name="originalString">The input.</param>
        /// <returns>the swaped string</returns>
        /// <example>
        /// word -&gt; WORD
        /// Word -&gt; wORD
        /// WoRd -&gt; wOrD
        ///   </example>
        public static string SwapCases(string originalString)
        {
            string ret = "";
            for (int i = 0; i < originalString.Length; i++)
            {
                if (string.Compare(originalString.Substring(i, 1), originalString.Substring(i, 1).ToUpper(), false) == 0)
                    ret += originalString.Substring(i, 1).ToLower(CultureInfo.InvariantCulture);
                else
                    ret += originalString.Substring(i, 1).ToUpper(CultureInfo.InvariantCulture);
            }
            return ret;
        }

        /// <summary>
        /// Receives a string as a parameter and returns the string in
        /// Proper format (makes each letter after a space capital)
        /// </summary>
        /// <param name="originalString">String</param>
        /// <returns>
        /// Proper string
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelpers.Proper("joe doe is a good man");	//returns "Joe Doe Is A Good Man"
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static string Proper(string originalString)
        {
            var sb = new StringBuilder(originalString);
            int counter;
            var length = originalString.Length;
            for (counter = 0; counter < length; counter++)
            {
                //look for a blank space and once found make the next character to uppercase
                if ((counter == 0) || (char.IsWhiteSpace(originalString[counter])))
                {
                    //Handle the first character differently
                    int counter2;
                    if (counter == 0)
                        counter2 = counter;
                    else
                        counter2 = counter + 1;

                    //Make the next character uppercase and update the stringBuilder
                    sb.Remove(counter2, 1);
                    sb.Insert(counter2, Char.ToUpper(originalString[counter2], CultureInfo.InvariantCulture));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method returns strings in proper case.
        /// However, contrary to regular Proper() methods,
        /// this method can be used to format names.
        /// </summary>
        /// <param name="originalString">String that is to be formatted</param>
        /// <returns>
        /// Properly formatted string
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelpers.SmartProper("macLeod");	//returns "MacLeod"
        /// 
        /// StringHelpers.SmartProper("MACLEOD");	//returns "Macleod"
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static string SmartProper(string originalString)
        {
            var chars = originalString.Trim().ToCharArray();

            var sb = new StringBuilder();
            var bLastWasNewWord = true;			// Indicated that the last character started a new word
            bool bEncounteredLower = false, bEncounteredUpper = false;
            for (int counter = 0; counter < chars.Length; counter++)
            {
                string dummy = chars[counter].ToString();

                // We figure out whether this was a lower or upper case character
                if (dummy.ToLower(CultureInfo.InvariantCulture) == dummy)
                    bEncounteredLower = true;
                else
                    bEncounteredUpper = true;

                if (bLastWasNewWord)
                    // Ever time we start a new word, the first char is upper case, no matter what.
                    sb.Append(dummy.ToUpper(CultureInfo.InvariantCulture));
                else
                {
                    // We are in the middle of a word. We may have to lower chars, unless the word was in camel case before
                    if (bEncounteredUpper && bEncounteredLower)
                        // We have a camel chase word. We do not change anything
                        sb.Append(dummy);
                    else
                        sb.Append(dummy.ToLower(CultureInfo.InvariantCulture));
                }

                // We check whether the current char starts a new word.
                bLastWasNewWord = (
                    dummy == " " ||
                    dummy == "-" ||
                    dummy == "'" ||
                    dummy == "." ||
                    dummy == "," ||
                    dummy == ";" ||
                    dummy == ":");
                if (bLastWasNewWord)
                {
                    bEncounteredLower = false;
                    bEncounteredUpper = false;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method takes a camel-case string 
        /// (such as one defined by an enum) and returns 
        /// is with a space before every upper-case letter.
        /// </summary>
        /// <param name="originalString">String</param>
        /// <returns>
        /// String with spaces
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelpers.SpaceCamelCase("CamelCaseWord"); // returns "Camel Case Word"
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static string SpaceCamelCase(string originalString)
        {
            var chars = originalString.Trim().ToCharArray();
            var sb = new StringBuilder();
            for (int counter = 0; counter < chars.Length; counter++)
            {
                string dummy = chars[counter].ToString();
                if (counter > 0)
                    if (dummy.ToUpper(CultureInfo.InvariantCulture) == dummy)
                        sb.Append(" ");
                sb.Append(dummy);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Appends zeros ('0') at the head of the passed string,
        /// until a certain number of total characters is reached.
        /// </summary>
        /// <param name="text">The string to append the zeros.</param>
        /// <param name="length">The required number of characters.</param>
        /// <returns>
        /// Returns the string with the appended number of
        /// characters.
        /// </returns>
        public static string AddZerosPrefix(object text, int length)
        {
            string s = Convert.ToString(text);

            if (!string.IsNullOrEmpty(s) && s.Length < length)
            {
                StringBuilder sb = new StringBuilder(s);
                sb.Append('0', length - s.Length);

                return sb.ToString();
            }
            else
            {
                return s;
            }
        }

    }
}
