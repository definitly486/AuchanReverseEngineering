namespace Websocket.Client;

public enum DisconnectionType
{
	Exit,
	Lost,
	NoMessageReceived,
	Error,
	ByUser,
	ByServer
}
