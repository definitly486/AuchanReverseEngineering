using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;
using NLog.Targets;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("json-encode")]
[AmbientProperty("JsonEncode")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class JsonEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool JsonEncode { get; set; } = true;

	public bool EscapeUnicode { get; set; } = true;

	[Obsolete("Marked obsolete with NLog 5.5. Should never escape forward slash")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool EscapeForwardSlash { get; set; }

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (JsonEncode && builder.Length > orgLength)
		{
			DefaultJsonSerializer.PerformJsonEscapeWhenNeeded(builder, orgLength, EscapeUnicode);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}
