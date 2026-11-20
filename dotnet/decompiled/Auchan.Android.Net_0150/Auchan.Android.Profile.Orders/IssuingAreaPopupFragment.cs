using System;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.Drive;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.Button;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Profile.Orders;

internal class IssuingAreaPopupFragment : BaseBottomSheetDialogFragment<IssuingAreaViewModel>
{
	private FragmentFactory _fragmentFactory;

	private OneTwoImages _oneTwoImages = new OneTwoImages();

	public Action? NavigateToOrders;

	protected override int LayoutId => 2131493473;

	public override int Theme => 2131951914;

	public IssuingAreaPopupFragment(Func<IssuingAreaViewModel.Parameter, IssuingAreaViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, IssuingAreaViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<IssuingAreaViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131298520);
		TextView textView3 = view.RequireViewById<TextView>(2131298488);
		TextView textView4 = view.RequireViewById<TextView>(2131298491);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296595);
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131296592);
		_oneTwoImages.FindAllViewsById(view);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.StoreName;
		textView3.Text = base.ViewModel.StoreAddress;
		textView4.Text = base.ViewModel.StoreDesc;
		materialButton.Text = base.ViewModel.YesButtonText;
		appCompatButton.Text = base.ViewModel.CancelButtonText;
		_oneTwoImages.Setup(base.ViewModel, base.ViewModel.Images, ViewLifecycleOwner, delegate(int i)
		{
			ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
			zoomableImageSliderFragment.ImageItemViewModels.AddRange(base.ViewModel.Images.Select((string x) => new ImageItemViewModel(x)));
			zoomableImageSliderFragment.CurrentIndex = i;
			zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
		});
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), ((View)materialButton).OnClick((Action)delegate
		{
			base.ViewModel.OnYesButtonClicked().SafeFireAndForget((Action<Exception>)null, false);
		}), appCompatButton.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnAnswerYes.SafeSubscribe(delegate
		{
			if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
			{
				AlreadyBringingPopupFragment alreadyBringingPopupFragment = _fragmentFactory.Instantiate<AlreadyBringingPopupFragment>();
				alreadyBringingPopupFragment.Show(appCompatActivity.SupportFragmentManager, null);
				alreadyBringingPopupFragment.NavigateToOrders = NavigateToOrders;
				Dismiss();
			}
		}, ViewLifecycleOwner);
		base.ViewModel.OnAnswerError.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
