using System;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("machinename")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class MachineNameLayoutRenderer : LayoutRenderer
{
	private string? _machineName;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		try
		{
			_machineName = EnvironmentHelper.GetMachineName();
			if (string.IsNullOrEmpty(_machineName))
			{
				InternalLogger.Info("MachineName is not available.");
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Error getting machine name.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
			_machineName = string.Empty;
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(_machineName);
	}
}
