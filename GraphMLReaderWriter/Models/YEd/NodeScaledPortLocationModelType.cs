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
    [System.Xml.Serialization.XmlTypeAttribute("NodeScaledPortLocationModel.type", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("NodeScaledPortLocationModel", Namespace="http://www.yworks.com/xml/graphml")]
    public partial class NodeScaledPortLocationModelType
    {
        
        [System.Xml.Serialization.XmlAttributeAttribute("portLocationPolicy")]
        public NodeScaledPortLocationModelPortLocationPolicyType PortLocationPolicy { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PortLocationPolicySpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("ratioX")]
        public double RatioX { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RatioXSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("ratioY")]
        public double RatioY { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RatioYSpecified { get; set; }
    }
}
