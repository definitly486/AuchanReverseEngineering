using System;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets;

[NLogConfigurationItem]
public class TargetPropertyWithContext
{
	private readonly ValueTypeLayoutInfo _layoutInfo = new ValueTypeLayoutInfo();

	private bool _includeEmptyValue;

	public string Name { get; set; }

	public Layout Layout
	{
		get
		{
			return _layoutInfo.Layout;
		}
		set
		{
			_layoutInfo.Layout = value;
		}
	}

	public Type PropertyType
	{
		get
		{
			return _layoutInfo.ValueType ?? typeof(string);
		}
		set
		{
			_layoutInfo.ValueType = value;
		}
	}

	public Layout? DefaultValue
	{
		get
		{
			return _layoutInfo.DefaultValue;
		}
		set
		{
			_layoutInfo.DefaultValue = value;
		}
	}

	public bool IncludeEmptyValue
	{
		get
		{
			return _includeEmptyValue;
		}
		set
		{
			_includeEmptyValue = value;
			_layoutInfo.ForceDefaultValueNull = !value;
		}
	}

	public TargetPropertyWithContext()
		: this(string.Empty, NLog.Layouts.Layout.Empty)
	{
	}

	public TargetPropertyWithContext(string name, Layout layout)
	{
		Name = name;
		Layout = layout;
	}

	public object? RenderValue(LogEventInfo logEvent)
	{
		return _layoutInfo.RenderValue(logEvent);
	}
}
