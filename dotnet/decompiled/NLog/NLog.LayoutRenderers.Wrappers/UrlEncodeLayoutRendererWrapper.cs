using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("url-encode")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class UrlEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool SpaceAsPlus { get; set; }

	public bool EscapeDataRfc3986 { get; set; }

	[Obsolete("Instead use default Rfc2396 or EscapeDataRfc3986. Marked obsolete with NLog v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool EscapeDataNLogLegacy { get; set; }

	public UrlEncodeLayoutRendererWrapper()
	{
		SpaceAsPlus = true;
	}

	protected override string Transform(string text)
	{
		if (!string.IsNullOrEmpty(text))
		{
			UrlHelper.EscapeEncodingOptions uriStringEncodingFlags = UrlHelper.GetUriStringEncodingFlags(EscapeDataNLogLegacy, SpaceAsPlus, EscapeDataRfc3986);
			StringBuilder stringBuilder = new StringBuilder(text.Length + 20);
			UrlHelper.EscapeDataEncode(text, stringBuilder, uriStringEncodingFlags);
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (builder.Length > orgLength)
		{
			string source = builder.ToString(orgLength, builder.Length - orgLength);
			builder.Length = orgLength;
			UrlHelper.EscapeEncodingOptions uriStringEncodingFlags = UrlHelper.GetUriStringEncodingFlags(EscapeDataNLogLegacy, SpaceAsPlus, EscapeDataRfc3986);
			UrlHelper.EscapeDataEncode(source, builder, uriStringEncodingFlags);
		}
	}
}
