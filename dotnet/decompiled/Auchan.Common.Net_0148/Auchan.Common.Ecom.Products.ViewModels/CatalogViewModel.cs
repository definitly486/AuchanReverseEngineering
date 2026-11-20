using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Logs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.StoreReview;
using CSharpFunctionalExtensions;
using DryIoc;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class CatalogViewModel : ScreenViewModel
{
	private readonly ICategoryManager _categoryManager;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly ILogService _logService;

	private readonly IEcomContext _ecomContext;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<bool> _lazyIsPriceCheckerEnabled;

	[CompilerGenerated]
	private IReadOnlyList<CategoryItemViewModel> _003CTopCategories_003Ek__BackingField;

	[CompilerGenerated]
	private Dictionary<Category, string>? _003CCategoriesForIndexing_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public string Title => "Каталог";

	public string SearchPlaceholder => "Найти в АШАН";

	public string ProgressTitle => "Обновляем ассортимент…";

	public IReadOnlyList<CategoryItemViewModel> TopCategories
	{
		[CompilerGenerated]
		get
		{
			return _003CTopCategories_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CTopCategories_003Ek__BackingField, value))
			{
				_003CTopCategories_003Ek__BackingField = value;
				RaisePropertyChanged("TopCategories");
			}
		}
	} = Array.Empty<CategoryItemViewModel>();

	public Dictionary<Category, string>? CategoriesForIndexing
	{
		[CompilerGenerated]
		get
		{
			return _003CCategoriesForIndexing_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCategoriesForIndexing_003Ek__BackingField, value))
			{
				_003CCategoriesForIndexing_003Ek__BackingField = value;
				RaisePropertyChanged("CategoriesForIndexing");
			}
		}
	}

	public UICommand<CategoryViewModel.Parameter> NavigateNextCommand { get; } = new UICommand<CategoryViewModel.Parameter>();

	public UICommand<BrokerToken> NavigateToProductsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<AddressViewModel.Parameter> OpenAddressCheckCommand { get; } = new UICommand<AddressViewModel.Parameter>();

	public ReceiveMethodSelectElementViewModel ReceiveMethodViewModel { get; }

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public bool IsAuthorized => _userContext.Value.Authorized;

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
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
		set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public bool IsPriceCheckerEnabled => _lazyIsPriceCheckerEnabled.Value;

	public UICommand OpenPriceChecker { get; } = new UICommand();

	public UICommand ShowStoreReviewPopupCommand { get; } = new UICommand();

	public CatalogViewModel(DefaultErrorTranslator errorTranslator, ILogService logService, ICategoryManager categoryManager, IEcomContext ecomContext, Lazy<IUserContext> userContext, Func<ScreenViewModel, ReceiveMethodSelectElementViewModel> receiveMethodVMFactory, Lazy<IAdminContext> adminContext, Lazy<IDataBroker> dataBroker)
	{
		CatalogViewModel catalogViewModel = this;
		_errorTranslator = errorTranslator;
		_logService = logService;
		_categoryManager = categoryManager;
		_ecomContext = ecomContext;
		_userContext = userContext;
		_dataBroker = dataBroker;
		base.ElementViewModels.Add(ReceiveMethodViewModel = receiveMethodVMFactory(this));
		ReceiveMethodViewModel.OpenAddressSelectionCommand.PerformDebouncingTask(delegate(AddressViewModel.Parameter p)
		{
			catalogViewModel.OpenAddressCheckCommand.Trigger(p);
			return Task.CompletedTask;
		}).Subscribe().AddTo(base.CloseDisposable);
		_lazyIsPriceCheckerEnabled = new Lazy<bool>(() => GetIsPriceCheckerEnabled(adminContext.Value, catalogViewModel._userContext.Value));
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).StartWith(_ecomContext.ActiveStore).PerformDebouncingTask(LoadCategories)
			.Subscribe()
			.AddTo(base.CloseDisposable);
	}

	public void Retry()
	{
		LoadCategories().SafeFireAndForget((Action<Exception>)null, false);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("CatalogViewModel", "Открыт каталог", LogType.UserAction, SystemType.MobileApp);
		CancellationToken cancellationToken = base.NavigationToken.GetValueOrDefault();
		ShowStoreReviewPopupCommand.Trigger();
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		await ReceiveMethodViewModel.LoadReceiveMethods();
		if (!cancellationToken.IsCancellationRequested)
		{
			ReceiveMethodViewModel.ShowExpressDeliveryHighlightIfNeeded();
		}
	}

	public Task RequestStoreReviewIfNeeded()
	{
		return DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded();
	}

	public void NavigateToCategory(CategoryItemViewModel itemViewModel)
	{
		if (itemViewModel.Categories.Count > 0)
		{
			UICommand<CategoryViewModel.Parameter> navigateNextCommand = NavigateNextCommand;
			CategoryViewModel.Parameter parameter = new CategoryViewModel.Parameter(itemViewModel.Category);
			int num = 1;
			List<string> list = new List<string>(num);
			CollectionsMarshal.SetCount(list, num);
			CollectionsMarshal.AsSpan(list)[0] = itemViewModel.Category.Name;
			parameter.Breadcrumbs = list;
			navigateNextCommand.Trigger(parameter);
		}
		else
		{
			NavigateToProductsCommand.Trigger(_dataBroker.Value.Push(new CatalogProductsViewModel.Parameter(itemViewModel.Category)));
		}
	}

	public void OnSearchClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapCatalogOnSearch");
	}

	private async Task LoadCategories()
	{
		State = VisualState.InProgress;
		Result<IReadOnlyList<CategoryItemViewModel>, DomainError> result = await _categoryManager.GetTopCategories();
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(result.Error);
			return;
		}
		TopCategories = result.Value;
		Dictionary<Category, string> categoriesForIndexing = TopCategories.SelectMany((CategoryItemViewModel x) => GetCategoriesForIndexing(x.Category, x.Category.Name)).ToDictionary();
		CategoriesForIndexing = categoriesForIndexing;
		State = VisualState.Default;
	}

	private Dictionary<Category, string> GetCategoriesForIndexing(Category parentCategory, string parentCategoryNames = "")
	{
		Dictionary<Category, string> dictionary = new Dictionary<Category, string>();
		foreach (Category item in parentCategory.Items)
		{
			item.ImageUrlForIndexing = parentCategory.TopCategoryImageUrl ?? parentCategory.ImageUrlForIndexing;
			if (item.HasChildCategories)
			{
				dictionary.AddCollection<KeyValuePair<Category, string>>(GetCategoriesForIndexing(item, item.Name + " / " + parentCategoryNames));
			}
			dictionary.Add(item, parentCategoryNames);
		}
		return dictionary;
	}

	private static bool GetIsPriceCheckerEnabled(IAdminContext adminContext, IUserContext userContext)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(28) ? true : false)
		{
			AppConfig appConfig = adminContext.AppConfig;
			if (appConfig != null && appConfig.PriceCheckerEnabled)
			{
				switch (adminContext.AppConfig?.PricecheckerAudience)
				{
				case AudienceType.Employees:
				case AudienceType.Clients:
					return userContext.Profile?.Audience == adminContext.AppConfig?.PricecheckerAudience;
				case AudienceType.All:
					return true;
				}
			}
		}
		return false;
	}

	public async Task OnPriceCheckerClicked()
	{
		if (IsPriceCheckerEnabled)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapCatalogOnPriceChecker");
			await Permissions.RequestAsync<Permissions.Camera>();
			OpenPriceChecker.Trigger();
		}
	}
}
