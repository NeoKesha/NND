using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model {
    
    public class Model : IModel {
        List<LayerType> LayerTypes;
        public Model() {
            LayerTypes = new List<LayerType>();
            LayerTypes.Add(new LayerType("Input", "Core",
                new Parameter[]{    new Parameter("shape", "Tuple", new string[]{ }),
                                    new Parameter("dtype", "String" , new string[] { "float32", "float64", "int32" })
                }
                ));
            LayerTypes.Add(new LayerType("Reshape", "Core",
                new Parameter[]{    new Parameter("target_shape", "Tuple", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("RepeatVector", "Core",
                new Parameter[]{    new Parameter("n", "Int", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("Dense", "Core",
                new Parameter[] {   new Parameter("units", "Int", new string[]{ }),
                                    new Parameter("activation", "String" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Dropout", "Core",
                new Parameter[]{    new Parameter("rate", "Int", new string[]{ })
                }
                ));
        }

        public LayerType[] GetLayerTypes() { return LayerTypes.ToArray(); }
    }
}
