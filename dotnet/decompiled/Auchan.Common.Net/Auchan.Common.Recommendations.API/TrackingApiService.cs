using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;
using Polly;

namespace Auchan.Common.Recommendations.API;

internal class TrackingApiService : ITrackingApiService
{
	private readonly ITrackingApi _api;

	public TrackingApiService(ITrackingApi api)
	{
		_api = api;
	}

	public Task<Result<Unit, DomainError>> ViewProduct(ProductTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.ViewProduct(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> AddToCart(ProductTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.AddToCart(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> Order(OrderTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.Order(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> ViewCategory(CategoryViewTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.ViewCategory(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> ViewCategoryByPath(CategoryViewByPathTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.ViewCategoryByPath(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> Search(SearchTrackingRequest request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.Search(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> BatchUpload(IList<BatchItemRequest> request, CancellationToken token)
	{
		return Run((CancellationToken ct) => _api.BatchUpload(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> RecommendationTap(RecomItemInteractionRequest request, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.RecommendationTap(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> RecommendationAddedToBasket(RecomItemInteractionRequest request, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.RecommendationAddedToBasket(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> RecommendationBlockViewed(RecomBlockViewedRequest request, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.RecommendationBlockViewed(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> SetCustomer(CustomerInfoRequest customerInfo, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.SetCustomer(customerInfo, ct), token);
	}

	public Task<Result<Unit, DomainError>> ProductPlacementViewed(ProductPlacementTrackingRequest request, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.ProductPlacementViewed(request, ct), token);
	}

	public Task<Result<Unit, DomainError>> ProductPlacementClicked(ProductPlacementTrackingRequest request, CancellationToken token = default(CancellationToken))
	{
		return Run((CancellationToken ct) => _api.ProductPlacementClicked(request, ct), token);
	}

	private static Task<Result<Unit, DomainError>> Run(Func<CancellationToken, Task<HttpResponseMessage>> factory, CancellationToken token)
	{
		return Task.Run(async () => await HandleResponse(await Policy.TimeoutAsync(15).ExecuteAsync((CancellationToken ct) => factory(ct).CatchErrors(), token)));
	}

	private static async Task<Result<Unit, DomainError>> HandleResponse(Result<HttpResponseMessage, ServiceError> apiResult)
	{
		if (apiResult.IsSuccess)
		{
			HttpResponseMessage value = apiResult.Value;
			HttpStatusCode code = value.StatusCode;
			if (value.IsSuccessStatusCode)
			{
				return Result.Success<Unit, DomainError>(Unit.Default);
			}
			string text = await value.GetContentAsyncSafe();
			return Result.Failure<Unit, DomainError>(new UnknownError
			{
				Message = (text ?? code.ToString())
			});
		}
		return apiResult.Map((HttpResponseMessage r) => Unit.Default, (ServiceError error) => error.ToBaseDomainError());
	}
}
