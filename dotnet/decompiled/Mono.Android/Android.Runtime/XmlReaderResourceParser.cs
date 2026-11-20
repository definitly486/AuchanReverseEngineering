using System;
using System.Xml;
using Android.Content.Res;
using Android.Util;
using Java.Interop;
using Org.XmlPull.V1;

namespace Android.Runtime;

public class XmlReaderResourceParser : XmlReaderPullParser, IXmlResourceParser, IAttributeSet, IJavaObject, IDisposable, IJavaPeerable, IXmlPullParser
{
	private XmlReader r;

	public string? ClassAttribute => GetAttributeValue(null, "class");

	public string? IdAttribute => GetAttributeValue(null, "id");

	public int StyleAttribute => GetAttributeResourceValue(null, "style", 0);

	public new static nint ToLocalJniHandle(XmlReader? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is XmlResourceParserReader xmlResourceParserReader)
		{
			return JNIEnv.NewLocalRef(xmlResourceParserReader.Handle);
		}
		return JNIEnv.ToLocalJniHandle(new XmlReaderResourceParser(value));
	}

	public XmlReaderResourceParser(XmlReader r)
		: base(r)
	{
		this.r = r;
	}

	public void Close()
	{
		r.Close();
	}

	public bool GetAttributeBooleanValue(int index, bool defaultValue)
	{
		if (index >= base.AttributeCount)
		{
			return defaultValue;
		}
		return XmlConvert.ToBoolean(GetAttributeValue(index));
	}

	public bool GetAttributeBooleanValue(string? namespaceURI, string? attribute, bool defaultValue)
	{
		string attributeValue = GetAttributeValue(namespaceURI, attribute);
		if (attributeValue == null)
		{
			return defaultValue;
		}
		return XmlConvert.ToBoolean(attributeValue);
	}

	public float GetAttributeFloatValue(int index, float defaultValue)
	{
		if (index >= base.AttributeCount)
		{
			return defaultValue;
		}
		return XmlConvert.ToSingle(GetAttributeValue(index));
	}

	public float GetAttributeFloatValue(string? namespaceURI, string? attribute, float defaultValue)
	{
		string attributeValue = GetAttributeValue(namespaceURI, attribute);
		if (attributeValue == null)
		{
			return defaultValue;
		}
		return XmlConvert.ToSingle(attributeValue);
	}

	public int GetAttributeIntValue(int index, int defaultValue)
	{
		if (index >= base.AttributeCount)
		{
			return defaultValue;
		}
		return XmlConvert.ToInt32(GetAttributeValue(index));
	}

	public int GetAttributeIntValue(string? namespaceURI, string? attribute, int defaultValue)
	{
		string attributeValue = GetAttributeValue(namespaceURI, attribute);
		if (attributeValue == null)
		{
			return defaultValue;
		}
		return XmlConvert.ToInt32(attributeValue);
	}

	public int GetAttributeListValue(int index, string[]? options, int defaultValue)
	{
		throw new NotSupportedException();
	}

	public int GetAttributeListValue(string? namespaceURI, string? attribute, string[]? options, int defaultValue)
	{
		throw new NotSupportedException();
	}

	public int GetAttributeNameResource(int index)
	{
		throw new NotSupportedException();
	}

	public int GetAttributeResourceValue(int index, int defaultValue)
	{
		throw new NotSupportedException();
	}

	public int GetAttributeResourceValue(string? namespaceURI, string? attribute, int defaultValue)
	{
		throw new NotSupportedException();
	}

	public int GetAttributeUnsignedIntValue(int index, int defaultValue)
	{
		if (index >= base.AttributeCount)
		{
			return defaultValue;
		}
		return (int)XmlConvert.ToUInt32(GetAttributeValue(index));
	}

	public int GetAttributeUnsignedIntValue(string? namespaceURI, string? attribute, int defaultValue)
	{
		string attributeValue = GetAttributeValue(namespaceURI, attribute);
		if (attributeValue == null)
		{
			return defaultValue;
		}
		return (int)XmlConvert.ToUInt32(attributeValue);
	}

	public int GetIdAttributeResourceValue(int defaultValue)
	{
		return GetAttributeResourceValue(null, "id", defaultValue);
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
