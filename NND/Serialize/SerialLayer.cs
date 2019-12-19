using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NND.Serialize
{
    public class SerialLayer
    {
        [JsonProperty(PropertyName = "class_name")]

        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "config")]

        public Dictionary<string, object> Config { get; }

        [NonSerialized] private static string _inputShape = "1";

        [NonSerialized] private static bool _setInput;

        [NonSerialized] private static string _dataType = "float32";

        public SerialLayer()
        {
            ClassName = "";
            Config = null;
        }

        public SerialLayer(Model.LayerNode node)
        {
            ClassName = node.Base.LayerName;
            Config = new Dictionary<string, object>();
            if (ClassName == "Input")
            {
                _dataType = node.Values["dtype"];
                _inputShape = node.Values["shape"];
                _setInput = true;
            }
            else
            {
                if (_setInput)
                {
                    var strings = _inputShape.Split(',');
                    var ints = new object[strings.Length + 1];
                    ints[0] = null;
                    for (var i = 1; i < strings.Length + 1; ++i)
                    {
                        ints[i] = Convert.ToInt32(strings[i - 1], System.Globalization.CultureInfo.InvariantCulture);
                    }

                    Config.Add("batch_input_shape", ints);
                    _setInput = false;
                }

                Config.Add("dtype", _dataType);
                foreach (var value in node.Base.Parameters)
                {
                    var paramKey = value.Name;
                    var paramValue = node.Values[paramKey];
                    switch (value.Type.ToUpperInvariant())
                    {
                        case "string":
                            Config.Add(paramKey, paramValue);
                            break;
                        case "float":
                            Config.Add(paramKey,
                                Convert.ToSingle(paramValue, System.Globalization.CultureInfo.InvariantCulture));
                            break;
                        case "int":
                            Config.Add(paramKey,
                                Convert.ToInt32(paramValue, System.Globalization.CultureInfo.InvariantCulture));
                            break;
                        case "tuple":
                            var strings = paramValue.Split(',');
                            var ints = new int[strings.Length];
                            for (var i = 0; i < strings.Length; ++i)
                            {
                                ints[i] = Convert.ToInt32(strings[i],
                                    System.Globalization.CultureInfo.InvariantCulture);
                            }

                            Config.Add(paramKey, ints);
                            break;
                    }
                }
            }
        }
    }
}