using System;
using System.IO;
using NND.Model;
using NND.Serialize;
using NUnit.Framework;

namespace NndTests.SerializeTests
{
    [TestFixture]
    internal class SerializerTests
    {
        [Test]
        public void SerializeEmptyModelTest()
        {
            var model = new Model();
            var serializer = new Serializer(model);
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            serializer.Serialize(streamWriter);
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            const string expected =
                "{\"class_name\":\"sequential\",\"config\":{\"name\":\"sequential_1\",\"layers\":[]},\"keras_version\":\"2.2.5\",\"backend\":\"tensorflow\"}";
            string actual;
            using (var reader = new StreamReader(memoryStream))
            {
                actual = reader.ReadLine();
            }

            Assert.True(expected.Equals(actual, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void SerializeNotEmptyModelTest()
        {
            var model = new Model();
            model.AddNode(new LayerType("Input", "Core",
                new[]
                {
                    new Parameter("shape", "Tuple", "1", Array.Empty<string>()),
                    new Parameter("dtype", "String", "float32", new[] {"float32", "float64", "int32"})
                }
            ));
            model.AddNode(new LayerType("Reshape", "Core",
                new[]
                {
                    new Parameter("target_shape", "Tuple", "1", Array.Empty<string>()),
                }
            ));
            var serializer = new Serializer(model);
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            serializer.Serialize(streamWriter);
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            const string expected =
                "{\"class_name\":\"sequential\",\"config\":{\"name\":\"sequential_1\",\"layers\":[{\"class_name\":\"Reshape\",\"config\":{\"batch_input_shape\":[null,1],\"dtype\":\"float32\",\"target_shape\":[1]}}]},\"keras_version\":\"2.2.5\",\"backend\":\"tensorflow\"}";
            string actual;
            using (var reader = new StreamReader(memoryStream))
            {
                actual = reader.ReadLine();
            }

            Assert.True(expected.Equals(actual, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}