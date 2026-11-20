using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.Layouts;

[NLogConfigurationItem]
public sealed class ValueTypeLayoutInfo
{
	private sealed class FixedLayoutTypeValue : ILayoutTypeValue
	{
		private readonly object? _fixedValue;

		public ILayoutTypeValue InnerLayout => this;

		public Type? InnerType => _fixedValue?.GetType();

		public FixedLayoutTypeValue(object fixedValue)
		{
			_fixedValue = fixedValue;
		}

		public object? RenderObjectValue(LogEventInfo logEvent, StringBuilder? stringBuilder)
		{
			return _fixedValue;
		}

		public override string ToString()
		{
			return _fixedValue?.ToString() ?? "null";
		}
	}

	private sealed class StringLayoutTypeValue : ILayoutTypeValue
	{
		private readonly Layout _innerLayout;

		public ILayoutTypeValue InnerLayout => this;

		public Type InnerType => typeof(string);

		public StringLayoutTypeValue(Layout layout)
		{
			_innerLayout = layout;
		}

		public object RenderObjectValue(LogEventInfo logEvent, StringBuilder? stringBuilder)
		{
			return _innerLayout.Render(logEvent);
		}

		public override string ToString()
		{
			return _innerLayout.ToString();
		}
	}

	private static readonly Layout<string> _fixedNullValue = new Layout<string>(null);

	private Layout _layout = NLog.Layouts.Layout.Empty;

	private Type? _valueType;

	private Func<object>? _createDefaultValue;

	private Layout? _defaultValue;

	private bool _useDefaultWhenEmptyString;

	private string? _valueParseFormat;

	private CultureInfo? _valueParseCulture;

	private ILayoutTypeValue? _layoutValue;

	private ILayoutTypeValue? _defaultLayoutValue;

	public Layout Layout
	{
		get
		{
			return _layout;
		}
		set
		{
			_layout = value ?? NLog.Layouts.Layout.Empty;
			if ((object)ValueType == null && _layout is ILayoutTypeValue layoutTypeValue)
			{
				ValueType = layoutTypeValue.InnerType;
			}
			_layoutValue = null;
		}
	}

	public Type? ValueType
	{
		get
		{
			return _valueType;
		}
		[UnconditionalSuppressMessage("Trimming - Allow ValueType assign from config", "IL2067")]
		set
		{
			_valueType = value;
			Type? type = value;
			if ((object)type != null && type.IsValueType)
			{
				_createDefaultValue = () => Activator.CreateInstance(value);
			}
			else
			{
				_createDefaultValue = null;
			}
			_layoutValue = null;
			_defaultLayoutValue = null;
			_useDefaultWhenEmptyString = UseDefaultWhenEmptyString(_valueType, _defaultValue);
		}
	}

	public Layout? DefaultValue
	{
		get
		{
			return _defaultValue;
		}
		set
		{
			_defaultValue = value;
			_defaultLayoutValue = null;
			_useDefaultWhenEmptyString = UseDefaultWhenEmptyString(_valueType, _defaultValue);
		}
	}

	public bool ForceDefaultValueNull
	{
		get
		{
			return DefaultValue == _fixedNullValue;
		}
		set
		{
			if (value)
			{
				DefaultValue = _fixedNullValue;
			}
			else if (DefaultValue == _fixedNullValue)
			{
				DefaultValue = null;
			}
			_useDefaultWhenEmptyString = UseDefaultWhenEmptyString(_valueType, _defaultValue);
		}
	}

	public string? ValueParseFormat
	{
		get
		{
			return _valueParseFormat;
		}
		set
		{
			_valueParseFormat = value;
			_layoutValue = null;
			_defaultLayoutValue = null;
		}
	}

	public CultureInfo? ValueParseCulture
	{
		get
		{
			return _valueParseCulture;
		}
		set
		{
			_valueParseCulture = value;
			_layoutValue = null;
			_defaultLayoutValue = null;
		}
	}

	private ILayoutTypeValue LayoutValue => _layoutValue ?? (_layoutValue = BuildLayoutTypeValue(Layout));

	private ILayoutTypeValue DefaultLayoutValue => _defaultLayoutValue ?? (_defaultLayoutValue = BuildLayoutTypeValue(DefaultValue));

	private static bool UseDefaultWhenEmptyString(Type? valueType, Layout? defaultValue)
	{
		if (((object)valueType == null || typeof(string).Equals(valueType) || typeof(object).Equals(valueType)) && (defaultValue == null || (defaultValue is SimpleLayout simpleLayout && string.Empty.Equals(simpleLayout.Text)) || (defaultValue == _fixedNullValue && !typeof(object).Equals(valueType))))
		{
			return false;
		}
		return true;
	}

	public object? RenderValue(LogEventInfo logEvent)
	{
		object obj = LayoutValue.RenderObjectValue(logEvent, null);
		if (obj == null || (_useDefaultWhenEmptyString && StringHelpers.IsNullOrEmptyString(obj)))
		{
			obj = DefaultLayoutValue.RenderObjectValue(logEvent, null);
		}
		return obj;
	}

	private ILayoutTypeValue BuildLayoutTypeValue(Layout? layout)
	{
		if (layout == null)
		{
			if (_createDefaultValue != null)
			{
				return new FixedLayoutTypeValue(_createDefaultValue());
			}
			if ((object)ValueType == null || typeof(string).Equals(ValueType))
			{
				return new FixedLayoutTypeValue(string.Empty);
			}
			layout = NLog.Layouts.Layout.Empty;
		}
		if (layout is ILayoutTypeValue layoutTypeValue)
		{
			return layoutTypeValue.InnerLayout;
		}
		if ((object)ValueType == null || typeof(string).Equals(ValueType))
		{
			return new StringLayoutTypeValue(layout);
		}
		IPropertyTypeConverter valueTypeConverter = (layout.LoggingConfiguration?.LogFactory ?? LogManager.LogFactory).ServiceRepository.ResolveService<IPropertyTypeConverter>();
		LayoutTypeValue layoutTypeValue2 = new LayoutTypeValue(layout, ValueType, ValueParseFormat, ValueParseCulture, valueTypeConverter);
		object obj = layoutTypeValue2.TryParseFixedValue();
		if (obj == null)
		{
			return layoutTypeValue2;
		}
		return new FixedLayoutTypeValue(obj);
	}
}
