using NLog.Config;

namespace NLog.Internal;

internal interface ISupportsInitialize
{
	void Initialize(LoggingConfiguration? configuration);

	void Close();
}
