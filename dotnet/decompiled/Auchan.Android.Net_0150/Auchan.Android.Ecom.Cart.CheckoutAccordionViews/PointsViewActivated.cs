using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using EBind;
using Google.Android.Material.TextField;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PointsViewActivated : ConstraintLayoutWidgetBase
{
	private TextView _titleText;

	private TextView _availableText;

	private TextView _burningText;

	private TextInputLayout _inputLayout;

	private EditText _editText;

	private AppCompatSeekBar _pointsSeekbar;

	private TextView _pointsStartText;

	private TextView _pointsEndText;

	private View _minusButton;

	private ImageView _infoButton;

	public TextInputLayout InputLayout => _inputLayout;

	public PointsViewActivated(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PointsViewActivated(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PointsViewActivated(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PointsViewActivated(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PointsViewActivated(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	public void Initialize(Context context)
	{
		int resource = 2131493138;
		View view = View.Inflate(context, resource, this);
		_titleText = view.RequireViewById<TextView>(2131298659);
		_availableText = view.RequireViewById<TextView>(2131296484);
		_burningText = view.RequireViewById<TextView>(2131296585);
		_inputLayout = view.RequireViewById<TextInputLayout>(2131297372);
		_editText = _inputLayout.EditText;
		_pointsSeekbar = view.RequireViewById<AppCompatSeekBar>(2131297947);
		_pointsStartText = view.RequireViewById<TextView>(2131297950);
		_pointsEndText = view.RequireViewById<TextView>(2131297932);
		_minusButton = view.RequireViewById<View>(2131297275);
		_infoButton = view.RequireViewById<ImageView>(2131297360);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		_titleText.Text = viewModel.PointsPaymentTitle;
		_inputLayout.SetEndIconOnClickListener(new ViewOnClickListener((Action<View>)delegate
		{
			viewModel.ResetPointsPaymentValue();
			_editText.Text = string.Empty;
		}).AutoDisposeOnDestroy(viewLifecycleOwner));
		((View)_editText).OnFocusChange((Action)delegate
		{
			_editText.Text = viewModel.PointsPaymentValue.ToString();
		}).AutoDisposeOnDestroy(viewLifecycleOwner);
		((TextView)_editText).OnAfterTextChanged((Action)delegate
		{
			viewModel.SetPointsPaymentValue(_editText.Text);
		}).AutoDisposeOnDestroy(viewLifecycleOwner);
		_pointsSeekbar.StartTrackingTouch += new DisposableDelegate<EventHandler<SeekBar.StartTrackingTouchEventArgs>>(delegate
		{
			if (_editText.HasFocus)
			{
				_editText.ClearFocus();
				this.HideKeyboard(base.Context);
			}
		}, delegate(EventHandler<SeekBar.StartTrackingTouchEventArgs> d)
		{
			_pointsSeekbar.StartTrackingTouch -= d;
		}).AutoDisposeOnDestroy(viewLifecycleOwner);
		_editText.Text = viewModel.PointsPaymentValue.ToString();
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				_availableText.Text = viewModel.PointsAvailableText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsAvailableText")),
			(delegate
			{
				_burningText.Text = viewModel.PointsBurnableText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBurnableText")),
			(delegate
			{
				_pointsStartText.Text = viewModel.PointsPaymentMinValue.ToString();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentMinValue")),
			(delegate
			{
				_pointsEndText.Text = viewModel.PointsPaymentMaxValue.ToString();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentMaxValue")),
			(delegate
			{
				UpdateSeekbar(viewModel);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "PointsPaymentMinValue", "PointsPaymentMaxValue", "PointsPaymentValue" })),
			(delegate
			{
				_infoButton.Visibility = viewModel.IsAdultWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAdultWarningVisible")),
			(delegate
			{
				SetPointsIfNeeded(viewModel.PointsPaymentValue);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentValue"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		viewModel.BindEvents(_infoButton.OnClick(viewModel.OnPointsPaymentInfoClick), _minusButton.OnClick(viewModel.OnPointsPaymentRemove), _minusButton.OnClick((Action)delegate
		{
			this.HideKeyboard(base.Context);
		}), _pointsSeekbar.OnProgressChanged(delegate(object? o, SeekBar.ProgressChangedEventArgs e)
		{
			viewModel.PointsPaymentValue = e.Progress;
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
	}

	private void SetPointsIfNeeded(long points)
	{
		if (!_editText.HasFocus)
		{
			_editText.Text = points.ToString();
		}
	}

	private void UpdateSeekbar(CheckoutViewModel vm)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(26))
		{
			_pointsSeekbar.Min = (int)vm.PointsPaymentMinValue;
		}
		_pointsSeekbar.Max = (int)vm.PointsPaymentMaxValue;
		if (!_pointsSeekbar.HasFocus)
		{
			_pointsSeekbar.Progress = (int)vm.PointsPaymentValue;
		}
	}
}
