using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/Activity", DoNotGenerateAcw = true)]
public class Activity : ContextThemeWrapper, IJavaObject, IDisposable, IJavaPeerable, Android.Views.Window.ICallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/Activity", typeof(Activity));

	private static Delegate? cb_getCurrentFocus_GetCurrentFocus_Landroid_view_View_;

	private static Delegate? cb_getIntent_GetIntent_Landroid_content_Intent_;

	private static Delegate? cb_setIntent_SetIntent_Landroid_content_Intent__V;

	private static Delegate? cb_isDestroyed_IsDestroyed_Z;

	private static Delegate? cb_isFinishing_IsFinishing_Z;

	private static Delegate? cb_getWindow_GetWindow_Landroid_view_Window_;

	private static Delegate? cb_getWindowManager_GetWindowManager_Landroid_view_WindowManager_;

	private static Delegate? cb_dispatchGenericMotionEvent_DispatchGenericMotionEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchKeyEvent_DispatchKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_dispatchKeyShortcutEvent_DispatchKeyShortcutEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_dispatchPopulateAccessibilityEvent_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_dispatchTouchEvent_DispatchTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchTrackballEvent_DispatchTrackballEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_findViewById_FindViewById_I_Landroid_view_View_;

	private static Delegate? cb_finish_Finish_V;

	private static Delegate? cb_finishAffinity_FinishAffinity_V;

	private static Delegate? cb_onActionModeFinished_OnActionModeFinished_Landroid_view_ActionMode__V;

	private static Delegate? cb_onActionModeStarted_OnActionModeStarted_Landroid_view_ActionMode__V;

	private static Delegate? cb_onActivityResult_OnActivityResult_IILandroid_content_Intent__V;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onBackPressed_OnBackPressed_V;

	private static Delegate? cb_onContentChanged_OnContentChanged_V;

	private static Delegate? cb_onCreate_OnCreate_Landroid_os_Bundle__V;

	private static Delegate? cb_onCreatePanelMenu_OnCreatePanelMenu_ILandroid_view_Menu__Z;

	private static Delegate? cb_onCreatePanelView_OnCreatePanelView_I_Landroid_view_View_;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_V;

	private static Delegate? cb_onMenuItemSelected_OnMenuItemSelected_ILandroid_view_MenuItem__Z;

	private static Delegate? cb_onMenuOpened_OnMenuOpened_ILandroid_view_Menu__Z;

	private static Delegate? cb_onNewIntent_OnNewIntent_Landroid_content_Intent__V;

	private static Delegate? cb_onPanelClosed_OnPanelClosed_ILandroid_view_Menu__V;

	private static Delegate? cb_onPreparePanel_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu__Z;

	private static Delegate? cb_onProvideKeyboardShortcuts_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I_V;

	private static Delegate? cb_onRequestPermissionsResult_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI_V;

	private static Delegate? cb_onResume_OnResume_V;

	private static Delegate? cb_onRetainNonConfigurationInstance_OnRetainNonConfigurationInstance_Ljava_lang_Object_;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Bundle__V;

	private static Delegate? cb_onSearchRequested_OnSearchRequested_Z;

	private static Delegate? cb_onSearchRequested_OnSearchRequested_Landroid_view_SearchEvent__Z;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onUserInteraction_OnUserInteraction_V;

	private static Delegate? cb_onWindowAttributesChanged_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams__V;

	private static Delegate? cb_onWindowFocusChanged_OnWindowFocusChanged_Z_V;

	private static Delegate? cb_onWindowStartingActionMode_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I_Landroid_view_ActionMode_;

	private static Delegate? cb_onWindowStartingActionMode_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback__Landroid_view_ActionMode_;

	private static Delegate? cb_setContentView_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_setContentView_SetContentView_Landroid_view_View__V;

	private static Delegate? cb_setContentView_SetContentView_I_V;

	private static Delegate? cb_startActivityForResult_StartActivityForResult_Landroid_content_Intent_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual View? CurrentFocus => Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentFocus.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual Intent? Intent
	{
		get
		{
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIntent.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIntent.(Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool IsDestroyed => _members.InstanceMethods.InvokeVirtualBooleanMethod("isDestroyed.()Z", this, null);

	public unsafe virtual bool IsFinishing => _members.InstanceMethods.InvokeVirtualBooleanMethod("isFinishing.()Z", this, null);

	public unsafe ICharSequence? TitleFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public unsafe virtual Android.Views.Window? Window => Java.Lang.Object.GetObject<Android.Views.Window>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWindow.()Landroid/view/Window;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual IWindowManager? WindowManager => Java.Lang.Object.GetObject<IWindowManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWindowManager.()Landroid/view/WindowManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public T? FindViewById<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(int id) where T : View
	{
		return Extensions.JavaCast<T>(FindViewById(id));
	}

	public T RequireViewById<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(int id) where T : View
	{
		return FindViewById<T>(id) ?? throw new IllegalArgumentException($"Parameter 'id' of value 0x{id:X} does not reference a View of type '{typeof(T)}' inside this Activity");
	}

	public void RunOnUiThread(System.Action action)
	{
		RunOnUiThread(new Thread.RunnableImplementor(action));
	}

	protected Activity(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Activity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentFocus);
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

	private static Delegate GetGetIntentHandler()
	{
		return new _JniMarshal_PP_L(n_GetIntent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIntent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Intent);
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

	private static Delegate GetSetIntent_Landroid_content_Intent_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetIntent_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIntent_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_newIntent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_newIntent, JniHandleOwnership.DoNotTransfer);
			activity.Intent = intent;
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

	private static Delegate GetIsDestroyedHandler()
	{
		return new _JniMarshal_PP_B(n_IsDestroyed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDestroyed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDestroyed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsFinishingHandler()
	{
		return new _JniMarshal_PP_B(n_IsFinishing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFinishing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFinishing ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Window);
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

	private static Delegate GetGetWindowManagerHandler()
	{
		return new _JniMarshal_PP_L(n_GetWindowManager);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWindowManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowManager);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchGenericMotionEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchGenericMotionEvent(MotionEvent? ev)
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchKeyEvent(KeyEvent? e)
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchKeyShortcutEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchKeyShortcutEvent(KeyEvent? e)
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchPopulateAccessibilityEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchPopulateAccessibilityEvent(AccessibilityEvent? e)
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchTouchEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchTouchEvent(MotionEvent? ev)
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return activity.DispatchTrackballEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool DispatchTrackballEvent(MotionEvent? ev)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewById(id));
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

	public unsafe virtual View? FindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFinishHandler()
	{
		return new _JniMarshal_PP_V(n_Finish);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Finish(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Finish();
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

	public unsafe virtual void Finish()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("finish.()V", this, null);
	}

	private static Delegate GetFinishAffinityHandler()
	{
		return new _JniMarshal_PP_V(n_FinishAffinity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FinishAffinity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinishAffinity();
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

	public unsafe virtual void FinishAffinity()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("finishAffinity.()V", this, null);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			activity.OnActionModeFinished(mode);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			activity.OnActionModeStarted(mode);
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
	private static void n_OnActivityResult_IILandroid_content_Intent_(nint jnienv, nint native__this, int requestCode, int native_resultCode, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
			activity.OnActivityResult(requestCode, (Result)native_resultCode, data);
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

	protected unsafe virtual void OnActivityResult(int requestCode, Result resultCode, Intent? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue((int)resultCode);
			ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityResult.(IILandroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetOnAttachedToWindowHandler()
	{
		return new _JniMarshal_PP_V(n_OnAttachedToWindow);
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
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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

	public unsafe virtual void OnAttachedToWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
	}

	[ObsoletedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnBackPressed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackPressed();
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

	[ObsoletedOSPlatform("android33.0")]
	public unsafe virtual void OnBackPressed()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onBackPressed.()V", this, null);
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
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
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

	public unsafe virtual void OnContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreate_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			activity.OnCreate(savedInstanceState);
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

	protected unsafe virtual void OnCreate(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return activity.OnCreatePanelMenu(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreatePanelView(featureId));
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

	public unsafe virtual View? OnCreatePanelView(int featureId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(featureId);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreatePanelView.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	protected unsafe virtual void OnDestroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
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
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return activity.OnMenuItemSelected(featureId, item) ? ((sbyte)1) : ((sbyte)0);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return activity.OnMenuOpened(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNewIntent_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			activity.OnNewIntent(intent);
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

	protected unsafe virtual void OnNewIntent(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNewIntent.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			activity.OnPanelClosed(featureId, menu);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			return activity.OnPreparePanel(featureId, view, menu) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetOnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_IHandler()
	{
		return new _JniMarshal_PPLLI_V(n_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I(nint jnienv, nint native__this, nint native_data, nint native_menu, int deviceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<KeyboardShortcutGroup> data = JavaList<KeyboardShortcutGroup>.FromJniHandle(native_data, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			activity.OnProvideKeyboardShortcuts(data, menu, deviceId);
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

	[SupportedOSPlatform("android24.0")]
	public unsafe virtual void OnProvideKeyboardShortcuts(IList<KeyboardShortcutGroup>? data, IMenu? menu, int deviceId)
	{
		nint num = JavaList<KeyboardShortcutGroup>.ToLocalJniHandle(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			ptr[2] = new JniArgumentValue(deviceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onProvideKeyboardShortcuts.(Ljava/util/List;Landroid/view/Menu;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(data);
			GC.KeepAlive(menu);
		}
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(nint jnienv, nint native__this, int requestCode, nint native_permissions, nint native_grantResults)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			Permission[] array2 = (Permission[])JNIEnv.GetArray(native_grantResults, JniHandleOwnership.DoNotTransfer, typeof(Permission));
			activity.OnRequestPermissionsResult(requestCode, array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_grantResults);
			}
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

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		nint num = JNIEnv.NewArray(permissions);
		nint num2 = JNIEnv.NewArray(grantResults);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRequestPermissionsResult.(I[Ljava/lang/String;[I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(num, permissions);
				JNIEnv.DeleteLocalRef(num);
			}
			if (grantResults != null)
			{
				JNIEnv.CopyArray(num2, grantResults);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(permissions);
			GC.KeepAlive(grantResults);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResume(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResume();
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

	protected unsafe virtual void OnResume()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onResume.()V", this, null);
	}

	private static Delegate GetOnRetainNonConfigurationInstanceHandler()
	{
		return new _JniMarshal_PP_L(n_OnRetainNonConfigurationInstance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnRetainNonConfigurationInstance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRetainNonConfigurationInstance());
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

	public unsafe virtual Java.Lang.Object? OnRetainNonConfigurationInstance()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("onRetainNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSaveInstanceState_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_outState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
			activity.OnSaveInstanceState(outState);
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

	protected unsafe virtual void OnSaveInstanceState(Bundle outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
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
			return Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSearchRequested() ? ((sbyte)1) : ((sbyte)0);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SearchEvent searchEvent = Java.Lang.Object.GetObject<SearchEvent>(native_searchEvent, JniHandleOwnership.DoNotTransfer);
			return activity.OnSearchRequested(searchEvent) ? ((sbyte)1) : ((sbyte)0);
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
	public unsafe virtual bool OnSearchRequested(SearchEvent? searchEvent)
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	protected unsafe virtual void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnUserInteraction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnUserInteraction();
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

	public unsafe virtual void OnUserInteraction()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onUserInteraction.()V", this, null);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowManagerLayoutParams windowManagerLayoutParams = Java.Lang.Object.GetObject<WindowManagerLayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			activity.OnWindowAttributesChanged(windowManagerLayoutParams);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hasFocus = native_hasFocus != 0;
			activity.OnWindowFocusChanged(hasFocus);
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activity.OnWindowStartingActionMode(callback, (ActionModeType)native_type));
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
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activity.OnWindowStartingActionMode(callback));
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

	public unsafe void RunOnUiThread(IRunnable? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("runOnUiThread.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_view, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams layoutParams = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			activity.SetContentView(view, layoutParams);
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

	public unsafe virtual void SetContentView(View? view, ViewGroup.LayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentView.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@params);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View contentView = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			activity.SetContentView(contentView);
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

	public unsafe virtual void SetContentView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_I(nint jnienv, nint native__this, int layoutResID)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentView(layoutResID);
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

	public unsafe virtual void SetContentView(int layoutResID)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(layoutResID);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentView.(I)V", this, ptr);
	}

	public unsafe void SetResult(Result resultCode, Intent? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)resultCode);
			ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setResult.(ILandroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetStartActivityForResult_Landroid_content_Intent_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_StartActivityForResult_Landroid_content_Intent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivityForResult_Landroid_content_Intent_I(nint jnienv, nint native__this, nint native_intent, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Activity? activity = Java.Lang.Object.GetObject<Activity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			activity.StartActivityForResult(intent, requestCode);
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

	public unsafe virtual void StartActivityForResult(Intent? intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
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

	[UnmanagedCallersOnly]
	private static void n_OnCreate_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCreate_Landroid_os_Bundle_(jnienv, native__this, native_savedInstanceState);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnResume_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnResume(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnNewIntent_Landroid_content_Intent__mm_wrapper(nint jnienv, nint native__this, nint native_intent)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnNewIntent_Landroid_content_Intent_(jnienv, native__this, native_intent);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnSaveInstanceState_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_outState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnSaveInstanceState_Landroid_os_Bundle_(jnienv, native__this, native_outState);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnActivityResult_IILandroid_content_Intent__mm_wrapper(nint jnienv, nint native__this, int requestCode, int native_resultCode, nint native_data)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnActivityResult_IILandroid_content_Intent_(jnienv, native__this, requestCode, native_resultCode, native_data);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDestroy_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDestroy(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI_mm_wrapper(nint jnienv, nint native__this, int requestCode, nint native_permissions, nint native_grantResults)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(jnienv, native__this, requestCode, native_permissions, native_grantResults);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStop_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStop(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native__params)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(jnienv, native__this, native_view, native__params);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetContentView_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_view)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetContentView_Landroid_view_View_(jnienv, native__this, native_view);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetContentView_I_mm_wrapper(nint jnienv, nint native__this, int layoutResID)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetContentView_I(jnienv, native__this, layoutResID);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnUserInteraction_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnUserInteraction(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnBackPressed_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnBackPressed(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
