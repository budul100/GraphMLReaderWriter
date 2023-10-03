namespace GraphMLReaderWriterExample.Models
{
    internal class Node
    {
        #region Public Properties

        [GraphMLReaderWriter.Attributes.Id]
        [GraphMLReaderWriter.Attributes.Data]
        public string Name { get; set; }

        #endregion Public Properties
    }
}