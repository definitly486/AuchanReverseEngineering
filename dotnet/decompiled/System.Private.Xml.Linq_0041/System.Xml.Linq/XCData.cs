namespace System.Xml.Linq;

public class XCData : XText
{
	public override XmlNodeType NodeType => XmlNodeType.CDATA;

	public XCData(string value)
		: base(value)
	{
	}

	public XCData(XCData other)
		: base(other)
	{
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		writer.WriteCData(text);
	}

	internal override XNode CloneNode()
	{
		return new XCData(this);
	}
}
