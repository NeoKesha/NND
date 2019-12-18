using System;
using System.Linq;
using NND.Model;
using NUnit.Framework;

namespace NndTests.ModelTests
{
    [TestFixture]
    internal class ModelTests
    {
        [Test]
        public void AddNodeTest()
        {
            var model = new Model();

            Assert.NotNull(model.GetLayerNodes());
            Assert.That(model.GetLayerNodes()?.Length == 0);

            var layerType = new LayerType("Dropout", "Core",
                new[]
                {
                    new Parameter("rate", "Float", "1.0", Array.Empty<string>())
                }
            );
            model.AddNode(layerType);

            Assert.That(model.GetLayerNodes()?.Length == 1);
        }

        [Test]
        public void AddNodeWithIndexTest()
        {
            var model = new Model();

            Assert.NotNull(model.GetLayerNodes());
            Assert.That(model.GetLayerNodes()?.Length == 0);

            var layerType = new LayerType("Dropout", "Core",
                new[]
                {
                    new Parameter("rate", "Float", "1.0", Array.Empty<string>())
                }
            );
            model.AddNode(layerType);
            var firstNode = model.GetLayerNodes()?.First();

            Assert.AreEqual(firstNode, model.GetLayerNodes()?[0]);

            model.AddNode(layerType, 0);

            Assert.AreEqual(firstNode, model.GetLayerNodes()?[1]);
        }

        [Test]
        public void RemoveNodeTest()
        {
            var model = new Model();

            Assert.NotNull(model.GetLayerNodes());
            Assert.That(model.GetLayerNodes()?.Length == 0);

            var layerType = new LayerType("Dropout", "Core",
                new[]
                {
                    new Parameter("rate", "Float", "1.0", Array.Empty<string>())
                }
            );
            model.AddNode(layerType);

            Assert.That(model.GetLayerNodes()?.Length == 1);

            model.RemoveNode(0);

            Assert.That(model.GetLayerNodes()?.Length == 0);
        }

        [Test]
        public void MoveNodeTest()
        {
            var model = new Model();

            Assert.NotNull(model.GetLayerNodes());
            Assert.That(model.GetLayerNodes()?.Length == 0);

            var layerType = new LayerType("Dropout", "Core",
                new[]
                {
                    new Parameter("rate", "Float", "1.0", Array.Empty<string>())
                }
            );
            model.AddNode(layerType);
            var firstNode = model.GetLayerNodes()?.First();

            Assert.AreEqual(firstNode, model.GetLayerNodes()?[0]);

            model.AddNode(layerType);
            model.MoveNode(1, 0);

            Assert.AreEqual(firstNode, model.GetLayerNodes()?[1]);

            model.MoveNode(0, 1);

            Assert.AreEqual(firstNode, model.GetLayerNodes()?[0]);
        }

    }
}