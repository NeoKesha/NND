using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model
{
    public class Parameter
    {
        public String Name { get; private set; }
        
        public String Type { get; private set; }
        
        public String DefaultValue { get; private set; }
        
        private List<String> options;
        
        public Parameter(String name, String type, string[] options)
        {
            Name = name;
            Type = type;
            this.options = new List<string>(options);
            DefaultValue = "";
        }
        
        public Parameter(String name, String type, String defaultVal, string[] options) : this(name, type, options)
        {
            DefaultValue = defaultVal;
        }
        
        public string[] GetOptions() { return options.ToArray(); }
    }
}
