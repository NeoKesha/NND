using System.Collections.Generic;
using GuardUtils;
using JetBrains.Annotations;

namespace NND.Model
{
    public class Parameter
    {
        [NotNull] public string Name { get; }

        [NotNull] public string Type { get; }

        [NotNull] public string DefaultValue { get; }

        [NotNull] [ItemNotNull] private readonly List<string> _options;

        public Parameter([NotNull] string name, [NotNull] string type, [NotNull] [ItemNotNull] string[] options)
        {
            ThrowIf.Variable.IsNull(name, nameof(name));
            ThrowIf.Variable.IsNull(type, nameof(type));
            ThrowIf.Variable.IsNull(options, nameof(options));

            Name = name;
            Type = type;
            _options = new List<string>(options);
            DefaultValue = "";
        }

        public Parameter([NotNull] string name, [NotNull] string type, [NotNull] string defaultVal,
            [NotNull] string[] options) : this(name, type, options)
        {
            ThrowIf.Variable.IsNull(defaultVal, nameof(defaultVal));

            DefaultValue = defaultVal;
        }

        public string[] GetOptions()
        {
            return _options.ToArray();
        }
    }
}