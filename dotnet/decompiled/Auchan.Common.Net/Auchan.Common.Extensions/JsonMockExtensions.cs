using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Auchan.Common.Extensions;

public static class JsonMockExtensions
{
	public static T? GetJsonMockDto<T>(this string fileName) where T : class
	{
		Assembly assembly = typeof(JsonMockExtensions).GetTypeInfo().Assembly;
		using StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream(assembly.GetName().Name + "." + fileName));
		return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
	}
}
