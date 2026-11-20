using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram;
using EBind;

namespace Auchan.Android.Controls;

[Register("Auchan.Android.Controls.LoyaltyCardView")]
internal class LoyaltyCardView : BaseCustomView<LoyaltyCardElementViewModel>
{
	private ViewGroup _employeeLayout;

	private TextView _employeeText;

	private View _employeeIcon;

	private ViewGroup _employeeInfoLayout;

	private TextView _employeeInfoText;

	private View _separator;

	private View _separator2;

	private ImageView _codeImage;

	private LinearLayout _cardPointsLayout;

	private ViewGroup _pointsLayout;

	private TextView _pointsText;

	private TextView _pointDecimalsText;

	private ViewGroup _ePointsLayout;

	private TextView _ePointsText;

	private TextView _ePointDecimalsText;

	private ViewGroup _marksLayout;

	private TextView _marksText;

	private TextView _marksDecimalsText;

	private ViewGroup _burningLayout;

	private TextView _burningText;

	private ViewGroup _delayedPointsLayout;

	private TextView _delayedPointsText;

	private ViewGroup _burningMarksLayout;

	private TextView _burningMarksText;

	private string _lastCode = string.Empty;

	private Bitmap _lastCodeBitmap;

	protected override int LayoutId => 2131493161;

	public LoyaltyCardView(Context context)
		: base(context)
	{
	}

