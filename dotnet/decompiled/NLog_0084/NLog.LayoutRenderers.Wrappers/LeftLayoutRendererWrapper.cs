using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("left")]
[AmbientProperty("Truncate")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class LeftLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public int Length { get; set; }

	public int Truncate
	{
		get
		{
			return Length;
		}
		set
		{
			Length = value;
		}
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (Length > 0)
		{
			base.Inner?.Render(logEvent, builder);
			if (builder.Length - orgLength > Length)
			{
				builder.Length = orgLength + Length;
			}
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}
