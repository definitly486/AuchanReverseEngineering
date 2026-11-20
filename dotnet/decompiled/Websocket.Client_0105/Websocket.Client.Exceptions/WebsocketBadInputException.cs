namespace Websocket.Client.Exceptions;

public class WebsocketBadInputException : WebsocketException
{
	public WebsocketBadInputException(string message)
		: base(message)
	{
	}
}
