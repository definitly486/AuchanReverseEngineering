using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auchan.Common.Common;

public static class JsonHelper
{
	public static bool TryParseJson<T>(this string @this, out T result)
	{
		bool success = true;
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			Error = delegate(object? sender, ErrorEventArgs args)
			{
				success = false;
				args.ErrorContext.Handled = true;
			},
			MissingMemberHandling = MissingMemberHandling.Error
		};
		result = JsonConvert.DeserializeObject<T>(@this, settings);
		if (success)
		{
			return result != null;
		}
		return false;
	}
}
