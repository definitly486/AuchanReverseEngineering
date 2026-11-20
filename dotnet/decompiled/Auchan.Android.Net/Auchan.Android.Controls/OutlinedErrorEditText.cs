using System;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using EBind;
using Google.Android.Material.TextField;
using InputMask;
using Java.Lang;

namespace Auchan.Android.Controls;

public class OutlinedErrorEditText : TextInputEditText
{
	private const int FullPhoneLength = 11;

	private bool _isError;

	private string _pastedPhone = "";

	private bool _phoneCallbackStarting;

	private bool _plusWritten;

	public bool IsError => _isError;

	public new string? Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			if (!_phoneCallbackStarting)
			{
				base.Text = value;
			}
		}
	}

	public override Drawable? Background
	{
		get
		{
			return base.Background;
		}
		set
		{
			DoNothing(value);
			base.Background = ((!HasFocus) ? (_isError ? base.Context.GetDrawable(2131230930) : base.Context.GetDrawable(2131230920)) : (_isError ? base.Context.GetDrawable(2131230930) : base.Context.GetDrawable(2131230933)));
		}
	}

	protected OutlinedErrorEditText(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public OutlinedErrorEditText(Context context)
		: base(context)
	{
	}

	public OutlinedErrorEditText(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
	}

	public OutlinedErrorEditText(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public void SetupPhoneMask(string mask, string placeholder, TextView placeholderView, Action<bool, string> onPhoneChanged, ILifecycleOwner lifecycleOwner)
	{
		this.InstallMaskedListener(mask, new ValueListener(delegate(bool m, string ex, string form)
		{
			OnPhoneChanged(m, ex, form, onPhoneChanged);
		}));
		base.TextChanged += new DisposableDelegate<EventHandler<TextChangedEventArgs>>(delegate(object? s, TextChangedEventArgs e)
		{
			OnInputTextChanged(s, e, placeholder, placeholderView);
		}, delegate(EventHandler<TextChangedEventArgs> h)
		{
			base.TextChanged -= h;
		}).AutoDisposeOnDestroy(lifecycleOwner);
	}

	private void OnInputTextChanged(object? sender, TextChangedEventArgs e, string placeholder, TextView placeholderView)
	{
		string text = e.Text?.ToString();
		string text2 = MakePlaceHolder(text, placeholder);
		placeholderView.Elevation = 0f;
		if (!string.IsNullOrEmpty(text2))
		{
			placeholderView.Text = text2;
		}
		placeholderView.SetTextColor(string.IsNullOrEmpty(text) ? new Color(ContextCompat.GetColor(base.Context, 2131100604)) : new Color(ContextCompat.GetColor(base.Context, 2131099872)));
		if (text == "+")
		{
			_plusWritten = true;
			Post(new Runnable(delegate
			{
				if (text == "+" && !string.IsNullOrEmpty(Text))
				{
					SetSelection(1, 1);
					placeholderView.Elevation = 10f;
				}
				placeholderView.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100604)));
			}));
		}
		string text3 = "";
		string text4 = text;
		foreach (char c in text4)
		{
			if (char.IsDigit(c))
			{
				text3 += c;
			}
		}
		if (text3.Length > 11 && text.Length != 19 && (text3.Take(3).All((char c3) => c3 == '7') || text3.Skip(1).Take(2).All((char c3) => c3 == '8')))
		{
			_pastedPhone = text3.Remove(1, 1);
		}
		else
		{
			bool flag = text3.Length > 11;
			if (flag)
			{
				char c2 = text3[1];
				bool flag2 = ((c2 == '7' || c2 == '8') ? true : false);
				flag = flag2;
			}
			if (flag && text[7] != ')')
			{
				char c2 = text3[2];
				_pastedPhone = ((c2 != '7' && c2 != '8') ? text3.Remove(0, 2) : ((text3[1] == '8') ? text3.Remove(1, 1) : text3.Remove(0, 1)));
			}
		}
		if (text3.Length > 1 && text3[0] == '8')
		{
			_pastedPhone = "7" + text3.Substring(1);
		}
	}

	private void OnPhoneChanged(bool maskFilled, string extractedValue, string formattedValue, Action<bool, string> callback)
	{
		object obj;
		if (string.IsNullOrWhiteSpace(_pastedPhone))
		{
			int length = extractedValue.Length;
			obj = ((length < 11 && length > 0 && extractedValue[0] == '7') ? ("7" + extractedValue) : extractedValue);
		}
		else
		{
			obj = _pastedPhone;
		}
		string arg = (string)obj;
		if (Text == "8" || (_plusWritten && (extractedValue == "7" || Text == "+87 (")))
		{
			_plusWritten = false;
			Text = "+7 (";
		}
		else if (_plusWritten && Text.Length == 5 && Text[1] != '7')
		{
			_plusWritten = false;
			Text = $"{Text[1]}";
		}
		else
		{
			_phoneCallbackStarting = true;
			callback(maskFilled, arg);
			_phoneCallbackStarting = false;
		}
		bool flag = string.IsNullOrEmpty(extractedValue);
		if (flag)
		{
			bool flag2 = ((formattedValue == "+7 " || formattedValue == "+") ? true : false);
			flag = flag2 || (Text == "7 (" && formattedValue == "+7 (");
		}
		if (flag)
		{
			_plusWritten = false;
			Text = "";
		}
		if (!string.IsNullOrWhiteSpace(_pastedPhone))
		{
			string text = ((_pastedPhone.Length == 10 && _pastedPhone[7] == '7') ? ("7" + _pastedPhone) : _pastedPhone);
			_pastedPhone = "";
			Text = text;
		}
	}

	private string? MakePlaceHolder(string text, string placeholder)
	{
		int num = text?.Length ?? 0;
		if (num > placeholder.Length)
		{
			return null;
		}
		string text2 = placeholder.Substring(num, placeholder.Length - num);
		return text + text2;
	}

	public override bool OnKeyPreIme(Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Back)
		{
			ClearFocus();
		}
		return base.OnKeyPreIme(keyCode, e);
	}

	public void SetError(bool isError)
	{
		_isError = isError;
		Background = base.Context.GetDrawable(2131230930);
	}

	private static void DoNothing(Drawable? drawable)
	{
	}

	public void ResetText(string phoneText)
	{
		if (string.IsNullOrEmpty(phoneText) && !string.IsNullOrEmpty(Text))
		{
			Text = "";
		}
	}
}
