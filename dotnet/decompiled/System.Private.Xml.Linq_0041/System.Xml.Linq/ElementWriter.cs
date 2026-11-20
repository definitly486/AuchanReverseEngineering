namespace System.Xml.Linq;

internal struct ElementWriter
{
	private readonly XmlWriter _writer;

	private NamespaceResolver _resolver;

	public ElementWriter(XmlWriter writer)
	{
		_writer = writer;
		_resolver = default(NamespaceResolver);
	}

	public void WriteElement(XElement e)
	{
		PushAncestors(e);
		XNode xNode = e;
		while (true)
		{
			if (xNode is XElement xElement)
			{
				WriteStartElement(xElement);
				if (xElement.content == null)
				{
					WriteEndElement();
				}
				else
				{
					if (!(xElement.content is string text))
					{
						xNode = ((XNode)xElement.content).next;
						continue;
					}
					_writer.WriteString(text);
					WriteFullEndElement();
				}
			}
			else
			{
				xNode.WriteTo(_writer);
			}
			while (xNode != e && xNode == xNode.parent.content)
			{
				xNode = xNode.parent;
				WriteFullEndElement();
			}
			if (xNode != e)
			{
				xNode = xNode.next;
				continue;
			}
			break;
		}
	}

	private string GetPrefixOfNamespace(XNamespace ns, bool allowDefaultNamespace)
	{
		string namespaceName = ns.NamespaceName;
		if (namespaceName.Length == 0)
		{
			return string.Empty;
		}
		string prefixOfNamespace = _resolver.GetPrefixOfNamespace(ns, allowDefaultNamespace);
		if (prefixOfNamespace != null)
		{
			return prefixOfNamespace;
		}
		if ((object)namespaceName == "http://www.w3.org/XML/1998/namespace")
		{
			return "xml";
		}
		if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
		{
			return "xmlns";
		}
		return null;
	}

	private void PushAncestors(XElement e)
	{
		while (true)
		{
			e = e.parent as XElement;
			if (e == null)
			{
				break;
			}
			XAttribute xAttribute = e.lastAttr;
			if (xAttribute == null)
			{
				continue;
			}
			do
			{
				xAttribute = xAttribute.next;
				if (xAttribute.IsNamespaceDeclaration)
				{
					_resolver.AddFirst((xAttribute.Name.NamespaceName.Length == 0) ? string.Empty : xAttribute.Name.LocalName, XNamespace.Get(xAttribute.Value));
				}
			}
			while (xAttribute != e.lastAttr);
		}
	}

	private void PushElement(XElement e)
	{
		_resolver.PushScope();
		XAttribute xAttribute = e.lastAttr;
		if (xAttribute == null)
		{
			return;
		}
		do
		{
			xAttribute = xAttribute.next;
			if (xAttribute.IsNamespaceDeclaration)
			{
				_resolver.Add((xAttribute.Name.NamespaceName.Length == 0) ? string.Empty : xAttribute.Name.LocalName, XNamespace.Get(xAttribute.Value));
			}
		}
		while (xAttribute != e.lastAttr);
	}

	private void WriteEndElement()
	{
		_writer.WriteEndElement();
		_resolver.PopScope();
	}

	private void WriteFullEndElement()
	{
		_writer.WriteFullEndElement();
		_resolver.PopScope();
	}

	private void WriteStartElement(XElement e)
	{
		PushElement(e);
		XNamespace xNamespace = e.Name.Namespace;
		_writer.WriteStartElement(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: true), e.Name.LocalName, xNamespace.NamespaceName);
		XAttribute xAttribute = e.lastAttr;
		if (xAttribute != null)
		{
			do
			{
				xAttribute = xAttribute.next;
				xNamespace = xAttribute.Name.Namespace;
				string localName = xAttribute.Name.LocalName;
				string namespaceName = xNamespace.NamespaceName;
				_writer.WriteAttributeString(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: false), localName, (namespaceName.Length == 0 && localName == "xmlns") ? "http://www.w3.org/2000/xmlns/" : namespaceName, xAttribute.Value);
			}
			while (xAttribute != e.lastAttr);
		}
	}
}
