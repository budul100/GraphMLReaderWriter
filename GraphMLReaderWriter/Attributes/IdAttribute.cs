using System;

namespace GraphMLReaderWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class IdAttribute
        : Attribute
    { }
}