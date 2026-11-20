using System;
using System.Text;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers;

[Obsolete("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform() instead. Marked obsolete in NLog 5.0")]
public abstract class WrapperLayoutRendererBuilderBase : WrapperLayoutRendererBase
{
	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (builder.Length > 0)
		{
			using (AppendBuilderCreator appendBuilderCreator = new AppendBuilderCreator(mustBeEmpty: true))
			{
				RenderFormattedMessage(logEvent, appendBuilderCreator.Builder);
				TransformFormattedMesssage(logEvent, appendBuilderCreator.Builder);
				appendBuilderCreator.Builder.CopyTo(builder);
				return;
			}
		}
		RenderFormattedMessage(logEvent, builder);
		TransformFormattedMesssage(logEvent, builder);
	}

	[Obsolete("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform() instead. Marked obsolete in NLog 4.6")]
	protected virtual void TransformFormattedMesssage(LogEventInfo logEvent, StringBuilder target)
	{
		TransformFormattedMesssage(target);
	}

	[Obsolete("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform() instead. Marked obsolete in NLog 4.6")]
	protected abstract void TransformFormattedMesssage(StringBuilder target);

	[Obsolete("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform() instead. Marked obsolete in NLog 4.6")]
	protected virtual void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		base.Inner?.Render(logEvent, target);
	}

	protected sealed override string Transform(string text)
	{
		throw new NotSupportedException("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform()");
	}

	protected sealed override string RenderInner(LogEventInfo logEvent)
	{
		throw new NotSupportedException("Inherit from WrapperLayoutRendererBase and override RenderInnerAndTransform()");
	}
}
