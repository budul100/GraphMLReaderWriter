using GraphMLRW.Attributes;

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

        [SourceIdAttribute]
        public string FromId => From?.Abbreviation;

        [IdAttribute]
        public string Id { get; set; }

        public Point To { get; set; }

        [TargetIdAttribute]
        public string ToId => To.Abbreviation;

        #endregion Public Properties
    }
}