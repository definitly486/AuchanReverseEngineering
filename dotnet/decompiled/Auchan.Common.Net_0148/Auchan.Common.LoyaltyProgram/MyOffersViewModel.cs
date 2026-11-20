using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
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
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.PersonalOffers;
using Auchan.Common.StoreReview;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.LoyaltyProgram;

public class MyOffersViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public enum VisualState
	{
		Default,
		Empty,
		InProgress,
		Error
	}

	public class Parameter
	{
		public string? CodeToOpen { get; set; }

		public bool IsAiOffer { get; set; }

		public bool FromPush { get; set; }

		public Parameter(string? code, bool isAi, bool fromPush = false)
		{
			CodeToOpen = code;
			IsAiOffer = isAi;
			FromPush = fromPush;
		}

		[JsonConstructor]
		public Parameter()
		{
		}
	}

	private readonly IEcomContext _ecomContext;

	private readonly IAdminContext _adminContext;

	private readonly IDataBroker _dataBroker;

	private readonly IErrorTranslator _errorTranslator;

	private readonly Lazy<PersonalOffersService> _personalOffersService;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Subject<Deeplink> _openDeeplink = new Subject<Deeplink>();

	private Parameter _parameter;

	private const string EmptyDefaultTitle = "Уже совсем скоро!";

	private const string EmptyDefaultDescription = "Здесь появятся интересные предложения специально для вас";

	private const string EmptyLoadFailedDescription = "Не удалось загрузить данные";

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNewOffersCountText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmptyTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmptyDescription_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorDescription_003Ek__BackingField;

	private bool _loading;

	private int _offersPage = 1;

	private int _offersTotalCount = int.MaxValue;

	private Task<Result<List<PersOfferItemViewModel>, DomainError>>? _loadOffersTask;

	private bool _closeOnResume;

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
	} = VisualState.InProgress;

	public string Title => "Мои предложения";

	public string ProgressTitle => "Загружаем ваши предложения…";

	public string NewOffersCountText
	{
		[CompilerGenerated]
		get
		{
			return _003CNewOffersCountText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CNewOffersCountText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CNewOffersCountText_003Ek__BackingField = value;
				RaisePropertyChanged("NewOffersCountText");
			}
		}
	} = string.Empty;

	public string EmptyTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CEmptyTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmptyTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmptyTitle_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyTitle");
			}
		}
	} = "Уже совсем скоро!";

	public string EmptyDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CEmptyDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmptyDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmptyDescription_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyDescription");
			}
		}
	} = "Здесь появятся интересные предложения специально для вас";

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
	} = "Упс! Что-то пошло не так.";

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
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public bool HasBanners => PersonalOffers.Any();

	public ObservableRangeCollection<PersOfferItemViewModel> PersonalOffers { get; } = new ObservableRangeCollection<PersOfferItemViewModel>();

	private List<PersOfferItemViewModel> _additionalPersOffers { get; } = new List<PersOfferItemViewModel>();

	public UICommand<BrokerToken> OpenOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> OpenAIOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand ShowQrCommand { get; } = new UICommand();

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "loyalty_all_offers";

	public MyOffersViewModel(IEcomContext ecomContext, Parameter parameter, IAdminContext adminContext, IDataBroker dataBroker, DefaultErrorTranslator defaultErrorTranslator, Lazy<IInfoMessageService> infoMessageService, Lazy<PersonalOffersService> personalOffersService)
	{
		_ecomContext = ecomContext;
		_parameter = parameter;
		_adminContext = adminContext;
		_errorTranslator = defaultErrorTranslator;
		_dataBroker = dataBroker;
		_personalOffersService = personalOffersService;
		_infoMessageService = infoMessageService;
	}

	protected override async Task Start()
	{
		await base.Start();
		if (string.IsNullOrEmpty(_parameter.CodeToOpen))
		{
			return;
		}
		State = VisualState.InProgress;
		string code = _parameter.CodeToOpen;
		bool fromPush = _parameter.FromPush;
		bool isAiOffer = _parameter.IsAiOffer;
		if (isAiOffer)
		{
			_adminContext.InvalidatePersOffersCache();
			await LoadPersonalOffers(useEmptyStateOnErrorForDeepLink: true);
			if (!PersonalOffers.Any((PersOfferItemViewModel offer) => offer.IsAiOffer && offer.Code == code))
			{
				lock (_parameter)
				{
					_parameter = new Parameter(null, isAi: false);
				}
				if (State == VisualState.InProgress)
				{
					State = ((!PersonalOffers.Any()) ? VisualState.Empty : VisualState.Default);
				}
				return;
			}
		}
		Result<PersOfferItemViewModel, DomainError> result = ((!isAiOffer) ? (await _personalOffersService.Value.PersonalOfferDetails(_parameter.CodeToOpen)) : (await _personalOffersService.Value.AIPersonalOfferDetails(_parameter.CodeToOpen)));
		Result<PersOfferItemViewModel, DomainError> result2 = result;
		lock (_parameter)
		{
			_parameter = new Parameter(null, isAi: false);
		}
		if (result2.IsSuccess)
		{
			if (fromPush)
			{
				AppAnalytics.AppMetrica.TrackEvent("personalOfferScreenView_from_push");
			}
			if (result2.Value.IsAiOffer)
			{
				AIOfferDetailsViewModel.Parameter parameter = new AIOfferDetailsViewModel.Parameter(code);
				OpenAIOfferDetailsCommand.Trigger(_dataBroker.Push(parameter));
				AIOfferDetailsViewModel.OfferDetailsResult offerDetailsResult = await parameter.WaitForResultAsync();
				if (offerDetailsResult.WentElsewhere)
				{
					_closeOnResume = true;
				}
				else
				{
					CloseCommand.Trigger();
				}
				if (offerDetailsResult.ProductDetailsParameter != null)
				{
					OpenProductDetailsCommand.Trigger(offerDetailsResult.ProductDetailsParameter);
				}
			}
			else
			{
				OfferDetailsViewModel.Parameter parameter2 = new OfferDetailsViewModel.Parameter(code);
				OpenOfferDetailsCommand.Trigger(_dataBroker.Push(parameter2));
				if ((await parameter2.WaitForResultAsync()).WentElsewhere)
				{
					_closeOnResume = true;
				}
				else
				{
					CloseCommand.Trigger();
				}
			}
		}
		else if (_loadOffersTask != null && _loadOffersTask.IsCompleted)
		{
			State = ((!PersonalOffers.Any()) ? VisualState.Empty : VisualState.Default);
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (_closeOnResume)
		{
			CloseCommand.Trigger();
		}
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).StartWith(_ecomContext.ActiveStore).Subscribe(delegate
		{
			LoadPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
		})
			.AddTo(base.PauseDisposable);
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	public async void OnBannerClicked(PersOfferItemViewModel offerViewModel)
	{
		int num = PersonalOffers.IndexOf(offerViewModel);
		AppAnalytics.AppMetrica.PersonalOfferTapped(offerViewModel.Code, offerViewModel.Title, num + 1, this);
		ProductDetailsViewModel.Parameter productParam = null;
		bool hasChanges;
		if (offerViewModel.IsAiOffer)
		{
			AIOfferDetailsViewModel.Parameter parameter = new AIOfferDetailsViewModel.Parameter(offerViewModel.Code);
			OpenAIOfferDetailsCommand.Trigger(_dataBroker.Push(parameter));
			AIOfferDetailsViewModel.OfferDetailsResult offerDetailsResult = await parameter.WaitForResultAsync();
			hasChanges = offerDetailsResult.HasChanges;
			productParam = offerDetailsResult.ProductDetailsParameter;
		}
		else
		{
			OfferDetailsViewModel.Parameter parameter2 = new OfferDetailsViewModel.Parameter(offerViewModel.Code);
			OpenOfferDetailsCommand.Trigger(_dataBroker.Push(parameter2));
			hasChanges = (await parameter2.WaitForResultAsync()).HasChanges;
		}
		if (productParam != null)
		{
			OpenProductDetailsCommand.Trigger(productParam);
		}
		else if (hasChanges)
		{
			LoadPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public async void OnActivateOfferTapped(PersOfferItemViewModel bannerViewModel)
	{
		if (!bannerViewModel.IsAccepted)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_activate");
			if ((await _adminContext.ActivatePersonalOffer(bannerViewModel.LoymaxId)).IsSuccess)
			{
				bannerViewModel.IsAccepted = true;
				PersonalOffers.ForceNotifyItemChanged(bannerViewModel);
				_adminContext.InvalidatePersOffersCache();
			}
			else
			{
				_infoMessageService.Value.ShowSnackbar("К сожалению, сейчас активация невозможна. Попробуйте позднее.");
			}
		}
	}

	public void Retry()
	{
		LoadPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void ShowQr()
	{
		ShowQrCommand.Trigger();
	}

	private async Task LoadPersonalOffers(bool useEmptyStateOnErrorForDeepLink = false)
	{
		_loading = true;
		State = VisualState.InProgress;
		SetDefaultEmptyStateText();
		_additionalPersOffers.Clear();
		_loadOffersTask = _adminContext.GetPersonalOffers();
		Result<List<PersOfferItemViewModel>, DomainError> result = await _loadOffersTask;
		_loading = false;
		if (result.IsFailure)
		{
			PersonalOffers.Clear();
			NewOffersCountText = string.Empty;
			if (useEmptyStateOnErrorForDeepLink)
			{
				SetLoadFailedEmptyStateText();
				State = VisualState.Empty;
			}
			else
			{
				State = VisualState.Error;
				(ErrorTitle, ErrorDescription) = _errorTranslator.Translate(result.Error);
			}
			return;
		}
		_offersPage = 1;
		List<PersOfferItemViewModel> second = PersonalOffers.ToList();
		List<PersOfferItemViewModel> list = _adminContext.PersonalOffers.ToList();
		int countOfNewPersonalOffers = _adminContext.CountOfNewPersonalOffers;
		NewOffersCountText = ((countOfNewPersonalOffers == 0) ? string.Empty : $"+{countOfNewPersonalOffers}");
		if (!list.SequenceEqual(second))
		{
			PersonalOffers.SetState(list);
		}
		lock (_parameter)
		{
			if (string.IsNullOrEmpty(_parameter.CodeToOpen))
			{
				State = ((!PersonalOffers.Any()) ? VisualState.Empty : VisualState.Default);
			}
		}
	}

	private void SetDefaultEmptyStateText()
	{
		EmptyTitle = "Уже совсем скоро!";
		EmptyDescription = "Здесь появятся интересные предложения специально для вас";
		RaisePropertyChanged("EmptyTitle");
		RaisePropertyChanged("EmptyDescription");
	}

	private void SetLoadFailedEmptyStateText()
	{
		EmptyTitle = string.Empty;
		EmptyDescription = "Не удалось загрузить данные";
		RaisePropertyChanged("EmptyTitle");
		RaisePropertyChanged("EmptyDescription");
	}
}
