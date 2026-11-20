using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.BottomNavigation;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.Cart;

internal class CheckoutOrderNotPaidFragment : BaseFragment<CheckoutOrderNotPaidViewModel>
{
	private OnBackPressedCallback? _backPressCallback;

	protected override int LayoutId => 2131493008;

	public CheckoutOrderNotPaidFragment(Func<CheckoutOrderNotPaidViewModel.Parameter, CheckoutOrderNotPaidViewModel> newViewModel)
		: base((Func<Fragment, CheckoutOrderNotPaidViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CheckoutOrderNotPaidViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, base.ViewModel.CloseCommand.Trigger);
		BottomNavigationView _bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		base.ViewModel.ReturnToCheckoutCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
		base.ViewModel.ReturnToCartCommand.SafeSubscribe(delegate
		{
			if (_bottomNavigation.SelectedItemId == 2131297640)
			{
				base.ParentFragmentManager.PopBackStack(null, 1);
			}
			else
			{
				base.ParentFragmentManager.PopBackStack();
			}
		}, this);
		base.ViewModel.OpenPaymentCommand.SafeSubscribe(delegate(CheckoutWebViewModel.Parameter parameter)
		{
			FragmentManager parentFragmentManager = base.ParentFragmentManager;
			parentFragmentManager.PopBackStackImmediate();
			Fragment fragment = parentFragmentManager.Fragments.Last();
			parentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(fragment)
				.Add<CheckoutWebViewFragment>(fragment, parameter.ToNavBundle())
				.Commit();
		}, this);
		base.ViewModel.OpenOrdersCommand.SafeSubscribe(delegate
		{
			FragmentManager parentFragmentManager = base.ParentFragmentManager;
			PopBackStack(parentFragmentManager);
			Fragment fragment = parentFragmentManager.Fragments.Last();
			parentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(fragment)
				.Add<OrdersFragment>(fragment)
				.Commit();
		}, this);
		base.ViewModel.OpenOrderCommand.SafeSubscribe(delegate(OrderDetailsViewModel.Parameter p)
		{
			FragmentManager parentFragmentManager = base.ParentFragmentManager;
			PopBackStack(parentFragmentManager);
			Fragment fragment = parentFragmentManager.Fragments.Last();
			parentFragmentManager.BeginTransaction().Commit<OrderDetailsFragment, OrderDetailsViewModel.Parameter>(fragment, p, null, add: true);
		}, this);
		void PopBackStack(FragmentManager fragmentManager)
		{
			if (_bottomNavigation.SelectedItemId == 2131297640 || _bottomNavigation.SelectedItemId == 2131297644)
			{
				fragmentManager.PopBackStackImmediate(null, 1);
			}
			else
			{
				fragmentManager.PopBackStackImmediate();
			}
		}
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296904);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131298079);
		TextView title = view.RequireViewById<TextView>(2131298679);
		View view2 = view.RequireViewById<View>(2131298249);
		Button button = view.RequireViewById<Button>(2131298228);
		Button cancelOrderButton = view.RequireViewById<Button>(2131296614);
		TextView textView = view.RequireViewById<TextView>(2131297808);
		TextView orderPriceText = view.RequireViewById<TextView>(2131297807);
		TextView receiveMethodTitle = view.RequireViewById<TextView>(2131298170);
		TextView receiveMethodText = view.RequireViewById<TextView>(2131298169);
		TextView receiveTimeTitle = view.RequireViewById<TextView>(2131298172);
		TextView receiveTimeText = view.RequireViewById<TextView>(2131298171);
		SnackView snackView = view.RequireViewById<SnackView>(2131297368);
		button.Text = base.ViewModel.ReturnToPaymentText;
		cancelOrderButton.Text = base.ViewModel.CancelOrderText;
		textView.Text = base.ViewModel.OrderPriceTitle;
		snackView.TextView.SetTextAppearance(2131952192);
		snackView.Text = base.ViewModel.InfoText;
		VisibilitySwitch<CheckoutOrderNotPaidViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<CheckoutOrderNotPaidViewModel.VisualState>(CheckoutOrderNotPaidViewModel.VisualState.Default)
		{
			{
				CheckoutOrderNotPaidViewModel.VisualState.Default,
				viewGroup
			},
			{
				CheckoutOrderNotPaidViewModel.VisualState.InProgress,
				viewGroup2
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[8]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				title.Text = base.ViewModel.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				cancelOrderButton.Visibility = base.ViewModel.CancelOrderAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CancelOrderAvailable")),
			(delegate
			{
				orderPriceText.Text = base.ViewModel.OrderPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OrderPriceText")),
			(delegate
			{
				receiveMethodTitle.Text = base.ViewModel.ReceiveMethodTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethodTitle")),
			(delegate
			{
				receiveMethodText.Text = base.ViewModel.ReceiveMethodText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethodText")),
			(delegate
			{
				receiveTimeTitle.Text = base.ViewModel.ReceiveTimeTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveTimeTitle")),
			(delegate
			{
				receiveTimeText.Text = base.ViewModel.ReceiveTimeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveTimeText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.CloseButtonClickCommand.Trigger), button.OnClick(base.ViewModel.ReturnToPaymentCommand.Trigger), cancelOrderButton.OnClick(base.ViewModel.CancelOrderCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (_backPressCallback != null)
		{
			_backPressCallback.Enabled = !hidden;
		}
	}
}
