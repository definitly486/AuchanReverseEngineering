using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Stores;
using Google.Android.Material.Button;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoresSearchFragment : BaseToolbarFragment<StoresSearchViewModel>
{
	private enum StoreCellType
	{
		Informer,
		Store
	}

	private CustomSearchView _searchView;

	protected override int LayoutId => 2131493093;

	public ObservableRecyclerAdapter<StoresItemViewModel, CachingViewHolder> StoresAdapter { get; set; }

	public StoresSearchFragment(Func<Fragment, StoresSearchViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override int GetNavigationButtonId()
	{
		return 2131296613;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_searchView = view.RequireViewById<CustomSearchView>(2131298322);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297218);
		View view2 = view.RequireViewById<View>(2131297081);
		View view3 = view.RequireViewById<View>(2131298087);
		TextView textView = view2.RequireViewById<TextView>(2131297083);
		TextView textView2 = view2.RequireViewById<TextView>(2131297071);
		_searchView.RequireViewById<ImageView>(2131298315).SetImageResource(2131231122);
		_searchView.IsSearchIconVisible = base.ViewModel.IsSearchIconVisible;
		StoresAdapter = new ObservableRecyclerAdapter<StoresItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = delegate(int index)
			{
				StoresItemViewModel storesItemViewModel = base.ViewModel.SearchProductResults[index];
				return (storesItemViewModel == null || !storesItemViewModel.IsTempWorkInformerModel) ? 1 : 0;
			},
			CreateViewHolderDelegate = delegate(ViewGroup layout, int cellType)
			{
				CachingViewHolder cachingViewHolder = ((cellType != 1) ? new CachingViewHolder(base.LayoutInflater.Inflate(2131493348, layout, attachToRoot: false)) : new CachingViewHolder(base.LayoutInflater.Inflate(2131493349, layout, attachToRoot: false)));
				ViewGroup.LayoutParams layoutParameters = cachingViewHolder.ItemView.LayoutParameters;
				layoutParameters.Width = -1;
				layoutParameters.Height = -2;
				cachingViewHolder.ItemView.LayoutParameters = layoutParameters;
				return cachingViewHolder;
			},
			DataSource = base.ViewModel.SearchProductResults,
			BindViewHolderDelegate = OnBindStore,
			ClickCallback = OnItemClick
		};
		recyclerView.SetAdapter(StoresAdapter);
		textView.Text = base.ViewModel.EmptySearchTitle;
		textView2.Text = base.ViewModel.EmptySearchSubtitle;
		_searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		_searchView.SetQuery(base.ViewModel.SearchQuery, submit: false);
		_searchView.RequireViewById<EditText>(2131298321).SetFilters(new IInputFilter[2]
		{
			new InputFilterLengthFilter(base.ViewModel.MaxQueryLength),
			new SearchSpaceInputFilter()
		});
		VisibilitySwitch<StoresSearchViewModel.SearchVisualState> viewSwitch = new VisibilitySwitch<StoresSearchViewModel.SearchVisualState>(base.ViewModel.SearchState)
		{
			{
				StoresSearchViewModel.SearchVisualState.Content,
				recyclerView
			},
			{
				StoresSearchViewModel.SearchVisualState.InProgress,
				view3
			},
			{
				StoresSearchViewModel.SearchVisualState.NotFound,
				view2
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				StoresAdapter.DataSource = base.ViewModel.SearchProductResults;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchProductResults")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.SearchState);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchState")),
			(delegate
			{
				_searchView.IsSearchIconVisible = base.ViewModel.IsSearchIconVisible;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSearchIconVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((SearchView)_searchView).OnQueryTextChange((EventHandler<SearchView.QueryTextChangeEventArgs>)delegate
		{
			base.ViewModel.SearchQuery = _searchView.Query;
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateNextCommand.SafeSubscribe(OnNavigateNext, ViewLifecycleOwner);
		FocusSearch();
		Task.Run(async delegate
		{
			await Task.Delay(1000);
			Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(delegate
			{
				base.Activity.Window.HideKeyboardOnTouchOutside(_searchView, ViewLifecycleOwner);
			});
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			FocusSearch();
		}
	}

	public override void OnPause()
	{
		base.OnPause();
		_searchView.HideKeyboard(_searchView.Context);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (!hidden)
		{
			FocusSearch();
		}
	}

	private void FocusSearch()
	{
		_searchView.RequestFocus();
		_searchView.ShowKeyboard(_searchView.Context);
	}

	private void OnBindStore(CachingViewHolder viewHolder, StoresItemViewModel item, int position, CompositeDisposable disposable)
	{
		if (item.IsTempWorkInformerModel)
		{
			viewHolder.FindCachedView<TextView>(2131298602).Text = item.TempWorkDescription;
			return;
		}
		TextView? textView = viewHolder.FindCachedView<TextView>(2131298528);
		TextView textView2 = viewHolder.FindCachedView<TextView>(2131298523);
		TextView textView3 = viewHolder.FindCachedView<TextView>(2131298529);
		ImageView? imageView = viewHolder.FindCachedView<ImageView>(2131298530);
		LinearLayout linearLayout = viewHolder.FindCachedView<LinearLayout>(2131298527);
		TextView textView4 = viewHolder.FindCachedView<TextView>(2131298526);
		TempWorkTimeView? tempWorkTimeView = viewHolder.FindCachedView<TempWorkTimeView>(2131298600);
		TextView? textView5 = viewHolder.FindCachedView<TextView>(2131298842);
		TextView textView6 = viewHolder.FindCachedView<TextView>(2131298840);
		TextView textView7 = viewHolder.FindCachedView<TextView>(2131298839);
		MaterialButton materialButton = viewHolder.FindCachedView<MaterialButton>(2131296581);
		textView5.SetTextColor(new Color(ContextCompat.GetColor(Context, item.IsOpen ? 2131099854 : 2131100476)));
		textView5.Text = item.OpenStatusText;
		textView7.Text = item.OpenStatusDescription;
		ViewStates visibility = (textView6.Visibility = (string.IsNullOrEmpty(item.OpenStatusDescription) ? ViewStates.Gone : ViewStates.Visible));
		textView7.Visibility = visibility;
		tempWorkTimeView.Setup(item.FullStoreModel, item.TempWorkTitle);
		tempWorkTimeView.Visibility = ((item.FullStoreModel.TempWorkHours.Count <= 0) ? ViewStates.Gone : ViewStates.Visible);
		if (base.ViewModel.GotLocation && item.DistanceExists)
		{
			linearLayout.Visibility = ViewStates.Visible;
			textView4.Text = item.DistanceText;
		}
		else
		{
			linearLayout.Visibility = ViewStates.Gone;
		}
		visibility = (textView3.Visibility = item.IsScheduleExist.ToVisibility());
		imageView.Visibility = visibility;
		textView.Text = item.NameText;
		textView2.Text = item.AddressText;
		textView3.Text = item.ScheduleText;
		materialButton.Text = item.BuildRouteText;
		item.BindEvents(materialButton.OnClick(item.BuildRoute)).AddTo(disposable);
		item.BuildRouteCommand.ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).Subscribe(delegate(Location location)
		{
			BuildRoute(location, item.ExternalAppChooseText);
		}).AddTo(disposable);
	}

	private void OnItemClick(CachingViewHolder vh, StoresItemViewModel vm, int pos)
	{
		base.ViewModel.NavigateToDetails(vm);
	}

	private void OnNavigateNext(StoreDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StoreDetailsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void BuildRoute(Location location, string title)
	{
		RequireContext().StartActivity(Intent.CreateChooser(IntentHelper.GetBuildRouteIntent(location.Latitude, location.Longitude), title));
	}
}
