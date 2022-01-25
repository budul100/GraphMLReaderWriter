using GraphML;
using GraphMLRW.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLRW.Converters
{
    internal class EdgeConverter
        : ItemsConverter<EdgeType>
    {
        #region Private Fields

        private readonly Func<object, string> sourceGetter;
        private readonly Func<object, string> targetGetter;

        #endregion Private Fields

        #region Public Constructors

        public EdgeConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, KeyForType.Edge)
        {
            sourceGetter = GetAttributeGetter<SourceIdAttribute>(type);
            targetGetter = GetAttributeGetter<TargetIdAttribute>(type);
        }

        #endregion Public Constructors

        #region Public Methods

        public override EdgeType GetContent(object input)
        {
            var source = sourceGetter.Invoke(input);

            if (source == default)
                throw new ApplicationException($"The edge {input} has no source.");

            var target = targetGetter.Invoke(input);

            if (target == default)
                throw new ApplicationException($"The edge {input} has no target.");

            var content = new EdgeType
            {
                Data = GetData(input).ToArray(),
                Id = idGetter.Invoke(input),
                Source = source,
                Target = target,
            };

            return content;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<DataType> GetData(object input)
        {
            foreach (var dataGetter in dataGetters)
            {
                var data = dataGetter.Invoke(input);

                if (data != default)
                    yield return data;
            }
        }

        #endregion Private Methods
    }
}