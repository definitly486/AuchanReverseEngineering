using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Logs;
using EBind;
using VisibilitySwitch;

namespace Auchan.Android.Logs;

[Register("auchan.Android.Logs.LogFragment")]
internal class LogFragment : BaseToolbarFragment<LogViewModel>
{
	protected override int LayoutId => 2131493366;

	public LogFragment(Func<Fragment, LogViewModel> viewModel)
		: base(viewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override bool HasRightButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		Button button = constraintLayout.RequireViewById<Button>(2131298371);
		Button button2 = view.RequireViewById<Button>(2131297475);
		AppCompatImageButton appCompatImageButton = view.RequireViewById<AppCompatImageButton>(2131298249);
		SearchView searchView = view.RequireViewById<SearchView>(2131297474);
		searchView.SetIconifiedByDefault(iconified: false);
		searchView.QueryHint = "Поиск по логам";
		searchView.Iconified = false;
		searchView.QueryTextChange += new DisposableDelegate<EventHandler<SearchView.QueryTextChangeEventArgs>>(delegate(object? s, SearchView.QueryTextChangeEventArgs e)
		{
			base.ViewModel.SearchText = e.NewText ?? string.Empty;
		}, delegate(EventHandler<SearchView.QueryTextChangeEventArgs> d)
		{
			searchView.QueryTextChange -= d;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		BottomFadeEdgeRecyclerView bottomFadeEdgeRecyclerView = view.RequireViewById<BottomFadeEdgeRecyclerView>(2131297473);
		ObservableRecyclerAdapter<LogItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<LogItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493367,
			DataSource = base.ViewModel.FilteredLogItemViewModels,
			BindViewHolderDelegate = OnBindLog
		};
		bottomFadeEdgeRecyclerView.SetAdapter(adapter);
		button2.Text = base.ViewModel.SendLogsButtonText;
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			VisualState.Default,
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			visibilitySwitch.SwitchState(base.ViewModel.State);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)button2).OnClick((Action)delegate
		{
			base.ViewModel.SendLogsAsync().SafeFireAndForget((Action<Exception>)null, false);
		}), appCompatImageButton.OnClick(base.ViewModel.ExportLogsClick), ((View)button).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindLog(CachingViewHolder holder, LogItemViewModel itemViewModel, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297460);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297461);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297466);
		TextView textView4 = holder.RequireCachedView<TextView>(2131297467);
		TextView textView5 = holder.RequireCachedView<TextView>(2131297469);
		TextView textView6 = holder.RequireCachedView<TextView>(2131297470);
		View view = holder.RequireCachedView<View>(2131297465);
		TextView textView7 = holder.RequireCachedView<TextView>(2131297463);
		TextView textView8 = holder.RequireCachedView<TextView>(2131297464);
		textView2.SetTextIsSelectable(selectable: true);
		textView4.SetTextIsSelectable(selectable: true);
		textView6.SetTextIsSelectable(selectable: true);
		textView8.SetTextIsSelectable(selectable: true);
		ApplyHighlight(textView2, itemViewModel.LogTime, base.ViewModel.SearchText);
		ApplyHighlight(textView4, itemViewModel.Name, base.ViewModel.SearchText);
		ApplyHighlight(textView6, itemViewModel.LogType, base.ViewModel.SearchText);
		ApplyHighlight(textView8, itemViewModel.Description, base.ViewModel.SearchText);
		view.Visibility = LogMenuConverter.ViewStateFromIsDescriptionVisible(itemViewModel.IsDescriptionVisible);
		View view2 = holder.RequireCachedView<View>(2131297472);
		Color textColor = LogMenuConverter.ColorFromIsError(itemViewModel.IsErrorEntry);
		textView.SetTextColor(textColor);
		textView5.SetTextColor(textColor);
		textView3.SetTextColor(textColor);
		textView7.SetTextColor(textColor);
		textView2.SetTextColor(textColor);
		textView6.SetTextColor(textColor);
		textView4.SetTextColor(textColor);
		textView8.SetTextColor(textColor);
		view2.Visibility = LogMenuConverter.ViewStateFromIsError(itemViewModel.IsErrorEntry);
	}

	private void ApplyHighlight(TextView textView, string text, string searchText)
	{
		if (string.IsNullOrEmpty(text))
		{
			textView.Text = string.Empty;
			return;
		}
		if (string.IsNullOrEmpty(searchText))
		{
			textView.Text = text;
			return;
		}
		SpannableString spannableString = new SpannableString(text);
		int num = 0;
		while (num < text.Length)
		{
			int num2 = text.IndexOf(searchText, num, StringComparison.OrdinalIgnoreCase);
			if (num2 == -1)
			{
				break;
			}
			spannableString.SetSpan(new BackgroundColorSpan(Color.Yellow), num2, num2 + searchText.Length, SpanTypes.ExclusiveExclusive);
			num = num2 + searchText.Length;
		}
		textView.SetText(spannableString, TextView.BufferType.Spannable);
	}
}
