using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.Cases;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Cases;

internal class CasesFragment : BaseToolbarFragment<CasesViewModel>
{
	protected override int LayoutId => 2131492998;

	public CasesFragment(Func<Fragment, CasesViewModel> newViewModel)
		: base(newViewModel)
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

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.Title;
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297066);
		ConstraintLayout constraintLayout3 = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = constraintLayout2.RequireViewById<TextView>(2131298646);
		TextView textView2 = constraintLayout2.RequireViewById<TextView>(2131297563);
		ImageView imageView = constraintLayout2.RequireViewById<ImageView>(2131297308);
		textView.Text = base.ViewModel.EmptyTitleText;
		textView2.Visibility = ViewStates.Gone;
		imageView.SetImageResource(2131231424);
		TextView textView3 = constraintLayout3.RequireViewById<TextView>(2131298646);
		TextView textView4 = constraintLayout3.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout3.RequireViewById<AppCompatButton>(2131296325);
		View view2 = constraintLayout3.RequireViewById<View>(2131298371);
		ImageView imageView2 = constraintLayout3.RequireViewById<ImageView>(2131297308);
		view2.Visibility = ViewStates.Gone;
		imageView2.SetImageResource(2131231423);
		textView3.Text = base.ViewModel.ErrorTitleText;
		textView4.Text = base.ViewModel.ErrorMessageText;
		appCompatButton.Text = base.ViewModel.ErrorButtonText;
		frameLayout.RequireViewById<TextView>(2131298080).Text = base.ViewModel.ProgressTitle;
		EndlessRecyclerView casesRecyclerView = view.RequireViewById<EndlessRecyclerView>(2131296705);
		casesRecyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		ObservableRecyclerAdapter<CaseItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<CaseItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493221,
			BindViewHolderDelegate = BindCase,
			ClickCallback = OnItemClick,
			DataSource = base.ViewModel.Cases
		};
		casesRecyclerView.SetAdapter(adapter);
		casesRecyclerView.SetOnLoadMoreListener(new OnLoadMoreListener(base.ViewModel.LoadNextPage));
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				constraintLayout
			},
			{
				VisualState.Empty,
				constraintLayout2
			},
			{
				VisualState.Error,
				constraintLayout3
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
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				casesRecyclerView.HasNextPage = base.ViewModel.HasNextPage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasNextPage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatButton.OnClick(base.ViewModel.Retry)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.InfoCommand.SafeSubscribe(delegate
		{
			Show<CasesInfoFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.CaseDetailsCommand.SafeSubscribe(NavigateToCaseDetails, ViewLifecycleOwner);
	}

	protected override void OnRightButtonClick()
	{
		base.ViewModel.InfoCommand.Trigger();
	}

	private void BindCase(CachingViewHolder holder, CaseItemViewModel item, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131296701);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296702);
		TextView textView3 = holder.RequireCachedView<TextView>(2131296704);
		TextView textView4 = holder.RequireCachedView<TextView>(2131296700);
		textView.Text = item.NumberText;
		textView2.Text = item.StatusText;
		textView3.Text = item.TopicsText;
		textView4.Text = item.CreatedOnText;
		textView3.Visibility = ((!item.HasTopics) ? ViewStates.Gone : ViewStates.Visible);
		textView4.Visibility = ((!item.HasCreatedOn) ? ViewStates.Gone : ViewStates.Visible);
		textView2.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), item.Status.GetTextArgb())));
		textView2.BackgroundTintMode = PorterDuff.Mode.SrcIn;
		textView2.BackgroundTintList = ContextCompat.GetColorStateList(RequireContext(), item.Status.GetBackgroundArgb());
	}

	private void OnItemClick(CachingViewHolder holder, CaseItemViewModel item, int position)
	{
		if (!string.IsNullOrWhiteSpace(item.Id) && !string.IsNullOrWhiteSpace(item.Number))
		{
			base.ViewModel.CaseDetailsCommand.Trigger(new CaseDetailsViewModel.Parameter(item.Id, item.Number));
		}
	}

	private void NavigateToCaseDetails(CaseDetailsViewModel.Parameter parameter)
	{
		NavigateTo<CaseDetailsFragment, CaseDetailsViewModel.Parameter>(new CaseDetailsViewModel.Parameter(parameter.Id, parameter.Number));
	}
}
