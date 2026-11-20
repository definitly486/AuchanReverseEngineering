using System;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet.Authorization.Managers;

namespace Auchan.Common.Profile;

public class FavoritesButtonViewModel : BaseItemViewModel
{
	private Favorites _favorites;

	private readonly bool _fromPriceChecker;

	private Product _product;

	private readonly IEcomContext _ecomContext;

	private bool _isProductDetailsScreen;

	[CompilerGenerated]
	private bool _003CProductInFavorites_003Ek__BackingField;

	public bool ProductInFavorites
	{
		[CompilerGenerated]
		get
		{
			return _003CProductInFavorites_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CProductInFavorites_003Ek__BackingField != value)
			{
				_003CProductInFavorites_003Ek__BackingField = value;
				RaisePropertyChanged("ProductInFavorites");
			}
		}
	}

	public FavoritesButtonViewModel(Product product, IEcomContext ecomContext, Favorites favorites, ILoginManager loginManager, bool isProductDetailsScreen = false, bool fromPriceChecker = false)
	{
		_isProductDetailsScreen = isProductDetailsScreen;
		_favorites = favorites;
		_fromPriceChecker = fromPriceChecker;
		_product = product;
		_ecomContext = ecomContext;
		Observable.FromEvent(delegate(Action h)
		{
			_favorites.UpdateAllHeartsStates += h;
		}, delegate(Action h)
		{
			_favorites.UpdateAllHeartsStates -= h;
		}).Subscribe(delegate
		{
			OnHeartStateChanged();
		}).AddTo(base.Disposables);
		IsProductInFavorites();
	}

	private void OnHeartStateChanged()
	{
		IsProductInFavorites();
	}

	public bool OnHeartClicked()
	{
		bool result;
		if (ProductInFavorites)
		{
			_favorites.Remove(_product);
			result = false;
		}
		else
		{
			if (_fromPriceChecker)
			{
				AppAnalytics.AppMetrica.TrackEvent("add_to_favorites_pc", ("merchant_id", _ecomContext.ActiveStore.Id.ToString()), ("product_id", _product.ProductId ?? ""));
			}
			_favorites.Add(_product);
			if (_isProductDetailsScreen)
			{
				AppAnalytics.AppMetrica.TrackEvent("productDetailScreenAddToFavorites", ("productSKU", _product.GimaId), ("productName", _product.Title));
			}
			result = true;
		}
		IsProductInFavorites();
		return result;
	}

	private void IsProductInFavorites()
	{
		ProductInFavorites = _favorites.IsProductInFavorites(_product);
		RaisePropertyChanged("ProductInFavorites");
	}
}
