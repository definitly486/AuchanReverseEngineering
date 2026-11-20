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

namespace Auchan.Android.Controls;

internal abstract class OptionDialogFragment<TOption, TItem, TViewModel> : BaseBottomSheetDialogFragment<TViewModel> where TOption : ISelectionItemViewModel<TItem, TViewModel> where TItem : ITitle where TViewModel : ScreenViewModel, IOptionSelectorViewModel<TOption, TItem>
{
	private sealed class Controls(View view)
	{
		public View View => _003Cview_003EP;

		public View PullIndicator { get; } = _003Cview_003EP.RequireViewById<View>(2131298111);

		public TextView TitleLabel { get; } = _003Cview_003EP.RequireViewById<TextView>(2131298646);

		public View CloseButton { get; } = _003Cview_003EP.RequireViewById<View>(2131296795);

		public RecyclerView RecyclerView { get; } = _003Cview_003EP.RequireViewById<RecyclerView>(2131298188);

		public TextView ApplyButton { get; } = _003Cview_003EP.RequireViewById<TextView>(2131296454);
	}

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493070;

	protected OptionDialogFragment(Func<Fragment, TViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseDialogCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.View.SetPadding(Converter.DpToPx(base.ViewModel.PaddingLeft), controls.View.PaddingTop, Converter.DpToPx(base.ViewModel.PaddingRight), controls.View.PaddingBottom);
		controls.PullIndicator.Visibility = base.ViewModel.ShowPullIndicator.ToInvisibleVisibility();
		controls.TitleLabel.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = Converter.DpToPx(base.ViewModel.PaddingTop);
		});
		ObservableRecyclerAdapter<TOption, CachingViewHolder> adapter = new ObservableRecyclerAdapter<TOption, CachingViewHolder>
		{
			CellLayoutId = 2131493265,
			BindViewHolderDelegate = BindItem,
			DataSource = base.ViewModel.Items
		};
		controls.RecyclerView.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = Converter.DpToPx(base.ViewModel.TableTopMargin);
		});
		controls.RecyclerView.SetLayoutManager(new LinearLayoutManager(Context));
		controls.RecyclerView.SetAdapter(adapter);
		controls.ApplyButton.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = Converter.DpToPx(base.ViewModel.ApplyButtonTopMargin);
		});
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				controls.TitleLabel.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.ApplyButton.Text = base.ViewModel.ApplyButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ApplyButtonTitle"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.ApplyButton.OnClick(base.ViewModel.ApplyCommand.Trigger), controls.CloseButton.OnClick(base.ViewModel.CloseDialogCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	protected virtual void BindItem(CachingViewHolder vh, TOption item, int index, CompositeDisposable disposable)
	{
		CheckBox checkbox = vh.RequireCachedView<CheckBox>(2131296768);
		checkbox.Text = item.Item.Title;
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			checkbox.Checked = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		item.Parent.BindEvents(vh.ItemView.OnClick((Action)delegate
		{
			item.Parent.SelectItemCommand.Trigger(item);
		})).AddTo(disposable);
	}
}
internal abstract class OptionDialogFragment<TItem, TViewModel> : OptionDialogFragment<SelectionItemViewModel<TItem, TViewModel>, TItem, TViewModel> where TItem : ITitle where TViewModel : ScreenViewModel, IOptionSelectorViewModel<SelectionItemViewModel<TItem, TViewModel>, TItem>
{
	protected OptionDialogFragment(Func<Fragment, TViewModel> newViewModel)
		: base(newViewModel)
	{
	}
}
