using GraphMLReader;
using GraphMLWriter;
using GraphMLWriterTest.Models;
using NUnit.Framework;
using System.IO;

namespace GraphMLWriterTest
{
    public class Tests
    {
        #region Public Methods

        [Test]
        public void ExportImportRoundtrip()
        {
            var path = Path.GetTempFileName();
            var input = GetNetwork();

            var writer = new Writer<Network>();
            writer.Save(
                input: input,
                path: path);

            Assert.IsTrue(File.Exists(path));

            var reader = new Reader<Network>();
            var output = reader.Load(path);

            Assert.True(output.Locations.Length == 2);
            Assert.True(output.Locations[1].Points[1].IsImportant);

            Assert.True(output.Links.Length == 3);
            Assert.True(output.Links[0].From == output.Locations[0]);
            Assert.True(output.Links[0].To == output.Locations[1].Points[0]);
            Assert.True(output.Links[1].From == output.Locations[0]);
            Assert.True(output.Links[1].To == output.Locations[1].Points[1]);
            Assert.True(output.Links[2].From == output.Locations[1].Points[1]);
            Assert.True(output.Links[2].To == output.Locations[1].Points[0]);
        }

        [Test]
        public void ImportyEd()
        {
            var path = @"..\..\..\Samples\Example_yEd.graphml";

            var reader = new Reader<Network>();
            var output = reader.Load(path);

            Assert.True(output.Locations.Length == 2);
            Assert.True(output.Locations[1].Points[1].IsImportant);

            Assert.True(output.Links.Length == 3);
            Assert.True(output.Links[0].From == output.Locations[0]);
            Assert.True(output.Links[0].To == output.Locations[1].Points[0]);
            Assert.True(output.Links[1].From == output.Locations[0]);
            Assert.True(output.Links[1].To == output.Locations[1].Points[1]);
            Assert.True(output.Links[2].From == output.Locations[1].Points[1]);
            Assert.True(output.Links[2].To == output.Locations[1].Points[0]);
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
            var pointC = new Point("C")
            {
                IsImportant = true
            };

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