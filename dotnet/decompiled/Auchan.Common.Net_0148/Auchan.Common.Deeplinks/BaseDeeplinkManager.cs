using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Deeplinks;

public abstract class BaseDeeplinkManager : IBaseDeeplinkManager
{
	private readonly Lazy<ICategoryRepository> _categoryRepository;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IInfoPagesRepository> _infoPagesRepository;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	public BaseDeeplinkManager(Lazy<ICategoryRepository> categoryRepository, Lazy<IUserContext> userContext, Lazy<IInfoMessageService> infoMessageService, Lazy<IInfoPagesRepository> infoPagesRepository, Lazy<IDataBroker> dataBroker, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog)
	{
		_categoryRepository = categoryRepository;
		_userContext = userContext;
		_infoMessageService = infoMessageService;
		_infoPagesRepository = infoPagesRepository;
		_dataBroker = dataBroker;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
	}

	public async Task ResolveDeeplink(Deeplink deeplink)
	{
		if ((deeplink.type switch
		{
			DeeplinkType.Authorization => await ResolveAuthorization(), 
			DeeplinkType.Cart => await NavigateToCart(), 
			DeeplinkType.Cashback => await ResolveCashback(), 
			DeeplinkType.Catalog => await NavigateToCatalog(), 
			DeeplinkType.Category => await ResolveCategory(deeplink), 
			DeeplinkType.Product => await ResolveProduct(deeplink), 
			DeeplinkType.InfoExchangeRefund => await ResolveInfoPages(InfoPagePosition.RefundExchange), 
			DeeplinkType.InfoPaymentDelivery => await ResolveInfoPages(InfoPagePosition.PaymentDelivery), 
			DeeplinkType.InfoFAQ => await NavigateToFAQ(new FAQViewModel.Parameter(FAQType.Default)), 
			DeeplinkType.Profile => await NavigateToProfile(), 
			DeeplinkType.Selfscan => await ResolvePriceChecker(), 
			DeeplinkType.UserSubscriptions => await ResolveUserSubscriptions(), 
			DeeplinkType.Streams => await NavigateToStreams(), 
			DeeplinkType.GiftCards => await NavigateToGiftCards(), 
			DeeplinkType.Notifications => await ResolveNotifications(), 
			DeeplinkType.None => SuccessfulResolve(), 
			_ => Result.Failure<Unit, DomainError>(new UnknownError()), 
		}).IsFailure)
		{
			_infoMessageService.Value.ShowSnackbar("Произошла неизвестная ошибка");
		}
	}

	protected abstract Task<Result<Unit, DomainError>> NavigateToCategory(CategoryViewModel.Parameter parameter);

	protected abstract Task<Result<Unit, DomainError>> NavigateToProducts(BrokerToken parameter);

	protected abstract Task<Result<Unit, DomainError>> NavigateToProductDetails(ProductDetailsViewModel.Parameter parameter);

	protected abstract Task<Result<Unit, DomainError>> NavigateToAuthorization();

	protected abstract Task<Result<Unit, DomainError>> NavigateToCart();

	protected abstract Task<Result<Unit, DomainError>> NavigateToCashback();

	protected abstract Task<Result<Unit, DomainError>> NavigateToCatalog();

	protected abstract Task<Result<Unit, DomainError>> NavigateToProfile();

	protected abstract Task<Result<Unit, DomainError>> NavigateToInfoPages(InfoPageIntermediateViewModel.Parameter parameter);

	protected abstract Task<Result<Unit, DomainError>> NavigateToFAQ(FAQViewModel.Parameter parameter);

	protected abstract Task<Result<Unit, DomainError>> NavigateToPriceChecker();

	protected abstract Task<Result<Unit, DomainError>> NavigateToUserSubscriptions();

	protected abstract Task<Result<Unit, DomainError>> NavigateToStreams();

	protected abstract Task<Result<Unit, DomainError>> NavigateToGiftCards();

	protected abstract Task<Result<Unit, DomainError>> NavigateToNotifications();

	private async Task<Result<Unit, DomainError>> ResolveNotifications()
	{
		if (!_userContext.Value.Authorized)
		{
			return await ResolveAuthorization();
		}
		return await NavigateToNotifications();
	}

	private async Task<Result<Unit, DomainError>> ResolveCategory(Deeplink deeplink)
	{
		Result<List<Category>, DomainError> result = await _categoryRepository.Value.GetCategoriesTree(deeplink.id, showHidden: true);
		if (result.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result.Error);
		}
		Category category = result.Value.FirstOrDefaultRecursive((Category x) => x.Code == deeplink.id, (Category x) => x.Items);
		if (category == null)
		{
			return await NavigateToProductDetails(new ProductDetailsViewModel.Parameter(deeplink.id));
		}
		bool flag = category.IsAdult && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes;
		if (flag)
		{
			flag = await _ageGateDialog.Value.ShowAgeGateDialogAsync() != AgreeState.Yes;
		}
		if (flag)
		{
			return Unit.Default;
		}
		return await NavigateToProducts(_dataBroker.Value.Push(new CollectionProductsViewModel.Parameter(category)));
	}

	private async Task<Result<Unit, DomainError>> ResolveProduct(Deeplink deeplink)
	{
		return await NavigateToProductDetails(new ProductDetailsViewModel.Parameter(deeplink.id));
	}

	private async Task<Result<Unit, DomainError>> ResolveAuthorization()
	{
		if (!_userContext.Value.Authorized)
		{
			return await NavigateToAuthorization();
		}
		return SuccessfulResolve();
	}

	private async Task<Result<Unit, DomainError>> ResolveInfoPages(InfoPagePosition infoPagePosition)
	{
		Result<List<InfoPage>, DomainError> result = await _infoPagesRepository.Value.InfoPages();
		if (result.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result.Error);
		}
		IEnumerable<string> source = from x in result.Value
			where x.Position == infoPagePosition
			select x.Slug;
		if (!source.Any())
		{
			return Result.Failure<Unit, DomainError>(new NoDataError());
		}
		return await NavigateToInfoPages(new InfoPageIntermediateViewModel.Parameter(source.ToList(), ""));
	}

	private async Task<Result<Unit, DomainError>> ResolvePriceChecker()
	{
		if (!_userContext.Value.Authorized)
		{
			return await ResolveAuthorization();
		}
		return await NavigateToPriceChecker();
	}

	private async Task<Result<Unit, DomainError>> ResolveUserSubscriptions()
	{
		if (!_userContext.Value.Authorized)
		{
			return await ResolveAuthorization();
		}
		return await NavigateToUserSubscriptions();
	}

	private async Task<Result<Unit, DomainError>> ResolveCashback()
	{
		if (!_userContext.Value.Authorized)
		{
			return await ResolveAuthorization();
		}
		return await NavigateToCashback();
	}

	private Result<Unit, DomainError> SuccessfulResolve()
	{
		return Result.Success<Unit, DomainError>(Unit.Default);
	}
}
