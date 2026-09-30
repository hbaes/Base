namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;


    public static partial class StringHelper
    {
        /// <summary>
        /// Converts a numeric value into a string that represents the number
        /// expressed as a size value in bytes, kilobytes, megabytes, or
        /// gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns></returns>
        public static string FormatFileSize(int fileSize)
        {
            return FormatFileSize((long)fileSize);
        }

        /// <summary>
        /// Converts a numeric value into a string that represents the number
        /// expressed as a size value in bytes, kilobytes, megabytes, or
        /// gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns></returns>
        public static string FormatFileSize(long fileSize)
        {
            const long fileSize1KB = 1024;
            const long fileSize100KB = 102400;
            const long fileSize1MB = 1048576;
            const long fileSize1GB = 1073741824;
            const long fileSize1TB = 1099511627776;

            if (fileSize < fileSize1KB)
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0} {1}",
                    fileSize,
                    "bytes");
            }
            else if (fileSize < fileSize100KB)
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0:F1} {1}",
                    (double)fileSize / (double)fileSize1KB,
                    "kB");
            }
            else if (fileSize < fileSize1MB)
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0} {1}",
                    fileSize / fileSize1KB,
                    "kB");
            }
            else if (fileSize < fileSize1GB)
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0:F1} {1}",
                    (double)fileSize / (double)fileSize1MB,
                    "MB");
            }
            else if (fileSize < fileSize1TB)
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0:F2} {1}",
                    (double)fileSize / (double)fileSize1GB,
                    "GB");
            }
            else
            {
                return string.Format(
                    Thread.CurrentThread.CurrentCulture,
                    @"{0:F2} {1}",
                    (double)fileSize / (double)fileSize1TB,
                    "TB");
            }
        }

        /// <summary>
        /// split Version string from VersionInfo string
        /// </summary>
        /// <param name="stringWithVersionInfo">String containing 'Version=...,'</param>
        /// <returns>
        /// version information if found
        /// </returns>
        /// <example>
        ///   <code>
        /// if(StringHelper.FormatVersionFromVersionInfo("Version=1.0.0,Binary=...")==@"1.0.0")
        /// found it
        ///   </code>
        ///   </example>
        public static string FormatVersionFromVersionInfo(string stringWithVersionInfo)
        {
            string _search = "Version=";
            if (stringWithVersionInfo.Contains(_search))
            {
                Int32 _iPos = stringWithVersionInfo.IndexOf(_search);
                _iPos += _search.Length;
                string _tmp = stringWithVersionInfo.Substring(_iPos);
                return _tmp.Split(',')[0];
            }
            else
            {
                return stringWithVersionInfo;
            }
        }

    }
}
