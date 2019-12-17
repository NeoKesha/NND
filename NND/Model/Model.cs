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
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid", "casual" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Conv2D", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("SeparableConv1D", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" }),
                                    new Parameter("depth_multiplier", "Int", "1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("SeparableConv2D", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" }),
                                    new Parameter("depth_multiplier", "Int", "1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("Conv2DTranspose", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Conv3D", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Conv3DTranspose", "Convolutional",
                new Parameter[]{    new Parameter("filters", "Int", "1", new string[]{ }),
                                    new Parameter("kernel_size", "Tuple", "1", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" }),
                                    new Parameter("activation", "String", "relu" , new string[] { "relu", "tanh", "sigmoid",  "exponential", "linear" })
                }
                ));
            LayerTypes.Add(new LayerType("Cropping1D", "Convolutional",
                new Parameter[]{    new Parameter("cropping", "Tuple", "0, 0", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("Cropping2D", "Convolutional",
                new Parameter[]{    new Parameter("cropping", "Tuple", "0, 0, 0, 0", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("Cropping3D", "Convolutional",
                new Parameter[]{    new Parameter("cropping", "Tuple", "0, 0, 0, 0, 0, 0", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("UpSampling1D", "Convolutional",
                new Parameter[]{    new Parameter("size", "Int", "1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("UpSampling2D", "Convolutional",
                new Parameter[]{    new Parameter("size", "Tuple", "1,1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("UpSampling3D", "Convolutional",
                new Parameter[]{    new Parameter("size", "Tuple", "1,1,1", new string[]{ }),
                }
                ));
            LayerTypes.Add(new LayerType("MaxPooling1D", "Convolutional",
                new Parameter[]{    new Parameter("pool_size", "Int", "2", new string[]{ }),
                                    new Parameter("strides", "Int", "1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" })
                }
                ));
            LayerTypes.Add(new LayerType("MaxPooling2D", "Convolutional",
                new Parameter[]{    new Parameter("pool_size", "Tuple", "2,2", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1, 1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" })
                }
                ));
            LayerTypes.Add(new LayerType("MaxPooling3D", "Convolutional",
                new Parameter[]{    new Parameter("pool_size", "Tuple", "2,2,2", new string[]{ }),
                                    new Parameter("strides", "Tuple", "1, 1, 1", new string[]{ }),
                                    new Parameter("padding", "String", "same" , new string[] { "same", "valid" })
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
