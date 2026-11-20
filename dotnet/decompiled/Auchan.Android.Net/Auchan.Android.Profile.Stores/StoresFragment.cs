using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Stores;
using Auchan.Common.Profile.Stores.Enums;
using Com.Yandex.Mapkit;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.Map;
using Com.Yandex.Mapkit.Mapview;
using Com.Yandex.Runtime.Ui_view;
using Google.Android.Material.Button;
using Java.Interop;
using Microsoft.Maui.Devices.Sensors;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoresFragment : BaseToolbarFragment<StoresViewModel>, IMapObjectTapListener, IJavaObject, IDisposable, IJavaPeerable
{
	private enum StoreCellType
	{
		Informer,
		Store
	}

	private ImageView _filterImage;

	private MapView _mapView;

	private readonly FragmentFactory _fragmentFactory;

	private bool _isMapStarted;

	protected override int LayoutId => 2131493101;

	public StoresFragment(Func<Fragment, StoresViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override bool HasRightButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (!MainActivity.MapKitInitialized)
		{
			MainActivity.MapKitInitialized = true;
			MapKitFactory.SetApiKey(base.ViewModel.YandexMapKey);
			MapKitFactory.Initialize(RequireActivity());
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131298535);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297081);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		SearchView searchView = linearLayout.RequireViewById<SearchView>(2131298322);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout2.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout2.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout2.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout2.RequireViewById<Button>(2131298371);
		button.Text = base.ViewModel.ErrorButtonText;
		textView.Text = base.ViewModel.ProgressTitle;
		searchView.QueryHint = base.ViewModel.SearchQueryHint;
		_filterImage = view.RequireViewById<ImageView>(2131298249);
		VisibilitySwitch<StoresViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<StoresViewModel.VisualState>(StoresViewModel.VisualState.InProgress)
		{
			{
				StoresViewModel.VisualState.Default,
				linearLayout
			},
			{
				StoresViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				StoresViewModel.VisualState.Error,
				constraintLayout2
			},
			{
				StoresViewModel.VisualState.Empty,
				constraintLayout
			}
		};
		SetUI(view);
		ConfigureTabs(linearLayout);
		ConfigureStoresList(linearLayout);
		ConfigureReactive();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHint")),
			(delegate
			{
				_filterImage.Visibility = base.ViewModel.IsFilterButtonActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFilterButtonActive")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_filterImage.OnClick(base.ViewModel.OpenFilter), button.OnClick(base.ViewModel.Retry), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		searchView.SetOnClickListener(new ViewOnClickListener((Action<View>)delegate
		{
			OnOpenSearch();
		}));
		base.ViewModel.RestoreFilterIcon();
	}

	public override void OnStart()
	{
		base.OnStart();
		StartMapIfNeeded();
	}

	public override void OnStop()
	{
		base.OnStop();
		StopMapIfNeeded();
	}

	public bool OnMapObjectTap(IMapObject p0, Com.Yandex.Mapkit.Geometry.Point p1)
	{
		base.ViewModel.OpenMiniStore((int)p0.UserData).SafeFireAndForget((Action<Exception>)null, false);
		return true;
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (hidden)
		{
			StopMapIfNeeded();
		}
		else if (Lifecycle.CurrentState.IsAtLeast(AndroidX.Lifecycle.Lifecycle.State.Started))
		{
			StartMapIfNeeded();
		}
	}

	private void StartMapIfNeeded()
	{
		if (!_isMapStarted && _mapView != null)
		{
			_mapView.OnStart();
			MapKitFactory.Instance.OnStart();
			_isMapStarted = true;
		}
	}

	private void StopMapIfNeeded()
	{
		if (_isMapStarted && _mapView != null)
		{
			_mapView.OnStop();
			MapKitFactory.Instance.OnStop();
			_isMapStarted = false;
		}
	}

	private void ConfigureReactive()
	{
		base.ViewModel.NavigateNextCommand.SafeSubscribe(OnNavigateNext, ViewLifecycleOwner);
		base.ViewModel.OpenFilterCommand.SafeSubscribe(OpenFilter, ViewLifecycleOwner);
		base.ViewModel.OnChangeFilterIcon.SafeSubscribe(ChangeFilterIcon, ViewLifecycleOwner);
		base.ViewModel.OnOpenMiniStore.SafeSubscribe(OpenStoreDetailsMini, ViewLifecycleOwner);
	}

	private void ChangeFilterIcon(bool isApplied)
	{
		if (_filterImage != null)
		{
			_filterImage.SetImageResource(isApplied ? 2131231175 : 2131231174);
		}
	}

	private void ConfigureStoresList(View view)
	{
		RecyclerView storesRecyclerView = view.RequireViewById<RecyclerView>(2131298534);
		ObservableRecyclerAdapter<StoresItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<StoresItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = delegate(int index)
			{
				StoresItemViewModel storesItemViewModel = base.ViewModel.Stores[index];
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
			DataSource = base.ViewModel.Stores,
			BindViewHolderDelegate = OnBindStore,
			ClickCallback = OnItemClick
		};
		storesRecyclerView.SetAdapter(adapter);
		_mapView = view.RequireViewById<MapView>(2131298536);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				storesRecyclerView.Visibility = (base.ViewModel.ContentState == StoresContentState.List).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ContentState")),
			(delegate
			{
				_mapView.Visibility = (base.ViewModel.ContentState == StoresContentState.Map).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ContentState"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnMapUpdate.SafeSubscribe(UpdateMap, ViewLifecycleOwner);
		RxTaskExtensions.StartWithDefault(base.ViewModel.Stores.CollectionChangedAsObservable()).SafeSubscribe(delegate
		{
			storesRecyclerView.ScrollToPosition(0);
		}, ViewLifecycleOwner);
	}

	private void UpdateMap(Location moveTo)
	{
		_mapView.Map.MapObjects.Clear();
		ViewProvider p = new ViewProvider(new View(Context)
		{
			Background = Context.GetDrawable(2131231236)
		});
		_mapView.Map.Move(new CameraPosition(new Com.Yandex.Mapkit.Geometry.Point(moveTo.Latitude, moveTo.Longitude), base.ViewModel.MapZoom, base.ViewModel.Azimuth, base.ViewModel.Tilt), new Animation(Animation.Type.Smooth, 0f), null);
		foreach (StoresItemViewModel store in base.ViewModel.Stores)
		{
			IPlacemarkMapObject placemarkMapObject = _mapView.Map.MapObjects.AddPlacemark(new Com.Yandex.Mapkit.Geometry.Point(store.Latitude, store.Longitude), p);
			placemarkMapObject.UserData = store.Id;
			placemarkMapObject.AddTapListener(this);
		}
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
		item.BuildRouteCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate(Location location)
		{
			BuildRoute(location, item.ExternalAppChooseText);
		}).AddTo(disposable);
	}

	private void BuildRoute(Location location, string title)
	{
		RequireContext().StartActivity(Intent.CreateChooser(IntentHelper.GetBuildRouteIntent(location.Latitude, location.Longitude), title));
	}

	private void ConfigureTabs(View view)
	{
		MaterialButton listButton = view.RequireViewById<MaterialButton>(2131298537);
		MaterialButton mapButton = view.RequireViewById<MaterialButton>(2131298538);
		listButton.Text = base.ViewModel.ListButtonText;
		mapButton.Text = base.ViewModel.MapButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				listButton.ForceChecked(base.ViewModel.ContentState == StoresContentState.List);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ContentState")),
			(delegate
			{
				mapButton.ForceChecked(base.ViewModel.ContentState == StoresContentState.Map);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ContentState"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(listButton.OnClick(base.ViewModel.TabListClick), mapButton.OnClick(base.ViewModel.TabMapClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetUI(View view)
	{
		TextView textView = view.RequireViewById<TextView>(2131298679);
		TextView textView2 = view.RequireViewById<TextView>(2131297071);
		view.RequireViewById<TextView>(2131297083).Text = base.ViewModel.EmptyTitleText;
		textView2.Text = base.ViewModel.EmptyHintText;
		textView.Text = base.ViewModel.Title;
	}

	private void OnItemClick(CachingViewHolder vh, StoresItemViewModel vm, int pos)
	{
		base.ViewModel.NavigateToDetails(vm);
	}

	private void OnNavigateNext(StoreDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StoreDetailsFragment>(base.ParentFragment, parameter.ToNavBundle(), null, 2131297216)
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenFilter(StoresFilterViewModel storesFilterViewModel)
	{
		StoresFilterFragment storesFilterFragment = new StoresFilterFragment((Fragment _) => storesFilterViewModel);
		storesFilterFragment.SetTargetFragment(this, 0);
		storesFilterFragment.Show(base.ParentFragmentManager, null);
	}

	private void OnOpenSearch()
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StoresSearchFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenStoreDetailsMini(StoreDetailsMiniViewModel.Parameter parameter)
	{
		PopupStoreDetailsMini popupStoreDetailsMini = _fragmentFactory.Instantiate<PopupStoreDetailsMini>();
		popupStoreDetailsMini.Arguments = parameter.ToNavBundle();
		popupStoreDetailsMini.Show(base.ChildFragmentManager, null);
	}
}
