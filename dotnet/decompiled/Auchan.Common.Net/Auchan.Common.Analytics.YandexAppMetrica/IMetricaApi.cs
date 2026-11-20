using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IMetricaApi
{
	[Post("/logs/v1/import/events.csv")]
	[Headers(new string[] { "Content-Type: text/csv" })]
	Task<string> TrackEvent([Query][AliasAs("post_api_key")] string postApiKey, [Query][AliasAs("postApiKey")] string postApiKey2, [Body] string csvContent, CancellationToken cancellationToken = default(CancellationToken));
}
