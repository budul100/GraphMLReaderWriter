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
    [System.Xml.Serialization.XmlTypeAttribute("TableTypeRows", Namespace="http://www.yworks.com/xml/graphml", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TableTypeRows
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private TableRowType[] row;
        
        [System.Xml.Serialization.XmlElementAttribute("Row")]
        public TableRowType[] Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowSpecified
        {
            get
            {
                return ((this.Row != null) 
                            && (this.Row.Length != 0));
            }
        }
        
        public TableTypeRows()
        {
            this.row = System.Array.Empty<TableRowType>();
        }
    }
}
