using GraphMLRW.Attributes;

namespace GraphMLWriterTest.Models
{
    public abstract class Location
    {
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

        [Node()]
        public virtual Point[] Points { get; set; }

        #endregion Public Properties
    }
}