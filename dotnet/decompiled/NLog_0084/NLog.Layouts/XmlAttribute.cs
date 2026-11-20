using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.Layouts;

[NLogConfigurationItem]
public class XmlAttribute
{
	private readonly ValueTypeLayoutInfo _layoutInfo = new ValueTypeLayoutInfo();

	private string _name = string.Empty;

	private bool _includeEmptyValue;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = XmlHelper.XmlConvertToElementName(value?.Trim() ?? string.Empty);
		}
	}

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

	public Type? ValueType
	{
		get
		{
			return _layoutInfo.ValueType;
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

	public bool Encode { get; set; }

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

	public XmlAttribute()
		: this(string.Empty, NLog.Layouts.Layout.Empty, encode: true)
	{
	}

	public XmlAttribute(string name, Layout layout)
		: this(name, layout, encode: true)
	{
	}

	public XmlAttribute(string name, Layout layout, bool encode)
	{
		Name = name;
		Layout = layout;
		Encode = encode;
		IncludeEmptyValue = false;
	}

	internal bool RenderAppendXmlValue(LogEventInfo logEvent, StringBuilder builder)
	{
		if ((object)ValueType == null)
		{
			int length = builder.Length;
			Layout?.Render(logEvent, builder);
			if (!IncludeEmptyValue && builder.Length <= length)
			{
				return false;
			}
			if (Encode)
			{
				XmlHelper.PerformXmlEscapeWhenNeeded(builder, length, xmlEncodeNewlines: true);
			}
		}
		else
		{
			object obj = _layoutInfo.RenderValue(logEvent);
			if (!IncludeEmptyValue && StringHelpers.IsNullOrEmptyString(obj))
			{
				return false;
			}
			IConvertible convertible = obj as IConvertible;
			TypeCode typeCode = (TypeCode)(((int?)convertible?.GetTypeCode()) ?? ((obj != null) ? 1 : 0));
			if (typeCode != TypeCode.Object)
			{
				string value = XmlHelper.XmlConvertToString(convertible, typeCode, safeConversion: true);
				builder.Append(value);
			}
			else
			{
				string value2 = XmlHelper.XmlConvertToStringSafe(obj);
				builder.Append(value2);
			}
		}
		return true;
	}
}
