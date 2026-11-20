using System;
using System.Collections.Generic;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.PriceChecker;
using Google.Android.Material.TextField;

namespace Auchan.Android.Ecom.PriceChecker;

internal class ManualBarcodeFragment : BaseBottomSheetDialogFragment<ManualBarcodeViewModel>
{
	private sealed class Controls(View view)
	{
		public View View => view;

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public ImageView CloseButton { get; } = view.RequireViewById<ImageView>(2131296791);

		public TextInputLayout BarcodeInputLayout { get; } = view.RequireViewById<TextInputLayout>(2131296519);

		public TextInputEditText BarcodeInput { get; } = view.RequireViewById<TextInputEditText>(2131296518);

		public Button OkButton { get; } = view.RequireViewById<Button>(2131296351);

		public ImageView ClearTextButton { get; } = view.RequireViewById<ImageView>(2131296783);

		public SkottieAnimationView LoadingView { get; } = view.RequireViewById<SkottieAnimationView>(2131297458);
	}

	protected override int LayoutId => 2131493466;

	public override int Theme => 2131951914;

	public ManualBarcodeFragment(Func<BrokerToken, ManualBarcodeViewModel> newViewModel)
		: base((Func<Fragment, ManualBarcodeViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.OkButton.Enabled = false;
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				controls.Title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.BarcodeInputLayout.Hint = base.ViewModel.Hint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Hint")),
			(delegate
			{
				controls.OkButton.Enabled = base.ViewModel.CanCheckBarcode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanCheckBarcode")),
			(delegate
			{
				controls.OkButton.Activated = base.ViewModel.CanCheckBarcode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanCheckBarcode")),
			(delegate
			{
				SetState(base.ViewModel.State, controls);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.CloseButton.OnClick(base.ViewModel.Dismiss), ((View)controls.OkButton).OnClick((Action)delegate
		{
			base.ViewModel.OkClicked().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)controls.ClearTextButton).OnClick((Action)delegate
		{
			Clear(controls);
		}), ((TextView)controls.BarcodeInput).OnTextChanged((Action)delegate
		{
			OnBarcodeTextChanged(controls);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBarcodeTextChanged(Controls controls)
	{
		string text = controls.BarcodeInput.Text;
		bool flag = string.IsNullOrWhiteSpace(text);
		controls.ClearTextButton.Visibility = (!flag).ToVisibility();
		base.ViewModel.OnEnterBarcode(text);
	}

	private void Clear(Controls controls)
	{
		controls.BarcodeInput.Text = string.Empty;
		base.ViewModel.Clear();
	}

	private void SetState(VisualState state, Controls controls)
	{
		if (state == VisualState.Default)
		{
			controls.View.PostDelayed(delegate
			{
				ShowKeyboard(controls);
			}, 500L);
		}
		controls.ClearTextButton.Visibility = (state == VisualState.Default && !string.IsNullOrWhiteSpace(controls.BarcodeInput.Text)).ToVisibility();
		controls.OkButton.Visibility = (state == VisualState.Default).ToVisibility();
		controls.LoadingView.Visibility = (state == VisualState.InProgress).ToVisibility();
		controls.BarcodeInput.Text = ((state == VisualState.InProgress) ? string.Empty : base.ViewModel.Barcode);
		controls.BarcodeInput.Enabled = state == VisualState.Default;
		TextInputLayout barcodeInputLayout = controls.BarcodeInputLayout;
		string hint = ((state != VisualState.InProgress) ? base.ViewModel.Hint : base.ViewModel.CheckPlaceholder);
		barcodeInputLayout.Hint = hint;
	}

	private void ShowKeyboard(Controls controls)
	{
		try
		{
			controls.BarcodeInput.RequestFocus();
			InputMethodManager.FromContext(RequireActivity()).ShowSoftInput(controls.BarcodeInput, ShowFlags.Implicit);
			string text = controls.BarcodeInput.Text;
			if (!string.IsNullOrWhiteSpace(text) && text.Length > 0)
			{
				controls.BarcodeInput.SetSelection(text.Length);
			}
		}
		catch (Exception value)
		{
			Log.Error(base.Tag, $"Failed to focus keyboard - {value}");
		}
	}
}
