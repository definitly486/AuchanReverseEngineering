using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers;

namespace NLog.Layouts;

[NLogConfigurationItem]
public abstract class Layout : ISupportsInitialize, IRenderable
{
	public static readonly Layout Empty = new SimpleLayout();

	internal bool IsInitialized;

	private bool _scannedForObjects;

	internal bool ThreadAgnostic { get; set; }

	internal bool ThreadAgnosticImmutable { get; set; }

	internal StackTraceUsage StackTraceUsage { get; set; }

	protected internal LoggingConfiguration? LoggingConfiguration { get; private set; }

	public static implicit operator Layout([Localizable(false)] string text)
	{
		if (text == null)
		{
			return new Layout<string>(null);
		}
		return FromString(text, ConfigurationItemFactory.Default);
	}

	public static Layout FromString([Localizable(false)] string layoutText)
	{
		return FromString(layoutText, ConfigurationItemFactory.Default);
	}

	public static Layout FromString([Localizable(false)] string layoutText, ConfigurationItemFactory configurationItemFactory)
	{
		if (!string.IsNullOrEmpty(layoutText))
		{
			return new SimpleLayout(layoutText, configurationItemFactory);
		}
		return Empty;
	}

	public static Layout FromString([Localizable(false)] string layoutText, bool throwConfigExceptions)
	{
		try
		{
			return string.IsNullOrEmpty(layoutText) ? Empty : new SimpleLayout(layoutText, ConfigurationItemFactory.Default, throwConfigExceptions);
		}
		catch (NLogConfigurationException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			if (!throwConfigExceptions || ex2.MustBeRethrownImmediately())
			{
				throw;
			}
			throw new NLogConfigurationException("Invalid Layout: " + layoutText, ex2);
		}
	}

	public static Layout FromLiteral([Localizable(false)] string literalText)
	{
		if (string.IsNullOrEmpty(literalText))
		{
			return Empty;
		}
		LayoutRenderer[] layoutRenderers = new LiteralLayoutRenderer[1]
		{
			new LiteralLayoutRenderer(literalText)
		};
		return new SimpleLayout(layoutRenderers, literalText);
	}

	public static Layout FromMethod(Func<LogEventInfo, object> layoutMethod, LayoutRenderOptions options = LayoutRenderOptions.None)
	{
		Guard.ThrowIfNull(layoutMethod, "layoutMethod");
		string name = layoutMethod.Method?.DeclaringType?.ToString() + "." + layoutMethod.Method?.Name;
		FuncLayoutRenderer funcLayoutRenderer = CreateFuncLayoutRenderer((LogEventInfo l, LoggingConfiguration? c) => layoutMethod(l), options, name);
		LayoutRenderer[] layoutRenderers = new FuncLayoutRenderer[1] { funcLayoutRenderer };
		return new SimpleLayout(layoutRenderers, funcLayoutRenderer.LayoutRendererName);
	}

	internal static FuncLayoutRenderer CreateFuncLayoutRenderer(Func<LogEventInfo, LoggingConfiguration?, object> layoutMethod, LayoutRenderOptions options, string name)
	{
		if ((options & LayoutRenderOptions.ThreadAgnostic) == LayoutRenderOptions.ThreadAgnostic)
		{
			return new FuncThreadAgnosticLayoutRenderer(name, layoutMethod);
		}
		return new FuncLayoutRenderer(name, layoutMethod);
	}

	public virtual void Precalculate(LogEventInfo logEvent)
	{
		if (!ThreadAgnostic || ThreadAgnosticImmutable)
		{
			using (AppendBuilderCreator appendBuilderCreator = new AppendBuilderCreator(mustBeEmpty: true))
			{
				PrecalculateCachedLayoutValue(logEvent, appendBuilderCreator.Builder);
			}
		}
	}

	public string Render(LogEventInfo logEvent)
	{
		if (!IsInitialized)
		{
			Initialize(LoggingConfiguration);
		}
		if ((!ThreadAgnostic || ThreadAgnosticImmutable) && logEvent.TryGetCachedLayoutValue(this, out object value))
		{
			return value?.ToString() ?? string.Empty;
		}
		return GetFormattedMessage(logEvent) ?? string.Empty;
	}

	public void Render(LogEventInfo logEvent, StringBuilder target)
	{
		if (!IsInitialized)
		{
			Initialize(LoggingConfiguration);
		}
		if ((!ThreadAgnostic || ThreadAgnosticImmutable) && logEvent.TryGetCachedLayoutValue(this, out object value))
		{
			target.Append(value?.ToString());
		}
		else
		{
			RenderFormattedMessage(logEvent, target);
		}
	}

