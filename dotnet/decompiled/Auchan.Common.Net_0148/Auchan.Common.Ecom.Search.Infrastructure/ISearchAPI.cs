using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Search.DTO;
using Refit;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public interface ISearchAPI
{
	[Post("/search")]
	Task<SearchResultDTO> ProductsBySearchQuery([AliasAs("query")] string query, [AliasAs("merchantId")] int storeId, [AliasAs("isAdult")] bool? isAdult, [Body] SearchRequestDTO searchRequest, [AliasAs("show_hidden")] int? showHidden = 0, [AliasAs("channel")] string channel = "M", CancellationToken cancellationToken = default(CancellationToken));

	[Get("/autohints")]
	Task<SearchAutohintsResultDTO> AutohintsBySearchQuery([AliasAs("query")] string query, [AliasAs("merchantId")] int storeId, [AliasAs("show_hidden")] int? showHidden = 0, [AliasAs("channel")] string channel = "M", CancellationToken cancellationToken = default(CancellationToken));
}
