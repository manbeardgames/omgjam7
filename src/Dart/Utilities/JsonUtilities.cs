using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public static class JsonUtilities
    {
        /// <summary>
        ///     Given a UTF-8 encoded json string, returns the JSON as an instance
        ///     of <typeparamref name="TObject"/>.
        /// </summary>
        /// <typeparam name="TObject">
        ///     The object type represented by the JSON string.
        /// </typeparam>
        /// <param name="json">
        ///     The JSON string to deserialize
        /// </param>
        /// <returns>
        ///     An instance <typeparamref name="TObject"/>.
        /// </returns>
        public static TObject ReadToObject<TObject>(string json) where TObject: class
        {
            return ReadToObject<TObject>(json, Encoding.UTF8);
        }

        /// <summary>
        ///     Given a json string and encoding type, returns the JSON as an instance
        ///     of <typeparamref name="TObject"/>.
        /// </summary>
        /// <typeparam name="TObject">
        ///     The object type represented by the JSON string.
        /// </typeparam>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <param name="encoding">
        ///     The type of encoding used by the string.
        /// </param>
        /// <returns></returns>
        public static TObject ReadToObject<TObject>(string json, Encoding encoding) where TObject : class
        {
            TObject obj = default(TObject);

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TObject));
                obj = serializer.ReadObject(memoryStream) as TObject;
            }

            return obj;
        }
    }
}
