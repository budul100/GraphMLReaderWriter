using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Place
    {
        #region Public Constructors

        public Place()
        { }

        #endregion Public Constructors

        #region Protected Constructors

        protected Place(string name)
        {
            Abbreviation = name;
        }

        #endregion Protected Constructors

        #region Public Properties

        [Id]
        [Data]
        public string Abbreviation { get; set; }

        [NodeLabel]
        public string LongName { get; set; }

        [Nodes]
        public virtual Point[] Points { get; set; }

        #endregion Public Properties
    }
}