using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("event-properties")]
[LayoutRenderer("event-property")]
[LayoutRenderer("event-context")]
[ThreadAgnostic]
[ThreadAgnosticImmutable]
public class EventPropertiesLayoutRenderer : LayoutRenderer, IRawValue, IStringValueRenderer
{
	private ObjectReflectionCache? _objectReflectionCache;

	private ObjectPropertyPath _objectPropertyPath;

	private object _item = string.Empty;

	private bool _ignoreCase = true;

	private ObjectReflectionCache ObjectReflectionCache => _objectReflectionCache ?? (_objectReflectionCache = new ObjectReflectionCache(base.LoggingConfiguration.GetServiceProvider()));

	[DefaultParameter]
	public string Item
	{
		get
		{
			return _item?.ToString() ?? string.Empty;
		}
		set
		{
			_item = ((value == null || !IgnoreCase) ? ((object)(value ?? string.Empty)) : ((object)new PropertiesDictionary.IgnoreCasePropertyKey(value)));
		}
	}

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	public string ObjectPath
	{
		get
		{
			return _objectPropertyPath.Value ?? string.Empty;
		}
		set
		{
			_objectPropertyPath.Value = value;
		}
	}

	public bool IgnoreCase
	{
		get
		{
			return _ignoreCase;
		}
		set
		{
			if (value != _ignoreCase)
			{
				_ignoreCase = value;
				Item = _item?.ToString() ?? string.Empty;
			}
		}
	}

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (StringHelpers.IsNullOrEmptyString(_item))
		{
			throw new NLogConfigurationException("EventProperty-LayoutRenderer Item-property must be assigned. Lookup blank value not supported.");
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (TryGetValue(logEvent, out object value))
		{
			AppendFormattedValue(builder, logEvent, value, Format, Culture);
		}
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		TryGetValue(logEvent, out value);
		return true;
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (!"@".Equals(Format))
		{
			if (TryGetValue(logEvent, out object value))
			{
				return FormatHelper.TryFormatToString(value, Format, GetFormatProvider(logEvent, Culture));
			}
			return string.Empty;
		}
		return null;
	}

	private bool TryGetValue(LogEventInfo logEvent, out object? value)
	{
		value = null;
		if (!logEvent.HasProperties)
		{
			return false;
		}
		if (!logEvent.Properties.TryGetValue(_item, out value))
		{
			return false;
		}
		if (_objectPropertyPath.PathNames != null)
		{
			if (ObjectReflectionCache.TryGetObjectProperty(value, _objectPropertyPath.PathNames, out object foundValue))
			{
				value = foundValue;
			}
			else
			{
				value = null;
			}
		}
		return true;
	}
}
