using System.Collections.Generic;

namespace NND.Model
{
    public class Parameter
    {
        public string Name { get; }

        public string Type { get; }

        public string DefaultValue { get; }

        private readonly List<string> _options;

        public Parameter(string name, string type, string[] options)
        {
            Name = name;
            Type = type;
            _options = new List<string>(options);
            DefaultValue = "";
        }

        public Parameter(string name, string type, string defaultVal, string[] options) : this(name, type, options)
        {
            DefaultValue = defaultVal;
        }

        public string[] GetOptions()
        {
            return _options.ToArray();
        }
    }
}