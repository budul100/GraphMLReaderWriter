using System;

namespace GraphMLWriter.Attributes
{
    public class Key : Attribute
    {
        #region Public Constructors

        public Key()
        { }

        public Key(string name)
        {
            Name = name;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Name { get; }

        #endregion Public Properties
    }
}