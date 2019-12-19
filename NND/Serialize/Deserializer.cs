using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NND.Model;

namespace NND.Serialize
{
    public class Deserializer
    {
        public void Deserialize(System.IO.StreamReader reader, StaticModel staticModel)
        {
            var serializer = JsonConvert.DeserializeObject<Serializer>(reader.ReadToEnd());
            var types = staticModel.GetLayerTypesLink();
            staticModel.GetLayerNodesLink().Clear();
            var batch_size = "";
            var dtype = "";
            var has_input = false;
            foreach (var layer in serializer.Config.Layers)
            {
                staticModel.AddNode(types.FirstOrDefault(t => t.LayerName == layer.ClassName));
                var node = staticModel.GetLayerNodesLink().Last();
                foreach (var param in layer.Config)
                {
                    string str;
                    if (param.Value is JArray arr)
                    {
                        str = arr.ToString().Replace("[", "").Replace("]", "").Replace("\n", "").Replace("\r", "");
                    }
                    else
                    {
                        str = param.Value.ToString();
                    }

                    switch (param.Key)
                    {
                        case "batch_input_shape":
                            batch_size = str;
                            break;
                        case "dtype":
                            dtype = str;
                            break;
                        default:
                            node.Values[param.Key] = str;
                            break;
                    }

                    if (string.IsNullOrEmpty(dtype) || string.IsNullOrEmpty(batch_size) || has_input)
                    {
                        continue;
                    }

                    staticModel.AddNode(types.FirstOrDefault(t => t.LayerName == "Input"), 0);
                    var input = staticModel.GetLayerNodesLink().First();
                    input.Values["dtype"] = dtype;
                    input.Values["batch_input_shape"] = batch_size;
                    has_input = true;
                }
            }
        }
    }
}