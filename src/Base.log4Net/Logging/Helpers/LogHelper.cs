namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Helpers for logging
    /// </summary>
    public static partial class LogHelper
    {
        /// <summary>
        /// The <see cref="ILog">log</see> object.
        /// </summary>
        private static readonly ILogger? log = ApplicationLogging.CreateLogger("LogHelper");

    }
}
