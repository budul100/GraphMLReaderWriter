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
    internal class EdgesSetterFactory
    {
        #region Private Fields

        private readonly KeySetterFactory keySetterFactory;

        private readonly IDictionary<Type, Action<GraphType, IDictionary<string, object>, object>> setters =
                    new Dictionary<Type, Action<GraphType, IDictionary<string, object>, object>>();

        #endregion Private Fields

        #region Public Constructors

        public EdgesSetterFactory(KeySetterFactory keySetterFactory)
        {
            this.keySetterFactory = keySetterFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        public Action<GraphType, IDictionary<string, object>, object> Get(Type type)
        {
            var result = default(Action<GraphType, IDictionary<string, object>, object>);

            var edgesProperty = type.GetProperty<EdgesAttribute>();

            if (edgesProperty != default)
            {
                var propertyType = edgesProperty.PropertyType;

                if (!setters.ContainsKey(propertyType))
                {
                    var edgesType = propertyType.GetItemType(
                        mustBeInstantiable: true);
                    var edgesList = propertyType.GetAsList();

                    var sourceProperty = edgesType.GetProperty<SourceAttribute>(
                        isMandatory: true);
                    var targetProperty = edgesType.GetProperty<TargetAttribute>(
                        isMandatory: true);

                    void setter(GraphType graph, IDictionary<string, object> nodes, object output) => SetEdges(
                        graph: graph,
                        nodes: nodes,
                        edgesProperty: edgesProperty,
                        sourceProperty: sourceProperty,
                        targetProperty: targetProperty,
                        edgesType: edgesType,
                        edgesList: edgesList,
                        output: output);

                    setters.Add(
                        key: propertyType,
                        value: setter);
                }

                result = setters[propertyType];
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private void SetEdges(GraphType graph, IDictionary<string, object> nodes, PropertyInfo edgesProperty,
            PropertyInfo sourceProperty, PropertyInfo targetProperty, Type edgesType, IList edgesList, object output)
        {
            if ((graph.Edge?.Any() ?? false)
                && (nodes?.Any() ?? false))
            {
                var keySetters = keySetterFactory.Get(
                    type: edgesType,
                    keyForType: KeyForType.Edge);

                foreach (var edge in graph.Edge)
                {
                    if (nodes.ContainsKey(edge.Source)
                        && nodes.ContainsKey(edge.Target))
                    {
                        var content = Activator.CreateInstance(edgesType);

                        sourceProperty.SetValue(
                            obj: content,
                            value: nodes[edge.Source]);

                        targetProperty.SetValue(
                            obj: content,
                            value: nodes[edge.Target]);

                        if (keySetters?.Any() ?? false)
                        {
                            foreach (var keySetter in keySetters)
                            {
                                keySetter.Invoke(
                                    arg1: edge,
                                    arg2: content);
                            }
                        }

                        edgesList.Add(content);
                    }
                }

                edgesProperty.SetCollection(
                    obj: output,
                    items: edgesList);
            }
        }

        #endregion Private Methods
    }
}