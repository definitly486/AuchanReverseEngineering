using System;
using System.Reactive;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.Notifications;
using Auchan.Android.Profile;
using Auchan.Android.Profile.GiftCards;
using Auchan.Android.Streams;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Deeplinks;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.InfoPages;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.Deeplinks;

public class DeeplinkManager : BaseDeeplinkManager, IDeeplinkManager
{
	private Fragment Fragment { get; set; }

	public DeeplinkManager(Lazy<ICategoryRepository> categoryRepository, Lazy<IUserContext> userContext, Lazy<IInfoMessageService> infoMessageService, Lazy<IInfoPagesRepository> infoPagesRepository, Lazy<IDataBroker> dataBroker, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog)
		: base(categoryRepository, userContext, infoMessageService, infoPagesRepository, dataBroker, ecomContext, ageGateDialog)
	{
	}

	public async Task ResolveDeeplink(Fragment fragment, Deeplink deeplink)
	{
		Fragment = fragment;
		await ResolveDeeplink(deeplink);
	}

	protected override Task<Result<Unit, DomainError>> NavigateToAuthorization()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment.RequireActivity().SupportFragmentManager.FragmentFactory.Instantiate<ToolbarContainerFragment>();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToCart()
	{
		return Task.FromResult(NavigateToTab(2131297640));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToCashback()
	{
		return Task.FromResult(NavigateToTab(2131297643));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToCatalog()
	{
		return Task.FromResult(NavigateToTab(2131297641));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToCategory(CategoryViewModel.Parameter parameter)
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<CategoryFragment>(Fragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToProductDetails(ProductDetailsViewModel.Parameter parameter)
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<ProductDetailsFragment>(Fragment, parameter.ToNavBundle(), null, 2131297216)
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToProducts(BrokerToken parameter)
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<CollectionProductsFragment>(Fragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToFAQ(FAQViewModel.Parameter parameter)
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<FAQFragment>(Fragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToInfoPages(InfoPageIntermediateViewModel.Parameter parameter)
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<InfoPageIntermediateFragment>(Fragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToProfile()
	{
		return Task.FromResult(NavigateToTab(2131297644));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToPriceChecker()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment.Activity.SupportFragmentManager.Replace<PriceCheckerFragment>(2131296564).AddToBackStack(null).Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToUserSubscriptions()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<UserDataFragment>(Fragment)
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToStreams()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<StreamListFragment>(Fragment)
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToGiftCards()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<GiftCardsFragment>(Fragment)
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	protected override Task<Result<Unit, DomainError>> NavigateToNotifications()
	{
		if (!CanNavigate())
		{
			return Task.FromResult(Result.Failure<Unit, DomainError>(new UnknownError()));
		}
		Fragment?.ParentFragmentManager.BeginTransaction().Hide(Fragment).Add<NotificationsFragment>(Fragment)
			.AddToBackStack(null)
			.Commit();
		return Task.FromResult(Result.Success<Unit, DomainError>(Unit.Default));
	}

	private bool CanNavigate()
	{
		try
		{
			return Fragment.IsVisible && Fragment.IsAdded && Fragment.Activity.Lifecycle.CurrentState.IsAtLeast(Lifecycle.State.Started) && Fragment.Lifecycle.CurrentState.IsAtLeast(Lifecycle.State.Started);
		}
		catch (Exception)
		{
			return false;
		}
	}

	private Result<Unit, DomainError> NavigateToTab(int resourceId)
	{
		if (!CanNavigate())
		{
			return Result.Failure<Unit, DomainError>(new UnknownError());
		}
		BottomNavigationView bottomNavigationView = Fragment.Activity?.FindViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView == null)
		{
			return Result.Failure<Unit, DomainError>(new UnknownError());
		}
		bottomNavigationView.SelectedItemId = resourceId;
		bottomNavigationView.SelectedItemId = resourceId;
		return Result.Success<Unit, DomainError>(Unit.Default);
	}
}
