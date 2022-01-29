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

        private readonly EdgesSetterFactory edgesSetterFactory;
        private readonly Encoding encoding;
        private readonly KeySetterFactory keySetterFactory;
        private readonly NodesGetterFactory<T> nodesGetterFactory;

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

            keySetterFactory = new KeySetterFactory();
            nodesGetterFactory = new NodesGetterFactory<T>(
                keySetterFactory: keySetterFactory,
                nodesGetter: nodesGetter);
            edgesSetterFactory = new EdgesSetterFactory(
                keySetterFactory: keySetterFactory);
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

            var nodesGetter = nodesGetterFactory.Get(type);

            if (nodesGetter != default)
            {
                result = nodesGetter.Invoke(
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
                keySetterFactory.Initialize(graphML);

                output = Activator.CreateInstance<T>();

                var keySetters = keySetterFactory.Get(
                    type: typeof(T),
                    keyForType: KeyForType.Graph);

                GetNodes(
                    graph: graph,
                    type: typeof(T),
                    output: output);

                if (keySetters?.Any() ?? false)
                {
                    foreach (var keySetter in keySetters)
                    {
                        keySetter.Invoke(
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