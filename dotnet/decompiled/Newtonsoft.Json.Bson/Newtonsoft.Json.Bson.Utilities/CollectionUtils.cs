using System.Linq;

namespace Newtonsoft.Json.Bson.Utilities;

internal static class CollectionUtils
{
	public static T[] ArrayEmpty<T>()
	{
		return (Enumerable.Empty<T>() as T[]) ?? new T[0];
	}
}
