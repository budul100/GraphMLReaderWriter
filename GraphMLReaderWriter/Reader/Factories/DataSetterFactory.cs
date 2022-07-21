using GraphML;
using GraphMLReader.Extensions;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TB.ComponentModel;

namespace GraphMLReader.Factories
{
    internal class DataSetterFactory
    {
        #region Private Fields

        private readonly IDictionary<Type, IEnumerable<Action<object, object>>> setters =
            new Dictionary<Type, IEnumerable<Action<object, object>>>();

        private IEnumerable<KeyType> keys;

        #endregion Private Fields

        #region Public Methods

        public IEnumerable<Action<object, object>> Get(Type type, KeyForType keyForType)
        {
            var result = default(IEnumerable<Action<object, object>>);

            if (keys?.Any() ?? false)
            {
                if (!setters.ContainsKey(type))
                {
                    var dataSetters = GetDataSetters<DataAttribute>(
                        type: type,
                        keyForType: keyForType,
                        textGetterGetter: k => keyForType.GetDataTextGetter(k)).ToArray();

                    setters.Add(
                        key: type,
                        value: dataSetters);
                }

                result = setters[type];
            }

            return result;
        }

        public void Initialize(GraphMLType graphML)
        {
            keys = graphML.Key;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<Action<object, object>> GetDataSetters<T>(Type type, KeyForType keyForType,
            Func<KeyType, Func<object, string>> textGetterGetter)
            where T : KeyAttribute
        {
            var attributeProperties = type?.GetProperties<T>()?
                .Where(p => p.GetSetMethod() != default).ToArray();

            if (attributeProperties?.Any() ?? false)
            {
                foreach (var attributeProperty in attributeProperties)
                {
                    var name = attributeProperty.GetAttribute<T>()?.Name
                        ?? attributeProperty.Name;
                    var key = keys.SingleOrDefault(k => k.AttrName == name
                        && k.For == keyForType);

                    if (key != default)
                    {
                        var attributeType = attributeProperty.PropertyType;

                        if (!setters.ContainsKey(attributeType))
                        {
                            var textGetter = textGetterGetter.Invoke(key);

                            if (textGetter != default)
                            {
                                void result(object element, object output) => SetAttribute(
                                    element: element,
                                    attributeProperty: attributeProperty,
                                    attributeType: attributeType,
                                    textGetter: textGetter,
                                    output: output);

                                yield return result;
                            }
                        }
                    }
                }
            }
        }

        private void SetAttribute(object element, PropertyInfo attributeProperty, Type attributeType,
            Func<object, string> textGetter, object output)
        {
            if (element != default)
            {
                var text = textGetter.Invoke(element);

                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (attributeType == typeof(string) || attributeType == typeof(object))
                    {
                        attributeProperty.SetValue(
                            obj: output,
                            value: text);
                    }
                    else
                    {
                        var converted = text.To(attributeType);

                        attributeProperty.SetValue(
                            obj: output,
                            value: converted);
                    }
                }
            }
        }

        #endregion Private Methods
    }
}