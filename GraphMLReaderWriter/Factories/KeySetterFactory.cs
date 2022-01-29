using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TB.ComponentModel;

namespace GraphMLReader.Factories
{
    internal class KeySetterFactory
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
                    var currents = GetSetters(
                        type: type,
                        keyForType: keyForType).ToArray();

                    setters.Add(
                        key: type,
                        value: currents);
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

        private IEnumerable<Action<object, object>> GetSetters(Type type, KeyForType keyForType)
        {
            var attributeProperties = type?.GetProperties<KeyAttribute>()?
                .Where(p => p.GetSetMethod() != default).ToArray();

            if (attributeProperties?.Any() ?? false)
            {
                foreach (var attributeProperty in attributeProperties)
                {
                    var name = attributeProperty.GetAttribute<KeyAttribute>()?.Name;
                    var key = keys.SingleOrDefault(k => k.AttrName == name
                        && k.For == keyForType);

                    if (key != default)
                    {
                        var attributeType = attributeProperty.PropertyType;

                        if (!setters.ContainsKey(attributeType))
                        {
                            var textGetter = default(Func<object, string>);

                            switch (keyForType)
                            {
                                case KeyForType.Graph:
                                    textGetter = (graph) => (graph as GraphType).GetAttribute(key);
                                    break;

                                case KeyForType.Node:
                                    textGetter = (node) => (node as NodeType).GetAttribute(key);
                                    break;

                                case KeyForType.Edge:
                                    textGetter = (edge) => (edge as EdgeType).GetAttribute(key);
                                    break;
                            }

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