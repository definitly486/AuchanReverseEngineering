using System;
using System.Collections.Generic;
using System.Threading;
using AsyncAwaitBestPractices;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Recommendations;

namespace Auchan.Common.Analytics.RocketRetail;

public class RocketRetailAnalytics : IRocketRetailAnalytics
{
	private readonly Lazy<ITrackingService> _tracking;

	private readonly Lazy<IProductPostService> _productPost;

	public RocketRetailAnalytics(Lazy<ITrackingService> tracking, Lazy<IProductPostService> productPost)
	{
		_tracking = tracking;
		_productPost = productPost;
	}

	public void ViewProduct(Product product)
	{
		if (long.TryParse(product.GimaId, out var result))
		{
			_tracking.Value.ViewProduct(result, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
			_productPost.Value.ProductPost(result, product, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void AddToCart(ProductOffer offer)
	{
		if (long.TryParse(offer.GimaId, out var result))
		{
			_tracking.Value.AddToCart(result, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
			_productPost.Value.ProductPost(result, offer, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void Order(IReadOnlyList<OrderDetailsDto> orderDetails)
	{
		foreach (OrderDetailsDto orderDetail in orderDetails)
		{
			string number = orderDetail.Order.Number;
			int merchantId = orderDetail.Shop.MerchantId;
			IReadOnlyList<ProductShort> products = orderDetail.Deliveries[0].Products;
			_tracking.Value.Order(products, merchantId, number, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void ViewCategory(long categoryId)
	{
		_tracking.Value.ViewCategory(categoryId, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void ViewCategoryByPath(string categoryPath)
	{
		_tracking.Value.ViewCategoryByPath(categoryPath, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void Search(string query)
	{
		_tracking.Value.Search(query, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void RecommendationTap(ProductItemViewModel recomItem)
	{
		if (!recomItem.RecomAnalytics.IsEmpty && long.TryParse(recomItem.Product.GimaId, out var result))
		{
			_tracking.Value.RecommendationTap(result, recomItem.RecomAnalytics.BlockId, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void RecommendationAddedToBasket(ProductItemViewModel recomItem)
	{
		if (!recomItem.RecomAnalytics.IsEmpty && long.TryParse(recomItem.Product.GimaId, out var result))
		{
			_tracking.Value.RecommendationAddedToBasket(result, recomItem.RecomAnalytics.BlockId, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void RecommendationBlockViewed(string blockId)
	{
		_tracking.Value.RecommendationBlockViewed(blockId, CancellationToken.None).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void ProductPlacementViewed(ProductItemViewModel recomItem)
	{
		if (!recomItem.RecomAnalytics.IsEmpty && !string.IsNullOrEmpty(recomItem.RecomAnalytics.ProductPlacementContentId))
		{
			_tracking.Value.ProductPlacementViewed(recomItem.RecomAnalytics.ProductPlacementContentId).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void ProductPlacementClicked(ProductItemViewModel recomItem)
	{
		if (!recomItem.RecomAnalytics.IsEmpty && !string.IsNullOrEmpty(recomItem.RecomAnalytics.ProductPlacementContentId))
		{
			_tracking.Value.ProductPlacementClicked(recomItem.RecomAnalytics.ProductPlacementContentId).SafeFireAndForget((Action<Exception>)null, false);
		}
	}
}
