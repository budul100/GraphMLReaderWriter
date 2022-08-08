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

        private readonly DataLabelSetterFactory dataLabelSetterFactory;
        private readonly DataTextSetterFactory dataTextSetterFactory;

        private readonly IDictionary<Type, Func<GraphType[], object, IDictionary<string, object>>> getters =
            new Dictionary<Type, Func<GraphType[], object, IDictionary<string, object>>>();

        private readonly Func<GraphType[], Type, object, IDictionary<string, object>> nodesGetter;

        #endregion Private Fields

        #region Public Constructors

        public NodesSetterFactory(DataTextSetterFactory dataTextSetterFactory, DataLabelSetterFactory dataLabelSetterFactory,
            Func<GraphType[], Type, object, IDictionary<string, object>> nodesGetter)
        {
            this.dataTextSetterFactory = dataTextSetterFactory;
            this.dataLabelSetterFactory = dataLabelSetterFactory;
            this.nodesGetter = nodesGetter;
        }

        #endregion Public Constructors

        #region Public Methods

        public Func<GraphType[], object, IDictionary<string, object>> Get(Type type)
        {
            var result = default(Func<GraphType[], object, IDictionary<string, object>>);

            var nodesProperty = type.GetProperty<NodesAttribute>();

            if (nodesProperty?.GetSetMethod() != default)
            {
                var propertyType = nodesProperty.PropertyType;

                if (!getters.ContainsKey(propertyType))
                {
                    var nodesType = propertyType.GetItemType(
                        mustBeInstantiable: true);
                    var nodesList = propertyType.GetAsList();

                    IDictionary<string, object> getter(GraphType[] graphs, object output) => GetNodes(
                        graphs: graphs,
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

        private IDictionary<string, object> GetNodes(GraphType[] graphs, PropertyInfo nodesProperty, Type nodesType,
            IList nodesList, object output)
        {
            var result = new Dictionary<string, object>();

            if (graphs?.Any() ?? false)
            {
                foreach (var graph in graphs)
                {
                    if (graph.Node?.Any() ?? false)
                    {
                        var dataTextSetters = dataTextSetterFactory.Get(
                            type: nodesType,
                            keyForType: KeyForType.Node);

                        var dataLabelSetters = dataLabelSetterFactory.Get(
                            type: nodesType);

                        foreach (var node in graph.Node)
                        {
                            var content = Activator.CreateInstance(nodesType);

                            // TO DO: If node.Graph != default, then the Node is a group => new attribute

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

                            if (dataTextSetters?.Any() ?? false)
                            {
                                foreach (var dataSetter in dataTextSetters)
                                {
                                    dataSetter.Invoke(
                                        arg1: node,
                                        arg2: content);
                                }
                            }

                            if (dataLabelSetters?.Any() ?? false)
                            {
                                foreach (var dataLabelSetter in dataLabelSetters)
                                {
                                    dataLabelSetter.Invoke(
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
                }
            }

            return result;
        }

        #endregion Private Methods
    }
}