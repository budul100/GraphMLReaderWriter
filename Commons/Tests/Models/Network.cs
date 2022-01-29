using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Network
    {
        #region Public Properties

        [Edges()]
        public Link[] Links { get; set; }

        [Nodes()]
        public Location[] Locations { get; set; }

        #endregion Public Properties
    }
}