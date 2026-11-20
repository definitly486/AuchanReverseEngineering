using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace System.Xml;

[DebuggerDisplay("{debuggerDisplayProxy}")]
public abstract class XmlNode : ICloneable, IEnumerable
{
	[DebuggerDisplay("{ToString()}")]
	internal readonly struct DebuggerDisplayXmlNodeProxy
	{
		private readonly XmlNode _node;

		public DebuggerDisplayXmlNodeProxy(XmlNode node)
		{
			_node = node;
		}

		public override string ToString()
		{
			XmlNodeType nodeType = _node.NodeType;
			string text = nodeType.ToString();
			switch (nodeType)
			{
			case XmlNodeType.Element:
			case XmlNodeType.EntityReference:
				text = text + ", Name=\"" + _node.Name + "\"";
				break;
			case XmlNodeType.Attribute:
			case XmlNodeType.ProcessingInstruction:
				text += $", Name=\"{_node.Name}\", Value=\"{XmlConvert.EscapeValueForDebuggerDisplay(_node.Value)}\"";
				break;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Comment:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
			case XmlNodeType.XmlDeclaration:
				text = text + ", Value=\"" + XmlConvert.EscapeValueForDebuggerDisplay(_node.Value) + "\"";
				break;
			case XmlNodeType.DocumentType:
			{
				XmlDocumentType xmlDocumentType = (XmlDocumentType)_node;
				text += $", Name=\"{xmlDocumentType.Name}\", SYSTEM=\"{xmlDocumentType.SystemId}\", PUBLIC=\"{xmlDocumentType.PublicId}\", Value=\"{XmlConvert.EscapeValueForDebuggerDisplay(xmlDocumentType.InternalSubset)}\"";
				break;
			}
			}
			return text;
		}
	}

	internal XmlNode parentNode;

	public abstract string Name { get; }

	public virtual string? Value
	{
		get
		{
			return null;
		}
		set
		{
			throw new InvalidOperationException(System.SR.Format(CultureInfo.InvariantCulture, "Xdom_Node_SetVal", NodeType.ToString()));
		}
	}

	public abstract XmlNodeType NodeType { get; }

	public virtual XmlNode? ParentNode
	{
		get
		{
			if (parentNode.NodeType != XmlNodeType.Document)
			{
				return parentNode;
			}
			if (parentNode.FirstChild is XmlLinkedNode xmlLinkedNode)
			{
				XmlLinkedNode xmlLinkedNode2 = xmlLinkedNode;
				do
				{
					if (xmlLinkedNode2 == this)
					{
						return parentNode;
					}
					xmlLinkedNode2 = xmlLinkedNode2.next;
				}
				while (xmlLinkedNode2 != null && xmlLinkedNode2 != xmlLinkedNode);
			}
			return null;
		}
	}

	public virtual XmlNodeList ChildNodes => new XmlChildNodes(this);

	public virtual XmlNode? PreviousSibling => null;

	public virtual XmlNode? NextSibling => null;

	public virtual XmlAttributeCollection? Attributes => null;

	public virtual XmlDocument? OwnerDocument
	{
		get
		{
			if (parentNode.NodeType == XmlNodeType.Document)
			{
				return (XmlDocument)parentNode;
			}
			return parentNode.OwnerDocument;
		}
	}

	public virtual XmlNode? FirstChild => LastNode?.next;

	public virtual XmlNode? LastChild => LastNode;

	internal virtual bool IsContainer => false;

	internal virtual XmlLinkedNode? LastNode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool HasChildNodes => LastNode != null;

	public virtual string NamespaceURI => string.Empty;

	public virtual string Prefix
	{
		get
		{
			return string.Empty;
		}
		[param: AllowNull]
		set
		{
		}
	}

	public abstract string LocalName { get; }

	public virtual bool IsReadOnly => HasReadOnlyParent(this);

