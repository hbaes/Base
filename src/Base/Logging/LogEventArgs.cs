namespace Base
{
    using System;

    public class LogEventArgs
    {
        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        /// <value>
        /// The log level.
        /// </value>
        public LogLevels LogLevel { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }
        /// <summary>
        /// Gets or sets the log time.
        /// </summary>
        /// <value>
        /// The log time.
        /// </value>
        public DateTime LogTime { get; set; }


        public LogEventArgs() { }

        public LogEventArgs(string message)
            : base()
        {
            this.Message = message;
            this.LogLevel = LogLevels.Debug;
        }

        public LogEventArgs(string messageFormat, params object[] args)
            : base()
        {
            this.Message = string.Format(messageFormat, args);
            this.LogLevel = LogLevels.Debug;
        }

        public LogEventArgs(LogLevels logLevel, string message)
            : base()
        {
            this.Message = message;
            this.LogLevel = logLevel;
        }

        public LogEventArgs(LogLevels logLevel, string messageFormat, params object[] args)
            : base()
        {
            this.Message = string.Format(messageFormat, args);
            this.LogLevel = logLevel;
        }

        public LogEventArgs(Exception ex)
            : base()
        {
            this.LogLevel = LogLevels.Error;
            this.Exception = ex;
        }

        public LogEventArgs(Exception ex, string message)
            : base()
        {
            this.LogLevel = LogLevels.Error;
            this.Message = message;
            this.Exception = ex;
        }

        public LogEventArgs(Exception ex, string messageFormat, params object[] args)
            : base()
        {
            this.LogLevel = LogLevels.Error;
            this.Message = string.Format(messageFormat, args);
            this.Exception = ex;
        }

    }
}
