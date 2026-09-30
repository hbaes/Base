namespace Base
{
    using Base.Text;
    
    using System;
    using System.Text;


    /// <summary>
    /// The string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        #region Methods
        /// <summary>
        /// Prepares a string value as search filter by trimming it and making it lower-case.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The search filter.</returns>
        public static string PrepareAsSearchFilter(this string filter)
        {
            var filterText = filter;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                filterText = string.Empty;
            }

            filterText = filterText.ToLower().Trim();
            return filterText;
        }
        #endregion

        /// <summary>
        /// Fill given string with given fillercahr to given len.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <param name="len">The length.</param>
        /// <param name="filler">The filler.</param>
        /// <returns></returns>
        public static string Fill(this string originalString, int len, char filler)
        {
            return StringHelper.Fill(originalString, len, filler);
        }

        /// <summary>
        /// Fill given string with blanks to given len.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <param name="len">The length.</param>
        /// <returns></returns>
        public static string Fill(this string originalString, int len)
        {
            return StringHelper.Fill(originalString, len);
        }

        /// <summary>
        /// Returns a culture-neutral to-lower operation on the string.
        /// </summary>
        /// <param name="originalString">Original string</param>
        /// <returns>
        /// Lower-case string
        /// </returns>
        /// <example>"Hello".Lower()</example>
        public static string Lower(this string originalString) { return StringHelper.Lower(originalString); }

        /// <summary>
        /// Returns a culture-neutral to-upper operation on the string.
        /// </summary>
        /// <param name="originalString">Original string</param>
        /// <returns>
        /// Upper-case string
        /// </returns>
        /// <example>"Hello".Upper()</example>
        public static string Upper(this string originalString) { return StringHelper.Upper(originalString); }

        /// <summary>
        /// Returns true if the two strings match.
        /// </summary>
        /// <param name="firstString">First string</param>
        /// <param name="secondString">Second string</param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <example>if ("Hello".Compare("World")) { }</example>
        /// <remarks>
        /// The strings are trimmed and compared in a case-insensitive, culture neutral fashion.
        /// </remarks>
        public static bool Compare(this string firstString, string secondString) { return StringHelper.Compare(firstString, secondString); }

        /// <summary>
        /// Safe copy a <see cref="string" /> from the start for a maximum number
        /// of characters
        /// </summary>
        /// <param name="s">The <see cref="string" /> to copy.</param>
        /// <param name="maxLength">The maximum length to copy.</param>
        /// <returns>
        /// The copied <see cref="string" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="maxLength" /> exceeds the <see cref="string" />
        /// <see cref="string.Length" /> then the whole string is copied.
        /// <para />
        /// if <paramref name="s" /> is <see langword="null" />, then
        /// <see langword="null" /> is returned.
        /// </remarks>
        public static string Left(this string s, int maxLength)
        {
            return StringHelper.Left(s, maxLength);
        }

        /// <summary>
        /// Lefts the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="character">The character.</param>
        /// <param name="inclusion">The inclusion.</param>
        /// <returns></returns>
        public static string Left(this string s, char character, Inclusion inclusion = Inclusion.Exclude)
        {
            var pos = s.IndexOf(character);
            if (pos < 0) return s;
            return s.Substring(0, (inclusion == Inclusion.Exclude) ? pos : pos + 1);
        }


        /// <summary>
        /// Rights the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        public static string Right(this string s, int maxLength)
        {
            return StringHelper.Right(s, maxLength);
        }

        /// <summary>
        /// Rights the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="character">The character.</param>
        /// <param name="inclusion">The inclusion.</param>
        /// <returns></returns>
        public static string Right(this string s, char character, Inclusion inclusion = Inclusion.Exclude)
        {
            var pos = s.IndexOf(character);
            if (pos < 0) return String.Empty;

            int len = (inclusion == Inclusion.Exclude) ? (s.Length - pos - 1) : (s.Length - pos);
            return s.Substring((inclusion == Inclusion.Exclude) ? pos + 1 : pos, len);
        }

        /// <summary>
        /// Returns true if the two strings match.
        /// </summary>
        /// <param name="firstString">First string</param>
        /// <param name="secondString">Second string</param>
        /// <param name="ignoreCase">Should case (upper/lower) be ignored?</param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <example>if ("Hello".Compare("HELLO", true)) {}</example>
        /// <remarks>
        /// The strings are trimmed and compared in a case-insensitive, culture neutral fashion.
        /// </remarks>
        public static bool Compare(this string firstString, string secondString, bool ignoreCase) { return StringHelper.Compare(firstString, secondString, ignoreCase); }

        /// <summary>
        /// Receives a string as a parameter and returns the string in Proper format (makes each letter after a space capital)
        /// </summary>
        /// <param name="originalString">String</param>
        /// <returns>
        /// Proper string
        /// </returns>
        /// <example>"hello".Proper()</example>
        public static string Proper(this string originalString) { return StringHelper.Proper(originalString); }

        /// <summary>
        /// This method returns strings in proper case.
        /// However, contrary to regular Proper() methods,
        /// this method can be used to format names.
        /// For instance, "MacLeod" will remain "MacLeod",
        /// "macLeod" will be "MacLeod", "MACLEOD" will be turned into
        /// "Macleod". "macleod" will also be turned into "Macleod".
        /// </summary>
        /// <param name="originalString">String that is to be formatted</param>
        /// <returns>
        /// Properly formatted string
        /// </returns>
        /// <example>"macLeod".SmartProper()</example>
        public static string SmartProper(this string originalString) { return StringHelper.SmartProper(originalString); }

        /// <summary>
        /// This method takes a camel-case string (such as one defined by an enum)
        /// and returns is with a space before every upper-case letter.
        /// </summary>
        /// <param name="originalString">String</param>
        /// <returns>
        /// String with spaces
        /// </returns>
        /// <example>"CamelCaseWord".SpaceCamelCase()</example>
        public static string SpaceCamelCase(this string originalString) { return StringHelper.SpaceCamelCase(originalString); }

        /// <summary>
        /// Receives a string and a file name as parameters and writes the contents of the string to that file
        /// </summary>
        /// <param name="expression">String to be written</param>
        /// <param name="fileName">File name the string is to be written to.</param>
        /// <example>"This is the line we want to insert in our file".ToFile(@"c:\My Folders\MyFile.txt");</example>
        public static void ToFile(this string expression, string fileName) { StringHelper.ToFile(expression, fileName); }

        /// <summary>
        /// Receives a string and a file name as parameters and writes the contents of the string to that file
        /// </summary>
        /// <param name="expression">String to be written</param>
        /// <param name="fileName">File name the string is to be written to.</param>
        /// <param name="encoding">File encoding</param>
        /// <example>"This is the line we want to insert in our file".ToFile(@"c:\My Folders\MyFile.txt", Encoding.ASCII);</example>
        public static void ToFile(this string expression, string fileName, Encoding encoding) { StringHelper.ToFile(expression, fileName, encoding); }

        /// <summary>
        /// Loads a file from disk and returns it as a string
        /// </summary>
        /// <param name="fileName">File to be loaded</param>
        /// <returns>
        /// String containing the file contents
        /// </returns>
        /// <example>string text = @"c:\folder\myfile.txt".FromFile();</example>
        public static string FromFile(this string fileName) { return StringHelper.FromFile(fileName); }

        /// <summary>
        /// This method takes any regular string, and returns its base64 encoded representation
        /// </summary>
        /// <param name="original">Original String</param>
        /// <returns>
        /// Base64 encoded string
        /// </returns>
        /// <example>string encoded = "Encode this".Base64Encode();</example>
        public static string Base64Encode(this string original) { return StringHelper.Base64Encode(original); }

        /// <summary>
        /// Takes a base64 encoded string and converts it into a regular string
        /// </summary>
        /// <param name="encodedString">Base64 encoded string</param>
        /// <returns>
        /// Decoded string
        /// </returns>
        /// <example>string decoded = "jumbledText==".Base64Decode();</example>
        public static string Base64Decode(this string encodedString) { return StringHelper.Base64Decode(encodedString); }

        /// <summary>
        /// Receives two strings as parameters and searches for one string within another. If found, returns the beginning numeric position otherwise returns 0
        /// </summary>
        /// <param name="searchIn">String to search in</param>
        /// <param name="searchFor">String to search for</param>
        /// <returns>
        /// Position
        /// </returns>
        /// <example>"Joe Doe".At("D")</example>
        public static int At(this string searchIn, string searchFor) { return StringHelper.At(searchFor, searchIn); }

        /// <summary>
        /// Receives two strings and an occurrence position (1st, 2nd etc) as parameters and
        /// searches for one string within another for that position.
        /// If found, returns the beginning numeric position otherwise returns 0
        /// </summary>
        /// <param name="searchIn">String to search in</param>
        /// <param name="searchFor">String to search for</param>
        /// <param name="occurrence">The occurrence of the string</param>
        /// <returns>
        /// Position
        /// </returns>
        /// <example>
        /// "Joe Doe".At("o", 1); //returns 2
        /// "Joe Doe".At("o", 2); //returns 6
        ///   </example>
        public static int At(this string searchIn, string searchFor, int occurrence) { return StringHelper.At(searchFor, searchIn, occurrence); }

        /// <summary>
        /// Receives a character as a parameter and returns its ANSI code
        /// </summary>
        /// <param name="character">Character</param>
        /// <returns>
        /// ASCII value
        /// </returns>
        /// <example>'#'.Asc(); //returns 35</example>
        public static int Asc(this char character) { return StringHelper.Asc(character); }

        /// <summary>
        /// Receives an integer ANSI code and returns a character associated with it
        /// </summary>
        /// <param name="ansiCode">Character Code</param>
        /// <returns>
        /// Char that corresponds with the ASCII code
        /// </returns>
        /// <example>35.Chr(); returns '#'</example>
        public static char Chr(this int ansiCode) { return StringHelper.Chr(ansiCode); }

        /// <summary>
        /// Receives a string as a parameter and counts the number of words in that string
        /// </summary>
        /// <param name="sourceString">String</param>
        /// <returns>
        /// Word Count
        /// </returns>
        /// <example>
        /// string text = "John Doe is a good man";
        /// text.GetWordCount(); //returns 6
        ///   </example>
        public static long GetWordCount(this string sourceString) 
        { return StringHelper.GetWordCount(sourceString); }

        /// <summary>
        /// Based on the position specified, returns a word from a string
        /// Receives a string as a parameter and counts the number of words in that string
        /// </summary>
        /// <param name="sourceString">String</param>
        /// <param name="wordPosition">Word Position</param>
        /// <returns>
        /// Word number
        /// </returns>
        /// <example>
        /// string text = "John Doe is a good man";
        /// text.GetWordNumber(5); //returns "good"
        ///   </example>
        public static string GetWordNumber(this string sourceString, int wordPosition)
        { return StringHelper.GetWordNumber(sourceString, wordPosition); }

        /// <summary>
        /// Returns a bool indicating if the first character in a string is an alphabet or not
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <returns>
        /// True or False depending on whether the string only had alphanumeric chars
        /// </returns>
        /// <example>"Joe Doe".IsAlpha(); //returns true</example>
        public static bool IsAlpha(this string expression) { return StringHelper.IsAlpha(expression); }

        /// <summary>
        /// Returns the number of occurrences of a character within a string
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="character">Search Character</param>
        /// <returns>
        /// Number of occurrences
        /// </returns>
        /// <example>"Joe Doe".Occurs('o'); //returns 2</example>
        public static int Occurs(this string expression, char character) { return StringHelper.Occurs(character, expression); }

        /// <summary>
        /// Returns the number of occurrences of one string within another string
        /// </summary>
        /// <param name="stringSearched">Expression</param>
        /// <param name="searchString">Search String</param>
        /// <returns>
        /// Number of occurrences
        /// </returns>
        /// <example>
        /// "Joe Doe".Occurs("oe"); //returns 2
        /// "Joe Doe".Occurs("Joe"); //returns 1
        ///   </example>
        public static int Occurs(this string stringSearched, string searchString) { return StringHelper.Occurs(searchString, stringSearched); }

        /// <summary>
        /// Receives a string expression and a numeric value indicating number of time
        /// and replicates that string for the specified number of times.
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="times">Number of times the string is to be replicated</param>
        /// <returns>
        /// New string
        /// </returns>
        /// <example>"Joe".Replicate(5); //returns JoeJoeJoeJoeJoe</example>
        public static string Replicate(this string expression, int times) { return StringHelper.Replicate(expression, times); }

        /// <summary>
        /// Overloaded method for SubStr() that receives starting position and length
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="startPosition">Start Position</param>
        /// <param name="length">Length</param>
        /// <returns>
        /// Substring
        /// </returns>
        public static string SubStr(this string expression, int startPosition, int length) { return StringHelper.SubStr(expression, startPosition, length); }

        /// <summary>
        /// Receives a string and converts it to an integer
        /// </summary>
        /// <param name="expressionSearched">Expression Searched</param>
        /// <param name="searchExpression">Search Expression</param>
        /// <returns>
        /// Line number
        /// </returns>
        /// <example>"Is Life Beautiful? \r\n It sure is".AtLine("Is"); //returns 1</example>
        public static int AtLine(this string expressionSearched, string searchExpression) { return StringHelper.AtLine(searchExpression, expressionSearched); }

        /// <summary>
        /// Receives a string as a parameter and returns a bool indicating if the left most character in the string is a valid digit.
        /// </summary>
        /// <param name="sourceString">Expression</param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <example>if("1Test".IsDigit()){...} //returns true</example>
        public static bool IsDigit(this string sourceString) { return StringHelper.IsDigit(sourceString); }

        /// <summary>
        /// Determines whether the specified source string is an integer.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns>True or False</returns>
        /// <example>if("1Test".IsInteger()){...} //returns false</example>
        public static bool IsInteger(this string sourceString) { return StringHelper.IsInteger(sourceString); }

        /// <summary>
        /// Returns true if the array contains the string we are looking for
        /// </summary>
        /// <param name="searchText">The search string.</param>
        /// <param name="hostArray">The host array.</param>
        /// <returns>
        /// True or false
        /// </returns>
        /// <example>
        /// string[] testArray = new string[] { "One", "Two", "Three" };
        /// bool result1 = "one".ArrayContainsString(testArray, true); // returns true
        /// bool result2 = "one".ArrayContainsString(testArray); // returns false
        /// bool result3 = "One".ArrayContainsString(testArray); // returns true
        /// bool result4 = "Four".ArrayContainsString(testArray); // returns false
        ///   </example>
        public static bool ArrayContainsString(this string searchText, string[] hostArray) { return StringHelper.ArrayContainsString(hostArray, searchText); }

        /// <summary>
        /// Returns true if the array contains the string we are looking for
        /// </summary>
        /// <param name="searchText">The search string.</param>
        /// <param name="hostArray">The host array.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>
        /// True or false
        /// </returns>
        /// <example>
        /// string[] testArray = new string[] { "One", "Two", "Three" };
        /// bool result1 = "one".ArrayContainsString(testArray, true); // returns true
        /// bool result2 = "one".ArrayContainsString(testArray); // returns false
        /// bool result3 = "One".ArrayContainsString(testArray); // returns true
        /// bool result4 = "Four".ArrayContainsString(testArray); // returns false
        ///   </example>
        public static bool ArrayContainsString(this string searchText, string[] hostArray, bool ignoreCase)
        { return StringHelper.ArrayContainsString(hostArray, searchText, ignoreCase); }

        /// <summary>
        /// Strings the contains array element.
        /// </summary>
        /// <param name="searchedText">The searched text.</param>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public static bool StringContainsArrayElement(this string searchedText, string[] array)
        { return StringHelper.StringContainsArrayElement(searchedText, array); }

        /// <summary>
        /// Tries to parse a string value as an integer. If the parse fails, the provided default value will be inserted
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="failedDefault">The failed default.</param>
        /// <returns></returns>
        /// <example>int valueInt = "1".TryIntParse(-1);</example>
        public static int TryIntParse(this string value, int failedDefault) { return StringHelper.TryIntParse(value, failedDefault); }

        /// <summary>
        /// Tries to parse a string value as an Guid. If the parse fails, the provided default value will be inserted
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="failedDefault">The failed default.</param>
        /// <returns></returns>
        /// <example>Guid valueGuid = "xxx".TryGuidParse(Guid.Empty);</example>
        public static Guid TryGuidParse(this string value, Guid failedDefault) { return StringHelper.TryGuidParse(value, failedDefault); }

        /// <summary>
        /// Tries to parse a string value as an Guid. If the parse fails, Guid.Empty will be returned
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <example>Guid guid = "xxx".TryGuidParse();</example>
        public static Guid TryGuidParse(string value) { return StringHelper.TryGuidParse(value); }

        /// <summary>
        /// Determines whether the specified source string 
        /// contains the <paramref name="filter">filter</paramref> string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="sourceString"/> contains <paramref name="filter"/>
        ///   otherwise <c>false</c>.
        /// </returns>
        /// <example>if "xSx".ContainsInvariant("s") then </example>
        public static bool ContainsInvariant(this string sourceString, string filter)
        {
            return sourceString.ToLowerInvariant().Contains(filter);
        }

        /// <summary>
        /// Returns if string contains upper size letters using RegExp
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        ///   <c>true</c> if [contains upper size letter] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsUpperSizeLetter(this string s)
        {
            return new System.Text.RegularExpressions.Regex(@"[A-Z]").IsMatch(s);
        }

        /// <summary>
        /// Returns if string contains lower size letters using RegExp
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        ///   <c>true</c> if [contains lower size letter] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsLowerSizeLetter(this string s)
        {
            return new System.Text.RegularExpressions.Regex(@"[a-z]").IsMatch(s);
        }

        /// <summary>
        /// Shortcut for FormatString
        /// </summary>
        /// <param name="thistr">The thistr.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string FS(this string thistr, params object[] args)
        {
            return String.Format(thistr, args);
        }

        /// <summary>
        /// Swaps the cases in a string
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        /// <example>
        /// word -&gt; WORD
        /// Word -&gt; wORD
        /// WoRd -&gt; wOrD
        ///   </example>
        public static string SwapCases(this string s) { return StringHelper.SwapCases(s); }

        /// <summary>
        /// Remove vowels (selbstlaute) from a given string
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static string RemoveVowels(this string s) { return StringHelper.RemoveVowels(s); }

        /// <summary>
        /// Get vowels from a given string
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static string GetVowels(this string s) { return StringHelper.GetVowels(s); }

        /// <summary>
        /// Inserts the separator.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// "hallo".InsertSeperator("-") = "h-a-l-l-o"
        /// "hallo".InsertSeperator("-",2) = "ha-ll-o"
        /// </code>
        /// </example>
        public static string InsertSeparator(this string s, string separator, int count = 1)
        { return StringHelper.InsertSeparator(s, separator, count); }

        // TODO: http://www.vcskicks.com/string_functions.php


        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string GetValueOrDefault(this string value, string defaultValue = null)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            //Return default
            return defaultValue;
        }

    }
}
