//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 1.0.0.0 using the following command:
// XmlSchemaClassGenerator.Console -o . -n http://graphml.graphdrawing.org/xmlns=GraphML -n http://www.w3.org/1999/xlink=XLink --nu --sf --csm=Public --ct=System.Array --dc .\_XSD\graphml_complete.xsd
namespace GraphML
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("hyperedge.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("hyperedge", Namespace="http://graphml.graphdrawing.org/xmlns")]
    public partial class HyperedgeType : IHyperedgeExtraAttrib
    {
        
        [System.Xml.Serialization.XmlElementAttribute("desc")]
        public string Desc { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private DataType[] data;
        
        [System.Xml.Serialization.XmlElementAttribute("data")]
        public DataType[] Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataSpecified
        {
            get
            {
                return ((this.Data != null) 
                            && (this.Data.Length != 0));
            }
        }
        
        public HyperedgeType()
        {
            this.data = System.Array.Empty<DataType>();
            this.endpoint = System.Array.Empty<EndpointType>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private EndpointType[] endpoint;
        
        [System.Xml.Serialization.XmlElementAttribute("endpoint")]
        public EndpointType[] Endpoint
        {
            get
            {
                return this.endpoint;
            }
            set
            {
                this.endpoint = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndpointSpecified
        {
            get
            {
                return ((this.Endpoint != null) 
                            && (this.Endpoint.Length != 0));
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("graph")]
        public GraphType Graph { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("attr.name")]
        public string AttrName { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("attr.type")]
        public KeyTypeType AttrType { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AttrTypeSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public string Id { get; set; }
    }
}