using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ApiSchema
{
    public class Helpers
    {
        public static ApiObject DeserializeObject(byte[] binaryData)
        {
            ApiObject result = null;

            using (var ms = new MemoryStream(binaryData))
            {
                var form = new BinaryFormatter();
                result = (ApiObject)form.Deserialize(ms);
            }

            return result;
        }

        public static byte[] SerializeObject<T>(T sourceObject) where T : ApiSchema.ApiObject
        {
            byte[] result = null;

            using (var ms = new MemoryStream())
            {
                var form = new BinaryFormatter();
                form.Serialize(ms, sourceObject);
                ms.Position = 0;
                result = ms.ToArray();
            }

            return result;
        }
    }
}
