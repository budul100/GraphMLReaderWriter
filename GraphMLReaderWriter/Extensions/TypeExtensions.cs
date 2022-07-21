using GraphMLReaderWriter.Attributes;
using GraphMLWriter.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLReaderWriter.Extensions
{
    internal static class TypeExtensions
    {
        #region Public Methods

        public static IList GetAsList(this Type type)
        {
            var itemType = type.GetItemType();
            var listType = typeof(List<>).MakeGenericType(itemType);

            var result = Activator.CreateInstance(listType) as IList;

            return result;
        }

        public static Func<object, string> GetAttributeGetter<T>(this Type type, bool isMandatory = false)
            where T : Attribute
        {
            var property = type.GetProperty<T>(
                isMandatory: isMandatory);

            return (input) => input != default
                ? property?.GetValue(input)?.ToString()
                : default;
        }

        public static Func<object, IEnumerable<U>> GetItemsGetter<T, U>(this Type type, Func<Type, ContentFactory<U>> factoryGetter)
            where T : Attribute
        {
            var property = type.GetProperty<T>();

            var itemType = property?.PropertyType.GetItemType();

            if (itemType != default)
            {
                var factory = factoryGetter?.Invoke(itemType);

                if (factory != default)
                {
                    return (input) => input.GetContents(
                        property: property,
                        factory: factory);
                }
            }

            return default;
        }

        public static Type GetItemType(this Type type, bool mustBeInstantiable = false)
        {
            var result = type.GetGenericArguments().FirstOrDefault()
                ?? type.GetElementType();

            if (mustBeInstantiable
                && (result.GetTypeInfo().IsAbstract || result.GetConstructor(Type.EmptyTypes) == default))
            {
                throw new InvalidOperationException(
                    $"The type {result.Name} cannot be an abstract type and must have a parameterless constructor.");
            }

            return result;
        }

        public static Func<object, string> GetNodeIdGetter<T>(this Type type)
            where T : Attribute
        {
            var property = type.GetProperty<T>(
                isMandatory: true);

            var nodeIdGetter = property.PropertyType.GetAttributeGetter<IdAttribute>(
                isMandatory: true);

            return (input) => nodeIdGetter?.Invoke(property?.GetValue(input))?.ToString();
        }

        public static IEnumerable<PropertyInfo> GetProperties<T>(this Type type, bool isMandatory = false)
            where T : Attribute
        {
            var properties = type?.GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(T)) != default).ToArray();

            if ((properties?.Length ?? 0) > 0)
            {
                return properties;
            }
            else if (isMandatory)
            {
                throw new TypeLoadException($"There is no property marked with {typeof(T)} in {type} type.");
            }

            return Enumerable.Empty<PropertyInfo>();
        }

        public static PropertyInfo GetProperty<T>(this Type type, bool isMandatory = false)
            where T : Attribute
        {
            var properties = type.GetProperties<T>(isMandatory);

            if ((properties?.Count() ?? 0) > 1)
            {
                throw new TypeLoadException($"There can be only one property with the {typeof(T)} attribute in {type} type.");
            }

            return properties.SingleOrDefault();
        }

        #endregion Public Methods

        #region Private Methods

        private static IEnumerable<T> GetContents<T>(this object input, PropertyInfo property, ContentFactory<T> factory)
        {
            var contents = (Array)property.GetValue(input);

            if ((contents?.Length ?? 0) > 0)
            {
                foreach (var content in contents)
                {
                    yield return factory.GetContent(content);
                }
            }
        }

        #endregion Private Methods
    }
}