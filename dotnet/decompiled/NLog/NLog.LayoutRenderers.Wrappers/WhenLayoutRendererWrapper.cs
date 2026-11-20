using System;
using System.Text;
using NLog.Conditions;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("when")]
[AmbientProperty("When")]
[ThreadAgnostic]
public sealed class WhenLayoutRendererWrapper : WrapperLayoutRendererBase, IRawValue
{
	public ConditionExpression? When { get; set; }

	public Layout Else { get; set; } = Layout.Empty;

	protected override void InitializeLayoutRenderer()
	{
		if (When == null)
		{
			throw new NLogConfigurationException("When-LayoutRenderer When-property must be assigned.");
		}
		base.InitializeLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		int length = builder.Length;
		try
		{
			if (ShouldRenderInner(logEvent))
			{
				base.Inner?.Render(logEvent, builder);
			}
			else
			{
				Else?.Render(logEvent, builder);
			}
		}
		catch
		{
			builder.Length = length;
			throw;
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private bool ShouldRenderInner(LogEventInfo logEvent)
	{
		if (When != null)
		{
			return true.Equals(When.Evaluate(logEvent));
		}
		return true;
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		if (ShouldRenderInner(logEvent))
		{
			return TryGetRawValueFromLayout(logEvent, base.Inner, out value);
		}
		return TryGetRawValueFromLayout(logEvent, Else, out value);
	}

	private static bool TryGetRawValueFromLayout(LogEventInfo logEvent, Layout layout, out object? value)
	{
		if (layout == null)
		{
			value = null;
			return false;
		}
		return layout.TryGetRawValue(logEvent, out value);
	}
}
