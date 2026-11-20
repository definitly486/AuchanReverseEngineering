using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("right")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class RightLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public int Length { get; set; }

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (Length > 0)
		{
			base.Inner.Render(logEvent, builder);
			if (builder.Length - orgLength > Length)
			{
				string value = builder.ToString(builder.Length - Length, Length);
				builder.Length = orgLength;
				builder.Append(value);
			}
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}
