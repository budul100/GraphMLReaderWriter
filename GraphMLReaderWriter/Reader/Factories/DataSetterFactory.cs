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
                    var dataSetters = GetSetters<DataAttribute>(
                        type: type,
                        keyGetter: a => GetKeyData(keyForType, a),
                        textGetterGetter: k => keyForType.GetTextGetterData(k)).ToArray();

                    setters.Add(
                        key: type,
                        value: dataSetters);

                    //var nodeLabelSetters = GetSetters<NodeLabelAttribute>(
                    //    type: type,
                    //    keyGetter: _ => GetKeyNodeLabel(keyForType),
                    //    textGetterGetter: k => keyForType.GetTextGetterData(k)).ToArray();

                    //setters.Add(
                    //    key: type,
                    //    value: dataSetters);
                }

                result = setters[type];
            }

            return result;
        }

        public void Initialize(GraphmlType graphML)
        {
            keys = graphML.Key;
        }

        #endregion Public Methods

        #region Private Methods

        private KeyType GetKeyData(KeyForType keyForType, PropertyInfo attributeProperty)
        {
            var name = attributeProperty.GetAttribute<DataAttribute>()?.Name
                ?? attributeProperty.Name;

            var result = keys.SingleOrDefault(k => k.For == keyForType
                && k.AttrName == name);

            return result;
        }

        private KeyType GetKeyNodeLabel(KeyForType keyForType)
        {
            var result = keys.SingleOrDefault(k => k.For == keyForType
                && k.YfilesType == "nodegraphics");

            return result;
        }

        private IEnumerable<Action<object, object>> GetSetters<T>(Type type, Func<PropertyInfo, KeyType> keyGetter,
            Func<KeyType, Func<object, string>> textGetterGetter)
            where T : KeyAttribute
        {
            var attributeProperties = type?.GetProperties<T>()?
                .Where(p => p.GetSetMethod() != default).ToArray();

            if (attributeProperties?.Any() ?? false)
            {
                foreach (var attributeProperty in attributeProperties)
                {
                    var key = keyGetter?.Invoke(attributeProperty);

                    if (key != default)
                    {
                        var attributeType = attributeProperty.PropertyType;

                        if (!setters.ContainsKey(attributeType))
                        {
                            var textGetter = textGetterGetter?.Invoke(key);

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