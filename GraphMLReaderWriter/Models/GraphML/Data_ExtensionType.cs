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
namespace GraphML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("data-extension.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("data-extension.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GraphML.DataType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GraphML.DefaultType))]
    public partial class Data_ExtensionType
    {
        [System.Xml.Serialization.XmlElementAttribute("ShapeNode", Namespace = "http://www.yworks.com/xml/graphml")]
        public YEd.ShapeNodeType ShapeNode { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("ProxyAutoBoundsNode", Namespace = "http://www.yworks.com/xml/graphml")]
        public YEd.ProxyAutoBoundsNode ProxyAutoBoundsNode { get; set; }
        
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text { get; set; }
    }
}