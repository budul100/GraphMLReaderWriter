using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections.Generic;

namespace GraphMLWriter.Converters
{
    internal abstract class BaseConverter
    {
        #region Protected Fields

        protected static HashSet<string> ids;

        #endregion Protected Fields

        #region Public Methods

        public static void Initialize()
        {
            ids = new HashSet<string>();
        }

        #endregion Public Methods

        #region Protected Methods

        protected static Func<object, string> GetIdGetter(Type type)
        {
            var currentIdGetter = type.GetAttributeGetter<IdAttribute>();
            var newIdGetter = GetNewIdGetter(type);

            return (input) => GetId(
                currentIdGetter: currentIdGetter,
                newIdGetter: newIdGetter,
                input: input);
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

        private static Func<int, string> GetNewIdGetter(Type type)
        {
            return (newId) => $"{type.Name}-{newId}";
        }

        #endregion Private Methods
    }
}