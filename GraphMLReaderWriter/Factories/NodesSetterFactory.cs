using GraphML;
using GraphMLReaderWriter.Attributes;
using GraphMLReaderWriter.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphMLReader.Factories
{
    internal class NodesSetterFactory<T>
        where T : class
    {
        #region Private Fields

        private readonly IDictionary<Type, Func<GraphType, object, IDictionary<string, object>>> getters =
            new Dictionary<Type, Func<GraphType, object, IDictionary<string, object>>>();

        private readonly KeySetterFactory keySetterFactory;
        private readonly Func<GraphType, Type, object, IDictionary<string, object>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public NodesSetterFactory(KeySetterFactory keySetterFactory,
            Func<GraphType, Type, object, IDictionary<string, object>> nodesGetter)
        {
            this.keySetterFactory = keySetterFactory;
            this.nodesGetter = nodesGetter;
        }

        #endregion Public Constructors

        #region Public Methods

        public Func<GraphType, object, IDictionary<string, object>> Get(Type type)
        {
            var result = default(Func<GraphType, object, IDictionary<string, object>>);

            var nodesProperty = type.GetProperty<NodesAttribute>();

            if (nodesProperty?.GetSetMethod() != default)
            {
                var propertyType = nodesProperty.PropertyType;

                if (!getters.ContainsKey(propertyType))
                {
                    var nodesType = propertyType.GetItemType(
                        mustBeInstantiable: true);
                    var nodesList = propertyType.GetAsList();

                    IDictionary<string, object> getter(GraphType graph, object output) => GetNodes(
                        graph: graph,
                        nodesProperty: nodesProperty,
                        nodesType: nodesType,
                        nodesList: nodesList,
                        output: output);

                    getters.Add(
                        key: propertyType,
                        value: getter);
                }

                result = getters[propertyType];
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private IDictionary<string, object> GetNodes(GraphType graph, PropertyInfo nodesProperty, Type nodesType,
            IList nodesList, object output)
        {
            var result = new Dictionary<string, object>();

            if (graph.Node?.Any() ?? false)
            {
                var keySetters = keySetterFactory.Get(
                    type: nodesType,
                    keyForType: KeyForType.Node);

                foreach (var node in graph.Node)
                {
                    var content = Activator.CreateInstance(nodesType);

                    if (node.Graph != default)
                    {
                        var contentNodes = nodesGetter.Invoke(
                            arg1: node.Graph,
                            arg2: nodesType,
                            arg3: content);

                        if (contentNodes?.Any() ?? false)
                        {
                            foreach (var childNode in contentNodes)
                            {
                                result.Add(
                                    key: childNode.Key,
                                    value: childNode.Value);
                            }
                        }
                    }

                    if (keySetters?.Any() ?? false)
                    {
                        foreach (var keySetter in keySetters)
                        {
                            keySetter.Invoke(
                                arg1: node,
                                arg2: content);
                        }
                    }

                    nodesList.Add(content);

                    result.Add(
                        key: node.Id,
                        value: content);
                }

                nodesProperty.SetCollection(
                    obj: output,
                    items: nodesList);
            }

            return result;
        }

        #endregion Private Methods
    }
}