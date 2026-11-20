using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading;
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
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Home;
using Auchan.Common.PersonalOffers;
using Auchan.Common.Reviews;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.LoyaltyProgram;

public class AIOfferDetailsViewModel : ScreenViewModel<AIOfferDetailsViewModel.Parameter>, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class OfferDetailsResult
	{
		public bool HasChanges { get; set; }

		public bool WentElsewhere { get; set; }

		public ProductDetailsViewModel.Parameter? ProductDetailsParameter { get; set; }
	}

	public class Parameter : BrokeredParameter<OfferDetailsResult>
	{
		public string Code { get; set; }

		[JsonConstructor]
		public Parameter(string code)
			: base(default(CancellationToken))
		{
			Code = code;
		}
	}

	private readonly PersonalOffersService _personalOffersService;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly IAdminContext _adminContext;

	private readonly IErrorTranslator _errorTranslator;

	private readonly Lazy<IProductsRepository> _productsRepository;

	private readonly Func<Product, ICollection<IDisposable>, ProductItemViewModel> _productItemViewModelFactory;

	private readonly Lazy<IEcomContext> _ecomContext;

	private string _offerCode;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorDescription_003Ek__BackingField;

	[CompilerGenerated]
	private PersOfferItemViewModel? _003COfferModel_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CContent_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDetailsTitle_003Ek__BackingField;

	public ObservableRangeCollection<ProductItemViewModel> Products = new ObservableRangeCollection<ProductItemViewModel>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private bool _hasChanges;

	string IYandexMetricaScreenViewModel.ScreenName => "Loymax_pp_detail";

	public string ScreenNameForBaseEvents => "Loymax_pp_detail";

	public override bool ShowInPopup => true;

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
	} = "";

	public string ErrorDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorDescription_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorDescription");
			}
		}
	} = "";

	public PersOfferItemViewModel? OfferModel
	{
		[CompilerGenerated]
		get
		{
			return _003COfferModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COfferModel_003Ek__BackingField, value))
			{
				_003COfferModel_003Ek__BackingField = value;
				RaisePropertyChanged("OfferModel");
			}
		}
	}

	public string Content
	{
		[CompilerGenerated]
		get
		{
			return _003CContent_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CContent_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CContent_003Ek__BackingField = value;
				RaisePropertyChanged("Content");
			}
		}
	} = "";

	public string DetailsTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CDetailsTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDetailsTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDetailsTitle_003Ek__BackingField = value;
				RaisePropertyChanged("DetailsTitle");
			}
		}
	} = "";

	public bool HasProducts => Products.Count > 0;

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

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<string> OpenBrowserCommand { get; } = new UICommand<string>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public void NavigateToProductDetails(ProductItemViewModel productItemViewModel)
	{
		if (!string.IsNullOrEmpty(productItemViewModel.Product.Code))
		{
			ProductDetailsViewModel.Parameter productDetailsParameter = new ProductDetailsViewModel.Parameter(productItemViewModel.Product.Code);
			base.Argument.TaskCompletionSource.TrySetResult(new OfferDetailsResult
			{
				WentElsewhere = true,
				HasChanges = _hasChanges,
				ProductDetailsParameter = productDetailsParameter
			});
			CloseCommand.Trigger();
		}
	}

	public AIOfferDetailsViewModel(BrokerToken parameter, PersonalOffersService personalOffersService, IUniversalLinksService universalLinksService, DefaultErrorTranslator defaultErrorTranslator, IAdminContext adminContext, Lazy<IEcomContext> ecomContext, Lazy<IProductsRepository> productsRepository, Func<Product, ICollection<IDisposable>, ProductItemViewModel> productItemViewModelFactory)
		: base(parameter)
	{
		_adminContext = adminContext;
		_errorTranslator = defaultErrorTranslator;
		_offerCode = base.Argument.Code;
		_personalOffersService = personalOffersService;
		_universalLinksService = universalLinksService;
		_productsRepository = productsRepository;
		_ecomContext = ecomContext;
		_productItemViewModelFactory = productItemViewModelFactory;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadOfferDetails();
	}

	private async Task LoadOfferDetails()
	{
		State = VisualState.InProgress;
		Result<PersOfferItemViewModel, DomainError> result = await _personalOffersService.AIPersonalOfferDetails(_offerCode);
		if (result.IsSuccess)
		{
			Products.Clear();
			OfferModel = result.Value;
			Content = OfferModel.DetailsText;
			DetailsTitle = OfferModel.DetailsTitle;
			_hasChanges = !_adminContext.IsMyOfferViewed(OfferModel.Code);
			_adminContext.SaveViewedMyOfferId(OfferModel.Code);
			OfferModel.Update();
			if (!string.IsNullOrEmpty(OfferModel.ProductGimaIds))
			{
				await LoadProducts(OfferModel.ProductGimaIds);
			}
			RaisePropertyChanged("OfferModel");
			RaisePropertyChanged("HasProducts");
			State = VisualState.Default;
		}
		else
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorDescription = tuple.Item2;
			State = VisualState.Error;
		}
	}

	private async Task LoadProducts(string gimaIds)
	{
		IEnumerable<string> gimaIds2 = from s in gimaIds.Trim().Split(',')
			select s.Trim();
		if ((await _productsRepository.Value.GetProductsByGimaIdAsync(_ecomContext.Value.ActiveStore.Id.ToString(), gimaIds2)).TryGetValue(out var value) && value.Any())
		{
			Products.ReplaceRange(value.Select((Product p) => _productItemViewModelFactory(p, base.CloseDisposable)));
		}
		RaisePropertyChanged("HasProducts");
	}

	public void Retry()
	{
		LoadOfferDetails().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void HandleUrl(string url)
	{
		if (_universalLinksService.ShouldHandleLink(url))
		{
			AppAnalytics.AppMetrica.TrackEvent("TapPersonalOfferView");
			if (!_universalLinksService.ShouldOpenInBrowser(url))
			{
				base.Argument.TaskCompletionSource.TrySetResult(new OfferDetailsResult
				{
					WentElsewhere = true,
					HasChanges = _hasChanges
				});
			}
			_universalLinksService.HandleLink(url).SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			Browser.Default.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(new OfferDetailsResult
		{
			WentElsewhere = false,
			HasChanges = _hasChanges
		});
	}
}
