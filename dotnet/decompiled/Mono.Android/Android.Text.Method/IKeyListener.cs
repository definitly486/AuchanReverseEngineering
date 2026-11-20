using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/KeyListener", "", "Android.Text.Method.IKeyListenerInvoker")]
public interface IKeyListener : IJavaObject, IDisposable, IJavaPeerable
{
	InputTypes InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler:Android.Text.Method.IKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("clearMetaKeyState", "(Landroid/view/View;Landroid/text/Editable;I)V", "GetClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_IHandler:Android.Text.Method.IKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ClearMetaKeyState(View? view, IEditable? content, MetaKeyStates states);

	[Register("onKeyDown", "(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", "GetOnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_Handler:Android.Text.Method.IKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyDown(View? view, IEditable? text, Keycode keyCode, KeyEvent? e);

	[Register("onKeyOther", "(Landroid/view/View;Landroid/text/Editable;Landroid/view/KeyEvent;)Z", "GetOnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_Handler:Android.Text.Method.IKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyOther(View? view, IEditable? text, KeyEvent? e);

	[Register("onKeyUp", "(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", "GetOnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_Handler:Android.Text.Method.IKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyUp(View? view, IEditable? text, Keycode keyCode, KeyEvent? e);
}
