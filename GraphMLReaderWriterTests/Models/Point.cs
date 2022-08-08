using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Point
        : Place
    {
        #region Public Constructors

        public Point()
        { }

        public Point(string name)
            : base(name)
        { }

        #endregion Public Constructors

        #region Public Properties

        [Data(nameof(IsImportant))]
        public bool IsImportant { get; set; }

        [Data(nameof(IsNotImportant))]
        public bool IsNotImportant => !IsImportant;

        public override Point[] Points => default;

        #endregion Public Properties
    }
}