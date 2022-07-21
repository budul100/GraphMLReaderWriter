using GraphML;
using GraphMLReader.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GraphMLReader
{
    public class Reader<T>
        where T : class
    {
        #region Private Fields

        private readonly DataSetterFactory dataSetterFactory;
        private readonly EdgesSetterFactory edgesSetterFactory;
        private readonly Encoding encoding;
        private readonly NodesSetterFactory<T> nodesSetterFactory;

        #endregion Private Fields

        #region Public Constructors

        public Reader()
            : this(Encoding.UTF8)
        { }

        public Reader(Encoding encoding)
        {
            this.encoding = encoding;

            IDictionary<string, object> nodesGetter(GraphType graph, Type type, object output) => GetNodes(
                graph: graph,
                type: type,
                output: output);

            dataSetterFactory = new DataSetterFactory();
            nodesSetterFactory = new NodesSetterFactory<T>(
                dataSetterFactory: dataSetterFactory,
                nodesGetter: nodesGetter);
            edgesSetterFactory = new EdgesSetterFactory(
                dataSetterFactory: dataSetterFactory);
        }

        #endregion Public Constructors

        #region Public Methods

        public T Load(string path)
        {
            var graphML = GetGraphML(path);
            var result = GetContent(graphML);

            return result;
        }

        #endregion Public Methods

        #region Internal Methods

        internal IDictionary<string, object> GetNodes(GraphType graph, Type type, object output)
        {
            var result = default(IDictionary<string, object>);

            var nodesSetter = nodesSetterFactory.Get(type);

            if (nodesSetter != default)
            {
                result = nodesSetter.Invoke(
                    arg1: graph,
                    arg2: output);

                if (result?.Any() ?? false)
                {
                    var edgesSetter = edgesSetterFactory.Get(type);

                    if (edgesSetter != default)
                    {
                        edgesSetter.Invoke(
                            arg1: graph,
                            arg2: result,
                            arg3: output);
                    }
                }
            }

            return result;
        }

        #endregion Internal Methods

        #region Private Methods

        private T GetContent(GraphMLType graphML)
        {
            var output = default(T);

            var graph = graphML.Graph
                .SingleOrDefault();

            if (graph != default)
            {
                dataSetterFactory.Initialize(graphML);

                output = Activator.CreateInstance<T>();

                var dataSetters = dataSetterFactory.Get(
                    type: typeof(T),
                    keyForType: KeyForType.Graph);

                GetNodes(
                    graph: graph,
                    type: typeof(T),
                    output: output);

                if (dataSetters?.Any() ?? false)
                {
                    foreach (var dataSetter in dataSetters)
                    {
                        dataSetter.Invoke(
                            arg1: graph,
                            arg2: output);
                    }
                }
            }

            return output;
        }

        private GraphMLType GetGraphML(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    message: "The graphML file has not been found.",
                    fileName: path);
            }

            var result = default(GraphMLType);

            using (var xmlReader = new StreamReader(
                path: path,
                encoding: encoding))
            {
                var serializer = new XmlSerializer(typeof(GraphMLType));
                result = serializer.Deserialize(xmlReader) as GraphMLType;
            }

            return result;
        }

        #endregion Private Methods
    }
}