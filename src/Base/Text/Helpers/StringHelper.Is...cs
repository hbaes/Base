namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Returns a bool indicating if the first character in a string is an alphabet or not
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <returns>
        /// True or False depending on whether the string only had alphanumeric chars
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.IsAlpha("Joe Doe"); // returns true
        /// </code>
        /// </example>
        public static bool IsAlpha(string expression)
        {
            //Check if the first character is a letter
            return Char.IsLetter(expression[0]);
        }

        /// <summary>
        /// Determines whether the specified value is an integer.
        /// </summary>
        /// <param name="expression">The value.</param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <example>
        /// <code>
        /// if(StringHelper.IsINteger("1Kamal")){...}	//returns false
        /// </code>
        /// </example>
        public static bool IsInteger(string expression)
        {
            int result;
            if (int.TryParse(expression, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Receives a string as a parameter and returns a bool indicating
        /// if the left most character in the string is a valid digit.
        /// </summary>
        /// <param name="sourceString">Expression</param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <example>
        /// <code>
        /// if(StringHelper.IsDigit("1Kamal")){...}	//returns true
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
        public static bool IsDigit(string sourceString)
        {
            //get the first character in the string
            var chr = sourceString[0];
            return Char.IsDigit(chr);
        }



        /// <summary>
        /// Does some (weak) validations whether the given strings
        /// are valid e-mail addresses.
        /// It only returns TRUE if all strings are valid.
        /// </summary>
        /// <param name="emailAddresses">The strings to check.</param>
        /// <returns>
        /// Returns TRUE if the e-mail addresses seems to be valid,
        /// FALSE if not.
        /// </returns>
        public static bool IsValidEMailAddress(string[] emailAddresses)
        {
            if (emailAddresses == null || emailAddresses.Length <= 0)
            {
                return false;
            }
            else
            {
                return IsValidEMailAddress(string.Join(@";", emailAddresses));
            }
        }

        /// <summary>
        /// Does some (weak) validations whether the given string
        /// is a valid e-mail address.
        /// The string can contain multiple e-mail-addresses, separated by
        /// semicolon (";"). It then only returns TRUE if all are valid.
        /// </summary>
        /// <param name="emailAddress">The string to check.</param>
        /// <returns>
        /// Returns TRUE if the e-mail address seems to be valid,
        /// FALSE if not.
        /// </returns>
        public static bool IsValidEMailAddress(string emailAddress)
        {
            if (emailAddress == null || emailAddress.Trim().Length <= 0)
            {
                return false;
            }
            else
            {
                string[] ss = emailAddress.Split(';');

                if (ss.Length <= 0)
                {
                    return false;
                }
                else
                {
                    foreach (string s_ in ss)
                    {
                        string s = s_.Trim();

                        if (s.Length <= 0)
                        {
                            return false;
                        }
                        else
                        {
                            // Location of "@".
                            int atPos = s.IndexOf(@"@");

                            if (atPos < 0 ||
                                s.LastIndexOf(@".") < atPos + 1)
                            {
                                // "@" must exist, and last "." 
                                // in string must follow the "@".
                                return false;
                            }
                            else if (s.IndexOf(@"@", atPos + 1) > atPos)
                            {
                                // String can't have more than one "@".
                                return false;
                            }
                            else if (s.Substring(atPos + 1, 1) == @".")
                            {
                                // String can't have "." 
                                // immediately following "@".
                                return false;
                            }
                            else if (s.Substring(
                                s.Length - 2).IndexOf(@".") > 0)
                            {
                                // String must have at least 
                                // a two-character top-level domain.
                                return false;
                            }
                        }
                    }

                    // All valid.
                    return true;
                }
            }
        }

    }
}
