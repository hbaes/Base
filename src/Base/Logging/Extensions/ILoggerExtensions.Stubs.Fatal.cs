namespace Base
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extensions to the <see cref="ILog" /> interface.
    /// Generates new Stubs asking if log is enabled.
    /// so instead of using:
    /// <example>
    /// // instead
    /// if (log.IsdebugEnabled) log.Debug("...");
    /// // just use
    /// log.Debug("....");
    /// // or
    /// log.D("...");
    /// </example>
    /// </summary>
    public static partial class ILoggerExtensions
    {

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        public static void Fatal(this ILogger log, string message)
        {
            log.LogError(message);
        }

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void Fatal(this ILogger log, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, args);
        }

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void Fatal(this ILogger log, Exception exception, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, exception, args);
        }

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        public static void F(this ILogger log, string message)
        {
            log.LogError(message);
        }

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void F(this ILogger log, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, args);
        }

        /// <summary>
        /// FATAL message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void F(this ILogger log, Exception exception, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, exception, args);
        }

    }
}
