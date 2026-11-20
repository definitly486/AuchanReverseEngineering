using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers;

[LayoutRenderer("processid")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class ProcessIdLayoutRenderer : LayoutRenderer, IRawValue
{
	private readonly int _processId;

	public ProcessIdLayoutRenderer()
		: this(LogFactory.DefaultAppEnvironment)
	{
	}

	internal ProcessIdLayoutRenderer(IAppEnvironment appEnvironment)
	{
		_processId = appEnvironment.CurrentProcessId;
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.AppendInvariant(_processId);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = _processId;
		return true;
	}
}
