using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers;

[LayoutRenderer("processdir")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class ProcessDirLayoutRenderer : LayoutRenderer
{
	private readonly string _processDir;

	private string? _nlogCombinedPath;

	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	public ProcessDirLayoutRenderer()
		: this(LogFactory.DefaultAppEnvironment)
	{
	}

	internal ProcessDirLayoutRenderer(IAppEnvironment appEnvironment)
	{
		_processDir = Path.GetDirectoryName(appEnvironment.CurrentProcessFilePath);
	}

	protected override void InitializeLayoutRenderer()
	{
		_nlogCombinedPath = null;
		base.InitializeLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string value = _nlogCombinedPath ?? (_nlogCombinedPath = PathHelpers.CombinePaths(_processDir, Dir, File));
		builder.Append(value);
	}
}
