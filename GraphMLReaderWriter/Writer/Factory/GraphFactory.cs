using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Factories
{
    internal class GraphFactory
        : ContentFactory<GraphType>
    {
        #region Private Fields

        private readonly Func<object, IEnumerable<EdgeType>> edgesGetter;
        private readonly Func<object, IEnumerable<NodeType>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public GraphFactory(Type type, DataFactory dataFactory)
            : base(type: type, dataFactory: dataFactory, forType: KeyForType.Graph)
        {
            var nodesFactoryGetter = GetNodeFactoryGetter(dataFactory);
            nodesGetter = type.GetItemsGetter<NodesAttribute, NodeType>(nodesFactoryGetter);

            var edgesFactoryGetter = GetEdgeFactoryGetter(dataFactory);
            edgesGetter = type.GetItemsGetter<EdgesAttribute, EdgeType>(edgesFactoryGetter);
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

        private static Func<Type, ContentFactory<EdgeType>> GetEdgeFactoryGetter(DataFactory dataFactory)
        {
            return (propertyType) => new EdgeFactory(
                type: propertyType,
                dataFactory: dataFactory);
        }

        private static Func<Type, ContentFactory<NodeType>> GetNodeFactoryGetter(DataFactory dataFactory)
        {
            return (propertyType) => new NodeFactory(
                type: propertyType,
                dataFactory: dataFactory);
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