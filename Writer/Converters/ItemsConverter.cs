﻿using GraphML;
using GraphMLRW.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLRW.Converters
{
    internal abstract class ItemsConverter<T>
        : BaseConverter
    {
        #region Protected Fields

        protected readonly IEnumerable<Func<object, DataType>> dataGetters;
        protected readonly Func<object, string> idGetter;

        #endregion Protected Fields

        #region Protected Constructors

        protected ItemsConverter(Type type, KeyConverter keyConverter, KeyForType forType)
        {
            idGetter = GetIdGetter(type);

            dataGetters = keyConverter.GetDataGetters(
                type: type,
                forType: forType).ToArray();
        }

        #endregion Protected Constructors

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

        protected static Func<Type, ItemsConverter<EdgeType>> GetEdgeConverterGetter(KeyConverter keyConverter)
        {
            return (propertyType) => new EdgeConverter(
                type: propertyType,
                keyConverter: keyConverter);
        }

        protected static Func<Type, ItemsConverter<GraphType>> GetGraphConverterGetter(KeyConverter keyConverter)
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

            if (properties.Length > 0)
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

        protected static Func<Type, ItemsConverter<NodeType>> GetNodeConverterGetter(KeyConverter keyConverter)
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
                    id = newIdGetter.Invoke(newId++);
                } while (ids.Contains(id));
            }

            ids.Add(id);

            return id;
        }

        private static Func<object, string> GetIdGetter(Type type)
        {
            var currentIdGetter = GetAttributeGetter<IdAttribute>(type);
            var newIdGetter = GetNewIdGetter(type);

            return (input) => GetId(
                currentIdGetter: currentIdGetter,
                newIdGetter: newIdGetter,
                input: input);
        }

        private static Func<int, string> GetNewIdGetter(Type type)
        {
            return (newId) => $"{type.Name}-{newId}";
        }

        #endregion Private Methods
    }
}