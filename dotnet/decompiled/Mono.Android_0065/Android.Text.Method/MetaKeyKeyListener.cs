using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/MetaKeyKeyListener", DoNotGenerateAcw = true)]
public abstract class MetaKeyKeyListener : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/MetaKeyKeyListener", typeof(MetaKeyKeyListener));

	private static Delegate? cb_clearMetaKeyState_ClearMetaKeyState_Landroid_view_View_Landroid_text_Editable_I_V;

	private static Delegate? cb_onKeyDown_OnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyUp_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected MetaKeyKeyListener(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
			MetaKeyKeyListener? metaKeyKeyListener = Java.Lang.Object.GetObject<MetaKeyKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable content = Java.Lang.Object.GetObject<IEditable>(native_content, JniHandleOwnership.DoNotTransfer);
			metaKeyKeyListener.ClearMetaKeyState(view, content, (MetaKeyStates)native_states);
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

	public unsafe virtual void ClearMetaKeyState(View? view, IEditable? content, MetaKeyStates states)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
			ptr[2] = new JniArgumentValue((int)states);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearMetaKeyState.(Landroid/view/View;Landroid/text/Editable;I)V", this, ptr);
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
	private static sbyte n_OnKeyDown_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_content, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MetaKeyKeyListener? metaKeyKeyListener = Java.Lang.Object.GetObject<MetaKeyKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable content = Java.Lang.Object.GetObject<IEditable>(native_content, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return metaKeyKeyListener.OnKeyDown(view, content, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool OnKeyDown(View? view, IEditable? content, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyDown.(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(content);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLIL_B(n_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyUp_Landroid_view_View_Landroid_text_Editable_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_content, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MetaKeyKeyListener? metaKeyKeyListener = Java.Lang.Object.GetObject<MetaKeyKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable content = Java.Lang.Object.GetObject<IEditable>(native_content, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return metaKeyKeyListener.OnKeyUp(view, content, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool OnKeyUp(View? view, IEditable? content, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
			ptr[2] = new JniArgumentValue((int)keyCode);
			ptr[3] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyUp.(Landroid/view/View;Landroid/text/Editable;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(content);
			GC.KeepAlive(e);
		}
	}
}
