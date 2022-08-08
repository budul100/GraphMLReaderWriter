using GraphML;
using GraphMLReaderWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLWriter.Factories
{
    internal class DataFactory
    {
        #region Private Fields

        private int keyIndex;

        #endregion Private Fields

        #region Public Properties

        public IList<KeyType> Keys { get; } = new List<KeyType>();

        #endregion Public Properties

        #region Public Methods

        public IEnumerable<Func<object, DataType>> GetDataGetters(Type type, KeyForType forType = KeyForType.All)
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(DataAttribute)) != default).ToArray();

            foreach (var property in properties)
            {
                var name = (property.GetCustomAttribute(typeof(DataAttribute)) as DataAttribute)?.Name
                    ?? property.Name;

                var key = GetKey(
                    name: name,
                    type: property.PropertyType,
                    forType: forType);

                yield return (input) => GetData(
                    input: input,
                    property: property,
                    key: key);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static DataType GetData(object input, PropertyInfo property, KeyType key)
        {
            var text = GetValue(
                input: input,
                property: property).ToArray();

            var result = new DataType
            {
                Key = key.Id,
                Text = text,
            };

            return result;
        }

        private static KeyTypeType GetKeyType(Type type)
        {
            if (type == typeof(bool))
            {
                return KeyTypeType.Boolean;
            }
            else if (type == typeof(double))
            {
                return KeyTypeType.Double;
            }
            else if (type == typeof(float))
            {
                return KeyTypeType.Float;
            }
            else if (type == typeof(int))
            {
                return KeyTypeType.Int;
            }
            else if (type == typeof(long))
            {
                return KeyTypeType.Long;
            }
            else
            {
                return KeyTypeType.String;
            }
        }

        private static IEnumerable<string> GetValue(object input, PropertyInfo property)
        {
            var value = property.GetValue(input)?.ToString();

            if (!string.IsNullOrWhiteSpace(value))
            {
                yield return value;
            }
        }

        private KeyType GetKey(string name, Type type, KeyForType forType)
        {
            var keyType = GetKeyType(type);

            var result = Keys?.SingleOrDefault(k => k.AttrName == name
                && k.For == forType
                && k.AttrType == keyType);

            if (result == default)
            {
                result = new KeyType
                {
                    For = forType,
                    AttrName = name,
                    AttrType = keyType,
                    AttrTypeSpecified = true,
                    Id = $"Key-{keyIndex++}",
                };

                Keys.Add(result);
            }

            return result;
        }

        #endregion Private Methods
    }
}