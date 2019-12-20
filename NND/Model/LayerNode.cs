using System.Collections.Generic;
using GuardUtils;
using JetBrains.Annotations;

namespace NND.Model
{
    public class LayerNode
    {

        [NotNull] public LayerType Base { get; }

        [NotNull] public Dictionary<string, string> Values { get; }

        public LayerNode([NotNull] LayerType type)
        {
            ThrowIf.Variable.IsNull(type, nameof(type));

            Base = type;
            Values = new Dictionary<string, string>();
            foreach (var p in type.Parameters)
            {
                Values.Add(p.Name, p.DefaultValue);
            }
        }

        public override string ToString()
        {
            return $" {Base.LayerName}";
        }
    }
}