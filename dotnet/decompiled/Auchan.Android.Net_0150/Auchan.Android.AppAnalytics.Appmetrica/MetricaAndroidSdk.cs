using System;
using System.Collections.Generic;
using System.Globalization;
using Auchan.Android.AppAnalytics.YandexMetrica;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using IO.Appmetrica.Analytics;
using IO.Appmetrica.Analytics.Ecommerce;
using IO.Appmetrica.Analytics.Profile;
using Java.Math;
using Java.Util;

namespace Auchan.Android.AppAnalytics.Appmetrica;

public class MetricaAndroidSdk : IMetricaPlatformSdk
{
	private readonly Lazy<IUserContext> _userContext;

	public MetricaAndroidSdk(Lazy<IUserContext> userContext)
	{
		_userContext = userContext;
	}

	public void InitMetrica()
	{
		ProfileModel profile = _userContext.Value.Profile;
		string value = profile?.LoymaxLoyaltyId ?? profile?.FullName ?? string.Empty;
		GenderAttribute.Gender gender = profile?.Gender switch
		{
			Gender.Female => GenderAttribute.Gender.Female, 
			Gender.Male => GenderAttribute.Gender.Male, 
			Gender.Unknown => GenderAttribute.Gender.Other, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		if (gender == null)
		{
			throw new InvalidOperationException("dead code");
		}
		DateTime value2 = profile.Birthday.Value;
		int day = value2.Day;
		int month = value2.Month;
		int year = value2.Year;
		bool isAuchanEmployee = profile.IsAuchanEmployee;
		bool isConfirmedSocialStatus = profile.IsConfirmedSocialStatus;
		UserProfileUpdate userProfileUpdate = IO.Appmetrica.Analytics.Profile.Attribute.BirthDate().WithBirthDate(year, month, day) ?? throw new InvalidOperationException("dead code");
		UserProfile profile2 = UserProfile.NewBuilder().Apply(IO.Appmetrica.Analytics.Profile.Attribute.Name().WithValue(value))?.Apply(IO.Appmetrica.Analytics.Profile.Attribute.Gender().WithValue(gender))?.Apply(userProfileUpdate)?.Apply(IO.Appmetrica.Analytics.Profile.Attribute.NotificationsEnabled().WithValue(value: false))?.Apply(IO.Appmetrica.Analytics.Profile.Attribute.CustomBoolean("FLAG_EMPLOYEE").WithValue(isAuchanEmployee))?.Apply(IO.Appmetrica.Analytics.Profile.Attribute.CustomBoolean("FLAG_SOCIAL").WithValue(isConfirmedSocialStatus))?.Build() ?? throw new InvalidOperationException("dead code");
		IO.Appmetrica.Analytics.AppMetrica.SetUserProfileID(_userContext.Value.Profile?.MagentoAccountId.ToString() ?? "");
		IO.Appmetrica.Analytics.AppMetrica.ReportUserProfile(profile2);
	}

	public void ReportError(Exception error, string? message = null, IReadOnlyDictionary<string, string>? environment = null)
	{
		string p = ((!string.IsNullOrWhiteSpace(message)) ? message : ((!string.IsNullOrWhiteSpace(error.Message)) ? error.Message : "Unknown error"));
		IO.Appmetrica.Analytics.AppMetrica.PluginExtension.ReportError(AppMetricaCrashes.GetErrorDetailsFor(".net error report", error, environment), p);
	}

	public void ReportShowScreen(string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.ShowScreenEvent(CreateECommerceScreen(screenName, storeAfilNumber, searchQuery)));
	}

