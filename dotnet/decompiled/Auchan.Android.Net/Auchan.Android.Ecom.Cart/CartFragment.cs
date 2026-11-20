using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager2.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Common.HighlightScreen;
using Auchan.Android.Common.ScrollListeners;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.AutoLayout;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.Profile.Favorites;
using Auchan.Android.Profile.Orders;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using EBind;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.TextField;
using Me.Relex.CircleIndicatorLib;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.Cart;

internal sealed class CartFragment : AutoLayoutFragment<CartScreenViewModel>
{
	private readonly Lazy<IFullScreenDialogState> _fullScreenDialogState;

	private readonly FragmentFactory _fragmentFactory;

	private DroidPopupQueue _queueManager;

	private bool _expressDeliveryHighlightPending;

	private readonly HashSet<DialogFragment> _observedDialogs = new HashSet<DialogFragment>();

	private ViewGroup _checkoutButtonBackground;

	private ConstraintLayout _defaultLayout;

	private ConstraintLayout _errorLayout;

	private View _progressLayout;

	private LinearLayoutWithClickIntercept _mainLayout;

	private ReceiveMethodSelectView _receiveMethodView;

	private Button _goToCatalogButton;

	private Button _goToFavoritesButton;

	private TextView _cartRetryTitle;

	private View _retryLastOrderButton;

	private TextView _totalPriceOnButton;

	private TextView _countAndWeight;

	private TextView _goToCheckoutText;

	private ViewGroup _buttonContentView;

	private ProgressBar _receiveMethodProgress;

	private TextView _receiveMethodProgressText;

	private TextView _receiveMethodProgressDescription;

	private View _receiveMethodProgressMask;

	private Button _goToCheckoutButton;

	private TextView _errorTitle;

	private TextView _errorMessage;

	private AppCompatButton _retryButton;

	private Button _showQrButton;

	private TextView _progressCartTitle;

	private BottomNavigationView _bottomNavigation;

	private ImageView _receiveMethodImageView;

	private ImageView _weightInfoImageView;

	private View _bottomItemView;

	private EndlessScrollChangeListener _loadMoreScrollListener;

	private ViewOnClickListener _onClickListener;

	private GoToTopButtonScrollListener _goToTopButtonScrollListener;

	private FloatingActionButton _goToTopButton;

	private RecyclerView _completedOrderProducts;

	private ObservableRecyclerAdapter<ProductModel, CachingViewHolder> _productsAdapter;

	protected override int LayoutId => 2131492996;

