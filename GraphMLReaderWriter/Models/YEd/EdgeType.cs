//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 1.0.0.0 using the following command:
// XmlSchemaClassGenerator.Console -o . -n http://graphml.graphdrawing.org/xmlns=GraphML -n http://www.w3.org/1999/xlink=XLink -n http://www.yworks.com/xml/graphml=YEd --nu --sf --csm=Public --ct=System.Array --dc .\_XSD\ygraphml.xsd
namespace YEd
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Edge.type", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ArcEdgeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BezierEdge))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericEdgeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolyLineEdgeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(QuadCurveEdgeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SplineEdge))]
    public partial class EdgeType
    {
        
        [System.Xml.Serialization.XmlElementAttribute("Path")]
        public PathType Path { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("LineStyle")]
        public LineStyleType LineStyle { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("Arrows")]
        public EdgeTypeArrows Arrows { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private EdgeLabelType[] edgeLabel;
        
        [System.Xml.Serialization.XmlElementAttribute("EdgeLabel")]
        public EdgeLabelType[] EdgeLabel
        {
            get
            {
                return edgeLabel;
            }
            set
            {
                edgeLabel = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EdgeLabelSpecified
        {
            get
            {
                return ((this.EdgeLabel != null) 
                            && (this.EdgeLabel.Length != 0));
            }
        }
        
        public EdgeType()
        {
            this.edgeLabel = System.Array.Empty<EdgeLabelType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("SourcePort")]
        public EdgePortType SourcePort { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("TargetPort")]
        public EdgePortType TargetPort { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("selected")]
        public bool Selected { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedSpecified { get; set; }
    }
}
