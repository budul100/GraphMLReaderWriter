# GraphMLReaderWriter

Class library for

* Serialization of objects into graphML files and,
* Deserialization graphML files back into objects.

The respective NuGet package can be found on https://github.com/budul100/GraphMLReaderWriter.

## Writing example

To write a graphML file there must be a graph containing nodes and edges. The nodes are linked by the edges.

```
internal class Node
{
    #region Public Properties

    [GraphMLReaderWriter.Attributes.Id]
    [GraphMLReaderWriter.Attributes.Data]
    public string Name { get; set; }

    #endregion Public Properties
}

internal class Edge
{
    #region Public Properties

    [GraphMLReaderWriter.Attributes.Source]
    public Node From { get; set; }

    [GraphMLReaderWriter.Attributes.Target]
    public Node To { get; set; }

    #endregion Public Properties
}

internal class Graph
{
    #region Public Properties

    [GraphMLReaderWriter.Attributes.Edges]
    public Edge[] Edges { get; set; }

    [GraphMLReaderWriter.Attributes.Nodes]
    public Node[] Nodes { get; set; }

    #endregion Public Properties
}

```

Nodes must have a string property marked with the `Id` attribute. The `Data` attribute of nodes marks all properties which are used to cover data content in the resulting graphML data.

Edges must have one node property marked with a `Source` attribute, this node represents the start of the edge. And edges must have one node property marked with a `Target` attribute, this node represents the end of the edge.

Nodes and edges must be combined in a joint class. The collection of nodes in this class must be marked with an `Nodes` attribute. The collection of edges in this class must be marked with an `Edges` attribute.

The graph can be serialized by using the `Writer`.

```
var nodeA = new Node
{
    Name = "a",
};

var nodeB = new Node
{
    Name = "b",
};

var nodeC = new Node
{
    Name = "c",
};

var edgeAB = new Edge
{
    From = nodeA,
    To = nodeB,
};

var edgeAC = new Edge
{
    From = nodeA,
    To = nodeC,
};

var graph = new Graph
{
    Edges = new Edge[] { edgeAB, edgeAC },
    Nodes = new Node[] { nodeA, nodeB, nodeC },
};

var writer = new Writer<Graph>();

writer.Save(
    input: graph,
    path: path);

```

The example above creates the following graphML file.

```
<?xml version="1.0" encoding="utf-8"?>
<graphml xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://graphml.graphdrawing.org/xmlns">
  <key id="Key-0" for="node" attr.name="Name" attr.type="string" />
  <key id="Key-1" for="graph" attr.name="Name" attr.type="string" />
  <graph id="Graph-0" edgedefault="directed">
    <node id="a">
      <data key="Key-0">a</data>
    </node>
    <node id="b">
      <data key="Key-0">b</data>
    </node>
    <node id="c">
      <data key="Key-0">c</data>
    </node>
    <edge id="Edge-1" source="a" target="b" />
    <edge id="Edge-2" source="a" target="c" />
  </graph>
</graphml>
```

## Reading example

An existing graphML file can be deserialized by using the `Reader`.

```
var reader = new Reader<Graph>();

var graph = reader.Load(
    path: path);
```