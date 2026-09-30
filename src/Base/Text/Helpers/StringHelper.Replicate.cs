namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Receives a string expression and a numeric value indicating number of time and replicates that string for the specified number of times.
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="times">Number of times the string is to be replicated</param>
        /// <returns>
        /// New string
        /// </returns>
        /// <example>
        /// <code>
        /// StringHelper.Replicate("Joe", 5); // returns JoeJoeJoeJoeJoe
        /// </code>
        /// </example>
        public static string Replicate(string expression, int times)
        {
            var sb = new StringBuilder();
            sb.Insert(0, expression, times);
            return sb.ToString();
        }

    }
}
