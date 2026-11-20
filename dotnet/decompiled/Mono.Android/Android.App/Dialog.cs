using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/Dialog", DoNotGenerateAcw = true)]
public class Dialog : Java.Lang.Object, IDialogInterface, IJavaObject, IDisposable, IJavaPeerable, Android.Views.Window.ICallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/Dialog", typeof(Dialog));

	private static Delegate? cb_getCurrentFocus_GetCurrentFocus_Landroid_view_View_;

	private static Delegate? cb_getWindow_GetWindow_Landroid_view_Window_;

	private static Delegate? cb_cancel_Cancel_V;

	private static Delegate? cb_dismiss_Dismiss_V;

	private static Delegate? cb_dispatchGenericMotionEvent_DispatchGenericMotionEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchKeyEvent_DispatchKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_dispatchKeyShortcutEvent_DispatchKeyShortcutEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_dispatchPopulateAccessibilityEvent_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_dispatchTouchEvent_DispatchTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchTrackballEvent_DispatchTrackballEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_findViewById_FindViewById_I_Landroid_view_View_;

	private static Delegate? cb_onActionModeFinished_OnActionModeFinished_Landroid_view_ActionMode__V;

	private static Delegate? cb_onActionModeStarted_OnActionModeStarted_Landroid_view_ActionMode__V;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onContentChanged_OnContentChanged_V;

	private static Delegate? cb_onCreatePanelMenu_OnCreatePanelMenu_ILandroid_view_Menu__Z;

	private static Delegate? cb_onCreatePanelView_OnCreatePanelView_I_Landroid_view_View_;

	private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_V;

	private static Delegate? cb_onMenuItemSelected_OnMenuItemSelected_ILandroid_view_MenuItem__Z;

	private static Delegate? cb_onMenuOpened_OnMenuOpened_ILandroid_view_Menu__Z;

	private static Delegate? cb_onPanelClosed_OnPanelClosed_ILandroid_view_Menu__V;

	private static Delegate? cb_onPreparePanel_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu__Z;

	private static Delegate? cb_onSearchRequested_OnSearchRequested_Z;

	private static Delegate? cb_onSearchRequested_OnSearchRequested_Landroid_view_SearchEvent__Z;

	private static Delegate? cb_onWindowAttributesChanged_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams__V;

	private static Delegate? cb_onWindowFocusChanged_OnWindowFocusChanged_Z_V;

	private static Delegate? cb_onWindowStartingActionMode_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I_Landroid_view_ActionMode_;

	private static Delegate? cb_onWindowStartingActionMode_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback__Landroid_view_ActionMode_;

	private static Delegate? cb_setCancelable_SetCancelable_Z_V;

	private static Delegate? cb_setCanceledOnTouchOutside_SetCanceledOnTouchOutside_Z_V;

	private static Delegate? cb_setOnCancelListener_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener__V;

	private static Delegate? cb_setOnDismissListener_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener__V;

	private static Delegate? cb_setOnKeyListener_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener__V;

	private static Delegate? cb_setOnShowListener_SetOnShowListener_Landroid_content_DialogInterface_OnShowListener__V;

	private static Delegate? cb_show_Show_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Context Context
	{
		[Register("getContext", "()Landroid/content/Context;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual View? CurrentFocus
	{
		[Register("getCurrentFocus", "()Landroid/view/View;", "GetGetCurrentFocusHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentFocus.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Android.Views.Window? Window
	{
		[Register("getWindow", "()Landroid/view/Window;", "GetGetWindowHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.Window>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWindow.()Landroid/view/Window;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public T? FindViewById<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(int id) where T : View
	{
		return Extensions.JavaCast<T>(FindViewById(id));
	}

	protected Dialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetCurrentFocusHandler()
	{
		return new _JniMarshal_PP_L(n_GetCurrentFocus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentFocus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentFocus);
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

	private static Delegate GetGetWindowHandler()
	{
		return new _JniMarshal_PP_L(n_GetWindow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Window);
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

	private static Delegate GetCancelHandler()
	{
		return new _JniMarshal_PP_V(n_Cancel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cancel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
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

	[Register("cancel", "()V", "GetCancelHandler")]
	public unsafe virtual void Cancel()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.()V", this, null);
	}

	private static Delegate GetDismissHandler()
	{
		return new _JniMarshal_PP_V(n_Dismiss);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dismiss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
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

	[Register("dismiss", "()V", "GetDismissHandler")]
	public unsafe virtual void Dismiss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
	}

	private static Delegate GetDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchGenericMotionEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchGenericMotionEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchGenericMotionEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchGenericMotionEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool DispatchGenericMotionEvent(MotionEvent ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchGenericMotionEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}

	private static Delegate GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool DispatchKeyEvent(KeyEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchKeyShortcutEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchKeyShortcutEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchKeyShortcutEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchKeyShortcutEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool DispatchKeyShortcutEvent(KeyEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchKeyShortcutEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchPopulateAccessibilityEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchPopulateAccessibilityEvent", "(Landroid/view/accessibility/AccessibilityEvent;)Z", "GetDispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual bool DispatchPopulateAccessibilityEvent(AccessibilityEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchPopulateAccessibilityEvent.(Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchTouchEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchTouchEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool DispatchTouchEvent(MotionEvent ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}

	private static Delegate GetDispatchTrackballEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchTrackballEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchTrackballEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return dialog.DispatchTrackballEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchTrackballEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchTrackballEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool DispatchTrackballEvent(MotionEvent ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchTrackballEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}

	private static Delegate GetFindViewById_IHandler()
	{
		return new _JniMarshal_PPI_L(n_FindViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewById(id));
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

	[Register("findViewById", "(I)Landroid/view/View;", "GetFindViewById_IHandler")]
	public unsafe virtual View? FindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnActionModeFinished_Landroid_view_ActionMode_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnActionModeFinished_Landroid_view_ActionMode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActionModeFinished_Landroid_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			dialog.OnActionModeFinished(mode);
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

	[Register("onActionModeFinished", "(Landroid/view/ActionMode;)V", "GetOnActionModeFinished_Landroid_view_ActionMode_Handler")]
	public unsafe virtual void OnActionModeFinished(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActionModeFinished.(Landroid/view/ActionMode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mode);
		}
	}

	private static Delegate GetOnActionModeStarted_Landroid_view_ActionMode_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnActionModeStarted_Landroid_view_ActionMode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActionModeStarted_Landroid_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			dialog.OnActionModeStarted(mode);
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

	[Register("onActionModeStarted", "(Landroid/view/ActionMode;)V", "GetOnActionModeStarted_Landroid_view_ActionMode_Handler")]
	public unsafe virtual void OnActionModeStarted(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActionModeStarted.(Landroid/view/ActionMode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mode);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttachedToWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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

	[Register("onAttachedToWindow", "()V", "GetOnAttachedToWindowHandler")]
	public unsafe virtual void OnAttachedToWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
	}

	private static Delegate GetOnContentChangedHandler()
	{
		return new _JniMarshal_PP_V(n_OnContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
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

	[Register("onContentChanged", "()V", "GetOnContentChangedHandler")]
	public unsafe virtual void OnContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
	}

	private static Delegate GetOnCreatePanelMenu_ILandroid_view_Menu_Handler()
	{
		return new _JniMarshal_PPIL_B(n_OnCreatePanelMenu_ILandroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnCreatePanelMenu_ILandroid_view_Menu_(nint jnienv, nint native__this, int featureId, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return dialog.OnCreatePanelMenu(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onCreatePanelMenu", "(ILandroid/view/Menu;)Z", "GetOnCreatePanelMenu_ILandroid_view_Menu_Handler")]
	public unsafe virtual bool OnCreatePanelMenu(int featureId, IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onCreatePanelMenu.(ILandroid/view/Menu;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnCreatePanelView_IHandler()
	{
		return new _JniMarshal_PPI_L(n_OnCreatePanelView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreatePanelView_I(nint jnienv, nint native__this, int featureId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreatePanelView(featureId));
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

	[Register("onCreatePanelView", "(I)Landroid/view/View;", "GetOnCreatePanelView_IHandler")]
	public unsafe virtual View? OnCreatePanelView(int featureId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(featureId);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreatePanelView.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnDetachedFromWindowHandler()
	{
		return new _JniMarshal_PP_V(n_OnDetachedFromWindow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDetachedFromWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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

	[Register("onDetachedFromWindow", "()V", "GetOnDetachedFromWindowHandler")]
	public unsafe virtual void OnDetachedFromWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.()V", this, null);
	}

	private static Delegate GetOnMenuItemSelected_ILandroid_view_MenuItem_Handler()
	{
		return new _JniMarshal_PPIL_B(n_OnMenuItemSelected_ILandroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuItemSelected_ILandroid_view_MenuItem_(nint jnienv, nint native__this, int featureId, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return dialog.OnMenuItemSelected(featureId, item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onMenuItemSelected", "(ILandroid/view/MenuItem;)Z", "GetOnMenuItemSelected_ILandroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnMenuItemSelected(int featureId, IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMenuItemSelected.(ILandroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetOnMenuOpened_ILandroid_view_Menu_Handler()
	{
		return new _JniMarshal_PPIL_B(n_OnMenuOpened_ILandroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuOpened_ILandroid_view_Menu_(nint jnienv, nint native__this, int featureId, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return dialog.OnMenuOpened(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onMenuOpened", "(ILandroid/view/Menu;)Z", "GetOnMenuOpened_ILandroid_view_Menu_Handler")]
	public unsafe virtual bool OnMenuOpened(int featureId, IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMenuOpened.(ILandroid/view/Menu;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPanelClosed_ILandroid_view_Menu_Handler()
	{
		return new _JniMarshal_PPIL_V(n_OnPanelClosed_ILandroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPanelClosed_ILandroid_view_Menu_(nint jnienv, nint native__this, int featureId, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			dialog.OnPanelClosed(featureId, menu);
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

	[Register("onPanelClosed", "(ILandroid/view/Menu;)V", "GetOnPanelClosed_ILandroid_view_Menu_Handler")]
	public unsafe virtual void OnPanelClosed(int featureId, IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPanelClosed.(ILandroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPreparePanel_ILandroid_view_View_Landroid_view_Menu_Handler()
	{
		return new _JniMarshal_PPILL_B(n_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu_(nint jnienv, nint native__this, int featureId, nint native_view, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return dialog.OnPreparePanel(featureId, view, menu) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onPreparePanel", "(ILandroid/view/View;Landroid/view/Menu;)Z", "GetOnPreparePanel_ILandroid_view_View_Landroid_view_Menu_Handler")]
	public unsafe virtual bool OnPreparePanel(int featureId, View? view, IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onPreparePanel.(ILandroid/view/View;Landroid/view/Menu;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnSearchRequestedHandler()
	{
		return new _JniMarshal_PP_B(n_OnSearchRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnSearchRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSearchRequested() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onSearchRequested", "()Z", "GetOnSearchRequestedHandler")]
	public unsafe virtual bool OnSearchRequested()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSearchRequested.()Z", this, null);
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetOnSearchRequested_Landroid_view_SearchEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnSearchRequested_Landroid_view_SearchEvent_);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnSearchRequested_Landroid_view_SearchEvent_(nint jnienv, nint native__this, nint native_searchEvent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SearchEvent searchEvent = Java.Lang.Object.GetObject<SearchEvent>(native_searchEvent, JniHandleOwnership.DoNotTransfer);
			return dialog.OnSearchRequested(searchEvent) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android23.0")]
	[Register("onSearchRequested", "(Landroid/view/SearchEvent;)Z", "GetOnSearchRequested_Landroid_view_SearchEvent_Handler", ApiSince = 23)]
	public unsafe virtual bool OnSearchRequested(SearchEvent searchEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(searchEvent?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSearchRequested.(Landroid/view/SearchEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(searchEvent);
		}
	}

	private static Delegate GetOnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_(nint jnienv, nint native__this, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowManagerLayoutParams windowManagerLayoutParams = Java.Lang.Object.GetObject<WindowManagerLayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			dialog.OnWindowAttributesChanged(windowManagerLayoutParams);
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

	[Register("onWindowAttributesChanged", "(Landroid/view/WindowManager$LayoutParams;)V", "GetOnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_Handler")]
	public unsafe virtual void OnWindowAttributesChanged(WindowManagerLayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onWindowAttributesChanged.(Landroid/view/WindowManager$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetOnWindowFocusChanged_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_OnWindowFocusChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnWindowFocusChanged_Z(nint jnienv, nint native__this, sbyte native_hasFocus)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hasFocus = native_hasFocus != 0;
			dialog.OnWindowFocusChanged(hasFocus);
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

	[Register("onWindowFocusChanged", "(Z)V", "GetOnWindowFocusChanged_ZHandler")]
	public unsafe virtual void OnWindowFocusChanged(bool hasFocus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(hasFocus ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onWindowFocusChanged.(Z)V", this, ptr);
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I(nint jnienv, nint native__this, nint native__callback, int native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(dialog.OnWindowStartingActionMode(callback, (ActionModeType)native_type));
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

	[SupportedOSPlatform("android23.0")]
	[Register("onWindowStartingActionMode", "(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", "GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_IHandler", ApiSince = 23)]
	public unsafe virtual ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback, ActionModeType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[1] = new JniArgumentValue((int)type);
			return Java.Lang.Object.GetObject<ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("onWindowStartingActionMode.(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_Handler()
	{
		return new _JniMarshal_PPL_L(n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(dialog.OnWindowStartingActionMode(callback));
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

	[Register("onWindowStartingActionMode", "(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", "GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_Handler")]
	public unsafe virtual ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("onWindowStartingActionMode.(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetCancelable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetCancelable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCancelable_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool cancelable = native_flag != 0;
			dialog.SetCancelable(cancelable);
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

	[Register("setCancelable", "(Z)V", "GetSetCancelable_ZHandler")]
	public unsafe virtual void SetCancelable(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCancelable.(Z)V", this, ptr);
	}

	private static Delegate GetSetCanceledOnTouchOutside_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetCanceledOnTouchOutside_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCanceledOnTouchOutside_Z(nint jnienv, nint native__this, sbyte native_cancel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool canceledOnTouchOutside = native_cancel != 0;
			dialog.SetCanceledOnTouchOutside(canceledOnTouchOutside);
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

	[Register("setCanceledOnTouchOutside", "(Z)V", "GetSetCanceledOnTouchOutside_ZHandler")]
	public unsafe virtual void SetCanceledOnTouchOutside(bool cancel)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cancel ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCanceledOnTouchOutside.(Z)V", this, ptr);
	}

	private static Delegate GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnCancelListener onCancelListener = Java.Lang.Object.GetObject<IDialogInterfaceOnCancelListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			dialog.SetOnCancelListener(onCancelListener);
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

	[Register("setOnCancelListener", "(Landroid/content/DialogInterface$OnCancelListener;)V", "GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler")]
	public unsafe virtual void SetOnCancelListener(IDialogInterfaceOnCancelListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnCancelListener.(Landroid/content/DialogInterface$OnCancelListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnDismissListener onDismissListener = Java.Lang.Object.GetObject<IDialogInterfaceOnDismissListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			dialog.SetOnDismissListener(onDismissListener);
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

	[Register("setOnDismissListener", "(Landroid/content/DialogInterface$OnDismissListener;)V", "GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler")]
	public unsafe virtual void SetOnDismissListener(IDialogInterfaceOnDismissListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnDismissListener.(Landroid/content/DialogInterface$OnDismissListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_(nint jnienv, nint native__this, nint native_onKeyListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnKeyListener onKeyListener = Java.Lang.Object.GetObject<IDialogInterfaceOnKeyListener>(native_onKeyListener, JniHandleOwnership.DoNotTransfer);
			dialog.SetOnKeyListener(onKeyListener);
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

	[Register("setOnKeyListener", "(Landroid/content/DialogInterface$OnKeyListener;)V", "GetSetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_Handler")]
	public unsafe virtual void SetOnKeyListener(IDialogInterfaceOnKeyListener? onKeyListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onKeyListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onKeyListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnKeyListener.(Landroid/content/DialogInterface$OnKeyListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onKeyListener);
		}
	}

	private static Delegate GetSetOnShowListener_Landroid_content_DialogInterface_OnShowListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnShowListener_Landroid_content_DialogInterface_OnShowListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnShowListener_Landroid_content_DialogInterface_OnShowListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Dialog? dialog = Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnShowListener onShowListener = Java.Lang.Object.GetObject<IDialogInterfaceOnShowListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			dialog.SetOnShowListener(onShowListener);
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

	[Register("setOnShowListener", "(Landroid/content/DialogInterface$OnShowListener;)V", "GetSetOnShowListener_Landroid_content_DialogInterface_OnShowListener_Handler")]
	public unsafe virtual void SetOnShowListener(IDialogInterfaceOnShowListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnShowListener.(Landroid/content/DialogInterface$OnShowListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetShowHandler()
	{
		return new _JniMarshal_PP_V(n_Show);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Dialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
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

	[Register("show", "()V", "GetShowHandler")]
	public unsafe virtual void Show()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
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

	[UnmanagedCallersOnly]
	private static void n_OnAttachedToWindow_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnAttachedToWindow(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
