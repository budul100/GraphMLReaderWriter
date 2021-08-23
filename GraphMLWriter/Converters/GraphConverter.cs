using GraphMLWriter.Attributes;
using GraphMLWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class GraphConverter
        : ItemsConverter<graphtype>
    {
        #region Private Fields

        private readonly Func<object, IEnumerable<edgetype>> edgesGetter;
        private readonly Func<object, IEnumerable<nodetype>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public GraphConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, keyfortype.graph)
        {
            var nodesConverterGetter = GetNodeConverterGetter(keyConverter);
            nodesGetter = type.GetItemsGetter<nodetype, NodeAttribute>(nodesConverterGetter);

            var edgesConverterGetter = GetEdgeConverterGetter(keyConverter);
            edgesGetter = type.GetItemsGetter<edgetype, EdgeAttribute>(edgesConverterGetter);
        }

        #endregion Public Constructors

        #region Public Methods

        public override graphtype GetContent(object input)
        {
            var content = new graphtype
            {
                id = idGetter.Invoke(input),
                Items = GetItems(input).ToArray()
            };

            return content;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<object> GetItems(object input)
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

        #endregion Private Methods
    }
}