using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("lowercase")]
[AmbientProperty("Lowercase")]
[AmbientProperty("ToLower")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class LowercaseLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool Lowercase { get; set; } = true;

	public bool ToLower
	{
		get
		{
			return Lowercase;
		}
		set
		{
			Lowercase = value;
		}
	}

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner?.Render(logEvent, builder);
		if (Lowercase && builder.Length > orgLength)
		{
			TransformToLowerCase(builder, logEvent, orgLength);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private void TransformToLowerCase(StringBuilder target, LogEventInfo logEvent, int startPos)
	{
		CultureInfo culture = GetCulture(logEvent, Culture);
		for (int i = startPos; i < target.Length; i++)
		{
			target[i] = char.ToLower(target[i], culture);
		}
	}
}
