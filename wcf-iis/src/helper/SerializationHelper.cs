using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace wcf_iis.helper
{
    public class SerializationHelper
    {
        public static string Serialize<T>(T o)
        {
            if (o == null) return null;
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, o);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T> (string o)
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(o)))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}