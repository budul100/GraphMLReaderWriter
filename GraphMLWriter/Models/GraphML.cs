#pragma warning disable IDE1006 // Benennungsstile
#pragma warning disable CA1819 // Eigenschaften dürfen keine Arrays zurückgeben
#pragma warning disable CA1720 // Bezeichner enthält Typnamen

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "endpoint.type.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
public enum endpointtypetype
{
    @in,

    @out,

    undir,
}

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "graph.edgedefault.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
public enum graphedgedefaulttype
{
    directed,

    undirected,
}

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "key.for.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
public enum keyfortype
{
    all,

    graphml,

    graph,

    node,

    edge,

    hyperedge,

    port,

    endpoint,
}

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "key.type.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
public enum keytypetype
{
    boolean,

    @int,

    @long,

    @float,

    @double,

    @string,
}

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/1999/xlink")]
public enum typeType
{
    simple,

    extended,

    title,

    resource,

    locator,

    arc,
}

[System.Xml.Serialization.XmlIncludeAttribute(typeof(defaulttype))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(datatype))]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "data-extension.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
public partial class dataextensiontype
{
    #region Public Properties

    [System.Xml.Serialization.XmlText()]
    public string Content { get; set; }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "data.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("data", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class datatype : dataextensiontype
{
    #region Private Fields

    private string idField;
    private string keyField;

    private long timeField;

    #endregion Private Fields

    #region Public Constructors

    public datatype()
    {
        this.timeField = ((long)(0));
    }

    #endregion Public Constructors

    #region Public Properties

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string key
    {
        get
        {
            return this.keyField;
        }
        set
        {
            this.keyField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
    public long time
    {
        get
        {
            return this.timeField;
        }
        set
        {
            this.timeField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "default.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("default", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class defaulttype : dataextensiontype
{
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "edge.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("edge", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class edgetype
{
    #region Private Fields

    private datatype[] dataField;
    private string descField;
    private bool directedField;
    private bool directedFieldSpecified;
    private graphtype graphField;

    private string idField;
    private string sourceField;

    private string sourceportField;
    private string targetField;
    private string targetportField;

    #endregion Private Fields

    #region Public Properties

    [System.Xml.Serialization.XmlElementAttribute("data")]
    public datatype[] data
    {
        get
        {
            return this.dataField;
        }
        set
        {
            this.dataField = value;
        }
    }

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool directed
    {
        get
        {
            return this.directedField;
        }
        set
        {
            this.directedField = value;
        }
    }

    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool directedSpecified
    {
        get
        {
            return this.directedFieldSpecified;
        }
        set
        {
            this.directedFieldSpecified = value;
        }
    }

    public graphtype graph
    {
        get
        {
            return this.graphField;
        }
        set
        {
            this.graphField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string source
    {
        get
        {
            return this.sourceField;
        }
        set
        {
            this.sourceField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string sourceport
    {
        get
        {
            return this.sourceportField;
        }
        set
        {
            this.sourceportField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string target
    {
        get
        {
            return this.targetField;
        }
        set
        {
            this.targetField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string targetport
    {
        get
        {
            return this.targetportField;
        }
        set
        {
            this.targetportField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "endpoint.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("endpoint", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class endpointtype
{
    #region Private Fields

    private string descField;

    private string idField;

    private string nodeField;
    private string portField;
    private endpointtypetype typeField;

    #endregion Private Fields

    #region Public Constructors

    public endpointtype()
    {
        this.typeField = endpointtypetype.undir;
    }

    #endregion Public Constructors

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string node
    {
        get
        {
            return this.nodeField;
        }
        set
        {
            this.nodeField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string port
    {
        get
        {
            return this.portField;
        }
        set
        {
            this.portField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(endpointtypetype.undir)]
    public endpointtypetype type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "graphml.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("graphml", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class graphmltype
{
    #region Private Fields

    private string descField;

    private object[] itemsField;
    private keytype[] keyField;

    #endregion Private Fields

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("graph", typeof(graphtype))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("key")]
    public keytype[] key
    {
        get
        {
            return this.keyField;
        }
        set
        {
            this.keyField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "graph.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("graph", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class graphtype
{
    #region Private Fields

    private string descField;

    private graphedgedefaulttype edgedefaultField;
    private string idField;
    private object[] itemsField;

    #endregion Private Fields

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public graphedgedefaulttype edgedefault
    {
        get
        {
            return this.edgedefaultField;
        }
        set
        {
            this.edgedefaultField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("edge", typeof(edgetype))]
    [System.Xml.Serialization.XmlElementAttribute("hyperedge", typeof(hyperedgetype))]
    [System.Xml.Serialization.XmlElementAttribute("locator", typeof(locatortype))]
    [System.Xml.Serialization.XmlElementAttribute("node", typeof(nodetype))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "hyperedge.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("hyperedge", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class hyperedgetype
{
    #region Private Fields

    private string descField;

    private graphtype graphField;
    private string idField;
    private object[] itemsField;

    #endregion Private Fields

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    public graphtype graph
    {
        get
        {
            return this.graphField;
        }
        set
        {
            this.graphField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("endpoint", typeof(endpointtype))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "key.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("key", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class keytype
{
    #region Private Fields

    private string attrnameField;
    private defaulttype defaultField;
    private string descField;
    private bool dynamicField;
    private keyfortype forField;
    private string idField;

    #endregion Private Fields

    #region Public Constructors

    public keytype()
    {
        this.dynamicField = false;
        this.forField = keyfortype.all;
    }

    #endregion Public Constructors

    #region Public Properties

    public defaulttype @default
    {
        get
        {
            return this.defaultField;
        }
        set
        {
            this.defaultField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(keyfortype.all)]
    public keyfortype @for
    {
        get
        {
            return this.forField;
        }
        set
        {
            this.forField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute("attr.name", DataType = "NMTOKEN")]
    public string attrname
    {
        get
        {
            return this.attrnameField;
        }
        set
        {
            this.attrnameField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute("attr.type")]
    public string attrtype { get; set; }

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool dynamic
    {
        get
        {
            return this.dynamicField;
        }
        set
        {
            this.dynamicField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "locator.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("locator", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class locatortype
{
    #region Private Fields

    private string hrefField;

    private typeType typeField;

    private bool typeFieldSpecified;

    #endregion Private Fields

    #region Public Properties

    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "anyURI")]
    public string href
    {
        get
        {
            return this.hrefField;
        }
        set
        {
            this.hrefField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    public typeType type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool typeSpecified
    {
        get
        {
            return this.typeFieldSpecified;
        }
        set
        {
            this.typeFieldSpecified = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "node.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("node", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class nodetype
{
    #region Private Fields

    private string descField;

    private string idField;
    private object[] itemsField;

    #endregion Private Fields

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("graph", typeof(graphtype))]
    [System.Xml.Serialization.XmlElementAttribute("locator", typeof(locatortype))]
    [System.Xml.Serialization.XmlElementAttribute("port", typeof(porttype))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    #endregion Public Properties
}

[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "port.type", Namespace = "http://graphml.graphdrawing.org/xmlns")]
[System.Xml.Serialization.XmlRootAttribute("port", Namespace = "http://graphml.graphdrawing.org/xmlns", IsNullable = false)]
public partial class porttype
{
    #region Private Fields

    private string descField;

    private object[] itemsField;

    private string nameField;

    #endregion Private Fields

    #region Public Properties

    public string desc
    {
        get
        {
            return this.descField;
        }
        set
        {
            this.descField = value;
        }
    }

    [System.Xml.Serialization.XmlElementAttribute("data", typeof(datatype))]
    [System.Xml.Serialization.XmlElementAttribute("port", typeof(porttype))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    #endregion Public Properties
}

#pragma warning restore CA1720 // Bezeichner enthält Typnamen
#pragma warning restore CA1819 // Eigenschaften dürfen keine Arrays zurückgeben
#pragma warning restore IDE1006 // Benennungsstile