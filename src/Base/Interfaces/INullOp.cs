namespace Base.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <remarks>
    /// Code originally found at http://www.yoda.arachsys.com/csharp/miscutil/.
    /// </remarks>
    public interface INullOp<T>
    {
        /// <summary>
        /// Determines whether the specified value has value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        bool HasValue(T value);
        /// <summary>
        /// Adds if not null.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        bool AddIfNotNull(ref T accumulator, T value);
    }
}
