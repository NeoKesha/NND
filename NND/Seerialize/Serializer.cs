﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NND.Seerialize {
    public class Serializer {
        [JsonProperty(PropertyName = "class_name")]
        public String ClassName { get; set; }
        [JsonProperty(PropertyName = "config")]
        public Object[] Config { get; set; }
        [JsonProperty(PropertyName = "keras_version")]
        public String KerasVersion { get; set; }
        [JsonProperty(PropertyName = "backend")]
        public String Backend { get; set; }
        public Serializer(NND.Model.Model model) {
            ClassName = "sequential";
            Config = null;
            KerasVersion = "2.2.5";
            Backend = "tensorflow";
        }
        public void Serialize(System.IO.StreamWriter writer) {
            if (writer != null) {
                writer.Write(JsonConvert.SerializeObject(this));
            }
        }
    }
}
