namespace Base
{
    using Base.Text;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Helper methods for Exceptions
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
    ///     <term>2014.03.24</term><term>hbaes</term><term>renamed to Exceptions.</term>
    ///     <term>2014.03.24</term><term>hbaes</term><term>added logging.</term>
    ///     <term>2014.03.24</term><term>hbaes</term><term>added Argument checks.</term>
    ///     <term>2014.03.24</term><term>hbaes</term><term>make BuildExceptionMessageString public</term>
    ///   </item>
    /// </list>
    /// </remarks>
    public static partial class ExceptionHelper
    {

        #region private fields

        /// <summary>
        /// The <see cref="ILog">log</see> object.
        /// </summary>
        private static readonly ILogger Log = ApplicationLogging.CreateLogger("Base.ExceptionHelper");

        /// <summary>
        /// Mask used to mask exception data in string
        /// </summary>
        private const string cERRORMASK = @"BINERROR";

        /// <summary>
        /// Split exception data from String.
        /// </summary>
        private const string cERRORMASKSPLIT = @"\n\n";

        #endregion

        #region BuildExceptionMessage

        /// <summary>
        /// Build an Exception Message with additional header title
        /// </summary>
        /// <param name="ex">The x.</param>
        /// <param name="headerTitle">The header title.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(Exception ex, string headerTitle)
        {
            string ErrMessages = Environment.NewLine + headerTitle;
            List<string> messages = GetAllErrMessages(ex);
            foreach (string message in messages)
                ErrMessages += message;
            return ErrMessages;
        }

        /// <summary>
        /// Builds the exception message.
        /// </summary>
        /// <param name="ex">The x.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(Exception ex)
        {
            string ErrMessages = string.Empty;
            ErrMessages = Environment.NewLine;
            List<string> messages = GetAllErrMessages(ex);
            foreach (string message in messages)
                ErrMessages += message;
            return ErrMessages;
        }

        /// <summary>
        /// Builds the exception message string.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="indent">The indent.</param>
        /// <returns></returns>
        public static string BuildExceptionMessageString(Exception ex, int indent = 0)
        {
            string message = String.Empty;
            if (ex != null)
            {
                message += Environment.NewLine;
                message += "".PadLeft(50, '=');
                message += Environment.NewLine;
                message += "".PadLeft(indent, '.') + "Message:" + ex.Message;
                message += Environment.NewLine;
                message += "".PadLeft(indent, '.') + "Source:" + ex.Source;
                message += Environment.NewLine;
                message += "".PadLeft(indent, '.') + "Stack Trace:" + ex.StackTrace;
                message += Environment.NewLine;
                message += "".PadLeft(indent, '.') + "TargetSite:" + ex.TargetSite;
                message += "".PadLeft(50, '=');
                message += Environment.NewLine;
            }
            return message;
        }

        #endregion

        /// <summary>
        /// fetch most inner exception
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static Exception GetOriginalException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex;
            return ex.InnerException.GetOriginalException();
        }

        #region Exception masking in string

        /// <summary>
        /// Mask an exception into a special string using serialization
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static string MaskException(Exception ex)
        {
            string res = String.Empty;
            res = string.Format("{0}{1}{2}{1}", cERRORMASK, cERRORMASKSPLIT, StringHelper.SerializeToString(ex));
            return res;
        }

        /// <summary>
        /// check if an string contains an masked error exception...
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static bool StringContainsMaskedError(string text)
        {
            if (text.StartsWith(cERRORMASK))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get the raw exception data out of masked string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static Exception? UnMaskException(string text)
        {
            Exception? ex = null;
            if (StringContainsMaskedError(text))
            {
                // split the serialized exception
                string[] arr = text.Split(new string[] { cERRORMASKSPLIT }, StringSplitOptions.None);
                if (arr.Length > 0)
                {
                    string rawdata = arr[1];
                    ex = (Exception)StringHelper.DeserializeFromString(rawdata);
                }
            }
            return ex;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Gets all err messages.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private static List<string> GetAllErrMessages(Exception ex)
        {
            List<string> messages = new List<string>();
            int indent = 0;
            for (Exception eCurrent = ex; eCurrent != null; eCurrent = eCurrent.InnerException)
            {
                messages.Add(BuildExceptionMessageString(eCurrent, indent));
                indent = indent + 1;
            }
            return messages;
        }

        #endregion

    }
}
