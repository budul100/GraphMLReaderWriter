using System;

namespace GraphMLRW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class KeyAttribute
        : Attribute
    {
        #region Public Constructors

        public KeyAttribute()
        { }

        public KeyAttribute(string name)
        {
            Name = name;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Name { get; }

        #endregion Public Properties
    }
}