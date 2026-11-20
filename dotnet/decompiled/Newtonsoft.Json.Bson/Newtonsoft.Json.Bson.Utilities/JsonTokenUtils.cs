namespace Newtonsoft.Json.Bson.Utilities;

internal static class JsonTokenUtils
{
	internal static bool IsPrimitiveToken(JsonToken token)
	{
		if ((uint)(token - 7) <= 5u || (uint)(token - 16) <= 1u)
		{
			return true;
		}
		return false;
	}
}
