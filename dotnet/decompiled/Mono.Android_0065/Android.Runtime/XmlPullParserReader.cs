using System;
using System.Xml;
using Android.Content.Res;
using Java.Lang;
using Org.XmlPull.V1;

namespace Android.Runtime;

public class XmlPullParserReader : XmlReader, IXmlLineInfo
{
	private struct QName
	{
		public string LocalName;

		public string? Namespace;

		public QName(XmlPullParserReader r, string name)
		{
			int num = name.IndexOf(':');
			LocalName = ((num < 0) ? name : name.Substring(num + 1));
			Namespace = ((num < 0) ? string.Empty : r.LookupNamespace(name.Substring(0, num)));
		}
	}

	private IXmlPullParser source;

	private bool supports_ns;

	private bool supports_ns_report_as_attr;

	private XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());

	private bool started;

	private int ns_index;

	private int ns_count;

	private int attr_pos = -1;

	private bool attr_value;

	public nint Handle => source.Handle;

	public override int AttributeCount
	{
		get
		{
			int num = source.AttributeCount + ns_count;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}
	}

	public int LineNumber
	{
		get
		{
			if (!HasLineInfo())
			{
				return 0;
			}
			return source.LineNumber + 1;
		}
	}

	public int LinePosition
	{
		get
		{
			if (!HasLineInfo())
			{
				return 0;
			}
			return source.ColumnNumber + 1;
		}
	}

	public override string BaseURI => string.Empty;

	public override int Depth => source.Depth - 1 + ((attr_pos >= 0) ? ((!attr_value) ? 1 : 2) : 0);

	public override bool EOF => source.EventType == XmlPullParserNode.EndDocument;

	public override bool HasAttributes
	{
		get
		{
			if (source.AttributeCount <= 0)
			{
				return ns_count > 0;
			}
			return true;
		}
	}

	public override bool IsDefault
	{
		get
		{
			if (attr_pos < 0 || attr_pos >= source.AttributeCount)
			{
				return false;
			}
			return source.IsAttributeDefault(attr_pos);
		}
	}

	public override bool IsEmptyElement => source.IsEmptyElementTag;

	public override string? LocalName
	{
		get
		{
			if (attr_pos < 0)
			{
				return source.Name;
			}
			if (attr_pos < source.AttributeCount)
			{
				return source.GetAttributeName(attr_pos);
			}
			string namespacePrefix = source.GetNamespacePrefix(attr_pos - source.AttributeCount + ns_index);
			if (!string.IsNullOrEmpty(namespacePrefix))
			{
				return namespacePrefix;
			}
			return "xmlns";
		}
	}

	public override string? Name
	{
		get
		{
			if (!string.IsNullOrEmpty(Prefix))
			{
				return Prefix + ":" + LocalName;
			}
			return LocalName;
		}
	}

	public override XmlNameTable? NameTable => nsmgr.NameTable;

	public override string? NamespaceURI
	{
		get
		{
			if (attr_pos < 0)
			{
				return source.Namespace;
			}
			if (attr_pos < source.AttributeCount)
			{
				return source.GetAttributeNamespace(attr_pos);
			}
			return source.GetNamespaceUri(attr_pos - source.AttributeCount + ns_index);
		}
	}

	public override XmlNodeType NodeType
	{
		get
		{
			if (attr_value)
			{
				return XmlNodeType.Text;
			}
			if (attr_pos >= 0)
			{
				return XmlNodeType.Attribute;
			}
			switch (source.EventType)
			{
			case XmlPullParserNode.Cdsect:
				return XmlNodeType.CDATA;
			case XmlPullParserNode.Comment:
				return XmlNodeType.Comment;
			case XmlPullParserNode.Docdecl:
				return XmlNodeType.XmlDeclaration;
			case XmlPullParserNode.EndTag:
				return XmlNodeType.EndElement;
			case XmlPullParserNode.EntityRef:
				return XmlNodeType.EntityReference;
			case XmlPullParserNode.IgnorableWhitespace:
				return XmlNodeType.Whitespace;
			case XmlPullParserNode.ProcessingInstruction:
				return XmlNodeType.ProcessingInstruction;
			case XmlPullParserNode.StartTag:
				return XmlNodeType.Element;
			case XmlPullParserNode.Text:
				if (!source.IsWhitespace)
				{
					return XmlNodeType.Text;
				}
				return XmlNodeType.SignificantWhitespace;
			default:
				return XmlNodeType.None;
			}
		}
	}

	public override string? Prefix
	{
		get
		{
			if (NamespaceURI == null)
			{
				return null;
			}
			return nsmgr.LookupPrefix(NamespaceURI);
		}
	}

	public override ReadState ReadState
	{
		get
		{
			if (!started)
			{
				return ReadState.Initial;
			}
			if (EOF)
			{
				return ReadState.EndOfFile;
			}
			return ReadState.Interactive;
		}
	}

	public override string? Value
	{
		get
		{
			if (attr_pos < 0)
			{
				return source.Text;
			}
			if (attr_pos < source.AttributeCount)
			{
				return source.GetAttributeValue(attr_pos);
			}
			return source.GetNamespaceUri(attr_pos - source.AttributeCount + ns_index);
		}
	}

	public XmlPullParserReader(IJavaObject source)
	{
		this.source = (IXmlPullParser)source;
		supports_ns = this.source.GetFeature("http://xmlpull.org/v1/doc/features.html#process-namespaces");
		supports_ns_report_as_attr = this.source.GetFeature("http://xmlpull.org/v1/doc/features.html#report-namespace-prefixes");
	}

	public bool HasLineInfo()
	{
		return attr_pos < 0;
	}

	public override void Close()
	{
		if (source is IXmlResourceParser xmlResourceParser)
		{
			xmlResourceParser.Close();
		}
	}

	public override string? GetAttribute(int i)
	{
		if (i < source.AttributeCount)
		{
			return source.GetAttributeValue(i);
		}
		if (i < AttributeCount)
		{
			return source.GetNamespaceUri(i - source.AttributeCount + ns_index);
		}
		throw new ArgumentOutOfRangeException();
	}

	public override string? GetAttribute(string localName, string? namespaceName)
	{
		if (!(namespaceName == "http://www.w3.org/2000/xmlns/"))
		{
			return source.GetAttributeValue(namespaceName, localName);
		}
		return source.GetNamespace(localName);
	}

	public override string? GetAttribute(string name)
	{
		QName qName = new QName(this, name);
		return GetAttribute(qName.LocalName, qName.Namespace);
	}

	public override string? LookupNamespace(string prefix)
	{
		return nsmgr.LookupNamespace(prefix);
	}

	public override void MoveToAttribute(int i)
	{
		if (i < 0 || i >= AttributeCount)
		{
			throw new IndexOutOfRangeException();
		}
		attr_pos = i;
		attr_value = false;
	}

	public override bool MoveToAttribute(string localName, string? namespaceName)
	{
		if (namespaceName == "http://www.w3.org/2000/xmlns/")
		{
			for (int i = 0; i < ns_count; i++)
			{
				if (source.GetNamespacePrefix(ns_index + i) == localName)
				{
					attr_pos = source.AttributeCount + i;
					attr_value = false;
					return true;
				}
			}
		}
		else
		{
			int attributeCount = source.AttributeCount;
			for (int j = 0; j < attributeCount; j++)
			{
				if (source.GetAttributeName(j) == localName && source.GetAttributeNamespace(j) == namespaceName)
				{
					attr_pos = j;
					attr_value = false;
					return true;
				}
			}
		}
		return false;
	}

	public override bool MoveToAttribute(string name)
	{
		QName qName = new QName(this, name);
		return MoveToAttribute(qName.LocalName, qName.Namespace);
	}

	public override bool MoveToElement()
	{
		if (attr_pos >= 0)
		{
			attr_pos = -1;
			attr_value = false;
			return true;
		}
		return false;
	}

	public override bool MoveToFirstAttribute()
	{
		if (source.AttributeCount == 0 && ns_count == 0)
		{
			return false;
		}
		attr_pos = 0;
		attr_value = false;
		return true;
	}

	public override bool MoveToNextAttribute()
	{
		if (attr_pos + 1 >= source.AttributeCount && attr_pos + 1 - source.AttributeCount >= ns_count)
		{
			return false;
		}
		attr_pos++;
		attr_value = false;
		return true;
	}

	public override bool Read()
	{
		started = true;
		if (source.EventType == XmlPullParserNode.EndDocument)
		{
			return false;
		}
		MoveToElement();
		bool isEmptyElementTag = source.IsEmptyElementTag;
		if (source.IsEmptyElementTag)
		{
			source.NextToken();
		}
		source.NextToken();
		if (source.EventType == XmlPullParserNode.StartDocument)
		{
			source.NextToken();
		}
		if (source.EventType == XmlPullParserNode.EndDocument)
		{
			return false;
		}
		if (supports_ns && !supports_ns_report_as_attr)
		{
			ns_index = ((source.Depth != 0) ? source.GetNamespaceCount(source.Depth - 1) : 0);
			ns_count = source.GetNamespaceCount(source.Depth) - ns_index;
		}
		if (isEmptyElementTag || NodeType == XmlNodeType.EndElement)
		{
			nsmgr.PopScope();
		}
		if (NodeType == XmlNodeType.Element)
		{
			if (!string.IsNullOrEmpty(NamespaceURI) && nsmgr.LookupPrefix(NamespaceURI) != string.Empty)
			{
				nsmgr.AddNamespace(string.Empty, NamespaceURI);
			}
			else if (NamespaceURI == string.Empty && nsmgr.DefaultNamespace != string.Empty)
			{
				nsmgr.AddNamespace(string.Empty, string.Empty);
			}
			for (int i = 0; i < source.AttributeCount; i++)
			{
				string attributeNamespace = source.GetAttributeNamespace(i);
				if (!string.IsNullOrEmpty(attributeNamespace) && nsmgr.LookupPrefix(attributeNamespace) == null)
				{
					nsmgr.AddNamespace("p" + i, attributeNamespace);
				}
			}
			nsmgr.PushScope();
		}
		return true;
	}

	public override bool ReadAttributeValue()
	{
		if (attr_pos < 0 || attr_value)
		{
			return false;
		}
		attr_value = true;
		return true;
	}

	public override void ResolveEntity()
	{
		throw new NotSupportedException();
	}

	public static XmlReader? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		return FromNative(handle, transfer);
	}

	private static XmlReader? FromNative(nint handle, JniHandleOwnership transfer)
	{
		IXmlPullParser xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(handle, transfer);
		if (xmlPullParser == null)
		{
			return null;
		}
		return new XmlPullParserReader(xmlPullParser);
	}
}
