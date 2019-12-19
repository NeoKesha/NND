using System.Collections.Generic;
using GuardUtils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize
{
    public class Config
    {
        [JsonProperty(PropertyName = "name")] [NotNull] public string Name { get; set; }

        [JsonProperty(PropertyName = "layers")]

        public List<SerialLayer> Layers { get; }

        public Config([NotNull] IModel staticModel)
        {
            ThrowIf.Variable.IsNull(staticModel, nameof(staticModel));

            Name = "sequential_1";
            Layers = new List<SerialLayer>();
            var nodes = staticModel.GetLayerNodes();
            ThrowIf.Variable.IsNull(nodes, nameof(nodes));

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