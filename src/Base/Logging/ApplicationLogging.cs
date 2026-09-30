using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Base
{
    /// <summary>
    /// Application Logger for static classes implementing ILogger Factory
    /// </summary>
    public static class ApplicationLogging
    {
        /// <summary>
        /// Gets or sets the logger factory.
        /// </summary>
        /// <value>
        /// The logger factory.
        /// </value>
        public static ILoggerFactory LoggerFactory { get; set; }
        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);

    }
}
