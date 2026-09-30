using Base.Interfaces;

namespace Base.Generics
{
    /// <remarks>
    /// Code originally found at http://www.yoda.arachsys.com/csharp/miscutil/.
    /// </remarks>
    sealed class StructNullOp<T> : INullOp<T>, INullOp<T?>
        where T : struct
    {
        /// <summary>
        /// Determines whether the specified value has value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool HasValue(T value)
        {
            return true;
        }

        /// <summary>
        /// Adds if not null.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool AddIfNotNull(ref T accumulator, T value)
        {
            accumulator = Operator<T>.Add(accumulator, value);
            return true;
        }

        /// <summary>
        /// Determines whether the specified value has value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool HasValue(T? value)
        {
            return value.HasValue;
        }

        /// <summary>
        /// Adds if not null.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool AddIfNotNull(ref T? accumulator, T? value)
        {
            if (value.HasValue)
            {
                accumulator = accumulator.HasValue ? Operator<T>.Add(accumulator.GetValueOrDefault(), value.GetValueOrDefault()) : value;
                return true;
            }

            return false;
        }
    }
}
