using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.DynamicFeedback.Responses;

internal static class UploadFulesConverter
{
	public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
	{
		MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
		DateParseHandling = DateParseHandling.None,
		Converters = { (JsonConverter)new IsoDateTimeConverter
		{
			DateTimeStyles = DateTimeStyles.AssumeUniversal
		} }
	};
}
