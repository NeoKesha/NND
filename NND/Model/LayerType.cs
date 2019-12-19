using System.Collections.Generic;

namespace NND.Model
{
    public class LayerType
    {
        private static int _layers;

        public int LayerId { get; }

        public string LayerName { get; }

        public string CategoryName { get; }

        public List<Parameter> Parameters { get; }

        public LayerType(string layerName, string categoryName, Parameter[] parameters)
        {
            LayerId = ++_layers;
            LayerName = layerName;
            CategoryName = categoryName;
            Parameters = new List<Parameter>(parameters);
        }

        public override string ToString()
        {
            return LayerName;
        }
    }
}