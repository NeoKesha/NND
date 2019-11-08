using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model {
    public class Parameter {
        public String Name { get; private set; }
        public String Type { get; private set; }
        private List<String> options;
        public Parameter(String name, String type, string[] options) {
            Name = name;
            Type = type;
            this.options = new List<string>(options);
        }
        public string[] GetOptions() { return options.ToArray(); }
    }
}
