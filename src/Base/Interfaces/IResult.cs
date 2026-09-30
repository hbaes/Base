namespace Base.Interfaces
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult<T>
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        T Value { get; }
    }
}
