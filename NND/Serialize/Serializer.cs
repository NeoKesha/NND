using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize
{
    public class Serializer
    {
        [JsonProperty(PropertyName = "class_name")]

        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "config")]

        public Config Config { get; set; }

        [JsonProperty(PropertyName = "keras_version")]

        public string KerasVersion { get; set; }

        [JsonProperty(PropertyName = "backend")]

        public string Backend { get; set; }

        public Serializer(IModel staticModel)
        {
            ClassName = "sequential";
            Config = new Config(staticModel);
            KerasVersion = "2.2.5";
            Backend = "tensorflow";
        }

        public Serializer()
        {
            ClassName = "";
            Config = null;
            KerasVersion = "";
            Backend = "";
        }

        public void Serialize(System.IO.StreamWriter writer)
        {
            writer?.Write(JsonConvert.SerializeObject(this));
        }
    }
}