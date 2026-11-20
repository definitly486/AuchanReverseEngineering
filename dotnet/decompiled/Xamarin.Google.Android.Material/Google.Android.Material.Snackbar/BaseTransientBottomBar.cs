using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.Behavior;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Snackbar;

[Register("com/google/android/material/snackbar/BaseTransientBottomBar", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "B extends com.google.android.material.snackbar.BaseTransientBottomBar<B>" })]
public abstract class BaseTransientBottomBar : Java.Lang.Object
{
	[Register("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "B" })]
	public abstract class BaseCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", typeof(BaseCallback));

		private static Delegate? cb_onDismissed_OnDismissed_Ljava_lang_Object_I_V;

		private static Delegate? cb_onShown_OnShown_Ljava_lang_Object__V;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected BaseCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BaseCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDismissed_Ljava_lang_Object_I(nint jnienv, nint native__this, nint native_transientBottomBar, int e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				BaseCallback? baseCallback = Java.Lang.Object.GetObject<BaseCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object transientBottomBar = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transientBottomBar, JniHandleOwnership.DoNotTransfer);
				baseCallback.OnDismissed(transientBottomBar, e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDismissed", "(Ljava/lang/Object;I)V", "GetOnDismissed_Ljava_lang_Object_IHandler")]
		public unsafe virtual void OnDismissed(Java.Lang.Object? transientBottomBar, int e)
		{
			nint num = JNIEnv.ToLocalJniHandle(transientBottomBar);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(e);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDismissed.(Ljava/lang/Object;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(transientBottomBar);
			}
		}

		private static Delegate GetOnShown_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnShown_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnShown_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transientBottomBar)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				BaseCallback? baseCallback = Java.Lang.Object.GetObject<BaseCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object transientBottomBar = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transientBottomBar, JniHandleOwnership.DoNotTransfer);
				baseCallback.OnShown(transientBottomBar);
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

		[Register("onShown", "(Ljava/lang/Object;)V", "GetOnShown_Ljava_lang_Object_Handler")]
		public unsafe virtual void OnShown(Java.Lang.Object? transientBottomBar)
		{
			nint num = JNIEnv.ToLocalJniHandle(transientBottomBar);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onShown.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(transientBottomBar);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDismissed_Ljava_lang_Object_I_mm_wrapper(nint jnienv, nint native__this, nint native_transientBottomBar, int e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDismissed_Ljava_lang_Object_I(jnienv, native__this, native_transientBottomBar, e);
			}
			catch (System.Exception e2)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e2);
			}
		}
	}

	[Register("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", DoNotGenerateAcw = true)]
	internal class BaseCallbackInvoker : BaseCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", typeof(BaseCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public BaseCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("com/google/android/material/snackbar/BaseTransientBottomBar$Behavior", DoNotGenerateAcw = true)]
	public class Behavior : SwipeDismissBehavior
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$Behavior", typeof(Behavior));

		private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

		internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Behavior(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Behavior()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return behavior.OnInterceptTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public unsafe override bool OnInterceptTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(e);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar", typeof(BaseTransientBottomBar));

	private static Delegate? cb_getAnchorView_GetAnchorView_Landroid_view_View_;

	private static Delegate? cb_isAnchorViewLayoutListenerEnabled_IsAnchorViewLayoutListenerEnabled_Z;

	private static Delegate? cb_setAnchorViewLayoutListenerEnabled_SetAnchorViewLayoutListenerEnabled_Z_V;

	private static Delegate? cb_getAnimationMode_GetAnimationMode_I;

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getDuration_GetDuration_I;

	private static Delegate? cb_hasSnackbarStyleAttr_HasSnackbarStyleAttr_Z;

	private static Delegate? cb_isGestureInsetBottomIgnored_IsGestureInsetBottomIgnored_Z;

	private static Delegate? cb_isShown_IsShown_Z;

	private static Delegate? cb_isShownOrQueued_IsShownOrQueued_Z;

	private static Delegate? cb_getNewBehavior_GetNewBehavior_Lcom_google_android_material_behavior_SwipeDismissBehavior_;

	private static Delegate? cb_getSnackbarBaseLayoutResId_GetSnackbarBaseLayoutResId_I;

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_addCallback_AddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback__Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_dismiss_Dismiss_V;

	private static Delegate? cb_dispatchDismiss_DispatchDismiss_I_V;

	private static Delegate? cb_getBehavior_GetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_;

	private static Delegate? cb_removeCallback_RemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback__Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setAnchorView_SetAnchorView_Landroid_view_View__Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setAnchorView_SetAnchorView_I_Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setAnimationMode_SetAnimationMode_I_Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setBehavior_SetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior__Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setDuration_SetDuration_I_Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_setGestureInsetBottomIgnored_SetGestureInsetBottomIgnored_Z_Lcom_google_android_material_snackbar_BaseTransientBottomBar_;

	private static Delegate? cb_show_Show_V;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual View? AnchorView
	{
		[Register("getAnchorView", "()Landroid/view/View;", "GetGetAnchorViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchorView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool AnchorViewLayoutListenerEnabled
	{
		[Register("isAnchorViewLayoutListenerEnabled", "()Z", "GetIsAnchorViewLayoutListenerEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAnchorViewLayoutListenerEnabled.()Z", this, null);
		}
		[Register("setAnchorViewLayoutListenerEnabled", "(Z)V", "GetSetAnchorViewLayoutListenerEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAnchorViewLayoutListenerEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int AnimationMode
	{
		[Register("getAnimationMode", "()I", "GetGetAnimationModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimationMode.()I", this, null);
		}
	}

	public unsafe virtual Context Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Duration
	{
		[Register("getDuration", "()I", "GetGetDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDuration.()I", this, null);
		}
	}

	protected unsafe virtual bool HasSnackbarStyleAttr
	{
		[Register("hasSnackbarStyleAttr", "()Z", "GetHasSnackbarStyleAttrHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasSnackbarStyleAttr.()Z", this, null);
		}
	}

	public unsafe virtual bool IsGestureInsetBottomIgnored
	{
		[Register("isGestureInsetBottomIgnored", "()Z", "GetIsGestureInsetBottomIgnoredHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isGestureInsetBottomIgnored.()Z", this, null);
		}
	}

	public unsafe virtual bool IsShown
	{
		[Register("isShown", "()Z", "GetIsShownHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShown.()Z", this, null);
		}
	}

	public unsafe virtual bool IsShownOrQueued
	{
		[Register("isShownOrQueued", "()Z", "GetIsShownOrQueuedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShownOrQueued.()Z", this, null);
		}
	}

	protected unsafe virtual SwipeDismissBehavior NewBehavior
	{
		[Register("getNewBehavior", "()Lcom/google/android/material/behavior/SwipeDismissBehavior;", "GetGetNewBehaviorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SwipeDismissBehavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNewBehavior.()Lcom/google/android/material/behavior/SwipeDismissBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual int SnackbarBaseLayoutResId
	{
		[Register("getSnackbarBaseLayoutResId", "()I", "GetGetSnackbarBaseLayoutResIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSnackbarBaseLayoutResId.()I", this, null);
		}
	}

	public unsafe virtual View View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected BaseTransientBottomBar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", "")]
	protected unsafe BaseTransientBottomBar(Context context, ViewGroup parent, View content, IContentViewCallback contentViewCallback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((contentViewCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)contentViewCallback).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(parent);
			GC.KeepAlive(content);
			GC.KeepAlive(contentViewCallback);
		}
	}

	[Register(".ctor", "(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", "")]
	protected unsafe BaseTransientBottomBar(ViewGroup parent, View content, IContentViewCallback contentViewCallback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((contentViewCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)contentViewCallback).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parent);
			GC.KeepAlive(content);
			GC.KeepAlive(contentViewCallback);
		}
	}

	private static Delegate GetGetAnchorViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnchorView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnchorView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorView);
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

	private static Delegate GetIsAnchorViewLayoutListenerEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAnchorViewLayoutListenerEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAnchorViewLayoutListenerEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorViewLayoutListenerEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAnchorViewLayoutListenerEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAnchorViewLayoutListenerEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAnchorViewLayoutListenerEnabled_Z(nint jnienv, nint native__this, sbyte native_anchorViewLayoutListenerEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool anchorViewLayoutListenerEnabled = native_anchorViewLayoutListenerEnabled != 0;
			baseTransientBottomBar.AnchorViewLayoutListenerEnabled = anchorViewLayoutListenerEnabled;
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

	private static Delegate GetGetAnimationModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetAnimationMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAnimationMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimationMode;
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

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetGetDurationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDuration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDuration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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

	private static Delegate GetHasSnackbarStyleAttrHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasSnackbarStyleAttr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasSnackbarStyleAttr(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSnackbarStyleAttr ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsGestureInsetBottomIgnoredHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsGestureInsetBottomIgnored);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsGestureInsetBottomIgnored(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsGestureInsetBottomIgnored ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsShownHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShown ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsShownOrQueuedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShownOrQueued);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShownOrQueued(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShownOrQueued ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNewBehaviorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetNewBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNewBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewBehavior);
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

	private static Delegate GetGetSnackbarBaseLayoutResIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSnackbarBaseLayoutResId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSnackbarBaseLayoutResId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SnackbarBaseLayoutResId;
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

	private static Delegate GetGetViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	private static Delegate GetAddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BaseCallback callback = Java.Lang.Object.GetObject<BaseCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.AddCallback(callback));
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

	[Register("addCallback", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetAddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler")]
	public unsafe virtual Java.Lang.Object AddCallback(BaseCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("addCallback.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetDismissHandler()
	{
		return new global::_JniMarshal_PP_V(n_Dismiss);
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
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
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

	private static Delegate GetDispatchDismiss_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_DispatchDismiss_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchDismiss_I(nint jnienv, nint native__this, int e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DispatchDismiss(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchDismiss", "(I)V", "GetDispatchDismiss_IHandler")]
	protected unsafe virtual void DispatchDismiss(int e)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(e);
		_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchDismiss.(I)V", this, ptr);
	}

	private static Delegate GetGetBehaviorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBehavior());
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

	[Register("getBehavior", "()Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;", "GetGetBehaviorHandler")]
	public unsafe virtual Behavior? GetBehavior()
	{
		return Java.Lang.Object.GetObject<Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_RemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BaseCallback callback = Java.Lang.Object.GetObject<BaseCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.RemoveCallback(callback));
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

	[Register("removeCallback", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetRemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler")]
	public unsafe virtual Java.Lang.Object RemoveCallback(BaseCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeCallback.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetAnchorView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetAnchorView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAnchorView_Landroid_view_View_(nint jnienv, nint native__this, nint native_anchorView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchorView = Java.Lang.Object.GetObject<View>(native_anchorView, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.SetAnchorView(anchorView));
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

	[Register("setAnchorView", "(Landroid/view/View;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetAnchorView_Landroid_view_View_Handler")]
	public unsafe virtual Java.Lang.Object SetAnchorView(View? anchorView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchorView?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAnchorView.(Landroid/view/View;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchorView);
		}
	}

	private static Delegate GetSetAnchorView_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetAnchorView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAnchorView_I(nint jnienv, nint native__this, int anchorViewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAnchorView(anchorViewId));
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

	[Register("setAnchorView", "(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetAnchorView_IHandler")]
	public unsafe virtual Java.Lang.Object SetAnchorView(int anchorViewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(anchorViewId);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAnchorView.(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetAnimationMode_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetAnimationMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAnimationMode_I(nint jnienv, nint native__this, int animationMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAnimationMode(animationMode));
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

	[Register("setAnimationMode", "(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetAnimationMode_IHandler")]
	public unsafe virtual Java.Lang.Object SetAnimationMode(int animationMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(animationMode);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAnimationMode.(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_(nint jnienv, nint native__this, nint native_behavior)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Behavior behavior = Java.Lang.Object.GetObject<Behavior>(native_behavior, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.SetBehavior(behavior));
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

	[Register("setBehavior", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_Handler")]
	public unsafe virtual Java.Lang.Object SetBehavior(Behavior? behavior)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(behavior?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBehavior.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(behavior);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDuration_I(nint jnienv, nint native__this, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
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

	[Register("setDuration", "(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetDuration_IHandler")]
	public unsafe virtual Java.Lang.Object SetDuration(int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetGestureInsetBottomIgnored_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SetGestureInsetBottomIgnored_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetGestureInsetBottomIgnored_Z(nint jnienv, nint native__this, sbyte native_gestureInsetBottomIgnored)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseTransientBottomBar? baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool gestureInsetBottomIgnored = native_gestureInsetBottomIgnored != 0;
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.SetGestureInsetBottomIgnored(gestureInsetBottomIgnored));
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

	[Register("setGestureInsetBottomIgnored", "(Z)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetGestureInsetBottomIgnored_ZHandler")]
	public unsafe virtual Java.Lang.Object SetGestureInsetBottomIgnored(bool gestureInsetBottomIgnored)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(gestureInsetBottomIgnored ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setGestureInsetBottomIgnored.(Z)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetShowHandler()
	{
		return new global::_JniMarshal_PP_V(n_Show);
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
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
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

	[UnmanagedCallersOnly]
	private static nint n_SetDuration_I_mm_wrapper(nint jnienv, nint native__this, int duration)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_SetDuration_I(jnienv, native__this, duration);
		}
		catch (System.Exception e)
		{
			global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
