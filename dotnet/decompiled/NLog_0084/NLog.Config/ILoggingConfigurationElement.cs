using System.Collections.Generic;

namespace NLog.Config;

public interface ILoggingConfigurationElement
{
	string Name { get; }

	IEnumerable<KeyValuePair<string, string?>> Values { get; }

	IEnumerable<ILoggingConfigurationElement> Children { get; }
}
