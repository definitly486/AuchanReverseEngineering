using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[NLogConfigurationItem]
public abstract class LayoutRenderer : ISupportsInitialize, IRenderable
{
	private bool _isInitialized;

	private IValueFormatter? _valueFormatter;

	protected LoggingConfiguration? LoggingConfiguration { get; private set; }

	protected IValueFormatter ValueFormatter => _valueFormatter ?? (_valueFormatter = ResolveService<IValueFormatter>());

	public override string ToString()
	{
		LayoutRendererAttribute firstCustomAttribute = GetType().GetFirstCustomAttribute<LayoutRendererAttribute>();
		if (firstCustomAttribute != null)
		{
			return "Layout Renderer: ${" + firstCustomAttribute.Name + "}";
		}
		return GetType().Name;
	}

	public string Render(LogEventInfo logEvent)
	{
		using AppendBuilderCreator appendBuilderCreator = new AppendBuilderCreator(mustBeEmpty: true);
		RenderAppendBuilder(logEvent, appendBuilderCreator.Builder);
		return appendBuilderCreator.Builder.ToString();
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
		if (LoggingConfiguration == null)
		{
			LoggingConfiguration = configuration;
		}
		if (!_isInitialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		try
		{
			InitializeLayoutRenderer();
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Exception in layout renderer initialization.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
		finally
		{
			_isInitialized = true;
		}
	}

	internal void Close()
	{
		if (_isInitialized)
		{
			LoggingConfiguration = null;
			_valueFormatter = null;
			_isInitialized = false;
			CloseLayoutRenderer();
		}
	}

	internal void RenderAppendBuilder(LogEventInfo logEvent, StringBuilder builder)
	{
		try
		{
			if (!_isInitialized)
			{
				Initialize();
			}
			Append(builder, logEvent);
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "Exception in '{0}.Append()'", new ReadOnlySpan<object>(new object[1] { GetType() }));
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
	}

	protected abstract void Append(StringBuilder builder, LogEventInfo logEvent);

	internal void AppendFormattedValue(StringBuilder builder, LogEventInfo logEvent, object? value, string? format, CultureInfo? culture)
	{
		if (format == null && value is string value2)
		{
			builder.Append(value2);
			return;
		}
		IFormatProvider formatProvider = GetFormatProvider(logEvent, culture);
		builder.AppendFormattedValue(value, format, formatProvider, ValueFormatter);
	}

	protected virtual void InitializeLayoutRenderer()
	{
	}

	protected virtual void CloseLayoutRenderer()
	{
	}

	protected IFormatProvider? GetFormatProvider(LogEventInfo logEvent, IFormatProvider? layoutCulture = null)
	{
		object obj = layoutCulture;
		if (obj == null)
		{
			obj = logEvent.FormatProvider;
			if (obj == null)
			{
				LoggingConfiguration? loggingConfiguration = LoggingConfiguration;
				if (loggingConfiguration == null)
				{
					return null;
				}
				obj = loggingConfiguration.DefaultCultureInfo;
			}
		}
		return (IFormatProvider?)obj;
	}

	protected CultureInfo GetCulture(LogEventInfo logEvent, CultureInfo? layoutCulture = null)
	{
		return layoutCulture ?? (logEvent.FormatProvider as CultureInfo) ?? LoggingConfiguration?.DefaultCultureInfo ?? CultureInfo.CurrentCulture;
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(string name) where T : LayoutRenderer
	{
		Type typeFromHandle = typeof(T);
		Register(name, typeFromHandle);
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type layoutRendererType)
	{
		Guard.ThrowIfNull(layoutRendererType, "layoutRendererType");
		Guard.ThrowIfNullOrEmpty(name, "name");
		ConfigurationItemFactory.Default.GetLayoutRendererFactory().RegisterDefinition(name, layoutRendererType);
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(string name, Func<LogEventInfo, object> func)
	{
		Guard.ThrowIfNull(func, "func");
		Register(name, (LogEventInfo info, LoggingConfiguration? configuration) => func(info));
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(string name, Func<LogEventInfo, LoggingConfiguration?, object> func)
	{
		Guard.ThrowIfNull(func, "func");
		Register(new FuncLayoutRenderer(name, func));
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(FuncLayoutRenderer layoutRenderer)
	{
		Guard.ThrowIfNull(layoutRenderer, "layoutRenderer");
		ConfigurationItemFactory.Default.GetLayoutRendererFactory().RegisterFuncLayout(layoutRenderer.LayoutRendererName, layoutRenderer);
	}

	protected T ResolveService<T>() where T : class
	{
		return LoggingConfiguration.GetServiceProvider().ResolveService<T>(_isInitialized);
	}
}
