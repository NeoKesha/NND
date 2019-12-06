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
        [NonSerialized]
        static private string inputShape = "1";
        [NonSerialized]
        static private bool setInput = false;
        [NonSerialized]
        static private string dataType = "float32";
        public SerialLayer(Model.LayerNode node) {
            ClassName = node.Base.LayerName;
            Config = new Dictionary<string, object>();
            if (ClassName == "Input") {
                dataType = node.values["dtype"];
                inputShape = node.values["shape"];
                setInput = true;
            } else {
                if (setInput) {
                    string[] strs = inputShape.Split(',');
                    Object[] ints = new Object[strs.Length + 1];
                    ints[0] = null;
                    for (var i = 1; i < strs.Length + 1; ++i) {
                        ints[i] = Convert.ToInt32(strs[i-1]);
                    }
                    Config.Add("batch_input_shape", ints);
                    setInput = false;
                }
                Config.Add("dtype", dataType);
                foreach (var value in node.Base.Parameters) {
                    string param_key = value.Name;
                    string param_value = node.values[param_key];
                    switch (value.Type.ToLower()) {
                        case "string":
                            Config.Add(param_key, param_value);
                            break;
                        case "float":
                            Config.Add(param_key, Convert.ToSingle(param_value, System.Globalization.CultureInfo.InvariantCulture));
                            break;
                        case "int":
                            Config.Add(param_key, Convert.ToInt32(param_value));
                            break;
                        case "tuple":
                            string[] strs = param_value.Split(',');
                            int[] ints = new int[strs.Length];
                            for (var i = 0; i < strs.Length; ++i) {
                                ints[i] = Convert.ToInt32(strs[i]);
                            }
                            Config.Add(param_key, ints);
                            break;
                    }
                }
            }
        }
    }
}
