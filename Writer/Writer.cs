using GraphML;
using GraphMLRW.Converters;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GraphMLRW
{
    public class Writer<T>
    {
        #region Private Fields

        private readonly Encoding encoding;
        private readonly GraphConverter graphConverter;
        private readonly KeyConverter keyConverter;
        private readonly XmlSerializer serializer;

        #endregion Private Fields

        #region Public Constructors

        public Writer()
            : this(Encoding.UTF8)
        { }

        public Writer(Encoding encoding)
        {
            this.encoding = encoding;

            keyConverter = new KeyConverter();
            graphConverter = new GraphConverter(
                type: typeof(T),
                keyConverter: keyConverter);

            serializer = new XmlSerializer(typeof(GraphMLType));
        }

        #endregion Public Constructors

        #region Public Methods

        public void Save(T input, string path)
        {
            var content = GetContent(input);

            using (var writer = new StreamWriter(
                path: path,
                append: false,
                encoding: encoding))
            {
                serializer.Serialize(
                    textWriter: writer,
                    o: content);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private GraphMLType GetContent(T input)
        {
            BaseConverter.Initialize();

            var content = new GraphMLType
            {
                Graph = GetGraph(input).ToArray(),
                Key = keyConverter.Keys.ToArray(),
            };

            return content;
        }

        private IEnumerable<GraphType> GetGraph(T input)
        {
            yield return graphConverter.GetContent(input);
        }

        #endregion Private Methods
    }
}