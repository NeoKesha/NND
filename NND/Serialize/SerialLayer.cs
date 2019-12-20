using System;
using System.Collections.Generic;
using GuardUtils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize {
    public class SerialLayer {
        [JsonProperty(PropertyName = "class_name")]
        [NotNull]
        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "config")]

        public Dictionary<string, object> Config { get; }

        public SerialLayer() {
            ClassName = "";
            Config = new Dictionary<string, object>();
        }

        public SerialLayer([NotNull] LayerNode node, string DType, string BSize) : this(node, DType) {
            Config.Add("batch_input_shape", $"null, {BSize}");
        }

        public SerialLayer([NotNull] LayerNode node, string DType) {
            ThrowIf.Variable.IsNull(node, nameof(node));

            ClassName = node.Base.LayerName;
            Config = new Dictionary<string, object>();
            Config.Add("dtype", DType);
            foreach (var value in node.Base.Parameters) {
                var paramKey = value.Name;
                var paramValue = node.Values[paramKey];
                switch (value.Type.ToUpperInvariant()) {
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
                        ThrowIf.Variable.IsNull(paramValue, nameof(paramValue));

                        var strings = paramValue.Split(',');
                        var ints = new int[strings.Length];
                        for (var i = 0; i < strings.Length; ++i) {
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