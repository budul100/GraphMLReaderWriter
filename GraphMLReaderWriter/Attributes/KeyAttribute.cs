using System;

namespace GraphMLReaderWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public abstract class KeyAttribute
        : Attribute
    {
        #region Protected Constructors

        protected KeyAttribute()
        { }

        protected KeyAttribute(string name)
        {
            Name = name;
        }

        #endregion Protected Constructors

        #region Public Properties

        public string Name { get; }

        #endregion Public Properties
    }
}