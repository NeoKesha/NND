using System;
using System.IO;
using NND.Model;
using NND.Serialize;
using NUnit.Framework;

namespace NndTests.SerializeTests
{
    [TestFixture]
    internal class DeserializerTests
    {
        [Test]
        public void DeserializeEmptyModelTest()
        {
            var modelExpected = new StaticModel();
	    var layerNodesExpected = modelExpected.GetLayersNode();
            var serializer = new Serializer(modelExpected);
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            serializer.Serialize(streamWriter);
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var deserialiser = new Deserializer();
	    var modelActual = new StaticModel();
	    deserializer.Deserialize(new StreamReader(memoryStream), modelActual);
	    var layerNodesActual = modelActual.GetLayersNode();
	    Assert.IsNotNull(layerNodesActual);
	    Assert.AreEqual(layerNodesExpected.Length, layerNodesActual.Length);
        }

        [Test]
        public void DeserializeNotEmptyModelTest()
        {
            var modelExpected = new StaticModel();
	    var layerNodesExpected = modelExpected.GetLayersNode();
            modelExpected.AddNode(new LayerType("Reshape", "Core",
                new[]
                {
                    new Parameter("target_shape", "Tuple", "1", Array.Empty<string>()),
                }
            ));
            var serializer = new Serializer(modelExpected);
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            serializer.Serialize(streamWriter);
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var deserialiser = new Deserializer();
	    var modelActual = new StaticModel();
	    deserializer.Deserialize(new StreamReader(memoryStream), modelActual);
	    var layerNodesActual = modelActual.GetLayersNode();
	    Assert.IsNotNull(layerNodesActual);
	    Assert.AreEqual(layerNodesExpected.Length, layerNodesActual.Length);
	    CollectionAssert.AreEqual(layerNodesExpected, layerNodesActual);
        }
    }
}