using GraphMLWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Link
    {
        #region Public Constructors

        public Link(Point from, Point to)
        {
            From = from;
            To = to;
        }

        #endregion Public Constructors

        #region Public Properties

        public Point From { get; set; }

        [SourceId]
        public string FromId => From?.Abbreviation;

        [Id]
        public string Id { get; set; }

        public Point To { get; set; }

        [TargetId]
        public string ToId => To.Abbreviation;

        #endregion Public Properties
    }
}