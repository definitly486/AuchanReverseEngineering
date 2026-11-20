using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Xml.Linq;

[XmlSchemaProvider(null, IsAny = true)]
[TypeDescriptionProvider("MS.Internal.Xml.Linq.ComponentModel.XTypeDescriptionProvider`1[[System.Xml.Linq.XElement, System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.ComponentModel.TypeConverter")]
public class XElement : XContainer, IXmlSerializable
{
	internal XName name;

	internal XAttribute lastAttr;

	public static IEnumerable<XElement> EmptySequence => Array.Empty<XElement>();

	public XAttribute? FirstAttribute => lastAttr?.next;

	public bool HasAttributes => lastAttr != null;

	public bool HasElements
	{
		get
		{
			XNode xNode = content as XNode;
			if (xNode != null)
			{
				do
				{
					if (xNode is XElement)
					{
						return true;
					}
					xNode = xNode.next;
				}
				while (xNode != content);
			}
			return false;
		}
	}

	public bool IsEmpty => content == null;

	public XAttribute? LastAttribute => lastAttr;

	public XName Name
	{
		get
		{
			return name;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Name);
			name = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Name);
			}
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Element;

	public string Value
	{
		get
		{
			if (content == null)
			{
				return string.Empty;
			}
			if (content is string result)
			{
				return result;
			}
			StringBuilder sb = System.Text.StringBuilderCache.Acquire();
			AppendText(sb);
			return System.Text.StringBuilderCache.GetStringAndRelease(sb);
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			RemoveNodes();
			Add(value);
		}
	}

	public XElement(XName name)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		this.name = name;
	}

	public XElement(XElement other)
		: base(other)
	{
		name = other.name;
		XAttribute xAttribute = other.lastAttr;
		if (xAttribute != null)
		{
			do
			{
				xAttribute = xAttribute.next;
				AppendAttributeSkipNotify(new XAttribute(xAttribute));
			}
			while (xAttribute != other.lastAttr);
		}
	}

	public XElement(XStreamingElement other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		name = other.name;
		AddContentSkipNotify(other.content);
	}

	public XAttribute? Attribute(XName name)
	{
		XAttribute xAttribute = lastAttr;
		if (xAttribute != null)
		{
			do
			{
				xAttribute = xAttribute.next;
				if (xAttribute.name == name)
				{
					return xAttribute;
				}
			}
			while (xAttribute != lastAttr);
		}
		return null;
	}

	public IEnumerable<XAttribute> Attributes()
	{
		return GetAttributes(null);
	}

	public string? GetPrefixOfNamespace(XNamespace ns)
	{
		ArgumentNullException.ThrowIfNull(ns, "ns");
		string namespaceName = ns.NamespaceName;
		bool flag = false;
		XElement xElement = this;
		do
		{
			XAttribute xAttribute = xElement.lastAttr;
			if (xAttribute != null)
			{
				bool flag2 = false;
				do
				{
					xAttribute = xAttribute.next;
					if (xAttribute.IsNamespaceDeclaration)
					{
						if (xAttribute.Value == namespaceName && xAttribute.Name.NamespaceName.Length != 0 && (!flag || GetNamespaceOfPrefixInScope(xAttribute.Name.LocalName, xElement) == null))
						{
							return xAttribute.Name.LocalName;
						}
						flag2 = true;
					}
				}
				while (xAttribute != xElement.lastAttr);
				flag = flag || flag2;
			}
			xElement = xElement.parent as XElement;
		}
		while (xElement != null);
		if ((object)namespaceName == "http://www.w3.org/XML/1998/namespace")
		{
			if (!flag || GetNamespaceOfPrefixInScope("xml", null) == null)
			{
				return "xml";
			}
		}
		else if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
		{
			return "xmlns";
		}
		return null;
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		new ElementWriter(writer).WriteElement(this);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator string?(XElement? element)
	{
		return element?.Value;
	}

	[CLSCompliant(false)]
	public static explicit operator bool(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToBoolean(element.Value.ToLowerInvariant());
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator bool?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToBoolean(element.Value.ToLowerInvariant());
	}

	[CLSCompliant(false)]
	public static explicit operator int(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToInt32(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator int?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToInt32(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator uint(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToUInt32(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator uint?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToUInt32(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator long(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToInt64(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator long?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToInt64(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator ulong(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToUInt64(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator ulong?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToUInt64(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator float(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToSingle(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator float?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToSingle(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator double(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToDouble(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator double?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToDouble(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator decimal(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToDecimal(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator decimal?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToDecimal(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator DateTime(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return DateTime.Parse(element.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator DateTime?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return DateTime.Parse(element.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
	}

	[CLSCompliant(false)]
	public static explicit operator DateTimeOffset(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToDateTimeOffset(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator DateTimeOffset?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToDateTimeOffset(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator TimeSpan(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToTimeSpan(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator TimeSpan?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToTimeSpan(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator Guid(XElement element)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		return XmlConvert.ToGuid(element.Value);
	}

	[CLSCompliant(false)]
	[return: NotNullIfNotNull("element")]
	public static explicit operator Guid?(XElement? element)
	{
		if (element == null)
		{
			return null;
		}
		return XmlConvert.ToGuid(element.Value);
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		ArgumentNullException.ThrowIfNull(reader, "reader");
		if (parent != null || annotations != null || content != null || lastAttr != null)
		{
			throw new InvalidOperationException("InvalidOperation_DeserializeInstance");
		}
		if (reader.MoveToContent() != XmlNodeType.Element)
		{
			throw new InvalidOperationException(System.SR.Format("InvalidOperation_ExpectedNodeType", XmlNodeType.Element, reader.NodeType));
		}
		ReadElementFrom(reader, LoadOptions.None);
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		WriteTo(writer);
	}

	internal override void AddAttribute(XAttribute a)
	{
		if (Attribute(a.Name) != null)
		{
			throw new InvalidOperationException("InvalidOperation_DuplicateAttribute");
		}
		if (a.parent != null)
		{
			a = new XAttribute(a);
		}
		AppendAttribute(a);
	}

	internal override void AddAttributeSkipNotify(XAttribute a)
	{
		if (Attribute(a.Name) != null)
		{
			throw new InvalidOperationException("InvalidOperation_DuplicateAttribute");
		}
		if (a.parent != null)
		{
			a = new XAttribute(a);
		}
		AppendAttributeSkipNotify(a);
	}

	internal void AppendAttribute(XAttribute a)
	{
		bool num = NotifyChanging(a, XObjectChangeEventArgs.Add);
		if (a.parent != null)
		{
			throw new InvalidOperationException("InvalidOperation_ExternalCode");
		}
		AppendAttributeSkipNotify(a);
		if (num)
		{
			NotifyChanged(a, XObjectChangeEventArgs.Add);
		}
	}

	internal void AppendAttributeSkipNotify(XAttribute a)
	{
		a.parent = this;
		if (lastAttr == null)
		{
			a.next = a;
		}
		else
		{
			a.next = lastAttr.next;
			lastAttr.next = a;
		}
		lastAttr = a;
	}

	internal override XNode CloneNode()
	{
		return new XElement(this);
	}

	private IEnumerable<XAttribute> GetAttributes(XName name)
	{
		XAttribute a = lastAttr;
		if (a == null)
		{
			yield break;
		}
		do
		{
			a = a.next;
			if (name == null || a.name == name)
			{
				yield return a;
			}
		}
		while (a.parent == this && a != lastAttr);
	}

	private string GetNamespaceOfPrefixInScope(string prefix, XElement outOfScope)
	{
		for (XElement xElement = this; xElement != outOfScope; xElement = xElement.parent as XElement)
		{
			XAttribute xAttribute = xElement.lastAttr;
			if (xAttribute != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					if (xAttribute.IsNamespaceDeclaration && xAttribute.Name.LocalName == prefix)
					{
						return xAttribute.Value;
					}
				}
				while (xAttribute != xElement.lastAttr);
			}
		}
		return null;
	}

	private void ReadElementFrom(XmlReader r, LoadOptions o)
	{
		ReadElementFromImpl(r, o);
		if (!r.IsEmptyElement)
		{
			r.Read();
			ReadContentFrom(r, o);
		}
		r.Read();
	}

	private void ReadElementFromImpl(XmlReader r, LoadOptions o)
	{
		if (r.ReadState != ReadState.Interactive)
		{
			throw new InvalidOperationException("InvalidOperation_ExpectedInteractive");
		}
		name = XNamespace.Get(r.NamespaceURI).GetName(r.LocalName);
		if ((o & LoadOptions.SetBaseUri) != LoadOptions.None)
		{
			string baseURI = r.BaseURI;
			if (!string.IsNullOrEmpty(baseURI))
			{
				SetBaseUri(baseURI);
			}
		}
		IXmlLineInfo xmlLineInfo = null;
		if ((o & LoadOptions.SetLineInfo) != LoadOptions.None)
		{
			xmlLineInfo = r as IXmlLineInfo;
			if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
			{
				SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
			}
		}
		if (!r.MoveToFirstAttribute())
		{
			return;
		}
		do
		{
			XAttribute xAttribute = new XAttribute(XNamespace.Get((r.Prefix.Length == 0) ? string.Empty : r.NamespaceURI).GetName(r.LocalName), r.Value);
			if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
			{
				xAttribute.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
			}
			AppendAttributeSkipNotify(xAttribute);
		}
		while (r.MoveToNextAttribute());
		r.MoveToElement();
	}

	internal void SetEndElementLineInfo(int lineNumber, int linePosition)
	{
		AddAnnotation(new LineInfoEndElementAnnotation(lineNumber, linePosition));
	}

	internal override void ValidateNode(XNode node, XNode previous)
	{
		if (node is XDocument)
		{
			throw new ArgumentException(System.SR.Format("Argument_AddNode", XmlNodeType.Document));
		}
		if (node is XDocumentType)
		{
			throw new ArgumentException(System.SR.Format("Argument_AddNode", XmlNodeType.DocumentType));
		}
	}
}
