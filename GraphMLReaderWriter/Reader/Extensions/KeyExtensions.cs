using GraphML;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace GraphMLReader.Extensions
{
    internal static class KeyExtensions
    {
        #region Private Fields

        private static readonly XmlSerializer shapeNodeSerializer = new XmlSerializer(typeof(YEd.ShapeNodeType));

        #endregion Private Fields

        #region Public Methods

        public static Func<object, string> GetLabelTextGetter(this GraphML.KeyType key)
        {
            return (node) => (node as GraphML.NodeType).GetTextLabel(key);
        }

        public static Func<object, string> GetTextGetter(this KeyForType keyForType, KeyType key)
        {
            switch (keyForType)
            {
                case KeyForType.Graph:
                    return (graph) => (graph as GraphType).GetText(key);

                case KeyForType.Node:
                    return (node) => (node as NodeType).GetTextData(key);

                case KeyForType.Edge:
                    return (edge) => (edge as EdgeType).GetText(key);
            }

            return default;
        }

        #endregion Public Methods

        #region Private Methods

        private static string GetText(this EdgeType edge, KeyType key)
        {
            var result = edge?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        private static string GetText(this GraphType graph, KeyType key)
        {
            var result = graph?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        private static string GetTextData(this NodeType node, KeyType key)
        {
            var result = node?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        private static string GetTextLabel(this GraphML.NodeType node, GraphML.KeyType key)
        {
            var result = default(string);

            var relevant = node?.Data?
                .SingleOrDefault(d => d.Key == key.Id);

            if (relevant != default)
            {
                var nodeLabel = relevant.ShapeNode != default
                    ? relevant.ShapeNode?.NodeLabel
                    : relevant.ProxyAutoBoundsNode?.Realizers?.GroupNode?.NodeLabel;

                if (nodeLabel != default)
                {
                    result = nodeLabel?.FirstOrDefault()?
                        .Text?.FirstOrDefault()?.ToString();
                }
            }

            return result;
        }

        #endregion Private Methods
    }
}