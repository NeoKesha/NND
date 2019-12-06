using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NND.Serialize {
    public class Config {
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "layers")]
        public SerialLayer[] Layers { get; set; }
        public Config(Model.Model model) {
            Name = "sequential_1";
            var Nodes = model.GetLayerNodes();
            Layers = new SerialLayer[Nodes.Length];
        }
    }
}
