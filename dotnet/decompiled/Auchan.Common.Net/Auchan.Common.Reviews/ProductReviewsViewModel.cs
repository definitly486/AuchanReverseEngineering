using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Reviews.Model;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews;

public class ProductReviewsViewModel : ScreenViewModel, IProductReviewsViewModel, IBindable, INotifyPropertyChanged, IReviewListViewModel, ProductFooterViewModel.IModificationsSource
{
	public class Parameter
	{
		public Rate? Rate { get; init; }

		public ReviewList ReviewList { get; init; } = Auchan.Common.Reviews.Model.ReviewList.Empty;

		public Review? SelectedReview { get; init; }

		public Product? Product { get; init; }

		public string? ProductCode { get; init; }

		public bool OfflinePurchase { get; init; }

		public ProductDetailsViewModel.ForCase ForCase { get; init; }

		[JsonConstructor]
		public Parameter()
		{
		}

		public Parameter(Product product, Rate? rate, ReviewList reviews, Review? selectedReview)
		{
			Product = product;
			Rate = rate;
			ReviewList = reviews;
			SelectedReview = selectedReview;
			ProductCode = product.Code ?? string.Empty;
		}

		public Parameter(string code)
		{
			ProductCode = code;
		}
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private readonly ReviewCheckAddingService _reviewCheckAddingService;

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly IDataBroker _dataBroker;

	private readonly IModificationsDialogService _modificationsDialogService;

	private readonly IEcomContext _ecomContext;

	private readonly IProductsRepository _productsRepository;

	private readonly IUserContext _userContext;

	private readonly ILoginManager _loginManager;

	private readonly IInfoMessageService _infoMessageService;

	[CompilerGenerated]
	private string _003CProductCode_003Ek__BackingField;

	[CompilerGenerated]
	private Product? _003CProduct_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003COfflinePurchase_003Ek__BackingField;

	[CompilerGenerated]
	private Rate? _003CRate_003Ek__BackingField;

	[CompilerGenerated]
	private ReviewList _003CReviewList_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<ReviewItemViewModel> _003CItems_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CInitialReviewIndex_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFooterVisible_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsPhotoFilterActive_003Ek__BackingField;

	public string ProductCode
	{
		[CompilerGenerated]
		get
		{
			return _003CProductCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CProductCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductCode_003Ek__BackingField = value;
				RaisePropertyChanged("ProductCode");
			}
		}
	}

