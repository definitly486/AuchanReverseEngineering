using System;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("hostname")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class HostNameLayoutRenderer : LayoutRenderer
{
	private string? _hostName;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		try
		{
			_hostName = GetHostName();
			if (string.IsNullOrEmpty(_hostName))
			{
				InternalLogger.Info("HostName is not available.");
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Error getting host name.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
			_hostName = string.Empty;
		}
	}

	private static string GetHostName()
	{
		return TryLookupValue(() => Environment.GetEnvironmentVariable("HOSTNAME"), "HOSTNAME") ?? TryLookupValue(() => Environment.GetEnvironmentVariable("COMPUTERNAME"), "COMPUTERNAME") ?? TryLookupValue(() => Environment.GetEnvironmentVariable("MACHINENAME"), "MACHINENAME") ?? TryLookupValue(() => Environment.MachineName, "MachineName") ?? string.Empty;
	}

	private static string? TryLookupValue(Func<string> lookupFunc, string lookupType)
	{
		try
		{
			string text = lookupFunc()?.Trim();
			return string.IsNullOrEmpty(text) ? null : text;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "Failed to lookup {0}", new ReadOnlySpan<object>(new object[1] { lookupType }));
			return null;
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(_hostName);
	}
}
