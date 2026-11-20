using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("currentdir")]
[ThreadAgnostic]
public class CurrentDirLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetStringValue());
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue();
	}

	private string GetStringValue()
	{
		return PathHelpers.CombinePaths(Directory.GetCurrentDirectory(), Dir, File);
	}
}
