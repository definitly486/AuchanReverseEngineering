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

[Register("auchan.OutlinedActiveTextInput")]
public class OutlinedActiveTextInput : ConstraintLayoutWidgetBase
{
	public enum ButtonStyle
	{
		None,
		Clear,
		Contacts,
		Checkmark
	}

	private TextView _upperHintText;

	private EditText _inputEditText;

	private ImageButton _imageButton;

	private ViewGroup _bgView;

	private ButtonStyle _buttonStyle;

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

	protected OutlinedActiveTextInput(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public OutlinedActiveTextInput(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public OutlinedActiveTextInput(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public OutlinedActiveTextInput(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public OutlinedActiveTextInput(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		View view = View.Inflate(context, 2131493436, this);
		_inputEditText = view.RequireViewById<EditText>(2131298609);
		_upperHintText = view.RequireViewById<TextView>(2131298789);
		_imageButton = view.RequireViewById<ImageButton>(2131298607);
		_bgView = view.RequireViewById<ViewGroup>(2131298611);
		_imageButton.Click += delegate
		{
			_inputEditText.Text = "";
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
		bool flag = _inputEditText.Text.Length > 0;
		UpdateHintVisibility(flag, e.HasFocus);
		_bgView.Activated = e.HasFocus;
		if (_buttonStyle == ButtonStyle.None || _buttonStyle == ButtonStyle.Clear)
		{
			SetButtonStyle((flag && e.HasFocus) ? ButtonStyle.Clear : ButtonStyle.None);
		}
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

	public void SetButtonStyle(ButtonStyle style)
	{
		_buttonStyle = style;
		_imageButton.Visibility = (style != ButtonStyle.None).ToVisibility();
		ImageButton imageButton = _imageButton;
		int imageResource = ((style != ButtonStyle.Clear) ? 2131231122 : 2131231122);
		imageButton.SetImageResource(imageResource);
	}
}
