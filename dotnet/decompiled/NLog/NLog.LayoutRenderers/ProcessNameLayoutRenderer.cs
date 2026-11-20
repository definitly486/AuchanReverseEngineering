using System.Text;
using NLog.Config;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers;

[LayoutRenderer("processname")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class ProcessNameLayoutRenderer : LayoutRenderer
{
	private readonly string _processFilePath;

	private readonly string _processBaseName;

	public bool FullName { get; set; }

	public ProcessNameLayoutRenderer()
		: this(LogFactory.DefaultAppEnvironment)
	{
	}

	internal ProcessNameLayoutRenderer(IAppEnvironment appEnvironment)
	{
		_processFilePath = appEnvironment.CurrentProcessFilePath;
		_processBaseName = appEnvironment.CurrentProcessBaseName;
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string value = (FullName ? _processFilePath : _processBaseName);
		builder.Append(value);
	}
}
