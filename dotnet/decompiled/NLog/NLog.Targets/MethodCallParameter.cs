using System;
using System.ComponentModel;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets;

[NLogConfigurationItem]
public class MethodCallParameter
{
	private readonly ValueTypeLayoutInfo _layoutInfo = new ValueTypeLayoutInfo();

	public string Name { get; set; } = string.Empty;

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

	[Obsolete("Use property ParameterType instead. Marked obsolete on NLog 4.6")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Type Type
	{
		get
		{
			return ParameterType;
		}
		set
		{
			ParameterType = value;
		}
	}

	public Type ParameterType
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

	public MethodCallParameter()
	{
		ParameterType = typeof(string);
	}

	public MethodCallParameter(Layout layout)
	{
		ParameterType = typeof(string);
		Layout = layout;
	}

	public MethodCallParameter(string parameterName, Layout layout)
	{
		ParameterType = typeof(string);
		Name = parameterName;
		Layout = layout;
	}

	public MethodCallParameter(string name, Layout layout, Type type)
	{
		ParameterType = type;
		Name = name;
		Layout = layout;
	}

	public object? RenderValue(LogEventInfo logEvent)
	{
		return _layoutInfo.RenderValue(logEvent);
	}
}
