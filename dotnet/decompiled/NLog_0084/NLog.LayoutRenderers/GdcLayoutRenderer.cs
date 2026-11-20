using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("gdc")]
[ThreadAgnostic]
public class GdcLayoutRenderer : LayoutRenderer, IRawValue, IStringValueRenderer
{
	private sealed class CachedLookup
	{
		internal readonly object CachedDictionary;

		internal readonly object? CachedItemValue;

		public CachedLookup(object cachedDictionary, object? cachedItemValue)
		{
			CachedDictionary = cachedDictionary;
			CachedItemValue = cachedItemValue;
		}
	}

	private CachedLookup _cachedLookup = new CachedLookup(string.Empty, null);

	[DefaultParameter]
	public string Item { get; set; } = string.Empty;

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (string.IsNullOrEmpty(Item))
		{
			throw new NLogConfigurationException("Gdc-LayoutRenderer Item-property must be assigned. Lookup blank value not supported.");
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		object value = GetValue();
		if (value != null || !string.IsNullOrEmpty(Format))
		{
			AppendFormattedValue(builder, logEvent, value, Format, Culture);
		}
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		value = GetValue();
		return true;
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
		CachedLookup cachedLookup = _cachedLookup;
		Dictionary<string, object> readOnlyDict = GlobalDiagnosticsContext.GetReadOnlyDict();
		if (cachedLookup.CachedDictionary == readOnlyDict)
		{
			return cachedLookup.CachedItemValue;
		}
		readOnlyDict.TryGetValue(Item, out var value);
		_cachedLookup = new CachedLookup(readOnlyDict, value);
		return value;
	}
}
