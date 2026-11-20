using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

internal class TrackingService : ITrackingService
{
	private readonly ITrackingApiService _apiService;

	private readonly IDeviceService _deviceService;

	private readonly IEcomContext _ecomContext;

	private const string LinkName = "sessionExternalId";

	public TrackingService(ITrackingApiService apiService, IDeviceService deviceService, IEcomContext ecomContext)
	{
		_apiService = apiService;
		_deviceService = deviceService;
		_ecomContext = ecomContext;
	}

	public Task<Result<Unit, DomainError>> ViewProduct(long gimaId, CancellationToken token)
	{
		ProductTrackingRequest request = BuildProductTracking(gimaId);
		return _apiService.ViewProduct(request, token);
	}

	public Task<Result<Unit, DomainError>> AddToCart(long gimaId, CancellationToken token)
	{
		ProductTrackingRequest request = BuildProductTracking(gimaId);
		return _apiService.AddToCart(request, token);
	}

	public Task<Result<Unit, DomainError>> Order(IReadOnlyList<ProductShort> products, int storeId, string transactionId, CancellationToken token)
	{
		DateTime utcNow = DateTime.UtcNow;
		string stockId = storeId.ToString();
		List<BatchItemRequest> list = new List<BatchItemRequest>(products.Count);
		foreach (ProductShort product in products)
		{
			OrderTrackingRequest request = new OrderTrackingRequest
			{
				ProductId = product.AuchanCode,
				StockId = stockId,
				Price = product.Price / product.Qty,
				Quantity = product.Qty,
				Transaction = transactionId,
				Link = new Link
				{
					Name = "sessionExternalId",
					Value = _deviceService.Udid
				},
				Timestamp = utcNow
			};
			list.Add(new BatchItemRequest("order", request));
		}
		return _apiService.BatchUpload(list, token);
	}

	public Task<Result<Unit, DomainError>> ViewCategory(long categoryId, CancellationToken token)
	{
		CategoryViewTrackingRequest request = new CategoryViewTrackingRequest
		{
			CategoryId = categoryId,
			Timestamp = DateTime.UtcNow,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			}
		};
		return _apiService.ViewCategory(request, token);
	}

	public Task<Result<Unit, DomainError>> ViewCategoryByPath(string categoryPath, CancellationToken token)
	{
		CategoryViewByPathTrackingRequest request = new CategoryViewByPathTrackingRequest
		{
			CategoryPath = categoryPath,
			Timestamp = DateTime.UtcNow,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			}
		};
		return _apiService.ViewCategoryByPath(request, token);
	}

	public Task<Result<Unit, DomainError>> Search(string query, CancellationToken token)
	{
		SearchTrackingRequest request = new SearchTrackingRequest
		{
			SearchPhrase = query,
			Timestamp = DateTime.UtcNow,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			}
		};
		return _apiService.Search(request, token);
	}

	public Task<Result<Unit, DomainError>> RecommendationTap(long gimaId, string blockId, CancellationToken token = default(CancellationToken))
	{
		RecomItemInteractionRequest request = BuildRecom(gimaId, blockId);
		return _apiService.RecommendationTap(request, token);
	}

	public Task<Result<Unit, DomainError>> RecommendationAddedToBasket(long gimaId, string blockId, CancellationToken token = default(CancellationToken))
	{
		RecomItemInteractionRequest request = BuildRecom(gimaId, blockId);
		return _apiService.RecommendationAddedToBasket(request, token);
	}

	public Task<Result<Unit, DomainError>> RecommendationBlockViewed(string blockId, CancellationToken token = default(CancellationToken))
	{
		RecomBlockViewedRequest request = new RecomBlockViewedRequest
		{
			BlockId = blockId,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow
		};
		return _apiService.RecommendationBlockViewed(request, token);
	}

	public Task<Result<Unit, DomainError>> SetCustomer(ProfileModel profile, LoyaltyCardEntity card, CancellationToken token = default(CancellationToken))
	{
		return _apiService.SetCustomer(new CustomerInfoRequest
		{
			CustomerId = (profile.ClientAccountId ?? ""),
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			},
			DefaultStockId = _ecomContext.ActiveStore.Id.ToString(),
			SoftLinks = ((card.CardNumber != null) ? new SoftLinks
			{
				LoymaxLoyalty = profile.LoymaxLoyaltyId
			} : null),
			CustomData = ((profile.FirstName != null) ? new CustomData
			{
				Name = profile.FirstName
			} : null),
			IsAgreedToReceiveMarketingMail = false,
			Timestamp = DateTime.UtcNow
		}, token);
	}

	private ProductTrackingRequest BuildProductTracking(long gimaId)
	{
		return new ProductTrackingRequest
		{
			ProductId = gimaId,
			StockId = _ecomContext.ActiveStore.Id.ToString(),
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow
		};
	}

	private RecomItemInteractionRequest BuildRecom(long gimaId, string blockId)
	{
		return new RecomItemInteractionRequest
		{
			ProductId = gimaId,
			StockId = _ecomContext.ActiveStore.Id.ToString(),
			BlockId = blockId,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow
		};
	}

	public Task<Result<Unit, DomainError>> ProductPlacementViewed(string contentId, CancellationToken token = default(CancellationToken))
	{
		return _apiService.ProductPlacementViewed(CreateProductPlacmentRequestBody(contentId), token);
	}

	public Task<Result<Unit, DomainError>> ProductPlacementClicked(string contentId, CancellationToken token = default(CancellationToken))
	{
		return _apiService.ProductPlacementClicked(CreateProductPlacmentRequestBody(contentId), token);
	}

	private ProductPlacementTrackingRequest CreateProductPlacmentRequestBody(string contentId)
	{
		return new ProductPlacementTrackingRequest
		{
			ContentId = contentId,
			Link = new Link
			{
				Name = "sessionExternalId",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow
		};
	}
}
