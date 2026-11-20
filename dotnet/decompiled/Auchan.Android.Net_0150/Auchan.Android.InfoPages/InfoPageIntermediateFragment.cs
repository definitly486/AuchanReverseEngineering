using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
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

internal class InfoPageIntermediateFragment : BaseToolbarFragment<InfoPageIntermediateViewModel>
{
	protected override int LayoutId => 2131493034;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public InfoPageIntermediateFragment(Func<InfoPageIntermediateViewModel.Parameter, InfoPageIntermediateViewModel> newViewModel)
		: base((Func<Fragment, InfoPageIntermediateViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<InfoPageIntermediateViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateNextCommand.SafeSubscribe(NavigateNext, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		VisibilitySwitch<InfoPageIntermediateViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<InfoPageIntermediateViewModel.VisualState>(base.ViewModel.State)
		{
			{
				InfoPageIntermediateViewModel.VisualState.Default,
				linearLayout
			},
			{
				InfoPageIntermediateViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				InfoPageIntermediateViewModel.VisualState.Error,
				constraintLayout
			}
		};
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		button.Text = base.ViewModel.ErrorButtonText;
		RecyclerView recyclerView = linearLayout.RequireViewById<RecyclerView>(2131297353);
		ObservableRecyclerAdapter<InfoPageIntermediateModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<InfoPageIntermediateModel, CachingViewHolder>
		{
			CellLayoutId = 2131493252,
			DataSource = base.ViewModel.InfoTypeModels,
			BindViewHolderDelegate = OnBindItem
		};
		recyclerView.SetAdapter(adapter);
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
	}

	private void OnBindItem(CachingViewHolder holder, InfoPageIntermediateModel model, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297352);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297351);
		View view = holder.RequireCachedView<View>(2131297006);
		textView.Text = model.Title;
		imageView.FromUrl(model.IconUrl);
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.NavigateNextClick(model.Slug);
		}).AddTo(disposable);
		view.Visibility = ((base.ViewModel.InfoTypeModels.Count - 1 == position) ? ViewStates.Gone : ViewStates.Visible);
	}

	private void NavigateNext(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}
}
