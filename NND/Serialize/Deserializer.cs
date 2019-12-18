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
        }
    }
}
