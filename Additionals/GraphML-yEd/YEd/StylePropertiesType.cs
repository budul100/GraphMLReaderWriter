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
    [System.Xml.Serialization.XmlTypeAttribute("StyleProperties.type", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StylePropertiesType
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private StylePropertyType[] property;
        
        [System.Xml.Serialization.XmlElementAttribute("Property")]
        public StylePropertyType[] Property
        {
            get
            {
                return property;
            }
            set
            {
                property = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PropertySpecified
        {
            get
            {
                return ((this.Property != null) 
                            && (this.Property.Length != 0));
            }
        }
        
        public StylePropertiesType()
        {
            this.property = System.Array.Empty<StylePropertyType>();
        }
    }
}
