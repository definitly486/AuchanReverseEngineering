using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Helpers;
using Auchan.Common.Profile;
using Google.Android.Material.BottomSheet;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;

namespace Auchan.Android.Profile;

internal class EnterPinToUpdatePhoneFragment : BaseBottomSheetDialogFragment<EnterPinToUpdatePhoneViewModel>
{
	private readonly BottomSheetCallback _callback = new BottomSheetCallback();

	private BottomSheetBehavior? _behavior;

	protected override int LayoutId => 2131493467;

	public EnterPinToUpdatePhoneFragment(Func<EnterPinToUpdatePhoneViewModel.Parameter, EnterPinToUpdatePhoneViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, EnterPinToUpdatePhoneViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<EnterPinToUpdatePhoneViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.Activity.OnBackPressedDispatcher.AddCallback(new DelegateOnBackPressedCallback(delegate
		{
			this.ReturnResult(result: false);
		}));
		base.ViewModel.CloseCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate(EnterPinToUpdatePhoneViewModel.Result result)
		{
			this.ReturnResult(result.WasPhoneChanged);
			Dismiss();
		}).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		_callback.State.Subscribe(delegate
		{
			if (_behavior != null)
			{
				_behavior.State = 3;
			}
		}).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnShow(IDialogInterface dialog)
	{
		BottomSheetDialog fullHeight = (BottomSheetDialog)dialog;
		SetFullHeight(fullHeight);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		HighlightedTextView messageLabel = view.RequireViewById<HighlightedTextView>(2131297571);
		TextInputLayout pinInputLayout = view.RequireViewById<TextInputLayout>(2131297915);
		TextInputEditText pinInput = pinInputLayout.RequireViewById<TextInputEditText>(2131297913);
		MaterialButton getPinButton = view.RequireViewById<MaterialButton>(2131297234);
		AppCompatImageButton appCompatImageButton = view.RequireViewById<AppCompatImageButton>(2131296490);
		pinInputLayout.Hint = base.ViewModel.PlaceholderString;
		pinInput.SetFilters(new IInputFilter[1]
		{
			new InputFilterLengthFilter(4)
		});
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				messageLabel.AttributedText = base.ViewModel.Hint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Hint")),
			(delegate
			{
				getPinButton.Text = base.ViewModel.ButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ButtonTitle")),
			(delegate
			{
				getPinButton.Enabled = base.ViewModel.IsGetPinButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsGetPinButtonEnabled")),
			(delegate
			{
				pinInputLayout.HelperText = base.ViewModel.HelperText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HelperText")),
			(delegate
			{
				pinInput.Text = base.ViewModel.PinText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PinText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)getPinButton).OnClick((Action)delegate
		{
			base.ViewModel.GetPinAsync().SafeFireAndForget((Action<Exception>)null, false);
		}), appCompatImageButton.OnClick(base.ViewModel.ClosePage)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		base.OnDismiss(dialog);
		_behavior?.RemoveBottomSheetCallback(_callback);
	}

	private void SetFullHeight(BottomSheetDialog bottomSheetDialog)
	{
		View view = bottomSheetDialog.FindViewById<View>(2131296966);
		_behavior = BottomSheetBehavior.From(view);
		_behavior.AddBottomSheetCallback(_callback);
		_behavior.HalfExpandedRatio = 1E-08f;
		ViewGroup.LayoutParams layoutParameters = view.LayoutParameters;
		int windowHeight = GetWindowHeight();
		if (layoutParameters != null)
		{
			layoutParameters.Height = windowHeight - (int)base.Activity.ConvertDpToPx(10f);
		}
		view.LayoutParameters = layoutParameters;
		_behavior.State = 3;
		_behavior.Hideable = false;
	}

	private int GetWindowHeight()
	{
		DisplayMetrics displayMetrics = new DisplayMetrics();
		((Activity)Context).WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
		return displayMetrics.HeightPixels;
	}
}
