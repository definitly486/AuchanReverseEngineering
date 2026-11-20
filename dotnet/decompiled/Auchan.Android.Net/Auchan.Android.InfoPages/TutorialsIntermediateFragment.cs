using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.Models;
using VisibilitySwitch;

namespace Auchan.Android.InfoPages;

internal class TutorialsIntermediateFragment : BaseToolbarFragment<TutorialsIntermediateViewModel>
{
	protected override int LayoutId => 2131493114;

	public TutorialsIntermediateFragment(Func<Fragment, TutorialsIntermediateViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		ObservableRecyclerAdapter<Tutorial, CachingViewHolder> adapter = new ObservableRecyclerAdapter<Tutorial, CachingViewHolder>
		{
			CellLayoutId = 2131493358,
			DataSource = base.ViewModel.TutorialModels,
			BindViewHolderDelegate = OnBindItem
		};
		recyclerView.SetAdapter(adapter);
		textView.Text = base.ViewModel.ScreenTitle;
		button.Text = base.ViewModel.ErrorButtonText;
		VisibilitySwitch<TutorialsIntermediateViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<TutorialsIntermediateViewModel.VisualState>(TutorialsIntermediateViewModel.VisualState.Default)
		{
			TutorialsIntermediateViewModel.VisualState.Default,
			{
				TutorialsIntermediateViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				TutorialsIntermediateViewModel.VisualState.Error,
				constraintLayout
			}
		};
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
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnRetryClick), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateNextCommand.ObserveOn(MainThread.Scheduler).Subscribe(NavigateToTutorial).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void OnBindItem(CachingViewHolder holder, Tutorial model, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131298646);
		View view = holder.RequireCachedView<View>(2131297006);
		textView.Text = model.Title;
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.NavigateNextClick(model);
		}).AddTo(disposable);
		ObservableRangeCollection<Tutorial> tutorialModels = base.ViewModel.TutorialModels;
		view.Visibility = ((position == ((tutorialModels != null) ? new int?(tutorialModels.Count - 1) : ((int?)null))) ? ViewStates.Gone : ViewStates.Visible);
	}

	private void NavigateToTutorial(TutorialViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<TutorialFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}
}
