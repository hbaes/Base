namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Extension class describing Bit Functions
    /// </summary>
    public static class BitExtensions
    {

        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <returns></returns>
        public static int Set(this int value, int flag)
        {
            return BitHelper.Set(value, flag, true);
        }

        /// <summary>
        /// Resets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns></returns>
        public static int Reset(this int value, int flag, bool state)
        {
            return BitHelper.Set(value, flag, false);
        }

        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns></returns>
        public static int Set(this int value, int flag, bool state)
        {
            return BitHelper.Set(value, flag, state);
        }
    }
}
