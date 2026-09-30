namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Exception Extensions
    /// </summary>
    /// <remarks>
    /// <c>History:</c>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Date</term>
    ///     <term>User</term>
    ///     <term>Description</term>
    ///   </listheader>
    ///   <item>
    ///     <term>2013.02.23</term><term>hbaes</term><term>finished documentation.</term>
    ///   </item>
    /// </list>
    /// </remarks>
    public static partial class ExceptionExtensions
    {

        /// <summary>
        /// Build an Exception Message with additional header title
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="headerTitle">The header title.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(this Exception ex, string headerTitle, params object[] args)
        {
            return ExceptionHelper.BuildExceptionMessage(ex, string.Format(headerTitle, args));
        }

        /// <summary>
        /// Build an Exception Message with additional header title
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="headerTitle">The header title.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(this Exception ex, string headerTitle)
        {
            return ExceptionHelper.BuildExceptionMessage(ex, headerTitle);
        }

        /// <summary>
        /// Builds the exception message.
        /// </summary>
        /// <param name="ex">The x.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(this Exception ex)
        {
            return ExceptionHelper.BuildExceptionMessage(ex);
        }

        /// <summary>
        /// fetch most inner exception
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static Exception GetOriginalException(this Exception ex)
        {
            return ExceptionHelper.GetOriginalException(ex);
        }

    }
}
