using System;

namespace GraphMLReaderWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class DataAttribute
        : Attribute
    {
        #region Public Constructors

        public DataAttribute()
        { }

        public DataAttribute(string name)
        {
            Name = name;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Name { get; }

        #endregion Public Properties
    }
}