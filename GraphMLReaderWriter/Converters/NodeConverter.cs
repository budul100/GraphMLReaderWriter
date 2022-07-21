﻿using GraphML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class NodeConverter
        : ContentConverter<NodeType>
    {
        #region Private Fields

        private readonly GraphConverter graphConverter;

        #endregion Private Fields

        #region Public Constructors

        public NodeConverter(Type type, DataConverter dataConverter)
            : base(type: type, dataConverter: dataConverter, forType: KeyForType.Node)
        {
            graphConverter = new GraphConverter(
                type: type,
                dataConverter: dataConverter);
        }

        #endregion Public Constructors

        #region Public Methods

        public override NodeType GetContent(object input)
        {
            var content = new NodeType
            {
                Id = idGetter.Invoke(input),
                Data = GetDatas(input).ToArray(),
                Graph = GetGraph(input),
            };

            return content;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<DataType> GetDatas(object input)
        {
            foreach (var dataGetter in dataGetters)
            {
                var data = dataGetter.Invoke(input);

                if (data != default)
                {
                    yield return data;
                }
            }
        }

        private GraphType GetGraph(object input)
        {
            var result = default(GraphType);

            var graph = graphConverter.GetContent(input);

            if ((graph?.Node?.Any() ?? false)
                || (graph?.Edge?.Any() ?? false))
            {
                result = graph;
            }

            return result;
        }

        #endregion Private Methods
    }
}