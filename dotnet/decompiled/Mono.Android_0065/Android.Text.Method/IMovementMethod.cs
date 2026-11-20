using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/MovementMethod", "", "Android.Text.Method.IMovementMethodInvoker")]
public interface IMovementMethod : IJavaObject, IDisposable, IJavaPeerable
{
	bool CanSelectArbitrarily();

	void Initialize(TextView? widget, ISpannable? text);

	bool OnGenericMotionEvent(TextView? widget, ISpannable? text, MotionEvent? e);

	bool OnKeyDown(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e);

	bool OnKeyOther(TextView? view, ISpannable? text, KeyEvent? e);

	bool OnKeyUp(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e);

	void OnTakeFocus(TextView? widget, ISpannable? text, FocusSearchDirection direction);

	bool OnTouchEvent(TextView? widget, ISpannable? text, MotionEvent? e);

	bool OnTrackballEvent(TextView? widget, ISpannable? text, MotionEvent? e);
}