	public void ReportProductCardEvent(Product product, string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber, searchQuery);
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.ShowProductCardEvent(CreateECommerceProduct(product), screen));
	}

	public void ReportProductDetails(Product product, string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber, searchQuery);
		ECommerceProduct product2 = CreateECommerceProduct(product);
		ECommerceReferrer referrer = CreateReferrer(screen);
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.ShowProductDetailsEvent(product2, referrer));
	}

	public void ReportAddCartItem(ProductOffer product, decimal diff, string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber, searchQuery);
		ECommerceProduct product2 = CreateECommerceProduct(product);
		ECommerceReferrer referrer = CreateReferrer(screen);
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.AddCartItemEvent(CreateCartItem(product2, referrer, diff)));
	}

	public void ReportRemoveCartItem(ProductOffer product, decimal diff, string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber, searchQuery);
		ECommerceProduct product2 = CreateECommerceProduct(product);
		ECommerceReferrer referrer = CreateReferrer(screen);
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.RemoveCartItemEvent(CreateCartItem(product2, referrer, diff)));
	}

	public void ReportBeginCheckout(string orderNumber, IReadOnlyList<ProductOffer> products, string screenName, string storeAfilNumber, string receiveMethodId)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber);
		List<ECommerceCartItem> list = new List<ECommerceCartItem>();
		foreach (ProductOffer product2 in products)
		{
			ECommerceProduct product = CreateECommerceProduct(product2);
			ECommerceReferrer referrer = CreateReferrer(screen);
			ECommerceCartItem item = CreateCartItem(product, referrer, product2.Qty);
			list.Add(item);
		}
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.BeginCheckoutEvent(CreateOrder(orderNumber, list, storeAfilNumber, receiveMethodId)));
	}

	public void ReportPurchase(string orderNumber, IReadOnlyList<ProductOffer> products, string screenName, string storeAfilNumber, string receiveMethodId, string? coupon = null)
	{
		ECommerceScreen screen = CreateECommerceScreen(screenName, storeAfilNumber);
		List<ECommerceCartItem> list = new List<ECommerceCartItem>();
		foreach (ProductOffer product2 in products)
		{
			ECommerceProduct product = CreateECommerceProduct(product2);
			ECommerceReferrer referrer = CreateReferrer(screen);
			ECommerceCartItem item = CreateCartItem(product, referrer, product2.Qty);
			list.Add(item);
		}
		IO.Appmetrica.Analytics.AppMetrica.ReportECommerce(ECommerceEvent.PurchaseEvent(CreateOrder(orderNumber, list, storeAfilNumber, receiveMethodId, coupon)));
	}

	public void ReportAdRevenue(Auchan.Common.Analytics.YandexAppMetrica.AdRevenue adRevenue)
	{
		IO.Appmetrica.Analytics.AdRevenue.Builder builder = IO.Appmetrica.Analytics.AdRevenue.NewBuilder(new BigDecimal(adRevenue.Revenue.ToString(CultureInfo.InvariantCulture)), Currency.GetInstance(adRevenue.Currency));
		if (adRevenue.AdNetwork != null)
		{
			builder.WithAdNetwork(adRevenue.AdNetwork);
		}
		if (adRevenue.AdPlacementID != null)
		{
			builder.WithAdPlacementId(adRevenue.AdPlacementID);
		}
		if (adRevenue.AdPlacementName != null)
		{
			builder.WithAdPlacementName(adRevenue.AdPlacementName);
		}
		switch (adRevenue.AdType)
		{
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Banner:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Banner);
			break;
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Interstitial:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Interstitial);
			break;
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Mrec:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Mrec);
			break;
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Native:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Native);
			break;
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Other:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Other);
			break;
		case Auchan.Common.Analytics.YandexAppMetrica.AdType.Rewarded:
			builder.WithAdType(IO.Appmetrica.Analytics.AdType.Rewarded);
			break;
		}
		if (adRevenue.AdUnitID != null)
		{
			builder.WithAdUnitId(adRevenue.AdUnitID);
		}
		if (adRevenue.AdUnitName != null)
		{
			builder.WithAdUnitName(adRevenue.AdUnitName);
		}
		if (adRevenue.Payload != null)
		{
			builder.WithPayload(new Dictionary<string, string>(adRevenue.Payload));
		}
		if (adRevenue.Precision != null)
		{
			builder.WithPrecision(adRevenue.Precision);
		}
		IO.Appmetrica.Analytics.AppMetrica.ReportAdRevenue(builder.Build());
	}

	private ECommerceProduct CreateECommerceProduct(Product product)
	{
		ECommerceProduct eCommerceProduct = new ECommerceProduct(product.GimaId ?? string.Empty);
		eCommerceProduct.SetName(product.Title);
		string[] categoryPath = IMetricaPlatformSdk.GetCategoryPath(product);
		eCommerceProduct.SetCategoriesPath(categoryPath);
		eCommerceProduct.SetActualPrice(new ECommercePrice(new ECommerceAmount((double)(product.Price?.Value ?? 0m), "RUB")));
		eCommerceProduct.SetOriginalPrice(new ECommercePrice(new ECommerceAmount((double)(product.OldPrice?.Value ?? 0m), "RUB")));
		eCommerceProduct.SetPayload(new Dictionary<string, string>
		{
			{
				"ispromo",
				product.IsSaleActive ? "promo" : "non"
			},
			{
				"iscashback",
				(product.Cashback != null) ? "cash" : "non"
			}
		});
		return eCommerceProduct;
	}

	private ECommerceScreen CreateECommerceScreen(string screenName, string? storeAfilNumber = null, string? searchQuery = null)
	{
		ECommerceScreen eCommerceScreen = new ECommerceScreen();
		eCommerceScreen.SetName(screenName);
		if (searchQuery != null)
		{
			eCommerceScreen.SetSearchQuery(searchQuery);
		}
		if (storeAfilNumber != null)
		{
			eCommerceScreen.SetPayload(new Dictionary<string, string> { { "afil", storeAfilNumber } });
		}
		return eCommerceScreen;
	}

	private ECommerceProduct CreateECommerceProduct(ProductOffer product)
	{
		ECommerceProduct eCommerceProduct = new ECommerceProduct(product.GimaId ?? string.Empty);
		eCommerceProduct.SetName(product.Name);
		string[] categoryPath = IMetricaPlatformSdk.GetCategoryPath(product);
		eCommerceProduct.SetCategoriesPath(categoryPath);
		eCommerceProduct.SetActualPrice(new ECommercePrice(new ECommerceAmount((double)product.PricePerOneOrPerKilo, "RUB")));
		eCommerceProduct.SetOriginalPrice(new ECommercePrice(new ECommerceAmount((double)product.OldPricePerOneOrPerKilo.GetValueOrDefault(), "RUB")));
		eCommerceProduct.SetPayload(new Dictionary<string, string>
		{
			{
				"ispromo",
				product.IsSaleActive ? "promo" : "non"
			},
			{
				"iscashback",
				(product.Cashback != null) ? "cash" : "non"
			}
		});
		return eCommerceProduct;
	}

	private ECommerceReferrer CreateReferrer(ECommerceScreen screen)
	{
		return new ECommerceReferrer().SetScreen(screen);
	}

	private ECommerceCartItem CreateCartItem(ECommerceProduct product, ECommerceReferrer referrer, decimal qty)
	{
		return new ECommerceCartItem(product, new ECommercePrice(new ECommerceAmount(product.ActualPrice?.Fiat.Amount, "RUB")), (double)qty).SetReferrer(referrer);
	}

	private ECommerceOrder CreateOrder(string orderNumber, List<ECommerceCartItem> cartItems, string storeAfilNumber, string receiveMethodId, string? coupon = null)
	{
		ECommerceOrder eCommerceOrder = new ECommerceOrder(orderNumber, cartItems);
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "afil", storeAfilNumber },
			{ "receiveMethodId", receiveMethodId }
		};
		if (coupon != null)
		{
			dictionary.Add("coupon", coupon);
		}
		eCommerceOrder.SetPayload(dictionary);
		return eCommerceOrder;
	}
}
