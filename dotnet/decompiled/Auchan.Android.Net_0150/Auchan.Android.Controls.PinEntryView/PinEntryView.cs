using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Interop;

namespace Auchan.Android.Controls.PinEntryView;

[Register("auchan.PinEntryView")]
internal sealed class PinEntryView : FrameLayout, TextView.IOnEditorActionListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Animation _alphaAnimation = new AlphaAnimation(1f, 0f)
	{
		Duration = 10L,
		RepeatMode = RepeatMode.Reverse,
		StartOffset = 480L,
		StartTime = 0L,
		RepeatCount = -1
	};

	private List<(EditText input, View cursor)> _inputsWithCursors;

	public EditText InputField { get; private set; }

	private int PinMaxLength => _inputsWithCursors.Count;

	public IOnPinEnteringResultListener ResultListener { get; set; }

	public string Placeholder
	{
		get
		{
			return _inputsWithCursors[0].input.Hint;
		}
		set
		{
			foreach (var inputsWithCursor in _inputsWithCursors)
			{
				inputsWithCursor.input.Hint = value;
			}
		}
	}

	protected PinEntryView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PinEntryView(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PinEntryView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PinEntryView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	protected override void OnDetachedFromWindow()
	{
		base.OnDetachedFromWindow();
		foreach (var inputsWithCursor in _inputsWithCursors)
		{
			inputsWithCursor.input.TextChanged -= TextChanged;
		}
	}

	public override bool OnInterceptTouchEvent(MotionEvent ev)
	{
		FocusEditTextAndOpenKeyboard();
		return true;
	}

	public override bool RequestFocus(FocusSearchDirection direction, Rect previouslyFocusedRect)
	{
		FocusEditTextAndOpenKeyboard();
		return true;
	}

	public void Reset()
	{
		for (int i = 0; i < _inputsWithCursors.Count; i++)
		{
			UnfocusInput(i);
			_inputsWithCursors[i].input.Text = string.Empty;
		}
		InputField.Text = string.Empty;
	}

	private void Initialize(Context context)
	{
		View view = View.Inflate(context, 2131493438, this);
		_inputsWithCursors = new List<(EditText, View)>
		{
			(view.RequireViewById<EditText>(2131297909), view.RequireViewById<View>(2131297908)),
			(view.RequireViewById<EditText>(2131297917), view.RequireViewById<View>(2131297916)),
			(view.RequireViewById<EditText>(2131297919), view.RequireViewById<View>(2131297918)),
			(view.RequireViewById<EditText>(2131297911), view.RequireViewById<View>(2131297910))
		};
		InputField = view.RequireViewById<EditText>(2131297371);
		InputField.SetOnEditorActionListener(this);
		InputField.TextChanged += TextChanged;
	}

	private void FocusEditTextAndOpenKeyboard()
	{
		if (InputField.Text.Length < PinMaxLength)
		{
			FocusInput(InputField.Text.Length);
		}
		InputField.RequestFocus();
		InputMethodManager.FromContext(base.Context).ShowSoftInput(InputField, ShowFlags.Implicit);
	}

	private void TextChanged(object sender, TextChangedEventArgs e)
	{
		for (int i = 0; i < _inputsWithCursors.Count; i++)
		{
			UnfocusInput(i);
			_inputsWithCursors[i].input.Text = ((i < InputField.Text.Length) ? InputField.Text.Substring(i, 1) : string.Empty);
		}
		if (InputField.Text.Length >= PinMaxLength)
		{
			OnResult();
		}
		else
		{
			FocusInput(InputField.Text.Length);
		}
	}

	private void OnResult()
	{
		string text = string.Empty;
		foreach (var inputsWithCursor in _inputsWithCursors)
		{
			text += inputsWithCursor.input.Text;
		}
		if (ResultListener != null)
		{
			ResultListener.OnResult(text);
		}
	}

	bool TextView.IOnEditorActionListener.OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
	{
		return true;
	}

	private void FocusInput(int index)
	{
		_inputsWithCursors[index].cursor.StartAnimation(_alphaAnimation);
		_inputsWithCursors[index].cursor.Visibility = ViewStates.Visible;
	}

	private void UnfocusInput(int index)
	{
		_inputsWithCursors[index].cursor.ClearAnimation();
		_inputsWithCursors[index].cursor.Visibility = ViewStates.Gone;
	}
}
