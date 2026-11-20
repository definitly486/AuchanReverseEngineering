using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("uppercase")]
[AmbientProperty("Uppercase")]
[AmbientProperty("ToUpper")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class UppercaseLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool Uppercase { get; set; } = true;

	public bool ToUpper
	{
		get
		{
			return Uppercase;
		}
		set
		{
			Uppercase = value;
		}
	}

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (Uppercase && builder.Length > orgLength)
		{
			TransformToUpperCase(builder, logEvent, orgLength);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private void TransformToUpperCase(StringBuilder target, LogEventInfo logEvent, int startPos)
	{
		CultureInfo culture = GetCulture(logEvent, Culture);
		for (int i = startPos; i < target.Length; i++)
		{
			target[i] = char.ToUpper(target[i], culture);
		}
	}
}
