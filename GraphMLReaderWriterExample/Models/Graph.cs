namespace GraphMLReaderWriterExample.Models
{
    internal class Graph
    {
        #region Public Properties

        [GraphMLReaderWriter.Attributes.Edges]
        public Edge[] Edges { get; set; }

        [GraphMLReaderWriter.Attributes.Nodes]
        public Node[] Nodes { get; set; }

        #endregion Public Properties
    }
}