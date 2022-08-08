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

        private readonly DataLabelSetterFactory dataLabelSetterFactory;
        private readonly DataTextSetterFactory dataTextSetterFactory;
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

            IDictionary<string, object> nodesGetter(GraphType[] graph, Type type, object output) => GetNodes(
                graphs: graph,
                type: type,
                output: output);

            dataTextSetterFactory = new DataTextSetterFactory();
            dataLabelSetterFactory = new DataLabelSetterFactory();

            nodesSetterFactory = new NodesSetterFactory<T>(
                dataTextSetterFactory: dataTextSetterFactory,
                dataLabelSetterFactory: dataLabelSetterFactory,
                nodesGetter: nodesGetter);

            edgesSetterFactory = new EdgesSetterFactory(
                dataSetterFactory: dataTextSetterFactory);
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

        internal IDictionary<string, object> GetNodes(GraphType[] graphs, Type type, object output)
        {
            var result = default(IDictionary<string, object>);

            var nodesSetter = nodesSetterFactory.Get(type);

            if (nodesSetter != default)
            {
                result = nodesSetter.Invoke(
                    arg1: graphs,
                    arg2: output);

                if (result?.Any() ?? false)
                {
                    var edgesSetter = edgesSetterFactory.Get(type);

                    if (edgesSetter != default)
                    {
                        edgesSetter.Invoke(
                            arg1: graphs,
                            arg2: result,
                            arg3: output);
                    }
                }
            }

            return result;
        }

        #endregion Internal Methods

        #region Private Methods

        private T GetContent(GraphmlType graphML)
        {
            var output = default(T);

            var graph = graphML.Graph;

            if (graph != default)
            {
                dataTextSetterFactory.Initialize(graphML);
                dataLabelSetterFactory.Initialize(graphML);

                output = Activator.CreateInstance<T>();

                var dataSetters = dataTextSetterFactory.Get(
                    type: typeof(T),
                    keyForType: KeyForType.Graph);

                GetNodes(
                    graphs: graph,
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

        private GraphmlType GetGraphML(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    message: "The graphML file has not been found.",
                    fileName: path);
            }

            var result = default(GraphmlType);

            using (var reader = new StreamReader(
                path: path,
                encoding: encoding))
            {
                var serializer = new XmlSerializer(typeof(GraphmlType));
                result = serializer.Deserialize(reader) as GraphmlType;
            }

            return result;
        }

        #endregion Private Methods
    }
}