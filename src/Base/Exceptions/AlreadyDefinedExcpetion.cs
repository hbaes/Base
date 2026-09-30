namespace Base
{
    using System;
    using System.Runtime.Serialization;


    /// <summary>
    /// Exception class used for enumeration errors.
    /// The error is raised when an enumeration finds its enumeration source in disarray
    /// and thus overshoots the sources bounds
    /// </summary>
    [Serializable]
    public class AlreadyDefinedExcpetion: Exception
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public AlreadyDefinedExcpetion() : base("Given value already defined!") { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AlreadyDefinedExcpetion(string message) : base(message) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public AlreadyDefinedExcpetion(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected AlreadyDefinedExcpetion(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

