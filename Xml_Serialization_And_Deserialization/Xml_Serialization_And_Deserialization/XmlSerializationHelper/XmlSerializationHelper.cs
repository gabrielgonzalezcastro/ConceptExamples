using System.IO;
using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.XmlSerializationHelper
{
    public static class XmlSerializationHelper
    {
        public static string Serialize<T>(T data) where T : class
        {
            var serializer = new DataContractSerializer(typeof (T));
            var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, data);
            memoryStream.Position = 0;
            string result;
            using (var reader = new StreamReader(memoryStream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static T Deserialize<T>(string data) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T));
            var memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data));
            var result = serializer.ReadObject(memoryStream) as T;
            return result;
        }
    }
}