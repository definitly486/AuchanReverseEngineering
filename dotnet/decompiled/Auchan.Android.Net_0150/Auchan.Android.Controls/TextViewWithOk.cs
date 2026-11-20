using System;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Extensions;

namespace Auchan.Android.Controls;

public class TextViewWithOk : ConstraintLayout
{
	private View _view;

	private Context _context;

	private TextView _hintTextView;

	private View _bottomLine;

	private string _hint;

	private bool _isError;

	public EditText Input { get; private set; }

	public Button OkButton { get; private set; }

	public Button CancelButton { get; private set; }

	public View OkInfoView { get; private set; }

	public View OkView { get; private set; }

	public View ErrorView { get; private set; }

	public ImageView ClearButton { get; private set; }

	public bool IsEnabled
	{
		get
		{
			return _view.Enabled;
		}
		set
		{
			_view.Enabled = value;
			Input.Enabled = value;
			if (!value)
			{
				ClearButton.Visibility = ViewStates.Gone;
			}
		}
	}

	public bool IsError
	{
		get
		{
			return _isError;
		}
		set
		{
			_isError = value;
			ErrorView.Visibility = value.ToVisibility();
			_hintTextView.SetTextColor(ContextCompat.GetColorStateList(base.Context, value ? 2131099790 : 2131099703));
			SetBottomLineColor();
		}
	}

	public bool IsPromocodeEntered
	{
		get
		{
			return OkView.Visibility == ViewStates.Visible;
		}
		set
		{
			OkView.Visibility = value.ToVisibility();
			ClearButton.Visibility = (!value && Input.Text.Length > 0).ToVisibility();
			SetBottomLineColor();
		}
	}

	public bool IsPromocodeInfoExists
	{
		get
		{
			return OkInfoView.Visibility == ViewStates.Visible;
		}
		set
		{
			OkInfoView.Visibility = value.ToVisibility();
		}
	}

	public string Hint
	{
		get
		{
			return _hint;
		}
		set
		{
			_hint = value;
			Input.Hint = (Input.HasFocus ? string.Empty : value);
			_hintTextView.Text = value;
		}
	}

	public TextViewWithOk(Context context)
		: base(context)
	{
		_context = context;
	}

	public TextViewWithOk(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		_context = context;
		Initialize(context, attrs);
	}

	public TextViewWithOk(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		_context = context;
		Initialize(context, attrs);
	}

	protected TextViewWithOk(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		_view = View.Inflate(context, 2131493202, this);
		Input = _view.RequireViewById<EditText>(2131298625);
		_hintTextView = _view.RequireViewById<TextView>(2131298624);
		OkButton = _view.RequireViewById<Button>(2131298622);
		CancelButton = _view.RequireViewById<Button>(2131296613);
		ClearButton = _view.RequireViewById<ImageView>(2131296795);
		_bottomLine = _view.RequireViewById<View>(2131296563);
		OkInfoView = _view.RequireViewById<View>(2131297730);
		OkView = _view.RequireViewById<View>(2131297729);
		ErrorView = _view.RequireViewById<View>(2131297116);
		ClearButton.Visibility = ViewStates.Gone;
		Input.InputType = InputTypes.TextFlagAutoComplete;
		_hintTextView.Visibility = ViewStates.Gone;
		Input.FocusChange += OnPromocodeFocus;
		ClearButton.Click += ClearText;
		OkButton.Click += OnOkClick;
		Input.TextChanged += OnTextChanges;
		_view.Click += FocusInput;
	}

	private void FocusInput(object sender, EventArgs e)
	{
		Input.RequestFocus();
		Input.ShowKeyboard(_context);
	}

	private void OnOkClick(object sender, EventArgs e)
	{
		Input.ClearFocus();
		Input.HideKeyboard(_context);
	}

	private void OnTextChanges(object sender, TextChangedEventArgs e)
	{
		SetupHint();
		SetBottomLineColor();
	}

	private void ClearText(object sender, EventArgs e)
	{
		if (!Input.HasFocus)
		{
			Input.Hint = string.Empty;
			Input.RequestFocus();
			Input.ShowKeyboard(_context);
		}
		Input.Text = string.Empty;
	}

	private void OnPromocodeFocus(object sender, FocusChangeEventArgs e)
	{
		SetupHint();
	}

	private void SetupHint()
	{
		if (Input.HasFocus)
		{
			Input.Hint = string.Empty;
			_hintTextView.Visibility = ViewStates.Visible;
		}
		else if (string.IsNullOrEmpty(Input.Text))
		{
			Input.Hint = _hint;
			_hintTextView.Visibility = ViewStates.Gone;
		}
		else
		{
			Input.Hint = string.Empty;
			_hintTextView.Visibility = ViewStates.Visible;
		}
	}

	private void SetBottomLineColor()
	{
		_bottomLine.SetBackgroundResource(IsError ? 2131099790 : ((IsPromocodeEntered || Input.Text.Length > 0) ? 2131100548 : 2131099699));
	}
}
