namespace Base.Interfaces
{
    using System;

    /// <summary>
    /// Interface describing an error result
    /// </summary>
    public interface IResultError
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IResultError"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        bool Error { get; }
        /// <summary>
        /// Gets the ex.
        /// </summary>
        /// <value>
        /// The ex.
        /// </value>
        Exception Ex { get; }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}
