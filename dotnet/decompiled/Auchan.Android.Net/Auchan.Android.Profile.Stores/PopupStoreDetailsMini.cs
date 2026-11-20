using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Common.Base;
using Auchan.Common.Profile.Stores;
using Google.Android.Material.Button;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Android.Profile.Stores;

internal sealed class PopupStoreDetailsMini : BaseBottomSheetDialogFragment<StoreDetailsMiniViewModel>
{
	protected override int LayoutId => 2131493497;

	public override int Theme => 2131951914;

	public PopupStoreDetailsMini(Func<StoreDetailsMiniViewModel.Parameter, StoreDetailsMiniViewModel> newViewModel)
		: base((Func<Fragment, StoreDetailsMiniViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<StoreDetailsMiniViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131297266);
		TextView textView3 = view.RequireViewById<TextView>(2131298523);
		TextView textView4 = view.RequireViewById<TextView>(2131298529);
		ImageView imageView = view.RequireViewById<ImageView>(2131298530);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131298527);
		TextView textView5 = linearLayout.RequireViewById<TextView>(2131298526);
		LinearLayout linearLayout2 = view.RequireViewById<LinearLayout>(2131298525);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298505);
		if (base.ViewModel.IsDistanceExist)
		{
			linearLayout.Visibility = ViewStates.Visible;
			textView5.Text = base.ViewModel.DistanceText;
		}
		if (!base.ViewModel.IsScheduleExist)
		{
			imageView.Visibility = ViewStates.Invisible;
		}
		textView2.Text = base.ViewModel.NameText;
		textView3.Text = base.ViewModel.AddressText;
		textView4.Text = base.ViewModel.ScheduleText;
		materialButton.Text = base.ViewModel.MoreButtonText;
		textView.Text = base.ViewModel.CloseButtonText;
		base.ViewModel.BindEvents(textView.OnClick(Dismiss), linearLayout2.OnClick(base.ViewModel.BuildRoute), materialButton.OnClick(base.ViewModel.OpenStoreDetails)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BuildRouteCommand.SafeSubscribe(delegate(Location location)
		{
			BuildRoute(location.Latitude, location.Longitude);
		}, ViewLifecycleOwner);
		base.ViewModel.OnNavigateStoreDetails.SafeSubscribe(OnNavigateStoreDetails, ViewLifecycleOwner);
	}

	private void OnNavigateStoreDetails(StoreDetailsViewModel.Parameter parameter)
	{
		Fragment fragment = RequireParentFragment();
		fragment.ParentFragmentManager.BeginTransaction().Hide(fragment).Add<StoreDetailsFragment>(fragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		Dismiss();
	}

	private void BuildRoute(double latitude, double longitude)
	{
		RequireContext().StartActivity(Intent.CreateChooser(IntentHelper.GetBuildRouteIntent(latitude, longitude), base.ViewModel.ExternalAppChooseText));
	}
}
