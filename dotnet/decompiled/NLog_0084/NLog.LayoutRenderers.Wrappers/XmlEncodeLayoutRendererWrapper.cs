using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("xml-encode")]
[AmbientProperty("XmlEncode")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class XmlEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool XmlEncode { get; set; } = true;

	public bool CDataEncode { get; set; }

	public bool XmlEncodeNewlines { get; set; }

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (CDataEncode)
		{
			builder.Append("<![CDATA[");
			orgLength = builder.Length;
		}
		base.Inner?.Render(logEvent, builder);
		XmlHelper.RemoveInvalidXmlIfNeeded(builder, orgLength);
		if (CDataEncode)
		{
			XmlHelper.EscapeCDataIfNeeded(builder, orgLength);
			builder.Append("]]>");
		}
		else if (XmlEncode)
		{
			XmlHelper.PerformXmlEscapeWhenNeeded(builder, orgLength, XmlEncodeNewlines);
		}
	}

	protected override string Transform(string text)
	{
		if (CDataEncode)
		{
			return XmlHelper.EscapeCData(text);
		}
		if (XmlEncode)
		{
			return XmlHelper.EscapeXmlString(text, XmlEncodeNewlines);
		}
		return text;
	}
}
