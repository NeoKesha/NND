using System;
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
    }
}