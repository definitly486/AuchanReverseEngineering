using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/KeyListener", "", "Android.Text.Method.IKeyListenerInvoker")]
public interface IKeyListener : IJavaObject, IDisposable, IJavaPeerable
{
	InputTypes InputType { get; }

	void ClearMetaKeyState(View? view, IEditable? content, MetaKeyStates states);

	bool OnKeyDown(View? view, IEditable? text, Keycode keyCode, KeyEvent? e);

	bool OnKeyOther(View? view, IEditable? text, KeyEvent? e);

	bool OnKeyUp(View? view, IEditable? text, Keycode keyCode, KeyEvent? e);
}
