using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Profile;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class CartItemUnavailableViewModel : BaseItemViewModel, IAdultsOnlyItemViewModel, INotifyPropertyChanged, IBindable, ICartItemViewModel, IIdentifiable
{
	private readonly IEcomContext _ecomContext;

	[CompilerGenerated]
	private ProductOffer _003CProductOffer_003Ek__BackingField;

	public string Title => ProductOffer.Name ?? string.Empty;

	public string? ImageUrl => ProductOffer.ImageUrl;

	public bool ShouldBlur
	{
		get
		{
			if (_ecomContext.AgeGateAgreement != AgreeState.Yes)
			{
				return ProductOffer.IsAdult;
			}
			return false;
		}
	}

	public string AdultsOnlyText => "Для лиц\nстарше 18 лет";

	public string Code => ProductOffer.Code ?? string.Empty;

	public string FindReplacementText => "Найти замену";

	public BadgesListModel Badges { get; }

	public ProductOffer ProductOffer
	{
		[CompilerGenerated]
		get
		{
			return _003CProductOffer_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CProductOffer_003Ek__BackingField == value))
			{
				_003CProductOffer_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
				RaisePropertyChanged("ImageUrl");
				RaisePropertyChanged("ShouldBlur");
				RaisePropertyChanged("Code");
				RaisePropertyChanged("ProductOffer");
			}
		}
	}

	public FavoritesButtonViewModel FavoritesButtonViewModel { get; }

	public CartItemUnavailableViewModel(ProductOffer model, IAdminContext adminContext, IEcomContext ecomContext, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory)
	{
		_ecomContext = ecomContext;
		Badges = new BadgesListModel(model.Badges);
		ProductOffer = model;
		FavoritesButtonViewModel = favoritesButtonViewModelFactory(model.Map());
	}

	public void OnItemDeleted()
	{
	}

	string IIdentifiable.GetId()
	{
		return $"unavailable:{ProductOffer.GetKey().GetHashCode()}";
	}
}
