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
    [System.Xml.Serialization.XmlTypeAttribute("nodeLabelModel.type", Namespace="http://www.yworks.com/xml/graphml")]
    public enum NodeLabelModelType
    {
        
        [System.Xml.Serialization.XmlEnumAttribute("free")]
        Free,
        
        [System.Xml.Serialization.XmlEnumAttribute("sides")]
        Sides,
        
        [System.Xml.Serialization.XmlEnumAttribute("corners")]
        Corners,
        
        [System.Xml.Serialization.XmlEnumAttribute("eight_pos")]
        Eight_Pos,
        
        [System.Xml.Serialization.XmlEnumAttribute("sandwich")]
        Sandwich,
        
        [System.Xml.Serialization.XmlEnumAttribute("internal")]
        Internal,
        
        [System.Xml.Serialization.XmlEnumAttribute("custom")]
        Custom,
    }
}