	internal virtual void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		Precalculate(logEvent);
	}

	private void PrecalculateCachedLayoutValue(LogEventInfo logEvent, StringBuilder target)
	{
		if (!IsInitialized)
		{
			Initialize(LoggingConfiguration);
		}
		if ((!ThreadAgnostic || ThreadAgnosticImmutable) && !logEvent.TryGetCachedLayoutValue(this, out object _))
		{
			RenderFormattedMessage(logEvent, target);
			logEvent.AddCachedLayoutValue(this, target.ToString());
		}
	}

	internal string RenderAllocateBuilder(LogEventInfo logEvent)
	{
		using AppendBuilderCreator appendBuilderCreator = new AppendBuilderCreator(mustBeEmpty: true);
		RenderFormattedMessage(logEvent, appendBuilderCreator.Builder);
		return appendBuilderCreator.Builder.ToString();
	}

	internal string RenderAllocateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		RenderFormattedMessage(logEvent, target);
		return target.ToString();
	}

	protected virtual void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		target.Append(GetFormattedMessage(logEvent));
	}

	void ISupportsInitialize.Initialize(LoggingConfiguration? configuration)
	{
		Initialize(configuration);
	}

	void ISupportsInitialize.Close()
	{
		Close();
	}

	internal void Initialize(LoggingConfiguration? configuration)
	{
		if (IsInitialized)
		{
			return;
		}
		try
		{
			LoggingConfiguration = configuration;
			_scannedForObjects = false;
			InitializeLayout();
			if (!_scannedForObjects)
			{
				InternalLogger.Debug("{0} Initialized Layout done but not scanned for objects", GetType());
				PerformObjectScanning();
			}
		}
		finally
		{
			IsInitialized = true;
		}
	}

	internal void PerformObjectScanning()
	{
		List<IRenderable> list = ObjectGraphScanner.FindReachableObjects<IRenderable>(ConfigurationItemFactory.Default, aggressiveSearch: true, new object[1] { this });
		HashSet<Type> hashSet = new HashSet<Type>(list.Select((IRenderable o) => o.GetType()));
		hashSet.Remove(typeof(SimpleLayout));
		hashSet.Remove(typeof(LiteralLayoutRenderer));
		hashSet.Remove(typeof(LiteralWithRawValueLayoutRenderer));
		ThreadAgnostic = hashSet.All((Type t) => t.IsDefined(typeof(ThreadAgnosticAttribute), inherit: true));
		ThreadAgnosticImmutable = ThreadAgnostic && hashSet.Any((Type t) => t.IsDefined(typeof(ThreadAgnosticImmutableAttribute), inherit: true));
		if (list.Count > 1 && hashSet.Count > 0)
		{
			foreach (Layout item in list.OfType<Layout>())
			{
				if (item != this)
				{
					item.Initialize(LoggingConfiguration);
					ThreadAgnostic = item.ThreadAgnostic && ThreadAgnostic;
					ThreadAgnosticImmutable = ThreadAgnostic && (item.ThreadAgnosticImmutable || ThreadAgnosticImmutable);
				}
			}
		}
		StackTraceUsage = StackTraceUsage.None;
		StackTraceUsage = list.OfType<IUsesStackTrace>().DefaultIfEmpty().Aggregate(StackTraceUsage.None, (StackTraceUsage usage, IUsesStackTrace item) => (usage | item?.StackTraceUsage).GetValueOrDefault());
		_scannedForObjects = true;
	}

	internal Layout[]? ResolveLayoutPrecalculation(IEnumerable<Layout> allLayouts)
	{
		if (!_scannedForObjects || (ThreadAgnostic && !ThreadAgnosticImmutable))
		{
			return null;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (Layout allLayout in allLayouts)
		{
			num++;
			if ((allLayout != null && !allLayout.ThreadAgnostic) || (allLayout != null && allLayout.ThreadAgnosticImmutable))
			{
				num2++;
				if (allLayout is SimpleLayout)
				{
					num3++;
				}
			}
		}
		if (num <= 1 || num2 > 4 || num2 - num3 > 2 || num - num3 <= 1 || num2 == 0)
		{
			return null;
		}
		return allLayouts.Where((Layout layout) => (layout != null && !layout.ThreadAgnostic) || (layout?.ThreadAgnosticImmutable ?? false)).ToArray();
	}

	internal void Close()
	{
		if (IsInitialized)
		{
			LoggingConfiguration = null;
			IsInitialized = false;
			CloseLayout();
		}
	}

	protected virtual void InitializeLayout()
	{
		PerformObjectScanning();
	}

	protected virtual void CloseLayout()
	{
	}

	protected abstract string GetFormattedMessage(LogEventInfo logEvent);

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(string name) where T : Layout
	{
		Type typeFromHandle = typeof(T);
		Register(name, typeFromHandle);
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type layoutType)
	{
		ConfigurationItemFactory.Default.GetLayoutFactory().RegisterDefinition(name, layoutType);
	}

	internal void PrecalculateBuilderInternal(LogEventInfo logEvent, StringBuilder target, Layout[]? precalculateLayout)
	{
		if (ThreadAgnostic && !ThreadAgnosticImmutable)
		{
			return;
		}
		if (precalculateLayout == null)
		{
			PrecalculateCachedLayoutValue(logEvent, target);
			return;
		}
		foreach (Layout obj in precalculateLayout)
		{
			target.ClearBuilder();
			obj.PrecalculateBuilder(logEvent, target);
		}
	}

	internal string ToStringWithNestedItems<T>(IList<T> nestedItems, Func<T, string> nextItemToString)
	{
		if (nestedItems != null && nestedItems.Count > 0)
		{
			string[] value = nestedItems.Select(nextItemToString).ToArray();
			return GetType().Name + "=" + string.Join("|", value);
		}
		return base.ToString();
	}

	internal virtual bool TryGetRawValue(LogEventInfo logEvent, out object? rawValue)
	{
		rawValue = null;
		return false;
	}

	protected T ResolveService<T>() where T : class
	{
		return LoggingConfiguration.GetServiceProvider().ResolveService<T>(IsInitialized);
	}
}
[ThreadAgnostic]
public sealed class Layout<T> : Layout, ILayoutTypeValue<T>, ILayoutTypeValue, IEquatable<T>
{
	private sealed class LayoutGenericTypeValue : LayoutTypeValue, ILayoutTypeValue<T>, ILayoutTypeValue
	{
		private readonly Layout<T> _ownerLayout;

