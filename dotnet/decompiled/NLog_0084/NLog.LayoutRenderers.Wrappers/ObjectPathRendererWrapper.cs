using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("Object-Path")]
[AmbientProperty("ObjectPath")]
[ThreadAgnostic]
public sealed class ObjectPathRendererWrapper : WrapperLayoutRendererBase, IRawValue
{
	private ObjectReflectionCache? _objectReflectionCache;

	private ObjectPropertyPath _objectPropertyPath;

	private ObjectReflectionCache ObjectReflectionCache => _objectReflectionCache ?? (_objectReflectionCache = new ObjectReflectionCache(base.LoggingConfiguration.GetServiceProvider()));

	public string Path
	{
		get
		{
			return ObjectPath;
		}
		set
		{
			ObjectPath = value;
		}
	}

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

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (TryGetRawPropertyValue(logEvent, out object propertyValue))
		{
			AppendFormattedValue(builder, logEvent, propertyValue, Format, Culture);
		}
	}

	private bool TryGetRawPropertyValue(LogEventInfo logEvent, out object? propertyValue)
	{
		Layout inner = base.Inner;
		if (inner != null && inner.TryGetRawValue(logEvent, out object rawValue) && rawValue != null && TryGetPropertyValue(rawValue, out propertyValue))
		{
			return true;
		}
		propertyValue = null;
		return false;
	}

	public bool TryGetPropertyValue(object sourceObject, out object? propertyValue)
	{
		return ObjectReflectionCache.TryGetObjectProperty(sourceObject, _objectPropertyPath.PathNames, out propertyValue);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		return TryGetRawPropertyValue(logEvent, out value);
	}
}
