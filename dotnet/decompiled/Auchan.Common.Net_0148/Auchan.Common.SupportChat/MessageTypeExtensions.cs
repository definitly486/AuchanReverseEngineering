using Auchan.Common.SupportChat.DTO;

namespace Auchan.Common.SupportChat;

public static class MessageTypeExtensions
{
	public static WSDataContentType ToWSDataContentType(this MessageType messageType)
	{
		return messageType switch
		{
			MessageType.Text => WSDataContentType.Text, 
			MessageType.Image => WSDataContentType.Image, 
			MessageType.File => WSDataContentType.File, 
			MessageType.Location => WSDataContentType.Location, 
			_ => WSDataContentType.Unknown, 
		};
	}
}
