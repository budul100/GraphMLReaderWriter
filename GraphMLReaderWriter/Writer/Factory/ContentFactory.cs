using GraphML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMLWriter.Factories
{
    internal abstract class ContentFactory<T>
        : BaseFactory
    {
        #region Protected Fields

        protected readonly IEnumerable<Func<object, DataType>> dataGetters;
        protected readonly Func<object, string> idGetter;

        #endregion Protected Fields

        #region Protected Constructors

        protected ContentFactory(Type type, DataFactory dataFactory, KeyForType forType)
        {
            idGetter = GetIdGetter(type);

            dataGetters = dataFactory.GetDataGetters(
                type: type,
                forType: forType).ToArray();
        }

        #endregion Protected Constructors

        #region Public Methods

        public abstract T GetContent(object input);

        #endregion Public Methods
    }
}