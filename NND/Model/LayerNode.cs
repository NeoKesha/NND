using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model 
{
    public class LayerNode 
    {
        static UInt32 count = 0;

        public LayerType Base { get; private set; }

        public Dictionary<string, string> values;

        public UInt32 Id { get; private set; }

        public LayerNode(LayerType type) 
        {
            Base = type;
            values = new Dictionary<string, string>();
            Id = ++count;
            foreach (var p in type.Parameters) 
            {
                values.Add(p.Name, p.DefaultValue);
            }
        }

        public override string ToString()
        {
            return $"{Id}: {Base.LayerName}";
        }
    }
}
