using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Search.DTO;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public class SearchProductsService
{
	private readonly ISearchAPI _searchAPI;

	private readonly IRequestExecutor _requestExecutor;

	public SearchProductsService(ISearchAPI searchAPI, IRequestExecutor requestExecutor)
	{
		_searchAPI = searchAPI;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<SearchResult, DomainError>> ProductsBySearchQuery(string query, int storeId, bool? isAdult, SearchRequestDTO request)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _searchAPI.ProductsBySearchQuery(query, storeId, isAdult, request, 0, "M", t))).Ensure((SearchResultDTO res) => res.Items != null && res.Items.Count > 0, new UnsuccessfulStatusCodeError(HttpStatusCode.NotFound, null)).Map((SearchResultDTO dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<SearchAutohintsResult, DomainError>> AutohintsBySearchQuery(string query, int storeId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _searchAPI.AutohintsBySearchQuery(query, storeId, 0, "M", t), cancellationToken)).Map((SearchAutohintsResultDTO dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
