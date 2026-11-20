using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Common;
using Auchan.Android.Common.HighlightScreen;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Bumptech.Glide;
using EBind;
using Google.Android.Material.AppBar;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal class CatalogFragment : BaseToolbarFragment<CatalogViewModel>
{
	private DroidPopupQueue _queueManager;

	private bool _expressDeliveryHighlightPending;

	private bool _canShowExpressDeliveryHighlightOnCurrentResume = true;

	private bool _expressDeliveryHighlightAvailabilityChecked;

	private bool _expressDeliveryHighlightTargetLayoutPending;

	private bool _storeReviewPopupRequested;

	private ReceiveMethodSelectView _receiveMethodView;

	private AppBarLayout _appBar;

	private RecyclerView _categoryList;

	private readonly HashSet<DialogFragment> _observedDialogs = new HashSet<DialogFragment>();

	protected override int LayoutId => 2131492999;

	public CatalogFragment(Func<Fragment, CatalogViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_queueManager = DroidPopupQueue.CreateFor(this);
		_queueManager.OnCreate(base.ParentFragmentManager).AutoDisposeOnDestroy(this);
		base.ViewModel.OpenAddressCheckCommand.SafeSubscribe(delegate(AddressViewModel.Parameter p)
		{
			Show<AddressFragment, AddressViewModel.Parameter>(p);
		}, this);
		base.ViewModel.NavigateNextCommand.ObserveOn(MainThread.Scheduler).Subscribe(NavigateNextForResult).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.NavigateToProductsCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnNavigateToProductsNext).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OpenPriceChecker.SafeSubscribe(delegate
		{
			NavigateTo<PriceCheckerFragment>();
		}, this);
		base.ViewModel.ShowStoreReviewPopupCommand.SafeSubscribe(delegate
		{
			QueueStoreReviewPopup();
		}, this);
		base.ViewModel.ReceiveMethodViewModel.ShowExpressDeliveryHighlightCommand.SafeSubscribe(delegate
		{
			RequestExpressDeliveryHighlight();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_receiveMethodView = view.RequireViewById<ReceiveMethodSelectView>(2131298168);
		CoordinatorLayout coordinatorLayout = view.RequireViewById<CoordinatorLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = view.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		_appBar = coordinatorLayout.RequireViewById<AppBarLayout>(2131296451);
		_categoryList = coordinatorLayout.RequireViewById<RecyclerView>(2131296731);
		TextView textView2 = _appBar.RequireViewById<TextView>(2131298307);
		FrameLayout priceCheckerButton = _appBar.RequireViewById<FrameLayout>(2131297985);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				coordinatorLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		_categoryList.SetLayoutManager(new GridLayoutManager(base.Activity, 3));
		_categoryList.AddItemDecoration(new GridSpacesItemDecoration(8));
		_appBar.AddOnOffsetChangedListener(new AppBarStateChangeListener(OnStateChanged));
		OnStateChanged(AppBarStateChangeListener.State.Expanded);
		ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder> categoryAdapter = new ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493222,
			BindViewHolderDelegate = OnBindCategory,
			ClickCallback = OnCategoryItemClick
		};
		_categoryList.SetAdapter(categoryAdapter);
		textView2.Text = base.ViewModel.SearchPlaceholder;
		textView2.SetOnClickListener(new ViewOnClickListener(OnOpenSearch));
		_receiveMethodView.Bind(base.ViewModel.ReceiveMethodViewModel, ViewLifecycleOwner);
		_receiveMethodView.Post(TryQueueExpressDeliveryHighlight);
		textView.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				priceCheckerButton.Visibility = base.ViewModel.IsPriceCheckerEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPriceCheckerEnabled")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				categoryAdapter.DataSource = base.ViewModel.TopCategories;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TopCategories")),
			(delegate
			{
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)button).OnClick((EventHandler)delegate
		{
			base.ViewModel.Retry();
		}), ((View)showQrButton).OnClick((EventHandler)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), ((View)priceCheckerButton).OnClick((EventHandler)delegate
		{
			base.ViewModel.OnPriceCheckerClicked().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
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
		(from state in base.ViewModel.OnPropertyChanges((CatalogViewModel x) => x.State)
			where state == VisualState.Default
			select state).Subscribe(delegate
		{
			RetryExpressDeliveryHighlight();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			UpdateExpressDeliveryHighlightAvailability();
			_queueManager.OnResume();
		}
	}

	public override void OnStop()
	{
		base.OnStop();
		ResetExpressDeliveryHighlightAvailability();
		_storeReviewPopupRequested = false;
		if (!base.IsHidden)
		{
			_queueManager.OnPause();
		}
	}

	public override void OnResume()
	{
		base.OnResume();
		UpdateExpressDeliveryHighlightAvailability();
		RetryExpressDeliveryHighlight();
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (hidden)
		{
			ResetExpressDeliveryHighlightAvailability();
			_storeReviewPopupRequested = false;
			_queueManager.OnPause();
		}
		else
		{
			UpdateExpressDeliveryHighlightAvailability();
			_queueManager.OnResume();
			TryQueueExpressDeliveryHighlight();
		}
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		_receiveMethodView = null;
		_appBar = null;
		_categoryList = null;
		_expressDeliveryHighlightTargetLayoutPending = false;
	}

	private void RequestExpressDeliveryHighlight()
	{
		if (_canShowExpressDeliveryHighlightOnCurrentResume)
		{
			_expressDeliveryHighlightPending = true;
			TryQueueExpressDeliveryHighlight();
			_receiveMethodView?.Post(TryQueueExpressDeliveryHighlight);
		}
	}

	private void QueueStoreReviewPopup()
	{
		if (!_storeReviewPopupRequested)
		{
			_storeReviewPopupRequested = true;
			_queueManager.Show(base.ViewModel.RequestStoreReviewIfNeeded);
			TryQueueExpressDeliveryHighlight();
		}
	}

	private void TryQueueExpressDeliveryHighlight()
	{
		if (!_expressDeliveryHighlightPending || View == null || _appBar == null || _categoryList == null)
		{
			return;
		}
		if (!_appBar.IsFullyExpanded() || !_categoryList.IsAtTop())
		{
			RejectExpressDeliveryHighlight();
		}
		else
		{
			if (!_storeReviewPopupRequested || _receiveMethodView == null || base.ViewModel.State != VisualState.Default || !base.IsAdded || !base.IsResumed || base.IsHidden || !IsLastInCatalogStack())
			{
				return;
			}
			_receiveMethodView.PrepareForHighlight();
			if (_receiveMethodView.ExpressCell == null)
			{
				RetryWhenExpressDeliveryHighlightTargetIsLaidOut();
				return;
			}
			BrokerToken brokerToken = base.ViewModel.ReceiveMethodViewModel.CreateExpressDeliveryHighlight();
			if (brokerToken == null)
			{
				_expressDeliveryHighlightPending = false;
				return;
			}
			_expressDeliveryHighlightPending = false;
			new HighlightBundleBuilder().AddView(_receiveMethodView.ExpressCell.Id, 0f, Converter.DpToPx(8f)).SetSearchRoot(2131296711).SetTargetView(_receiveMethodView.Id)
				.ShowInQueue<ExpressDeliveryHighlightScreenFragment>(_queueManager, brokerToken, CanShowExpressDeliveryHighlight);
		}
	}

	private bool CanShowExpressDeliveryHighlight()
	{
		if (_canShowExpressDeliveryHighlightOnCurrentResume && _storeReviewPopupRequested && View != null && _appBar != null && _categoryList != null && _appBar.IsFullyExpanded() && _categoryList.IsAtTop() && _receiveMethodView?.ExpressCell != null && base.ViewModel.State == VisualState.Default && base.IsAdded && base.IsResumed && !base.IsHidden)
		{
			return IsLastInCatalogStack();
		}
		return false;
	}

	private void UpdateExpressDeliveryHighlightAvailability()
	{
		if (!_expressDeliveryHighlightAvailabilityChecked && _appBar != null && _categoryList != null)
		{
			_expressDeliveryHighlightAvailabilityChecked = true;
			_canShowExpressDeliveryHighlightOnCurrentResume = _appBar.IsFullyExpanded() && _categoryList.IsAtTop();
			if (!_canShowExpressDeliveryHighlightOnCurrentResume)
			{
				RejectExpressDeliveryHighlight();
			}
		}
	}

	private void ResetExpressDeliveryHighlightAvailability()
	{
		_expressDeliveryHighlightAvailabilityChecked = false;
		_canShowExpressDeliveryHighlightOnCurrentResume = false;
		_expressDeliveryHighlightTargetLayoutPending = false;
		RejectExpressDeliveryHighlight();
	}

	private void RetryWhenExpressDeliveryHighlightTargetIsLaidOut()
	{
		if (!_expressDeliveryHighlightTargetLayoutPending && _receiveMethodView?.RecyclerView != null)
		{
			_expressDeliveryHighlightTargetLayoutPending = true;
			RecyclerView recyclerView = _receiveMethodView.RecyclerView;
			recyclerView.ViewTreeObserver.AddOnGlobalLayoutListener(new OneTimeOnGlobalLayoutListener(recyclerView, delegate
			{
				_expressDeliveryHighlightTargetLayoutPending = false;
				TryQueueExpressDeliveryHighlight();
			}));
			recyclerView.RequestLayout();
		}
	}

	private void RejectExpressDeliveryHighlight()
	{
		_expressDeliveryHighlightPending = false;
		_queueManager.RemoveFromQueue<ExpressDeliveryHighlightScreenFragment>();
	}

	private void RetryExpressDeliveryHighlight()
	{
		_queueManager.RaiseQueue();
		TryQueueExpressDeliveryHighlight();
	}

	private bool IsLastInCatalogStack()
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

	private void OnStateChanged(AppBarStateChangeListener.State state)
	{
		if (base.ToolbarTitleLabel != null)
		{
			base.ToolbarTitleLabel.Visibility = ((state != AppBarStateChangeListener.State.Collapsed) ? ViewStates.Gone : ViewStates.Visible);
		}
	}

	private void OnCategoryItemClick(CachingViewHolder vh, CategoryItemViewModel vm, int arg3)
	{
		base.ViewModel.NavigateToCategory(vm);
	}

	private void OnBindCategory(CachingViewHolder holder, CategoryItemViewModel model, int position, CompositeDisposable disposable)
	{
		ImageView imageView = holder.FindCachedView<ImageView>(2131296728);
		holder.ItemView.ContentDescription = model.Title;
		Glide.With(RequireContext()).Clear(imageView);
		imageView.SetImageResource(2131231086);
		imageView.ClipToOutline = true;
		if (!string.IsNullOrWhiteSpace(model.Category.ImageUrl))
		{
			imageView.FromUrlAnimated(model.Category.ImageUrl);
		}
	}

	private void NavigateNextForResult(CategoryViewModel.Parameter parameter)
	{
		NavigateTo<CategoryFragment, CategoryViewModel.Parameter>(parameter);
	}

	private void OnNavigateToProductsNext(BrokerToken parameter)
	{
		NavigateTo<CatalogProductsFragment, BrokerToken>(parameter, null, add: true);
	}

	private void OnOpenSearch(View obj)
	{
		SearchProductsResultFragment.OpenSearch(this);
		base.ViewModel.OnSearchClick();
	}
}
