namespace System.Xml.Linq;

public class XDocument : XContainer
{
	private XDeclaration _declaration;

	public XDeclaration? Declaration
	{
		get
		{
			return _declaration;
		}
		set
		{
			_declaration = value;
		}
	}

	public XDocumentType? DocumentType => GetFirstNode<XDocumentType>();

	public override XmlNodeType NodeType => XmlNodeType.Document;

	public XElement? Root => GetFirstNode<XElement>();

	public XDocument()
	{
	}

	public XDocument(XDocument other)
		: base(other)
	{
		if (other._declaration != null)
		{
			_declaration = new XDeclaration(other._declaration);
		}
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		if (_declaration != null && _declaration.Standalone == "yes")
		{
			writer.WriteStartDocument(standalone: true);
		}
		else if (_declaration != null && _declaration.Standalone == "no")
		{
			writer.WriteStartDocument(standalone: false);
		}
		else
		{
			writer.WriteStartDocument();
		}
		WriteContentTo(writer);
		writer.WriteEndDocument();
	}

	internal override void AddAttribute(XAttribute a)
	{
		throw new ArgumentException("Argument_AddAttribute");
	}

	internal override void AddAttributeSkipNotify(XAttribute a)
	{
		throw new ArgumentException("Argument_AddAttribute");
	}

	internal override XNode CloneNode()
	{
		return new XDocument(this);
	}

	private T GetFirstNode<T>() where T : XNode
	{
		XNode xNode = content as XNode;
		if (xNode != null)
		{
			do
			{
				xNode = xNode.next;
				if (xNode is T result)
				{
					return result;
				}
			}
			while (xNode != content);
		}
		return null;
	}

	internal override void ValidateNode(XNode node, XNode previous)
	{
		switch (node.NodeType)
		{
		case XmlNodeType.Text:
			ValidateString(((XText)node).Value);
			break;
		case XmlNodeType.Element:
			ValidateDocument(previous, XmlNodeType.DocumentType, XmlNodeType.None);
			break;
		case XmlNodeType.DocumentType:
			ValidateDocument(previous, XmlNodeType.None, XmlNodeType.Element);
			break;
		case XmlNodeType.CDATA:
			throw new ArgumentException(System.SR.Format("Argument_AddNode", XmlNodeType.CDATA));
		case XmlNodeType.Document:
			throw new ArgumentException(System.SR.Format("Argument_AddNode", XmlNodeType.Document));
		}
	}

	private void ValidateDocument(XNode previous, XmlNodeType allowBefore, XmlNodeType allowAfter)
	{
		XNode xNode = content as XNode;
		if (xNode == null)
		{
			return;
		}
		if (previous == null)
		{
			allowBefore = allowAfter;
		}
		do
		{
			xNode = xNode.next;
			XmlNodeType nodeType = xNode.NodeType;
			if (nodeType == XmlNodeType.Element || nodeType == XmlNodeType.DocumentType)
			{
				if (nodeType != allowBefore)
				{
					throw new InvalidOperationException("InvalidOperation_DocumentStructure");
				}
				allowBefore = XmlNodeType.None;
			}
			if (xNode == previous)
			{
				allowBefore = allowAfter;
			}
		}
		while (xNode != content);
	}

	internal override void ValidateString(string s)
	{
		if (s.AsSpan().ContainsAnyExcept(" \t\r\n".AsSpan()))
		{
			throw new ArgumentException("Argument_AddNonWhitespace");
		}
	}
}
