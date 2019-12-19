using System.Collections.Generic;
using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize
{
    public class Config
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "layers")]

        public List<SerialLayer> Layers { get; }

        public Config(IModel staticModel)
        {
            Name = "sequential_1";
            Layers = new List<SerialLayer>();
            var nodes = staticModel.GetLayerNodes();
            foreach (var node in nodes)
            {
                var layer = new SerialLayer(node);
                if (layer.ClassName != "Input")
                {
                    Layers.Add(layer);
                }
            }
        }

        public Config()
        {
            Name = "";
            Layers = null;
        }
    }
}