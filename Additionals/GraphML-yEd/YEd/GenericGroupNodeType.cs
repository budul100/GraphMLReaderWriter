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
    [System.Xml.Serialization.XmlTypeAttribute("GenericGroupNode.type", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("GenericGroupNode", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TableNodeType))]
    public partial class GenericGroupNodeType : GenericNodeType
    {
        
        [System.Xml.Serialization.XmlElementAttribute("State")]
        public GenericGroupNodeTypeState State { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("Insets")]
        public InsetsType Insets { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("BorderInsets")]
        public InsetsType BorderInsets { get; set; }
    }
}
