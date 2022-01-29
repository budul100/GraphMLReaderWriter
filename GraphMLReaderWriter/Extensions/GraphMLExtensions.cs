using GraphML;
using System.Linq;

namespace GraphMLReaderWriter.Extensions
{
    internal static class GraphMLExtensions
    {
        #region Public Methods

        public static string GetAttribute(this EdgeType edge, KeyType key)
        {
            var result = edge?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        public static string GetAttribute(this GraphType graph, KeyType key)
        {
            var result = graph?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        public static string GetAttribute(this NodeType node, KeyType key)
        {
            var result = node?.Data?
                .SingleOrDefault(d => d.Key == key.Id)?
                .Text?.FirstOrDefault()?.ToString();

            return result;
        }

        #endregion Public Methods
    }
}