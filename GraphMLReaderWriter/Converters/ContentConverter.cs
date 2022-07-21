using GraphML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Converters
{
    internal abstract class ContentConverter<T>
        : BaseConverter
    {
        #region Protected Fields

        protected readonly IEnumerable<Func<object, DataType>> dataGetters;
        protected readonly Func<object, string> idGetter;

        #endregion Protected Fields

        #region Protected Constructors

        protected ContentConverter(Type type, DataConverter dataConverter, KeyForType forType)
        {
            idGetter = GetIdGetter(type);

            dataGetters = dataConverter.GetDataGetters(
                type: type,
                forType: forType).ToArray();
        }

        #endregion Protected Constructors

        #region Public Methods

        public abstract T GetContent(object input);

        #endregion Public Methods
    }
}