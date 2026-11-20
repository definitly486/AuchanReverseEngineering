using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("trim-whitespace")]
[AmbientProperty("TrimWhiteSpace")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class TrimWhiteSpaceLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool TrimWhiteSpace { get; set; } = true;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (TrimWhiteSpace && builder.Length > orgLength)
		{
			TransformTrimWhiteSpaces(builder, orgLength);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private static void TransformTrimWhiteSpaces(StringBuilder builder, int startPos)
	{
		builder.TrimRight(startPos);
		if (builder.Length > startPos && char.IsWhiteSpace(builder[startPos]))
		{
			string text = builder.ToString(startPos, builder.Length - startPos);
			builder.Length = startPos;
			builder.Append(text.Trim());
		}
	}
}
