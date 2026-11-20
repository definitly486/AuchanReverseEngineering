namespace NLog.Common;

internal interface IInternalLoggerContext
{
	string Name { get; }

	LogFactory? LogFactory { get; }
}
