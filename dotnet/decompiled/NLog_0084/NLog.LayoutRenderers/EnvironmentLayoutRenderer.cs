using System.Collections.Generic;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers;

[LayoutRenderer("environment")]
[ThreadAgnostic]
public class EnvironmentLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	private KeyValuePair<string, SimpleLayout> _cachedValue;

	[DefaultParameter]
	public string Variable { get; set; } = string.Empty;

	public string Default { get; set; } = string.Empty;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (string.IsNullOrEmpty(Variable))
		{
			throw new NLogConfigurationException("Environment-LayoutRenderer Variable-property must be assigned. Lookup blank value not supported.");
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		GetSimpleLayout()?.Render(logEvent, builder);
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		SimpleLayout simpleLayout = GetSimpleLayout();
		if (simpleLayout == null)
		{
			return string.Empty;
		}
		if (simpleLayout.IsFixedText || simpleLayout.IsSimpleStringText)
		{
			return simpleLayout.Render(logEvent);
		}
		return null;
	}

	private SimpleLayout? GetSimpleLayout()
	{
		if (Variable != null)
		{
			string text = EnvironmentHelper.GetSafeEnvironmentVariable(Variable);
			if (string.IsNullOrEmpty(text))
			{
				text = Default;
			}
			if (!string.IsNullOrEmpty(text))
			{
				KeyValuePair<string, SimpleLayout> keyValuePair = _cachedValue;
				if (string.CompareOrdinal(keyValuePair.Key, text) != 0)
				{
					keyValuePair = (_cachedValue = new KeyValuePair<string, SimpleLayout>(text, new SimpleLayout(text)));
				}
				return keyValuePair.Value;
			}
		}
		return null;
	}
}
