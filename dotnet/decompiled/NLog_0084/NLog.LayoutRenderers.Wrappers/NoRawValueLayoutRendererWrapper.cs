using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("norawvalue")]
[AmbientProperty("NoRawValue")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class NoRawValueLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool NoRawValue { get; set; } = true;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner?.Render(logEvent, builder);
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}
