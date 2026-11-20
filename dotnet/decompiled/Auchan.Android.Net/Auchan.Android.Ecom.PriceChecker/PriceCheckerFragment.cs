using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Controls;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.Products.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Ecom.PriceChecker;

[Register("auchan.Android.Ecom.PriceCheckerFragment")]
internal class PriceCheckerFragment : BaseScannerFragment<PriceCheckerViewModel>
{
	protected override int LayoutId => 2131493080;

	public PriceCheckerFragment(PriceCheckerViewModel newViewModel)
		: base((Func<Fragment, PriceCheckerViewModel>)((Fragment thisFragment) => newViewModel))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		CoordinatorLayout cameraLayout = view.RequireViewById<CoordinatorLayout>(2131296610);
		ImageView imageView = cameraLayout.RequireViewById<ImageView>(2131297267);
		FrameLayout progressLayout = view.RequireViewById<FrameLayout>(2131298079);
		ImageView flashButton = cameraLayout.RequireViewById<ImageView>(2131297192);
		Button enterButton = cameraLayout.RequireViewById<Button>(2131297095);
		TextView textView = cameraLayout.RequireViewById<TextView>(2131297355);
		SnackView warningView = cameraLayout.RequireViewById<SnackView>(2131298821);
		flashButton.SetImageResource(2131231021);
		textView.Text = base.ViewModel.ScanPromptText;
		warningView.Visibility = ViewStates.Gone;
		warningView.Text = base.ViewModel.ScanErrorText;
		ConstraintLayout noCameraLayout = view.RequireViewById<ConstraintLayout>(2131297675);
		ImageView imageView2 = noCameraLayout.RequireViewById<ImageView>(2131297671);
		TextView noCameraHeaderTextView = noCameraLayout.RequireViewById<TextView>(2131297674);
		ImageView imageView3 = noCameraLayout.RequireViewById<ImageView>(2131297673);
		TextView textView2 = noCameraLayout.RequireViewById<TextView>(2131297678);
		TextView textView3 = noCameraLayout.RequireViewById<TextView>(2131297677);
		TextView textView4 = noCameraLayout.RequireViewById<TextView>(2131297676);
		Button button = noCameraLayout.RequireViewById<Button>(2131297672);
		View noCameraBottomInfoView = noCameraLayout.RequireViewById<View>(2131297670);
		SnackView snackView = noCameraLayout.RequireViewById<SnackView>(2131297679);
		textView2.Text = base.ViewModel.NoCameraTitle;
		textView3.Text = base.ViewModel.NoCameraSubtitle;
		textView4.Text = base.ViewModel.NoCameraSettings;
		button.Text = base.ViewModel.EnterBarcodeButton;
		snackView.Text = base.ViewModel.ScanErrorText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[9]
		{
			(delegate
			{
				noCameraLayout.Visibility = (!base.ViewModel.HasCameraPermissions).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasCameraPermissions")),
			(delegate
			{
				cameraLayout.Visibility = base.ViewModel.HasCameraPermissions.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasCameraPermissions")),
			(delegate
			{
				base.HeaderTextView.Text = base.ViewModel.AddressTopTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressTopTitle")),
			(delegate
			{
				flashButton.SetImageResource(base.ViewModel.FlashEnabled ? 2131231021 : 2131231020);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FlashEnabled")),
			(delegate
			{
				enterButton.Text = base.ViewModel.EnterBarcodeButton;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnterBarcodeButton")),
			(delegate
			{
				noCameraHeaderTextView.Text = base.ViewModel.AddressTopTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressTopTitle")),
			(delegate
			{
				progressLayout.Visibility = base.ViewModel.ThrobberEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ThrobberEnabled")),
			(delegate
			{
				warningView.Visibility = base.ViewModel.IsWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				noCameraBottomInfoView.Visibility = base.ViewModel.IsWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(base.HeaderTextView.OnClick(base.ViewModel.OnAddressClicked), imageView.OnClick(base.ViewModel.OnAddressClicked), flashButton.OnClick(OnTorch), enterButton.OnClick(base.ViewModel.OnAddManualClicked), noCameraHeaderTextView.OnClick(base.ViewModel.OnAddressClicked), imageView3.OnClick(base.ViewModel.OnAddressClicked), textView4.OnClick(AppInfo.ShowSettingsUI), imageView2.OnClick(OnClose), button.OnClick(base.ViewModel.OnAddManualClicked)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ShowManualViewCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<ManualBarcodeFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.CancelPriceCheckerCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowProductCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<ProductMiniFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenAddressCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<PriceCheckerAddressFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToFeedback.SafeSubscribe(delegate
		{
			Intent intent = new Intent(Context, typeof(FeedbackActivity));
			intent.PutExtra("ForCase", 1);
			StartActivity(intent);
		}, ViewLifecycleOwner);
	}
}
