using System;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;

namespace Auchan.Android.Base.Widgets;

[Register("auchan.OutlinedTextInput")]
public class OutlinedTextInput : ConstraintLayoutWidgetBase
{
	public enum ButtonStyle
	{
		None,
		Clear,
		Contacts,
		Checkmark
	}

	private TextView _errorText;

	private TextView _upperHintText;

	private EditText _inputEditText;

	private ImageButton _imageButton;

	private ImageButton _errorImageButton;

	private ViewGroup _bgView;

	private ButtonStyle _buttonStyle;

	private bool _errorState;

	private string _hint = string.Empty;

	public EditText EditText => _inputEditText;

	public string Hint
	{
		get
		{
			return _hint;
		}
		set
		{
			EditText inputEditText = _inputEditText;
			string hint = (_upperHintText.Text = (_hint = value));
			inputEditText.Hint = hint;
			UpdateHintVisibility(_inputEditText.Text.Length > 0, _inputEditText.HasFocus);
		}
	}

	public event Action<ButtonStyle>? ButtonTapped;

	protected OutlinedTextInput(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public OutlinedTextInput(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public OutlinedTextInput(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public OutlinedTextInput(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public OutlinedTextInput(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		View view = View.Inflate(context, 2131493437, this);
		_inputEditText = view.RequireViewById<EditText>(2131298609);
		_errorText = view.RequireViewById<TextView>(2131298626);
		_upperHintText = view.RequireViewById<TextView>(2131298789);
		_imageButton = view.RequireViewById<ImageButton>(2131298607);
		_errorImageButton = view.RequireViewById<ImageButton>(2131297110);
		_bgView = view.RequireViewById<ViewGroup>(2131298611);
		_imageButton.Click += delegate
		{
			this.ButtonTapped?.Invoke(_buttonStyle);
		};
		_inputEditText.TextChanged += InputTextChanged;
		_inputEditText.FocusChange += InputFocusChanged;
		view.Click += delegate
		{
			_inputEditText.RequestFocus();
			InputMethodManager.FromContext(_inputEditText.Context).ShowSoftInput(_inputEditText, ShowFlags.Forced);
		};
	}

	private void InputFocusChanged(object sender, FocusChangeEventArgs e)
	{
		bool hasText = _inputEditText.Text.Length > 0;
		UpdateHintVisibility(hasText, e.HasFocus);
	}

	public void Clear()
	{
		if (_inputEditText.Text.Length > 0)
		{
			_inputEditText.Text = null;
		}
		UpdateHintVisibility(hasText: false, _inputEditText.HasFocus);
	}

	private void InputTextChanged(object sender, TextChangedEventArgs e)
	{
		bool flag = _inputEditText.Text.Length > 0;
		UpdateHintVisibility(flag, _inputEditText.HasFocus);
		if (_buttonStyle == ButtonStyle.None || _buttonStyle == ButtonStyle.Clear)
		{
			SetButtonStyle(flag ? ButtonStyle.Clear : ButtonStyle.None);
		}
	}

	private void UpdateHintVisibility(bool hasText, bool hasFocus)
	{
		_upperHintText.Visibility = (hasFocus || hasText).ToVisibility();
		_inputEditText.Hint = ((hasFocus && !hasText) ? "" : _hint);
	}

	public void SetError(string text, bool error)
	{
		_errorState = error;
		_bgView.Activated = error;
		_upperHintText.Activated = error;
		_errorImageButton.Visibility = error.ToVisibility();
		_imageButton.Visibility = (!error && _buttonStyle != ButtonStyle.None).ToVisibility();
		_errorText.Visibility = error.ToVisibility();
		_errorText.Text = text;
	}

	public void SetButtonStyle(ButtonStyle style)
	{
		_buttonStyle = style;
		_imageButton.Visibility = (!_errorState && style != ButtonStyle.None).ToVisibility();
		ImageButton imageButton = _imageButton;
		imageButton.SetImageResource(style switch
		{
			ButtonStyle.Clear => 2131231122, 
			ButtonStyle.Checkmark => 2131231093, 
			ButtonStyle.Contacts => 2131231133, 
			_ => 2131231122, 
		});
	}
}
