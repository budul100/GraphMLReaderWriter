REM "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\xsd.exe" xlink.xsd graphml-attributes.xsd graphml-parseinfo.xsd graphml-structure.xsd graphml.xsd /classes
REM "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\xsd.exe" .\xlink.xsd .\graphml_complete.xsd  /classes

"C:\Program Files (x86)\XmlSchemaClassGenerator\XmlSchemaClassGenerator.Console.exe" -o . -n http://graphml.graphdrawing.org/xmlns=GraphML -n http://www.w3.org/1999/xlink=XLink --nu --sf --csm=Public --ct=System.Array --dc ".\_XSD\graphml_complete.xsd"