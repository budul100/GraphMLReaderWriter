using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace GraphMLReaderWriter.Extensions
{
    public static class PropertyExtensions
    {
        #region Public Methods

        public static T GetAttribute<T>(this PropertyInfo property)
            where T : class
        {
            return property.GetCustomAttribute(typeof(T)) as T;
        }

        public static void SetCollection(this PropertyInfo property, object obj, IList items)
        {
            if (items?.Count > 0)
            {
                var methode = property.PropertyType.IsListType()
                    ? items.GetType().GetMethod("ToList")
                    : items.GetType().GetMethod("ToArray");

                var value = methode.Invoke(
                    obj: items,
                    parameters: default);

                property.SetValue(
                    obj: obj,
                    value: value);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static bool IsListType(this Type type)
        {
            var result = type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(IList<>);

            return result;
        }

        #endregion Private Methods
    }
}