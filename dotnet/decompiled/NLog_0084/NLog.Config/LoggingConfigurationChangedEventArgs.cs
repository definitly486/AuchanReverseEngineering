using System;

namespace NLog.Config;

public class LoggingConfigurationChangedEventArgs : EventArgs
{
	public LoggingConfiguration? DeactivatedConfiguration { get; }

	public LoggingConfiguration? ActivatedConfiguration { get; }

	public LoggingConfigurationChangedEventArgs(LoggingConfiguration? activatedConfiguration, LoggingConfiguration? deactivatedConfiguration)
	{
		ActivatedConfiguration = activatedConfiguration;
		DeactivatedConfiguration = deactivatedConfiguration;
	}
}
