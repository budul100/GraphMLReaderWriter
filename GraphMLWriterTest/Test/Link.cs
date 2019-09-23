using GraphMLWriter.Attributes;

namespace GraphMLWriterTest.Test
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

        [Source]
        public string FromId => From?.Abbreviation;

        [Id]
        public string Id { get; set; }

        public Point To { get; set; }

        [Target]
        public string ToId => To.Abbreviation;

        #endregion Public Properties
    }
}