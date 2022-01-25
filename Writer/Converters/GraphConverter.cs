using GraphML;
using GraphMLRW.Attributes;
using GraphMLRW.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLRW.Converters
{
    internal class GraphConverter
        : ItemsConverter<GraphType>
    {
        #region Private Fields

        private readonly Func<object, IEnumerable<EdgeType>> edgesGetter;
        private readonly Func<object, IEnumerable<NodeType>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public GraphConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, KeyForType.Graph)
        {
            var nodesConverterGetter = GetNodeConverterGetter(keyConverter);
            nodesGetter = type.GetItemsGetter<NodeType, NodeAttribute>(nodesConverterGetter);

            var edgesConverterGetter = GetEdgeConverterGetter(keyConverter);
            edgesGetter = type.GetItemsGetter<EdgeType, EdgeAttribute>(edgesConverterGetter);
        }

        #endregion Public Constructors

        #region Public Methods

        public override GraphType GetContent(object input)
        {
            var content = new GraphType
            {
                Id = idGetter.Invoke(input),
                Edge = GetEdges(input).ToArray(),
                Node = GetNodes(input).ToArray(),
            };

            return content;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<EdgeType> GetEdges(object input)
        {
            var edges = edgesGetter?.Invoke(input)?
                .Where(e => e != default).ToArray();

            if (edges?.Any() ?? false)
            {
                foreach (var edge in edges)
                {
                    yield return edge;
                }
            }
        }

        private IEnumerable<NodeType> GetNodes(object input)
        {
            var nodes = nodesGetter?.Invoke(input)?
                .Where(n => n != default).ToArray();

            if (nodes?.Any() ?? false)
            {
                foreach (var node in nodes)
                {
                    yield return node;
                }
            }
        }

        #endregion Private Methods
    }
}