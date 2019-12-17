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
        public void SerializeTest()
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
    }
}