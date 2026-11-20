using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/Window", DoNotGenerateAcw = true)]
public abstract class Window : Java.Lang.Object
{
	[Register("android/view/Window$Callback", "", "Android.Views.Window/ICallbackInvoker")]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/Window$Callback", typeof(ICallback), isInterface: true);

		private static Delegate? cb_onPointerCaptureChanged_OnPointerCaptureChanged_Z_V;

		private static Delegate? cb_onProvideKeyboardShortcuts_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I_V;

		[Register("dispatchGenericMotionEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchGenericMotionEvent(MotionEvent? e);

		[Register("dispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchKeyEvent(KeyEvent? e);

		[Register("dispatchKeyShortcutEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchKeyShortcutEvent(KeyEvent? e);

		[Register("dispatchPopulateAccessibilityEvent", "(Landroid/view/accessibility/AccessibilityEvent;)Z", "GetDispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchPopulateAccessibilityEvent(AccessibilityEvent? e);

		[Register("dispatchTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchTouchEvent(MotionEvent? e);

		[Register("dispatchTrackballEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchTrackballEvent_Landroid_view_MotionEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool DispatchTrackballEvent(MotionEvent? e);

		[Register("onActionModeFinished", "(Landroid/view/ActionMode;)V", "GetOnActionModeFinished_Landroid_view_ActionMode_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActionModeFinished(ActionMode? mode);

		[Register("onActionModeStarted", "(Landroid/view/ActionMode;)V", "GetOnActionModeStarted_Landroid_view_ActionMode_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActionModeStarted(ActionMode? mode);

		[Register("onAttachedToWindow", "()V", "GetOnAttachedToWindowHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAttachedToWindow();

		[Register("onContentChanged", "()V", "GetOnContentChangedHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnContentChanged();

		[Register("onCreatePanelMenu", "(ILandroid/view/Menu;)Z", "GetOnCreatePanelMenu_ILandroid_view_Menu_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnCreatePanelMenu(int featureId, IMenu menu);

		[Register("onCreatePanelView", "(I)Landroid/view/View;", "GetOnCreatePanelView_IHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		View? OnCreatePanelView(int featureId);

		[Register("onDetachedFromWindow", "()V", "GetOnDetachedFromWindowHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnDetachedFromWindow();

		[Register("onMenuItemSelected", "(ILandroid/view/MenuItem;)Z", "GetOnMenuItemSelected_ILandroid_view_MenuItem_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnMenuItemSelected(int featureId, IMenuItem item);

		[Register("onMenuOpened", "(ILandroid/view/Menu;)Z", "GetOnMenuOpened_ILandroid_view_Menu_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnMenuOpened(int featureId, IMenu menu);

		[Register("onPanelClosed", "(ILandroid/view/Menu;)V", "GetOnPanelClosed_ILandroid_view_Menu_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnPanelClosed(int featureId, IMenu menu);

		[Register("onPreparePanel", "(ILandroid/view/View;Landroid/view/Menu;)Z", "GetOnPreparePanel_ILandroid_view_View_Landroid_view_Menu_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnPreparePanel(int featureId, View? view, IMenu menu);

		[Register("onSearchRequested", "()Z", "GetOnSearchRequestedHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnSearchRequested();

		[SupportedOSPlatform("android23.0")]
		[Register("onSearchRequested", "(Landroid/view/SearchEvent;)Z", "GetOnSearchRequested_Landroid_view_SearchEvent_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 23)]
		bool OnSearchRequested(SearchEvent? searchEvent);

		[Register("onWindowAttributesChanged", "(Landroid/view/WindowManager$LayoutParams;)V", "GetOnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnWindowAttributesChanged(WindowManagerLayoutParams? attrs);

		[Register("onWindowFocusChanged", "(Z)V", "GetOnWindowFocusChanged_ZHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnWindowFocusChanged(bool hasFocus);

		[SupportedOSPlatform("android23.0")]
		[Register("onWindowStartingActionMode", "(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", "GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_IHandler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 23)]
		ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback, ActionModeType type);

		[Register("onWindowStartingActionMode", "(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", "GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_Handler:Android.Views.Window/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback);

		[SupportedOSPlatform("android26.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnPointerCaptureChanged_Z(nint jnienv, nint native__this, sbyte native_hasCapture)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool hasCapture = native_hasCapture != 0;
				callback.OnPointerCaptureChanged(hasCapture);
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

		[SupportedOSPlatform("android26.0")]
		[Register("onPointerCaptureChanged", "(Z)V", "GetOnPointerCaptureChanged_ZHandler:Android.Views.Window/ICallback, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		unsafe void OnPointerCaptureChanged(bool hasCapture)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(hasCapture ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPointerCaptureChanged.(Z)V", this, ptr);
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<KeyboardShortcutGroup> data = JavaList<KeyboardShortcutGroup>.FromJniHandle(native_data, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				callback.OnProvideKeyboardShortcuts(data, menu, deviceId);
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
		[Register("onProvideKeyboardShortcuts", "(Ljava/util/List;Landroid/view/Menu;I)V", "GetOnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_IHandler:Android.Views.Window/ICallback, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
		unsafe void OnProvideKeyboardShortcuts(IList<KeyboardShortcutGroup>? data, IMenu? menu, int deviceId)
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

		[UnmanagedCallersOnly]
		private static void n_OnPointerCaptureChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_hasCapture)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnPointerCaptureChanged_Z(jnienv, native__this, native_hasCapture);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I_mm_wrapper(nint jnienv, nint native__this, nint native_data, nint native_menu, int deviceId)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnProvideKeyboardShortcuts_Ljava_util_List_Landroid_view_Menu_I(jnienv, native__this, native_data, native_menu, deviceId);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("android/view/Window$Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_Window_Callback = new XAPeerMembers("android/view/Window$Callback", typeof(ICallbackInvoker));

		private static Delegate? cb_dispatchGenericMotionEvent_DispatchGenericMotionEvent_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_dispatchKeyEvent_DispatchKeyEvent_Landroid_view_KeyEvent__Z;

		private static Delegate? cb_dispatchKeyShortcutEvent_DispatchKeyShortcutEvent_Landroid_view_KeyEvent__Z;

		private static Delegate? cb_dispatchPopulateAccessibilityEvent_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent__Z;

		private static Delegate? cb_dispatchTouchEvent_DispatchTouchEvent_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_dispatchTrackballEvent_DispatchTrackballEvent_Landroid_view_MotionEvent__Z;

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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_Window_Callback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_Window_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_Window_Callback.ManagedPeerType;

		public ICallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_DispatchGenericMotionEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchGenericMotionEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchGenericMotionEvent(MotionEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchGenericMotionEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchKeyEvent(KeyEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchKeyShortcutEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchKeyShortcutEvent(KeyEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchKeyShortcutEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchPopulateAccessibilityEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchPopulateAccessibilityEvent(AccessibilityEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchPopulateAccessibilityEvent.(Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_DispatchTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchTouchEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchTouchEvent(MotionEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_DispatchTrackballEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return callback.DispatchTrackballEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool DispatchTrackballEvent(MotionEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("dispatchTrackballEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				callback.OnActionModeFinished(mode);
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

		public unsafe void OnActionModeFinished(ActionMode? mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onActionModeFinished.(Landroid/view/ActionMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				callback.OnActionModeStarted(mode);
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

		public unsafe void OnActionModeStarted(ActionMode? mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onActionModeStarted.(Landroid/view/ActionMode;)V", this, ptr);
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
				Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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

		public unsafe void OnAttachedToWindow()
		{
			_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onAttachedToWindow.()V", this, null);
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
				Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
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

		public unsafe void OnContentChanged()
		{
			_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onContentChanged.()V", this, null);
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnCreatePanelMenu(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnCreatePanelMenu(int featureId, IMenu menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(featureId);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onCreatePanelMenu.(ILandroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(menu);
			}
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreatePanelView(featureId));
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

		public unsafe View? OnCreatePanelView(int featureId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(featureId);
			return Java.Lang.Object.GetObject<View>(_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractObjectMethod("onCreatePanelView.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
				Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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

		public unsafe void OnDetachedFromWindow()
		{
			_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onDetachedFromWindow.()V", this, null);
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
				return callback.OnMenuItemSelected(featureId, item) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnMenuItemSelected(int featureId, IMenuItem item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(featureId);
				ptr[1] = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemSelected.(ILandroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(item);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnMenuOpened(featureId, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnMenuOpened(int featureId, IMenu menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(featureId);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onMenuOpened.(ILandroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(menu);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				callback.OnPanelClosed(featureId, menu);
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

		public unsafe void OnPanelClosed(int featureId, IMenu menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(featureId);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onPanelClosed.(ILandroid/view/Menu;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(menu);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnPreparePanel(featureId, view, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnPreparePanel(int featureId, View? view, IMenu menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(featureId);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onPreparePanel.(ILandroid/view/View;Landroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(menu);
			}
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
				return Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSearchRequested() ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnSearchRequested()
		{
			return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onSearchRequested.()Z", this, null);
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SearchEvent searchEvent = Java.Lang.Object.GetObject<SearchEvent>(native_searchEvent, JniHandleOwnership.DoNotTransfer);
				return callback.OnSearchRequested(searchEvent) ? ((sbyte)1) : ((sbyte)0);
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
		public unsafe bool OnSearchRequested(SearchEvent? searchEvent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(searchEvent?.Handle ?? IntPtr.Zero);
				return _members_android_view_Window_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onSearchRequested.(Landroid/view/SearchEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(searchEvent);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_(nint jnienv, nint native__this, nint native_attrs)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowManagerLayoutParams attrs = Java.Lang.Object.GetObject<WindowManagerLayoutParams>(native_attrs, JniHandleOwnership.DoNotTransfer);
				callback.OnWindowAttributesChanged(attrs);
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

		public unsafe void OnWindowAttributesChanged(WindowManagerLayoutParams? attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(attrs?.Handle ?? IntPtr.Zero);
				_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onWindowAttributesChanged.(Landroid/view/WindowManager$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(attrs);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool hasFocus = native_hasFocus != 0;
				callback.OnWindowFocusChanged(hasFocus);
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

		public unsafe void OnWindowFocusChanged(bool hasFocus)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(hasFocus ? ((sbyte)1) : ((sbyte)0));
			_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractVoidMethod("onWindowFocusChanged.(Z)V", this, ptr);
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode.ICallback callback2 = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(callback.OnWindowStartingActionMode(callback2, (ActionModeType)native_type));
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
		public unsafe ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback, ActionModeType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[1] = new JniArgumentValue((int)type);
				return Java.Lang.Object.GetObject<ActionMode>(_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractObjectMethod("onWindowStartingActionMode.(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
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
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode.ICallback callback2 = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(callback.OnWindowStartingActionMode(callback2));
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

		public unsafe ActionMode? OnWindowStartingActionMode(ActionMode.ICallback? callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<ActionMode>(_members_android_view_Window_Callback.InstanceMethods.InvokeAbstractObjectMethod("onWindowStartingActionMode.(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(callback);
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
		private static sbyte n_DispatchGenericMotionEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchGenericMotionEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_DispatchKeyEvent_Landroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchKeyEvent_Landroid_view_KeyEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_DispatchKeyShortcutEvent_Landroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchKeyShortcutEvent_Landroid_view_KeyEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_DispatchTouchEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchTouchEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_DispatchTrackballEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_DispatchTrackballEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActionModeFinished_Landroid_view_ActionMode__mm_wrapper(nint jnienv, nint native__this, nint native_mode)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActionModeFinished_Landroid_view_ActionMode_(jnienv, native__this, native_mode);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActionModeStarted_Landroid_view_ActionMode__mm_wrapper(nint jnienv, nint native__this, nint native_mode)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActionModeStarted_Landroid_view_ActionMode_(jnienv, native__this, native_mode);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
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

		[UnmanagedCallersOnly]
		private static void n_OnContentChanged_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnContentChanged(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnCreatePanelMenu_ILandroid_view_Menu__mm_wrapper(nint jnienv, nint native__this, int featureId, nint native_menu)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnCreatePanelMenu_ILandroid_view_Menu_(jnienv, native__this, featureId, native_menu);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static nint n_OnCreatePanelView_I_mm_wrapper(nint jnienv, nint native__this, int featureId)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnCreatePanelView_I(jnienv, native__this, featureId);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDetachedFromWindow_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDetachedFromWindow(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnMenuItemSelected_ILandroid_view_MenuItem__mm_wrapper(nint jnienv, nint native__this, int featureId, nint native_item)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnMenuItemSelected_ILandroid_view_MenuItem_(jnienv, native__this, featureId, native_item);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnMenuOpened_ILandroid_view_Menu__mm_wrapper(nint jnienv, nint native__this, int featureId, nint native_menu)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnMenuOpened_ILandroid_view_Menu_(jnienv, native__this, featureId, native_menu);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnPanelClosed_ILandroid_view_Menu__mm_wrapper(nint jnienv, nint native__this, int featureId, nint native_menu)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnPanelClosed_ILandroid_view_Menu_(jnienv, native__this, featureId, native_menu);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu__mm_wrapper(nint jnienv, nint native__this, int featureId, nint native_view, nint native_menu)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnPreparePanel_ILandroid_view_View_Landroid_view_Menu_(jnienv, native__this, featureId, native_view, native_menu);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnSearchRequested_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSearchRequested(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnSearchRequested_Landroid_view_SearchEvent__mm_wrapper(nint jnienv, nint native__this, nint native_searchEvent)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSearchRequested_Landroid_view_SearchEvent_(jnienv, native__this, native_searchEvent);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams__mm_wrapper(nint jnienv, nint native__this, nint native_attrs)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_(jnienv, native__this, native_attrs);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnWindowFocusChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_hasFocus)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnWindowFocusChanged_Z(jnienv, native__this, native_hasFocus);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static nint n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I_mm_wrapper(nint jnienv, nint native__this, nint native__callback, int native_type)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_I(jnienv, native__this, native__callback, native_type);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static nint n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback__mm_wrapper(nint jnienv, nint native__this, nint native__callback)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnWindowStartingActionMode_Landroid_view_ActionMode_Callback_(jnienv, native__this, native__callback);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/Window", typeof(Window));

	private static Delegate? cb_getDecorView_GetDecorView_Landroid_view_View_;

	private static Delegate? cb_addFlags_AddFlags_I_V;

	private static Delegate? cb_clearFlags_ClearFlags_I_V;

	private static Delegate? cb_setBackgroundDrawable_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setNavigationBarColor_SetNavigationBarColor_I_V;

	private static Delegate? cb_setSoftInputMode_SetSoftInputMode_I_V;

	private static Delegate? cb_setStatusBarColor_SetStatusBarColor_I_V;

	private static Delegate? cb_superDispatchGenericMotionEvent_SuperDispatchGenericMotionEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_superDispatchKeyEvent_SuperDispatchKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_superDispatchKeyShortcutEvent_SuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_superDispatchTouchEvent_SuperDispatchTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_superDispatchTrackballEvent_SuperDispatchTrackballEvent_Landroid_view_MotionEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe WindowManagerLayoutParams? Attributes
	{
		[Register("getAttributes", "()Landroid/view/WindowManager$LayoutParams;", "")]
		get
		{
			return Java.Lang.Object.GetObject<WindowManagerLayoutParams>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAttributes.()Landroid/view/WindowManager$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAttributes", "(Landroid/view/WindowManager$LayoutParams;)V", "GetSetAttributes_Landroid_view_WindowManager_LayoutParams_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAttributes.(Landroid/view/WindowManager$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe ICallback? Callback
	{
		[Register("getCallback", "()Landroid/view/Window$Callback;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICallback>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCallback.()Landroid/view/Window$Callback;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCallback", "(Landroid/view/Window$Callback;)V", "GetSetCallback_Landroid_view_Window_Callback_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCallback.(Landroid/view/Window$Callback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public abstract View DecorView
	{
		[Register("getDecorView", "()Landroid/view/View;", "GetGetDecorViewHandler")]
		get;
	}

	protected Window(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetDecorViewHandler()
	{
		return new _JniMarshal_PP_L(n_GetDecorView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDecorView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DecorView);
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

	private static Delegate GetAddFlags_IHandler()
	{
		return new _JniMarshal_PPI_V(n_AddFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFlags_I(nint jnienv, nint native__this, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddFlags((WindowManagerFlags)native_flags);
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

	[Register("addFlags", "(I)V", "GetAddFlags_IHandler")]
	public unsafe virtual void AddFlags(WindowManagerFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)flags);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addFlags.(I)V", this, ptr);
	}

	private static Delegate GetClearFlags_IHandler()
	{
		return new _JniMarshal_PPI_V(n_ClearFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearFlags_I(nint jnienv, nint native__this, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearFlags((WindowManagerFlags)native_flags);
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

	[Register("clearFlags", "(I)V", "GetClearFlags_IHandler")]
	public unsafe virtual void ClearFlags(WindowManagerFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)flags);
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearFlags.(I)V", this, ptr);
	}

	private static Delegate GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable backgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			window.SetBackgroundDrawable(backgroundDrawable);
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

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public abstract void SetBackgroundDrawable(Drawable? drawable);

	[ObsoletedOSPlatform("android35.0")]
	private static Delegate GetSetNavigationBarColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetNavigationBarColor_I);
	}

	[ObsoletedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationBarColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color navigationBarColor = new Color(native_color);
			window.SetNavigationBarColor(navigationBarColor);
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

	[ObsoletedOSPlatform("android35.0")]
	[Register("setNavigationBarColor", "(I)V", "GetSetNavigationBarColor_IHandler")]
	public abstract void SetNavigationBarColor(Color color);

	private static Delegate GetSetSoftInputMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSoftInputMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSoftInputMode_I(nint jnienv, nint native__this, int native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSoftInputMode((SoftInput)native_mode);
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

	[Register("setSoftInputMode", "(I)V", "GetSetSoftInputMode_IHandler")]
	public unsafe virtual void SetSoftInputMode(SoftInput mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)mode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSoftInputMode.(I)V", this, ptr);
	}

	[ObsoletedOSPlatform("android35.0")]
	private static Delegate GetSetStatusBarColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetStatusBarColor_I);
	}

	[ObsoletedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color statusBarColor = new Color(native_color);
			window.SetStatusBarColor(statusBarColor);
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

	[ObsoletedOSPlatform("android35.0")]
	[Register("setStatusBarColor", "(I)V", "GetSetStatusBarColor_IHandler")]
	public abstract void SetStatusBarColor(Color color);

	private static Delegate GetSuperDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_SuperDispatchGenericMotionEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchGenericMotionEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return window.SuperDispatchGenericMotionEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("superDispatchGenericMotionEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler")]
	public abstract bool SuperDispatchGenericMotionEvent(MotionEvent? e);

	private static Delegate GetSuperDispatchKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_SuperDispatchKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return window.SuperDispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("superDispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetSuperDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public abstract bool SuperDispatchKeyEvent(KeyEvent? e);

	private static Delegate GetSuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_SuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return window.SuperDispatchKeyShortcutEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("superDispatchKeyShortcutEvent", "(Landroid/view/KeyEvent;)Z", "GetSuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler")]
	public abstract bool SuperDispatchKeyShortcutEvent(KeyEvent? e);

	private static Delegate GetSuperDispatchTouchEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_SuperDispatchTouchEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return window.SuperDispatchTouchEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("superDispatchTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchTouchEvent_Landroid_view_MotionEvent_Handler")]
	public abstract bool SuperDispatchTouchEvent(MotionEvent? e);

	private static Delegate GetSuperDispatchTrackballEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_SuperDispatchTrackballEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchTrackballEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Window? window = Java.Lang.Object.GetObject<Window>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return window.SuperDispatchTrackballEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("superDispatchTrackballEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchTrackballEvent_Landroid_view_MotionEvent_Handler")]
	public abstract bool SuperDispatchTrackballEvent(MotionEvent? e);
}
