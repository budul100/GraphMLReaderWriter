﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.7.3081.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="locator.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("locator", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class locatortype {
    
    private string hrefField;
    
    private typeType typeField;
    
    private bool typeFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://www.w3.org/1999/xlink", DataType="anyURI")]
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://www.w3.org/1999/xlink")]
    public typeType type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool typeSpecified {
        get {
            return this.typeFieldSpecified;
        }
        set {
            this.typeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3.org/1999/xlink")]
public enum typeType {
    
    /// <remarks/>
    simple,
    
    /// <remarks/>
    extended,
    
    /// <remarks/>
    title,
    
    /// <remarks/>
    resource,
    
    /// <remarks/>
    locator,
    
    /// <remarks/>
    arc,
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(defaulttype))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(datatype))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="data-extension.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
public partial class dataextensiontype {
    
    private string[] textField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text {
        get {
            return this.textField;
        }
        set {
            this.textField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="data.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("data", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class datatype : dataextensiontype {
    
    private string keyField;
    
    private long timeField;
    
    private string idField;
    
    public datatype() {
        this.timeField = ((long)(0));
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
    public long time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="key.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("key", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class keytype {
    
    private string descField;
    
    private defaulttype defaultField;
    
    private string idField;
    
    private bool dynamicField;
    
    private keyfortype forField;
    
    private string attrnameField;
    
    private keytypetype attrtypeField;
    
    private bool attrtypeFieldSpecified;
    
    public keytype() {
        this.dynamicField = false;
        this.forField = keyfortype.all;
    }
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    public defaulttype @default {
        get {
            return this.defaultField;
        }
        set {
            this.defaultField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool dynamic {
        get {
            return this.dynamicField;
        }
        set {
            this.dynamicField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(keyfortype.all)]
    public keyfortype @for {
        get {
            return this.forField;
        }
        set {
            this.forField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("attr.name", DataType="NMTOKEN")]
    public string attrname {
        get {
            return this.attrnameField;
        }
        set {
            this.attrnameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("attr.type")]
    public keytypetype attrtype {
        get {
            return this.attrtypeField;
        }
        set {
            this.attrtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool attrtypeSpecified {
        get {
            return this.attrtypeFieldSpecified;
        }
        set {
            this.attrtypeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="default.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("default", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class defaulttype : dataextensiontype {
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="key.for.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
public enum keyfortype {
    
    /// <remarks/>
    all,
    
    /// <remarks/>
    graphml,
    
    /// <remarks/>
    graph,
    
    /// <remarks/>
    node,
    
    /// <remarks/>
    edge,
    
    /// <remarks/>
    hyperedge,
    
    /// <remarks/>
    port,
    
    /// <remarks/>
    endpoint,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="key.type.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
public enum keytypetype {
    
    /// <remarks/>
    boolean,
    
    /// <remarks/>
    @int,
    
    /// <remarks/>
    @long,
    
    /// <remarks/>
    @float,
    
    /// <remarks/>
    @double,
    
    /// <remarks/>
    @string,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="graphml.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("graphml", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class graphmltype {
    
    private string descField;
    
    private keytype[] keyField;
    
    private object[] itemsField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("key")]
    public keytype[] key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("graph", typeof(graphtype))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="graph.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("graph", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class graphtype {
    
    private string descField;
    
    private object[] itemsField;
    
    private string idField;
    
    private graphedgedefaulttype edgedefaultField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("edge", typeof(edgetype))]
    [System.Xml.Serialization.XmlElementAttribute("hyperedge", typeof(hyperedgetype))]
    [System.Xml.Serialization.XmlElementAttribute("locator", typeof(locatortype))]
    [System.Xml.Serialization.XmlElementAttribute("node", typeof(nodetype))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public graphedgedefaulttype edgedefault {
        get {
            return this.edgedefaultField;
        }
        set {
            this.edgedefaultField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="edge.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("edge", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class edgetype {
    
    private string descField;
    
    private datatype[] dataField;
    
    private graphtype graphField;
    
    private string idField;
    
    private bool directedField;
    
    private bool directedFieldSpecified;
    
    private string sourceField;
    
    private string targetField;
    
    private string sourceportField;
    
    private string targetportField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data")]
    public datatype[] data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
    
    /// <remarks/>
    public graphtype graph {
        get {
            return this.graphField;
        }
        set {
            this.graphField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool directed {
        get {
            return this.directedField;
        }
        set {
            this.directedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool directedSpecified {
        get {
            return this.directedFieldSpecified;
        }
        set {
            this.directedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string source {
        get {
            return this.sourceField;
        }
        set {
            this.sourceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string target {
        get {
            return this.targetField;
        }
        set {
            this.targetField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string sourceport {
        get {
            return this.sourceportField;
        }
        set {
            this.sourceportField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string targetport {
        get {
            return this.targetportField;
        }
        set {
            this.targetportField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="hyperedge.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("hyperedge", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class hyperedgetype {
    
    private string descField;
    
    private object[] itemsField;
    
    private graphtype graphField;
    
    private string idField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("endpoint", typeof(endpointtype))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    public graphtype graph {
        get {
            return this.graphField;
        }
        set {
            this.graphField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="endpoint.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("endpoint", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class endpointtype {
    
    private string descField;
    
    private string idField;
    
    private string portField;
    
    private string nodeField;
    
    private endpointtypetype typeField;
    
    public endpointtype() {
        this.typeField = endpointtypetype.undir;
    }
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string port {
        get {
            return this.portField;
        }
        set {
            this.portField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string node {
        get {
            return this.nodeField;
        }
        set {
            this.nodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(endpointtypetype.undir)]
    public endpointtypetype type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="endpoint.type.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
public enum endpointtypetype {
    
    /// <remarks/>
    @in,
    
    /// <remarks/>
    @out,
    
    /// <remarks/>
    undir,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="node.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("node", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class nodetype {
    
    private string descField;
    
    private object[] itemsField;
    
    private string idField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("graph", typeof(graphtype))]
    [System.Xml.Serialization.XmlElementAttribute("locator", typeof(locatortype))]
    [System.Xml.Serialization.XmlElementAttribute("port", typeof(porttype))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="port.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("port", Namespace="http://graphml.graphdrawing.org/xmlns", IsNullable=false)]
public partial class porttype {
    
    private string descField;
    
    private object[] itemsField;
    
    private string nameField;
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("port", typeof(porttype))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="graph.edgedefault.type", Namespace="http://graphml.graphdrawing.org/xmlns")]
public enum graphedgedefaulttype {
    
    /// <remarks/>
    directed,
    
    /// <remarks/>
    undirected,
}