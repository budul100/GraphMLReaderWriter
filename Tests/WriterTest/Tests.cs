using GraphMLRW;
using GraphMLWriterTest.Models;
using NUnit.Framework;
using System.IO;

namespace GraphMLWriterTest
{
    public class Tests
    {
        #region Public Methods

        [Test]
        public void TestWriter()
        {
            var input = GetNetwork();

            var writer = new Writer<Network>();

            var path = Path.GetTempFileName();

            writer.Save(
                input: input,
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

            var area = new Area("BC")
            {
                Points = new Point[] { pointB, pointC }
            };

            var locations = new Location[] { pointA, area };

            var linkAB = new Link(pointA, pointB);
            var linkAC = new Link(pointA, pointC);
            var linkBC = new Link(pointC, pointB);

            var links = new Link[] { linkAB, linkAC, linkBC };

            return new Network
            {
                Links = links,
                Locations = locations,
            };
        }

        #endregion Private Methods
    }
}