using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class NodeConverter
        : ItemsConverter<nodetype>
    {
        #region Private Fields

        private readonly GraphConverter graphConverter;

        #endregion Private Fields

        #region Public Constructors

        public NodeConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, keyfortype.node)
        {
            graphConverter = new GraphConverter(
                type: type,
                keyConverter: keyConverter);
        }

        #endregion Public Constructors

        #region Public Methods

        public override nodetype GetContent(object input)
        {
            var content = new nodetype
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
            foreach (var dataGetter in dataGetters)
            {
                var data = dataGetter.Invoke(input);

                if (data != default)
                    yield return data;
            }

            var graph = graphConverter.GetContent(input);

            if (graph?.Items?.Any() ?? false)
            {
                yield return graph;
            }
        }

        #endregion Private Methods
    }
}