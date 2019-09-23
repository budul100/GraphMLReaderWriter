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

        protected static Func<Type, ItemsConverter<nodetype>> GetNodeConverterGetter(KeyConverter keyConverter)
        {
            return (propertyType) => new NodeConverter(
                type: propertyType,
                keyConverter: keyConverter);
        }

        protected Func<object, string> GetAttributeGetter<U>(Type type)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != null).ToArray();

            if (properties.Count() > 1)
            {
                throw new TypeLoadException($"There can be only one property with the {typeof(U).ToString()} attribute in {type.ToString()} types.");
            }

            return (input) => properties.SingleOrDefault()?.GetValue(input)?.ToString();
        }

        protected Func<object, V> GetItemGetter<V, U>(Type type, Func<Type, ItemsConverter<V>> converterGetter)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != null).ToArray();

            if (properties.Any())
            {
                if (properties.Count() > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U).ToString()} attribute in {type.ToString()} types.");
                }

                return (input) => converterGetter
                    .Invoke(properties.Single().PropertyType)
                    .GetContent(input);
            }

            return default;
        }

        protected Func<object, IEnumerable<V>> GetItemsGetter<V, U>(Type type, Func<Type, ItemsConverter<V>> converterGetter)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != null).ToArray();

            if (properties?.Any() ?? false)
            {
                if (properties.Count() > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U).ToString()} attribute in {type.ToString()} types.");
                }

                var property = properties.Single();

                var contentType = GetContentType(property.PropertyType);
                var converter = converterGetter?.Invoke(contentType);

                if (converter != null)
                {
                    return (input) => GetContents(
                        input: input,
                        property: property,
                        converter: converter);
                }
            }

            return default;
        }

        #endregion Protected Methods

        #region Private Methods

        private static Type GetContentType(Type type)
        {
            return type.GetGenericArguments().FirstOrDefault()
                ?? type.GetElementType();
        }

        private static Func<int, string> GetNewIdGetter(Type type)
        {
            return (newId) => $"{type.Name}-{newId.ToString()}";
        }

        private IEnumerable<V> GetContents<V>(object input, PropertyInfo property, ItemsConverter<V> converter)
        {
            var contents = (Array)property.GetValue(input);

            if ((contents?.Length ?? 0) > 0)
            {
                foreach (var content in contents)
                {
                    yield return converter.GetContent(content);
                }
            }
        }

        private string GetId(Func<object, string> currentIdGetter, Func<int, string> newIdGetter, object input)
        {
            var id = currentIdGetter?.Invoke(input);

            if (id == null)
            {
                var newId = ids.Count();

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

        private Func<object, string> GetIdGetter(Type type)
        {
            return (input) => GetId(
                currentIdGetter: GetAttributeGetter<Id>(type),
                newIdGetter: GetNewIdGetter(type),
                input: input);
        }

        #endregion Private Methods
    }
}