using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class ConfigFile
    {
        public string DataManagerClient { get; set; }
        public string DataManagerServer { get; set; }
    }

    public class Config
    {
        public static ConfigFile Instance
        {
            get { return JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Config\\default.json")); }
        }
    }
}
