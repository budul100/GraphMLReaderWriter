using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Network
    {
        #region Public Properties

        [Edges()]
        public Link[] Links { get; set; }

        [Nodes()]
        public Place[] Places { get; set; }

        #endregion Public Properties
    }
}