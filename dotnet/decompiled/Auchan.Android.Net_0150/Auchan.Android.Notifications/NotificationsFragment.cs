using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Disposables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Notifications;
using Java.Interop;
using VisibilitySwitch;

namespace Auchan.Android.Notifications;

internal class NotificationsFragment : BaseToolbarFragment<NotificationsViewModel>, SwipeRefreshLayout.IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
{
	private SwipeRefreshLayout _swipeRefreshLayout;

	protected override int LayoutId => 2131493068;

	public NotificationsFragment(Func<Fragment, NotificationsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		SwipeRefreshLayout swipeRefreshLayout = view.RequireViewById<SwipeRefreshLayout>(2131297713);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297708);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131297711);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297710);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131297709);
		TextView errorMessage = constraintLayout2.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout2.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout2.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout2.RequireViewById<Button>(2131298371);
		RecyclerView recyclerView = swipeRefreshLayout.RequireViewById<RecyclerView>(2131297712);
		TextView textView2 = view.RequireViewById<TextView>(2131298679);
		_swipeRefreshLayout = swipeRefreshLayout;
		_swipeRefreshLayout.SetOnRefreshListener(this);
		_swipeRefreshLayout.SetColorSchemeResources(2131100555);
		textView2.Text = base.ViewModel.Title;
		textView.Text = base.ViewModel.EmptyTitleText;
		button.Text = base.ViewModel.ErrorRetryButtonText;
		ConfigureRecyclerView(recyclerView);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				swipeRefreshLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout2
			},
			{
				VisualState.Empty,
				constraintLayout
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
				_swipeRefreshLayout.Refreshing = base.ViewModel.IsRefreshing;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsRefreshing")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitleText")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHintText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHintText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnRetryClick), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void ConfigureRecyclerView(RecyclerView recyclerView)
	{
		recyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		ObservableRecyclerAdapter<NotificationItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<NotificationItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = (ViewGroup parent, int layoutId) => new NotificationItemViewHolder(base.LayoutInflater.Inflate(layoutId, parent, attachToRoot: false)),
			GetItemViewTypeDelegate = (int _) => 2131493263,
			BindViewHolderDelegate = delegate(CachingViewHolder holder, NotificationItemViewModel item, int _, CompositeDisposable _)
			{
				if (holder is NotificationItemViewHolder notificationItemViewHolder)
				{
					notificationItemViewHolder.Bind(item);
				}
			},
			ClickCallback = delegate(CachingViewHolder _, NotificationItemViewModel item, int _)
			{
				base.ViewModel.OnItemClicked(item);
			}
		};
		recyclerView.SetAdapter(adapter);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			adapter.DataSource = new List<NotificationItemViewModel>(base.ViewModel.Items);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Items")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		((INotifyCollectionChanged)base.ViewModel.Items).OnCollectionChanged((Action)delegate
		{
			adapter.DataSource = new List<NotificationItemViewModel>(base.ViewModel.Items);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public void OnRefresh()
	{
		base.ViewModel.Refresh().SafeFireAndForget((Action<Exception>)null, false);
	}
}
