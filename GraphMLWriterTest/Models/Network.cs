#pragma warning disable CA1819 // Eigenschaften dürfen keine Arrays zurückgeben

using GraphMLWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Network
    {
        #region Public Properties

        public Area[] Areas { get; set; }

        [EdgeAttribute()]
        public Link[] Links { get; set; }

        [NodeAttribute()]
        public Point[] Points { get; set; }

        #endregion Public Properties
    }
}

#pragma warning restore CA1819 // Eigenschaften dürfen keine Arrays zurückgeben