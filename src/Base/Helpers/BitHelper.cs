namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Helper class for Bit Manipulations
    /// </summary>
    public static class BitHelper
    {
        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <returns></returns>
        public static int Set(int value, int flag)
        {
            return Set(value, flag, true);
        }

        /// <summary>
        /// Resets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns></returns>
        public static int Reset(int value, int flag, bool state)
        {
            return Set(value, flag, false);
        }

        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns></returns>
        public static int Set(int value, int flag, bool state)
        {
            if (state)
                return value | flag;

            return value & (~flag);
        }
    }
}