		public override IPropertyTypeConverter ValueTypeConverter => _ownerLayout.ValueTypeConverter;

		public LayoutGenericTypeValue(Layout layout, string? parseValueFormat, CultureInfo? parseValueCulture, Layout<T> ownerLayout)
			: base(layout, typeof(T), parseValueFormat, parseValueCulture, null)
		{
			_ownerLayout = ownerLayout;
		}

		public void InitializeLayout()
		{
			InitializeLayout(_ownerLayout);
		}

		public void CloseLayout()
		{
			Close();
		}

		public bool TryRenderValue(LogEventInfo logEvent, StringBuilder? stringBuilder, out T? value)
		{
			if (RenderObjectValue(logEvent, stringBuilder) is T val)
			{
				value = val;
				return true;
			}
			value = default(T);
			return false;
		}
	}

	private sealed class FuncMethodValue : ILayoutTypeValue<T>, ILayoutTypeValue
	{
		private readonly Func<LogEventInfo, T> _layoutMethod;

		public bool ThreadAgnostic { get; }

		ILayoutTypeValue ILayoutTypeValue.InnerLayout => this;

		Type ILayoutTypeValue.InnerType => typeof(T);

		LoggingConfiguration? ILayoutTypeValue<T>.LoggingConfiguration => null;

		bool ILayoutTypeValue<T>.ThreadAgnosticImmutable => false;

		StackTraceUsage ILayoutTypeValue<T>.StackTraceUsage => StackTraceUsage.None;

		public FuncMethodValue(Func<LogEventInfo, T> layoutMethod, LayoutRenderOptions options)
		{
			_layoutMethod = layoutMethod;
			ThreadAgnostic = options == LayoutRenderOptions.ThreadAgnostic;
		}

		public void InitializeLayout()
		{
		}

		public void CloseLayout()
		{
		}

		public bool TryRenderValue(LogEventInfo logEvent, StringBuilder? stringBuilder, out T? value)
		{
			value = _layoutMethod(logEvent);
			return true;
		}

		public object? RenderObjectValue(LogEventInfo logEvent, StringBuilder? stringBuilder)
		{
			return _layoutMethod(logEvent);
		}

