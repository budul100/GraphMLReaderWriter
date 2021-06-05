using System;

namespace GraphMLWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class NodeAttribute
        : Attribute
    { }
}