	public virtual string InnerText
	{
		get
		{
			XmlNode firstChild = FirstChild;
			if (firstChild == null)
			{
				return string.Empty;
			}
			if (firstChild.NextSibling == null)
			{
				XmlNodeType nodeType = firstChild.NodeType;
				if ((uint)(nodeType - 3) <= 1u || (uint)(nodeType - 13) <= 1u)
				{
					return firstChild.Value;
				}
			}
			StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
			AppendChildText(stringBuilder);
			return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
		}
		set
		{
			XmlNode firstChild = FirstChild;
			if (firstChild != null && firstChild.NextSibling == null && firstChild.NodeType == XmlNodeType.Text)
			{
				firstChild.Value = value;
				return;
			}
			RemoveAll();
			AppendChild(OwnerDocument.CreateTextNode(value));
		}
	}

	public virtual string OuterXml
	{
		get
		{
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			XmlDOMTextWriter xmlDOMTextWriter = new XmlDOMTextWriter(stringWriter);
			try
			{
				WriteTo(xmlDOMTextWriter);
			}
			finally
			{
				xmlDOMTextWriter.Close();
			}
			return stringWriter.ToString();
		}
	}

	public virtual string InnerXml
	{
		get
		{
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			XmlDOMTextWriter xmlDOMTextWriter = new XmlDOMTextWriter(stringWriter);
			try
			{
				WriteContentTo(xmlDOMTextWriter);
			}
			finally
			{
				xmlDOMTextWriter.Close();
			}
			return stringWriter.ToString();
		}
		set
		{
			throw new InvalidOperationException("Xdom_Set_InnerXml");
		}
	}

	public virtual IXmlSchemaInfo SchemaInfo => XmlDocument.NotKnownSchemaInfo;

	public virtual string BaseURI
	{
		get
		{
			for (XmlNode xmlNode = ParentNode; xmlNode != null; xmlNode = xmlNode.ParentNode)
			{
				switch (xmlNode.NodeType)
				{
				case XmlNodeType.EntityReference:
					return ((XmlEntityReference)xmlNode).ChildBaseURI;
				case XmlNodeType.Attribute:
				case XmlNodeType.Entity:
				case XmlNodeType.Document:
					return xmlNode.BaseURI;
				}
			}
			return string.Empty;
		}
	}

	internal XmlDocument Document
	{
		get
		{
			if (NodeType == XmlNodeType.Document)
			{
				return (XmlDocument)this;
			}
			return OwnerDocument;
		}
	}

