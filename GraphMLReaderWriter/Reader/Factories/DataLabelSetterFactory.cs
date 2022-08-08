using GraphML;
using GraphMLReader.Extensions;
using GraphMLReaderWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLReader.Factories
{
    internal class DataLabelSetterFactory
        : DataBaseSetterFactory
    {
        #region Public Methods

        public IEnumerable<Action<object, object>> Get(Type type)
        {
            var result = default(IEnumerable<Action<object, object>>);

            if (keys?.Any() ?? false)
            {
                if (!setters.ContainsKey(type))
                {
                    KeyType keyGetter(PropertyInfo _) => GetKey();

                    var currentSetters = GetSetters<NodeLabelAttribute>(
                        type: type,
                        keyGetter: keyGetter,
                        textGetterGetter: k => k.GetLabelTextGetter()).ToArray();

                    setters.Add(
                        key: type,
                        value: currentSetters);
                }

                result = setters[type];
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private KeyType GetKey()
        {
            var result = keys.SingleOrDefault(k => k.For == KeyForType.Node
                && k.YfilesType == "nodegraphics");

            return result;
        }

        #endregion Private Methods
    }
}