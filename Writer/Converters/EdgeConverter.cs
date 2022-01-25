using GraphML;
using GraphMLRW.Attributes;
using GraphMLRW.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLRW.Converters
{
    internal class EdgeConverter
        : ContentConverter<EdgeType>
    {
        #region Private Fields

        private readonly Func<object, string> sourceIdGetter;
        private readonly Func<object, string> targetIdGetter;

        #endregion Private Fields

        #region Public Constructors

        public EdgeConverter(Type type, KeyConverter keyConverter)
            : base(type, keyConverter, KeyForType.Edge)
        {
            sourceIdGetter = type.GetNodeIdGetter<SourceAttribute>();

            if (sourceIdGetter == default)
            {
                throw new TypeLoadException($"There is no property marked with {nameof(SourceAttribute)} in {type} type.");
            }

            targetIdGetter = type.GetNodeIdGetter<TargetAttribute>();

            if (targetIdGetter == default)
            {
                throw new TypeLoadException($"There is no property marked with {nameof(TargetAttribute)} in {type} type.");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public override EdgeType GetContent(object input)
        {
            var source = sourceIdGetter.Invoke(input);

            if (source == default)
            {
                throw new ApplicationException($"The edge {input} has no source.");
            }

            var target = targetIdGetter.Invoke(input);

            if (target == default)
            {
                throw new ApplicationException($"The edge {input} has no target.");
            }

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