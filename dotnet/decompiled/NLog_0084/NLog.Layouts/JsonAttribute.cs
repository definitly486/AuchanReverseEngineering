using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Targets;

namespace NLog.Layouts;

[NLogConfigurationItem]
public class JsonAttribute
{
	private readonly ValueTypeLayoutInfo _layoutInfo = new ValueTypeLayoutInfo();

	private string _name;

	private bool _includeEmptyValue;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				_name = value;
				return;
			}
			if (value.All((char chr) => char.IsLetterOrDigit(chr)))
			{
				_name = value;
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			DefaultJsonSerializer.AppendStringEscape(stringBuilder, value.Trim(), escapeUnicode: false);
			_name = stringBuilder.ToString();
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

	public bool EscapeUnicode { get; set; }

	[Obsolete("Marked obsolete since forward slash are valid JSON. Marked obsolete with NLog v5.4")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool EscapeForwardSlash { get; set; }

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

	public JsonAttribute()
		: this(string.Empty, NLog.Layouts.Layout.Empty, encode: true)
	{
	}

	public JsonAttribute(string name, Layout layout)
		: this(name, layout, encode: true)
	{
	}

	public JsonAttribute(string name, Layout layout, bool encode)
	{
		Name = name;
		_name = Name;
		Layout = layout;
		Encode = encode;
	}

	internal bool RenderAppendJsonValue(LogEventInfo logEvent, IJsonConverter jsonConverter, StringBuilder builder)
	{
		if ((object)ValueType == null)
		{
			if (Encode)
			{
				builder.Append('"');
			}
			int length = builder.Length;
			Layout?.Render(logEvent, builder);
			if (!IncludeEmptyValue && builder.Length <= length)
			{
				return false;
			}
			if (Encode)
			{
				DefaultJsonSerializer.PerformJsonEscapeWhenNeeded(builder, length, EscapeUnicode);
				builder.Append('"');
			}
		}
		else
		{
			object obj = _layoutInfo.RenderValue(logEvent);
			if (!IncludeEmptyValue && StringHelpers.IsNullOrEmptyString(obj))
			{
				return false;
			}
			jsonConverter.SerializeObject(obj, builder);
		}
		return true;
	}
}
