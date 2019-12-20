using System;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace NND.Model
{
    public class StaticModel : IModel
    {
        [NotNull] private readonly ObservableCollection<LayerType> _layerTypes;
        [NotNull] private readonly ObservableCollection<LayerNode> _layerNodes;

        public string BatchSize { get; set; }
        public string DataType { get; set; }

        public StaticModel()
        {
            BatchSize = "1";
            DataType = "float32";
            _layerNodes = new ObservableCollection<LayerNode>();
            _layerTypes = new ObservableCollection<LayerType>
            {
                new LayerType("Reshape", "Core",
                    new[] {new Parameter("target_shape", "Tuple", "1", Array.Empty<string>())}
                ),
                new LayerType("RepeatVector", "Core",
                    new[] {new Parameter("n", "Int", "1", Array.Empty<string>())}
                ),
                new LayerType("Dense", "Core",
                    new[]
                    {
                        new Parameter("units", "Int", "1", Array.Empty<string>()), new Parameter("activation", "String",
                            "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("Dropout", "Core",
                    new[] {new Parameter("rate", "Float", "1.0", Array.Empty<string>())}
                ),
                new LayerType("Conv1D", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid", "casual"}),
                        new Parameter("activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("Conv2D", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("SeparableConv1D", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"}),
                        new Parameter("depth_multiplier", "Int", "1", Array.Empty<string>())
                    }
                ),
                new LayerType("SeparableConv2D", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"}),
                        new Parameter("depth_multiplier", "Int", "1", Array.Empty<string>())
                    }
                ),
                new LayerType("Conv2DTranspose", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("Conv3D", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("Conv3DTranspose", "Convolutional",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"}), new Parameter(
                            "activation", "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("Cropping1D", "Convolutional",
                    new[] {new Parameter("cropping", "Tuple", "0, 0", Array.Empty<string>())}
                ),
                new LayerType("Cropping2D", "Convolutional",
                    new[] {new Parameter("cropping", "Tuple", "0, 0, 0, 0", Array.Empty<string>())}
                ),
                new LayerType("Cropping3D", "Convolutional",
                    new[] {new Parameter("cropping", "Tuple", "0, 0, 0, 0, 0, 0", Array.Empty<string>())}
                ),
                new LayerType("UpSampling1D", "Convolutional",
                    new[] {new Parameter("size", "Int", "1", Array.Empty<string>())}
                ),
                new LayerType("UpSampling2D", "Convolutional",
                    new[] {new Parameter("size", "Tuple", "1,1", Array.Empty<string>())}
                ),
                new LayerType("UpSampling3D", "Convolutional",
                    new[] {new Parameter("size", "Tuple", "1,1,1", Array.Empty<string>())}
                ),
                new LayerType("MaxPooling1D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Int", "2", Array.Empty<string>()),
                        new Parameter("strides", "Int", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("MaxPooling2D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Tuple", "2,2", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1, 1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("MaxPooling3D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Tuple", "2,2,2", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1, 1, 1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("AveragePooling1D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Int", "2", Array.Empty<string>()),
                        new Parameter("strides", "Int", "1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("AveragePooling2D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Tuple", "2,2", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1, 1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("AveragePooling3D", "Pooling",
                    new[]
                    {
                        new Parameter("pool_size", "Tuple", "2,2,2", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1, 1, 1", Array.Empty<string>()),
                        new Parameter("padding", "String", "same", new[] {"same", "valid"})
                    }
                ),
                new LayerType("GlobalMaxPooling1D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("GlobalAveragePooling1D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("GlobalMaxPooling2D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("GlobalAveragePooling2D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("GlobalMaxPooling3D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("GlobalAveragePooling3D", "Pooling",
                    Array.Empty<Parameter>()
                ),
                new LayerType("LocallyConnected1D", "LocallyConnected",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1", Array.Empty<string>()), new Parameter("activation",
                            "String",
                            "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("LocallyConnected2D", "LocallyConnected",
                    new[]
                    {
                        new Parameter("filters", "Int", "1", Array.Empty<string>()),
                        new Parameter("kernel_size", "Tuple", "1,1", Array.Empty<string>()),
                        new Parameter("strides", "Tuple", "1,1", Array.Empty<string>()), new Parameter("activation",
                            "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("BatchNormalization", "Normalization",
                    new[]
                    {
                        new Parameter("axis", "Int", "1", Array.Empty<string>()),
                        new Parameter("momentum", "Float", "0.99", Array.Empty<string>()),
                        new Parameter("epsilon", "Float", "0.01", Array.Empty<string>()), new Parameter("activation",
                            "String", "relu",
                            new[] {"relu", "tanh", "sigmoid", "exponential", "linear"})
                    }
                ),
                new LayerType("GaussianNoise", "Noise",
                    new[] {new Parameter("stddev", "Float", "1.0", Array.Empty<string>())}
                ),
                new LayerType("GaussianDropout", "Noise",
                    new[] {new Parameter("rate", "Float", "0.8", Array.Empty<string>())}
                ),
                new LayerType("AlphaDropout", "Noise",
                    new[]
                    {
                        new Parameter("rate", "Float", "0.8", Array.Empty<string>()),
                        new Parameter("noise_shape", "Tuple", "1", Array.Empty<string>())
                    }
                )
            };
        }

        [NotNull]
        public LayerType[] GetLayerTypes()
        {
            return _layerTypes.ToArray();
        }

        [NotNull]
        public LayerNode[] GetLayerNodes()
        {
            return _layerNodes.ToArray();
        }

        public void AddNode(LayerType baseType)
        {
            _layerNodes.Add(new LayerNode(baseType));
        }

        public void AddNode(LayerType baseType, int position)
        {
            _layerNodes.Insert(position, new LayerNode(baseType));
        }

        public void RemoveNode(int position)
        {
            _layerNodes.RemoveAt(position);
        }

        public void MoveNode(int src, int dest)
        {
            _layerNodes.Insert(dest, _layerNodes[src]);
            _layerNodes.RemoveAt((src > dest) ? (src + 1) : src);
        }

        public string GetDType() {
            return DataType;
        }
        public string GetBSize() {
            return BatchSize;
        }

        [NotNull]
        public ObservableCollection<LayerType> GetLayerTypesLink()
        {
            return _layerTypes;
        }

        [NotNull]
        public ObservableCollection<LayerNode> GetLayerNodesLink()
        {
            return _layerNodes;
        }
    }
}