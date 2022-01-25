#pragma warning disable CA1819 // Eigenschaften dürfen keine Arrays zurückgeben

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

#pragma warning restore CA1819 // Eigenschaften dürfen keine Arrays zurückgeben