		public override string ToString()
		{
			return _layoutMethod.ToString();
		}
	}

	private readonly T? _fixedValue;

	private object? _fixedObjectValue;

	private readonly ILayoutTypeValue<T> _layoutValue;

	private IPropertyTypeConverter? _valueTypeConverter;

	ILayoutTypeValue ILayoutTypeValue.InnerLayout => _layoutValue;

	Type ILayoutTypeValue.InnerType => typeof(T);

	bool ILayoutTypeValue<T>.ThreadAgnostic => true;

	bool ILayoutTypeValue<T>.ThreadAgnosticImmutable => false;

	StackTraceUsage ILayoutTypeValue<T>.StackTraceUsage => StackTraceUsage.None;

	LoggingConfiguration? ILayoutTypeValue<T>.LoggingConfiguration => base.LoggingConfiguration;

	public bool IsFixed => this == _layoutValue;

	public T? FixedValue => _fixedValue;

	private object? FixedObjectValue => _fixedObjectValue ?? (_fixedObjectValue = _fixedValue);

	private IPropertyTypeConverter ValueTypeConverter => _valueTypeConverter ?? (_valueTypeConverter = ResolveService<IPropertyTypeConverter>());

	void ILayoutTypeValue<T>.InitializeLayout()
	{
	}

	void ILayoutTypeValue<T>.CloseLayout()
	{
	}

	bool ILayoutTypeValue<T>.TryRenderValue(LogEventInfo logEvent, StringBuilder? stringBuilder, out T? value)
	{
		value = _fixedValue;
		return true;
	}

	object? ILayoutTypeValue.RenderObjectValue(LogEventInfo logEvent, StringBuilder? stringBuilder)
	{
		return FixedObjectValue;
	}

	public Layout(Layout layout)
		: this(layout, (string?)null, CultureInfo.InvariantCulture)
	{
	}

	public Layout(Layout layout, string? parseValueFormat, CultureInfo? parseValueCulture)
	{
		if (PropertyTypeConverter.IsComplexType(typeof(T)))
		{
			throw new NLogConfigurationException("Layout<" + typeof(T).ToString() + "> not supported. Immutable value type is recommended");
		}
		if (TryParseFixedValue(layout, parseValueFormat, parseValueCulture, ref _fixedValue))
		{
			_layoutValue = this;
		}
		else
		{
			_layoutValue = new LayoutGenericTypeValue(layout, parseValueFormat, parseValueCulture, this);
		}
	}

	public Layout(T? value)
	{
		_fixedValue = value;
		_layoutValue = this;
	}

	private Layout(Func<LogEventInfo, T> layoutMethod, LayoutRenderOptions options)
	{
		Guard.ThrowIfNull(layoutMethod, "layoutMethod");
		_layoutValue = new FuncMethodValue(layoutMethod, options);
	}

	internal T? RenderTypedValue(LogEventInfo logEvent, T? defaultValue = default(T?))
	{
		return RenderTypedValue(logEvent, null, defaultValue);
	}

	internal T? RenderTypedValue(LogEventInfo logEvent, StringBuilder? stringBuilder, T? defaultValue)
	{
		if (IsFixed)
		{
			return _fixedValue;
		}
		if (logEvent == null)
		{
			return defaultValue;
		}
		if (logEvent.TryGetCachedLayoutValue(this, out object value))
		{
			if (value != null)
			{
				return (T)value;
			}
			return defaultValue;
		}
		if (!IsInitialized)
		{
			Initialize(base.LoggingConfiguration ?? _layoutValue.LoggingConfiguration);
		}
		if (_layoutValue.TryRenderValue(logEvent, stringBuilder, out T value2))
		{
			return value2;
		}
		return defaultValue;
	}

	private object? RenderObjectValue(LogEventInfo logEvent, StringBuilder? stringBuilder)
	{
		if (logEvent == null)
		{
			return null;
		}
		if (logEvent.TryGetCachedLayoutValue(this, out object value))
		{
			return value;
		}
		return _layoutValue.RenderObjectValue(logEvent, stringBuilder);
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return FormatHelper.TryFormatToString(IsFixed ? FixedObjectValue : RenderObjectValue(logEvent, null), null, CultureInfo.InvariantCulture);
	}

