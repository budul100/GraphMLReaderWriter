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
namespace XLink
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("type", Namespace="http://www.w3.org/1999/xlink", AnonymousType=true)]
    public enum Type
    {
        
        [System.Xml.Serialization.XmlEnumAttribute("simple")]
        Simple,
        
        [System.Xml.Serialization.XmlEnumAttribute("extended")]
        Extended,
        
        [System.Xml.Serialization.XmlEnumAttribute("locator")]
        Locator,
        
        [System.Xml.Serialization.XmlEnumAttribute("arc")]
        Arc,
    }
}
