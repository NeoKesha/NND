using System.IO;
using GuardUtils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NND.Model;

namespace NND.Serialize
{
    public class Serializer
    {
        [JsonProperty(PropertyName = "class_name")]
        [NotNull]
        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "config")]

        public Config Config { get; set; }

        [JsonProperty(PropertyName = "keras_version")]
        [NotNull]
        public string KerasVersion { get; set; }

        [JsonProperty(PropertyName = "backend")]
        [NotNull]
        public string Backend { get; set; }

        public Serializer([NotNull] IModel staticModel)
        {
            ThrowIf.Variable.IsNull(staticModel, nameof(staticModel));

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

        public void Serialize([NotNull] StreamWriter writer)
        {
            ThrowIf.Variable.IsNull(writer, nameof(writer));

            writer.Write(JsonConvert.SerializeObject(this));
        }
    }
}