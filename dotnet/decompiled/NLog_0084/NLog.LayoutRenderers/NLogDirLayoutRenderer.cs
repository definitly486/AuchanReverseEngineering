using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("nlogdir")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class NLogDirLayoutRenderer : LayoutRenderer
{
	private static string? _nlogDir;

	private string? _nlogCombinedPath;

	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	private static string NLogDir => _nlogDir ?? (_nlogDir = ResolveNLogDir());

	protected override void InitializeLayoutRenderer()
	{
		_nlogCombinedPath = null;
		base.InitializeLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string value = _nlogCombinedPath ?? (_nlogCombinedPath = PathHelpers.CombinePaths(NLogDir, Dir, File));
		builder.Append(value);
	}

	private static string ResolveNLogDir()
	{
		string assemblyFileLocation = AssemblyHelpers.GetAssemblyFileLocation(typeof(LogFactory).Assembly);
		if (!string.IsNullOrEmpty(assemblyFileLocation))
		{
			return Path.GetDirectoryName(assemblyFileLocation);
		}
		return string.Empty;
	}
}
