using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Profile.Stores;
using Com.Yandex.Mapkit;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.Map;
using Com.Yandex.Runtime.Ui_view;
using Google.Android.Material.AppBar;
using Google.Android.Material.Button;
using Microsoft.Maui.Devices.Sensors;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoreDetailsFragment : BaseToolbarFragment<StoreDetailsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	private NavigationCellViewStores _publicTransportCell;

	private CustomMapView _mapView;

	private TextView _descriptionTextView;

	private bool _isMapStarted;

	protected override int LayoutId => 2131493100;

	public StoreDetailsFragment(Func<StoreDetailsViewModel.Parameter, StoreDetailsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, StoreDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<StoreDetailsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
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
		BaseConfigure(view);
		BindProperties(view);
		ConfigureReactive();
		ConfigureAdapter(view);
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

	private void ConfigureAdapter(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298511);
		ObservableRecyclerAdapter<StoreDetailsServicesItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<StoreDetailsServicesItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493344,
			DataSource = base.ViewModel.Services,
			BindViewHolderDelegate = OnBindService
		};
		recyclerView.SetAdapter(adapter);
	}

	private void BaseConfigure(View view)
	{
		Toolbar supportActionBar = view.RequireViewById<Toolbar>(2131298669);
		CoordinatorLayout coordinatorLayout = view.RequireViewById<CoordinatorLayout>(2131296904);
		AppBarLayout appBarLayout = coordinatorLayout.RequireViewById<AppBarLayout>(2131296451);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		(base.Activity as AppCompatActivity)?.SetSupportActionBar(supportActionBar);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		button.Text = base.ViewModel.ErrorButtonText;
		_publicTransportCell = coordinatorLayout.RequireViewById<NavigationCellViewStores>(2131298508);
		LinearLayout linearLayout = coordinatorLayout.RequireViewById<LinearLayout>(2131298498);
		LinearLayout linearLayout2 = coordinatorLayout.RequireViewById<LinearLayout>(2131298501);
		_mapView = coordinatorLayout.RequireViewById<CustomMapView>(2131298504);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296581);
		TextView textView = view.RequireViewById<TextView>(2131298507);
		materialButton.Text = base.ViewModel.BuildRouteLabel;
		VisibilitySwitch<StoreDetailsViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<StoreDetailsViewModel.VisualState>(StoreDetailsViewModel.VisualState.InProgress)
		{
			{
				StoreDetailsViewModel.VisualState.Default,
				coordinatorLayout
			},
			{
				StoreDetailsViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				StoreDetailsViewModel.VisualState.Error,
				constraintLayout
			}
		};
		appBarLayout.AddOnOffsetChangedListener(new AppBarStateChangeListener(OnStateChanged));
		OnStateChanged(AppBarStateChangeListener.State.Expanded);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHint"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)button).OnClick((Action)delegate
		{
			base.ViewModel.LoadStore().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), linearLayout.OnClick(base.ViewModel.OpenPopupServices), linearLayout2.OnClick(base.ViewModel.OpenDescriptionDetails), textView.OnClick(base.ViewModel.MakeCall), materialButton.OnClick(base.ViewModel.BuildRoute), _publicTransportCell.OnClick(base.ViewModel.NavigateToPublicTransport)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void BindProperties(View view)
	{
		TextView nameTextView = view.RequireViewById<TextView>(2131298506);
		TextView typeTextView = view.RequireViewById<TextView>(2131298512);
		TextView distanceTextView = view.RequireViewById<TextView>(2131298492);
		TextView parkingTextView = view.RequireViewById<TextView>(2131298495);
		ImageView distanceIcon = view.RequireViewById<ImageView>(2131298493);
		ImageView parkingIcon = view.RequireViewById<ImageView>(2131298496);
		view.RequireViewById<LinearLayout>(2131298494);
		TextView addressTextView = view.RequireViewById<TextView>(2131298497);
		TextView phoneTextView = view.RequireViewById<TextView>(2131298507);
		TextView serviceLabel = view.RequireViewById<TextView>(2131298510);
		TextView textView = view.RequireViewById<TextView>(2131298499);
		TextView textView2 = view.RequireViewById<TextView>(2131298503);
		_descriptionTextView = view.RequireViewById<TextView>(2131298500);
		TextView textView3 = view.RequireViewById<TextView>(2131298502);
		TextView scheduleTextView = view.RequireViewById<TextView>(2131298529);
		ImageView scheduleImageView = view.RequireViewById<ImageView>(2131298530);
		TempWorkTimeView tempWorkTimeLayout = view.RequireViewById<TempWorkTimeView>(2131298600);
		TextView workingStatusTitle = view.RequireViewById<TextView>(2131298842);
		TextView workingStatusDot = view.RequireViewById<TextView>(2131298840);
		TextView workingStatusDescription = view.RequireViewById<TextView>(2131298839);
		TempWorkInformerView tempWorkInformer = view.RequireViewById<TempWorkInformerView>(2131298601);
		textView.Text = base.ViewModel.AllServicesLabel;
		textView2.Text = base.ViewModel.DescriptionLabel;
		textView3.Text = base.ViewModel.DescriptionMoreText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[23]
		{
			(delegate
			{
				nameTextView.Text = base.ViewModel.NameText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NameText")),
			(delegate
			{
				typeTextView.Text = base.ViewModel.StoreTypeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StoreTypeText")),
			(delegate
			{
				addressTextView.Text = base.ViewModel.AddressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressText")),
			(delegate
			{
				phoneTextView.Text = base.ViewModel.Phone;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Phone")),
			(delegate
			{
				phoneTextView.Visibility = (!string.IsNullOrEmpty(base.ViewModel.Phone)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Phone")),
			(delegate
			{
				distanceTextView.Text = base.ViewModel.DistanceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DistanceText")),
			(delegate
			{
				TextView textView4 = distanceTextView;
				ViewStates visibility = (distanceIcon.Visibility = (!string.IsNullOrEmpty(base.ViewModel.DistanceText)).ToVisibility());
				textView4.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DistanceText")),
			(delegate
			{
				parkingTextView.Text = base.ViewModel.ParkingLotsText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ParkingLotsText")),
			(delegate
			{
				TextView textView4 = parkingTextView;
				ViewStates visibility = (parkingIcon.Visibility = (!string.IsNullOrEmpty(base.ViewModel.ParkingLotsText)).ToVisibility());
				textView4.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ParkingLotsText")),
			(delegate
			{
				ImageView imageView = scheduleImageView;
				ViewStates visibility = (scheduleTextView.Visibility = base.ViewModel.IsScheduleExist.ToVisibility());
				imageView.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsScheduleExist")),
			(delegate
			{
				scheduleTextView.Text = base.ViewModel.ScheduleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ScheduleText")),
			(delegate
			{
				TempWorkTimeView tempWorkTimeView = tempWorkTimeLayout;
				ViewStates visibility = (tempWorkInformer.Visibility = (base.ViewModel.Store.TempWorkHours.Count > 0).ToVisibility());
				tempWorkTimeView.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Store")),
			(delegate
			{
				tempWorkTimeLayout.Setup(base.ViewModel.Store, base.ViewModel.TempWorkTitle);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Store")),
			(delegate
			{
				tempWorkInformer.ContentTextView.Text = base.ViewModel.Store.TempWorkDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Store")),
			(delegate
			{
				workingStatusTitle.SetTextColor(new Color(ContextCompat.GetColor(Context, base.ViewModel.IsOpen ? 2131099854 : 2131100476)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOpen")),
			(delegate
			{
				workingStatusTitle.Text = base.ViewModel.OpenStatusText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OpenStatusText")),
			(delegate
			{
				workingStatusDescription.Text = base.ViewModel.OpenStatusDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OpenStatusDescription")),
			(delegate
			{
				TextView textView4 = workingStatusDescription;
				ViewStates visibility = (workingStatusDot.Visibility = (!string.IsNullOrEmpty(base.ViewModel.OpenStatusDescription)).ToVisibility());
				textView4.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OpenStatusDescription")),
			(delegate
			{
				serviceLabel.Text = base.ViewModel.ServicesLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ServicesLabel")),
			(delegate
			{
				_publicTransportCell.Visibility = base.ViewModel.IsPublicTransportExist.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPublicTransportExist")),
			(delegate
			{
				SetPointToMap(base.ViewModel.StoreLocation);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StoreLocation")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.NameText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NameText")),
			(delegate
			{
				SetupExpandableDescription(base.ViewModel.DescriptionText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DescriptionText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public void SetupExpandableDescription(string description)
	{
		_descriptionTextView.Text = description;
	}

	private void OnStateChanged(AppBarStateChangeListener.State state)
	{
		if (base.ToolbarTitleLabel != null)
		{
			base.ToolbarTitleLabel.Visibility = ((state != AppBarStateChangeListener.State.Collapsed) ? ViewStates.Gone : ViewStates.Visible);
		}
	}

	private void SetPointToMap(Location storeLocation)
	{
		if (!(storeLocation == null))
		{
			View view = new View(Context)
			{
				Background = Context.GetDrawable(2131231281)
			};
			Com.Yandex.Mapkit.Geometry.Point point = new Com.Yandex.Mapkit.Geometry.Point(storeLocation.Latitude, storeLocation.Longitude);
			_mapView.Map.MapObjects.AddPlacemark(point, new ViewProvider(view));
			_mapView.Map.Move(new CameraPosition(point, base.ViewModel.MapZoom, base.ViewModel.Azimuth, base.ViewModel.Tilt), new Animation(Animation.Type.Smooth, 0f), null);
		}
	}

	private void ConfigureReactive()
	{
		base.ViewModel.OpenPopupServicesCommand.SafeSubscribe(OpenPopupServices, ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			OnNavigationButtonClick();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenTextDetailsCommand.SafeSubscribe(OnPublicTransportClick, ViewLifecycleOwner);
		base.ViewModel.BuildRouteCommand.SafeSubscribe(delegate(Location location)
		{
			BuildRoute(location.Latitude, location.Longitude);
		}, ViewLifecycleOwner);
	}

	private void OnBindService(CachingViewHolder viewHolder, StoreDetailsServicesItemViewModel item, int position, CompositeDisposable disposable)
	{
		viewHolder.FindCachedView<TextView>(2131297443).Text = item.NameText;
	}

	private void OpenPopupServices(StoreDetailsServicesViewModel.Parameter parameter)
	{
		StoreDetailsServicesBottomSheet storeDetailsServicesBottomSheet = _fragmentFactory.Instantiate<StoreDetailsServicesBottomSheet>();
		storeDetailsServicesBottomSheet.Arguments = parameter.ToNavBundle();
		storeDetailsServicesBottomSheet.SetTargetFragment(this, 0);
		storeDetailsServicesBottomSheet.Show(base.ParentFragmentManager, null);
	}

	private void OnPublicTransportClick(TextDetailsViewModel.Parameter parameter)
	{
		Show<TextDetailsBottomSheet, TextDetailsViewModel.Parameter>(parameter);
	}

	private void BuildRoute(double latitude, double longitude)
	{
		RequireContext().StartActivity(Intent.CreateChooser(IntentHelper.GetBuildRouteIntent(latitude, longitude), base.ViewModel.ExternalAppChooseText));
	}
}
