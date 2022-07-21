using GraphML;
using System;
using System.Linq;

namespace GraphMLReader.Extensions
{
    internal static class KeyExtensions
    {
        #region Public Methods

        public static Func<object, string> GetDataTextGetter(this KeyForType keyForType, KeyType key)
        {
            var textGetter = default(Func<object, string>);

            switch (keyForType)
            {
                case KeyForType.Graph:
                    textGetter = (graph) => (graph as GraphType).GetDataText(key);
                    break;

                case KeyForType.Node:
                    textGetter = (node) => (node as NodeType).GetDataText(key);
                    break;

                case KeyForType.Edge:
                    textGetter = (edge) => (edge as EdgeType).GetDataText(key);
                    break;
            }

            return textGetter;
        }

        #endregion Public Methods

        #region Private Methods

        private static string GetDataText(this EdgeType edge, KeyType key)
        {
            var result = edge?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        private static string GetDataText(this GraphType graph, KeyType key)
        {
            var result = graph?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        private static string GetDataText(this NodeType node, KeyType key)
        {
            var result = node?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        #endregion Private Methods
    }
}