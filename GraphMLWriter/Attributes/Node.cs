using System;

namespace GraphMLWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class Node
        : Attribute
    {
    }
}