namespace Base
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Globalization;


    /// <summary>
    /// Object helper class.
    /// </summary>
    public static partial class ObjectHelper
    {
        #region Private helper.
        // ------------------------------------------------------------------

        /// <summary>
        /// Number Style
        /// </summary>
        private static readonly NumberStyles floatNumberStyle =
            NumberStyles.Float |
            NumberStyles.Number |
            NumberStyles.AllowThousands |
            NumberStyles.AllowDecimalPoint |
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowLeadingWhite |
            NumberStyles.AllowTrailingWhite;

        /// <summary>
        /// The <see cref="ILog">log</see> object.
        /// </summary>
        private static readonly ILogger Log = ApplicationLogging.CreateLogger("Base.ObjectHelper");

        // ------------------------------------------------------------------
        #endregion

        /// <summary>
        ///   Checks whether the 2 specified objects are equal. This method is better, simple because it also checks boxing so
        ///   2 integers with the same values that are boxed are equal.
        /// </summary>
        /// <param name = "object1">The first object.</param>
        /// <param name = "object2">The second object.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise <c>false</c>.</returns>
        public static bool AreEqual(object object1, object object2)
        {
            if ((object1 == null) && (object2 == null))
            {
                return true;
            }

            if ((object1 == null) || (object2 == null))
            {
                return false;
            }

            if (ReferenceEquals(object1, object2))
            {
                return true;
            }

            var firstTagAsString = object1 as string;
            var secondTagAsString = object2 as string;

            if ((firstTagAsString != null) && (secondTagAsString != null))
            {
                return string.Compare(firstTagAsString, secondTagAsString, StringComparison.Ordinal) == 0;
            }

            if (object1 == object2)
            {
                return true;
            }

            if (object1.Equals(object2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Checks whether the 2 specified objects are equal references. This method is better, simple because it also checks boxing so
        ///   2 integers with the same values that are boxed are equal.
        /// <para />
        ///   Two objects are considered equal if one of the following expressions returns true:
        /// <list type="bullet">
        ///   <item><description>Both values are <c>null</c>.</description></item>
        ///   <item><description>Both values have the same reference, checked by <see cref="object.ReferenceEquals"/>.</description></item>
        ///   <item><description>Both values are value types and have the same value.</description></item>
        ///   <item><description>Both values are string type and have the same value.</description></item>
        /// </list>
        /// </summary>
        /// <param name = "object1">The first object.</param>
        /// <param name = "object2">The second object.</param>
        /// <returns><c>true</c> if the objects are equal references; otherwise <c>false</c>.</returns>
        public static bool AreEqualReferences(object object1, object object2)
        {
            if ((object1 == null) && (object2 == null))
            {
                return true;
            }

            if ((object1 == null) || (object2 == null))
            {
                return false;
            }

            if (ReferenceEquals(object1, object2))
            {
                return true;
            }

            var object1Type = object1.GetType();
            var object2Type = object2.GetType();

            if (object1Type.IsValueTypeEx() && object2Type.IsValueTypeEx())
            {
                return object1.Equals(object2);
            }

            var firstTagAsString = object1 as string;
            var secondTagAsString = object2 as string;

            if ((firstTagAsString != null) && (secondTagAsString != null))
            {
                return string.Compare(firstTagAsString, secondTagAsString, StringComparison.Ordinal) == 0;
            }

            return false;
        }

        /// <summary>
        /// Dynamically invokes the specified method on the defined object
        /// </summary>
        /// <typeparam name="TResult">The expected return type for the method</typeparam>
        /// <param name="valueObject">The value object (object that contains the method).</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The method's return value</returns>
        /// <remarks>
        /// The method must be an instance method
        /// This method can be called as an extension method.
        /// </remarks>
        /// <example>
        /// using EPS.Utilities;
        /// // more code
        /// var customer = this.GetCustomerObject();
        /// object[] parameters = { "John", "M.", "Smith" };
        /// string fullName = customer.InvokeMethod&lt;string&gt;("GetFullName", parameters);
        /// </example>
        public static TResult InvokeMethod<TResult>(object valueObject, string methodName, object[] parameters)
        {
            try
            {
                var type = valueObject.GetType();
                var methodInfo = type.GetMethod(methodName, System.Reflection.BindingFlags.Public |
                                                            System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                if (methodInfo != null) return (TResult)methodInfo.Invoke(valueObject, parameters);
                return default(TResult);
            }
            catch
            {
                return default(TResult);
            }
        }

    }
}
