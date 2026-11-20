using Newtonsoft.Json.Converters;

namespace Auchan.Common.Recommendations.API;

public class Iso8601DateTimeConverterType2 : IsoDateTimeConverter
{
	private const string DefaultDateTimeFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz";

	public Iso8601DateTimeConverterType2()
	{
		base.DateTimeFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz";
	}
}
