using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class SharedCartPreloaderViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required string Query { get; init; }
	}

	private const string SHARED_CART_ERROR_TEXT = "Что-то пошло не так.\nПовторите попытку позже.";

	private Func<Task> _retryAction = DoNothing;

	private readonly Parameter _parameter;

	private readonly RemoteCartService _remoteCartService;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	private readonly Lazy<Cart> _cart;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<IActivationParametersStore> _activationParametersStore;

	private readonly Lazy<DefaultErrorTranslator> _errorTranslator;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

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

	public string ProgressTitle => "Проверяем наличие товаров...";

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
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand<BrokerToken> ShowSharedCartIsObsoletedCommand { get; } = new UICommand<BrokerToken>();

	public UICommand GoBackCommand { get; } = new UICommand();

	public SharedCartPreloaderViewModel(Parameter parameter, RemoteCartService remoteCartService, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog, Lazy<Cart> cart, Lazy<IInfoMessageService> infoMessageService, Lazy<IUniversalLinksService> universalLinksService, Lazy<IDataBroker> dataBroker, Lazy<IActivationParametersStore> activationParametersStore, Lazy<DefaultErrorTranslator> errorTranslator)
	{
		_parameter = parameter;
		_remoteCartService = remoteCartService;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_cart = cart;
		_infoMessageService = infoMessageService;
		_universalLinksService = universalLinksService;
		_dataBroker = dataBroker;
		_activationParametersStore = activationParametersStore;
		_errorTranslator = errorTranslator;
	}

	protected override async Task Start()
	{
		_universalLinksService.Value.IsPreloadingSharedCart = true;
		RetryCommand.PerformDebouncingTask(_retryAction).Subscribe().AddTo(base.CloseDisposable);
		await UpdateCartAndProceed();
	}

	private async Task UpdateCartAndProceed()
	{
		Task<Result<SharedCartModel, DomainError>> getSharedCartTask = _remoteCartService.GetSharedCart(_parameter.Query);
		Task<Result<CartModel, DomainError>> cartUpdateTask = _cart.Value.Update(Guid.NewGuid());
		await Task.WhenAll(base.Start(), cartUpdateTask, getSharedCartTask);
		if (cartUpdateTask.Result.TryGetError(out DomainError error))
		{
			(ErrorTitle, ErrorMessage) = _errorTranslator.Value.Translate(error);
			SetErrorState(() => UpdateCartAndProceed());
			return;
		}
		bool isAdultInCart = _cart.Value.HasAnyAdultProducts;
		if (getSharedCartTask.Result.TryGetValue(out SharedCartModel remoteCartModel))
		{
			if ((isAdultInCart || remoteCartModel.IsAdult) && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes)
			{
				string message = (remoteCartModel.IsAdult ? "В корзине, которой с вами поделились, есть товары, требующие подтверждения возраста." : "Здесь содержится информация, не рекомендуемая для несовершеннолетних");
				if (await _ageGateDialog.Value.ShowAgeGateDialogAsync(new AgeGateViewModel.Parameter
				{
					Message = message
				}) != AgreeState.Yes)
				{
					if (isAdultInCart)
					{
						await ClearAllAdultsProductsAndShowRemoteCartAsync(_parameter.Query, remoteCartModel.IsAdult ? null : remoteCartModel);
						return;
					}
					await _universalLinksService.Value.HandleLinkOnStart(IUniversalLinksService.ActivateCartLink);
					_universalLinksService.Value.IsPreloadingSharedCart = false;
					return;
				}
			}
			await DoShowSharedCartAsync(_parameter.Query, remoteCartModel);
			return;
		}
		if (getSharedCartTask.Result.TryGetError(out DomainError error2))
		{
			if (error2 is SharedCartDomainError sharedCartDomainError)
			{
				switch (sharedCartDomainError.Code)
				{
				case SharedCartError.ActiveProductsNotFound:
					_infoMessageService.Value.ShowSnackbar("Что-то пошло не так.\nПовторите попытку позже.");
					break;
				case SharedCartError.BasketShareNotFound:
				{
					SharedCartIsObsoletedViewModel.Parameter parameter = new SharedCartIsObsoletedViewModel.Parameter();
					ShowSharedCartIsObsoletedCommand.Trigger(_dataBroker.Value.Push(parameter));
					switch (await parameter.WaitForResultAsync())
					{
					case SharedCartIsObsoletedViewModel.Result.Catalog:
						await _universalLinksService.Value.HandleLinkOnStart("auchan://categories?activate_tab=Catalog");
						break;
					case SharedCartIsObsoletedViewModel.Result.Home:
						await _universalLinksService.Value.HandleLinkOnStart("auchan://home?activate_tab=Home");
						break;
					}
					break;
				}
				case SharedCartError.Unknown:
					_infoMessageService.Value.ShowSnackbar("Что-то пошло не так.\nПовторите попытку позже.");
					break;
				}
			}
			else
			{
				_infoMessageService.Value.ShowSnackbar("Что-то пошло не так.\nПовторите попытку позже.");
			}
		}
		GoBackCommand.Trigger();
	}

	private async Task ClearAllAdultsProductsAndShowRemoteCartAsync(string cartToken, SharedCartModel? sharedCartModel)
	{
		State = VisualState.InProgress;
		if ((await _cart.Value.ClearAllAdultProducts()).IsFailure)
		{
			SetErrorState(() => ClearAllAdultsProductsAndShowRemoteCartAsync(cartToken, sharedCartModel));
		}
		else if (sharedCartModel == null)
		{
			await _universalLinksService.Value.HandleLinkOnStart(IUniversalLinksService.ActivateCartLink);
		}
		else
		{
			await DoShowSharedCartAsync(cartToken, sharedCartModel);
		}
		_universalLinksService.Value.IsPreloadingSharedCart = false;
	}

	private async Task DoShowSharedCartAsync(string cartToken, SharedCartModel sharedCartModel)
	{
		_activationParametersStore.Value.PushFor(typeof(CartScreenViewModel), new CartScreenViewModel.SharedCartParameter
		{
			Token = cartToken,
			Model = sharedCartModel
		});
		GoBackCommand.Trigger();
		await _universalLinksService.Value.HandleLinkOnStart(IUniversalLinksService.ActivateCartLink);
		_universalLinksService.Value.IsPreloadingSharedCart = false;
	}

	private void SetErrorState(Func<Task> retryAction)
	{
		State = VisualState.Error;
		_retryAction = retryAction;
	}

	private static Task DoNothing()
	{
		return Task.CompletedTask;
	}

	public override void Dispose()
	{
		_universalLinksService.Value.IsPreloadingSharedCart = false;
	}
}
