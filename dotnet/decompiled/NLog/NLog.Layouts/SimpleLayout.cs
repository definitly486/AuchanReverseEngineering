using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers;

namespace NLog.Layouts;

[Layout("SimpleLayout")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public sealed class SimpleLayout : Layout, IUsesStackTrace, IStringValueRenderer
{
	private readonly IRawValue? _rawValueRenderer;

	private IStringValueRenderer? _stringValueRenderer;

	private ReadOnlyCollection<LayoutRenderer>? _renderers;

	private readonly LayoutRenderer[] _layoutRenderers;

	internal static SimpleLayout Default => (SimpleLayout)Layout.Empty;

	public string OriginalText { get; }

	public string Text { get; }

	public bool IsFixedText => FixedText != null;

	public string? FixedText { get; }

	internal bool IsSimpleStringText => _stringValueRenderer != null;

	[NLogConfigurationIgnoreProperty]
	public ReadOnlyCollection<LayoutRenderer> Renderers => _renderers ?? (_renderers = new ReadOnlyCollection<LayoutRenderer>(_layoutRenderers));

	public IEnumerable<LayoutRenderer> LayoutRenderers => _layoutRenderers;

	public new StackTraceUsage StackTraceUsage => base.StackTraceUsage;

	public SimpleLayout()
		: this(ArrayHelper.Empty<LayoutRenderer>(), string.Empty)
	{
	}

	public SimpleLayout([Localizable(false)] string txt)
		: this(txt, ConfigurationItemFactory.Default)
	{
	}

	public SimpleLayout([Localizable(false)] string txt, ConfigurationItemFactory configurationItemFactory)
		: this(txt, configurationItemFactory, null)
	{
	}

	internal SimpleLayout([Localizable(false)] string txt, ConfigurationItemFactory configurationItemFactory, bool? throwConfigExceptions)
		: this(LayoutParser.CompileLayout(txt, configurationItemFactory, throwConfigExceptions, out string parsedText), parsedText)
	{
		OriginalText = txt ?? string.Empty;
	}

	internal SimpleLayout(LayoutRenderer[] layoutRenderers, [Localizable(false)] string txt)
	{
		Text = txt ?? string.Empty;
		OriginalText = txt ?? string.Empty;
		_layoutRenderers = layoutRenderers ?? ArrayHelper.Empty<LayoutRenderer>();
		_renderers = null;
		FixedText = null;
		_rawValueRenderer = null;
		_stringValueRenderer = null;
		if (_layoutRenderers.Length == 0)
		{
			FixedText = string.Empty;
			_stringValueRenderer = this;
		}
		else if (_layoutRenderers.Length == 1)
		{
			if (_layoutRenderers[0] is LiteralLayoutRenderer literalLayoutRenderer)
			{
				FixedText = literalLayoutRenderer.Text;
				_stringValueRenderer = this;
			}
			else if (_layoutRenderers[0] is IStringValueRenderer stringValueRenderer)
			{
				_stringValueRenderer = stringValueRenderer;
			}
			if (_layoutRenderers[0] is IRawValue rawValueRenderer)
			{
				_rawValueRenderer = rawValueRenderer;
			}
		}
	}

	public static implicit operator SimpleLayout?([Localizable(false)] string text)
	{
		if (text == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(text))
		{
			return new SimpleLayout(text);
		}
		return Default;
	}

	[Obsolete("Instead use Layout.FromLiteral()")]
	public static string Escape([Localizable(false)] string text)
	{
		return text.Replace("${", "${literal:text=\\$\\{}");
	}

	public static string Evaluate([Localizable(false)] string text, LogEventInfo logEvent)
	{
		return Evaluate(text, null, logEvent);
	}

	public static string Evaluate([Localizable(false)] string text)
	{
		return Evaluate(text, null, null, null);
	}

	internal static string Evaluate(string text, LoggingConfiguration? loggingConfiguration, LogEventInfo? logEventInfo = null, bool? throwConfigExceptions = null)
	{
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			if (text.IndexOf('$') < 0 || text.IndexOf('{') < 0 || text.IndexOf('}') < 0)
			{
				return text;
			}
			throwConfigExceptions = throwConfigExceptions ?? loggingConfiguration?.LogFactory.ThrowConfigExceptions;
			Layout layout = Layout.FromString(text, throwConfigExceptions ?? LogManager.ThrowConfigExceptions ?? LogManager.ThrowExceptions);
			layout.Initialize(loggingConfiguration);
			return layout.Render(logEventInfo ?? LogEventInfo.CreateNullEvent());
		}
		catch (NLogConfigurationException ex)
		{
			if (throwConfigExceptions ?? LogManager.ThrowConfigExceptions ?? LogManager.ThrowExceptions)
			{
				throw;
			}
			InternalLogger.Warn(ex, "Failed to Evaluate SimpleLayout: {0}", new ReadOnlySpan<object>(new object[1] { text }));
			return text;
		}
		catch (Exception ex2)
		{
			InternalLogger.Warn(ex2, "Failed to Evaluate SimpleLayout: {0}", new ReadOnlySpan<object>(new object[1] { text }));
			return text;
		}
	}

	public override string ToString()
	{
		if (string.IsNullOrEmpty(Text) && !IsFixedText && _layoutRenderers.Length != 0)
		{
			return ToStringWithNestedItems(_layoutRenderers, (LayoutRenderer r) => r.ToString());
		}
		return Text;
	}

	protected override void InitializeLayout()
	{
		LayoutRenderer[] layoutRenderers = _layoutRenderers;
		foreach (LayoutRenderer layoutRenderer in layoutRenderers)
		{
			try
			{
				layoutRenderer.Initialize(base.LoggingConfiguration);
			}
			catch (Exception ex)
			{
				if (InternalLogger.IsWarnEnabled || InternalLogger.IsErrorEnabled)
				{
					InternalLogger.Warn(ex, "Exception in '{0}.Initialize()'", new ReadOnlySpan<object>(new object[1] { layoutRenderer.GetType() }));
				}
				if (ex.MustBeRethrown())
				{
					throw;
				}
			}
		}
		base.InitializeLayout();
	}

	public override void Precalculate(LogEventInfo logEvent)
	{
		if (PrecalculateMustRenderLayoutValue(logEvent))
		{
			using (AppendBuilderCreator appendBuilderCreator = new AppendBuilderCreator(mustBeEmpty: true))
			{
				RenderFormattedMessage(logEvent, appendBuilderCreator.Builder);
				logEvent.AddCachedLayoutValue(this, appendBuilderCreator.Builder.ToString());
			}
		}
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		if (PrecalculateMustRenderLayoutValue(logEvent))
		{
			RenderFormattedMessage(logEvent, target);
			logEvent.AddCachedLayoutValue(this, target.ToString());
		}
	}

	private bool PrecalculateMustRenderLayoutValue(LogEventInfo logEvent)
	{
		if (!IsInitialized)
		{
			Initialize(base.LoggingConfiguration);
		}
		if (base.ThreadAgnostic && !base.ThreadAgnosticImmutable)
		{
			return false;
		}
		if (_rawValueRenderer != null && TryGetRawValue(logEvent, out object rawValue) && IsRawValueImmutable(rawValue))
		{
			return false;
		}
		if (logEvent.TryGetCachedLayoutValue(this, out object _))
		{
			return false;
		}
		if (IsSimpleStringText)
		{
			string formattedMessage = GetFormattedMessage(logEvent);
			logEvent.AddCachedLayoutValue(this, formattedMessage);
			return false;
		}
		return true;
	}

	private static bool IsRawValueImmutable(object? value)
	{
		if (value != null)
		{
			if (Convert.GetTypeCode(value) == TypeCode.Object)
			{
				return value.GetType().IsValueType;
			}
			return true;
		}
		return false;
	}

	internal override bool TryGetRawValue(LogEventInfo logEvent, out object? rawValue)
	{
		if (_rawValueRenderer == null)
		{
			rawValue = null;
			return false;
		}
		return TryGetSafeRawValue(logEvent, out rawValue);
	}

	private bool TryGetSafeRawValue(LogEventInfo logEvent, out object? rawValue)
	{
		try
		{
			if (_rawValueRenderer == null)
			{
				rawValue = null;
				return false;
			}
			if (!IsInitialized)
			{
				Initialize(base.LoggingConfiguration);
			}
			if ((!base.ThreadAgnostic || base.ThreadAgnosticImmutable) && logEvent.TryGetCachedLayoutValue(this, out object _))
			{
				rawValue = null;
				return false;
			}
			return _rawValueRenderer.TryGetRawValue(logEvent, out rawValue);
		}
		catch (Exception ex)
		{
			if (InternalLogger.IsWarnEnabled || InternalLogger.IsErrorEnabled)
			{
				InternalLogger.Warn(ex, "Exception in TryGetRawValue using '{0}.TryGetRawValue()'", new ReadOnlySpan<object>(new object[1] { _rawValueRenderer?.GetType() }));
			}
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
		rawValue = null;
		return false;
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		string stringValue = FixedText;
		if (stringValue != null)
		{
			return stringValue;
		}
		if (_stringValueRenderer == null || !TryGetSafeStringValue(logEvent, out stringValue))
		{
			return RenderAllocateBuilder(logEvent);
		}
		return stringValue;
	}

	private bool TryGetSafeStringValue(LogEventInfo logEvent, out string stringValue)
	{
		try
		{
			if (!IsInitialized)
			{
				Initialize(base.LoggingConfiguration);
			}
			string text = _stringValueRenderer?.GetFormattedString(logEvent);
			if (text == null)
			{
				stringValue = string.Empty;
				_stringValueRenderer = null;
				return false;
			}
			stringValue = text;
			return true;
		}
		catch (Exception ex)
		{
			if (InternalLogger.IsWarnEnabled || InternalLogger.IsErrorEnabled)
			{
				InternalLogger.Warn(ex, "Exception in '{0}.GetFormattedString()'", new ReadOnlySpan<object>(new object[1] { _stringValueRenderer?.GetType() }));
			}
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
		stringValue = string.Empty;
		return false;
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		string fixedText = FixedText;
		if (fixedText == null)
		{
			LayoutRenderer[] layoutRenderers = _layoutRenderers;
			for (int i = 0; i < layoutRenderers.Length; i++)
			{
				layoutRenderers[i].RenderAppendBuilder(logEvent, target);
			}
		}
		else
		{
			target.Append(fixedText);
		}
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		string text = FixedText;
		if (text == null)
		{
			if (!IsSimpleStringText)
			{
				return null;
			}
			text = Render(logEvent);
		}
		return text;
	}
}
