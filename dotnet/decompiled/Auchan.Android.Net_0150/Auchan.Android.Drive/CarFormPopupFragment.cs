using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Drive;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.Drive;

internal abstract class CarFormPopupFragment<T> : BaseBottomSheetDialogFragment<T> where T : CarFormViewModel
{
	private readonly TaskCompletionSource<Car?> _tcs = new TaskCompletionSource<Car>();

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493066;

	protected override int InsetsTypeMask => WindowInsetsCompat.Type.SystemBars();

	public CarFormPopupFragment(Func<CarFormViewModel.Parameter, T> newViewModel)
		: base((Func<Fragment, T>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CarFormViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		MaterialButton saveButton = linearLayout.RequireViewById<MaterialButton>(2131298287);
		TextInputLayout carNumberInputLayout = linearLayout.RequireViewById<TextInputLayout>(2131296629);
		TextInputLayout carBrandInputLayout = linearLayout.RequireViewById<TextInputLayout>(2131296624);
		TextInputLayout carColorInputLayout = linearLayout.RequireViewById<TextInputLayout>(2131296626);
		TextView textView = linearLayout.RequireViewById<TextView>(2131298646);
		ImageView imageView = linearLayout.RequireViewById<ImageView>(2131296795);
		TextView textView2 = linearLayout.RequireViewById<TextView>(2131296958);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131296809);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131296808);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		textView2.Visibility = base.ViewModel.IsDescriptionVisible.ToVisibility();
		saveButton.Text = base.ViewModel.SaveButtonText;
		carNumberInputLayout.Hint = base.ViewModel.CarNumberTextFieldHint;
		carColorInputLayout.Hint = base.ViewModel.CarColorTextFieldHint;
		carBrandInputLayout.Hint = base.ViewModel.CarBrandTextFieldHint;
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				linearLayout
			},
			{
				VisualState.Error,
				constraintLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			}
		};
		carColorInputLayout.EditText.Text = base.ViewModel.CarColor;
		carBrandInputLayout.EditText.Text = base.ViewModel.CarBrand;
		carNumberInputLayout.EditText.Text = base.ViewModel.CarNumber;
		InputFilterLengthFilter inputFilterLengthFilter = new InputFilterLengthFilter(25);
		EditText? editText = carColorInputLayout.EditText;
		IInputFilter[] filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		editText.SetFilters(filters);
		EditText? editText2 = carBrandInputLayout.EditText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		editText2.SetFilters(filters);
		EditText? editText3 = carNumberInputLayout.EditText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		editText3.SetFilters(filters);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				saveButton.Enabled = base.ViewModel.SaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonEnabled")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), saveButton.OnClick(OnSaveClick), ((TextView)carColorInputLayout.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.CarColor = carColorInputLayout.EditText.Text;
		}), ((TextView)carBrandInputLayout.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.CarBrand = carBrandInputLayout.EditText.Text;
		}), ((TextView)carNumberInputLayout.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.CarNumber = carNumberInputLayout.EditText.Text;
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	public Task<Car?> WaitAddingCar()
	{
		return _tcs.Task;
	}

	public override void Dismiss()
	{
		_tcs.TrySetResult(null);
		base.Dismiss();
	}

	private void OnSaveClick()
	{
		base.ViewModel.OnSaveClick();
		Car result = new Car
		{
			CarNumber = base.ViewModel.CarNumber,
			CarColor = base.ViewModel.CarColor,
			CarMark = base.ViewModel.CarBrand,
			IsDefault = true
		};
		_tcs.TrySetResult(result);
	}
}