	public LoyaltyCardView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LoyaltyCardView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public LoyaltyCardView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public LoyaltyCardView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet attrs = null)
	{
		base.Init(context, attrs);
		_employeeLayout = base.View.RequireViewById<ViewGroup>(2131297060);
		_employeeText = base.View.RequireViewById<TextView>(2131297061);
		_employeeIcon = base.View.RequireViewById<View>(2131297056);
		_codeImage = base.View.RequireViewById<ImageView>(2131296800);
		_cardPointsLayout = base.View.RequireViewById<LinearLayout>(2131296666);
		_pointsLayout = base.View.RequireViewById<ViewGroup>(2131297940);
		_pointsText = base.View.RequireViewById<TextView>(2131297951);
		_pointDecimalsText = base.View.RequireViewById<TextView>(2131297923);
		_ePointsLayout = base.View.RequireViewById<ViewGroup>(2131297104);
		_ePointsText = base.View.RequireViewById<TextView>(2131297105);
		_ePointDecimalsText = base.View.RequireViewById<TextView>(2131297100);
		_marksLayout = base.View.RequireViewById<ViewGroup>(2131297531);
		_marksText = base.View.RequireViewById<TextView>(2131297532);
		_marksDecimalsText = base.View.RequireViewById<TextView>(2131297519);
		_burningLayout = base.View.RequireViewById<ViewGroup>(2131296582);
		_burningText = base.View.RequireViewById<TextView>(2131296585);
		_delayedPointsLayout = base.View.RequireViewById<ViewGroup>(2131296918);
		_delayedPointsText = base.View.RequireViewById<TextView>(2131296919);
		_burningMarksLayout = base.View.RequireViewById<ViewGroup>(2131296583);
		_burningMarksText = base.View.RequireViewById<TextView>(2131296584);
		_employeeInfoLayout = base.View.RequireViewById<ViewGroup>(2131297057);
		_employeeInfoText = base.View.RequireViewById<TextView>(2131297059);
		_separator = base.View.RequireViewById<View>(2131298353);
		_separator2 = base.View.RequireViewById<View>(2131298354);
	}

	protected override void DoBind()
	{
		_employeeText.Text = base.ViewModel.EmployeeText;
		_employeeInfoText.Text = base.ViewModel.EmployeeInfoText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[20]
		{
			(delegate
			{
				_employeeLayout.Visibility = base.ViewModel.IsEmployee.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEmployee")),
			(delegate
			{
				_employeeInfoLayout.Visibility = base.ViewModel.EmployeeInfoVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmployeeInfoVisible")),
			(delegate
			{
				SetPDF417Code(base.ViewModel.Code, Resources.DisplayMetrics.WidthPixels, Resources.DisplayMetrics.WidthPixels / 4);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Code")),
			(delegate
			{
				_pointsLayout.Visibility = base.ViewModel.PointsAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsAvailable")),
			(delegate
			{
				_pointsText.Text = base.ViewModel.Points;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Points")),
			(delegate
			{
				_pointDecimalsText.Text = base.ViewModel.PointDecimals;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointDecimals")),
			(delegate
			{
				_ePointsLayout.Visibility = base.ViewModel.EPointsAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EPointsAvailable")),
			(delegate
			{
				_ePointsText.Text = base.ViewModel.EPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EPoints")),
			(delegate
			{
				_ePointDecimalsText.Text = base.ViewModel.EPointDecimals;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EPointDecimals")),
			(delegate
			{
				_marksLayout.Visibility = base.ViewModel.MarksAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarksAvailable")),
			(delegate
			{
				_marksText.Text = base.ViewModel.Marks;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Marks")),
			(delegate
			{
				_marksDecimalsText.Text = base.ViewModel.MarkDecimals;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarkDecimals")),
			(delegate
			{
				_burningLayout.Visibility = base.ViewModel.PointsBurningAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBurningAvailable")),
			(delegate
			{
				_burningText.Text = base.ViewModel.PointsBurningText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBurningText")),
			(delegate
			{
				_delayedPointsLayout.Visibility = base.ViewModel.DelayedPointsAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedPointsAvailable")),
			(delegate
			{
				_delayedPointsText.Text = base.ViewModel.DelayedPointsText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedPointsText")),
			(delegate
			{
				_burningMarksLayout.Visibility = base.ViewModel.MarksBurningAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarksBurningAvailable")),
			(delegate
			{
				_burningMarksText.Text = base.ViewModel.MarksBurningText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarksBurningText")),
			(delegate
			{
				_separator.Visibility = ((base.ViewModel.PointsBurningAvailable && base.ViewModel.MarksBurningAvailable) || (base.ViewModel.PointsBurningAvailable && base.ViewModel.DelayedPointsAvailable)).ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "PointsBurningAvailable", "MarksBurningAvailable", "DelayedPointsAvailable" })),
			(delegate
			{
				_separator2.Visibility = (base.ViewModel.MarksBurningAvailable && base.ViewModel.DelayedPointsAvailable).ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "MarksBurningAvailable", "DelayedPointsAvailable" }))
		})).AddTo(base.Disposables);
		_codeImage.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.OpenQrCodeClick)).AddTo(base.Disposables);
		_burningLayout.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.OpenBurningPointsTapped)).AddTo(base.Disposables);
		_delayedPointsLayout.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.OpenDelayedPointsCommand.Trigger)).AddTo(base.Disposables);
		_burningMarksLayout.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.StampsBurningTapped)).AddTo(base.Disposables);
		_employeeIcon.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.SwitchEmployeeInfoCommand.Trigger)).AddTo(base.Disposables);
		_employeeInfoLayout.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.SwitchEmployeeInfoCommand.Trigger)).AddTo(base.Disposables);
		_cardPointsLayout.SetOnClickListenerSafe(new ViewOnClickListener(base.ViewModel.OpenPointsClick)).AddTo(base.Disposables);
		FragmentActivity activity = base.ParentFragment.Activity;
		BaseActivity activity2 = activity as BaseActivity;
		if (activity2 == null)
		{
			return;
		}
		activity2.AnyClick += new DisposableDelegate<EventHandler>(delegate
		{
			if (base.ViewModel.EmployeeInfoVisible)
			{
				base.ViewModel.SwitchEmployeeInfoCommand.Trigger();
			}
		}, delegate(EventHandler d)
		{
			activity2.AnyClick -= d;
		}).AddTo(base.Disposables);
	}

	private void SetPDF417Code(string content, int width, int height)
	{
		if (!string.IsNullOrWhiteSpace(content))
		{
			if (_lastCode != content || _lastCodeBitmap == null)
			{
				_lastCode = content;
				_lastCodeBitmap = BarcodeGenerator.CreatePDF417Code(content, width, height);
			}
			_codeImage.SetBitmap(_lastCodeBitmap);
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		_lastCode = null;
		_lastCodeBitmap?.Dispose();
		_lastCodeBitmap = null;
	}
}
