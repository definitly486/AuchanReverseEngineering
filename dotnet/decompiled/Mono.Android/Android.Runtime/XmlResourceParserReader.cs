using Android.Content.Res;
using Java.Lang;

namespace Android.Runtime;

public class XmlResourceParserReader : XmlPullParserReader
{
	private IXmlResourceParser source;

	public XmlResourceParserReader(IJavaObject source)
		: base(source)
	{
		this.source = (IXmlResourceParser)source;
	}

	public override void Close()
	{
		source.Close();
	}

	public new static XmlResourceParserReader? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		return FromNative(handle, transfer);
	}

	private static XmlResourceParserReader? FromNative(nint handle, JniHandleOwnership transfer)
	{
		IXmlResourceParser xmlResourceParser = Object.GetObject<IXmlResourceParser>(handle, transfer);
		if (xmlResourceParser == null)
		{
			return null;
		}
		return new XmlResourceParserReader(xmlResourceParser);
	}
}
