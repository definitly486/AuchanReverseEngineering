using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Controls;
using Auchan.Android.Drive;
using Auchan.Android.Ecom.Cart;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Orders;

internal class OrdersFragment : BaseToolbarFragment<OrdersViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493072;

	public OrdersFragment(Func<Fragment, OrdersViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateNextCommand.SafeSubscribe(OnNavigateNext, this);
		base.ViewModel.NavigateCatalogCommand.SafeSubscribe(NavigateToCatalog, this);
		base.ViewModel.NavigateToIssuingZonePopup.SafeSubscribe(OpenIssuingZonePopup, this);
		base.ViewModel.OpenIsArrivedPopupCommand.SafeSubscribe(delegate(OrderItemViewModel o)
		{
			OpenIsArrivedDialog(o).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.OpenPaymentCommand.SafeSubscribe(OpenPayment, this);
		base.ViewModel.RepeatOrderService.NavigateToStaticProductListCommand.SafeSubscribe(GoToStaticList, this);
		base.ViewModel.RepeatOrderService.ShowRepeatAdultProductWarningCommand.SafeSubscribe(delegate
		{
			ShowAdultWarning().SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.RepeatOrderService.NavigateToCartCommand.SafeSubscribe(delegate
		{
			NavigateToTab(2131297640);
		}, this);
		base.ViewModel.RepeatOrderService.NavigateToRepeatPreviousOrderPopup.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<RepeatOrderPopupFragment, BrokerToken>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297066);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout3 = view.RequireViewById<ConstraintLayout>(2131297111);
		Button button = constraintLayout2.RequireViewById<Button>(2131297064);
		TextView errorMessage = constraintLayout3.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout3.RequireViewById<TextView>(2131297563);
		Button retryButton = constraintLayout3.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout3.RequireViewById<Button>(2131298371);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				constraintLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout3
			},
			{
				VisualState.Empty,
				constraintLayout2
			}
		};
		textView.Text = base.ViewModel.ProgressTitle;
		SetUIProperties(view);
		ConfigureOrdersRecyclerView(constraintLayout);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHint")),
			(delegate
			{
				retryButton.Text = base.ViewModel.ErrorButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorButtonText")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.NavigateToCatalog), ((View)retryButton).OnClick((Action)delegate
		{
			base.ViewModel.LoadFirstPageOrdersQueued();
		}), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetUIProperties(View view)
	{
		TextView textView = view.RequireViewById<TextView>(2131298679);
		TextView textView2 = view.RequireViewById<TextView>(2131297810);
		Button button = view.RequireViewById<Button>(2131297064);
		TextView textView3 = view.RequireViewById<TextView>(2131297812);
		button.Text = base.ViewModel.EmptyPageButtonText;
		textView3.Text = base.ViewModel.EmptyTitleText;
		textView2.Text = base.ViewModel.EmptyHintText;
		textView.Text = base.ViewModel.Title;
	}

	private void ConfigureOrdersRecyclerView(View view)
	{
		EndlessRecyclerView endlessRecyclerView = view.RequireViewById<EndlessRecyclerView>(2131297813);
		endlessRecyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		ObservableRecyclerAdapter<List<OrderItemViewModel>, CachingViewHolder> purchasesAdapter = new ObservableRecyclerAdapter<List<OrderItemViewModel>, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = BindViewHolderDelegate,
			ClickCallback = OnItemClick
		};
		endlessRecyclerView.SetAdapter(purchasesAdapter);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			purchasesAdapter.DataSource = base.ViewModel.Orders;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Orders")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		endlessRecyclerView.HasNextPage = true;
		endlessRecyclerView.SetOnLoadMoreListener(new OnLoadMoreListener(delegate
		{
			base.ViewModel.LoadNextPage();
		}));
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		View itemView = base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false);
		return cellLayoutId switch
		{
			2131493273 => new MultiOrdersItemViewHolder(itemView, base.ViewModel), 
			2131493272 => new OrdersItemViewHolder(itemView, base.ViewModel), 
			_ => throw new NotImplementedException($"Cannot resolve any ViewHolder for {cellLayoutId} cell layout id"), 
		};
	}

	private int GetItemViewTypeDelegate(int position)
	{
		if (base.ViewModel.Orders[position].Count == 1)
		{
			return 2131493272;
		}
		return 2131493273;
	}

	private void BindViewHolderDelegate(CachingViewHolder holder, List<OrderItemViewModel> model, int position, CompositeDisposable disposable)
	{
		if (holder is OrdersItemViewHolder ordersItemViewHolder)
		{
			ordersItemViewHolder.DoBind(model, disposable);
		}
		else if (holder is MultiOrdersItemViewHolder multiOrdersItemViewHolder)
		{
			multiOrdersItemViewHolder.DoBind(model, disposable);
		}
	}

	private void OnNavigateNext(OrderDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<OrderDetailsFragment>(base.ParentFragment, parameter.ToNavBundle(), null, 2131297216)
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenIssuingZonePopup(IssuingAreaViewModel.Parameter parameter)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			IssuingAreaPopupFragment issuingAreaPopupFragment = _fragmentFactory.Instantiate<IssuingAreaPopupFragment>();
			issuingAreaPopupFragment.Arguments = parameter.ToNavBundle();
			issuingAreaPopupFragment.Show(appCompatActivity.SupportFragmentManager, null);
			issuingAreaPopupFragment.NavigateToOrders = delegate
			{
				base.ViewModel.LoadFirstPageOrdersQueued();
			};
		}
	}

	private async Task OpenIsArrivedDialog(OrderItemViewModel order)
	{
		if (await ShowAutoDialog(order) == AgreeState.Yes && Platform.CurrentActivity is AppCompatActivity)
		{
			base.ViewModel.LoadFirstPageOrdersQueued();
			Show<AlreadyBringingPopupFragment>();
		}
	}

	private Task<AgreeState> ShowAutoDialog(OrderItemViewModel order)
	{
		if (Platform.CurrentActivity is AppCompatActivity)
		{
			AskIsPersonArrivedViewModel.Parameter parameter = new AskIsPersonArrivedViewModel.Parameter(order.OrderId);
			return Show<AskIsPersonArrivedFragment, AskIsPersonArrivedViewModel.Parameter>(parameter).Execute();
		}
		return Task.FromResult(AgreeState.None);
	}

	private void NavigateToCatalog(Unit obj)
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = 2131297641;
		}
	}

	private void OnItemClick(CachingViewHolder vh, List<OrderItemViewModel> vm, int pos)
	{
		if (vm.Count <= 1)
		{
			OrderItemViewModel orderItemViewModel = vm.First();
			base.ViewModel.NavigateToDetailsAsync(orderItemViewModel.Order).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void OpenPayment(CheckoutWebViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(this)
			.Add<CheckoutWebViewFragment>(this, parameter.ToNavBundle())
			.Commit();
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
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

	private void NavigateToTab(int resourceId)
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = resourceId;
		}
	}
}
