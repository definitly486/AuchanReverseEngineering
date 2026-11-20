using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat;
using Auchan.Common.SupportChat.ItemViewModels;
using Google.Android.Material.Card;

namespace Auchan.Android.SupportChat;

internal sealed class RefundFragment : BaseDialogFragment<RefundScreenViewModel>
{
	public override int Theme => 2131951957;

	protected override int LayoutId => 2131493006;

	public RefundFragment(Func<BrokerToken, RefundScreenViewModel> newViewModel)
		: base((Func<Fragment, RefundScreenViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296791);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		TextView nextButton = view.RequireViewById<TextView>(2131297667);
		textView.Text = base.ViewModel.Title;
		nextButton.Text = base.ViewModel.NextText;
		ObservableRecyclerAdapter<RefundItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<RefundItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493226,
			DataSource = base.ViewModel.Items,
			BindViewHolderDelegate = OnBind
		};
		recyclerView.SetAdapter(adapter);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			nextButton.Enabled = base.ViewModel.IsCanGoNext;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCanGoNext")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		}), ((View)nextButton).OnClick((Action)delegate
		{
			base.ViewModel.NextCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBind(CachingViewHolder holder, RefundItemViewModel model, int index, CompositeDisposable disposable)
	{
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297319);
		TextView textView = holder.RequireCachedView<TextView>(2131298646);
		CompoundButton checkBox = holder.RequireCachedView<CompoundButton>(2131296768);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297980);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297977);
		MaterialCardView materialCardView = holder.RequireCachedView<MaterialCardView>(2131296496);
		TextView textView4 = holder.RequireCachedView<TextView>(2131296497);
		View view = holder.RequireCachedView<View>(2131297329);
		View decreaseButton = holder.RequireCachedView<View>(2131296902);
		View increaseButton = holder.RequireCachedView<View>(2131297335);
		TextView itemCount = holder.RequireCachedView<TextView>(2131297385);
		bool isEnabled = model.Item.IsEnabled;
		if (string.IsNullOrEmpty(model.Item.Image))
		{
			imageView.SetImageResource(2131231317);
		}
		else
		{
			imageView.FromUrl(model.Item.Image);
		}
		imageView.ImageAlpha = (isEnabled ? 255 : 128);
		textView.Text = model.Item.Title;
		textView.SetTextColor(isEnabled ? 2131099872 : 2131100602);
		textView.Visibility = model.Item.IsTitleVisible.ToInvisibleVisibility();
		textView2.Text = model.Item.PricePerOneText;
		textView2.SetTextColor(isEnabled ? 2131100604 : 2131100602);
		textView2.Visibility = model.Item.IsPricePerOneVisible.ToInvisibleVisibility();
		textView3.Text = model.Item.PriceText;
		textView3.SetTextColor(isEnabled ? 2131099872 : 2131100602);
		textView3.Visibility = model.Item.IsPriceVisible.ToInvisibleVisibility();
		textView4.Text = model.Item.Status;
		materialCardView.Visibility = model.Item.IsStatusVisible.ToInvisibleVisibility();
		checkBox.Visibility = isEnabled.ToVisibility();
		view.Visibility = model.Item.IsQuantytVisible.ToVisibility();
		model.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				increaseButton.Enabled = model.IsCanAdd;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCanAdd")),
			(delegate
			{
				decreaseButton.Enabled = model.IsCanRemove;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCanRemove")),
			(delegate
			{
				itemCount.Text = model.SelectedCountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedCountText")),
			(delegate
			{
				checkBox.Checked = model.Selected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected"))
		})).AddTo(disposable);
		model.BindEvents(increaseButton.OnClick((Action)delegate
		{
			model.Increment();
		}), decreaseButton.OnClick((Action)delegate
		{
			model.Decrement();
		}), checkBox.OnCheckedChange((EventHandler<CompoundButton.CheckedChangeEventArgs>)delegate
		{
			model.Parent.OnItemChecked(model);
		})).AddTo(disposable);
	}
}
