using GraphMLRW.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Network
    {
        #region Public Properties

        [Edge()]
        public Link[] Links { get; set; }

        [Node()]
        public Location[] Locations { get; set; }

        #endregion Public Properties
    }
}