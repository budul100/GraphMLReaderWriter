using GraphMLWriter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLWriter.Converters
{
    internal abstract class ItemsConverter<T>
        : BaseConverter
    {
        #region Protected Fields

        protected readonly IEnumerable<Func<object, datatype>> dataGetters;
        protected readonly Func<object, string> idGetter;

        #endregion Protected Fields

        #region Public Constructors

        public ItemsConverter(Type type, KeyConverter keyConverter, keyfortype forType)
        {
            idGetter = GetIdGetter(type);
            dataGetters = keyConverter.GetDataGetters(
                type: type,
                forType: forType).ToArray();
        }

        #endregion Public Constructors

        #region Public Methods

        public abstract T GetContent(object input);

        #endregion Public Methods

        #region Protected Methods

        protected static Func<object, string> GetAttributeGetter<U>(Type type)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != default).ToArray();

            if (properties.Length > 1)
            {
                throw new TypeLoadException($"There can be only one property with the {typeof(U)} attribute in {type} types.");
            }

            return (input) => properties.SingleOrDefault()?.GetValue(input)?.ToString();
        }

        protected static Func<Type, ItemsConverter<edgetype>> GetEdgeConverterGetter(KeyConverter keyConverter)
        {
            return (propertyType) => new EdgeConverter(
                type: propertyType,
                keyConverter: keyConverter);
        }

        protected static Func<Type, ItemsConverter<graphtype>> GetGraphConverterGetter(KeyConverter keyConverter)
        {
            return (propertyType) => new GraphConverter(
                type: propertyType,
                keyConverter: keyConverter);
        }

        protected static Func<object, V> GetItemGetter<V, U>(Type type, Func<Type, ItemsConverter<V>> converterGetter)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != default).ToArray();

            if (properties.Any())
            {
                if (properties.Length > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U)} attribute in {type} types.");
                }

                return (input) => converterGetter
                    .Invoke(properties.Single().PropertyType)
                    .GetContent(input);
            }

            return default;
        }

        protected static Func<Type, ItemsConverter<nodetype>> GetNodeConverterGetter(KeyConverter keyConverter)
        {
            return (propertyType) => new NodeConverter(
                type: propertyType,
                keyConverter: keyConverter);
        }

        #endregion Protected Methods

        #region Private Methods

        private static string GetId(Func<object, string> currentIdGetter, Func<int, string> newIdGetter, object input)
        {
            var id = currentIdGetter?.Invoke(input);

            if (id == default)
            {
                var newId = ids.Count;

                do
                {
                    newId++;
                    id = newIdGetter.Invoke(newId);
                } while (ids.Any(i => i == id));
            }

            if (!ids.Any(i => i == id))
            {
                ids.Add(id);
            }

            return id;
        }

        private static Func<object, string> GetIdGetter(Type type)
        {
            return (input) => GetId(
                currentIdGetter: GetAttributeGetter<IdAttribute>(type),
                newIdGetter: GetNewIdGetter(type),
                input: input);
        }

        private static Func<int, string> GetNewIdGetter(Type type)
        {
            return (newId) => $"{type.Name}-{newId}";
        }

        #endregion Private Methods
    }
}