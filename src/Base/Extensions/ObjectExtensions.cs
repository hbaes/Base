namespace Base
{
    using System;

    /// <summary>
    /// Object extensions
    /// </summary>
    public static partial class ObjectExtensions
    {

        /// <summary>
        /// Safely converts a value into a Guid or returns Guid.Empty if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Guid</returns>
        /// <remarks>
        /// This method is an extension method.
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// Guid myGuid = dataSet.Tables[0].Rows[0]["id"].ToGuidSave();
        /// </code>
        /// </example>
        public static Guid ToGuidSafe(this object value)
        {
            return ObjectHelper.ToGuidSafe(value);
        }

        /// <summary>
        /// Safely converts a value into a string or returns string.Empty if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string or string.Empty</returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// string myString = dataSet.Tables[0].Rows[0]["name"].ToStringSave();
        /// </code>
        /// </example>
        public static string ToStringSafe(this object value)
        {
            return ObjectHelper.ToStringSafe(value);
        }

        /// <summary>
        /// Convert Object to a Nice text (null)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string, or (null) or System.DBNull.Value</returns>
        public static string ToStringNice(this object value)
        {
            return ObjectToStringHelper.ToString(value);
        }

        /// <summary>
        /// Safely converts a value into a boolean or returns false if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// bool myBool = dataSet.Tables[0].Rows[0]["active"].ToBooleanSave();
        /// </code>
        /// </example>
        public static bool ToBooleanSafe(this object value)
        {
            return ObjectHelper.ToBooleanSafe(value);
        }

        /// <summary>
        /// Safely converts a value into a DateTime or returns DateTime.MinValue if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// DateTime myDate = dataSet.Tables[0].Rows[0]["timeStamp"].ToDateTimeSave();
        /// </code>
        /// </example>
        public static DateTime ToDateTimeSafe(this object value)
        {
            return ObjectHelper.ToDateTimeSafe(value);
        }

        /// <summary>
        /// Safely converts a value into an integer or returns 0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// int myInt = dataSet.Tables[0].Rows[0]["number"].ToIntegerSave();
        /// </code>
        /// </example>
        public static int ToIntegerSafe(this object value)
        {
            return ObjectHelper.ToIntegerSafe(value);
        }

        /// <summary>
        /// Safely converts a value into a byte array or returns an empty byte array if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// byte[] myBytes = dataSet.Tables[0].Rows[0]["image"].ToByteArraySave();
        /// </code>
        /// </example>
        public static byte[] ToByteArraySafe(this object value)
        {
            return ObjectHelper.ToByteArraySafe(value);
        }

        /// <summary>
        /// Safely converts a value into a double or returns 0.0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// int myDouble = dataSet.Tables[0].Rows[0]["number"].ToDoubleSave();
        /// </code>
        /// </example>
        public static double ToDoubleSafe(this object value)
        {
            return ObjectHelper.ToDoubleSafe(value);
        }

        /// <summary>
        /// Safely converts a value into a decimal or returns 0.0 if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// decimal myDec = dataSet.Tables[0].Rows[0]["price"].ToDecimalSave();
        /// </code>
        /// </example>
        public static decimal ToDecimalSafe(this object value)
        {
            return ObjectHelper.ToDecimalSafe(value);
        }

        /// <summary>
        /// Safely converts a value into a char or returns ' ' if the value is invalid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is an extension method
        /// </remarks>
        /// <example>
        /// <code>
        /// using ITB.Helper;
        /// 
        /// // more code here
        /// 
        /// char myChar = dataSet.Tables[0].Rows[0]["character"].ToCharSave();
        /// </code>
        /// </example>
        public static char ToCharSafe(this object value)
        {
            return ObjectHelper.ToCharSafe(value);
        }




    }
}
