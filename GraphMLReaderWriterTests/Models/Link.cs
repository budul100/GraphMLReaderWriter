﻿using GraphMLReaderWriter.Attributes;

namespace GraphMLWriterTest.Models
{
    public class Link
    {
        #region Public Constructors

        public Link()
        { }

        public Link(Point from, Point to)
        {
            From = from;
            To = to;
        }

        #endregion Public Constructors

        #region Public Properties

        [Source]
        public Place From { get; set; }

        [Target]
        public Place To { get; set; }

        #endregion Public Properties
    }
}