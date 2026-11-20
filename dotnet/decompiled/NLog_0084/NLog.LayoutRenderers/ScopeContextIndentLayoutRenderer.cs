using System.Collections.Generic;
using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers;

[LayoutRenderer("scopeindent")]
public sealed class ScopeContextIndentLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public Layout Indent { get; set; } = Layout.FromLiteral("  ");

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string text = null;
		IList<object> allNestedStateList = ScopeContext.GetAllNestedStateList();
		for (int i = 0; i < allNestedStateList.Count; i++)
		{
			text = text ?? Indent?.Render(logEvent) ?? string.Empty;
			builder.Append(text);
		}
	}
}
