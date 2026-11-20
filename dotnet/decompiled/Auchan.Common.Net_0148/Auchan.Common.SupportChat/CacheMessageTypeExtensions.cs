namespace Auchan.Common.SupportChat;

public static class CacheMessageTypeExtensions
{
	public static bool IsStructured(this CacheMessageType messageType)
	{
		if ((uint)(messageType - 3) <= 1u)
		{
			return true;
		}
		return false;
	}
}
