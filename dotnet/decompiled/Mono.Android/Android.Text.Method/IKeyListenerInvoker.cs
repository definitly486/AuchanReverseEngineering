using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/KeyListener", DoNotGenerateAcw = true)]
internal class IKeyListenerInvoker : Java.Lang.Object, IKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_method_KeyListener = new XAPeerMembers("android/text/method/KeyListener", typeof(IKeyListenerInvoker));

	private static Delegate? cb_getInputType_GetInputType_I;

	private static Delegate? cb_clearMetaKeyState_ClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_I_V;

	private static Delegate? cb_onKeyDown_OnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyOther_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyUp_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_method_KeyListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_method_KeyListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_method_KeyListener.ManagedPeerType;

	public unsafe InputTypes InputType => (InputTypes)_members_android_text_method_KeyListener.InstanceMethods.InvokeAbstractInt32Method("getInputType.()I", this, null);

	public IKeyListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetInputTypeHandler()
	{
		return new _JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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

	private static Delegate GetClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_IHandler()
	{
		return new _JniMarshal_PPLLI_V(n_ClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_I(nint jnienv, nint native__this, nint native_view, nint native_content, int native_states)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IKeyListener? keyListener = Java.Lang.Object.GetObject<IKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable content = Java.Lang.Object.GetObject<IEditable>(native_content, JniHandleOwnership.DoNotTransfer);
			keyListener.ClearMetaKeyState(view, content, (MetaKeyStates)native_states);
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

	public unsafe void ClearMetaKeyState(View? view, IEditable? content, MetaKeyStates states)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
			ptr[2] = new JniArgumentValue((int)states);
			_members_android_text_method_KeyListener.InstanceMethods.InvokeAbstractVoidMethod("clearMetaKeyState.(Landroid/view/View;Landroid/text/Editable;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(content);
		}
	}

	private static Delegate GetOnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLIL_B(n_OnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_text, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKeyListener? keyListener = Java.Lang.Object.GetObject<IKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable text = Java.Lang.Object.GetObject<IEditable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return keyListener.OnKeyDown(view, text, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnKeyDown(View? view, IEditable? text, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_KeyListener.InstanceMethods.InvokeAbstractBooleanMethod("onKeyDown.(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_text, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKeyListener? keyListener = Java.Lang.Object.GetObject<IKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable text = Java.Lang.Object.GetObject<IEditable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return keyListener.OnKeyOther(view, text, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnKeyOther(View? view, IEditable? text, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_KeyListener.InstanceMethods.InvokeAbstractBooleanMethod("onKeyOther.(Landroid/view/View;Landroid/text/Editable;Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(text);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLIL_B(n_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_text, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKeyListener? keyListener = Java.Lang.Object.GetObject<IKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable text = Java.Lang.Object.GetObject<IEditable>(native_text, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return keyListener.OnKeyUp(view, text, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnKeyUp(View? view, IEditable? text, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_text_method_KeyListener.InstanceMethods.InvokeAbstractBooleanMethod("onKeyUp.(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
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
