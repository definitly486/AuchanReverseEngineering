using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.SwipeRefreshLayout.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Streams;
using Java.Interop;
using VisibilitySwitch;

namespace Auchan.Android.Streams;

internal class StreamListFragment : BaseToolbarFragment<StreamListViewModel>, SwipeRefreshLayout.IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
{
	private ListView _bannersList;

	protected override int LayoutId => 2131493104;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public StreamListFragment(Func<Fragment, StreamListViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToStreamCommand.SafeSubscribe(OpenStream, this);
		base.ViewModel.StreamItemViewModels.SafeSubscribeToCollectionChanged(delegate
		{
			SetupStreamList();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar supportActionBar = view.RequireViewById<Toolbar>(2131298669);
		SwipeRefreshLayout swipeRefreshLayout = view.RequireViewById<SwipeRefreshLayout>(2131298581);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		errorTitle.Text = base.ViewModel.ErrorTitle;
		errorMessage.Text = base.ViewModel.ErrorMessage;
		swipeRefreshLayout.SetColorSchemeResources(2131100555);
		swipeRefreshLayout.SetOnRefreshListener(this);
		_bannersList = swipeRefreshLayout.RequireViewById<ListView>(2131296515);
		(base.Activity as AppCompatActivity)?.SetSupportActionBar(supportActionBar);
		base.ToolbarTitle = base.ViewModel.Title;
		VisibilitySwitch<StreamListViewModel.VisualState> viewSwitch = new VisibilitySwitch<StreamListViewModel.VisualState>(base.ViewModel.State)
		{
			{
				StreamListViewModel.VisualState.Default,
				_bannersList
			},
			{
				StreamListViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				StreamListViewModel.VisualState.Error,
				constraintLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				swipeRefreshLayout.Refreshing = base.ViewModel.IsRefreshing;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsRefreshing")),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnRefresh), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetupStreamList()
	{
		StreamsListViewAdapter streamsListViewAdapter = new StreamsListViewAdapter(Context, base.ViewModel, ViewLifecycleOwner);
		_bannersList.Adapter = streamsListViewAdapter;
		streamsListViewAdapter.NotifyDataSetChanged();
	}

	private void OpenStream(StreamViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StreamFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	void SwipeRefreshLayout.IOnRefreshListener.OnRefresh()
	{
		base.ViewModel.OnRefresh();
	}
}
