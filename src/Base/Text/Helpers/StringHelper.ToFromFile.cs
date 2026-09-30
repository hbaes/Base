namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public static partial class StringHelper
    {
        /// <summary>
        /// Receives a string and a file name as parameters and writes the contents of the string to that file
        /// </summary>
        /// <param name="expression">String to be written</param>
        /// <param name="fileName">File name the string is to be written to.</param>
        /// <example>
        /// <code>
        /// string text = "This is the line we want to insert in our file.";
        /// StringHelper.ToFile(text, @"c:\My Folders\MyFile.txt");
        /// </code>
        /// </example>
        public static void ToFile(string expression, string fileName)
        {
            ToFile(expression, fileName, Encoding.Default);
        }

        /// <summary>
        /// Receives a string and a file name as parameters and writes the contents of the string to that file
        /// </summary>
        /// <param name="expression">String to be written</param>
        /// <param name="fileName">File name the string is to be written to.</param>
        /// <param name="encoding">File encoding</param>
        /// <example>
        /// <code>
        /// string text = "This is the line we want to insert in our file.";
        /// StringHelper.ToFile(text, "c:\\My Folders\\MyFile.txt", Encoding.Unicode);
        /// </code>
        /// </example>
        public static void ToFile(string expression, string fileName, Encoding encoding)
        {
            Argument.IsNotNullOrEmpty("fileName", fileName);
            //Check if the sepcified file exists
            if (File.Exists(fileName))
            {
                //If so then Erase the file first as in this case we are overwriting
                File.Delete(fileName);
            }

            using (var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(stream, encoding))
                {
                    writer.Write(expression);
                    writer.Flush();
                    writer.Close();
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Loads a file from disk and returns it as a string
        /// </summary>
        /// <param name="fileName">File to be loaded</param>
        /// <returns>
        /// String containing the file contents
        /// </returns>
        public static string FromFile(string fileName)
        {
            Argument.IsNotNullOrEmpty("fileName", fileName);
            var reader = File.OpenText(fileName);
            var retVal = reader.ReadToEnd();
            reader.Close();
            return retVal;
        }

    }
}
