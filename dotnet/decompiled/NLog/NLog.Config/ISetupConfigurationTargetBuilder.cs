using System.Collections.Generic;
using NLog.Targets;

namespace NLog.Config;

public interface ISetupConfigurationTargetBuilder
{
	LoggingConfiguration Configuration { get; }

	LogFactory LogFactory { get; }

	IList<Target> Targets { get; }
}
