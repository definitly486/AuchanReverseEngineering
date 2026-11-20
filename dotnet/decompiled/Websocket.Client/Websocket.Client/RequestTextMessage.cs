namespace Websocket.Client;

internal class RequestTextMessage : RequestMessage
{
	public string Text { get; }

	public RequestTextMessage(string text)
	{
		Text = text;
	}
}
