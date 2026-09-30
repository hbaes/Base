using Base.Interfaces;

namespace Base.Generics
{
    /// <remarks>
    /// Code originally found at http://www.yoda.arachsys.com/csharp/miscutil/.
    /// </remarks>
    sealed class ClassNullOp<T> : INullOp<T>
        where T : class
    {
        /// <summary>
        /// Determines whether the specified value has value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool HasValue(T value)
        {
            return value != null;
        }

        /// <summary>
        /// Adds if not null.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool AddIfNotNull(ref T accumulator, T value)
        {
            if (value != null)
            {
                accumulator = accumulator == null ? value : Operator<T>.Add(accumulator, value);
                return true;
            }
            return false;
        }

    }
}
