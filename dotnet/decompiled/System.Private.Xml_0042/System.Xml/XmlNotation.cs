namespace System.Xml;

public class XmlNotation : XmlNode
{
	private readonly string _publicId;

	private readonly string _systemId;

	private readonly string _name;

	public override string Name => _name;

	public override string LocalName => _name;

	public override XmlNodeType NodeType => XmlNodeType.Notation;

	public override bool IsReadOnly => true;

	public override string OuterXml => string.Empty;

	public override string InnerXml
	{
		get
		{
			return string.Empty;
		}
		set
		{
			throw new InvalidOperationException("Xdom_Set_InnerXml");
		}
	}

	internal XmlNotation(string name, string publicId, string systemId, XmlDocument doc)
		: base(doc)
	{
		_name = doc.NameTable.Add(name);
		_publicId = publicId;
		_systemId = systemId;
	}

	public override XmlNode CloneNode(bool deep)
	{
		throw new InvalidOperationException("Xdom_Node_Cloning");
	}

	public override void WriteTo(XmlWriter w)
	{
	}

	public override void WriteContentTo(XmlWriter w)
	{
	}
}
