using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardPdf417LandscapeFragment : BaseDialogFragment<LoyaltyCardQrPreviewViewModel>
{
	private float _previousBrightness;

	private ImageView? _codeImage;

	private string _code = "";

	public override int Theme => 2131952518;

	public string Code
	{
		get
		{
			return _code;
		}
		set
		{
			if (!(_code == value))
			{
				_code = value;
				if (!string.IsNullOrWhiteSpace(value))
				{
					_codeImage?.SetPDF417Code(value);
				}
			}
		}
	}

	protected override int LayoutId => 2131493042;

	private Window Window => RequireActivity().Window;

	public LoyaltyCardPdf417LandscapeFragment(Func<LoyaltyCardQrPreviewViewModel.Parameter?, LoyaltyCardQrPreviewViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyCardQrPreviewViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.NavParam<LoyaltyCardQrPreviewViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView cardNumber = view.RequireViewById<TextView>(2131297720);
		TextView screenTitle = view.RequireViewById<TextView>(2131298659);
		TextView advantagesButton = view.RequireViewById<TextView>(2131296414);
		ImageButton imageButton = view.RequireViewById<ImageButton>(2131296849);
		ImageButton imageButton2 = view.RequireViewById<ImageButton>(2131296795);
		_codeImage = view.RequireViewById<ImageView>(2131298128);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				Code = base.ViewModel.QrCode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QrCode")),
			(delegate
			{
				cardNumber.Text = base.ViewModel.CardNumber;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardNumber")),
			(delegate
			{
				screenTitle.Text = base.ViewModel.YourLoyaltyCard;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("YourLoyaltyCard")),
			(delegate
			{
				advantagesButton.Text = base.ViewModel.CardAdvantages;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardAdvantages"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageButton2.OnClick(base.ViewModel.CloseCommand.Trigger), advantagesButton.OnClick(base.ViewModel.ShowAdvantages), imageButton.OnClick(base.ViewModel.CopyCardNumberCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			DismissAllowingStateLoss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenDetailsCommand.SafeSubscribe(delegate
		{
			DismissAllowingStateLoss();
			OpenDetails<LoyaltyCardDetailsFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenEmployeeDetailsCommand.SafeSubscribe(delegate
		{
			DismissAllowingStateLoss();
			OpenDetails<LoyaltyCardDetailsEmployeeFragment>();
		}, ViewLifecycleOwner);
		Dialog.SetOnKeyListener(new DialogOnKeyListener(delegate(IDialogInterface dialogInterface, Keycode key, KeyEvent @event)
		{
			if (key == Keycode.Back)
			{
				DismissAllowingStateLoss();
				return false;
			}
			return true;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner));
	}

	public override void OnAttach(Context context)
	{
		base.OnAttach(context);
		SetBrightnessToMaximum();
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		RestoreBrightness();
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

	private void OpenDetails<TFragment>() where TFragment : Fragment
	{
		base.ParentFragment.ParentFragmentManager.BeginTransaction().Hide(base.ParentFragment).Add<TFragment>(base.ParentFragment)
			.AddToBackStack(null)
			.Commit();
	}
}
