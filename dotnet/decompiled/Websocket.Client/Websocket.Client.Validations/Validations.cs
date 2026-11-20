using Websocket.Client.Exceptions;

namespace Websocket.Client.Validations;

internal static class Validations
{
	public static void ValidateInput(string value, string name)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new WebsocketBadInputException("Input string parameter '" + name + "' is null or empty. Please correct it.");
		}
	}

	public static void ValidateInput<T>(T value, string name)
	{
		if (object.Equals(value, default(T)))
		{
			throw new WebsocketBadInputException("Input parameter '" + name + "' is null. Please correct it.");
		}
	}
}
