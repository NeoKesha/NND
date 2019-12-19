using System.Collections.Generic;

namespace NND.Model
{
    public class LayerNode
    {
        private static uint _count;

        public LayerType Base { get; }

        public Dictionary<string, string> Values { get; }

        public uint Id { get; }

        public LayerNode(LayerType type)
        {
            Base = type;
            Values = new Dictionary<string, string>();
            Id = ++_count;
            foreach (var p in type.Parameters)
            {
                Values.Add(p.Name, p.DefaultValue);
            }
        }

        public override string ToString()
        {
            return $"{Id}: {Base.LayerName}";
        }
    }
}