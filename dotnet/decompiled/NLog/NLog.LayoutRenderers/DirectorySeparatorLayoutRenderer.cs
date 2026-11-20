using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("dir-separator")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class DirectorySeparatorLayoutRenderer : LayoutRenderer, IRawValue
{
	private readonly char _separatorChar = Path.DirectorySeparatorChar;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(_separatorChar);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = _separatorChar;
		return true;
	}
}
