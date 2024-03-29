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
    [System.Xml.Serialization.XmlTypeAttribute("Table.type", Namespace="http://www.yworks.com/xml/graphml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TableType
    {
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("DefaultColumnInsets")]
        public FloatInsetsType DefaultColumnInsets { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("DefaultRowInsets")]
        public FloatInsetsType DefaultRowInsets { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Insets")]
        public FloatInsetsType Insets { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private TableColumnType[] columns;
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlArrayAttribute("Columns")]
        [System.Xml.Serialization.XmlArrayItemAttribute("Column", Namespace="http://www.yworks.com/xml/graphml")]
        public TableColumnType[] Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }
        
        public TableType()
        {
            this.columns = System.Array.Empty<TableColumnType>();
            this.rows = System.Array.Empty<TableRowType>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private TableRowType[] rows;
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlArrayAttribute("Rows")]
        [System.Xml.Serialization.XmlArrayItemAttribute("Row", Namespace="http://www.yworks.com/xml/graphml")]
        public TableRowType[] Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute("autoResizeTable")]
        public bool AutoResizeTable { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AutoResizeTableSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("defaultColumnWidth")]
        public double DefaultColumnWidth { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultColumnWidthSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("defaultMinimumColumnWidth")]
        public double DefaultMinimumColumnWidth { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultMinimumColumnWidthSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("defaultRowHeight")]
        public double DefaultRowHeight { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultRowHeightSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("defaultMinimumRowHeight")]
        public double DefaultMinimumRowHeight { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultMinimumRowHeightSpecified { get; set; }
    }
}
