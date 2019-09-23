using GraphMLWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class NodeConverter
        : BaseConverter<nodetype>
    {
        #region Protected Fields

        protected readonly Func<object, IEnumerable<graphtype>> graphsGetter;

        #endregion Protected Fields

        #region Public Constructors

        public NodeConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, keyfortype.node)
        {
            graphsGetter = GetItemsGetter<graphtype, Graph>(
                type: type,
                converterGetter: GetGraphConverterGetter(keyConverter));
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

                if (data != null) yield return data;
            }

            var graphs = graphsGetter?.Invoke(input)?
                .Where(g => g != null).ToArray();

            if (graphs?.Any() ?? false)
            {
                foreach (var graph in graphs)
                {
                    yield return graphs;
                }
            }
        }

        #endregion Private Methods
    }
}