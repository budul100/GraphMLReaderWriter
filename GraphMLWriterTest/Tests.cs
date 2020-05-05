using GraphMLWriter;
using GraphMLWriterTest.Models;
using NUnit.Framework;
using System.IO;

namespace GraphMLWriterTest
{
    public class Tests
    {
        #region Public Methods

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWriter()
        {
            var test = GetNetwork();

            var writer = new Writer<Network>();
            var path = @".\..\..\..\test.graphml";

            if (File.Exists(path))
                File.Delete(path);

            writer.Save(
                input: test,
                path: path);

            Assert.IsTrue(File.Exists(path));
        }

        #endregion Public Methods

        #region Private Methods

        private static Network GetNetwork()
        {
            var pointA = new Point("A")
            {
                IsImportant = true
            };

            var pointB = new Point("B");
            var pointC = new Point("C");

            var linkAB = new Link(pointA, pointB);
            var linkAC = new Link(pointA, pointC);
            var linkBC = new Link(pointC, pointB);

            var points = new Point[] { pointA, pointB, pointC };
            var links = new Link[] { linkAB, linkAC, linkBC };

            return new Network
            {
                Links = links,
                Points = points,
            };
        }

        #endregion Private Methods
    }
}