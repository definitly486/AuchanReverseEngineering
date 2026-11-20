using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.Models;
using VisibilitySwitch;

namespace Auchan.Android.InfoPages;

[Register("auchan.Android.InfoPages.FAQFragment")]
internal class FAQFragment : BaseToolbarFragment<FAQViewModel>
{
	private RecyclerView _faqList;

	private RecyclerView.Adapter _faqListAdapter;

	protected override int LayoutId => 2131493027;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public FAQFragment(Func<FAQViewModel.Parameter, FAQViewModel> newViewModel)
		: base((Func<Fragment, FAQViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<FAQViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296904);
		View view3 = view.RequireViewById<View>(2131298079);
		View view4 = view.RequireViewById<View>(2131297111);
		TextView errorMessage = view4.RequireViewById<TextView>(2131298646);
		TextView errorHint = view4.RequireViewById<TextView>(2131297563);
		Button button = view4.RequireViewById<Button>(2131296325);
		Button button2 = view4.RequireViewById<Button>(2131298371);
		VisibilitySwitch<FAQViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<FAQViewModel.VisualState>(base.ViewModel.State)
		{
			{
				FAQViewModel.VisualState.Default,
				view2
			},
			{
				FAQViewModel.VisualState.InProgress,
				view3
			},
			{
				FAQViewModel.VisualState.Error,
				view4
			}
		};
		button.Text = base.ViewModel.ErrorButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
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
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.RetryClick), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		_faqList = view2.RequireViewById<RecyclerView>(2131297140);
		_faqListAdapter = new ObservableRecyclerAdapter<FAQEntry, CachingViewHolder>
		{
			CellLayoutId = 2131493241,
			DataSource = base.ViewModel.FAQEntries,
			BindViewHolderDelegate = OnBindEntry
		};
		_faqList.SetAdapter(_faqListAdapter);
	}

	private void OnBindEntry(CachingViewHolder holder, FAQEntry entry, int position, CompositeDisposable disposable)
	{
		TextView answerLabel = holder.FindCachedView<TextView>(2131297138);
		answerLabel.SetText(entry.Answer, TextView.BufferType.Normal);
		holder.FindCachedView<TextView>(2131297139).SetText(entry.Question, TextView.BufferType.Normal);
		entry.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			answerLabel.Visibility = entry.isExpanded.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("isExpanded")))).AddTo(disposable);
		holder.ItemView.OnClick((Action)delegate
		{
			GetAction(entry, position);
		}).AddTo(disposable);
		AddLastSeparator(holder, position);
	}

	private void GetAction(FAQEntry entry, int position)
	{
		entry.isExpanded = !entry.isExpanded;
		if (entry.isExpanded)
		{
			_faqList.SmoothScrollToPosition(position + 1);
		}
	}

	private void AddLastSeparator(CachingViewHolder holder, int position)
	{
		View view = holder.RequireCachedView<View>(2131298353);
		View view2 = holder.RequireCachedView<View>(2131297418);
		ObservableRangeCollection<FAQEntry> fAQEntries = base.ViewModel.FAQEntries;
		view.Visibility = (position != ((fAQEntries != null) ? new int?(fAQEntries.Count - 1) : ((int?)null))).ToVisibility();
		ObservableRangeCollection<FAQEntry> fAQEntries2 = base.ViewModel.FAQEntries;
		view2.Visibility = (position == ((fAQEntries2 != null) ? new int?(fAQEntries2.Count - 1) : ((int?)null))).ToVisibility();
	}
}