	protected override void InitializeLayout()
	{
		base.InitializeLayout();
		_layoutValue.InitializeLayout();
		base.ThreadAgnostic = _layoutValue.ThreadAgnostic;
		base.ThreadAgnosticImmutable = _layoutValue.ThreadAgnosticImmutable;
		base.StackTraceUsage = _layoutValue.StackTraceUsage;
		_valueTypeConverter = null;
		_fixedObjectValue = null;
	}

	protected override void CloseLayout()
	{
		_layoutValue.CloseLayout();
		_valueTypeConverter = null;
		_fixedObjectValue = null;
		base.CloseLayout();
	}

	public override void Precalculate(LogEventInfo logEvent)
	{
		PrecalculateInnerLayout(logEvent, null);
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder? target)
	{
		PrecalculateInnerLayout(logEvent, target);
	}

	public static Layout<T> FromMethod(Func<LogEventInfo, T> layoutMethod, LayoutRenderOptions options = LayoutRenderOptions.None)
	{
		return new Layout<T>(layoutMethod, options);
	}

	private void PrecalculateInnerLayout(LogEventInfo logEvent, StringBuilder? target)
	{
		if (!IsFixed && (!_layoutValue.ThreadAgnostic || _layoutValue.ThreadAgnosticImmutable))
		{
			object value = RenderObjectValue(logEvent, target);
			logEvent.AddCachedLayoutValue(this, value);
		}
	}

	private bool TryParseFixedValue(Layout layout, string? parseValueFormat, CultureInfo? parseValueCulture, ref T? fixedValue)
	{
		if (layout is SimpleLayout { IsFixedText: not false } simpleLayout)
		{
			if (simpleLayout.FixedText != null && !string.IsNullOrEmpty(simpleLayout.FixedText))
			{
				try
				{
					fixedValue = (T)ParseValueFromObject(simpleLayout.FixedText, parseValueFormat, parseValueCulture);
					return true;
				}
				catch (Exception innerException)
				{
					NLogConfigurationException ex = new NLogConfigurationException($"Failed converting into type {typeof(T)}. Value='{simpleLayout.FixedText}'", innerException);
					if (ex.MustBeRethrown())
					{
						throw ex;
					}
				}
			}
			else
			{
				if (typeof(T) == typeof(string))
				{
					fixedValue = (T)(object)(simpleLayout.FixedText ?? string.Empty);
					return true;
				}
				if (Nullable.GetUnderlyingType(typeof(T)) != null)
				{
					fixedValue = default(T);
					return true;
				}
			}
		}
		else if (layout == null)
		{
			fixedValue = default(T);
			return true;
		}
		fixedValue = default(T);
		return false;
	}

	private object? ParseValueFromObject(object rawValue, string? parseValueFormat, CultureInfo? parseValueCulture)
	{
		return ValueTypeConverter.Convert(rawValue, typeof(T), parseValueFormat, parseValueCulture);
	}

	public override string ToString()
	{
		if (!IsFixed)
		{
			return _layoutValue.ToString();
		}
		return FixedObjectValue?.ToString() ?? "null";
	}

	public override bool Equals(object obj)
	{
		if (IsFixed)
		{
			if (obj is Layout<T> layout)
			{
				if (layout.IsFixed)
				{
					return object.Equals(FixedObjectValue, layout.FixedObjectValue);
				}
				return false;
			}
			if (obj is T)
			{
				return object.Equals(FixedObjectValue, obj);
			}
			return obj == FixedObjectValue;
		}
		return this == obj;
	}

	public bool Equals(T other)
	{
		if (IsFixed)
		{
			return object.Equals(FixedObjectValue, other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (IsFixed)
		{
			return FixedObjectValue?.GetHashCode() ?? typeof(T).GetHashCode();
		}
		return RuntimeHelpers.GetHashCode(this);
	}

	public static implicit operator Layout<T>(T value)
	{
		return new Layout<T>(value);
	}

	public static implicit operator Layout<T>([Localizable(false)] string layout)
	{
		if (layout != null || typeof(T).IsValueType)
		{
			return new Layout<T>(layout ?? string.Empty);
		}
		return new Layout<T>(default(T));
	}

	public static bool operator ==(Layout<T> left, T right)
	{
		if (left == null || !left.Equals(right))
		{
			if (left == null)
			{
				return object.Equals(right, default(T));
			}
			return false;
		}
		return true;
	}

	public static bool operator !=(Layout<T> left, T right)
	{
		if (left == null || !left.Equals(right))
		{
			if (left == null)
			{
				return !object.Equals(right, default(T));
			}
			return true;
		}
		return false;
	}
}
