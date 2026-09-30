namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class StringHelper
    {
        /// <summary>
        /// Tries to parse a string value as an integer. If the parse fails, the provided default value will be inserted
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="failedDefault">The failed default.</param>
        /// <returns></returns>
        /// <example>
        /// string value = "1";
        /// int valueInt = StringHelper.TryIntParse(value, -1);
        ///   </example>
        public static int TryIntParse(string value, int failedDefault)
        {
            int parsedValue;
            return int.TryParse(value, out parsedValue) ? parsedValue : failedDefault;
        }

        /// <summary>
        /// Tries to parse a string value as an Guid. If the parse fails, the provided default value will be inserted
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="failedDefault">The failed default.</param>
        /// <returns></returns>
        /// <example>
        /// string value = "xxx";
        /// Guid valueGuid = StringHelper.TryGuidParse(value, Guid.Empty);
        ///   </example>
        public static Guid TryGuidParse(string value, Guid failedDefault)
        {
            try
            {
                return new Guid(value);
            }
            catch
            {
                return failedDefault;
            }
        }

        /// <summary>
        /// Tries to parse a string value as an Guid. If the parse fails, Guid.Empty will be returned
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <example>
        /// string value = "xxx";
        /// Guid valueGuid = StringHelper.TryGuidParse(value);
        ///   </example>
        public static Guid TryGuidParse(string value)
        {
            return TryGuidParse(value, Guid.Empty);
        }

    }
}
