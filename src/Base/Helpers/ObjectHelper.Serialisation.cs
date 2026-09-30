namespace Base
{
    using System;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Object helper class handling Serialisation
    /// </summary>
    public static partial class ObjectHelper
    {

        
        /// <summary>
        /// Deserializes an object from its state stored in an xml stream.
        /// </summary>
        /// <param name="stateStream">The state stream.</param>
        /// <param name="expectedType">The expected type (which will be the returned type).</param>
        /// <returns>Object instance.</returns>
        /// <remarks>
        /// For this to work, the XML Stream must contain a serialized object
        /// </remarks>
        /// <example>
        /// Customer customer = (Customer)EPS.Utilities.ObjectHelper.DeserializeFromXmlStream(stream, typeof(Customer));
        /// </example>
        public static object DeserializeFromXmlStream(Stream stateStream, Type expectedType)
        {
            var serializer = new XmlSerializer(expectedType);
            return serializer.Deserialize(stateStream);
        }

        /// <summary>
        /// De-serializes an object from its state stored in an XML stream.
        /// </summary>
        /// <param name="stateStream">The state stream.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>Object instance</returns>
        /// <remarks>
        /// For this to work, the XML Stream must contain a serialized object
        /// </remarks>
        /// <example>
        /// using EPS.Utilities;
        /// // more code
        /// Customer customer = (Customer)stream.DeserializeFromXmlStream(typeof(Customer));
        /// </example>
        public static object DeserializeFromXml(Stream stateStream, Type expectedType)
        {
            return DeserializeFromXmlStream(stateStream, expectedType);
        }

        /// <summary>
        /// Serializes an object to its XML state
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns>
        /// XML stream representing the object's state
        /// </returns>
        /// <remarks>
        /// For this to work, the provided object must be serializable.
        /// This method can be used as an extension method.
        /// </remarks>
        /// <example>
        /// using EPS.Utilities;
        /// // more code
        /// Stream xmlStream = customer.SerializeToXmlStream();
        /// // or
        /// Stream xmlStream = EPS.Utilities.ObjectHelper.SerializeToXmlStream(customer);
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#", Justification = "Following the rule would lead to more misleading code in this specific case.")]
        public static Stream SerializeToXmlStream(object objectToSerialize)
        {
            var stream = new MemoryStream();
            var serializer = new XmlSerializer(objectToSerialize.GetType());
            serializer.Serialize(stream, objectToSerialize);
            return stream;
        }

        /// <summary>
        /// Serializes an object to its XML state
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns>
        /// XML string representing the object's state
        /// </returns>
        /// <remarks>
        /// For this to work, the provided object must be serializable.
        /// This method can be used as an extension method.
        /// </remarks>
        /// <example>
        /// using EPS.Utilities;
        /// // more code
        /// string xml = customer.SerializeToXmlString();
        /// // or
        /// string xml = EPS.Utilities.ObjectHelper.SerializeToXmlString(customer);
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#", Justification = "Following the rule would lead to more misleading code in this specific case.")]
        public static string SerializeToXmlString(object objectToSerialize)
        {
            return StreamHelper.ToString(SerializeToXmlStream(objectToSerialize));
        }

        
    }
}
