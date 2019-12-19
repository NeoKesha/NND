using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NND.Serialize {
    public class Deserializer {
        public void Deserialize(System.IO.StreamReader reader, Model.Model model) {
            Serializer serializer = JsonConvert.DeserializeObject<Serializer>(reader.ReadToEnd());
            var types = model.GetLayerTypesLink();
            model.GetLayerNodesLink().Clear();
            string batch_size = "";
            string dtype = "";
            bool has_input = false;
            foreach (var layer in serializer.Config.Layers) {
                model.AddNode(types.Where(t => t.LayerName == layer.ClassName).FirstOrDefault());
                var node = model.GetLayerNodesLink().Last();
                foreach (var param in layer.Config) {
                    string str = "";
                    if (param.Value is Newtonsoft.Json.Linq.JArray) {
                        Newtonsoft.Json.Linq.JArray arr = (Newtonsoft.Json.Linq.JArray)param.Value;
                        str = arr.ToString().Replace("[","").Replace("]", "").Replace("\n", "").Replace("\r", "");
                    } else {
                        str = param.Value.ToString();
                    }
                    if (param.Key == "batch_input_shape") {
                        batch_size = str;
                    } else if (param.Key == "dtype") {
                        dtype = str;
                    } else {
                        node.values[param.Key] = str;
                    }
                    if (!String.IsNullOrEmpty(dtype) && !String.IsNullOrEmpty(batch_size) && !has_input) {
                        model.AddNode(types.Where(t => t.LayerName == "Input").FirstOrDefault(),0);
                        var input = model.GetLayerNodesLink().First();
                        input.values["dtype"] = dtype;
                        input.values["batch_input_shape"] = batch_size;
                        has_input = true;
                    }
                }
            }
        }
    }
}
