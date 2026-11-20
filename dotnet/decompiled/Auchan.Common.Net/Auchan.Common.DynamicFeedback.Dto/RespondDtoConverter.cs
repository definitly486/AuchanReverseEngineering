using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.DynamicFeedback.Dto;

internal static class RespondDtoConverter
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