	public Product? Product
	{
		[CompilerGenerated]
		get
		{
			return _003CProduct_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CProduct_003Ek__BackingField, value))
			{
				_003CProduct_003Ek__BackingField = value;
				RaisePropertyChanged("AddReviewNavigationParameter");
				RaisePropertyChanged("ReviewingIsAllowed");
				RaisePropertyChanged("Auchan.Common.Ecom.Products.ViewModels.ProductFooterViewModel.IModificationsSource.IsSelectionComplete");
				RaisePropertyChanged("Product");
			}
		}
	}

	public bool OfflinePurchase
	{
		[CompilerGenerated]
		get
		{
			return _003COfflinePurchase_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003COfflinePurchase_003Ek__BackingField != value)
			{
				_003COfflinePurchase_003Ek__BackingField = value;
				RaisePropertyChanged("OfflinePurchase");
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
				RaisePropertyChanged("ReviewCountString");
				RaisePropertyChanged("Rate");
			}
		}
	}

	public ReviewList ReviewList
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
				RaisePropertyChanged("IsPhotoFilterButtonVisible");
				RaisePropertyChanged("SelectedSort");
				ReviewList reviewList2 = ReviewList;
				OnReviewListChanged(reviewList, reviewList2);
				RaisePropertyChanged("ReviewList");
			}
		}
	}

	public bool IsPhotoFilterButtonVisible => ReviewList.HasImages;

	public IReadOnlyList<ReviewItemViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return _003CItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CItems_003Ek__BackingField, value))
			{
				_003CItems_003Ek__BackingField = value;
				RaisePropertyChanged("Items");
			}
		}
	} = Array.Empty<ReviewItemViewModel>();

	public int InitialReviewIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CInitialReviewIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CInitialReviewIndex_003Ek__BackingField != value)
			{
				_003CInitialReviewIndex_003Ek__BackingField = value;
				RaisePropertyChanged("InitialReviewIndex");
			}
		}
	}

	public ProductFooterViewModel Footer { get; }

	public bool IsFooterVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFooterVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsFooterVisible_003Ek__BackingField != value)
			{
				_003CIsFooterVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsFooterVisible");
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

	public UICommand<ReviewDetailsViewModel.Parameter> OpenReviewDetailsCommand { get; } = new UICommand<ReviewDetailsViewModel.Parameter>();

	public UICommand<AddReviewViewModel.Parameter> AddReviewCommand { get; } = new UICommand<AddReviewViewModel.Parameter>();

	public UICommand<BrokerToken> NavigateToAddReviewCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<Review> OnMenuOptionsCommand { get; } = new UICommand<Review>();

	public UICommand<BrokerToken> OpenMenuOptionsCommand { get; } = new UICommand<BrokerToken>();

	public AddReviewViewModel.Parameter AddReviewNavigationParameter => new AddReviewViewModel.Parameter(Product);

	public string AddReviewButtonTitle => "Написать отзыв";

	public string Title => "Все отзывы";

	public string ReviewCountString => $"{Rate?.ReviewsCount ?? 0}";

	public bool IsAuthorized => _userContext.Authorized;

	public bool ReviewingIsAllowed
	{
		get
		{
			if (Product?.ReviewingIsAllowed == true)
			{
				return IsAuthorized;
			}
			return false;
		}
	}

	public string ReviewsWithPhotoText => "Отзывы с фото";

	public bool IsPhotoFilterActive
	{
		[CompilerGenerated]
		get
		{
			return _003CIsPhotoFilterActive_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsPhotoFilterActive_003Ek__BackingField != value)
			{
				_003CIsPhotoFilterActive_003Ek__BackingField = value;
				RaisePropertyChanged("IsPhotoFilterActive");
			}
		}
	}

	public UICommand SortClickCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenSortPopup { get; } = new UICommand<BrokerToken>();

	public UICommand PhotoFilterClickCommand { get; } = new UICommand();

	public UICommand<OpenThumbnailRequest> OpenThumbnailCommand { get; } = new UICommand<OpenThumbnailRequest>();

	public ReviewSortItem SelectedSort => AvailableSorts.FirstOrDefault((ReviewSortItem i) => i.Field == ReviewList.SortField && i.Direction == ReviewList.SortDirection) ?? AvailableSorts.First();

	public IReadOnlyList<ReviewSortItem> AvailableSorts { get; } = new global::_003C_003Ez__ReadOnlyArray<ReviewSortItem>(new ReviewSortItem[4]
	{
		new ReviewSortItem
		{
			Title = "С высокой оценкой",
			Field = ReviewSortField.Rate,
			Direction = ReviewSortDirection.Descend
		},
		new ReviewSortItem
		{
			Title = "С низкой оценкой",
			Field = ReviewSortField.Rate,
			Direction = ReviewSortDirection.Ascend
		},
		new ReviewSortItem
		{
			Title = "Сначала новые",
			Field = ReviewSortField.CreatedAt,
			Direction = ReviewSortDirection.Descend
		},
		new ReviewSortItem
		{
			Title = "Сначала старые",
			Field = ReviewSortField.CreatedAt,
			Direction = ReviewSortDirection.Ascend
		}
	});

	IReadOnlyList<SelectedModification> ProductFooterViewModel.IModificationsSource.SelectedModifications => Array.Empty<SelectedModification>();

	bool ProductFooterViewModel.IModificationsSource.IsSelectionComplete
	{
		get
		{
			Product? product = Product;
			if (product == null)
			{
				return true;
			}
			return !product.Modifications.Any();
		}
	}

	bool ProductFooterViewModel.IModificationsSource.DimAddToCartUntilSelectionComplete => false;

	public ProductReviewsViewModel(Parameter parameter, ReviewCheckAddingService reviewCheckAddingService, ReviewsEcomService reviewsEcomService, IEcomContext ecomContext, IProductsRepository productsRepository, IUserContext userContext, IDataBroker dataBroker, ILoginManager loginManager, IInfoMessageService infoMessageService, IModificationsDialogService modificationsDialogService, Func<ProductFooterViewModel.Parameter, ProductFooterViewModel> footerViewModelFactory)
	{
		ProductReviewsViewModel productReviewsViewModel = this;
		Product = parameter.Product;
		ProductCode = parameter.ProductCode ?? "";
		Rate = parameter.Rate;
		OfflinePurchase = parameter.OfflinePurchase;
		ReviewList = parameter.ReviewList;
		if (parameter.SelectedReview != null)
		{
			Review item = parameter.ReviewList.Reviews.First((Review r) => r.ExternalId == parameter.SelectedReview.ExternalId);
			InitialReviewIndex = parameter.ReviewList.Reviews.IndexOf(item);
		}
		_reviewCheckAddingService = reviewCheckAddingService;
		_reviewsEcomService = reviewsEcomService;
		_ecomContext = ecomContext;
		_productsRepository = productsRepository;
		_userContext = userContext;
		_dataBroker = dataBroker;
		_loginManager = loginManager;
		_infoMessageService = infoMessageService;
		_modificationsDialogService = modificationsDialogService;
		Footer = footerViewModelFactory(new ProductFooterViewModel.Parameter
		{
			IsForPriceChecker = (parameter.ForCase == ProductDetailsViewModel.ForCase.PriceChecker)
		}).AddTo(base.CloseDisposable);
		AddReviewCommand.PerformDebouncingTask(AddReview).Subscribe().AddTo(base.CloseDisposable);
		OnMenuOptionsCommand.Subscribe(delegate(Review review)
		{
			productReviewsViewModel.OpenMenuOptionsCommand.Trigger(dataBroker.Push(new ReportReviewViewModel.Parameter(review.Id)));
		}).AddTo(base.CloseDisposable);
		SortClickCommand.PerformDebouncingTask(OnSortClickCommand).Subscribe().AddTo(base.CloseDisposable);
		PhotoFilterClickCommand.PerformDebouncingTask(OnPhotoFilterClickCommand).Subscribe().AddTo(base.CloseDisposable);
	}

	private async Task AddReview()
	{
		if (!_userContext.Authorized)
		{
			_loginManager.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		State = VisualState.InProgress;
		using (Disposable.Create(delegate
		{
			State = VisualState.Default;
		}))
		{
			if (await _reviewCheckAddingService.CanAddReview(Product?.GimaId, OfflinePurchase ? Channel.Offline : Channel.Online))
			{
				NavigateToAddReviewCommand.Trigger(_dataBroker.Push(new AddReviewViewModel.Parameter(Product)));
			}
		}
	}

	protected override async Task Start()
	{
		await base.Start();
		if (Product == null)
		{
			await LoadProductDetail();
		}
		else
		{
			SetupFooter();
		}
	}

	public void Retry()
	{
		LoadProductDetail().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void SetupFooter()
	{
		if (Product != null)
		{
			Footer.Setup(Product, this);
			IsFooterVisible = true;
		}
	}

	void ProductFooterViewModel.IModificationsSource.OnIncompleteSelection()
	{
		if (Product != null)
		{
			_modificationsDialogService.ShowModificationsPopup(Product);
		}
	}

	private async Task LoadProductDetail()
	{
		State = VisualState.InProgress;
		int id = _ecomContext.ActiveStore.Id;
		Task<Result<Product, DomainError>> productTask = _productsRepository.GetProductDetailAsync(ProductCode, id);
		Task<Result<ReviewList, DomainError>> reviewsTask = _reviewsEcomService.GetProductReviewsAsync(ProductCode, null);
		await Task.WhenAll(productTask, reviewsTask);
		if (productTask.Result.IsSuccess && reviewsTask.Result.IsSuccess)
		{
			State = VisualState.Default;
			ReviewList = reviewsTask.Result.Value;
			Product = productTask.Result.Value;
			Rate = Product.Rate;
			RaisePropertyChanged("ReviewingIsAllowed");
			SetupFooter();
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private async Task OnSortClickCommand(Unit unit)
	{
		OptionSelectorViewModel<SelectionItemViewModel<ReviewSortItem, ReviewSortViewModel>, ReviewSortItem>.Parameter parameter = new OptionSelectorViewModel<SelectionItemViewModel<ReviewSortItem, ReviewSortViewModel>, ReviewSortItem>.Parameter
		{
			Items = AvailableSorts,
			Preselected = SelectedSort
		};
		OpenSortPopup.Trigger(_dataBroker.Push(parameter));
		if ((await parameter.WaitForResultAsync()).TryGetValue(out var value))
		{
			await UpdateReviewsList(IsPhotoFilterActive, value);
		}
	}

	private async Task OnPhotoFilterClickCommand(Unit unit)
	{
		bool nextState = !IsPhotoFilterActive;
		if ((await UpdateReviewsList(nextState, SelectedSort)).IsSuccess)
		{
			IsPhotoFilterActive = nextState;
		}
	}

	private async Task<Result<ReviewList, DomainError>> UpdateReviewsList(bool filterState, ReviewSortItem selectedSort)
	{
		State = VisualState.InProgress;
		using (Disposable.Create(delegate
		{
			State = VisualState.Default;
		}))
		{
			Result<ReviewList, DomainError> result = await _reviewsEcomService.GetProductReviewsAsync(ProductCode, Product?.GimaId, filterState, selectedSort.Field, selectedSort.Direction);
			if (result.TryGetValue(out var value))
			{
				ReviewList = value;
			}
			if (result.TryGetError(out var _))
			{
				_infoMessageService.ShowSnackbar("Не удалось загрузить. Обновите страницу или попробуйте позже.");
			}
			return result;
		}
	}

	private void OnReviewListChanged(ReviewList old, ReviewList @new)
	{
		Items = @new.Reviews.Select((Review i) => new ReviewItemViewModel
		{
			Review = i,
			Parent = this
		}).ToImmutableList();
	}
}
