using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/MovementMethod", DoNotGenerateAcw = true)]
internal class IMovementMethodInvoker : Java.Lang.Object, IMovementMethod, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_method_MovementMethod = new XAPeerMembers("android/text/method/MovementMethod", typeof(IMovementMethodInvoker));

	private static Delegate? cb_canSelectArbitrarily_CanSelectArbitrarily_Z;

	private static Delegate? cb_initialize_Initialize_Landroid_widget_TextView_Landroid_text_Spannable__V;

	private static Delegate? cb_onGenericMotionEvent_OnGenericMotionEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onKeyDown_OnKeyDown_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyOther_OnKeyOther_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyUp_OnKeyUp_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onTakeFocus_OnTakeFocus_Landroid_widget_TextView_Landroid_text_Spannable_I_V;

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onTrackballEvent_OnTrackballEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_method_MovementMethod;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_method_MovementMethod.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_method_MovementMethod.ManagedPeerType;

	public IMovementMethodInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCanSelectArbitrarilyHandler()
	{
		return new _JniMarshal_PP_B(n_CanSelectArbitrarily);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanSelectArbitrarily(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanSelectArbitrarily() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool CanSelectArbitrarily()
	{
		return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("canSelectArbitrarily.()Z", this, null);
	}

	private static Delegate GetInitialize_Landroid_widget_TextView_Landroid_text_Spannable_Handler()
	{
		return new _JniMarshal_PPLL_V(n_Initialize_Landroid_widget_TextView_Landroid_text_Spannable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Initialize_Landroid_widget_TextView_Landroid_text_Spannable_(nint jnienv, nint native__this, nint native_widget, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			movementMethod.Initialize(widget, text);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Initialize(TextView? widget, ISpannable? text)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			_members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractVoidMethod("initialize.(Landroid/widget/TextView;Landroid/text/Spannable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetOnGenericMotionEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnGenericMotionEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnGenericMotionEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_widget, nint native_text, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnGenericMotionEvent(widget, text, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnGenericMotionEvent(TextView? widget, ISpannable? text, MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onGenericMotionEvent.(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyDown_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLIL_B(n_OnKeyDown_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyDown_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_widget, nint native_text, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnKeyDown(widget, text, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnKeyDown(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onKeyDown.(Landroid/widget/TextView;Landroid/text/Spannable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyOther_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnKeyOther_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyOther_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_text, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView view = Java.Lang.Object.GetObject<TextView>(native_view, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnKeyOther(view, text, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnKeyOther(TextView? view, ISpannable? text, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onKeyOther.(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyUp_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLIL_B(n_OnKeyUp_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyUp_Landroid_widget_TextView_Landroid_text_Spannable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_widget, nint native_text, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnKeyUp(widget, text, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnKeyUp(TextView? widget, ISpannable? text, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onKeyUp.(Landroid/widget/TextView;Landroid/text/Spannable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnTakeFocus_Landroid_widget_TextView_Landroid_text_Spannable_IHandler()
	{
		return new _JniMarshal_PPLLI_V(n_OnTakeFocus_Landroid_widget_TextView_Landroid_text_Spannable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTakeFocus_Landroid_widget_TextView_Landroid_text_Spannable_I(nint jnienv, nint native__this, nint native_widget, nint native_text, int native_direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			movementMethod.OnTakeFocus(widget, text, (FocusSearchDirection)native_direction);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void OnTakeFocus(TextView? widget, ISpannable? text, FocusSearchDirection direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue((int)direction);
			_members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractVoidMethod("onTakeFocus.(Landroid/widget/TextView;Landroid/text/Spannable;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetOnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_widget, nint native_text, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnTouchEvent(widget, text, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnTouchEvent(TextView? widget, ISpannable? text, MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onTouchEvent.(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnTrackballEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnTrackballEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTrackballEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_widget, nint native_text, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMovementMethod? movementMethod = Java.Lang.Object.GetObject<IMovementMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextView widget = Java.Lang.Object.GetObject<TextView>(native_widget, JniHandleOwnership.DoNotTransfer);
			ISpannable text = Java.Lang.Object.GetObject<ISpannable>(native_text, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return movementMethod.OnTrackballEvent(widget, text, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnTrackballEvent(TextView? widget, ISpannable? text, MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_MovementMethod.InstanceMethods.InvokeAbstractBooleanMethod("onTrackballEvent.(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
