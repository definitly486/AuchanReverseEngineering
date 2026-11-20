using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/MovementMethod", "", "Android.Text.Method.IMovementMethodInvoker")]
public interface IMovementMethod : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("canSelectArbitrarily", "()Z", "GetCanSelectArbitrarilyHandler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool CanSelectArbitrarily();

	[Register("initialize", "(Landroid/widget/TextView;Landroid/text/Spannable;)V", "GetInitialize_Landroid_widget_TextView_Landroid_text_Spannable_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Initialize(TextView? widget, ISpannable? text);

	[Register("onGenericMotionEvent", "(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", "GetOnGenericMotionEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnGenericMotionEvent(TextView? widget, ISpannable? text, MotionEvent? e);

	[Register("onKeyDown", "(Landroid/widget/TextView;Landroid/text/Spannable;ILandroid/view/KeyEvent;)Z", "GetOnKeyDown_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyDown(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e);

	[Register("onKeyOther", "(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/KeyEvent;)Z", "GetOnKeyOther_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_KeyEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyOther(TextView? view, ISpannable? text, KeyEvent? e);

	[Register("onKeyUp", "(Landroid/widget/TextView;Landroid/text/Spannable;ILandroid/view/KeyEvent;)Z", "GetOnKeyUp_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKeyUp(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e);

	[Register("onTakeFocus", "(Landroid/widget/TextView;Landroid/text/Spannable;I)V", "GetOnTakeFocus_Landroid_widget_TextView_Landroid_text_Spannable_IHandler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnTakeFocus(TextView? widget, ISpannable? text, FocusSearchDirection direction);

	[Register("onTouchEvent", "(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnTouchEvent(TextView? widget, ISpannable? text, MotionEvent? e);

	[Register("onTrackballEvent", "(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", "GetOnTrackballEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler:Android.Text.Method.IMovementMethodInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnTrackballEvent(TextView? widget, ISpannable? text, MotionEvent? e);
}
