using NLog.Config;

namespace NLog.Layouts;

[ThreadAgnostic]
public class XmlElement : XmlElementBase
{
	private const string DefaultElementName = "item";

	public string Name
	{
		get
		{
			return base.ElementNameInternal;
		}
		set
		{
			base.ElementNameInternal = value;
		}
	}

	public Layout Value
	{
		get
		{
			return LayoutWrapper.Inner;
		}
		set
		{
			LayoutWrapper.Inner = value;
		}
	}

	public Layout Layout
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value;
		}
	}

	public bool Encode
	{
		get
		{
			return LayoutWrapper.XmlEncode;
		}
		set
		{
			LayoutWrapper.XmlEncode = value;
		}
	}

	public bool CDataEncode
	{
		get
		{
			return LayoutWrapper.CDataEncode;
		}
		set
		{
			LayoutWrapper.CDataEncode = value;
		}
	}

	public XmlElement()
		: this("item", NLog.Layouts.Layout.Empty)
	{
	}

	public XmlElement(string elementName, Layout elementValue)
		: base(elementName, elementValue)
	{
	}
}
