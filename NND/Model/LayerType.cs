using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model 
{
    public class LayerType 
    {
        static int Layers = 0;

        public int LayerID { get; private set; }

        public string LayerName { get; private set; }

        public string CategoryName { get; private set; }

        public List<Parameter> Parameters {get; private set; }

        public LayerType(string layerName, string categoryName, Parameter[] parameters)
        {
            LayerID = ++Layers;
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
