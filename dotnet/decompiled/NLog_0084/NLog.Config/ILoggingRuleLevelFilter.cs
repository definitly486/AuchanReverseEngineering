namespace NLog.Config;

internal interface ILoggingRuleLevelFilter
{
	bool[] LogLevels { get; }

	LogLevel? FinalMinLevel { get; }

	LoggingRuleLevelFilter GetSimpleFilterForUpdate();
}
