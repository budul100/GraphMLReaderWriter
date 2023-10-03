namespace GraphMLReaderWriterExample.Models
{
    internal class Edge
    {
        #region Public Properties

        [GraphMLReaderWriter.Attributes.Source]
        public Node From { get; set; }

        [GraphMLReaderWriter.Attributes.Target]
        public Node To { get; set; }

        #endregion Public Properties
    }
}