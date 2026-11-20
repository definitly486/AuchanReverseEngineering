using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Deeplinks;
using Auchan.Common.DependencyInjection;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products.Gluings;
using Auchan.Common.Ecom.Products.Modifications;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Model;
using Auchan.Common.StoreReview;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using DryIoc;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class ProductDetailsViewModel : ScreenViewModel, IModificationsViewModel, IBindable, INotifyPropertyChanged, IYandexMetricaScreenViewModel, IScreenViewModel, IReviewListViewModel, ProductFooterViewModel.IModificationsSource
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Empty
	}

	public enum ForCase
	{
		Default,
		PriceChecker
	}

	public class Parameter
	{
		public Product? Product { get; set; }

		public string? ProductCode { get; set; }

		public string? GimaId { get; set; }

		public List<string>? Breadcrumbs { get; set; }

		public ForCase ForCase { get; set; }

		public bool OfflinePurchase { get; set; }

		public bool ReplaceLastInBackStack { get; set; }

		public string? CtmShelfBlockId { get; set; }

		[JsonConstructor]
		public Parameter()
		{
		}

		public Parameter(Product product, ForCase forCase = ForCase.Default)
		{
			Product = product;
			ForCase = forCase;
		}

		public Parameter(string? productCode, string? gimaId = null)
		{
			ProductCode = productCode;
			GimaId = gimaId;
		}
	}

	public sealed class BrandOrCategory
	{
		private readonly BrandDto? _brand;

		private readonly CategoryCodeDto? _category;

		public string Title => _brand?.Name ?? _category?.Name ?? string.Empty;

		public BrandOrCategory(BrandDto brand)
		{
			_brand = brand;
		}

		public BrandOrCategory(CategoryCodeDto category)
		{
			_category = category;
		}

		public bool TryGetBrand([NotNullWhen(true)] out BrandDto? brand)
		{
			if (_brand != null)
			{
				brand = _brand;
				return true;
			}
			brand = null;
			return false;
		}

		public bool TryGetCategory([NotNullWhen(true)] out CategoryCodeDto? category)
		{
			if (_category != null)
			{
				category = _category;
				return true;
			}
			category = null;
			return false;
		}
	}

	private const int CharacteristicsLimit = 5;

	private Product? _product;

	private readonly Parameter _parameter;

	private readonly IUserContext _userContext;

	private readonly IAdminContext _adminContext;

	private readonly ILoginManager _loginManager;

	private readonly IEcomContext _ecomContext;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IAgeGateDialog _ageGateDialog;

	private readonly IProductsRepository _productsRepository;

	private readonly IDataBroker _dataBroker;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly IDictionary<string, SelectedModification> _selectedModifications = new Dictionary<string, SelectedModification>();

	private readonly Func<ProductModification, ICollection<IDisposable>, ProductModificationItemViewModel> _viewModelFactory;

	private readonly Func<Product, bool, bool, FavoritesButtonViewModel> _favoritesButtonViewModelFactory;

	private readonly ReviewCheckAddingService _reviewCheckAddingService;

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly Func<ProductDetailsNutrientsElementViewModel.Parameter, ProductDetailsNutrientsElementViewModel> _nutrientsVMFactory;

	private NotAuthReopenScreenService _notAuthReopenScreenService;

	[CompilerGenerated]
	private ReviewList? _003CReviewList_003Ek__BackingField;

	[CompilerGenerated]
	private Rate? _003CRate_003Ek__BackingField;

	[CompilerGenerated]
	private ReviewRewardSticker? _003CReviewRewardSticker_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CReviewingIsAllowed_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<ReviewItemViewModel> _003CReviews_003Ek__BackingField;

	[CompilerGenerated]
	private FavoritesButtonViewModel? _003CFavoritesButtonViewModel_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private BadgesListModel _003CBadges_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<string> _003CImageUrls_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003COldPrice_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CDiscountValue_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CCashbackAmount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsDelayedCashback_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CDiscountEndDate_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLoyaltyProgramDiscount_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CUnitTypeText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CUnitTypeInfoButtonVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CPrice_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CStockInfo_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CCurrentStoreAddress_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CProductInStock_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CAvailableShopsForPickup_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsBlockShopsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShareAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CShareUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAllCharacteristicsString_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CAllCharacteristicsButtonVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CProductDetailsOpen_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CDescription_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDescriptionVisible_003Ek__BackingField;

	[CompilerGenerated]
	private List<CharacteristicItemViewModel> _003CAllCharacteristics_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<CharacteristicItemViewModel> _003CCharacteristics_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<ProductModificationItemViewModel> _003CModifications_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<ProductGluingRowViewModel> _003CGluingRows_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<AvailableShop>? _003CAvailableShops_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<BrandOrCategory> _003CBrandsAndCategories_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSaleActive_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsShowAdultSnack_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsBadHabitSnack_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPriceVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWarningVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsNotAvaliableInCurrentShopVisible_003Ek__BackingField;

	public ReviewList? ReviewList
	{
		[CompilerGenerated]
		get
		{
			return _003CReviewList_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReviewList_003Ek__BackingField, value))
			{
				ReviewList reviewList = ReviewList;
				_003CReviewList_003Ek__BackingField = value;
				ReviewList reviewList2 = ReviewList;
				OnReviewListChanged(reviewList, reviewList2);
				RaisePropertyChanged("ReviewList");
			}
		}
	}

	public Rate? Rate
	{
		[CompilerGenerated]
		get
		{
			return _003CRate_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CRate_003Ek__BackingField, value))
			{
				_003CRate_003Ek__BackingField = value;
				RaisePropertyChanged("ReviewCountText");
				RaisePropertyChanged("Rate");
			}
		}
	}

	public ReviewRewardSticker? ReviewRewardSticker
	{
		[CompilerGenerated]
		get
		{
			return _003CReviewRewardSticker_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReviewRewardSticker_003Ek__BackingField, value))
			{
				_003CReviewRewardSticker_003Ek__BackingField = value;
				RaisePropertyChanged("ReviewRewardSticker");
			}
		}
	}

	public bool ReviewingIsAllowed
	{
		[CompilerGenerated]
		get
		{
			return _003CReviewingIsAllowed_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CReviewingIsAllowed_003Ek__BackingField != value)
			{
				_003CReviewingIsAllowed_003Ek__BackingField = value;
				RaisePropertyChanged("ReviewingIsAllowed");
			}
		}
	}

	public IReadOnlyList<ReviewItemViewModel> Reviews
	{
		[CompilerGenerated]
		get
		{
			return _003CReviews_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReviews_003Ek__BackingField, value))
			{
				_003CReviews_003Ek__BackingField = value;
				RaisePropertyChanged("Reviews");
			}
		}
	} = Array.Empty<ReviewItemViewModel>();

	public UICommand<OpenThumbnailRequest> OpenThumbnailCommand { get; } = new UICommand<OpenThumbnailRequest>();

	public UICommand<ReviewDetailsViewModel.Parameter> OpenReviewDetailsCommand { get; } = new UICommand<ReviewDetailsViewModel.Parameter>();

	public UICommand<string> ShowReviewRewardTooltipCommand { get; } = new UICommand<string>();

	public FavoritesButtonViewModel? FavoritesButtonViewModel
	{
		[CompilerGenerated]
		get
		{
			return _003CFavoritesButtonViewModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFavoritesButtonViewModel_003Ek__BackingField, value))
			{
				_003CFavoritesButtonViewModel_003Ek__BackingField = value;
				RaisePropertyChanged("FavoritesButtonViewModel");
			}
		}
	}

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = string.Empty;

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public bool IsAuthorized => _userContext.Authorized;

	public BadgesListModel Badges
	{
		[CompilerGenerated]
		get
		{
			return _003CBadges_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CBadges_003Ek__BackingField == value))
			{
				_003CBadges_003Ek__BackingField = value;
				RaisePropertyChanged("IsDelayedCashbackBadgeVisible");
				RaisePropertyChanged("IsDelayedCashbackTextVisible");
				RaisePropertyChanged("Badges");
			}
		}
	} = BadgesListModel.Empty;

	public IReadOnlyList<ProductCertificate> ProductsCertificate => _product?.ProductsCertificate ?? Array.Empty<ProductCertificate>();

	public bool IsProductVerifiedVisible => ProductsCertificate.Count > 0;

	public string ProductVerifiedTitle => "Товар проверен";

	public IReadOnlyList<string> ImageUrls
	{
		[CompilerGenerated]
		get
		{
			return _003CImageUrls_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CImageUrls_003Ek__BackingField, value))
			{
				_003CImageUrls_003Ek__BackingField = value;
				RaisePropertyChanged("ImageUrls");
			}
		}
	} = Array.Empty<string>();

	public string? Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public string? OldPrice
	{
		[CompilerGenerated]
		get
		{
			return _003COldPrice_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003COldPrice_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COldPrice_003Ek__BackingField = value;
				RaisePropertyChanged("OldPrice");
			}
		}
	}

	public string? DiscountValue
	{
		[CompilerGenerated]
		get
		{
			return _003CDiscountValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDiscountValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDiscountValue_003Ek__BackingField = value;
				RaisePropertyChanged("DiscountValue");
			}
		}
	}

	public string? CashbackAmount
	{
		[CompilerGenerated]
		get
		{
			return _003CCashbackAmount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCashbackAmount_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCashbackAmount_003Ek__BackingField = value;
				RaisePropertyChanged("CashbackAmount");
			}
		}
	}

	public bool IsDelayedCashback
	{
		[CompilerGenerated]
		get
		{
			return _003CIsDelayedCashback_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsDelayedCashback_003Ek__BackingField != value)
			{
				_003CIsDelayedCashback_003Ek__BackingField = value;
				RaisePropertyChanged("IsDelayedCashbackBadgeVisible");
				RaisePropertyChanged("IsDelayedCashbackTextVisible");
				RaisePropertyChanged("IsDelayedCashback");
			}
		}
	}

	public LinkedText DelayedCashbackText => new LinkedText("Баллы за этот товар станут активны через 14 дней после покупки в соответствии с правилами программы лояльности", "программы лояльности", delegate
	{
		OpenInternalDocumentCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
	});

	public bool IsDelayedCashbackTextVisible
	{
		get
		{
			if (IsDelayedCashbackBadgeVisible)
			{
				return !ShouldDisplayStamps;
			}
			return false;
		}
	}

	public bool IsDelayedCashbackBadgeVisible
	{
		get
		{
			if (Badges.VisibleItems.Any((BadgeItemViewModel b) => b.Item.BadgeType == BadgeType.DelayedCashback))
			{
				return IsDelayedCashback;
			}
			return false;
		}
	}

	public string DiscountBy
	{
		get
		{
			if (!IsSaleActive || !IsLoyaltyProgramDiscount)
			{
				return "Скидка";
			}
			return "Скидка по карте Ашан";
		}
	}

	public string OkEmptyText => "Понятно";

	public string EmptyOffersText => "Скоро появятся новые предложения";

	public string? DiscountEndDate
	{
		[CompilerGenerated]
		get
		{
			return _003CDiscountEndDate_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDiscountEndDate_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDiscountEndDate_003Ek__BackingField = value;
				RaisePropertyChanged("DiscountEndDate");
			}
		}
	}

	public bool IsLoyaltyProgramDiscount
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLoyaltyProgramDiscount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLoyaltyProgramDiscount_003Ek__BackingField != value)
			{
				_003CIsLoyaltyProgramDiscount_003Ek__BackingField = value;
				RaisePropertyChanged("DiscountBy");
				RaisePropertyChanged("IsLoyaltyProgramDiscount");
			}
		}
	}

	public string? UnitTypeText
	{
		[CompilerGenerated]
		get
		{
			return _003CUnitTypeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CUnitTypeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CUnitTypeText_003Ek__BackingField = value;
				RaisePropertyChanged("UnitTypeText");
			}
		}
	}

	public bool UnitTypeInfoButtonVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CUnitTypeInfoButtonVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CUnitTypeInfoButtonVisible_003Ek__BackingField != value)
			{
				_003CUnitTypeInfoButtonVisible_003Ek__BackingField = value;
				RaisePropertyChanged("UnitTypeInfoButtonVisible");
			}
		}
	}

	public string? Price
	{
		[CompilerGenerated]
		get
		{
			return _003CPrice_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPrice_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPrice_003Ek__BackingField = value;
				RaisePropertyChanged("Price");
			}
		}
	}

	public string StockInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CStockInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStockInfo_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStockInfo_003Ek__BackingField = value;
				RaisePropertyChanged("StockInfo");
			}
		}
	} = string.Empty;

	public string? CurrentStoreAddress
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentStoreAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCurrentStoreAddress_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCurrentStoreAddress_003Ek__BackingField = value;
				RaisePropertyChanged("CurrentStoreAddress");
			}
		}
	}

	public bool ProductInStock
	{
		[CompilerGenerated]
		get
		{
			return _003CProductInStock_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CProductInStock_003Ek__BackingField != value)
			{
				_003CProductInStock_003Ek__BackingField = value;
				RaisePropertyChanged("TopPriceVisible");
				RaisePropertyChanged("TopOldPriceVisible");
				RaisePropertyChanged("ProductInStock");
			}
		}
	}

	public string? AvailableShopsForPickup
	{
		[CompilerGenerated]
		get
		{
			return _003CAvailableShopsForPickup_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAvailableShopsForPickup_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAvailableShopsForPickup_003Ek__BackingField = value;
				RaisePropertyChanged("IsAvailableShopsForPickup");
				RaisePropertyChanged("AvailableShopsForPickup");
			}
		}
	}

	public bool IsAvailableShopsForPickup => !string.IsNullOrEmpty(AvailableShopsForPickup);

	public bool IsBlockShopsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CIsBlockShopsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsBlockShopsAvailable_003Ek__BackingField != value)
			{
				_003CIsBlockShopsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("IsBlockShopsAvailable");
			}
		}
	}

	public ProductFooterViewModel Footer { get; }

	public bool IsForPriceCheckerCase => _parameter.ForCase == ForCase.PriceChecker;

	public bool ShareAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CShareAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CShareAvailable_003Ek__BackingField != value)
			{
				_003CShareAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("ShareAvailable");
			}
		}
	}

	public string ShareUrl
	{
		[CompilerGenerated]
		get
		{
			return _003CShareUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CShareUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CShareUrl_003Ek__BackingField = value;
				RaisePropertyChanged("ShareUrl");
			}
		}
	} = string.Empty;

	public bool ShouldDisplayStampsInformer
	{
		get
		{
			if (ShouldDisplayStamps)
			{
				return _adminContext.StampsConfig?.ProductDetailsInformerAvailable == true;
			}
			return false;
		}
	}

	public bool ShouldDisplayStamps
	{
		get
		{
			if (_adminContext.StampsConfig?.ShowStampsToCurrentUser == true)
			{
				return (_product?.Collectible?.Stamps).GetValueOrDefault() > 0;
			}
			return false;
		}
	}

	public LinkedText? StampsInformerText => _adminContext.StampsConfig?.ProductDetailsInformerLinkedText(delegate(string url)
	{
		if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
		{
			if (!url.ToLower().StartsWith("auchan://"))
			{
				try
				{
					Browser.OpenAsync(url);
					return;
				}
				catch
				{
					return;
				}
			}
			_universalLinksService.HandleLink(url);
		}
		else
		{
			OpenInternalDocumentCommand.Trigger(new InfoPageViewModel.Parameter(url));
		}
	});

	public string ProductDetailsText => "Подробнее о товаре";

	public string MoreDescriptionString => "еще";

	public int MaxDescriptionLinesCollapsed => 3;

	public string AllCharacteristicsString
	{
		[CompilerGenerated]
		get
		{
			return _003CAllCharacteristicsString_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAllCharacteristicsString_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAllCharacteristicsString_003Ek__BackingField = value;
				RaisePropertyChanged("AllCharacteristicsString");
			}
		}
	} = "Смотреть все";

	public string ReviewCountText
	{
		get
		{
			int valueOrDefault = (Rate?.ReviewsCount).GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				return $"{valueOrDefault} {GrammarHelper.DeclineNoun(valueOrDefault, new string[3] { "отзыв", "отзыва", "отзывов" })}";
			}
			return "Нет отзывов";
		}
	}

	public string ReviewsTitle => "Отзывы о товаре";

	public string ShowAllReviewsButtonTitle => "Все";

	public string AddReviewButtonTitle => "Написать отзыв";

	public string NoReviewsText => "У этого товара еще нет отзывов, будьте первыми!";

	public bool AllCharacteristicsButtonVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CAllCharacteristicsButtonVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CAllCharacteristicsButtonVisible_003Ek__BackingField != value)
			{
				_003CAllCharacteristicsButtonVisible_003Ek__BackingField = value;
				RaisePropertyChanged("AllCharacteristicsButtonVisible");
			}
		}
	}

	public bool ProductDetailsOpen
	{
		[CompilerGenerated]
		get
		{
			return _003CProductDetailsOpen_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CProductDetailsOpen_003Ek__BackingField != value)
			{
				_003CProductDetailsOpen_003Ek__BackingField = value;
				RaisePropertyChanged("ProductDetailsOpen");
			}
		}
	}

	public string? Description
	{
		[CompilerGenerated]
		get
		{
			return _003CDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescription_003Ek__BackingField = value;
				RaisePropertyChanged("Description");
			}
		}
	}

	public bool DescriptionVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CDescriptionVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CDescriptionVisible_003Ek__BackingField != value)
			{
				_003CDescriptionVisible_003Ek__BackingField = value;
				RaisePropertyChanged("DescriptionVisible");
			}
		}
	}

	public List<CharacteristicItemViewModel> AllCharacteristics
	{
		[CompilerGenerated]
		get
		{
			return _003CAllCharacteristics_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAllCharacteristics_003Ek__BackingField, value))
			{
				_003CAllCharacteristics_003Ek__BackingField = value;
				RaisePropertyChanged("AllCharacteristics");
			}
		}
	} = new List<CharacteristicItemViewModel>();

	public ObservableRangeCollection<CharacteristicItemViewModel> Characteristics
	{
		[CompilerGenerated]
		get
		{
			return _003CCharacteristics_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCharacteristics_003Ek__BackingField, value))
			{
				_003CCharacteristics_003Ek__BackingField = value;
				RaisePropertyChanged("Characteristics");
			}
		}
	} = new ObservableRangeCollection<CharacteristicItemViewModel>();

	public ObservableRangeCollection<ProductModificationItemViewModel> Modifications
	{
		[CompilerGenerated]
		get
		{
			return _003CModifications_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CModifications_003Ek__BackingField, value))
			{
				_003CModifications_003Ek__BackingField = value;
				RaisePropertyChanged("Auchan.Common.Ecom.Products.Modifications.IModificationsViewModel.Modifications");
				RaisePropertyChanged("IsAllModificationsSeleted");
				RaisePropertyChanged("Auchan.Common.Ecom.Products.ViewModels.ProductFooterViewModel.IModificationsSource.IsSelectionComplete");
				RaisePropertyChanged("Modifications");
			}
		}
	} = new ObservableRangeCollection<ProductModificationItemViewModel>();

	private IReadOnlyList<SelectedModification> SelectedModifications
	{
		get
		{
			List<SelectedModification> list = new List<SelectedModification>();
			list.AddRange(_selectedModifications.Select<KeyValuePair<string, SelectedModification>, SelectedModification>((KeyValuePair<string, SelectedModification> c) => c.Value));
			return new _003C_003Ez__ReadOnlyList<SelectedModification>(list);
		}
	}

	public ObservableRangeCollection<ProductGluingRowViewModel> GluingRows
	{
		[CompilerGenerated]
		get
		{
			return _003CGluingRows_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CGluingRows_003Ek__BackingField, value))
			{
				_003CGluingRows_003Ek__BackingField = value;
				RaisePropertyChanged("GluingRows");
			}
		}
	} = new ObservableRangeCollection<ProductGluingRowViewModel>();

	public IReadOnlyList<AvailableShop>? AvailableShops
	{
		[CompilerGenerated]
		get
		{
			return _003CAvailableShops_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAvailableShops_003Ek__BackingField, value))
			{
				_003CAvailableShops_003Ek__BackingField = value;
				RaisePropertyChanged("AvailableShops");
			}
		}
	} = Array.Empty<AvailableShop>();

	IReadOnlyList<IModificationItemViewModel> IModificationsViewModel.Modifications => Modifications;

	public IReadOnlyList<BrandOrCategory> BrandsAndCategories
	{
		[CompilerGenerated]
		get
		{
			return _003CBrandsAndCategories_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CBrandsAndCategories_003Ek__BackingField, value))
			{
				_003CBrandsAndCategories_003Ek__BackingField = value;
				RaisePropertyChanged("IsBrandsAndCategoriesVisible");
				RaisePropertyChanged("BrandsAndCategories");
			}
		}
	} = Array.Empty<BrandOrCategory>();

	public bool IsBrandsAndCategoriesVisible => BrandsAndCategories.Any();

	public string EmptyGoodsTitle => "Скоро появятся новые предложения";

	public bool IsSaleActive
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSaleActive_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsSaleActive_003Ek__BackingField != value)
			{
				_003CIsSaleActive_003Ek__BackingField = value;
				RaisePropertyChanged("DiscountBy");
				RaisePropertyChanged("IsDiscountBadgeVisible");
				RaisePropertyChanged("TopOldPriceVisible");
				RaisePropertyChanged("IsSaleActive");
			}
		}
	}

	public bool IsDiscountBadgeVisible
	{
		get
		{
			if (IsSaleActive)
			{
				return !IsForPriceCheckerCase;
			}
			return false;
		}
	}

	public bool IsShowAdultSnack
	{
		[CompilerGenerated]
		get
		{
			return _003CIsShowAdultSnack_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsShowAdultSnack_003Ek__BackingField != value)
			{
				_003CIsShowAdultSnack_003Ek__BackingField = value;
				RaisePropertyChanged("IsShowAdultSnack");
			}
		}
	}

	public bool IsBadHabitSnack
	{
		[CompilerGenerated]
		get
		{
			return _003CIsBadHabitSnack_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsBadHabitSnack_003Ek__BackingField != value)
			{
				_003CIsBadHabitSnack_003Ek__BackingField = value;
				RaisePropertyChanged("IsBadHabitSnack");
			}
		}
	}

	public string AgeSnackInfoText => "Продажа товара возможна только для лиц старше 18 лет при наличии документа, удостоверяющего личность.";

	public string PickupSnackInfoText => "Только самовывоз из магазина с оплатой при получении.";

	public string BadHabitSnackInfoText => "Этот продукт не исключает риски для здоровья и вызывает зависимость";

	public Deeplink LinkToCart { get; } = new Deeplink(DeeplinkType.Cart, string.Empty);

	public UICommand<BrokerToken> NavigateToCategoryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductsViewModel.Parameter> NavigateToProductsByBrandCommand { get; } = new UICommand<ProductsViewModel.Parameter>();

	public UICommand CloseProductDetailsCommand { get; } = new UICommand();

	public UICommand AddReviewCommand { get; } = new UICommand();

	public UICommand<BrokerToken> NavigateToAddReviewCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<Parameter> NavigateToProductCommand { get; } = new UICommand<Parameter>();

	public UICommand<InfoPageViewModel.Parameter> OpenInternalDocumentCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand<ProductDetailsNutrientsElementViewModel> ShowNutrientsCommand { get; } = new UICommand<ProductDetailsNutrientsElementViewModel>();

	public UICommand ShowAllCharacteristicsCommand { get; } = new UICommand();

	public UICommand ShareCommand { get; } = new UICommand();

	public UICommand<Review> OnMenuOptionsCommand { get; } = new UICommand<Review>();

	public UICommand<BrokerToken> OpenMenuOptionsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand OnProductDetailsCommand { get; } = new UICommand();

	public string ErrorButtonTitle => "Повторить";

	public RecommendationsViewModel BottomRecommendations { get; }

	public RecommendationsViewModel TopRecommendations { get; }

	public bool PriceVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CPriceVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CPriceVisible_003Ek__BackingField != value)
			{
				_003CPriceVisible_003Ek__BackingField = value;
				RaisePropertyChanged("TopPriceVisible");
				RaisePropertyChanged("PriceVisible");
			}
		}
	}

	public bool TopPriceVisible
	{
		get
		{
			if (!ProductInStock)
			{
				return PriceVisible;
			}
			return false;
		}
	}

	public bool TopOldPriceVisible
	{
		get
		{
			if (!ProductInStock)
			{
				return IsSaleActive;
			}
			return false;
		}
	}

	public bool IsWarningVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWarningVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsWarningVisible_003Ek__BackingField != value)
			{
				_003CIsWarningVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsWarningVisible");
			}
		}
	}

	public bool IsNotAvaliableInCurrentShopVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsNotAvaliableInCurrentShopVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsNotAvaliableInCurrentShopVisible_003Ek__BackingField != value)
			{
				_003CIsNotAvaliableInCurrentShopVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsNotAvaliableInCurrentShopVisible");
			}
		}
	}

	public string WarningMessage => "Выберите цвет и укажите размер для добавления в корзину!";

	public UICommand<BrandOrCategory> BrandOrCategoryCommand { get; } = new UICommand<BrandOrCategory>();

	public string FeedbackButtonTitle => "Сообщить о неточности";

	public UICommand FeedbackCommand { get; } = new UICommand();

	public UICommand<DynamicFeedbackViewModel.Parameter> NavigateToFeedback { get; } = new UICommand<DynamicFeedbackViewModel.Parameter>();

	private bool IsAllModificationsSeleted => _selectedModifications.Count == Modifications.Count;

	IReadOnlyList<SelectedModification> ProductFooterViewModel.IModificationsSource.SelectedModifications => _selectedModifications.Values.ToImmutableList();

	bool ProductFooterViewModel.IModificationsSource.IsSelectionComplete => IsAllModificationsSeleted;

	bool ProductFooterViewModel.IModificationsSource.DimAddToCartUntilSelectionComplete => true;

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => (IsForPriceCheckerCase ? "pc_" : "") + "Item_" + _product?.Title;

	public ProductDetailsViewModel(Parameter parameter, IAdminContext adminContext, IUserContext userContext, ILoginManager loginManager, IEcomContext ecomContext, IAgeGateDialog ageGateDialog, IProductsRepository productsRepository, IUniversalLinksService universalLinksService, IInfoMessageService infoMessageService, IDataBroker dataBroker, DefaultErrorTranslator errorTranslator, RecommendationsViewModel bottomRecommendations, RecommendationsViewModel topRecommendations, Func<ProductModification, ICollection<IDisposable>, ProductModificationItemViewModel> viewModelFactory, Func<Product, bool, bool, FavoritesButtonViewModel> favoritesButtonViewModelFactory, ReviewsEcomService reviewsEcomService, ReviewCheckAddingService reviewCheckAddingService, Func<ProductDetailsNutrientsElementViewModel.Parameter, ProductDetailsNutrientsElementViewModel> nutrientsVMFactory, Func<RecommendationBuilder> recommendationBuilderFactory, NotAuthReopenScreenService notAuthReopenScreenService, Func<ProductFooterViewModel.Parameter, ProductFooterViewModel> footerViewModelFactory)
	{
		ProductDetailsViewModel productDetailsViewModel = this;
		_parameter = parameter;
		_adminContext = adminContext;
		_userContext = userContext;
		_loginManager = loginManager;
		_productsRepository = productsRepository;
		_dataBroker = dataBroker;
		_errorTranslator = errorTranslator;
		_universalLinksService = universalLinksService;
		_infoMessageService = infoMessageService;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_viewModelFactory = viewModelFactory;
		_nutrientsVMFactory = nutrientsVMFactory;
		_favoritesButtonViewModelFactory = favoritesButtonViewModelFactory;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_notAuthReopenScreenService = notAuthReopenScreenService;
		_reviewCheckAddingService = reviewCheckAddingService;
		_reviewsEcomService = reviewsEcomService;
		Footer = footerViewModelFactory(new ProductFooterViewModel.Parameter
		{
			IsForPriceChecker = (parameter.ForCase == ForCase.PriceChecker),
			Breadcrumbs = parameter.Breadcrumbs,
			CtmShelfBlockId = parameter.CtmShelfBlockId
		}).AddTo(base.CloseDisposable);
		BottomRecommendations = bottomRecommendations.Setup(base.CloseDisposable, this);
		TopRecommendations = topRecommendations.Setup(base.CloseDisposable, this);
		ShowAllCharacteristicsCommand.Subscribe(delegate
		{
			if (productDetailsViewModel.AllCharacteristics.Count > 5)
			{
				productDetailsViewModel.AllCharacteristicsString = ((productDetailsViewModel.Characteristics.Count == 5) ? "Свернуть" : "Смотреть все");
				productDetailsViewModel.Characteristics.ReplaceRange((productDetailsViewModel.Characteristics.Count == 5) ? ((IEnumerable<CharacteristicItemViewModel>)productDetailsViewModel.AllCharacteristics) : ((IEnumerable<CharacteristicItemViewModel>)productDetailsViewModel.AllCharacteristics.TakeSafe(5)));
			}
		}).AddTo(base.CloseDisposable);
		AddReviewCommand.PerformDebouncingTask(AddReview).Subscribe().AddTo(base.CloseDisposable);
		((IObservable<Unit>)ShareCommand).PerformDebouncingTask((Func<Unit, Task>)delegate
		{
			if (!productDetailsViewModel.ShareAvailable)
			{
				return Task.CompletedTask;
			}
			AppAnalytics.AppMetrica.TrackEvent("shareLinkClick", ("productGimaId", productDetailsViewModel._product?.GimaId ?? string.Empty));
			return Share.Default.RequestAsync(productDetailsViewModel.ShareUrl, productDetailsViewModel.Title ?? string.Empty);
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		OnMenuOptionsCommand.Subscribe(delegate(Review review)
		{
			productDetailsViewModel.OpenMenuOptionsCommand.Trigger(dataBroker.Push(new ReportReviewViewModel.Parameter(review.Id)));
		}).AddTo(base.CloseDisposable);
		BrandOrCategoryCommand.PerformDebouncingTask(OnBrandOrCategoryCommand).Subscribe().AddTo(base.CloseDisposable);
		OnProductDetailsCommand.Subscribe(delegate
		{
			productDetailsViewModel.ProductDetailsOpen = !productDetailsViewModel.ProductDetailsOpen;
			if (!productDetailsViewModel.ProductDetailsOpen && productDetailsViewModel.Characteristics.Count > 5)
			{
				productDetailsViewModel.ShowAllCharacteristicsCommand.Trigger();
			}
			if (productDetailsViewModel.ProductDetailsOpen)
			{
				AppAnalytics.AppMetrica.TrackEvent("ClickOnItemDetails", ("sku", productDetailsViewModel._product?.GimaId ?? string.Empty), ("category", productDetailsViewModel._product?.CategoryCodes?.FirstOrDefault()?.Code ?? string.Empty));
			}
		}).AddTo(base.CloseDisposable);
		FeedbackCommand.Subscribe(delegate
		{
			productDetailsViewModel.OnFeedbackCommand();
		}).AddTo(base.CloseDisposable);
	}

	public void OnReviewRewardStickerTapped()
	{
		ReviewRewardSticker reviewRewardSticker = ReviewRewardSticker;
		if (reviewRewardSticker != null)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapProductCardOnReviewRewards");
			string tooltipText = reviewRewardSticker.TooltipText;
			if (!string.IsNullOrWhiteSpace(tooltipText))
			{
				ShowReviewRewardTooltipCommand.Trigger(tooltipText);
			}
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task AddReview()
	{
		if (!_userContext.Authorized)
		{
			_notAuthReopenScreenService.SaveParameterForType(GetType(), _parameter);
			_loginManager.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		State = VisualState.InProgress;
		AppAnalytics.AppMetrica.TrackEvent("TapReviewFormPP");
		if (await _reviewCheckAddingService.CanAddReview(_product?.GimaId, _parameter.OfflinePurchase ? Channel.Offline : Channel.Online))
		{
			NavigateToAddReviewCommand.Trigger(_dataBroker.Push(new AddReviewViewModel.Parameter(_product)));
		}
		State = VisualState.Default;
	}

	public ProductReviewsViewModel.Parameter ReviewsNavigationParameter(Review review, ReviewList reviewList)
	{
		return new ProductReviewsViewModel.Parameter(_product, Rate, reviewList, review)
		{
			OfflinePurchase = _parameter.OfflinePurchase,
			ForCase = _parameter.ForCase
		};
	}

	protected override async Task Start()
	{
		await base.Start();
		if (_parameter.Product == null && string.IsNullOrWhiteSpace(_parameter.ProductCode) && string.IsNullOrWhiteSpace(_parameter.GimaId))
		{
			Console.WriteLine("ProductDetailsViewModel: Empty product, code and gima id");
			State = VisualState.Empty;
			return;
		}
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformSamplingTask((Store _) => LoadProductDetail()).Subscribe()
			.AddTo(base.CloseDisposable);
		await LoadProductDetail();
		ProductDetailsNutrientsElementViewModel nutrientsElementVM = _nutrientsVMFactory(new ProductDetailsNutrientsElementViewModel.Parameter(_product?.EnergyValue));
		base.ElementViewModels.Add(nutrientsElementVM);
		await nutrientsElementVM.Start();
		ShowNutrientsCommand.Trigger(nutrientsElementVM);
		if (_ecomContext.AgeGateAgreement != AgreeState.Yes && (_product?.IsAdult ?? false))
		{
			State = VisualState.InProgress;
			AgreeState agreeState = await _ageGateDialog.ShowAgeGateDialogAsync();
			if (agreeState == AgreeState.None || agreeState == AgreeState.No)
			{
				CloseProductDetailsCommand.Trigger();
				return;
			}
			State = VisualState.Default;
		}
		if (IsForPriceCheckerCase)
		{
			_infoMessageService.ShowSnackbar("Цены на товары в зависимости от магазина и способа получения могут отличаться.", SnackbarStyle.Warning);
		}
	}

	private async Task LoadProductDetail()
	{
		string productCode = _parameter.Product?.Code ?? _parameter.ProductCode;
		int id = _ecomContext.ActiveStore.Id;
		if (IsForPriceCheckerCase && _parameter.Product != null)
		{
			await InitProductAsync(_parameter.Product);
			return;
		}
		State = VisualState.InProgress;
		var (isSuccess, _, product2, error) = await _productsRepository.GetProductDetailAsync(productCode, id, _parameter.GimaId, _parameter.OfflinePurchase ? "offline" : "online");
		if (!isSuccess)
		{
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(error);
		}
		else
		{
			await InitProductAsync(product2);
		}
		State = ((!isSuccess) ? ((error is NoDataError) ? VisualState.Empty : VisualState.Error) : VisualState.Default);
	}

	private async Task InitProductAsync(Product product)
	{
		bool num = _product == null;
		_product = product;
		Rate = product.Rate;
		ReviewRewardSticker = product.ReviewRewardSticker;
		ReviewingIsAllowed = _product.ReviewingIsAllowed && _userContext.Authorized;
		FavoritesButtonViewModel = _favoritesButtonViewModelFactory(_product, arg2: true, IsForPriceCheckerCase).AddTo(base.CloseDisposable);
		Footer.Setup(_product, this);
		ShareAvailable = !string.IsNullOrWhiteSpace(product.ShareUrl);
		ShareUrl = product.ShareUrl ?? string.Empty;
		if (num)
		{
			AppAnalytics.Ecom.ViewProduct(product, _parameter.Breadcrumbs);
		}
		if (_parameter.ForCase != ForCase.PriceChecker)
		{
			SetupRecommendations(product);
		}
		ImageUrls = product.MediaUrls;
		AllCharacteristics = product.Characteristics.Select((Characteristic chrct) => new CharacteristicItemViewModel(chrct, _infoMessageService)).ToList();
		AllCharacteristics.Insert(0, new CharacteristicItemViewModel(new Characteristic
		{
			Id = 0,
			Title = "Артикул",
			Value = product.GimaId
		}, _infoMessageService));
		Characteristics.ReplaceRange(AllCharacteristics.TakeSafe(5));
		AllCharacteristicsButtonVisible = AllCharacteristics.Count > 5;
		AvailableShops = product.Stock?.Shops;
		CurrentStoreAddress = _ecomContext.ActiveStore.Address;
		Title = product.Title;
		OldPrice = (product.InStock ? $"{product.OldPrice?.Value:F2}" : string.Empty);
		IsBlockShopsAvailable = product != null && product.Stock?.Shops?.Count > 1;
		IsNotAvaliableInCurrentShopVisible = IsBlockShopsAvailable && (product?.Stock?.Qty).GetValueOrDefault() == 0m && product?.Stock?.NotAvailable != true;
		DiscountValue = ((product.InStock && product.Discount != null) ? $"-{product.Discount.ValueInPercent}" : string.Empty);
		DiscountEndDate = ((product.InStock && product.Discount != null) ? $"до {product.Discount.EndDate:dd/MM}" : string.Empty);
		IsLoyaltyProgramDiscount = product.Discount?.IsLoyaltyProgramDiscount ?? false;
		Price = $"{_product?.Price?.Value:C2}";
		ProductDetailsViewModel productDetailsViewModel = this;
		Product? product2 = _product;
		int priceVisible;
		if (product2 == null)
		{
			priceVisible = 0;
		}
		else
		{
			decimal? num2 = product2.Price?.Value;
			priceVisible = (((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue) ? 1 : 0);
		}
		productDetailsViewModel.PriceVisible = (byte)priceVisible != 0;
		UnitTypeText = (product.InStock ? (ProductsConverter.FromProductToUnitType(product) + ": " + Price) : string.Empty);
		ProductDetailsViewModel productDetailsViewModel2 = this;
		int unitTypeInfoButtonVisible;
		if (product.InStock)
		{
			Price? price = product.Price;
			unitTypeInfoButtonVisible = (((object)price == null || price.UnitType != ProductUnitType.Unit) ? 1 : 0);
		}
		else
		{
			unitTypeInfoButtonVisible = 0;
		}
		productDetailsViewModel2.UnitTypeInfoButtonVisible = (byte)unitTypeInfoButtonVisible != 0;
		StockInfo = ProductsConverter.GetStockInfo(product, IsNeedToShowFractionPartOnStock(product.Stock?.Qty)) ?? "Нет в наличии";
		Description = product.Description?.Content?.Replace("\n", "<br />");
		DescriptionVisible = !string.IsNullOrWhiteSpace(Description);
		IsSaleActive = product.IsSaleActive && product.InStock;
		IsShowAdultSnack = _product?.IsAdult ?? false;
		IsBadHabitSnack = _product?.IsAdult ?? false;
		ProductInStock = _product?.InStock ?? false;
		CashbackAmount = (_product?.Cashback?.Amount.ToString() ?? string.Empty) + "%";
		ProductDetailsViewModel productDetailsViewModel3 = this;
		Product? product3 = _product;
		productDetailsViewModel3.IsDelayedCashback = product3 != null && product3.Cashback?.Type == CashbackType.Delayed;
		ImmutableList<BrandOrCategory>.Builder builder = ImmutableList.CreateBuilder<BrandOrCategory>();
		BrandDto brand = product.Brand;
		if (!string.IsNullOrEmpty(brand?.Code) && brand.Code != "-1")
		{
			builder.Add(new BrandOrCategory(brand));
		}
		CategoryCodeDto categoryCodeDto = product.CategoryCodes?.LastOrDefault();
		if (categoryCodeDto != null)
		{
			builder.Add(new BrandOrCategory(categoryCodeDto));
		}
		BrandsAndCategories = builder.ToImmutable();
		ProductDetailsViewModel productDetailsViewModel4 = this;
		string obj = $"Доступно для самовывоза\nв {product.Stock?.Shops?.Count} ";
		Stock? stock = product.Stock;
		productDetailsViewModel4.AvailableShopsForPickup = obj + (((object)stock != null && stock.Shops?.Count % 10 == 1) ? "магазине" : "магазинах");
		Badges = (IsForPriceCheckerCase ? new BadgesListModel(Array.Empty<BadgeModel>()) : new BadgesListModel(product.Badges, (BadgeItemViewModel b) => b.Item.BadgeType != BadgeType.Discount));
		Modifications.ReplaceRange(product.Modifications.Select((ProductModification x) => _viewModelFactory(x, base.CloseDisposable)));
		GluingRows.ReplaceRange(ArrangeGluings(product.Gluings));
		RaisePropertyChanged("ShouldDisplayStamps");
		RaisePropertyChanged("ShouldDisplayStampsInformer");
		RaisePropertyChanged("Badges");
		RaisePropertyChanged("Rate");
		RaisePropertyChanged("ReviewRewardSticker");
		RaisePropertyChanged("IsProductVerifiedVisible");
		if ((await _reviewsEcomService.GetProductReviewsAsync(product.Code, product.GimaId)).TryGetValue(out var value))
		{
			ReviewList = value;
		}
	}

	public string FromShopToQty(AvailableShop shop)
	{
		return ProductsConverter.FromProductToQty(shop.Qty.GetValueOrDefault(), (_product?.Price?.UnitType).GetValueOrDefault(), addDot: false, IsNeedToShowFractionPartOnStock(shop.Qty));
	}

	private bool IsNeedToShowFractionPartOnStock(decimal? qty)
	{
		decimal valueOrDefault = qty.GetValueOrDefault();
		ProductUnitType valueOrDefault2 = (_product?.Price?.UnitType).GetValueOrDefault();
		if ((uint)(valueOrDefault2 - 1) <= 1u)
		{
			return Math.Abs(valueOrDefault - Math.Round(valueOrDefault)) > 0.001m;
		}
		return false;
	}

	private void SetupRecommendations(Product product)
	{
		string gimaId = product.GimaId;
		LoadRequest loadRequest;
		if (product.InStock)
		{
			loadRequest = _recommendationBuilderFactory().AddProductPlacementsAndCrossSellForLargeBaskets("С этим товаром покупают", PlacementId.ProductDetails, gimaId, "productcard_related").AddAlternative("Похожие товары", "productcard_alternatives", new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId)).Build();
		}
		else
		{
			loadRequest = _recommendationBuilderFactory().AddProductPlacementsAndCrossSellForLargeBaskets("С этим товаром покупают", PlacementId.ProductDetails, gimaId, "productcard_related").Build();
			LoadRequest loadRequest2 = _recommendationBuilderFactory().AddSimilar("Похожие товары", (analogsId: "productcard_analogs", alternativeId: "productcard_alternatives"), new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId)).Build();
			TopRecommendations.Load(loadRequest2).SafeFireAndForget((Action<Exception>)null, false);
		}
		BottomRecommendations.Load(loadRequest).SafeFireAndForget((Action<Exception>)null, false);
	}

	private IEnumerable<ProductGluingRowViewModel> ArrangeGluings(IReadOnlyList<GluingProperty> props)
	{
		IEnumerable<IGrouping<string, GluingProperty>> enumerable = from p in props
			orderby p.SortOrder
			group p by p.PropertyCode;
		enumerable.Select((IGrouping<string, GluingProperty> g) => g.Key);
		IEnumerable<string> enumerable2 = from p in props
			group p by p.ProductCode into g
			select g.Key;
		IEnumerable<GluingProperty> currentProductProps = props.Where((GluingProperty p) => p.ProductCode == _product.Code);
		Dictionary<string, int> matchDict = new Dictionary<string, int>();
		foreach (string productCode in enumerable2)
		{
			int value = props.Where((GluingProperty p) => p.ProductCode == productCode && currentProductProps.Any((GluingProperty prop) => prop.PropertyCode == p.PropertyCode && prop.Value == p.Value)).Count();
			matchDict[productCode] = value;
		}
		int propertyCount = enumerable.Count();
		List<ProductGluingRowViewModel> list = new List<ProductGluingRowViewModel>();
		foreach (IGrouping<string, GluingProperty> item in enumerable)
		{
			IEnumerable<GluingValueViewModel> values = (from g in item
				group g by g.Value into g
				select g.OrderByDescending((GluingProperty p) => matchDict[p.ProductCode]).First() into p
				orderby p.SortOrder
				select p).Select(delegate(GluingProperty p)
			{
				GluingValueState state = GluingValueState.GrayedOut;
				if (propertyCount - matchDict[p.ProductCode] == 1)
				{
					state = GluingValueState.Default;
				}
				if (p.ProductCode == _product.Code)
				{
					state = GluingValueState.Selected;
				}
				return new GluingValueViewModel(p.Value, p.ProductCode, state);
			});
			list.Add(new ProductGluingRowViewModel(item.First().Name, values));
		}
		return list;
	}

	public void NavigateToReviews(Review? review = null)
	{
		if ((Rate?.ReviewsCount).GetValueOrDefault() != 0)
		{
			ReviewList? reviewList = ReviewList;
			if (reviewList != null && reviewList.Reviews.Any())
			{
				OpenReviewsCommand.Trigger(ReviewsNavigationParameter(review ?? ReviewList.Reviews.First(), ReviewList));
				return;
			}
		}
		AddReviewCommand.Trigger();
	}

	public void Retry()
	{
		LoadProductDetail().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void GluingValueSelected(GluingValueViewModel value)
	{
		if (value.ProductCode != _product.Code)
		{
			NavigateToProductCommand.Trigger(new Parameter(value.ProductCode)
			{
				ReplaceLastInBackStack = true
			});
		}
	}

	public void WriteSelected(IModificationItemViewModel vmMod, ModificationValueViewModel vmVal)
	{
		ProductModification modification = vmMod.Modification;
		ProductModificationValue value = vmVal.Value;
		if (!(value == null))
		{
			if (_selectedModifications.ContainsKey(modification.Code))
			{
				_selectedModifications.Remove(modification.Code);
			}
			SelectedModification value2 = new SelectedModification
			{
				Code = modification.Code,
				Name = modification.Name,
				Value = value
			};
			_selectedModifications.Add(modification.Code, value2);
			Footer.NotifyModificationsChanged();
			if (modification.ViewType == ModificationValueType.Image_picker)
			{
				ImageUrls = vmVal.ImageUrls;
			}
			if (IsAllModificationsSeleted)
			{
				IsWarningVisible = false;
			}
		}
	}

	void ProductFooterViewModel.IModificationsSource.OnIncompleteSelection()
	{
		IsWarningVisible = true;
	}

	private Task OnBrandOrCategoryCommand(BrandOrCategory boc)
	{
		if (boc.TryGetBrand(out BrandDto brand))
		{
			NavigateToProductsByBrandCommand.Trigger(new ProductsViewModel.Parameter
			{
				Title = brand.Name,
				Code = brand.Code,
				ProductsToLoadType = ProductsToLoad.ByBrand,
				Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(brand.Name)
			});
			return Task.CompletedTask;
		}
		if (boc.TryGetCategory(out CategoryCodeDto category))
		{
			NavigateToCategoryCommand.Trigger(_dataBroker.Push(new CatalogProductsViewModel.Parameter(category.Name, category.Code, ProductsToLoad.ByCategory, category.Id)));
			return Task.CompletedTask;
		}
		return Task.CompletedTask;
	}

	private void OnFeedbackCommand()
	{
		NavigateToFeedback.Trigger(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory, IsForPriceCheckerCase ? new Auchan.Common.DynamicFeedback.ForCase?(Auchan.Common.DynamicFeedback.ForCase.PriceChecker) : ((Auchan.Common.DynamicFeedback.ForCase?)null)));
	}

	private void OnReviewListChanged(ReviewList? old, ReviewList? @new)
	{
		Reviews = ((@new != null) ? @new.Reviews.Select((Review i) => new ReviewItemViewModel
		{
			Review = i,
			Parent = this
		}).Take(30).ToImmutableList() : ImmutableList.Create(default(ReadOnlySpan<ReviewItemViewModel>)));
	}
}
