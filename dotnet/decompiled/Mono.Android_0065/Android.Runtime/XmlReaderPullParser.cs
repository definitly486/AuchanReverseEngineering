using System;
using System.IO;
using System.Text;
using System.Xml;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Org.XmlPull.V1;

namespace Android.Runtime;

public class XmlReaderPullParser : Java.Lang.Object, IXmlPullParser, IJavaObject, IDisposable, IJavaPeerable
{
	private XmlReader r;

	private bool started;

	private bool on_empty_end_element;

	private string? input_encoding;

	public int AttributeCount => r.AttributeCount;

	public int ColumnNumber
	{
		get
		{
			if (!(r is IXmlLineInfo xmlLineInfo) || !xmlLineInfo.HasLineInfo())
			{
				return -1;
			}
			return xmlLineInfo.LinePosition - 1;
		}
	}

	public int Depth
	{
		get
		{
			r.MoveToElement();
			return r.Depth;
		}
	}

	public XmlPullParserNode EventType
	{
		get
		{
			if (on_empty_end_element)
			{
				return XmlPullParserNode.EndTag;
			}
			if (r.EOF)
			{
				return XmlPullParserNode.EndDocument;
			}
			if (!started || r.ReadState == ReadState.Initial)
			{
				return XmlPullParserNode.StartDocument;
			}
			r.MoveToElement();
			switch (r.NodeType)
			{
			case XmlNodeType.CDATA:
				return XmlPullParserNode.Cdsect;
			case XmlNodeType.Comment:
				return XmlPullParserNode.Comment;
			case XmlNodeType.Element:
				return XmlPullParserNode.StartTag;
			case XmlNodeType.EndElement:
				return XmlPullParserNode.EndTag;
			case XmlNodeType.EntityReference:
				return XmlPullParserNode.EntityRef;
			case XmlNodeType.ProcessingInstruction:
				return XmlPullParserNode.ProcessingInstruction;
			case XmlNodeType.Text:
			case XmlNodeType.SignificantWhitespace:
				return XmlPullParserNode.Text;
			case XmlNodeType.Whitespace:
				return XmlPullParserNode.IgnorableWhitespace;
			default:
				if (r.ReadState == ReadState.EndOfFile)
				{
					return XmlPullParserNode.EndDocument;
				}
				throw new InvalidOperationException();
			}
		}
	}

	public string? InputEncoding => input_encoding;

	public bool IsEmptyElementTag
	{
		get
		{
			r.MoveToElement();
			return r.IsEmptyElement;
		}
	}

	public bool IsWhitespace => r.NodeType == XmlNodeType.Whitespace;

	public int LineNumber
	{
		get
		{
			if (!(r is IXmlLineInfo xmlLineInfo) || !xmlLineInfo.HasLineInfo())
			{
				return -1;
			}
			return xmlLineInfo.LineNumber - 1;
		}
	}

	public string Name
	{
		get
		{
			r.MoveToElement();
			return r.LocalName;
		}
	}

	public string Namespace
	{
		get
		{
			r.MoveToElement();
			return r.NamespaceURI;
		}
	}

	public string PositionDescription
	{
		get
		{
			r.MoveToElement();
			string text = ((!(r is IXmlLineInfo xmlLineInfo) || !xmlLineInfo.HasLineInfo()) ? "(location N/A)" : FormattableString.Invariant($"({xmlLineInfo.LineNumber}, {xmlLineInfo.LinePosition})"));
			string text2 = (string.IsNullOrEmpty(r.BaseURI) ? null : r.BaseURI);
			return FormattableString.Invariant($"Node {r.NodeType} at {text2} {text}");
		}
	}

	public string Prefix
	{
		get
		{
			r.MoveToElement();
			return r.Prefix;
		}
	}

	public string Text
	{
		get
		{
			r.MoveToElement();
			return r.Value;
		}
	}

