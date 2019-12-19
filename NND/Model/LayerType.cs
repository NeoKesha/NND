using System.Collections.Generic;
using JetBrains.Annotations;

namespace NND.Model
{
    public class LayerType
    {
        private static int _layers;

        public int LayerId { get; }

        [NotNull] public string LayerName { get; }

        [NotNull] public string CategoryName { get; }

        [NotNull] [ItemNotNull] public List<Parameter> Parameters { get; }

        public LayerType([NotNull] string layerName, [NotNull] string categoryName,
            [NotNull] [ItemNotNull] Parameter[] parameters)
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