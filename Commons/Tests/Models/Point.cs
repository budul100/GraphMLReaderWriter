using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Point
        : Location
    {
        #region Public Constructors

        public Point()
        { }

        public Point(string name)
            : base(name)
        { }

        #endregion Public Constructors

        #region Public Properties

        [Key(nameof(IsImportant))]
        public bool IsImportant { get; set; }

        public override Point[] Points => default;

        #endregion Public Properties
    }
}