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

        [SourceAttribute]
        public Point From { get; set; }

        [IdAttribute]
        public string Id { get; set; }

        [TargetAttribute]
        public Point To { get; set; }

        #endregion Public Properties
    }
}