using System;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Controls.Configuration.Input;
using Auchan.Android.Extensions;

namespace Auchan.Android.Controls;

public class BoldInputEditText : FrameLayout
{
	private Color _emptyPlaceholderColor;

	private Color _filledPlaceholderColor;

	private TextView _placeHolderTextView;

	private string _initialPlaceholder = string.Empty;

	public AppCompatEditText Input { get; private set; }

	public BoldInputEditText(Context context)
		: base(context)
	{
		InitView(context, null);
	}

	public BoldInputEditText(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		InitView(context, attrs);
	}

	public BoldInputEditText(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		InitView(context, attrs);
	}

	public BoldInputEditText(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		InitView(context, attrs);
	}

	public void Configure(InputConfiguration configuration)
	{
		Input.InputType = configuration.InputType;
		_initialPlaceholder = configuration.InitialPlaceHolder;
		_placeHolderTextView.Text = configuration.InitialPlaceHolder;
		if (configuration is PhoneInputConfiguration configuration2)
		{
			ConfigureAsPhone(configuration2);
			return;
		}
		throw new InvalidOperationException("Unknown configuration " + configuration.GetType().FullName);
	}

	private void ConfigureAsPhone(PhoneInputConfiguration configuration)
	{
		PhoneMaskOption maskOptions = configuration.MaskOptions;
		if (maskOptions != null)
		{
			Input.InstallMaskedListener(maskOptions.PhoneMask, maskOptions.ValueListener);
		}
	}

	private void InitView(Context context, IAttributeSet? attrs)
	{
		View view = View.Inflate(context, 2131493134, this);
		_emptyPlaceholderColor = new Color(ContextCompat.GetColor(context, 2131099700));
		_filledPlaceholderColor = new Color(ContextCompat.GetColor(context, 2131099699));
		_placeHolderTextView = view.RequireViewById<TextView>(2131296546);
		Input = view.RequireViewById<AppCompatEditText>(2131296545);
	}

	protected override void OnAttachedToWindow()
	{
		base.OnAttachedToWindow();
		Input.TextChanged += OnInputTextChanged;
	}

	protected override void OnDetachedFromWindow()
	{
		base.OnDetachedFromWindow();
		Input.TextChanged -= OnInputTextChanged;
	}

	private void OnInputTextChanged(object sender, TextChangedEventArgs e)
	{
		string text = e.Text?.ToString();
		string text2 = MakePlaceHolder(text);
		if (!string.IsNullOrEmpty(text2))
		{
			_placeHolderTextView.Text = text2;
		}
		_placeHolderTextView.SetTextColor(string.IsNullOrEmpty(text) ? _emptyPlaceholderColor : _filledPlaceholderColor);
	}

	private string MakePlaceHolder(string text)
	{
		int num = text?.Length ?? 0;
		if (num > _initialPlaceholder.Length)
		{
			return null;
		}
		string text2 = _initialPlaceholder.Substring(num, _initialPlaceholder.Length - num);
		return text + text2;
	}
}