	public static nint ToLocalJniHandle(XmlReader? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is XmlPullParserReader xmlPullParserReader)
		{
			return JNIEnv.NewLocalRef(xmlPullParserReader.Handle);
		}
		return JNIEnv.ToLocalJniHandle(new XmlReaderPullParser(value));
	}

	public XmlReaderPullParser(XmlReader r)
	{
		this.r = r;
	}

	public void DefineEntityReplacementText(string? entityName, string? replacementText)
	{
		throw new NotSupportedException();
	}

	public string GetAttributeName(int index)
	{
		r.MoveToAttribute(index);
		return r.LocalName;
	}

	public string GetAttributeNamespace(int index)
	{
		r.MoveToAttribute(index);
		return r.NamespaceURI;
	}

	public string GetAttributePrefix(int index)
	{
		r.MoveToAttribute(index);
		return r.Prefix;
	}

	public string GetAttributeType(int index)
	{
		throw new NotSupportedException();
	}

	public string GetAttributeValue(int index)
	{
		return r.GetAttribute(index);
	}

	public string? GetAttributeValue(string? namespaceURI, string? name)
	{
		if (name == null)
		{
			return null;
		}
		return r.GetAttribute(name, namespaceURI);
	}

	public bool GetFeature(string? name)
	{
		if (name == "http://xmlpull.org/v1/doc/features.html#process-namespaces" || name == "http://xmlpull.org/v1/doc/features.html#report-namespace-prefixes")
		{
			return true;
		}
		return false;
	}

	public string? GetNamespace(string prefix)
	{
		return r.LookupNamespace(prefix);
	}

	public int GetNamespaceCount(int depth)
	{
		throw new NotSupportedException();
	}

	public string GetNamespacePrefix(int pos)
	{
		throw new NotSupportedException();
	}

	public string GetNamespaceUri(int pos)
	{
		throw new NotSupportedException();
	}

	public Java.Lang.Object GetProperty(string? name)
	{
		throw new NotSupportedException();
	}

	public char[] GetTextCharacters(int[] holderForStartAndLength)
	{
		throw new NotSupportedException();
	}

	public bool IsAttributeDefault(int index)
	{
		r.MoveToAttribute(index);
		return r.IsDefault;
	}

	public XmlPullParserNode Next()
	{
		XmlPullParserNode xmlPullParserNode;
		do
		{
			xmlPullParserNode = NextToken();
		}
		while ((uint)(xmlPullParserNode - 1) > 3u);
		return xmlPullParserNode;
	}

	public XmlPullParserNode NextTag()
	{
		XmlPullParserNode xmlPullParserNode = Next();
		if (xmlPullParserNode == XmlPullParserNode.Text && IsWhitespace)
		{
			xmlPullParserNode = Next();
		}
		if ((uint)(xmlPullParserNode - 2) <= 1u)
		{
			return xmlPullParserNode;
		}
		throw new XmlPullParserException("expected start or end tag", r, null);
	}

	public string NextText()
	{
		if (EventType != XmlPullParserNode.StartTag)
		{
			throw new XmlPullParserException("parser must be on START_TAG to read next text", r, null);
		}
		switch (Next())
		{
		case XmlPullParserNode.Text:
		{
			string text = Text;
			XmlPullParserNode xmlPullParserNode = Next();
			if (xmlPullParserNode != XmlPullParserNode.EndTag)
			{
				throw new XmlPullParserException("event TEXT it must be immediately followed by END_TAG", r, null);
			}
			return text;
		}
		case XmlPullParserNode.EndTag:
			return "";
		default:
			throw new XmlPullParserException("parser must be on START_TAG or TEXT to read text", r, null);
		}
	}

	public XmlPullParserNode NextToken()
	{
		if (EventType == XmlPullParserNode.EndDocument)
		{
			throw new XmlPullParserException("Attempt to get next token after EndDocument event is invalid.");
		}
		if (r.IsEmptyElement)
		{
			if (!on_empty_end_element)
			{
				on_empty_end_element = true;
				return XmlPullParserNode.EndTag;
			}
			on_empty_end_element = false;
		}
		if (!started)
		{
			started = true;
			return XmlPullParserNode.StartDocument;
		}
		while (r.Read())
		{
			switch (r.NodeType)
			{
			case XmlNodeType.CDATA:
				return XmlPullParserNode.Cdsect;
			case XmlNodeType.Text:
			case XmlNodeType.SignificantWhitespace:
				return XmlPullParserNode.Text;
			case XmlNodeType.Whitespace:
				return XmlPullParserNode.IgnorableWhitespace;
			case XmlNodeType.Comment:
				return XmlPullParserNode.Comment;
			case XmlNodeType.Element:
				return XmlPullParserNode.StartTag;
			case XmlNodeType.EndElement:
				return XmlPullParserNode.EndTag;
			case XmlNodeType.EntityReference:
				return XmlPullParserNode.EntityRef;
			case XmlNodeType.ProcessingInstruction:
				return XmlPullParserNode.ProcessingInstruction;
			default:
				throw new NotSupportedException();
			case XmlNodeType.DocumentType:
			case XmlNodeType.EndEntity:
			case XmlNodeType.XmlDeclaration:
				break;
			}
		}
		return XmlPullParserNode.EndDocument;
	}

	public void Require(XmlPullParserNode type, string? namespaceURI, string? name)
	{
		if (type != EventType || namespaceURI != Namespace || name != Name)
		{
			throw new XmlPullParserException("expected " + type.ToString() + " " + PositionDescription);
		}
	}

	public void SetFeature(string? name, bool state)
	{
		if ((name == "http://xmlpull.org/v1/doc/features.html#process-namespaces" || name == "http://xmlpull.org/v1/doc/features.html#report-namespace-prefixes") && state)
		{
			return;
		}
		throw new NotSupportedException();
	}

	public void SetInput(Stream? inputStream, string? inputEncoding)
	{
		r = XmlReader.Create(new StreamReader(inputStream, Encoding.GetEncoding(inputEncoding)));
		r.Read();
		input_encoding = inputEncoding;
	}

	public void SetInput(Reader? input)
	{
		throw new NotSupportedException();
	}

	public void SetProperty(string? name, Java.Lang.Object? value)
	{
		throw new NotSupportedException();
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
