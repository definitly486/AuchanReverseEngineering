namespace NLog.Config;

public interface ISetupLoadConfigurationBuilder
{
	LogFactory LogFactory { get; }

	LoggingConfiguration Configuration { get; set; }
}
