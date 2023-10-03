using GraphMLReader;
using GraphMLReaderWriterExample.Models;
using GraphMLWriter;

namespace GraphMLReaderWriterExample
{
    internal static class Program
    {
        #region Private Fields

        private const string ExampleFileName = "Example.graphml";

        #endregion Private Fields

        #region Internal Methods

        internal static void Main()
        {
            var graph = GetGraph();

            var path = Path.Combine(
                path1: Environment.CurrentDirectory,
                path2: ExampleFileName);

            Console.WriteLine(
                value: $"The graphML file is written to {path}");

            WriteGraph(
                graph: graph,
                path: path);

            var result = ReadGraph(
                path: path);

            Console.WriteLine(
                value: $"The graphML file is read from {path}");

            var nodes = string.Join(',', result.Nodes.Select(n => n.Name));

            Console.WriteLine(
                value: $"The graph contains the following nodes: {nodes}");

            var edges = string.Join(',', result.Edges.Select(e => $"{e.From.Name}->{e.To.Name}"));

            Console.WriteLine(
                value: $"The graph contains the following edges: {edges}");
        }

        #endregion Internal Methods

        #region Private Methods

        private static Graph GetGraph()
        {
            var nodeA = new Node
            {
                Name = "a",
            };

            var nodeB = new Node
            {
                Name = "b",
            };

            var nodeC = new Node
            {
                Name = "c",
            };

            var edgeAB = new Edge
            {
                From = nodeA,
                To = nodeB,
            };

            var edgeAC = new Edge
            {
                From = nodeA,
                To = nodeC,
            };

            var graph = new Graph
            {
                Edges = new Edge[] { edgeAB, edgeAC },
                Nodes = new Node[] { nodeA, nodeB, nodeC },
            };

            return graph;
        }

        private static Graph ReadGraph(string path)
        {
            var reader = new Reader<Graph>();

            var graph = reader.Load(
                path: path);

            return graph;
        }

        private static void WriteGraph(Graph graph, string path)
        {
            var writer = new Writer<Graph>();

            writer.Save(
                input: graph,
                path: path);
        }

        #endregion Private Methods
    }
}