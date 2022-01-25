using GraphMLRW.Attributes;
using GraphMLRW.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLRW.Extensions
{
    internal static class TypeExtensions
    {
        #region Public Methods

        public static Func<object, string> GetAttributeGetter<U>(this Type type)
            where U : Attribute
        {
            var properties = type?.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != default).ToArray();

            if ((properties?.Length ?? 0) > 0)
            {
                if ((properties?.Length ?? 0) > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U)} attribute in {type} type.");
                }

                return (input) => properties?.SingleOrDefault()?
                    .GetValue(input)?.ToString();
            }

            return default;
        }

        public static Func<object, IEnumerable<V>> GetItemsGetter<V, U>(this Type type, Func<Type, ContentConverter<V>> converterGetter)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != default).ToArray();

            if (properties?.Any() ?? false)
            {
                if (properties.Length > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U)} attribute in {type} type.");
                }

                var property = properties.Single();

                var contentType = property.PropertyType.GetContentType();
                var converter = converterGetter?.Invoke(contentType);

                if (converter != default)
                {
                    return (input) => input.GetContents(
                        property: property,
                        converter: converter);
                }
            }

            return default;
        }

        public static Func<object, string> GetNodeIdGetter<U>(this Type type)
            where U : Attribute
        {
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(U)) != default).ToArray();

            if ((properties?.Length ?? 0) > 0)
            {
                if ((properties?.Length ?? 0) > 1)
                {
                    throw new TypeLoadException($"There can be only one property with the {typeof(U)} attribute in {type} type.");
                }

                var nodeType = properties.SingleOrDefault()?.PropertyType;

                var nodeIdGetter = nodeType != default
                    ? GetAttributeGetter<IdAttribute>(nodeType)
                    : default;

                if (nodeIdGetter == default)
                {
                    throw new TypeLoadException($"There is no property marked with {nameof(IdAttribute)} in {nodeType} type.");
                }

                return (input) => nodeIdGetter?.Invoke(properties.SingleOrDefault()?
                    .GetValue(input))?.ToString();
            }

            return default;
        }

        #endregion Public Methods

        #region Private Methods

        private static IEnumerable<V> GetContents<V>(this object input, PropertyInfo property, ContentConverter<V> converter)
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

        private static Type GetContentType(this Type type)
        {
            return type.GetGenericArguments().FirstOrDefault()
                ?? type.GetElementType();
        }

        #endregion Private Methods
    }
}