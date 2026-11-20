using System;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("whenEmpty")]
[AmbientProperty("WhenEmpty")]
[ThreadAgnostic]
public sealed class WhenEmptyLayoutRendererWrapper : WrapperLayoutRendererBase, IRawValue, IStringValueRenderer
{
	private Func<LogEventInfo, string>? _stringValueRenderer;

	public Layout WhenEmpty { get; set; } = Layout.Empty;

	protected override void InitializeLayoutRenderer()
	{
		_stringValueRenderer = null;
		if (WhenEmpty == null || WhenEmpty == Layout.Empty)
		{
			throw new NLogConfigurationException("WhenEmpty-LayoutRenderer WhenEmpty-property must be assigned.");
		}
		base.InitializeLayoutRenderer();
		WhenEmpty.Initialize(base.LoggingConfiguration);
		Layout inner = base.Inner;
		SimpleLayout innerLayout = inner as SimpleLayout;
		if (innerLayout == null)
		{
			return;
		}
		inner = WhenEmpty;
		SimpleLayout whenEmptyLayout = inner as SimpleLayout;
		if (whenEmptyLayout != null && (innerLayout.IsFixedText || innerLayout.IsSimpleStringText) && (whenEmptyLayout.IsFixedText || whenEmptyLayout.IsSimpleStringText))
		{
			_stringValueRenderer = delegate(LogEventInfo logEvent)
			{
				string text = innerLayout.Render(logEvent);
				return (!string.IsNullOrEmpty(text)) ? text : whenEmptyLayout.Render(logEvent);
			};
		}
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner?.Render(logEvent, builder);
		if (builder.Length <= orgLength)
		{
			WhenEmpty.Render(logEvent, builder);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return _stringValueRenderer?.Invoke(logEvent);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		Layout inner = base.Inner;
		if (inner != null && inner.TryGetRawValue(logEvent, out object rawValue))
		{
			if (rawValue != null && !rawValue.Equals(string.Empty))
			{
				value = rawValue;
				return true;
			}
		}
		else if (!string.IsNullOrEmpty(base.Inner?.Render(logEvent)))
		{
			value = null;
			return false;
		}
		return WhenEmpty.TryGetRawValue(logEvent, out value);
	}
}
