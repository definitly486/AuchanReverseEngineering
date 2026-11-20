using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("tempdir")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class TempDirLayoutRenderer : LayoutRenderer
{
	private static string? _tempDir;

	private string? _nlogCombinedPath;

	private static string TempDir => _tempDir ?? (_tempDir = Path.GetTempPath());

	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	protected override void InitializeLayoutRenderer()
	{
		_nlogCombinedPath = null;
		base.InitializeLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string value = _nlogCombinedPath ?? (_nlogCombinedPath = PathHelpers.CombinePaths(TempDir, Dir, File));
		builder.Append(value);
	}
}
