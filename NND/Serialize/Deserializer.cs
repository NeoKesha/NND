using System.IO;
using System.Linq;
using GuardUtils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NND.Model;

namespace NND.Serialize
{
    public class Deserializer
    {
        public void Deserialize([NotNull] StreamReader reader, [NotNull] StaticModel staticModel)
        {
            ThrowIf.Variable.IsNull(reader, nameof(reader));
            ThrowIf.Variable.IsNull(staticModel, nameof(staticModel));

            var serializer = JsonConvert.DeserializeObject<Serializer>(reader.ReadToEnd());

            ThrowIf.Variable.IsNull(serializer, nameof(serializer));
            ThrowIf.Variable.IsNull(serializer.Config, nameof(serializer.Config));
            ThrowIf.Variable.IsNull(serializer.Config.Layers, nameof(serializer.Config.Layers));

            var types = staticModel.GetLayerTypesLink();
            staticModel.GetLayerNodesLink().Clear();
            foreach (var layer in serializer.Config.Layers)
            {
                staticModel.AddNode(types.FirstOrDefault(t => t.LayerName == layer.ClassName));
                var node = staticModel.GetLayerNodesLink().Last();
                ThrowIf.Variable.IsNull(node, nameof(node));
                ThrowIf.Variable.IsNull(layer.Config, nameof(layer.Config));
                foreach (var param in layer.Config)
                {
                    string str;
                    if (param.Value is JArray arr)
                    {
                        str = arr.ToString().Replace("[", "").Replace("]", "").Replace("\n", "").Replace("\r", "");
                    }
                    else
                    {
                        ThrowIf.Variable.IsNull(param.Value, nameof(param.Value));
                        str = param.Value.ToString();
                    }

                    switch (param.Key)
                    {
                        case "batch_input_shape":
                            staticModel.BatchSize = str;
                            break;
                        case "dtype":
                            staticModel.DataType = str;
                            break;
                        default:
                            node.Values[param.Key] = str;
                            break;
                    }
                }
            }
        }
    }
}