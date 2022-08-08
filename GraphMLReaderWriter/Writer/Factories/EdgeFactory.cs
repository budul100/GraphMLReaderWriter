using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Factories
{
    internal class EdgeFactory
        : ContentFactory<EdgeType>
    {
        #region Private Fields

        private readonly Func<object, string> sourceIdGetter;
        private readonly Func<object, string> targetIdGetter;

        #endregion Private Fields

        #region Public Constructors

        public EdgeFactory(Type type, DataFactory dataFactory)
            : base(type: type, dataFactory: dataFactory, forType: KeyForType.Edge)
        {
            sourceIdGetter = type.GetNodeIdGetter<SourceAttribute>();
            targetIdGetter = type.GetNodeIdGetter<TargetAttribute>();
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