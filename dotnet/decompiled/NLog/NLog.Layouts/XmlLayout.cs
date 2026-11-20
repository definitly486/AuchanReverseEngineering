using NLog.Config;

namespace NLog.Layouts;

[Layout("XmlLayout")]
[ThreadAgnostic]
public class XmlLayout : XmlElementBase
{
	private const string DefaultRootElementName = "logevent";

	public string ElementName
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

	public Layout ElementValue
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

	public bool ElementEncode
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

	public XmlLayout()
		: this("logevent", Layout.Empty)
	{
	}

	public XmlLayout(string elementName, Layout elementValue)
		: base(elementName, elementValue)
	{
	}
}