	public virtual XmlElement? this[string name]
	{
		get
		{
			for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == name)
				{
					return (XmlElement)xmlNode;
				}
			}
			return null;
		}
	}

	public virtual XmlElement? this[string localname, string ns]
	{
		get
		{
			for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.LocalName == localname && xmlNode.NamespaceURI == ns)
				{
					return (XmlElement)xmlNode;
				}
			}
			return null;
		}
	}

	internal virtual XmlSpace XmlSpace
	{
		get
		{
			XmlNode xmlNode = this;
			do
			{
				if (xmlNode is XmlElement xmlElement && xmlElement.HasAttribute("xml:space"))
				{
					ReadOnlySpan<char> span = xmlElement.GetAttribute("xml:space").AsSpan().Trim(XmlConvert.WhitespaceChars);
					if (span.SequenceEqual("default".AsSpan()))
					{
						return XmlSpace.Default;
					}
					if (span.SequenceEqual("preserve".AsSpan()))
					{
						return XmlSpace.Preserve;
					}
				}
				xmlNode = xmlNode.ParentNode;
			}
			while (xmlNode != null);
			return XmlSpace.None;
		}
	}

	internal virtual string XmlLang
	{
		get
		{
			XmlNode xmlNode = this;
			do
			{
				if (xmlNode is XmlElement xmlElement && xmlElement.HasAttribute("xml:lang"))
				{
					return xmlElement.GetAttribute("xml:lang");
				}
				xmlNode = xmlNode.ParentNode;
			}
			while (xmlNode != null);
			return string.Empty;
		}
	}

	internal virtual bool IsText => false;

	public virtual XmlNode? PreviousText => null;

	private object debuggerDisplayProxy => new DebuggerDisplayXmlNodeProxy(this);

	internal XmlNode()
	{
	}

	internal XmlNode(XmlDocument doc)
	{
		if (doc == null)
		{
			throw new ArgumentException("Xdom_Node_Null_Doc");
		}
		parentNode = doc;
	}

	internal bool AncestorNode(XmlNode node)
	{
		XmlNode xmlNode = ParentNode;
		while (xmlNode != null && xmlNode != this)
		{
			if (xmlNode == node)
			{
				return true;
			}
			xmlNode = xmlNode.ParentNode;
		}
		return false;
	}

	public virtual XmlNode? InsertBefore(XmlNode newChild, XmlNode? refChild)
	{
		if (this == newChild || AncestorNode(newChild))
		{
			throw new ArgumentException("Xdom_Node_Insert_Child");
		}
		if (refChild == null)
		{
			return AppendChild(newChild);
		}
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Contain");
		}
		if (refChild.ParentNode != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Path");
		}
		if (newChild == refChild)
		{
			return newChild;
		}
		XmlDocument ownerDocument = newChild.OwnerDocument;
		XmlDocument ownerDocument2 = OwnerDocument;
		if (ownerDocument != null && ownerDocument != ownerDocument2 && ownerDocument != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Context");
		}
		if (!CanInsertBefore(newChild, refChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		newChild.ParentNode?.RemoveChild(newChild);
		if (newChild.NodeType == XmlNodeType.DocumentFragment)
		{
			XmlNode firstChild;
			XmlNode result = (firstChild = newChild.FirstChild);
			if (firstChild != null)
			{
				newChild.RemoveChild(firstChild);
				InsertBefore(firstChild, refChild);
				InsertAfter(newChild, firstChild);
			}
			return result;
		}
		if (!(newChild is XmlLinkedNode) || !IsValidChildType(newChild.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)newChild;
		XmlLinkedNode xmlLinkedNode2 = (XmlLinkedNode)refChild;
		string value = newChild.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(newChild, newChild.ParentNode, this, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		if (xmlLinkedNode2 == FirstChild)
		{
			xmlLinkedNode.next = xmlLinkedNode2;
			LastNode.next = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (xmlLinkedNode.IsText && xmlLinkedNode2.IsText)
			{
				NestTextNodes(xmlLinkedNode, xmlLinkedNode2);
			}
		}
		else
		{
			XmlLinkedNode xmlLinkedNode3 = (XmlLinkedNode)xmlLinkedNode2.PreviousSibling;
			xmlLinkedNode.next = xmlLinkedNode2;
			xmlLinkedNode3.next = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (xmlLinkedNode3.IsText)
			{
				if (xmlLinkedNode.IsText)
				{
					NestTextNodes(xmlLinkedNode3, xmlLinkedNode);
					if (xmlLinkedNode2.IsText)
					{
						NestTextNodes(xmlLinkedNode, xmlLinkedNode2);
					}
				}
				else if (xmlLinkedNode2.IsText)
				{
					UnnestTextNodes(xmlLinkedNode3, xmlLinkedNode2);
				}
			}
			else if (xmlLinkedNode.IsText && xmlLinkedNode2.IsText)
			{
				NestTextNodes(xmlLinkedNode, xmlLinkedNode2);
			}
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return xmlLinkedNode;
	}

	public virtual XmlNode? InsertAfter(XmlNode newChild, XmlNode? refChild)
	{
		if (this == newChild || AncestorNode(newChild))
		{
			throw new ArgumentException("Xdom_Node_Insert_Child");
		}
		if (refChild == null)
		{
			return PrependChild(newChild);
		}
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Contain");
		}
		if (refChild.ParentNode != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Path");
		}
		if (newChild == refChild)
		{
			return newChild;
		}
		XmlDocument ownerDocument = newChild.OwnerDocument;
		XmlDocument ownerDocument2 = OwnerDocument;
		if (ownerDocument != null && ownerDocument != ownerDocument2 && ownerDocument != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Context");
		}
		if (!CanInsertAfter(newChild, refChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		newChild.ParentNode?.RemoveChild(newChild);
		if (newChild.NodeType == XmlNodeType.DocumentFragment)
		{
			XmlNode refChild2 = refChild;
			XmlNode firstChild = newChild.FirstChild;
			XmlNode xmlNode = firstChild;
			while (xmlNode != null)
			{
				XmlNode? nextSibling = xmlNode.NextSibling;
				newChild.RemoveChild(xmlNode);
				InsertAfter(xmlNode, refChild2);
				refChild2 = xmlNode;
				xmlNode = nextSibling;
			}
			return firstChild;
		}
		if (!(newChild is XmlLinkedNode) || !IsValidChildType(newChild.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)newChild;
		XmlLinkedNode xmlLinkedNode2 = (XmlLinkedNode)refChild;
		string value = newChild.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(newChild, newChild.ParentNode, this, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		if (xmlLinkedNode2 == LastNode)
		{
			xmlLinkedNode.next = xmlLinkedNode2.next;
			xmlLinkedNode2.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (xmlLinkedNode2.IsText && xmlLinkedNode.IsText)
			{
				NestTextNodes(xmlLinkedNode2, xmlLinkedNode);
			}
		}
		else
		{
			XmlLinkedNode xmlLinkedNode3 = (xmlLinkedNode.next = xmlLinkedNode2.next);
			xmlLinkedNode2.next = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (xmlLinkedNode2.IsText)
			{
				if (xmlLinkedNode.IsText)
				{
					NestTextNodes(xmlLinkedNode2, xmlLinkedNode);
					if (xmlLinkedNode3.IsText)
					{
						NestTextNodes(xmlLinkedNode, xmlLinkedNode3);
					}
				}
				else if (xmlLinkedNode3.IsText)
				{
					UnnestTextNodes(xmlLinkedNode2, xmlLinkedNode3);
				}
			}
			else if (xmlLinkedNode.IsText && xmlLinkedNode3.IsText)
			{
				NestTextNodes(xmlLinkedNode, xmlLinkedNode3);
			}
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return xmlLinkedNode;
	}

	public virtual XmlNode RemoveChild(XmlNode oldChild)
	{
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Remove_Contain");
		}
		if (oldChild.ParentNode != this)
		{
			throw new ArgumentException("Xdom_Node_Remove_Child");
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)oldChild;
		string value = xmlLinkedNode.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(xmlLinkedNode, this, null, value, value, XmlNodeChangedAction.Remove);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		XmlLinkedNode lastNode = LastNode;
		if (xmlLinkedNode == FirstChild)
		{
			if (xmlLinkedNode == lastNode)
			{
				LastNode = null;
				xmlLinkedNode.next = null;
				xmlLinkedNode.SetParent(null);
			}
			else
			{
				XmlLinkedNode next = xmlLinkedNode.next;
				if (next.IsText && xmlLinkedNode.IsText)
				{
					UnnestTextNodes(xmlLinkedNode, next);
				}
				lastNode.next = next;
				xmlLinkedNode.next = null;
				xmlLinkedNode.SetParent(null);
			}
		}
		else if (xmlLinkedNode == lastNode)
		{
			XmlLinkedNode xmlLinkedNode2 = (XmlLinkedNode)xmlLinkedNode.PreviousSibling;
			xmlLinkedNode2.next = xmlLinkedNode.next;
			LastNode = xmlLinkedNode2;
			xmlLinkedNode.next = null;
			xmlLinkedNode.SetParent(null);
		}
		else
		{
			XmlLinkedNode xmlLinkedNode3 = (XmlLinkedNode)xmlLinkedNode.PreviousSibling;
			XmlLinkedNode next2 = xmlLinkedNode.next;
			if (next2.IsText)
			{
				if (xmlLinkedNode3.IsText)
				{
					NestTextNodes(xmlLinkedNode3, next2);
				}
				else if (xmlLinkedNode.IsText)
				{
					UnnestTextNodes(xmlLinkedNode, next2);
				}
			}
			xmlLinkedNode3.next = next2;
			xmlLinkedNode.next = null;
			xmlLinkedNode.SetParent(null);
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return oldChild;
	}

	public virtual XmlNode? PrependChild(XmlNode newChild)
	{
		return InsertBefore(newChild, FirstChild);
	}

	public virtual XmlNode? AppendChild(XmlNode newChild)
	{
		XmlDocument xmlDocument = OwnerDocument ?? (this as XmlDocument);
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Contain");
		}
		if (this == newChild || AncestorNode(newChild))
		{
			throw new ArgumentException("Xdom_Node_Insert_Child");
		}
		newChild.ParentNode?.RemoveChild(newChild);
		XmlDocument ownerDocument = newChild.OwnerDocument;
		if (ownerDocument != null && ownerDocument != xmlDocument && ownerDocument != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Context");
		}
		if (newChild.NodeType == XmlNodeType.DocumentFragment)
		{
			XmlNode firstChild = newChild.FirstChild;
			XmlNode xmlNode = firstChild;
			while (xmlNode != null)
			{
				XmlNode? nextSibling = xmlNode.NextSibling;
				newChild.RemoveChild(xmlNode);
				AppendChild(xmlNode);
				xmlNode = nextSibling;
			}
			return firstChild;
		}
		if (!(newChild is XmlLinkedNode) || !IsValidChildType(newChild.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		if (!CanInsertAfter(newChild, LastChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		string value = newChild.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(newChild, newChild.ParentNode, this, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		XmlLinkedNode lastNode = LastNode;
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)newChild;
		if (lastNode == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
		}
		else
		{
			xmlLinkedNode.next = lastNode.next;
			lastNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (lastNode.IsText && xmlLinkedNode.IsText)
			{
				NestTextNodes(lastNode, xmlLinkedNode);
			}
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return xmlLinkedNode;
	}

	internal virtual XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc)
	{
		XmlNodeChangedEventArgs insertEventArgsForLoad = doc.GetInsertEventArgsForLoad(newChild, this);
		if (insertEventArgsForLoad != null)
		{
			doc.BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode lastNode = LastNode;
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)newChild;
		if (lastNode == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParentForLoad(this);
		}
		else
		{
			xmlLinkedNode.next = lastNode.next;
			lastNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			if (lastNode.IsText && xmlLinkedNode.IsText)
			{
				NestTextNodes(lastNode, xmlLinkedNode);
			}
			else
			{
				xmlLinkedNode.SetParentForLoad(this);
			}
		}
		if (insertEventArgsForLoad != null)
		{
			doc.AfterEvent(insertEventArgsForLoad);
		}
		return xmlLinkedNode;
	}

	internal virtual bool IsValidChildType(XmlNodeType type)
	{
		return false;
	}

	internal virtual bool CanInsertBefore(XmlNode newChild, XmlNode refChild)
	{
		return true;
	}

	internal virtual bool CanInsertAfter(XmlNode newChild, XmlNode refChild)
	{
		return true;
	}

	public abstract XmlNode CloneNode(bool deep);

	internal virtual void CopyChildren(XmlDocument doc, XmlNode container, bool deep)
	{
		for (XmlNode xmlNode = container.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			AppendChildForLoad(xmlNode.CloneNode(deep), doc);
		}
	}

	internal static bool HasReadOnlyParent(XmlNode n)
	{
		while (n != null)
		{
			switch (n.NodeType)
			{
			case XmlNodeType.EntityReference:
			case XmlNodeType.Entity:
				return true;
			case XmlNodeType.Attribute:
				n = ((XmlAttribute)n).OwnerElement;
				break;
			default:
				n = n.ParentNode;
				break;
			}
		}
		return false;
	}

	object ICloneable.Clone()
	{
		return CloneNode(deep: true);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new XmlChildEnumerator(this);
	}

	public IEnumerator GetEnumerator()
	{
		return new XmlChildEnumerator(this);
	}

	private void AppendChildText(StringBuilder builder)
	{
		for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.FirstChild == null)
			{
				if (xmlNode.NodeType == XmlNodeType.Text || xmlNode.NodeType == XmlNodeType.CDATA || xmlNode.NodeType == XmlNodeType.Whitespace || xmlNode.NodeType == XmlNodeType.SignificantWhitespace)
				{
					builder.Append(xmlNode.InnerText);
				}
			}
			else
			{
				xmlNode.AppendChildText(builder);
			}
		}
	}

	public abstract void WriteTo(XmlWriter w);

	public abstract void WriteContentTo(XmlWriter w);

	public virtual void RemoveAll()
	{
		XmlNode xmlNode = FirstChild;
		while (xmlNode != null)
		{
			XmlNode? nextSibling = xmlNode.NextSibling;
			RemoveChild(xmlNode);
			xmlNode = nextSibling;
		}
	}

	public virtual string GetPrefixOfNamespace(string namespaceURI)
	{
		return GetPrefixOfNamespaceStrict(namespaceURI) ?? string.Empty;
	}

	internal string GetPrefixOfNamespaceStrict(string namespaceURI)
	{
		XmlDocument document = Document;
		if (document != null)
		{
			namespaceURI = document.NameTable.Add(namespaceURI);
			XmlNode xmlNode = this;
			while (xmlNode != null)
			{
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.HasAttributes)
					{
						XmlAttributeCollection attributes = xmlElement.Attributes;
						for (int i = 0; i < attributes.Count; i++)
						{
							XmlAttribute xmlAttribute = attributes[i];
							if (xmlAttribute.Prefix.Length == 0)
							{
								if (Ref.Equal(xmlAttribute.LocalName, document.strXmlns) && xmlAttribute.Value == namespaceURI)
								{
									return string.Empty;
								}
							}
							else if (Ref.Equal(xmlAttribute.Prefix, document.strXmlns))
							{
								if (xmlAttribute.Value == namespaceURI)
								{
									return xmlAttribute.LocalName;
								}
							}
							else if (Ref.Equal(xmlAttribute.NamespaceURI, namespaceURI))
							{
								return xmlAttribute.Prefix;
							}
						}
					}
					if (Ref.Equal(xmlNode.NamespaceURI, namespaceURI))
					{
						return xmlNode.Prefix;
					}
					xmlNode = xmlNode.ParentNode;
				}
				else
				{
					xmlNode = ((xmlNode.NodeType != XmlNodeType.Attribute) ? xmlNode.ParentNode : ((XmlAttribute)xmlNode).OwnerElement);
				}
			}
			if (Ref.Equal(document.strReservedXml, namespaceURI))
			{
				return document.strXml;
			}
			if (Ref.Equal(document.strReservedXmlns, namespaceURI))
			{
				return document.strXmlns;
			}
		}
		return null;
	}

	internal virtual void SetParent(XmlNode node)
	{
		if (node == null)
		{
			parentNode = OwnerDocument;
		}
		else
		{
			parentNode = node;
		}
	}

	internal virtual void SetParentForLoad(XmlNode node)
	{
		parentNode = node;
	}

	internal static void SplitName(string name, out string prefix, out string localName)
	{
		int num = name.IndexOf(':');
		if (-1 == num || num == 0 || name.Length - 1 == num)
		{
			prefix = string.Empty;
			localName = name;
		}
		else
		{
			prefix = name.Substring(0, num);
			localName = name.Substring(num + 1);
		}
	}

	internal virtual XmlNode FindChild(XmlNodeType type)
	{
		for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.NodeType == type)
			{
				return xmlNode;
			}
		}
		return null;
	}

	internal virtual XmlNodeChangedEventArgs GetEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action)
	{
		XmlDocument ownerDocument = OwnerDocument;
		if (ownerDocument != null)
		{
			if (!ownerDocument.IsLoading && ((newParent != null && newParent.IsReadOnly) || (oldParent != null && oldParent.IsReadOnly)))
			{
				throw new InvalidOperationException("Xdom_Node_Modify_ReadOnly");
			}
			return ownerDocument.GetEventArgs(node, oldParent, newParent, oldValue, newValue, action);
		}
		return null;
	}

	internal virtual void BeforeEvent(XmlNodeChangedEventArgs args)
	{
		if (args != null)
		{
			OwnerDocument.BeforeEvent(args);
		}
	}

	internal virtual void AfterEvent(XmlNodeChangedEventArgs args)
	{
		if (args != null)
		{
			OwnerDocument.AfterEvent(args);
		}
	}

	internal static void NestTextNodes(XmlNode prevNode, XmlNode nextNode)
	{
		nextNode.parentNode = prevNode;
	}

	internal static void UnnestTextNodes(XmlNode prevNode, XmlNode nextNode)
	{
		nextNode.parentNode = prevNode.ParentNode;
	}
}
