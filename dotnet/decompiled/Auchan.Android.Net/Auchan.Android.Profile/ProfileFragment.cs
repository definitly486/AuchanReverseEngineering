using System;
using System.Collections.Generic;
using System.Reactive;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.DeveloperMenu;
using Auchan.Android.Drive;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.Notifications;
using Auchan.Android.Profile.Cases;
using Auchan.Android.Profile.Favorites;
using Auchan.Android.Profile.GiftCards;
using Auchan.Android.Profile.Orders;
using Auchan.Android.Profile.SafeEntrance;
using Auchan.Android.Profile.SalesAndNews;
using Auchan.Android.Profile.SocialStatus;
using Auchan.Android.Profile.Stores;
using Auchan.Android.Profile.UserCards;
using Auchan.Android.Profile.WaitList;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Android.SupportChat;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.Profile;
using Auchan.Common.Reviews;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.Profile;

internal class ProfileFragment : BaseFragment<ProfileViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	private TextInputEditText _passwordInput;

	protected override int LayoutId => 2131493081;

	public ProfileFragment(Func<Fragment, ProfileViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToSafeEntranceCommand.SafeSubscribe(NavigateToSafeEntranceMenu, this);
		base.ViewModel.NavigateToUserDataCommand.SafeSubscribe(NavigateToUserData, this);
		base.ViewModel.NavigateToUserOrdersCommand.SafeSubscribe(NavigateToUserOrders, this);
		base.ViewModel.NavigateToUserReviewsCommand.SafeSubscribe(delegate
		{
			NavigateTo<UserReviewsFragment>();
		}, this);
		base.ViewModel.NavigateToUserFavoritesCommand.SafeSubscribe(NavigateToUserFavorites, this);
		base.ViewModel.NavigateToUserWaitListCommand.SafeSubscribe(delegate
		{
			NavigateTo<WaitListFragment>();
		}, this);
		base.ViewModel.NavigateToNotificationsCommand.SafeSubscribe(delegate
		{
			NavigateTo<NotificationsFragment>();
		}, this);
		base.ViewModel.NavigateToGiftCardsCommand.SafeSubscribe(delegate
		{
			NavigateToGiftCards();
		}, this);
		base.ViewModel.NavigateToUserCasesCommand.SafeSubscribe(delegate
		{
			NavigateToUserCases();
		}, this);
		base.ViewModel.NavigateToUserCarsCommand.SafeSubscribe(NavigateToUserCars, this);
		base.ViewModel.NavigateToUserAddressesCommand.SafeSubscribe(NavigateToUserAddresses, this);
		base.ViewModel.NavigateToUserCardsCommand.SafeSubscribe(NavigateToUserCards, this);
		base.ViewModel.NavigateToStoresCommand.SafeSubscribe(NavigateToStores, this);
		base.ViewModel.NavigateToInfoPagesCommand.SafeSubscribe(NavigateToInfoPages, this);
		base.ViewModel.NavigateToInfoPageCommand.SafeSubscribe(NavigateToInfoPage, this);
		base.ViewModel.NavigateToSalesAndNewsCommand.SafeSubscribe(delegate
		{
			NavigateTo<SalesAndNewsFragment>();
		}, this);
		base.ViewModel.NavigateToFAQCommand.SafeSubscribe(NavigateToFAQ, this);
		base.ViewModel.NavigateToTutorialsCommand.SafeSubscribe(NavigateToTutorials, this);
		base.ViewModel.NavigateToDevMenuCommand.SafeSubscribe(NavigateToDevMenu, this);
		base.ViewModel.NavigateToPurchaseHistoryCommand.SafeSubscribe(delegate(MyPurchasesViewModel.Parameter p)
		{
			NavigateTo<MyPurchasesFragment, MyPurchasesViewModel.Parameter>(p);
		}, this);
		base.ViewModel.NavigateToSocialStatusCommand.SafeSubscribe(NavigateToSocialStatus, this);
		base.ViewModel.NavigateToChatCommand.SafeSubscribe(NavigateToChat, this);
		base.ViewModel.OpenPasswordEnterCommand.SafeSubscribe(delegate
		{
			_passwordInput.Text = string.Empty;
			base.Activity.Window.SetSoftInputMode(SoftInput.AdjustNothing);
			_passwordInput.ForceFocusKeyboard();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		NestedScrollView scrollView = linearLayout.RequireViewById<NestedScrollView>(2131298303);
		linearLayout.RequireViewById<View>(2131298062);
		TextView authorizedUserName = linearLayout.RequireViewById<TextView>(2131298071);
		View view2 = linearLayout.RequireViewById<View>(2131296762);
		ImageView imageView = linearLayout.RequireViewById<ImageView>(2131296761);
		TextView chatCounterLabel = linearLayout.RequireViewById<TextView>(2131296759);
		RecommendationsView recommendationsView = linearLayout.RequireViewById<RecommendationsView>(2131298181);
		linearLayout.RequireViewById<View>(2131298182);
		View view3 = linearLayout.RequireViewById<View>(2131298050);
		TextView textView2 = view.RequireViewById<TextView>(2131298059);
		TextView textView3 = view.RequireViewById<TextView>(2131298056);
		NavigationCellView navigationCellView = view3.RequireViewById<NavigationCellView>(2131298068);
		NavigationCellView navigationCellView2 = view3.RequireViewById<NavigationCellView>(2131298073);
		NavigationCellView userReviewsView = view3.RequireViewById<NavigationCellView>(2131298074);
		NavigationCellView navigationCellView3 = view3.RequireViewById<NavigationCellView>(2131298069);
		NavigationCellView userWaitListView = view3.RequireViewById<NavigationCellView>(2131298075);
		NavigationCellView userNotificationsView = view3.RequireViewById<NavigationCellView>(2131298072);
		NavigationCellView userGiftCardsView = view3.RequireViewById<NavigationCellView>(2131298070);
		NavigationCellView navigationCellView4 = view3.RequireViewById<NavigationCellView>(2131298067);
		NavigationCellView navigationCellView5 = view3.RequireViewById<NavigationCellView>(2131298282);
		NavigationCellView userCarsView = view3.RequireViewById<NavigationCellView>(2131298066);
		NavigationCellView auchanPayView = view3.RequireViewById<NavigationCellView>(2131298049);
		NavigationCellView navigationCellView6 = view3.RequireViewById<NavigationCellView>(2131298064);
		NavigationCellView navigationCellView7 = linearLayout.RequireViewById<NavigationCellView>(2131298047);
		NavigationCellView aboutDeliveryView = linearLayout.RequireViewById<NavigationCellView>(2131298044);
		NavigationCellView aboutRefundView = linearLayout.RequireViewById<NavigationCellView>(2131298045);
		NavigationCellView navigationCellView8 = linearLayout.RequireViewById<NavigationCellView>(2131298048);
		NavigationCellView navigationCellView9 = linearLayout.RequireViewById<NavigationCellView>(2131298057);
		NavigationCellView navigationCellView10 = linearLayout.RequireViewById<NavigationCellView>(2131298060);
		NavigationCellView navigationCellView11 = linearLayout.RequireViewById<NavigationCellView>(2131298053);
		NavigationCellView feedbackChatView = linearLayout.RequireViewById<NavigationCellView>(2131298054);
		View documentsSection = linearLayout.RequireViewById<View>(2131298052);
		NavigationCellView navigationCellView12 = documentsSection.RequireViewById<NavigationCellView>(2131298051);
		TextView versionTextView = linearLayout.RequireViewById<TextView>(2131298076);
		TextView muidTextView = linearLayout.RequireViewById<TextView>(2131298061);
		TextView textView4 = linearLayout.RequireViewById<TextView>(2131298043);
		View view4 = linearLayout.RequireViewById<View>(2131298599);
		_passwordInput = view.RequireViewById<TextInputEditText>(2131297845);
		NavigationCellView socialStatusView = view3.RequireViewById<NavigationCellView>(2131298065);
		NavigationCellView navigationCellView13 = view3.RequireViewById<NavigationCellView>(2131298063);
		recommendationsView.SetupWithScrollView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, scrollView);
		textView.Text = base.ViewModel.ProgressTitle;
		textView2.Text = base.ViewModel.HelpSectionHeaderText;
		textView3.Text = base.ViewModel.FeedbackSectionHeaderText;
		navigationCellView.Text = base.ViewModel.UserDataText;
		navigationCellView2.Text = base.ViewModel.UserOrdersText;
		userReviewsView.Text = base.ViewModel.UserReviewsText;
		navigationCellView3.Text = base.ViewModel.UserFavoritesText;
		userWaitListView.Text = base.ViewModel.UserWaitListText;
		userNotificationsView.Text = base.ViewModel.UserNotificationsText;
		userGiftCardsView.Text = base.ViewModel.UserGiftCardsText;
		navigationCellView4.Text = base.ViewModel.UserCasesText;
		navigationCellView5.Text = base.ViewModel.SalesAndNewsText;
		userCarsView.Text = base.ViewModel.UserCarsText;
		auchanPayView.Text = base.ViewModel.AuchanPayText;
		navigationCellView7.Text = base.ViewModel.AboutStoresText;
		aboutDeliveryView.Text = base.ViewModel.AboutDeliveryText;
		aboutRefundView.Text = base.ViewModel.AboutRefundText;
		navigationCellView9.Text = base.ViewModel.HelpFAQText;
		navigationCellView10.Text = base.ViewModel.HelpTutorialsText;
		navigationCellView11.Text = base.ViewModel.FeedbackCallText;
		feedbackChatView.Text = base.ViewModel.FeedbackChatText;
		view2.Visibility = base.ViewModel.IsChatEnabled.ToVisibility();
		feedbackChatView.Visibility = base.ViewModel.IsChatEnabled.ToVisibility();
		navigationCellView12.Text = base.ViewModel.DocumentsText;
		navigationCellView6.Text = base.ViewModel.SafeEntranceText;
		VisibilitySwitch<ProfileViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<ProfileViewModel.VisualState>(base.ViewModel.State)
		{
			{
				ProfileViewModel.VisualState.Default,
				linearLayout
			},
			{
				ProfileViewModel.VisualState.InProgress,
				frameLayout
			}
		};
		ViewOnKeyListener viewOnKeyListener = new ViewOnKeyListener(OnKeyboardKeyPressed);
		viewOnKeyListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		_passwordInput.SetOnKeyListener(viewOnKeyListener);
		textView4.Text = base.ViewModel.RecomTechNote;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[18]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				chatCounterLabel.Visibility = (base.ViewModel.UnreadMessageCount != 0).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnreadMessageCount")),
			(delegate
			{
				chatCounterLabel.Text = base.ViewModel.UnreadMessageCount.ToString();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnreadMessageCount")),
			(delegate
			{
				authorizedUserName.Text = base.ViewModel.UserName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UserName")),
			(delegate
			{
				versionTextView.Text = base.ViewModel.AppVersion;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AppVersion")),
			(delegate
			{
				muidTextView.Text = base.ViewModel.UserMuid;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UserMuid")),
			(delegate
			{
				feedbackChatView.SetBadgeValue(base.ViewModel.UnreadMessageCount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnreadMessageCount")),
			(delegate
			{
				userWaitListView.SetBadgeValue(base.ViewModel.ProductsCountInWaitList);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductsCountInWaitList")),
			(delegate
			{
				userNotificationsView.SetBadgeValue(base.ViewModel.NotificationsCount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotificationsCount")),
			(delegate
			{
				userReviewsView.SetBadgeValue(base.ViewModel.WaitingForReviewProductsCount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WaitingForReviewProductsCount")),
			(delegate
			{
				userReviewsView.Visibility = base.ViewModel.IsUserReviewsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsUserReviewsVisible")),
			(delegate
			{
				userCarsView.Visibility = base.ViewModel.IsCarsViewVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCarsViewVisible")),
			(delegate
			{
				socialStatusView.Visibility = base.ViewModel.IsSocialStatusViewVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSocialStatusViewVisible")),
			(delegate
			{
				aboutDeliveryView.Visibility = base.ViewModel.IsPaymentAndDeliveryVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPaymentAndDeliveryVisible")),
			(delegate
			{
				aboutRefundView.Visibility = base.ViewModel.IsRefundAndExchangeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsRefundAndExchangeVisible")),
			(delegate
			{
				documentsSection.Visibility = base.ViewModel.IsDocumentsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDocumentsVisible")),
			(delegate
			{
				auchanPayView.Visibility = base.ViewModel.IsAuchanPayVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuchanPayVisible")),
			(delegate
			{
				userGiftCardsView.Visibility = base.ViewModel.IsGiftCardsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsGiftCardsVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view4.OnTouch(delegate(object? s, View.TouchEventArgs a)
		{
			if (a.Event.Action == MotionEventActions.Down)
			{
				base.ViewModel.OnVersionDown();
			}
			if (a.Event.Action == MotionEventActions.Up)
			{
				base.ViewModel.OnVersionUp();
			}
		}), _passwordInput.OnTextChanged(delegate(object? o, TextChangedEventArgs e)
		{
			base.ViewModel.VerifyPassword(e.Text?.ToString() ?? "");
			if (e.Text != null && e.Text.ToString().Length == 6)
			{
				_passwordInput.Text = string.Empty;
			}
		}), navigationCellView.OnClick(base.ViewModel.OnModifyClick), navigationCellView2.OnClick(base.ViewModel.OnUserOrdersClick), userReviewsView.OnClick(base.ViewModel.OnUserReviewsClick), navigationCellView3.OnClick(base.ViewModel.OnUserFavoritesClick), userWaitListView.OnClick(base.ViewModel.OnUserWaitListClick), userNotificationsView.OnClick(base.ViewModel.OnNotificationsClick), userGiftCardsView.OnClick(base.ViewModel.OnGiftCardsClick), navigationCellView4.OnClick(base.ViewModel.OnUserCasesClick), navigationCellView5.OnClick(base.ViewModel.OnSalesAndNewsTap), userCarsView.OnClick(base.ViewModel.OnUserCarsClick), navigationCellView7.OnClick(base.ViewModel.OnStoresClick), aboutDeliveryView.OnClick(base.ViewModel.OnNavigateToPaymentAndDelivery), aboutRefundView.OnClick(base.ViewModel.OnNavigateToExchangeAndRefund), navigationCellView8.OnClick(base.ViewModel.OnNavigateToVacancy), navigationCellView12.OnClick(base.ViewModel.OnNavigateToDocuments), navigationCellView6.OnClick(base.ViewModel.OnNavigateToSafeEntranceClick), navigationCellView9.OnClick(base.ViewModel.OnFAQClick), navigationCellView10.OnClick(base.ViewModel.OnTutorialsClick), imageView.OnClick(base.ViewModel.OnFeedbackChatClick), navigationCellView11.OnClick(base.ViewModel.OnFeedbackCallClick), feedbackChatView.OnClick(base.ViewModel.OnFeedbackChatClick), socialStatusView.OnClick(base.ViewModel.OnSocialStatusClick), navigationCellView13.OnClick(base.ViewModel.OnPurchaseHistoryClick), ((View)_passwordInput).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			if (!_passwordInput.HasFocus)
			{
				base.Activity.Window.SetSoftInputMode(SoftInput.AdjustPan);
			}
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowAllCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<StaticProductListFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, RequireContext());
		}, ViewLifecycleOwner);
	}

	private bool OnKeyboardKeyPressed(View view, Keycode keyCode, KeyEvent keyEvent)
	{
		if (keyCode == Keycode.Enter)
		{
			_passwordInput.ForceUnfocusKeyboard();
			return true;
		}
		return false;
	}

	private void NavigateToChat(Unit _)
	{
		NavigateTo<ChatFragment>(null, add: true);
	}

	private void NavigateToSafeEntranceMenu(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<SafeEntranceFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserCars(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<UserCarsFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserData(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<UserDataFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserCards(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<UserCardsFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserAddresses(Unit unit)
	{
		throw new NotImplementedException();
	}

	private void NavigateToUserOrders(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<OrdersFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserFavorites(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<FavoritesFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToGiftCards()
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<GiftCardsFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToUserCases()
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<CasesFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToSocialStatus(bool isConfirmedStatus)
	{
		BaseBottomSheetDialogFragment baseBottomSheetDialogFragment = null;
		baseBottomSheetDialogFragment = ((!isConfirmedStatus) ? ((BaseBottomSheetDialogFragment)_fragmentFactory.Instantiate<UnconfirmedSocialStatusFragment>()) : ((BaseBottomSheetDialogFragment)_fragmentFactory.Instantiate<ConfirmedSocialStatusFragment>()));
		baseBottomSheetDialogFragment.Show(base.Activity.SupportFragmentManager, null);
	}

	private void NavigateToStores(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StoresFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToInfoPages(InfoPageIntermediateViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageIntermediateFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToInfoPage(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToFAQ(FAQViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<FAQFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToTutorials(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<TutorialsIntermediateFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void NavigateToDevMenu(Unit unit)
	{
		_passwordInput.ForceUnfocusKeyboard();
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<DevMenuFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}
}
