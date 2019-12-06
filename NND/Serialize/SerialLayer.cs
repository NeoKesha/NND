using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NND.Serialize
{
    public class SerialLayer {
        [JsonProperty(PropertyName = "class_name")]
        public String ClassName { get; set; }
        [JsonProperty(PropertyName = "config")]
        public Dictionary<String, Object> Config { get; set; }
        public SerialLayer(Model.LayerNode node) {
            ClassName = node.Base.LayerName;
            Config = null;
        }
    }
}
