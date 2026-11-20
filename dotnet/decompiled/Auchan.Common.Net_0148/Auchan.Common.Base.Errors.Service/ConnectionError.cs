namespace Auchan.Common.Base.Errors.Service;

public class ConnectionError : ServiceError
{
	public ConnectionErrorType Type { get; }

	public ConnectionError(ConnectionErrorType type)
	{
		Type = type;
	}
}
