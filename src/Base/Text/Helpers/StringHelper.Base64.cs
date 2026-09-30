namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// This method takes any regular string, and returns its base64 encoded representation
        /// </summary>
        /// <param name="original">Original String</param>
        /// <returns>
        /// Base64 encoded string
        /// </returns>
        public static string Base64Encode(string original)
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(original));
        }

        /// <summary>
        /// Takes a base64 encoded string and converts it into a regular string
        /// </summary>
        /// <param name="encodedString">Base64 encoded string</param>
        /// <returns>
        /// Decoded string
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#", Justification = "This is a special case and the 'string' part is not identifying the type.")]
        public static string Base64Decode(string encodedString)
        {
            return new ASCIIEncoding().GetString(Convert.FromBase64String(encodedString));
        }

    }
}
