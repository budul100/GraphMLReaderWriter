using GraphMLWriter;
using GraphMLWriterTest.Test;
using System;
using System.IO;

namespace GraphMLWriterTest
{
    internal class Program
    {
        #region Private Methods

        private static Network GetNetwork()
        {
            var pointA = new Point("A");
            pointA.IsImportant = true;
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

        private static void Main(string[] args)
        {
            var test = GetNetwork();

            var writer = new Writer<Network>();
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "test.graphml");

            writer.Save(
                input: test,
                path: path);
        }

        #endregion Private Methods
    }
}