	public CartFragment(Lazy<IFullScreenDialogState> fullScreenDialogState, Func<Fragment, CartScreenViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fullScreenDialogState = fullScreenDialogState;
		_fragmentFactory = fragmentFactory;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_queueManager = DroidPopupQueue.CreateFor(this);
		_queueManager.OnCreate(base.ParentFragmentManager).AutoDisposeOnDestroy(this);
		base.ViewModel.GoToCatalogCommand.SafeSubscribe(GoToCatalog, this);
		base.ViewModel.GoToFavoritesCommand.SafeSubscribe(GoToFavorites, this);
		base.ViewModel.GoToCheckoutCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			GoToCheckoutAsync(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(GoToItemCard, this);
		base.ViewModel.OpenAddressCheckCommand.SafeSubscribe(delegate(AddressViewModel.Parameter p)
		{
			Show<AddressFragment, AddressViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenRemoveGoodsDialogCommand.SafeSubscribe(delegate
		{
			OpenRemoveGoodsDialog();
		}, this);
		base.ViewModel.OpenDeleteItemDialogCommand.SafeSubscribe(OpenDeleteItemDialog, this);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, this);
		base.ViewModel.OnLoyaltyPolicyCommand.SafeSubscribe(OpenLoyaltyPolicy, this);
		base.ViewModel.OpenDeliveryInfoCommand.SafeSubscribe(delegate(DeliveryInfoPopupViewModel.Parameter p)
		{
			Show<DeliveryInfoPopupFragment, DeliveryInfoPopupViewModel.Parameter>(p);
		}, this);
		base.ViewModel.ShowSharedCartCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<SharedCartFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.OpenStampsNoConnectCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<StampsLoyaltyNoConnectFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.OpenStampsProductsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<WithdrawStampsFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.ReceiveMethodViewModel.ShowExpressDeliveryHighlightCommand.SafeSubscribe(delegate
		{
			RequestExpressDeliveryHighlight();
		}, this);
		base.ViewModel.HighlightReceiveMethodsCommand.SafeSubscribe<(BrokerToken, HighlightScreenViewModel.Parameter)>(delegate((BrokerToken, HighlightScreenViewModel.Parameter) arg)
		{
			if (base.AutoLayoutRecycler != null && _receiveMethodView != null)
			{
				var (token, parameter) = arg;
				base.AutoLayoutRecycler.ScrollToPosition(0);
				base.AutoLayoutRecycler.Post(delegate
				{
					if (base.AutoLayoutRecycler != null && _receiveMethodView != null && base.IsAdded)
					{
						_receiveMethodView.ScrollToEnd(delegate
						{
							if (_receiveMethodView != null && base.IsAdded)
							{
								HighlightBundleBuilder highlightBundleBuilder = new HighlightBundleBuilder();
								foreach (var (text2, _) in parameter.Views)
								{
									if (text2 == base.ViewModel.SelfPickupHightlightViewId)
									{
										highlightBundleBuilder.AddView(_receiveMethodView.GetCellId(ReceivingMethod.Pickup), 0f, Converter.DpToPx(8f));
									}
									if (text2 == base.ViewModel.CarPickupHightlightViewId)
									{
										highlightBundleBuilder.AddView(_receiveMethodView.GetCellId(ReceivingMethod.CarPickup), 0f, Converter.DpToPx(8f));
									}
								}
								highlightBundleBuilder.SetSearchRoot(2131296699).SetTargetView(_receiveMethodView.Id).Show(base.ParentFragmentManager, token);
							}
						});
					}
				});
			}
		}, this);
		base.ViewModel.NavigateToStaticProductListCommand.SafeSubscribe(GoToStaticList, this);
		base.ViewModel.RepeatOrderService.NavigateToStaticProductListCommand.SafeSubscribe(GoToStaticList, this);
		base.ViewModel.RepeatOrderService.NavigateToRepeatPreviousOrderPopup.SafeSubscribe(delegate(BrokerToken p)
		{
			_queueManager.Show<RepeatOrderPopupFragment>(p);
		}, this);
		base.ViewModel.RepeatOrderService.ShowRepeatAdultProductWarningCommand.SafeSubscribe(delegate
		{
			_queueManager.Show(ShowAdultWarning);
		}, this);
		base.ViewModel.GoToSearchCommand.SafeSubscribe(delegate
		{
			OnOpenSearch();
		}, this);
		base.ViewModel.ScrollToTopCommand.SafeSubscribe(delegate
		{
			ScrollToTop();
		}, this);
		base.ViewModel.ShowAddProductsToOrderPopupCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			ShowAsync<AddProductsToOrderPopupFragment, BrokerToken>(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.ShowSuccessAdditionalOrderPopupCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			ShowAsync<SuccessAdditionalOrderPopupFragment, BrokerToken>(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.ShowAddToOrderFailedCommand.SafeSubscribe(delegate(AddToOrderFailedViewModel.Parameter p)
		{
			ShowAsync<AddToOrderFailedFragment, AddToOrderFailedViewModel.Parameter>(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.ShowOrderDetailCommand.SafeSubscribe(delegate(OrderDetailsViewModel.Parameter p)
		{
			NavigateTo<OrderDetailsFragment, OrderDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.ShowTooManyMarkedGoodsPopup.SafeSubscribe(delegate(TooManyMarkedProductsPopupViewModel.Parameter p)
		{
			Show<TooManyMarkedProductsPopupFragment, TooManyMarkedProductsPopupViewModel.Parameter>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		DisableHostFragmentProgress();
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup(delegate(int pos)
		{
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = base.ViewModel.AutoLayout.Elements.ElementAtOrDefault(pos);
			return (autoLayoutElement != null && (autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub")) ? 1 : 2;
		}));
		base.LayoutManager = gridLayoutManager;
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		_mainLayout = view.RequireViewById<LinearLayoutWithClickIntercept>(2131297509);
		FrameLayout viewGroup = _mainLayout.RequireViewById<FrameLayout>(2131298186);
		_checkoutButtonBackground = _mainLayout.RequireViewById<ViewGroup>(2131296774);
		_defaultLayout = _mainLayout.RequireViewById<ConstraintLayout>(2131296904);
		_errorLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		_progressLayout = view.RequireViewById<View>(2131298079);
		_progressCartTitle = _progressLayout.RequireViewById<TextView>(2131298080);
		_receiveMethodImageView = _defaultLayout.RequireViewById<ImageView>(2131298160);
		_receiveMethodProgress = _defaultLayout.RequireViewById<ProgressBar>(2131298161);
		_receiveMethodProgressText = _defaultLayout.RequireViewById<TextView>(2131298164);
		_receiveMethodProgressDescription = _defaultLayout.RequireViewById<TextView>(2131298162);
		_receiveMethodProgressMask = _defaultLayout.RequireViewById<View>(2131298163);
		_weightInfoImageView = _defaultLayout.RequireViewById<ImageView>(2131298831);
		_goToCheckoutButton = _defaultLayout.RequireViewById<AppCompatButton>(2131296773);
		_buttonContentView = _defaultLayout.RequireViewById<ViewGroup>(2131296589);
		_totalPriceOnButton = _defaultLayout.RequireViewById<TextView>(2131297982);
		_countAndWeight = _defaultLayout.RequireViewById<TextView>(2131296853);
		_goToCheckoutText = _defaultLayout.RequireViewById<TextView>(2131297244);
		_errorTitle = _errorLayout.RequireViewById<TextView>(2131298646);
		_errorMessage = _errorLayout.RequireViewById<TextView>(2131297563);
		_retryButton = _errorLayout.RequireViewById<AppCompatButton>(2131296325);
		_showQrButton = _errorLayout.RequireViewById<Button>(2131298371);
		(_goToTopButton, _goToTopButtonScrollListener) = viewGroup.AddGoToTopButton(base.AutoLayoutRecycler, base.ScrollToTop, ViewLifecycleOwner);
		SetupBinding();
		_loadMoreScrollListener = new EndlessScrollChangeListener(delegate
		{
			base.ViewModel.EndlessRecommendations.LoadMoreCommand.Trigger(subject: false);
		});
		base.ViewModel.UpdateGoToTopButton.SafeSubscribe(delegate(bool isEnabled)
		{
			_goToTopButtonScrollListener.IsEnabled = isEnabled;
			if (!isEnabled)
			{
				_goToTopButton.Hide();
			}
		}, ViewLifecycleOwner);
		if (_bottomNavigation != null)
		{
			_bottomNavigation.ItemSelected += new DisposableDelegate<EventHandler<NavigationBarView.ItemSelectedEventArgs>>(delegate(object? _, NavigationBarView.ItemSelectedEventArgs args)
			{
				if (BottomNavigationHostFragment.EnumFromId(args.Item.ItemId) != BottomNavigationViewModel.TabbarItem.Cart)
				{
					base.ViewModel.SetNeedUpdateRecoms();
				}
			}, delegate(EventHandler<NavigationBarView.ItemSelectedEventArgs> d)
			{
				_bottomNavigation.ItemSelected -= d;
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
		base.AutoLayoutRecycler.AddProductsAutoLayoutDecoration(base.ViewModel.AutoLayout);
		base.AutoLayoutRecycler.AddItemDecoration(new LastItemDecoration(0, 4, 0, 0, base.ViewModel.AutoLayout));
		base.AutoLayoutRecycler.AddOnScrollListener(_loadMoreScrollListener);
		_queueManager.QueueDrained += new DisposableDelegate<Action>(TryQueueExpressDeliveryHighlight, delegate(Action h)
		{
			_queueManager.QueueDrained -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		FragmentManager rootFragmentManager = RequireActivity().SupportFragmentManager;
		rootFragmentManager.BackStackChanged += new DisposableDelegate<EventHandler>(delegate
		{
			RetryExpressDeliveryHighlight();
		}, delegate(EventHandler h)
		{
			rootFragmentManager.BackStackChanged -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnPropertyChanges((CartScreenViewModel x) => x.State).Subscribe(delegate(VisualState state)
		{
			switch (state)
			{
			case VisualState.Default:
				base.AutoLayoutRecycler?.Post(RetryExpressDeliveryHighlight);
				break;
			case VisualState.Empty:
			case VisualState.Error:
				base.Activity?.RunOnUiThread(RejectExpressDeliveryHighlight);
				break;
			}
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.EndlessRecommendations.NavigateToProductCommand.SafeSubscribe(GoToItemCard, ViewLifecycleOwner);
		base.ViewModel.EndlessRecommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyRecommendationsInputDialog, ViewLifecycleOwner);
		base.ViewModel.EndlessRecommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(GoToItemCard, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyRecommendationsInputDialog, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
	}

	private void DisableHostFragmentProgress()
	{
		if (base.Activity.SupportFragmentManager.Fragments.FirstOrDefault() is BottomNavigationHostFragment bottomNavigationHostFragment)
		{
			bottomNavigationHostFragment.Progress.Visibility = ViewStates.Gone;
		}
	}

	private void SetupLastCompletedOrderProducts()
	{
		_productsAdapter = new ObservableRecyclerAdapter<ProductModel, CachingViewHolder>
		{
			CellLayoutId = 2131493230,
			BindViewHolderDelegate = OnBindProduct
		};
		HorizontalSpaceItemDecoration horizontalSpaceItemDecoration = new HorizontalSpaceItemDecoration(0, 9, 9);
		CustomSizeLinearLayoutManager customSizeLinearLayoutManager = new CustomSizeLinearLayoutManager(Context, 0, reverseLayout: false);
		customSizeLinearLayoutManager.CellSizeFunc = delegate
		{
			int num = (base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(80f)) / 5;
			int width = num + Converter.DpToPx(4f);
			double num2 = (double)num / 1.2 + (double)Converter.DpToPx(12f);
			return new RecyclerView.LayoutParams(width, (int)num2);
		};
		_productsAdapter.AutoDisposeOnDestroy(ViewLifecycleOwner);
		customSizeLinearLayoutManager.AutoDisposeOnDestroy(ViewLifecycleOwner);
		horizontalSpaceItemDecoration.AutoDisposeOnDestroy(ViewLifecycleOwner);
		_productsAdapter.ClickCallback = delegate
		{
			base.ViewModel.OnGoToOrderClickAsync().SafeFireAndForget((Action<Exception>)null, false);
		};
		_completedOrderProducts.SetLayoutManager(customSizeLinearLayoutManager);
		_completedOrderProducts.AddItemDecoration(horizontalSpaceItemDecoration);
		_completedOrderProducts.SetAdapter(_productsAdapter);
	}

	private void OnBindProduct(CachingViewHolder holder, ProductModel model, int position, CompositeDisposable disposable)
	{
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297809);
		TextView textView = holder.RequireCachedView<TextView>(2131296498);
		ViewGroup.LayoutParams layoutParameters = holder.ItemView.LayoutParameters;
		layoutParameters.Width = (base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(60f)) / 5;
		holder.ItemView.LayoutParameters = layoutParameters;
		textView.Text = $"{model.Qty}";
		string image = base.ViewModel.GetImage(model);
		if (!string.IsNullOrEmpty(image))
		{
			imageView.FromUrl(image);
		}
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void ShowRepeatPreviousOrderPopup(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Add<RepeatOrderPopupFragment>(this, arg.ToNavBundle()).AddToBackStack(null)
			.Commit();
	}

	private void SetupBinding()
	{
		_progressCartTitle.Text = base.ViewModel.ProgressCartTitle;
		_goToCheckoutText.Text = base.ViewModel.GoToCheckoutTitle;
		_onClickListener = new ViewOnClickListener(OnClick);
		_retryButton.SetOnClickListener(_onClickListener);
		_showQrButton.SetOnClickListener(_onClickListener);
		_goToCheckoutButton.SetOnClickListener(_onClickListener);
		_weightInfoImageView.SetOnClickListener(_onClickListener);
		_onClickListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				_mainLayout
			},
			{
				VisualState.Error,
				_errorLayout
			},
			{
				VisualState.InProgress,
				_progressLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[15]
		{
			(delegate
			{
				_checkoutButtonBackground.Visibility = (base.ViewModel.State == VisualState.Default && !base.ViewModel.CartIsEmpty).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "State", "CartIsEmpty" })),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				UpdateTabBarVisibility(base.ViewModel.TabBarVisible);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TabBarVisible")),
			(delegate
			{
				_errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				_errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				_receiveMethodProgressText.Text = base.ViewModel.ReceiveMethodProgressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethodProgressText")),
			(delegate
			{
				_receiveMethodProgressDescription.Text = base.ViewModel.ReceiveMethodProgressDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethodProgressDescription")),
			(delegate
			{
				_receiveMethodProgressDescription.Visibility = base.ViewModel.IsReceiveMethodProgressDescriptionVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsReceiveMethodProgressDescriptionVisible")),
			(delegate
			{
				_receiveMethodProgressMask.Visibility = base.ViewModel.ReceiveMethodProgressTwoParts.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethodProgressTwoParts")),
			(delegate
			{
				_goToCheckoutButton.Text = base.ViewModel.OrderButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OrderButtonTitle")),
			(delegate
			{
				SetCheckoutButtonColors(base.ViewModel.IsWeightValid, base.ViewModel.IsGotoCheckoutButtonEnabled, base.ViewModel.IsPreviousOrdersVisible);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "IsWeightValid", "IsGotoCheckoutButtonEnabled", "IsPreviousOrdersVisible" })),
			(delegate
			{
				_buttonContentView.Visibility = base.ViewModel.IsGoCheckoutButtonContentVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsGoCheckoutButtonContentVisible")),
			(delegate
			{
				_totalPriceOnButton.Text = base.ViewModel.TotalOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalOrderPrice")),
			(delegate
			{
				_countAndWeight.Text = base.ViewModel.CountAndWeightTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CountAndWeightTitle")),
			(delegate
			{
				_weightInfoImageView.Visibility = base.ViewModel.IsDeliveryInfoIconVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDeliveryInfoIconVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void UpdateLastCompletedOrderProductsDataSource()
	{
		if (base.ViewModel.LastCompletedOrder != null && _productsAdapter != null)
		{
			_productsAdapter.DataSource = base.ViewModel.LastCompletedOrder.Products;
		}
	}

	private void OnClick(View obj)
	{
		if (_retryButton.Id == obj.Id)
		{
			base.ViewModel.OnRetryButtonClick();
		}
		if (_showQrButton.Id == obj.Id)
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}
		if (_goToFavoritesButton != null && _goToFavoritesButton.Id == obj.Id)
		{
			base.ViewModel.OnGoToFavoritesClick();
		}
		if (_retryLastOrderButton != null && _retryLastOrderButton.Id == obj.Id)
		{
			base.ViewModel.OnGoToOrderClickAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
		if (_goToCheckoutButton.Id == obj.Id)
		{
			base.ViewModel.SelfPickupHightlightViewId = _receiveMethodView?.GetCellId(ReceivingMethod.Pickup)?.ToString() ?? string.Empty;
			base.ViewModel.CarPickupHightlightViewId = _receiveMethodView?.GetCellId(ReceivingMethod.CarPickup)?.ToString() ?? string.Empty;
			base.ViewModel.OnGoToCheckoutClick();
		}
		if (_goToCatalogButton != null && _goToCatalogButton.Id == obj.Id)
		{
			base.ViewModel.OnGoToCatalogClick();
		}
		if (_weightInfoImageView.Id == obj.Id)
		{
			base.ViewModel.OnFullDeliveryInfoClicked();
		}
	}

	private void SetCheckoutButtonColors(bool isWeightValid, bool enabled, bool isPreviousOrdersVisible)
	{
		if (_goToCheckoutButton != null)
		{
			int resourceId = ((!enabled) ? (isWeightValid ? 2131100615 : 2131100475) : (isPreviousOrdersVisible ? 2131099847 : 2131099791));
			int resourceId2 = ((enabled && isPreviousOrdersVisible) ? 2131099850 : 2131099697);
			ColorStateList textColor = GetColorByResourceId(resourceId2);
			_goToCheckoutButton.Enabled = enabled;
			_goToCheckoutButton.BackgroundTintList = GetColorByResourceId(resourceId);
			_totalPriceOnButton.SetTextColor(textColor);
			_countAndWeight.SetTextColor(textColor);
			_goToCheckoutText.SetTextColor(textColor);
		}
		ColorStateList GetColorByResourceId(int id)
		{
			return ColorStateList.ValueOf(new global::Android.Graphics.Color(ContextCompat.GetColor(Context, id)));
		}
	}

	private void UpdateTabBarVisibility(bool visible)
	{
		if (IsVisibleInCurrentTab())
		{
			_bottomNavigation.Visibility = visible.ToVisibility();
		}
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			_queueManager.OnResume();
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
			return;
		}
		_queueManager.OnResume();
		TryQueueExpressDeliveryHighlight();
	}

	public override void OnResume()
	{
		base.OnResume();
		RetryExpressDeliveryHighlight();
		base.ViewModel.PropertyChanged += new DisposableDelegate<PropertyChangedEventHandler>(delegate(object? o, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ReceiveMethodProgress")
			{
				SetReceiveMethodProgress(base.ViewModel.ReceiveMethodProgress);
			}
		}, delegate(PropertyChangedEventHandler h)
		{
			base.ViewModel.PropertyChanged -= h;
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnPause);
	}

	private void RequestExpressDeliveryHighlight()
	{
		_expressDeliveryHighlightPending = true;
		TryQueueExpressDeliveryHighlight();
		_receiveMethodView?.Post(TryQueueExpressDeliveryHighlight);
	}

	private void TryQueueExpressDeliveryHighlight()
	{
		if (!_expressDeliveryHighlightPending || View == null || base.AutoLayoutRecycler == null)
		{
			return;
		}
		if (!base.AutoLayoutRecycler.IsAtTop())
		{
			_expressDeliveryHighlightPending = false;
		}
		else if (_receiveMethodView?.ExpressCell != null && base.ViewModel.State == VisualState.Default && base.IsAdded && base.IsResumed && !base.IsHidden && IsLastInCartStack())
		{
			_receiveMethodView.PrepareForHighlight();
			BrokerToken brokerToken = base.ViewModel.ReceiveMethodViewModel.CreateExpressDeliveryHighlight();
			if (brokerToken == null)
			{
				_expressDeliveryHighlightPending = false;
				return;
			}
			_expressDeliveryHighlightPending = false;
			new HighlightBundleBuilder().AddView(_receiveMethodView.ExpressCell.Id, 0f, Converter.DpToPx(8f)).SetSearchRoot(2131296699).SetTargetView(_receiveMethodView.Id)
				.ShowInQueue<ExpressDeliveryHighlightScreenFragment>(_queueManager, brokerToken, CanShowExpressDeliveryHighlight);
		}
	}

	private bool CanShowExpressDeliveryHighlight()
	{
		if (View != null && base.AutoLayoutRecycler != null && base.AutoLayoutRecycler.IsAtTop() && _receiveMethodView?.ExpressCell != null && base.ViewModel.State == VisualState.Default && base.IsAdded && base.IsResumed && !base.IsHidden)
		{
			return IsLastInCartStack();
		}
		return false;
	}

	private void RejectExpressDeliveryHighlight()
	{
		_expressDeliveryHighlightPending = false;
		_queueManager.RemoveAndDismiss<ExpressDeliveryHighlightScreenFragment>();
	}

	private void RetryExpressDeliveryHighlight()
	{
		_queueManager.RaiseQueue();
		TryQueueExpressDeliveryHighlight();
	}

	private bool IsLastInCartStack()
	{
		Fragment fragment = base.Activity?.SupportFragmentManager.FindFragmentById(2131296564);
		if (!(fragment is BottomNavigationHostFragment) || !fragment.IsAdded || fragment.IsHidden || !IsVisibleInCurrentTab())
		{
			return false;
		}
		bool num = base.ParentFragmentManager.ObserveActiveDialogs(_observedDialogs, RetryExpressDeliveryHighlight);
		bool flag = base.ChildFragmentManager.ObserveActiveDialogs(_observedDialogs, RetryExpressDeliveryHighlight);
		if (!num)
		{
			return !flag;
		}
		return false;
	}

	private int GetPriceExpandOrCollapseResourceId(bool canExpand, bool isExpanded)
	{
		if (!canExpand)
		{
			return 0;
		}
		if (!isExpanded)
		{
			return 2131231611;
		}
		return 2131231610;
	}

	private void ShowQtyInputDialog(CartItemViewModel vm)
	{
		View view = base.LayoutInflater.Inflate(2131492969, null);
		TextInputEditText input = view.RequireViewById<TextInputEditText>(2131298129);
		base.ViewModel.OnClearQtyInput(vm);
		input.Text = vm.ManualInputQty;
		input.TextChanged += OnTextChanged;
		IDisposable fsd = _fullScreenDialogState.Value.SetVisible();
		DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
		{
			fsd.Dispose();
			input.TextChanged -= OnTextChanged;
		});
		AlertDialog alertDialog = new AlertDialog.Builder(Context).SetTitle(base.ViewModel.QtyDialogTitle).SetMessage(vm.Title).SetPositiveButton(base.ViewModel.QtyDialogDone, delegate
		{
			vm.OnChangeQtyDoneButtonClick().SafeFireAndForget((Action<Exception>)null, false);
		})
			.SetNegativeButton(base.ViewModel.QtyDialogClose, delegate
			{
			})
			.SetView(view)
			.SetOnDismissListener(dialogInterfaceOnDismissListener)
			.SetOnCancelListener(dialogInterfaceOnDismissListener)
			.Create();
		alertDialog.SetCanceledOnTouchOutside(cancel: true);
		alertDialog.Window.SetSoftInputMode(SoftInput.StateVisible);
		alertDialog.ShowCentered();
		input.RequestFocus();
		input.PostDelayed(delegate
		{
			(Context.GetSystemService("input_method") as InputMethodManager)?.ShowSoftInput(input, ShowFlags.Implicit);
		}, 200L);
		void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (!(input.Text == vm.ManualInputQty))
			{
				base.ViewModel.OnQtyEnteredManually(vm, input.Text);
				input.Text = vm.ManualInputQty;
				input.SetSelection(input.Text.Length);
			}
		}
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
		case 25:
			switch (type[3])
			{
			default:
				return;
			case 'e':
				if (type == "ReceiveMethodsSelectBlock")
				{
					ReceiveMethodSelectView view = vh.RequireCachedView<ReceiveMethodSelectView>(2131298168);
					_receiveMethodView = view;
					view.ExpressCellReady += new DisposableDelegate<Action>(TryQueueExpressDeliveryHighlight, delegate(Action h)
					{
						view.ExpressCellReady -= h;
					}).AddTo(disposables);
					view.Bind(base.ViewModel.ReceiveMethodViewModel, disposables);
					view.Post(TryQueueExpressDeliveryHighlight);
				}
				return;
			case 'o':
				break;
			}
			if (!(type == "RecommendationProductStub"))
			{
				break;
			}
			goto IL_0334;
		case 10:
			switch (type[0])
			{
			case 'C':
				if (type == "CartHeader")
				{
					OnBindCartHeader(vh, disposables);
				}
				break;
			case 'T':
				if (type == "TitleBlock")
				{
					SetupTextView(vh, vm.Data as string, disposables, 32f);
				}
				break;
			}
			break;
		case 21:
			switch (type[0])
			{
			default:
				return;
			case 'C':
				if (type == "CartUnavailableHeader")
				{
					OnBindUnavailableHeader(vh, disposables);
				}
				return;
			case 'R':
				break;
			}
			if (!(type == "RecommendationProduct"))
			{
				break;
			}
			goto IL_0334;
		case 19:
			switch (type[0])
			{
			case 'U':
				if (type == "UnavailableCartItem" && vh is UnavailableCartItemViewHolder unavailableCartItemViewHolder && vm.Data is CartItemUnavailableViewModel item)
				{
					unavailableCartItemViewHolder.BindData(base.ViewModel, item, disposables);
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
		case 8:
			if (type == "CartItem" && vh is CartItemViewHolder cartItemViewHolder && vm.Data is CartItemViewModel item2)
			{
				cartItemViewHolder.BindData(item2, _mainLayout, disposables);
			}
			break;
		case 18:
			if (type == "CartReservedHeader")
			{
				OnBindCartReservedHeader(vh);
			}
			break;
		case 17:
			if (type == "CartBottomContent")
			{
				if (_bottomItemView == null)
				{
					OnBindBottomContent(vh, disposables);
					break;
				}
				((ViewGroup)_bottomItemView.Parent)?.RemoveView(_bottomItemView);
				vh.ItemView = _bottomItemView;
			}
			break;
		case 16:
			if (type == "CartEmptyContent")
			{
				OnBindEmptyContent(vh, disposables);
			}
			break;
		case 28:
			if (type == "RecommendationLoadMoreButton")
			{
				vh.RequireCachedView<TextView>(2131298603).Text = base.ViewModel.EndlessRecommendations.LoadMoreText;
				vh.ItemView.OnClick((Action)delegate
				{
					base.ViewModel.EndlessRecommendations.LoadMoreCommand.Trigger(subject: true);
				}).AddTo(disposables);
			}
			break;
		case 29:
			{
				if (type == "RecommendationHorizontalBlock" && vm.Data is SectionItemViewModel sectionItemViewModel)
				{
					base.ViewModel.OnRecommendationsViewed(sectionItemViewModel);
					SetupHorizontalRecommendations(vh, sectionItemViewModel, disposables);
				}
				break;
			}
			IL_0334:
			AdjustProductCardWidth(vh);
			if (!(vh is ProductItemViewHolder productItemViewHolder))
			{
				break;
			}
			data = vm.Data;
			rpvm = data as RecomProductItemViewModel;
			if (rpvm != null)
			{
				base.ViewModel.OnEndlessRecommendationsViewed();
				productItemViewHolder.BindData(base.ViewModel, rpvm, disposables, base.ViewModel.EndlessRecommendations.ShowQtyDialogCommand, showPackageLabel: true);
				productItemViewHolder.ItemView.OnClick((Action)delegate
				{
					base.ViewModel.EndlessRecommendations.ProductClickCommand.Trigger(rpvm);
				}).AddTo(disposables);
			}
			break;
		}
	}

	private void OnBindUnavailableHeader(CachingViewHolder vh, CompositeDisposable disposables)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297404);
		TextView itemsUnavailableClearButton = vh.RequireCachedView<TextView>(2131297402);
		View itemsUnavailableHeaderTopMargin = vh.RequireCachedView<View>(2131297405);
		textView.Text = base.ViewModel.ItemsUnavailableHeader;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				itemsUnavailableClearButton.Text = base.ViewModel.RemoveGoodsButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RemoveGoodsButtonText")),
			(delegate
			{
				itemsUnavailableHeaderTopMargin.Visibility = base.ViewModel.IsUnavailableHeaderTopMarginVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsUnavailableHeaderTopMarginVisible")),
			(delegate
			{
				itemsUnavailableClearButton.Visibility = base.ViewModel.IsClearButtonAtUnavailableItemsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsClearButtonAtUnavailableItemsVisible"))
		})).AddTo(disposables);
		((View)itemsUnavailableClearButton).OnClick((Action)delegate
		{
			base.ViewModel.OpenRemoveGoodsDialogCommand.Trigger();
		}).AddTo(disposables);
	}

	private void OnBindCartHeader(CachingViewHolder vh, CompositeDisposable disposables)
	{
		View slider = vh.RequireCachedView<View>(2131298379);
		ViewPager2 sliderViewPager = vh.RequireCachedView<ViewPager2>(2131298381);
		CircleIndicator sliderIndicator = vh.RequireCachedView<CircleIndicator>(2131298380);
		sliderViewPager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(10f)));
		sliderViewPager.OffscreenPageLimit = 2;
		SnackView warningSnack = vh.RequireCachedView<SnackView>(2131296688);
		SnackView overweightSnack = vh.RequireCachedView<SnackView>(2131297835);
		View youCanAddToPreviousOrder = vh.RequireCachedView<View>(2131298857);
		TextView textView = vh.RequireCachedView<TextView>(2131298858);
		TextView textView2 = vh.RequireCachedView<TextView>(2131298675);
		View view = vh.RequireCachedView<View>(2131298308);
		View toolbarShareButton = vh.RequireCachedView<View>(2131298358);
		View toolbarItemsAndClearLine = vh.RequireCachedView<View>(2131298672);
		CompoundButton itemSelectedCount = vh.RequireCachedView<CompoundButton>(2131297388);
		View view2 = vh.RequireCachedView<View>(2131297389);
		TextView removeGoodsButton = vh.RequireCachedView<TextView>(2131298195);
		View tooManyMarkedGoodsCardView = vh.RequireCachedView<View>(2131298667);
		TextView tooManyMarkedGoodsTextView = vh.RequireCachedView<TextView>(2131298668);
		textView2.Text = base.ViewModel.CartTitle;
		removeGoodsButton.Text = base.ViewModel.RemoveGoodsButtonText;
		warningSnack.Text = base.ViewModel.WarningMessage;
		overweightSnack.Text = base.ViewModel.OverweightWarningMessage;
		overweightSnack.TextView.SetTextColor(new global::Android.Graphics.Color(ContextCompat.GetColor(Context, 2131100555)));
		textView.Text = base.ViewModel.YouCanAddToPreviousOrderText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[19]
		{
			(delegate
			{
				overweightSnack.Visibility = base.ViewModel.IsOverweightWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOverweightWarningVisible")),
			(delegate
			{
				overweightSnack.Description = base.ViewModel.OverweightWarningDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OverweightWarningDescription")),
			(delegate
			{
				warningSnack.Text = base.ViewModel.WarningMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WarningMessage")),
			(delegate
			{
				warningSnack.Description = base.ViewModel.WarningDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WarningDescription")),
			(delegate
			{
				warningSnack.Visibility = base.ViewModel.IsWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				warningSnack.TextView.SetTextColor(new global::Android.Graphics.Color(ContextCompat.GetColor(Context, base.ViewModel.HasUnavailableItems ? 2131099706 : 2131099704)));
				warningSnack.DescriptionView.SetTextColor(new global::Android.Graphics.Color(ContextCompat.GetColor(Context, base.ViewModel.HasUnavailableItems ? 2131100555 : 2131099704)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasUnavailableItems")),
			(delegate
			{
				removeGoodsButton.Visibility = base.ViewModel.IsRemoveGoodsButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsRemoveGoodsButtonVisible")),
			(delegate
			{
				removeGoodsButton.Enabled = base.ViewModel.IsRemoveGoodsButtonActive;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsRemoveGoodsButtonActive")),
			(delegate
			{
				toolbarItemsAndClearLine.Visibility = base.ViewModel.IsItemCountAndClearVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsItemCountAndClearVisible")),
			(delegate
			{
				slider.Visibility = base.ViewModel.IsPreviousOrdersVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPreviousOrdersVisible")),
			(delegate
			{
				sliderIndicator.CreateIndicators(base.ViewModel.PreviousOrdersToAdd.Count, 0);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PreviousOrdersToAdd")),
			(delegate
			{
				sliderIndicator.Visibility = base.ViewModel.IsPreviousOrdersPagerVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPreviousOrdersPagerVisible")),
			(delegate
			{
				UpdateSliderDataSource();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PreviousOrdersToAdd")),
			(delegate
			{
				youCanAddToPreviousOrder.Visibility = base.ViewModel.IsYouCanAddToPreviousOrderVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsYouCanAddToPreviousOrderVisible")),
			(delegate
			{
				itemSelectedCount.Checked = base.ViewModel.IsAllGoodsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAllGoodsSelected")),
			(delegate
			{
				itemSelectedCount.Text = base.ViewModel.GoodsSelectedText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("GoodsSelectedText")),
			(delegate
			{
				toolbarShareButton.Enabled = base.ViewModel.IsAnyGoodsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAnyGoodsSelected")),
			(delegate
			{
				tooManyMarkedGoodsTextView.Text = base.ViewModel.TooManyMarkedGoodsText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TooManyMarkedGoodsText")),
			(delegate
			{
				tooManyMarkedGoodsCardView.Visibility = base.ViewModel.IsTooManyMarkedGoodsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTooManyMarkedGoodsVisible"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.ToggleAllGoodsSelectionCommand.Trigger), ((View)removeGoodsButton).OnClick((Action)delegate
		{
			base.ViewModel.OpenRemoveGoodsDialogCommand.Trigger();
		}), view.OnClick((Action)delegate
		{
			base.ViewModel.OnSearchButtonClick();
		}), toolbarShareButton.OnClick((Action)delegate
		{
			base.ViewModel.ShareCartCommand.Trigger();
		}), ((View)warningSnack.DescriptionView).OnClick((Action)delegate
		{
			if (base.ViewModel.HasUnavailableItems)
			{
				int position = base.ViewModel.AutoLayout.Elements.IndexOf(base.ViewModel.AutoLayout.Elements.First((AutoLayoutViewModel.AutoLayoutElement x) => x.Type == "CartUnavailableHeader"));
				((LinearLayoutManager)(base.AutoLayoutRecycler?.GetLayoutManager()))?.ScrollToPositionWithOffset(position, 0);
			}
		}), sliderViewPager.OnPageSelected(delegate
		{
			sliderIndicator.AnimatePageSelected(sliderViewPager.CurrentItem);
		})).AddTo(disposables);
		void UpdateSliderDataSource()
		{
			sliderViewPager.Adapter = new ObservableRecyclerAdapter<CartPreviousOrderItemViewModel, CachingViewHolder>
			{
				DataSource = base.ViewModel.PreviousOrdersToAdd,
				CellLayoutId = 2131493214,
				BindViewHolderDelegate = OnBindPreviousOrderToAdd
			};
			sliderViewPager.SetCurrentItem(0, smoothScroll: true);
		}
	}

	private void OnBindPreviousOrderToAdd(CachingViewHolder holder, CartPreviousOrderItemViewModel model, int index, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131298646);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296958);
		TextView button = holder.RequireCachedView<TextView>(2131296587);
		View icon = holder.RequireCachedView<View>(2131297308);
		textView.Text = model.Title;
		textView2.Text = model.Description;
		button.Text = model.ButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			button.Enabled = base.ViewModel.IsAnyGoodsSelected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAnyGoodsSelected")))).AddTo(disposable);
		((View)button).OnClick((Action)delegate
		{
			base.ViewModel.AddToOrderCommand.Trigger(model);
		}).AddTo(disposable);
		icon.OnClick((Action)delegate
		{
			CartScreenViewModel viewModel = base.ViewModel;
			string hintText = model.HintText;
			View anchor = icon;
			System.Drawing.Point offsetDp = new System.Drawing.Point(-10, -10);
			Size paddingDp = new Size(20, 0);
			HintPopup.Show(viewModel, hintText, anchor, offsetDp, atTop: false, checkAnchorVisibility: false, default(Size), paddingDp);
		}).AddTo(disposable);
	}

	private void OnBindCartReservedHeader(CachingViewHolder vh)
	{
		vh.RequireCachedView<LinearLayout>(2131298212).Visibility = (base.ViewModel.IsAdultInCart && base.ViewModel.ItemsReserved.Count > 0).ToVisibility();
	}

	private void SetupTextView(CachingViewHolder vh, string text, CompositeDisposable disposables, float topDP = 0f)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131298603);
		if (topDP != 0f)
		{
			textView.UpdateLayoutParams(delegate(FrameLayout.LayoutParams lp)
			{
				lp.TopMargin = Converter.DpToPx(topDP);
			});
		}
		textView.Text = text;
	}

	private void AdjustProductCardWidth(CachingViewHolder vh)
	{
		vh.ItemView.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
			lp.Height = Converter.DpToPx(286f);
		});
	}

	private void OnBindBottomContent(CachingViewHolder vh, CompositeDisposable disposables)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131298721);
		TextView totalItemsPriceText = vh.RequireCachedView<TextView>(2131298723);
		TextView totalItemsPrice = vh.RequireCachedView<TextView>(2131298722);
		TextView totalOrderWeightText = vh.RequireCachedView<TextView>(2131298725);
		TextView totalOrderWeight = vh.RequireCachedView<TextView>(2131298724);
		View adultsReservedLayout = vh.RequireCachedView<View>(2131296410);
		TextView textView2 = vh.RequireCachedView<TextView>(2131296695);
		TextView totalCartItemsPrice = vh.RequireCachedView<TextView>(2131296694);
		TextView textView3 = vh.RequireCachedView<TextView>(2131298215);
		TextView totalReservedItemsPrice = vh.RequireCachedView<TextView>(2131298214);
		TextView totalDiscountTitle = vh.RequireCachedView<TextView>(2131298735);
		TextView totalDiscount = vh.RequireCachedView<TextView>(2131298734);
		TextView textView4 = vh.RequireCachedView<TextView>(2131298101);
		TextView textView5 = vh.RequireCachedView<TextView>(2131298100);
		RecyclerView discountItems = vh.RequireCachedView<RecyclerView>(2131296998);
		TextView textView6 = vh.RequireCachedView<TextView>(2131298727);
		TextView totalOrderPrice = vh.RequireCachedView<TextView>(2131298726);
		TextView pickingPriceText = vh.RequireCachedView<TextView>(2131297895);
		TextView pickingPrice = vh.RequireCachedView<TextView>(2131297894);
		TextView deliveryPriceText = vh.RequireCachedView<TextView>(2131296937);
		TextView deliveryPrice = vh.RequireCachedView<TextView>(2131296934);
		ImageView deliveryInfo = vh.RequireCachedView<ImageView>(2131296936);
		TextView textView7 = vh.RequireCachedView<TextView>(2131298729);
		TextView totalPrice = vh.RequireCachedView<TextView>(2131298728);
		LinearLayout loyaltyInfoView = vh.RequireCachedView<LinearLayout>(2131297500);
		TextView loyaltyTextView = vh.RequireCachedView<TextView>(2131297502);
		SnackView adultWarningSnackView = vh.RequireCachedView<SnackView>(2131296409);
		LinearLayout delayedCashbackSnack = vh.RequireCachedView<LinearLayout>(2131296913);
		TextView delayedCashbackText = vh.RequireCachedView<TextView>(2131296914);
		adultWarningSnackView.Text = base.ViewModel.AdultInCartText;
		pickingPriceText.Text = base.ViewModel.PickingPriceTitle;
		textView.Text = base.ViewModel.TotalHeaderText;
		totalDiscountTitle.Text = base.ViewModel.TotalDiscountTitle;
		textView6.Text = base.ViewModel.TotalOrderPriceText;
		totalOrderWeightText.Text = base.ViewModel.TotalItemsWeightText;
		textView2.Text = base.ViewModel.TotalInCartTitle;
		textView3.Text = base.ViewModel.TotalReservedTitle;
		textView4.Visibility = ViewStates.Gone;
		textView5.Visibility = ViewStates.Gone;
		textView7.Text = base.ViewModel.TotalPriceText;
		ObservableRecyclerAdapter<DiscountItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<DiscountItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493217,
			DataSource = base.ViewModel.DiscountItems,
			BindViewHolderDelegate = OnBindItem
		};
		discountItems.SetAdapter(adapter);
		ViewOnClickListener viewOnClickListener = new ViewOnClickListener(delegate(View v)
		{
			if (totalItemsPrice.Id == v.Id)
			{
				base.ViewModel.OnSwitchIsExpanded();
			}
			if (deliveryInfo.Id == v.Id)
			{
				base.ViewModel.OnShortDeliveryInfoClicked();
			}
		});
		totalItemsPrice.SetOnClickListener(viewOnClickListener);
		deliveryInfo.SetOnClickListener(viewOnClickListener);
		viewOnClickListener.AddTo(disposables);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[26]
		{
			(delegate
			{
				discountItems.Visibility = base.ViewModel.DiscountItems.Any().ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscountItems")),
			(delegate
			{
				totalItemsPriceText.Text = base.ViewModel.TotalItemsPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalItemsPriceText")),
			(delegate
			{
				totalItemsPriceText.Visibility = base.ViewModel.IsTotalItemPriceVisible.ToVisibility();
				totalItemsPrice.Visibility = base.ViewModel.IsTotalItemPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTotalItemPriceVisible")),
			(delegate
			{
				totalItemsPrice.Text = base.ViewModel.TotalItemsPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalItemsPrice")),
			(delegate
			{
				adultsReservedLayout.Visibility = base.ViewModel.IsExpanded.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpanded")),
			(delegate
			{
				totalItemsPrice.SetCompoundDrawablesWithIntrinsicBounds(0, 0, GetPriceExpandOrCollapseResourceId(base.ViewModel.CanExpand, base.ViewModel.IsExpanded), 0);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsExpanded", "CanExpand" })),
			(delegate
			{
				totalCartItemsPrice.Text = base.ViewModel.TotalInCartOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalInCartOrderPrice")),
			(delegate
			{
				delayedCashbackSnack.Visibility = base.ViewModel.IsDelayedCashbackTextVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDelayedCashbackTextVisible")),
			(delegate
			{
				totalReservedItemsPrice.Text = base.ViewModel.TotalReservedOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalReservedOrderPrice")),
			(delegate
			{
				totalDiscount.Visibility = base.ViewModel.HasDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDiscount")),
			(delegate
			{
				totalDiscountTitle.Visibility = base.ViewModel.HasDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDiscount")),
			(delegate
			{
				totalDiscount.Text = base.ViewModel.TotalDiscount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalDiscount")),
			(delegate
			{
				pickingPrice.Text = base.ViewModel.PickingPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceText")),
			(delegate
			{
				pickingPriceText.Visibility = base.ViewModel.PickingPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceVisible")),
			(delegate
			{
				pickingPrice.Visibility = base.ViewModel.PickingPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceVisible")),
			(delegate
			{
				deliveryPriceText.Text = base.ViewModel.ReceivingMethodPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceivingMethodPriceText")),
			(delegate
			{
				deliveryPrice.Text = base.ViewModel.DeliveryPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryPrice")),
			(delegate
			{
				deliveryInfo.Visibility = base.ViewModel.IsDeliveryInfoIconVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDeliveryInfoIconVisible")),
			(delegate
			{
				totalOrderPrice.Text = base.ViewModel.TotalOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalOrderPrice")),
			(delegate
			{
				totalOrderWeight.Text = base.ViewModel.TotalItemsWeight;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalItemsWeight")),
			(delegate
			{
				TextView textView8 = totalOrderWeightText;
				ViewStates visibility = (totalOrderWeight.Visibility = base.ViewModel.IsTotalItemWeightVisible.ToVisibility());
				textView8.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTotalItemWeightVisible")),
			(delegate
			{
				totalPrice.Text = base.ViewModel.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice")),
			(delegate
			{
				loyaltyInfoView.Visibility = base.ViewModel.IsInLoyalty.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsInLoyalty")),
			(delegate
			{
				adultWarningSnackView.Visibility = base.ViewModel.IsAdultWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAdultWarningVisible")),
			(delegate
			{
				delayedCashbackText.AddLinkedText(base.ViewModel.DelayedCashbackText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedCashbackText")),
			(delegate
			{
				loyaltyTextView.AddLinkedText(base.ViewModel.LoyaltyInformerText, new global::Android.Graphics.Color(ContextCompat.GetColor(RequireContext(), 2131100550)), underlineLinks: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LoyaltyInformerText"))
		})).AddTo(disposables);
	}

	private void OnBindEmptyContent(CachingViewHolder vh, CompositeDisposable disposables)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131296679);
		TextView minPriceOrderText = vh.RequireCachedView<TextView>(2131297577);
		_goToCatalogButton = vh.RequireCachedView<Button>(2131297645);
		_goToFavoritesButton = vh.RequireCachedView<Button>(2131297646);
		_cartRetryTitle = vh.RequireCachedView<TextView>(2131296698);
		_retryLastOrderButton = vh.RequireCachedView<View>(2131298227);
		_completedOrderProducts = vh.RequireCachedView<RecyclerView>(2131297420);
		textView.Text = base.ViewModel.EmptyTitle;
		_goToCatalogButton.Text = base.ViewModel.GoToCatalogButtonText;
		_goToFavoritesButton.Text = base.ViewModel.GoToFavoritesButtonText;
		_cartRetryTitle.Text = base.ViewModel.RetryLastOrderButtonText;
		_retryLastOrderButton.SetOnClickListener(_onClickListener);
		_goToCatalogButton.SetOnClickListener(_onClickListener);
		_goToFavoritesButton.SetOnClickListener(_onClickListener);
		SetupLastCompletedOrderProducts();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				_goToFavoritesButton.Visibility = base.ViewModel.IsFavoritesAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFavoritesAvailable")),
			(delegate
			{
				minPriceOrderText.Text = base.ViewModel.MinOrderSumText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MinOrderSumText")),
			(delegate
			{
				_retryLastOrderButton.Visibility = base.ViewModel.IsLastCompletedOrderAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsLastCompletedOrderAvailable")),
			(UpdateLastCompletedOrderProductsDataSource, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LastCompletedOrder"))
		})).AddTo(disposables);
		Disposable.Create(delegate
		{
			_retryLastOrderButton.SetOnClickListener(null);
			_goToCatalogButton.SetOnClickListener(null);
			_goToFavoritesButton.SetOnClickListener(null);
			_goToCatalogButton = null;
			_goToFavoritesButton = null;
			_cartRetryTitle = null;
			_retryLastOrderButton = null;
		}).AddTo(disposables);
	}

	private void OnBindItem(CachingViewHolder vh, DiscountItemViewModel viewModel, int pos, CompositeDisposable disposables)
	{
		vh.RequireCachedView<TextView>(2131297001).Text = viewModel.Title;
		vh.RequireCachedView<TextView>(2131296994).Text = viewModel.Amount;
	}

	private void GoToCatalog(Unit _)
	{
		_bottomNavigation.SelectedItemId = 2131297641;
	}

	private void GoToFavorites(Unit unit)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<FavoritesFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private async Task GoToCheckoutAsync(BrokerToken parameter)
	{
		(await this.GetParentFragmentManagerAsync()).BeginTransaction().Hide(this).Add<CheckoutFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void GoToItemCard(ProductDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductDetailsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenRemoveGoodsDialog()
	{
		AlertDialog.Builder builder = new AlertDialog.Builder(RequireContext());
		builder.SetTitle(base.ViewModel.RemoveGoodsDialogTitle);
		builder.SetMessage(base.ViewModel.RemoveGoodsDialogText);
		builder.SetPositiveButton(base.ViewModel.RemoveGoodsDialogPositiveText, delegate
		{
			base.ViewModel.OnRemoveGoodsApprovedAsync().SafeFireAndForget((Action<Exception>)null, false);
		});
		builder.SetNegativeButton(base.ViewModel.RemoveGoodsDialogNegativeText, delegate
		{
		});
		builder.Create().ShowCentered();
	}

	private void OpenDeleteItemDialog(CartItemViewModel item)
	{
		AlertDialog.Builder builder = new AlertDialog.Builder(RequireContext());
		builder.SetTitle(base.ViewModel.DeleteItemDialogTitle);
		builder.SetMessage(base.ViewModel.DeleteItemDialogText);
		builder.SetPositiveButton(base.ViewModel.RemoveGoodsDialogPositiveText, delegate
		{
			base.ViewModel.OnDeleteItem(item);
		});
		builder.SetNegativeButton(base.ViewModel.RemoveGoodsDialogNegativeText, delegate
		{
		});
		builder.Create().ShowCentered();
	}

	private void OpenLoyaltyPolicy(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void SetReceiveMethodProgress(int progress)
	{
		SetProgress(progress);
		CartScreenViewModel.ProgressState progressStatus = base.ViewModel.GetProgressStatus();
		ProgressBar receiveMethodProgress = _receiveMethodProgress;
		Context context = RequireContext();
		int id = default(int);
		switch (progressStatus)
		{
		case CartScreenViewModel.ProgressState.RedLessThanStoreMinPrice:
			id = 2131231571;
			break;
		case CartScreenViewModel.ProgressState.OrangeIncreasePriceForFreeDelivery:
			id = 2131231572;
			break;
		case CartScreenViewModel.ProgressState.OrangeOverweight:
			id = 2131231572;
			break;
		case CartScreenViewModel.ProgressState.GreenFreeDelivery:
			id = 2131231569;
			break;
		default:
			global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(progressStatus);
			break;
		}
		receiveMethodProgress.ProgressDrawable = ContextCompat.GetDrawable(context, id);
		if (progressStatus == CartScreenViewModel.ProgressState.OrangeOverweight)
		{
			SetProgressOverweightState();
		}
		else
		{
			SetProgressDefaultState();
		}
	}

	private void SetProgress(int progress)
	{
		if (!OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			_receiveMethodProgress.Progress = progress;
		}
		else
		{
			_receiveMethodProgress?.SetProgress(progress, animate: false);
		}
	}

	private void SetProgressOverweightState()
	{
		_receiveMethodImageView.SetImageResource(2131231266);
	}

	private void SetProgressDefaultState()
	{
		switch (base.ViewModel.ReceiveMode)
		{
		case ReceivingMethod.Delivery:
			_receiveMethodImageView.SetImageResource(2131231373);
			break;
		case ReceivingMethod.CarPickup:
			_receiveMethodImageView.SetImageResource(2131231184);
			break;
		case ReceivingMethod.Pickup:
			_receiveMethodImageView.SetImageResource(2131231187);
			break;
		default:
			_receiveMethodImageView.SetImageResource(2131231160);
			break;
		}
	}

	private void ShowQtyRecommendationsInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}

	private void SetupHorizontalRecommendations(CachingViewHolder vh, object data, CompositeDisposable disposables)
	{
		if (!(data is SectionItemViewModel sectionItemViewModel))
		{
			throw new ArgumentException("data is not SectionItemViewModel");
		}
		int num = Converter.DpToPx(20f);
		new RecommendationSectionBindings(vh, sectionItemViewModel.Parent, nestedScrollEnabled: false).Bind(sectionItemViewModel, base.ViewModel, OperatingSystem.IsAndroidVersionAtLeast(23) ? new Func<View, IObservable<bool>>(base.AutoLayoutRecycler.BecameVisible) : null, Converter.DpToPx(16f), num, num, disposables);
	}

	private void OnOpenSearch()
	{
		SearchProductsResultFragment.OpenSearch(this);
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		base.AutoLayoutRecycler.RemoveOnScrollListener(_loadMoreScrollListener);
		_loadMoreScrollListener.Dispose();
		_loadMoreScrollListener = null;
		_receiveMethodView = null;
	}

	private async Task ShowAdultWarning()
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		RepeatAdultProductWarningPopupFragment repeatAdultProductWarningPopupFragment = _fragmentFactory.Instantiate<RepeatAdultProductWarningPopupFragment>();
		repeatAdultProductWarningPopupFragment.Show(supportFragmentManager, null);
		if (await repeatAdultProductWarningPopupFragment.Execute())
		{
			await base.ViewModel.RepeatOrderService.ShowAddressSelection();
		}
	}
}
