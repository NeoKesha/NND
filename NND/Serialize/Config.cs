using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize
{
    public class Config
    {
        [JsonProperty(PropertyName = "name")]

        public String Name { get; set; }

        [JsonProperty(PropertyName = "layers")]

        public List<SerialLayer> Layers { get; set; }

        public Config(IModel staticModel)
        {
            Name = "sequential_1";
            Layers = new List<SerialLayer>();
            var Nodes = staticModel.GetLayerNodes();
            foreach (var node in Nodes)
            {
                SerialLayer layer = new SerialLayer(node);
                if (layer.ClassName != "Input")
                {
                    Layers.Add(layer);
                }
            }
        }
        public Config() {
            Name = "";
            Layers = null;
        }
    }
}
