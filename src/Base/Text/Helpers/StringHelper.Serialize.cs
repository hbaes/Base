namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Runtime.Serialization;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Collections.Specialized;
    using System.Text.Json;

    public static partial class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private const string stringDictionaryKey = @"__is_StringDictionary_wrapper__";

        /// <summary>
        /// Serializes an object to a string.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <returns>
        /// Returns the base64-encoded string
        /// that represents the serialized object.
        /// </returns>
        public static string SerializeToString(object o)
        {
            if (o == null)
            {
                return null;
            }
            else
            {
                StringDictionary dic = o as StringDictionary;

                // Special case for string dictionary.
                if (dic != null)
                {
                    Hashtable ht = new Hashtable();

                    foreach (string key in dic.Keys)
                    {
                        ht[key] = dic[key];
                    }

                    // Remember.
                    ht[stringDictionaryKey] = true;

                    o = ht;
                }

                return JsonSerializer.Serialize(o);
            }
        }

        /// <summary>
        /// Deserializes an object from a string.
        /// </summary>
        /// <param name="s">The base64-encoded string
        /// that represents the serialized object.</param>
        /// <returns>
        /// Returns the deserialized object.
        /// </returns>
        public static object DeserializeFromString(string s)
        {
            return DeserializeFromString(s, true);
        }

        /// <summary>
        /// Deserializes an object from a string.
        /// </summary>
        /// <param name="s">The base64-encoded string
        /// that represents the serialized object.</param>
        /// <param name="ignoreSerializationExceptions">if set to <c>true</c> [ignore serialization exceptions].</param>
        /// <returns>
        /// Returns the deserialized object.
        /// </returns>
        public static object DeserializeFromString(string s, bool ignoreSerializationExceptions)
        {
            if (s == null || s.Length <= 0)
            {
                return null;
            }
            else
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(s)))
                    { 
                        object o = JsonSerializer.Deserialize(stream, typeof(object));
                        // Special case for string dictionary.
                        if (o is Hashtable)
                        {
                            Hashtable ht = o as Hashtable;

                            if (ht.ContainsKey(stringDictionaryKey))
                            {
                                ht.Remove(stringDictionaryKey);

                                StringDictionary dic =
                                    new StringDictionary();

                                foreach (string key in ht.Keys)
                                {
                                    object ob = ht[key];

                                    if (ob == null)
                                    {
                                        dic[key] = null;
                                    }
                                    else
                                    {
                                        dic[key] = ob.ToString();
                                    }
                                }

                                return dic;
                            }
                            else
                            {
                                return o;
                            }
                        }
                        else
                        {
                            return o;
                        }
                    }
                }
                catch (FormatException x)
                {
                    if (ignoreSerializationExceptions)
                    {
                        // Can happen due to legacy issues.
                        // Ignore, but log for statistics.
                        Log.W(
                            string.Format(
                            @"FormatException while deserializing from " +
                            @"string with {0} characters length ('{1}'). " +
                            @"Returning NULL.",
                            s.Length,
                            s), x);

                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (SerializationException x)
                {
                    if (ignoreSerializationExceptions)
                    {
                        // Can happen due to legacy issues.
                        // Ignore, but log for statistics.
                        Log.W(
                            string.Format(
                            @"SerializationException while deserializing " +
                            @"from string with {0} characters length ('{1}'). " +
                            @"Returning NULL.",
                            s.Length,
                            s), x);

                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
