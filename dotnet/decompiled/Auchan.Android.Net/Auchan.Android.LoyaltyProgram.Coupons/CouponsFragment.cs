using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls.EmptyView;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram.Coupons;

internal class CouponsFragment : BaseToolbarFragment<CouponsViewModel>
{
	protected override int LayoutId => 2131493016;

	public CouponsFragment(Func<CouponsViewModel.Parameter, CouponsViewModel> newViewModel)
		: base((Func<Fragment, CouponsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CouponsViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
		base.ViewModel.OpenCouponDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<CouponDetailsFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.ShowQrCommand.SafeSubscribe(delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296909);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131298079);
		ViewGroup viewGroup3 = view.RequireViewById<ViewGroup>(2131297111);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131297563);
		Button button = view.RequireViewById<Button>(2131296325);
		Button button2 = viewGroup3.RequireViewById<Button>(2131298371);
		AisEmptyView aisEmptyView = view.RequireViewById<AisEmptyView>(2131297070);
		TextView textView3 = aisEmptyView.RequireViewById<TextView>(2131297083);
		TextView textView4 = aisEmptyView.RequireViewById<TextView>(2131297078);
		View newIndicator = view.RequireViewById<View>(2131297338);
		TextView newIndicatorText = view.RequireViewById<TextView>(2131297342);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296866);
		recyclerView.AddItemDecoration(new VerticalSpaceItemDecoration(5));
		ObservableRecyclerAdapter<CouponItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<CouponItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493232,
			DataSource = base.ViewModel.Coupons,
			BindViewHolderDelegate = Bind
		};
		recyclerView.SetAdapter(adapter);
		base.ToolbarTitle = base.ViewModel.Title;
		button.Text = base.ViewModel.RetryText;
		textView.Text = base.ViewModel.ErrorTitle;
		textView2.Text = base.ViewModel.ErrorDescription;
		textView3.Text = base.ViewModel.EmptyTitle;
		textView4.Text = base.ViewModel.EmptyDescription;
		VisibilitySwitch<CouponsViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<CouponsViewModel.VisualState>(CouponsViewModel.VisualState.Default)
		{
			{
				CouponsViewModel.VisualState.Default,
				viewGroup
			},
			{
				CouponsViewModel.VisualState.InProgress,
				viewGroup2
			},
			{
				CouponsViewModel.VisualState.Error,
				viewGroup3
			},
			{
				CouponsViewModel.VisualState.Empty,
				aisEmptyView
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				newIndicator.Visibility = base.ViewModel.CouponsNewAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponsNewAvailable")),
			(delegate
			{
				newIndicatorText.Text = base.ViewModel.CouponsNewText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponsNewText")),
			(delegate
			{
				adapter.DataSource = base.ViewModel.Coupons;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Coupons"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.RetryCommand.Trigger), button2.OnClick(base.ViewModel.ShowQr)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void Bind(CachingViewHolder holder, CouponItemViewModel entry, int index, CompositeDisposable disposables)
	{
		if (!entry.IsStub)
		{
			TextView textView = holder.RequireCachedView<TextView>(2131298659);
			TextView textView2 = holder.RequireCachedView<TextView>(2131296964);
			LinearLayout linearLayout = holder.RequireCachedView<LinearLayout>(2131297127);
			TextView textView3 = holder.RequireCachedView<TextView>(2131297128);
			ImageView imageView = holder.RequireCachedView<ImageView>(2131296495);
			View newIndicator = holder.RequireCachedView<View>(2131297338);
			textView.Text = entry.Name;
			textView2.Text = entry.Description;
			textView3.Text = entry.ExpiryText;
			linearLayout.Visibility = entry.HasExpiryDate.ToInvisibleVisibility();
			imageView.FromUrl(entry.MediaUrl);
			entry.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
			{
				newIndicator.Visibility = entry.IsNew.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsNew")))).AddTo(disposables);
			holder.ItemView.OnClick((Action)delegate
			{
				base.ViewModel.CouponTapped(entry);
			}).AddTo(disposables);
		}
	}
}
