using System;
using System.IO;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers;

[LayoutRenderer("basedir")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class BaseDirLayoutRenderer : LayoutRenderer
{
	private readonly string _appDomainDirectory;

	private string _baseDir;

	private readonly IAppEnvironment _appEnvironment;

	public bool ProcessDir { get; set; }

	public bool FixTempDir { get; set; }

	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	public BaseDirLayoutRenderer()
		: this(LogFactory.DefaultAppEnvironment)
	{
	}

	internal BaseDirLayoutRenderer(IAppEnvironment appEnvironment)
	{
		_baseDir = (_appDomainDirectory = appEnvironment.AppDomainBaseDirectory);
		_appEnvironment = appEnvironment;
	}

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		_baseDir = _appDomainDirectory;
		if (ProcessDir)
		{
			string processDir = GetProcessDir();
			if (!string.IsNullOrEmpty(processDir))
			{
				_baseDir = processDir;
			}
		}
		else if (FixTempDir)
		{
			string fixedTempBaseDir = GetFixedTempBaseDir(_appDomainDirectory);
			if (!string.IsNullOrEmpty(fixedTempBaseDir))
			{
				_baseDir = fixedTempBaseDir;
			}
		}
		_baseDir = AppEnvironmentWrapper.FixFilePathWithLongUNC(_baseDir);
		_baseDir = PathHelpers.CombinePaths(_baseDir, Dir, File);
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(_baseDir);
	}

	private string GetFixedTempBaseDir(string baseDir)
	{
		try
		{
			string userTempFilePath = _appEnvironment.UserTempFilePath;
			if (PathHelpers.IsTempDir(baseDir, userTempFilePath))
			{
				string processDir = GetProcessDir();
				if (!string.IsNullOrEmpty(processDir) && !PathHelpers.IsTempDir(processDir, userTempFilePath))
				{
					return processDir;
				}
			}
			return baseDir;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "BaseDir LayoutRenderer unexpected exception");
			return baseDir;
		}
	}

	private string GetProcessDir()
	{
		return Path.GetDirectoryName(_appEnvironment.CurrentProcessFilePath);
	}
}
