using GraphML;
using GraphMLReader.Extensions;
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

        private readonly DataSetterFactory dataSetterFactory;

        private readonly IDictionary<Type, Func<GraphType, object, IDictionary<string, object>>> getters =
            new Dictionary<Type, Func<GraphType, object, IDictionary<string, object>>>();

        private readonly Func<GraphType, Type, object, IDictionary<string, object>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public NodesSetterFactory(DataSetterFactory dataSetterFactory,
            Func<GraphType, Type, object, IDictionary<string, object>> nodesGetter)
        {
            this.dataSetterFactory = dataSetterFactory;
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
                var dataSetters = dataSetterFactory.Get(
                    type: nodesType,
                    keyForType: KeyForType.Node);

                foreach (var node in graph.Node)
                {
                    var content = Activator.CreateInstance(nodesType);

                    if (node.Graph != default)
                    {
                        var childNodes = nodesGetter.Invoke(
                            arg1: node.Graph,
                            arg2: nodesType,
                            arg3: content);

                        if (childNodes?.Any() ?? false)
                        {
                            foreach (var childNode in childNodes)
                            {
                                result.Add(
                                    key: childNode.Key,
                                    value: childNode.Value);
                            }
                        }
                    }

                    if (dataSetters?.Any() ?? false)
                    {
                        foreach (var dataSetter in dataSetters)
                        {
                            dataSetter.Invoke(
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