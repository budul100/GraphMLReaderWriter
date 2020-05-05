using GraphMLWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Point
    {
        #region Public Constructors

        public Point(string name)
        {
            Abbreviation = name;
        }

        #endregion Public Constructors

        #region Public Properties

        [Id]
        [Key(nameof(Abbreviation))]
        public string Abbreviation { get; set; }

        [Key(nameof(IsImportant))]
        public bool IsImportant { get; set; }

        #endregion Public Properties
    }
}