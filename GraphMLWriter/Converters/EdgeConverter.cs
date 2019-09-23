using GraphMLWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal class EdgeConverter
        : BaseConverter<edgetype>
    {
        #region Private Fields

        private readonly Func<object, graphtype> graphGetter;
        private readonly Func<object, string> sourceGetter;
        private readonly Func<object, string> targetGetter;

        #endregion Private Fields

        #region Public Constructors

        public EdgeConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, keyfortype.edge)
        {
            sourceGetter = GetAttributeGetter<Source>(type);
            targetGetter = GetAttributeGetter<Target>(type);

            graphGetter = GetItemGetter<graphtype, Graph>(
                type: type,
                converterGetter: GetGraphConverterGetter(keyConverter));
        }

        #endregion Public Constructors

        #region Public Methods

        public override edgetype GetContent(object input)
        {
            var source = sourceGetter.Invoke(input);

            if (source == null)
                throw new ApplicationException($"The edge {input.ToString()} has no source.");

            var target = targetGetter.Invoke(input);

            if (target == null)
                throw new ApplicationException($"The edge {input.ToString()} has no target.");

            var content = new edgetype
            {
                data = GetData(input).ToArray(),
                graph = graphGetter?.Invoke(input),
                id = idGetter.Invoke(input),
                source = source,
                target = target,
            };

            return content;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<datatype> GetData(object input)
        {
            foreach (var dataGetter in dataGetters)
            {
                var data = dataGetter.Invoke(input);

                if (data != null) yield return data;
            }
        }

        #endregion Private Methods
    }
}