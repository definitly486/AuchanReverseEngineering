using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.Digenetica;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Analytics;

public class EcomTracker : IEcomTracker
{
	private readonly IRocketRetailAnalytics _rocketRetail;

	private readonly IDigeneticaAnalytics _digenetica;

	private readonly AppMetrica _appMetrica;

	private readonly Lazy<ILoymaxAnalyticsService> _loymaxAnalyticsService;

	public EcomTracker(IRocketRetailAnalytics rocketRetail, IDigeneticaAnalytics digenetica, AppMetrica appMetrica, Lazy<ILoymaxAnalyticsService> loymaxAnalyticsService)
	{
		_rocketRetail = rocketRetail;
		_digenetica = digenetica;
		_appMetrica = appMetrica;
		_loymaxAnalyticsService = loymaxAnalyticsService;
	}

	public void AddToCart(ProductOffer offer)
	{
		_rocketRetail.AddToCart(offer);
		_appMetrica.AddToCart(offer, offer.Qty);
		_loymaxAnalyticsService.Value.AddToCart(offer);
	}

	public void RemoveFromCart(ProductOffer offer)
	{
		_appMetrica.RemoveFromCart(offer, offer.Qty);
		_loymaxAnalyticsService?.Value.RemoveFromCart(offer);
	}

	public void ChangeQuantity(ProductOffer offer, decimal oldQty, decimal newQty)
	{
		decimal diff = Math.Abs(newQty - oldQty);
		if (newQty > oldQty)
		{
			_rocketRetail.AddToCart(offer);
			_appMetrica.AddToCart(offer, diff);
			_loymaxAnalyticsService.Value.AddToCart(offer);
		}
		else
		{
			_appMetrica.RemoveFromCart(offer, diff);
			_loymaxAnalyticsService?.Value.RemoveFromCart(offer);
		}
	}

	public void ViewProductCellInListing(Product product, IYandexMetricaScreenViewModel screenViewModel)
	{
		_appMetrica.ProductCardView(product, screenViewModel);
	}

	public void ViewProduct(Product product, IReadOnlyList<string>? breadcrumbs)
	{
		_rocketRetail.ViewProduct(product);
		_digenetica.ViewProduct(product, breadcrumbs);
		_appMetrica.ProductDetailScreenView(product);
		_loymaxAnalyticsService.Value.ViewProduct(product);
		if (!product.InStock)
		{
			_loymaxAnalyticsService.Value.ViewUnavailableProduct(product);
		}
	}

	public void ViewCategory(long categoryId)
	{
		_loymaxAnalyticsService.Value?.ViewCategory(categoryId);
	}

	public void ViewCategoryByPath(string categoryPath)
	{
		_rocketRetail.ViewCategoryByPath(categoryPath);
	}

	public void ViewCategoryListing(long categoryId, int page, string categoryName, IReadOnlyList<Product> products, IReadOnlyList<string> breadcrumbs)
	{
		Task.Run(delegate
		{
			_digenetica.ViewProductsListing(categoryId, page, categoryName, products, breadcrumbs);
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void Search(string query, params Product[] products)
	{
		_rocketRetail.Search(query);
		if (products.Length != 0)
		{
			_digenetica.Search(query, 1, products.ToList());
		}
	}

	public void OnResumedCartScreen(decimal total, decimal subtotal, Guid cartId, IReadOnlyList<ProductOffer> products)
	{
		_appMetrica.CartScreenView();
		_digenetica.ViewCart(total, subtotal, cartId, products);
	}

	public void OpenEmptyCartScreenWithToCatalogueButton()
	{
		_appMetrica.OpenEmptyCartScreenWithToCatalogueButton();
	}

	public void TrackEmptyCartFavoritesShown()
	{
		_appMetrica.TrackEmptyCartFavoritesShown();
	}

	public void TrackEmptyCartRepeatLastOrderShown()
	{
		_appMetrica.TrackEmptyCartRepeatLastOrderShown();
	}

	public void OnEmptyCartScreenToCatalogueClick()
	{
		_appMetrica.OnEmptyCartScreenToCatalogueClick();
	}

	public void OnEmptyCartScreenToFavoritesClick()
	{
		_appMetrica.OnEmptyCartScreenToFavoritesClick();
	}

	public void OnEmptyCartScreenRepeatLastOrderClick()
	{
		_appMetrica.OnEmptyCartScreenRepeatLastOrderClick();
	}

	public void OpenCheckoutScreen()
	{
		_appMetrica.CheckoutScreenView();
	}

	public void SuccessfulPurchase(Guid cartId, IReadOnlyList<OrderDetailsDto> orderDetails)
	{
		_rocketRetail.Order(orderDetails);
		_digenetica.OrderSuccess(cartId, orderDetails);
		Task.Run(() => _appMetrica.SuccessPaymentScreenViewAsync(orderDetails)).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackPopUpCartUpdate()
	{
		Task.Run(delegate
		{
			_appMetrica.TrackPopUpCartUpdate();
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackPopUpCartUpdateButtonChange()
	{
		Task.Run(delegate
		{
			_appMetrica.TrackPopUpCartUpdateButtonChange();
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackPopUpCartUpdateButtonCancel()
	{
		Task.Run(delegate
		{
			_appMetrica.TrackPopUpCartUpdateButtonCancel();
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void AddToFavorites(Product product)
	{
		_loymaxAnalyticsService.Value.AddToFavorites(product);
	}

	public void AddToWaitList(Product product)
	{
		_loymaxAnalyticsService.Value.AddToWaitList(product);
	}
}
