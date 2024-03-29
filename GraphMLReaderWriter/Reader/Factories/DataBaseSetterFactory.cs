﻿using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TB.ComponentModel;

namespace GraphMLReader.Factories
{
    internal abstract class DataBaseSetterFactory
    {
        #region Protected Fields

        protected readonly IDictionary<Type, IEnumerable<Action<object, object>>> setters =
            new Dictionary<Type, IEnumerable<Action<object, object>>>();

        protected IEnumerable<KeyType> keys;

        #endregion Protected Fields

        #region Public Methods

        public void Initialize(GraphmlType graphML)
        {
            keys = graphML.Key;
        }

        #endregion Public Methods

        #region Protected Methods

        protected IEnumerable<Action<object, object>> GetSetters<T>(Type type, Func<PropertyInfo, KeyType> keyGetter,
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

        #endregion Protected Methods

        #region Private Methods

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