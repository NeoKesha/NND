using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model
{

    public class Model : IModel
    {

        ObservableCollection<LayerType> LayerTypes;
        ObservableCollection<LayerNode> LayerNodes;

        public Model()
        {
            LayerNodes = new ObservableCollection<LayerNode>();
            LayerTypes = new ObservableCollection<LayerType>();
            LayerTypes.Add(new LayerType("Input", "Core",
                new Parameter[]{    new Parameter("shape", "Tuple", "1", new string[]{ }),
                                    new Parameter("dtype", "String", "float32" , new string[] { "float32", "float64", "int32" })
                }
                ));
            LayerTypes.Add(new LayerType("Reshape", "Core",
                new Parameter[]{    new Parameter("target_shape", "Tuple", "1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("RepeatVector", "Core",
                new Parameter[]{    new Parameter("n", "Int", "1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("Dense", "Core",
                new Parameter[] {   new Parameter("units", "Int", "1", new string[]{ }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Dropout", "Core",
                new Parameter[]{    new Parameter("rate", "Float", "1.0", new string[]{ })
                }
                ));
            LayerTypes.Add(new LayerType("Conv1D", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Int", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid", "casual" })
                }
                ));
        }

        public LayerType[] GetLayerTypes() { return LayerTypes.ToArray(); }

        public LayerNode[] GetLayerNodes() { return LayerNodes.ToArray(); }

        public void AddNode(LayerType baseType)
        {
            LayerNodes.Add(new LayerNode(baseType));
        }

        public void AddNode(LayerType baseType, Int32 position)
        {
            LayerNodes.Insert(position, new LayerNode(baseType));
        }

        public void RemoveNode(Int32 position)
        {
            LayerNodes.RemoveAt(position);
        }

        public void MoveNode(Int32 from, Int32 to)
        {
            LayerNodes.Insert(to, LayerNodes[from]);
            LayerNodes.RemoveAt((from > to) ? (from + 1) : from);
        }

        public ObservableCollection<LayerType> GetLayerTypesLink() { return LayerTypes; }
        public ObservableCollection<LayerNode> GetLayerNodesLink() { return LayerNodes; }
    }
}
