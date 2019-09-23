using GraphMLWriter.Attributes;

namespace GraphMLWriterTest.Test
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

        #endregion Public Properties
    }
}