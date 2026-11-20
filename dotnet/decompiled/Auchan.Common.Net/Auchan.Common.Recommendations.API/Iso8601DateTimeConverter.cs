using Newtonsoft.Json.Converters;

namespace Auchan.Common.Recommendations.API;

public class Iso8601DateTimeConverter : IsoDateTimeConverter
{
	private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";

	public Iso8601DateTimeConverter()
	{
		base.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
	}
}
