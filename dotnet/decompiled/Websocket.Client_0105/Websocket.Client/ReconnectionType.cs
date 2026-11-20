namespace Websocket.Client;

public enum ReconnectionType
{
	Initial,
	Lost,
	NoMessageReceived,
	Error,
	ByUser,
	ByServer
}
