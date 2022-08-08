using GraphML;
using GraphMLReader.Extensions;
using GraphMLReaderWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLReader.Factories
{
    internal class DataTextSetterFactory
        : DataBaseSetterFactory
    {
        #region Public Methods

        public IEnumerable<Action<object, object>> Get(Type type, KeyForType keyForType)
        {
            var result = default(IEnumerable<Action<object, object>>);

            if (keys?.Any() ?? false)
            {
                if (!setters.ContainsKey(type))
                {
                    var currentSetters = GetSetters<DataAttribute>(
                        type: type,
                        keyGetter: a => GetKey(keyForType, a),
                        textGetterGetter: k => keyForType.GetTextGetter(k)).ToArray();

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

        private KeyType GetKey(KeyForType keyForType, PropertyInfo attributeProperty)
        {
            var name = attributeProperty.GetAttribute<DataAttribute>()?.Name
                ?? attributeProperty.Name;

            var result = keys.SingleOrDefault(k => k.For == keyForType
                && k.AttrName == name);

            return result;
        }

        #endregion Private Methods
    }
}