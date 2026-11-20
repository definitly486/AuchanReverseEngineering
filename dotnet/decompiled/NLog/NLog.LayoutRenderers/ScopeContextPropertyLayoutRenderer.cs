using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("scopeproperty")]
[LayoutRenderer("mdc")]
[LayoutRenderer("mdlc")]
public sealed class ScopeContextPropertyLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	[DefaultParameter]
	public string Item { get; set; } = string.Empty;

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (string.IsNullOrEmpty(Item))
		{
			throw new NLogConfigurationException("ScopeProperty-LayoutRenderer Item-property must be assigned. Lookup blank value not supported.");
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		object value = GetValue();
		AppendFormattedValue(builder, logEvent, value, Format, Culture);
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (!"@".Equals(Format))
		{
			return FormatHelper.TryFormatToString(GetValue(), Format, GetFormatProvider(logEvent, Culture));
		}
		return null;
	}

	private object? GetValue()
	{
		ScopeContext.TryGetProperty(Item, out object value);
		return value;
	}
}
