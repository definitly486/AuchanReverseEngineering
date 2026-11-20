namespace NLog.Config;

public interface ISetupConfigurationLoggingRuleBuilder : ISetupConfigurationTargetBuilder
{
	LoggingRule LoggingRule { get; }
}
