using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.Button;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardPdf417PortraitFragment : BaseBottomSheetDialogFragment<LoyaltyCardQrPreviewViewModel>
{
	private float _previousBrightness;

	private ImageView? _qrCodeImage;

	private string _qrCode = "";

	public override int Theme => 2131951916;

	protected override bool IsDragToCloseEnabled => true;

	public string QrCode
	{
		get
		{
			return _qrCode;
		}
		set
		{
			if (!(_qrCode == value))
			{
				_qrCode = value;
				if (!string.IsNullOrWhiteSpace(value))
				{
					_qrCodeImage?.SetPDF417Code(value);
				}
			}
		}
	}

	protected override int LayoutId => 2131493044;

	protected override bool FullScreen => true;

	private Window Window => RequireActivity().Window;

	public LoyaltyCardPdf417PortraitFragment(Func<LoyaltyCardQrPreviewViewModel.Parameter?, LoyaltyCardQrPreviewViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, LoyaltyCardQrPreviewViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.NavParam<LoyaltyCardQrPreviewViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296904);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131298079);
		ImageView imageView = viewGroup.RequireViewById<ImageView>(2131298112);
		TextView textView = view.RequireViewById<TextView>(2131298659);
		TextView textView2 = viewGroup.RequireViewById<TextView>(2131297689);
		TextView textView3 = viewGroup.RequireViewById<TextView>(2131297686);
		Group noInternetVisibilityGroup = viewGroup.RequireViewById<Group>(2131297687);
		TextView blockedCard = viewGroup.RequireViewById<TextView>(2131296542);
		TextView textView4 = viewGroup.RequireViewById<TextView>(2131296662);
		TextView textView5 = viewGroup.RequireViewById<TextView>(2131296659);
		MaterialButton materialButton = viewGroup.RequireViewById<MaterialButton>(2131296795);
		ImageView qrImageBlockedOverlay = viewGroup.RequireViewById<ImageView>(2131298125);
		_qrCodeImage = viewGroup.RequireViewById<ImageView>(2131298128);
		textView.Text = base.ViewModel.ScreenTitle;
		textView2.Text = base.ViewModel.NoInternetConnectionTitle;
		textView3.Text = base.ViewModel.NoInternetConnectionDescription;
		blockedCard.Text = base.ViewModel.CardIsBlockedText;
		textView4.Text = base.ViewModel.YourCardNumber;
		textView5.Text = base.ViewModel.CardNumber;
		materialButton.Text = base.ViewModel.CloseButtonText;
		VisibilitySwitch<LoyaltyCardQrPreviewViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<LoyaltyCardQrPreviewViewModel.VisualState>(LoyaltyCardQrPreviewViewModel.VisualState.Default)
		{
			{
				LoyaltyCardQrPreviewViewModel.VisualState.Default,
				viewGroup
			},
			{
				LoyaltyCardQrPreviewViewModel.VisualState.InProgress,
				viewGroup2
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				QrCode = base.ViewModel.QrCode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QrCode")),
			(delegate
			{
				_qrCodeImage.Elevation = Application.Context.Resources.DisplayMetrics.Density * (float)Converter.BoolToInts(base.ViewModel.IsCardBlocked, 0, 4);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				noInternetVisibilityGroup.Visibility = base.ViewModel.IsNotInternetConnectionVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsNotInternetConnectionVisible")),
			(delegate
			{
				blockedCard.Visibility = base.ViewModel.IsCardBlocked.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				qrImageBlockedOverlay.Visibility = base.ViewModel.IsCardBlocked.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), materialButton.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			this.DismissAsync().SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
	}

	public override void OnAttach(Context context)
	{
		base.OnAttach(context);
		SetBrightnessToMaximum();
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		RestoreBrightness();
		base.ViewModel.CloseCommand.Trigger();
	}

	private void SetBrightnessToMaximum()
	{
		WindowManagerLayoutParams attributes = Window.Attributes;
		_previousBrightness = attributes.ScreenBrightness;
		attributes.ScreenBrightness = 1f;
		Window.Attributes = attributes;
	}

	private void RestoreBrightness()
	{
		WindowManagerLayoutParams attributes = Window.Attributes;
		attributes.ScreenBrightness = _previousBrightness;
		Window.Attributes = attributes;
	}
}
