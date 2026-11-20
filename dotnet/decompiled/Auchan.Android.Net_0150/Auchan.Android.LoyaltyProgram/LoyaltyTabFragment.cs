using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using AndroidX.ViewPager2.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Catalog;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.AutoLayout;
using Auchan.Android.Deeplinks;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram.Coupons;
using Auchan.Android.LoyaltyProgram.PointsTransfer;
using Auchan.Android.NewYearGame;
using Auchan.Android.Onboardings;
using Auchan.Android.Profile.SocialStatus;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Android.SupportChat;
using Auchan.Android.Tooltips;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Deeplinks;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom.Banners.ViewModels;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Coupons;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using Auchan.Common.NewYearGame;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.Tooltips;
using Google.Android.Material.AppBar;
using Google.Android.Material.Button;
using Java.Interop;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal sealed class LoyaltyTabFragment : AutoLayoutToolbarFragment<LoyaltyTabViewModel>, SwipeRefreshLayout.IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable, IBannerNavigationSupport, IFragmentNavigation
{
	private enum CouponCellType
	{
		Stub,
		Coupon
	}

	private readonly FragmentFactory _fragmentFactory;

	private readonly IDeeplinkManager _deeplinkManager;

	private EndlessScrollChangeListener _loadMoreScrollListener;

	private SwipeRefreshLayout _swipeRefreshLayout;

	private DroidPopupQueue _queueManager;

	private const int ScrollGestureThresholdPx = 8;

	private AppBarLayout _appBar;

	protected override int LayoutId => 2131493061;

	public LoyaltyTabFragment(Func<Fragment, LoyaltyTabViewModel> newViewModel, FragmentFactory fragmentFactory, IDeeplinkManager deeplinkManager)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
		_deeplinkManager = deeplinkManager;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenTooltipsCommand.SafeSubscribe(OpenTooltips, this);
		base.ViewModel.NavigateToPointsTransferCommand.SafeSubscribe(OpenPointsTransfer, this);
		base.ViewModel.NavigateToStampsTransferCommand.SafeSubscribe(NavigateToStampsTransfer, this);
		base.ViewModel.NavigateToSocialStatusCommand.SafeSubscribe(OpenSocialStatus, this);
		base.ViewModel.NavigateFAQCommand.SafeSubscribe(OpenFAQ, this);
		base.ViewModel.NavigateToChatCommand.SafeSubscribe(delegate
		{
			NavigateTo<ChatFragment>(null, add: true);
		}, this);
		base.ViewModel.NavigateLoyaltyRulesCommand.SafeSubscribe(OpenLoyaltyRules, this);
		base.ViewModel.NavigateToReissuePlasticOptionsCommand.SafeSubscribe(OpenReissuePlasticOptions, this);
		base.ViewModel.OpenCashbackProducts.SafeSubscribe(OpenProducts, this);
		base.ViewModel.GoToReattachPlasticCardCommand.SafeSubscribe(delegate(LoyaltyCardReattachPlasticCardNavigationParameter param)
		{
			OpenReattachCard(param);
		}, this);
		base.ViewModel.OpenMyOffersCommand.SafeSubscribe(delegate
		{
			NavigateTo<MyOffersFragment, MyOffersViewModel.Parameter>(new MyOffersViewModel.Parameter(null, isAi: false));
		}, this);
		base.ViewModel.OpenOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<OfferDetailsFragment, BrokerToken>(x);
		}, this);
		base.ViewModel.OpenAIOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<AIOfferDetailsFragment, BrokerToken>(x);
		}, this);
		base.ViewModel.OpenProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenDeeplinkCommand.SafeSubscribe(delegate(Deeplink link)
		{
			base.ViewModel.RunTask(_deeplinkManager.ResolveDeeplink(this, link));
		}, this);
		base.ViewModel.OpenNewYearSantaPopup.SafeSubscribe(OpenNewYearSantaPopup, this);
		base.ViewModel.OpenOnboardingsCommand.SafeSubscribe(OpenOnboardings, this);
		base.ViewModel.RefreshDoneCommand.SafeSubscribe(delegate
		{
			_swipeRefreshLayout.Refreshing = false;
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenPurchasesCommand.SafeSubscribe(delegate(MyPurchasesViewModel.Parameter p)
		{
			Auchan.Common.Analytics.AppAnalytics.AppMetrica.TapLoyaltyOnScoreStatistic();
			NavigateTo<MyPurchasesFragment, MyPurchasesViewModel.Parameter>(p);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenPointsBurningCommand.SafeSubscribe(delegate(LoyaltyCardPointsExpirationViewModel.Parameter p)
		{
			NavigateTo<LoyaltyCardPointsExpirationFragment, LoyaltyCardPointsExpirationViewModel.Parameter>(p);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenStampsBurningDocumentCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter doc)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(doc);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenCodeCommand.SafeSubscribe(delegate
		{
			Show<LoyaltyCardPdf417LandscapeFragment, LoyaltyCardQrPreviewViewModel.Parameter>(new LoyaltyCardQrPreviewViewModel.Parameter(LoyaltyCardQrPreviewViewModel.OpenedFrom.LoyaltyTab));
		}, this);
		base.ViewModel.OpenCouponsCommand.SafeSubscribe(delegate(CouponsViewModel.Parameter p)
		{
			NavigateTo<CouponsFragment, CouponsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenCouponDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<CouponDetailsFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.OpenAboutCouponsCommand.SafeSubscribe(delegate
		{
			Show<CouponsAboutFragment>();
		}, this);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, this);
		_queueManager = DroidPopupQueue.CreateFor(this);
		_queueManager.OnCreate(base.ParentFragmentManager).AutoDisposeOnDestroy(this);
		this.SetupBannersNavigation(base.ViewModel.BannerNavigationSupport, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup(delegate(int pos)
		{
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = base.ViewModel.AutoLayout.Elements.ElementAtOrDefault(pos);
			return (autoLayoutElement != null && (autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub")) ? 1 : 2;
		}));
		base.LayoutManager = gridLayoutManager;
		base.OnViewCreated(view, savedInstanceState);
		_swipeRefreshLayout = view.RequireViewById<SwipeRefreshLayout>(2131298581);
		CoordinatorLayout coordinatorLayout = view.RequireViewById<CoordinatorLayout>(2131297496);
		_appBar = coordinatorLayout.RequireViewById<AppBarLayout>(2131296451);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298077);
		frameLayout.RequireViewById<TextView>(2131298080);
		view.FindViewById<ConstraintLayout>(2131297338);
		view.FindViewById<TextView>(2131297342);
		base.AutoLayoutRecycler.AddProductsAutoLayoutDecoration(base.ViewModel.AutoLayout);
		_loadMoreScrollListener = new EndlessScrollChangeListener(delegate
		{
			base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: false);
		});
		base.AutoLayoutRecycler.AddOnScrollListener(_loadMoreScrollListener);
		coordinatorLayout.AddGoToTopButton(base.AutoLayoutRecycler, base.ViewModel.AutoLayout, delegate
		{
			RecyclerView.LayoutManager layoutManager = base.AutoLayoutRecycler.GetLayoutManager();
			if (layoutManager != null)
			{
				layoutManager.SmoothScrollToPosition(base.AutoLayoutRecycler, null, 0);
				layoutManager.ScrollToPosition(0);
			}
		}, ViewLifecycleOwner, _appBar);
		_swipeRefreshLayout.SetColorSchemeResources(2131100555);
		_swipeRefreshLayout.SetOnRefreshListener(this);
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				_swipeRefreshLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				viewSwitch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			ResumeQueueManager();
		}
	}

	public override void OnStop()
	{
		base.OnStop();
		if (!base.IsHidden)
		{
			_queueManager.OnPause();
		}
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (hidden)
		{
			_queueManager.OnPause();
		}
		else
		{
			ResumeQueueManager();
		}
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		base.AutoLayoutRecycler.RemoveOnScrollListener(_loadMoreScrollListener);
		_loadMoreScrollListener.Dispose();
		_loadMoreScrollListener = null;
	}

	protected override void BindAutoLayoutView(AutoLayoutViewModel.AutoLayoutElement vm, int position, CachingViewHolder vh, CompositeDisposable disposables)
	{
		string type = vm.Type;
		if (type == null)
		{
			return;
		}
		object data;
		RecomProductItemViewModel rpvm;
		switch (type.Length)
		{
		case 10:
			switch (type[0])
			{
			case 'G':
				if (type == "GameBanner")
				{
					SetupGameView(vh, vm.Data as IReadOnlyList<BannerItemViewModel>, disposables);
				}
				break;
			case 'T':
				if (type == "TitleBlock")
				{
					SetupTextView(vh, vm.Data as string, disposables);
				}
				break;
			}
			break;
		case 19:
			switch (type[0])
			{
			case 'L':
				if (type == "LoyaltyTabHelpBlock")
				{
					SetupHelpBlock(vh, disposables);
				}
				break;
			case 'R':
				if (type == "RecommendationTitle")
				{
					SetupTextView(vh, vm.Data as string, disposables);
				}
				break;
			}
			break;
		case 16:
			if (type == "LoyaltyCardBlock")
			{
				LoyaltyCardView loyaltyCardView = vh.RequireCachedView<LoyaltyCardView>(2131297489);
				loyaltyCardView.SetParentFragment(this);
				loyaltyCardView.Bind(vm.Data as LoyaltyCardElementViewModel, disposables);
			}
			break;
		case 22:
			if (type == "LoyaltyTabButtonsBlock")
			{
				SetupButtonsBlock(vh, disposables);
			}
			break;
		case 27:
			if (type == "LoyaltyTabSocialStatusBlock")
			{
				SnackView snackView = vh.RequireCachedView<SnackView>(2131298410);
				snackView.AddLinkedText(vm.Data as LinkedText);
				snackView.SetOnClickListenerSafe(new ViewOnClickListener((Action<View>)delegate
				{
					base.ViewModel.HideSocialStatusHint();
				})).AddTo(disposables);
			}
			break;
		case 17:
			if (type == "LoyaltyTabCoupons")
			{
				SetupCouponsBlock(vh, disposables);
			}
			break;
		case 20:
			if (type == "LoyaltyTabPersOffers")
			{
				SetupPersOffersBlock(vh, disposables);
			}
			break;
		case 21:
			if (!(type == "RecommendationProduct"))
			{
				break;
			}
			goto IL_021e;
		case 25:
			if (!(type == "RecommendationProductStub"))
			{
				break;
			}
			goto IL_021e;
		case 28:
			if (type == "RecommendationLoadMoreButton")
			{
				vh.RequireCachedView<TextView>(2131298603).Text = base.ViewModel.Recommendations.LoadMoreText;
				vh.ItemView.OnClick((Action)delegate
				{
					base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: true);
				}).AddTo(disposables);
			}
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 18:
		case 23:
		case 24:
		case 26:
			break;
			IL_021e:
			AdjustProductCardSize(vh);
			if (!(vh is ProductItemViewHolder productItemViewHolder))
			{
				break;
			}
			data = vm.Data;
			rpvm = data as RecomProductItemViewModel;
			if (rpvm != null)
			{
				base.ViewModel.OnRecommendationsViewed();
				productItemViewHolder.BindData(base.ViewModel, rpvm, disposables, base.ViewModel.Recommendations.ShowQtyDialogCommand, showPackageLabel: true);
				productItemViewHolder.ItemView.OnClick((Action)delegate
				{
					base.ViewModel.Recommendations.ProductClickCommand.Trigger(rpvm);
				}).AddTo(disposables);
			}
			break;
		}
	}

	private void AdjustProductCardSize(CachingViewHolder vh)
	{
		vh.ItemView.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
			lp.Height = Converter.DpToPx(286f);
		});
	}

	private void ResumeQueueManager()
	{
		_queueManager.OnResume();
	}

	private void OpenSocialStatus(bool isConfirmedStatus)
	{
		BaseBottomSheetDialogFragment baseBottomSheetDialogFragment = null;
		baseBottomSheetDialogFragment = ((!isConfirmedStatus) ? ((BaseBottomSheetDialogFragment)_fragmentFactory.Instantiate<UnconfirmedSocialStatusFragment>()) : ((BaseBottomSheetDialogFragment)_fragmentFactory.Instantiate<ConfirmedSocialStatusFragment>()));
		baseBottomSheetDialogFragment.Show(base.ChildFragmentManager, null);
	}

	private void OpenPointsTransfer(Unit obj)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<LoyaltyPointsTransferOptionsFragment>(this)
			.AddToBackStack("LoyaltyTransferFlowBackstack")
			.Commit();
	}

	private void OpenLoyaltyRules(InfoPageViewModel.Parameter obj)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, obj.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenContactUsSheet(DynamicFeedbackViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<DynamicFeedbackFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenProducts(ProductsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenFAQ(FAQViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<FAQFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenReissuePlasticOptions(Unit obj)
	{
		_fragmentFactory.Instantiate<LoyaltyCardReissueOptionsFragment>().Show(base.ParentFragmentManager, null);
	}

	private void OpenReattachCard(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		LoyaltyCardReattachPlasticFragment loyaltyCardReattachPlasticFragment = _fragmentFactory.Instantiate<LoyaltyCardReattachPlasticFragment>();
		loyaltyCardReattachPlasticFragment.Arguments = parameter.ToNavBundle();
		loyaltyCardReattachPlasticFragment.Show(RequireActivity().SupportFragmentManager, null);
	}

	private void SetupCouponsBlock(CachingViewHolder cvh, CompositeDisposable disposables)
	{
		TextView textView = cvh.RequireCachedView<TextView>(2131296868);
		ViewGroup couponsCounter = cvh.RequireCachedView<ViewGroup>(2131296864);
		TextView couponsCounterText = cvh.RequireCachedView<TextView>(2131296865);
		ChevronRightButtonControls allItemsButton = new ChevronRightButtonControls(cvh.RequireCachedView<View>(2131296423));
		SliderView sliderView = cvh.RequireCachedView<SliderView>(2131296867);
		float num = (float)(base.Resources.DisplayMetrics.WidthPixels - sliderView.ViewPager.PaddingStart - sliderView.ViewPager.PaddingEnd) / 2.9385965f;
		TouchListenerViewGroup touchListener = sliderView.TouchListener;
		ViewPager2 viewPager = sliderView.ViewPager;
		viewPager.SetPaddingDp(17, 0, 17, 0);
		ViewGroup.LayoutParams layoutParameters = touchListener.LayoutParameters;
		layoutParameters.Height = (int)num;
		touchListener.LayoutParameters = layoutParameters;
		touchListener.RequestLayout();
		EndlessRecyclerAdapter<CouponItemViewModel> endlessRecyclerAdapter = new EndlessRecyclerAdapter<CouponItemViewModel>
		{
			GetItemViewTypeDelegate = delegate(int index)
			{
				CouponItemViewModel couponItemViewModel = base.ViewModel.Coupons.ElementAtOrDefault(index);
				return (couponItemViewModel == null || !couponItemViewModel.IsStub) ? 1 : 0;
			},
			CreateViewHolderDelegate = delegate(ViewGroup layout, int cellType)
			{
				CachingViewHolder cachingViewHolder = ((cellType != 0) ? new CachingViewHolder(base.LayoutInflater.Inflate(2131493232, layout, attachToRoot: false)) : new CachingViewHolder(base.LayoutInflater.Inflate(2131493233, layout, attachToRoot: false)));
				ViewGroup.LayoutParams layoutParameters2 = cachingViewHolder.ItemView.LayoutParameters;
				layoutParameters2.Height = -1;
				cachingViewHolder.ItemView.LayoutParameters = layoutParameters2;
				return cachingViewHolder;
			},
			BindViewHolderDelegate = OnBindCoupon,
			DataSource = base.ViewModel.Coupons,
			MinItemsForEndless = 2
		};
		viewPager.OffscreenPageLimit = 2;
		viewPager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(1f)));
		viewPager.Adapter = endlessRecyclerAdapter;
		viewPager.SetCurrentItem(endlessRecyclerAdapter.FirstItemAdapterPosition, smoothScroll: false);
		allItemsButton.TextView.Text = base.ViewModel.AllButtonText;
		textView.Text = base.ViewModel.MyCoupons;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				couponsCounter.Visibility = base.ViewModel.CouponsNewAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponsNewAvailable")),
			(delegate
			{
				allItemsButton.View.Visibility = base.ViewModel.CouponsAllAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponsAllAvailable")),
			(delegate
			{
				couponsCounterText.Text = base.ViewModel.CouponsNewText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponsNewText"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(allItemsButton.View.OnClick((Action)delegate
		{
			base.ViewModel.OpenCouponsCommand.Trigger(new CouponsViewModel.Parameter(null));
		})).AddTo(disposables);
	}

	private void OnBindCoupon(CachingViewHolder holder, CouponItemViewModel entry, int position, CompositeDisposable disposable)
	{
		if (entry.IsStub)
		{
			holder.RequireCachedView<TextView>(2131298659).Text = entry.StubTitle;
			TextView textView = holder.RequireCachedView<TextView>(2131296964);
			textView.Text = entry.StubAboutText;
			textView.OnClick(base.ViewModel.OpenAboutCouponsCommand.Trigger).AddTo(disposable);
			return;
		}
		TextView textView2 = holder.RequireCachedView<TextView>(2131298659);
		TextView textView3 = holder.RequireCachedView<TextView>(2131296964);
		TextView textView4 = holder.RequireCachedView<TextView>(2131297128);
		LinearLayout linearLayout = holder.RequireCachedView<LinearLayout>(2131297127);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131296495);
		View newIndicator = holder.RequireCachedView<View>(2131297338);
		textView2.Text = entry.Name;
		textView3.Text = entry.Description;
		textView4.Text = entry.ExpiryText;
		linearLayout.Visibility = entry.HasExpiryDate.ToInvisibleVisibility();
		imageView.FromUrl(entry.MediaUrl);
		newIndicator.Visibility = entry.IsNew.ToVisibility();
		entry.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			newIndicator.Visibility = entry.IsNew.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsNew")))).AddTo(disposable);
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.CouponTapped(entry);
		});
	}

	private void SetupGameView(CachingViewHolder viewHolder, IReadOnlyList<BannerItemViewModel> banners, CompositeDisposable disposables)
	{
		RecyclerView recyclerView = viewHolder.RequireCachedView<RecyclerView>(2131296378);
		ViewGroup viewGroup = viewHolder.RequireCachedView<ViewGroup>(2131296383);
		ViewGroup viewGroup2 = viewHolder.RequireCachedView<ViewGroup>(2131296373);
		if (banners.Count == 1)
		{
			recyclerView.Visibility = ViewStates.Gone;
			viewGroup2.Visibility = ViewStates.Gone;
			viewGroup.Visibility = ViewStates.Visible;
			SetupGameBanner(viewGroup.RequireViewById<SkottieAnimationView>(2131296381), viewGroup.RequireViewById<ImageView>(2131296382), banners[0], disposables, isShort: false);
			return;
		}
		if (banners.Count == 2)
		{
			recyclerView.Visibility = ViewStates.Gone;
			viewGroup.Visibility = ViewStates.Gone;
			viewGroup2.Visibility = ViewStates.Visible;
			SetupGameBanner(viewGroup2.RequireViewById<SkottieAnimationView>(2131296374), viewGroup2.RequireViewById<ImageView>(2131296375), banners[0], disposables, isShort: true);
			SetupGameBanner(viewGroup2.RequireViewById<SkottieAnimationView>(2131296379), viewGroup2.RequireViewById<ImageView>(2131296380), banners[1], disposables, isShort: true);
			return;
		}
		viewGroup.Visibility = ViewStates.Gone;
		viewGroup2.Visibility = ViewStates.Gone;
		recyclerView.Visibility = ((banners.Count <= 2) ? ViewStates.Gone : ViewStates.Visible);
		if (banners.Count <= 2)
		{
			return;
		}
		if (recyclerView.ItemDecorationCount == 0)
		{
			recyclerView.SetLayoutManager(new CustomSizeLinearLayoutManager(Context, 0, reverseLayout: false)
			{
				CellSizeFunc = delegate
				{
					int num = (int)((float)(base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(40f) - Converter.DpToPx(8f)) / 2.2f);
					int height = (int)((float)num / 1.8918918f);
					return new RecyclerView.LayoutParams(num, height);
				}
			});
			recyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		}
		ConfigureGameBannerRecyclerTouch(recyclerView);
		ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493207,
			BindViewHolderDelegate = delegate(CachingViewHolder holder, BannerItemViewModel model, int _, CompositeDisposable d)
			{
				SkottieAnimationView skottieAnimationView = holder.RequireCachedView<SkottieAnimationView>(2131296376);
				ImageView imageView = holder.RequireCachedView<ImageView>(2131296377);
				if (string.IsNullOrWhiteSpace(model.Banner.Animation))
				{
					imageView.FromUrl(model.Banner.CarouselImage);
					skottieAnimationView.Visibility = ViewStates.Gone;
					imageView.Visibility = ViewStates.Visible;
				}
				else
				{
					skottieAnimationView.FromUrl(model.Banner.Animation, $"{model.Banner.Id}_lottie_animation");
					imageView.Visibility = ViewStates.Gone;
					skottieAnimationView.Visibility = ViewStates.Visible;
				}
				base.ViewModel.BindEvents(((View)skottieAnimationView).OnClick((Action)delegate
				{
					base.ViewModel.OnBannerClicked(model);
				}), ((View)imageView).OnClick((Action)delegate
				{
					base.ViewModel.OnBannerClicked(model);
				})).AddTo(d);
			},
			DataSource = banners
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.ScrollToPosition(0);
	}

	private static void ConfigureGameBannerRecyclerTouch(RecyclerView recyclerView)
	{
		recyclerView.NestedScrollingEnabled = false;
		if (recyclerView.GetTag(2131296378) != null)
		{
			return;
		}
		float initialX = 0f;
		float initialY = 0f;
		recyclerView.SetOnTouchListener(new ViewOnTouchListener(delegate(View view, MotionEvent e)
		{
			switch (e.ActionMasked)
			{
			case MotionEventActions.Down:
				initialX = e.GetX();
				initialY = e.GetY();
				view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
				break;
			case MotionEventActions.Move:
			{
				float num = Math.Abs(e.GetX() - initialX);
				float num2 = Math.Abs(e.GetY() - initialY);
				if (num2 > num && num2 > 8f)
				{
					view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
				}
				else if (num > 8f)
				{
					view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
				}
				break;
			}
			case MotionEventActions.Up:
			case MotionEventActions.Cancel:
				view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
				break;
			}
			return false;
		}));
		recyclerView.SetTag(2131296378, true);
	}

	private void SetupGameBanner(SkottieAnimationView animation, ImageView image, BannerItemViewModel banner, CompositeDisposable disposables, bool isShort)
	{
		if (string.IsNullOrWhiteSpace(banner.Banner.Animation))
		{
			image.FromUrl(isShort ? banner.Banner.ShortImage : banner.Banner.Image);
			animation.Visibility = ViewStates.Gone;
			image.Visibility = ViewStates.Visible;
		}
		else
		{
			animation.FromUrl(banner.Banner.Animation, $"{banner.Banner.Id}_lottie_animation");
			image.Visibility = ViewStates.Gone;
			animation.Visibility = ViewStates.Visible;
		}
		base.ViewModel.BindEvents(((View)animation).OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(banner);
		}), ((View)image).OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(banner);
		})).AddTo(disposables);
	}

	private void SetupPersOffersBlock(CachingViewHolder cvh, CompositeDisposable disposables)
	{
		TextView textView = cvh.RequireCachedView<TextView>(2131296868);
		ViewGroup offersCounter = cvh.RequireCachedView<ViewGroup>(2131296864);
		TextView offersCounterText = cvh.RequireCachedView<TextView>(2131296865);
		ChevronRightButtonControls chevronRightButtonControls = new ChevronRightButtonControls(cvh.RequireCachedView<View>(2131296423));
		SliderView sliderView = cvh.RequireCachedView<SliderView>(2131296867);
		_ = base.Resources.DisplayMetrics.WidthPixels;
		_ = sliderView.ViewPager.PaddingStart;
		_ = sliderView.ViewPager.PaddingEnd;
		int num = 116;
		TouchListenerViewGroup touchListener = sliderView.TouchListener;
		ViewPager2 viewPager = sliderView.ViewPager;
		viewPager.SetPaddingDp(17, 0, 17, 0);
		ViewGroup.LayoutParams layoutParameters = touchListener.LayoutParameters;
		layoutParameters.Height = Converter.DpToPx(num);
		ViewGroup.MarginLayoutParams marginLayoutParams = sliderView.LayoutParameters as ViewGroup.MarginLayoutParams;
		marginLayoutParams.SetMargins(marginLayoutParams.LeftMargin, marginLayoutParams.TopMargin, marginLayoutParams.RightMargin, 1);
		sliderView.LayoutParameters = marginLayoutParams;
		touchListener.LayoutParameters = layoutParameters;
		touchListener.RequestLayout();
		EndlessRecyclerAdapter<PersOfferItemViewModel> endlessRecyclerAdapter = new EndlessRecyclerAdapter<PersOfferItemViewModel>
		{
			CreateViewHolderDelegate = delegate(ViewGroup layout, int index)
			{
				CachingViewHolder cachingViewHolder = new CachingViewHolder(base.LayoutInflater.Inflate(2131493277, layout, attachToRoot: false));
				ViewGroup.LayoutParams layoutParameters2 = cachingViewHolder.ItemView.LayoutParameters;
				layoutParameters2.Height = -1;
				cachingViewHolder.ItemView.LayoutParameters = layoutParameters2;
				return cachingViewHolder;
			},
			BindViewHolderDelegate = OnBindOffer,
			DataSource = base.ViewModel.PersonalOffers,
			MinItemsForEndless = 2
		};
		viewPager.OffscreenPageLimit = 2;
		viewPager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(1f)));
		viewPager.Adapter = endlessRecyclerAdapter;
		viewPager.SetCurrentItem(endlessRecyclerAdapter.FirstItemAdapterPosition, smoothScroll: false);
		textView.Text = base.ViewModel.MyOffers;
		chevronRightButtonControls.TextView.Text = base.ViewModel.AllButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				offersCounter.Visibility = (!string.IsNullOrEmpty(base.ViewModel.NewOffersCountText)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NewOffersCountText")),
			(delegate
			{
				offersCounterText.Text = base.ViewModel.PersOffersNewText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PersOffersNewText"))
		})).AddTo(disposables);
		chevronRightButtonControls.View.OnClick(base.ViewModel.OpenMyOffersCommand.Trigger);
	}

	private void OnBindOffer(CachingViewHolder holder, PersOfferItemViewModel entry, int position, CompositeDisposable disposable)
	{
		PersonalOfferView offerView = holder.RequireCachedView<PersonalOfferView>(2131297726);
		offerView.Setup(entry);
		entry.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				offerView.NewIndicator.Visibility = (!entry.IsViewed).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsViewed")),
			(delegate
			{
				UpdateActivateButton(offerView.AcceptButton, entry);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAccepted"))
		})).AddTo(disposable);
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.OnPersOfferTapped(entry);
		}).AddTo(disposable);
		((View)offerView.AcceptButton).OnClick((Action)delegate
		{
			base.ViewModel.OnActivatePersOfferTapped(entry);
		}).AddTo(disposable);
	}

	private void UpdateActivateButton(AppCompatButton acceptButton, PersOfferItemViewModel entry)
	{
		acceptButton.SetBackgroundResource(entry.IsAccepted ? 2131231547 : 2131231546);
		acceptButton.Text = entry.ActivateLabel;
	}

	private void SetupHelpBlock(CachingViewHolder viewHolder, CompositeDisposable disposables)
	{
		NavigationCellView navigationCellView = viewHolder.RequireCachedView<NavigationCellView>(2131297141);
		NavigationCellView navigationCellView2 = viewHolder.RequireCachedView<NavigationCellView>(2131296834);
		NavigationCellView navigationCellView3 = viewHolder.RequireCachedView<NavigationCellView>(2131297856);
		NavigationCellView navigationCellView4 = viewHolder.RequireCachedView<NavigationCellView>(2131298266);
		navigationCellView.Text = base.ViewModel.FAQButton;
		navigationCellView2.Text = base.ViewModel.ChatButton;
		navigationCellView3.Text = base.ViewModel.AddCardButton;
		navigationCellView4.Text = base.ViewModel.RulesButton;
		navigationCellView2.Visibility = base.ViewModel.IsChatEnabled.ToVisibility();
		base.ViewModel.BindEvents(navigationCellView.OnClick(base.ViewModel.FaqClicked), navigationCellView2.OnClick(base.ViewModel.OnChatClick), navigationCellView3.OnClick(base.ViewModel.AddCardClicked), navigationCellView4.OnClick(base.ViewModel.LoyaltyRulesClicked)).AddTo(disposables);
	}

	private void SetupTextView(CachingViewHolder viewHolder, string text, CompositeDisposable disposables)
	{
		viewHolder.RequireCachedView<TextView>(2131298603).Text = text;
	}

	private void OpenTooltips(TooltipViewModel.Parameter parameter)
	{
		new TooltipBuilder().AddView(2131297490, TooltipTargetType.LoyaltyCard).AddView(2131296800, TooltipTargetType.QrCodeButton, -8f).AddView(2131297940, TooltipTargetType.Points, -8f)
			.AddView(2131297104, TooltipTargetType.ExpressPoints, -8f)
			.AddView(2131297531, TooltipTargetType.Marks, -8f)
			.AddView(2131296657, TooltipTargetType.Details, -8f)
			.SetScrollView(2131298188)
			.SetTargetView(2131298188)
			.ShowInQueue(_queueManager, parameter);
	}

	void SwipeRefreshLayout.IOnRefreshListener.OnRefresh()
	{
		base.ViewModel.RefreshCommand.Trigger();
		base.ViewModel.ReloadRecommendationsCommand.Trigger();
	}

	private void OpenNewYearGame(Unit _)
	{
		Fragment fragment = base.Activity.SupportFragmentManager.Fragments.First();
		base.Activity.SupportFragmentManager.BeginTransaction().Hide(fragment).Add<NewYearGameFragment>(fragment)
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenNewYearSantaPopup(SantaPopupDialogViewModel.Parameter parameter)
	{
		_queueManager.Show<SantaPopupDialogFragment>(parameter);
	}

	private void OpenOnboardings(OnboardingsViewModel.Parameter parameter)
	{
		_queueManager.Show<OnboardingsFragment>(parameter.ToNavBundle());
	}

	private void SetupButtonsBlock(CachingViewHolder cvh, CompositeDisposable disposables)
	{
		MaterialButton cashbackButton = cvh.RequireCachedView<MaterialButton>(2131296707);
		MaterialButton pointsButton = cvh.RequireCachedView<MaterialButton>(2131297930);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				cashbackButton.Text = base.ViewModel.MyCashbackText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MyCashbackText")),
			(delegate
			{
				pointsButton.Text = base.ViewModel.GiftPointsButton;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("GiftPointsButton"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(cashbackButton.OnClick(base.ViewModel.CashbackClicked), ((View)pointsButton).OnClick((Action)delegate
		{
			base.ViewModel.PointsClicked().SafeFireAndForget((Action<Exception>)null, false);
		})).AddTo(disposables);
	}

	private void NavigateToStampsTransfer(LoyaltyPointsTransferNavigationParameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<LoyaltyPointsTransferToNumberFragment>(this, parameter.ToNavBundle())
			.AddToBackStack("LoyaltyTransferFlowBackstack")
			.Commit();
	}
}
