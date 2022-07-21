using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class GraphConverter
        : ContentConverter<GraphType>
    {
        #region Private Fields

        private readonly Func<object, IEnumerable<EdgeType>> edgesGetter;
        private readonly Func<object, IEnumerable<NodeType>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public GraphConverter(Type type, DataConverter dataConverter)
            : base(type: type, dataConverter: dataConverter, forType: KeyForType.Graph)
        {
            var nodesConverterGetter = GetNodeConverterGetter(dataConverter);
            nodesGetter = type.GetItemsGetter<NodesAttribute, NodeType>(nodesConverterGetter);

            var edgesConverterGetter = GetEdgeConverterGetter(dataConverter);
            edgesGetter = type.GetItemsGetter<EdgesAttribute, EdgeType>(edgesConverterGetter);
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

        private static Func<Type, ContentConverter<EdgeType>> GetEdgeConverterGetter(DataConverter dataConverter)
        {
            return (propertyType) => new EdgeConverter(
                type: propertyType,
                dataConverter: dataConverter);
        }

        private static Func<Type, ContentConverter<NodeType>> GetNodeConverterGetter(DataConverter dataConverter)
        {
            return (propertyType) => new NodeConverter(
                type: propertyType,
                dataConverter: dataConverter);
        }

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