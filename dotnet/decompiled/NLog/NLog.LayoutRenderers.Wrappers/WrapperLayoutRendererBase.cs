using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

public abstract class WrapperLayoutRendererBase : LayoutRenderer
{
	[DefaultParameter]
	public Layout Inner { get; set; } = Layout.Empty;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		Inner?.Initialize(base.LoggingConfiguration);
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		int length = builder.Length;
		try
		{
			RenderInnerAndTransform(logEvent, builder, length);
		}
		catch
		{
			builder.Length = length;
			throw;
		}
	}

	protected virtual void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		string text = RenderInner(logEvent);
		builder.Append(Transform(logEvent, text));
	}

	protected virtual string Transform(LogEventInfo logEvent, string text)
	{
		return Transform(text);
	}

	protected abstract string Transform(string text);

	protected virtual string RenderInner(LogEventInfo logEvent)
	{
		return Inner?.Render(logEvent) ?? string.Empty;
	}
}
