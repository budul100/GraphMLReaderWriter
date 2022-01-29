using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Location
    {
        #region Public Constructors

        public Location()
        { }

        #endregion Public Constructors

        #region Protected Constructors

        protected Location(string name)
        {
            Abbreviation = name;
        }

        #endregion Protected Constructors

        #region Public Properties

        [Id]
        [Key(nameof(Abbreviation))]
        public string Abbreviation { get; set; }

        [Nodes()]
        public virtual Point[] Points { get; set; }

        #endregion Public Properties
    }
}