namespace Websocket.Client;

public class ReconnectionInfo
{
	public ReconnectionType Type { get; }

	public ReconnectionInfo(ReconnectionType type)
	{
		Type = type;
	}

	public static ReconnectionInfo Create(ReconnectionType type)
	{
		return new ReconnectionInfo(type);
	}
}
