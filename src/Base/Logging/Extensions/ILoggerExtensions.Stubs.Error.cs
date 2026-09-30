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
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        public static void Error(this ILogger log, string message)
        {
            log.LogError(message);
        }

        /// <summary>
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void Error(this ILogger log, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, args);
        }

        /// <summary>
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void Error(this ILogger log, Exception exception, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, exception, args);
        }

        /// <summary>
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        public static void E(this ILogger log, string message)
        {
            log.LogError(message);
        }

        /// <summary>
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void E(this ILogger log, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, args);
        }

        /// <summary>
        /// ERROR message 2 Log
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="args">The arguments.</param>
        public static void E(this ILogger log, Exception exception, string messageFormat, params object[] args)
        {
            log.LogError(messageFormat, exception, args);
        }

        /// <summary>
        /// Writes the specified message as error message with extra data.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        /// <param name="extraData">The extra data.</param>
        public static void ErrorWithData(this ILogger log, string message, object? extraData = null)
        {
            log.LogError(message, extraData);
        }

        /// <summary>
        /// Writes the specified message as error message with log data.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        /// <param name="logData">The log data.</param>
        public static void ErrorWithData(this ILogger log, string message, LogData logData)
        {
            log.LogError(message, logData);
        }
    }
}
