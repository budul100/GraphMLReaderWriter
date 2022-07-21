using GraphML;
using GraphMLWriter.Factories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GraphMLWriter
{
    public class Writer<T>
    {
        #region Private Fields

        private readonly DataFactory dataFactory;
        private readonly Encoding encoding;
        private readonly GraphFactory graphFactory;
        private readonly XmlSerializer serializer;

        #endregion Private Fields

        #region Public Constructors

        public Writer()
            : this(Encoding.UTF8)
        { }

        public Writer(Encoding encoding)
        {
            this.encoding = encoding;

            dataFactory = new DataFactory();
            graphFactory = new GraphFactory(
                type: typeof(T),
                dataFactory: dataFactory);

            serializer = new XmlSerializer(typeof(GraphmlType));
        }

        #endregion Public Constructors

        #region Public Methods

        public GraphmlType Save(T input, string path)
        {
            var result = GetContent(input);

            using (var writer = new StreamWriter(
                path: path,
                append: false,
                encoding: encoding))
            {
                serializer.Serialize(
                    textWriter: writer,
                    o: result);
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private GraphmlType GetContent(T input)
        {
            BaseFactory.Initialize();

            var content = new GraphmlType
            {
                Graph = GetGraph(input).ToArray(),
                Key = dataFactory.Keys.ToArray(),
            };

            return content;
        }

        private IEnumerable<GraphType> GetGraph(T input)
        {
            yield return graphFactory.GetContent(input);
        }

        #endregion Private Methods
    }
}