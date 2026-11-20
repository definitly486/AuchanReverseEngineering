using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Behavior;

[Register("com/google/android/material/behavior/SwipeDismissBehavior", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "V extends android.view.View" })]
public class SwipeDismissBehavior : CoordinatorLayout.Behavior
{
	[Register("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", "", "Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker")]
	public interface IOnDismissListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDismiss", "(Landroid/view/View;)V", "GetOnDismiss_Landroid_view_View_Handler:Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker, Xamarin.Google.Android.Material")]
		void OnDismiss(View? view);

		[Register("onDragStateChanged", "(I)V", "GetOnDragStateChanged_IHandler:Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker, Xamarin.Google.Android.Material")]
		void OnDragStateChanged(int state);
	}

	[Register("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", DoNotGenerateAcw = true)]
	internal class IOnDismissListenerInvoker : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener = new XAPeerMembers("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", typeof(IOnDismissListenerInvoker));

		private static Delegate? cb_onDismiss_OnDismiss_Landroid_view_View__V;

		private static Delegate? cb_onDragStateChanged_OnDragStateChanged_I_V;

		private static nint java_class_ref => _members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener.ManagedPeerType;

		public IOnDismissListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDismiss_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnDismissListener? onDismissListener = Java.Lang.Object.GetObject<IOnDismissListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onDismissListener.OnDismiss(view);
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

		public unsafe void OnDismiss(View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener.InstanceMethods.InvokeAbstractVoidMethod("onDismiss.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDragStateChanged_I(nint jnienv, nint native__this, int state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnDismissListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDragStateChanged(state);
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

		public unsafe void OnDragStateChanged(int state)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state);
			_members_com_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener.InstanceMethods.InvokeAbstractVoidMethod("onDragStateChanged.(I)V", this, ptr);
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
		private static void n_OnDismiss_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_view)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDismiss_Landroid_view_View_(jnienv, native__this, native_view);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDragStateChanged_I_mm_wrapper(nint jnienv, nint native__this, int state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDragStateChanged_I(jnienv, native__this, state);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class DismissEventArgs : EventArgs
	{
		private View? view;

		public DismissEventArgs(View? view)
		{
			this.view = view;
		}
	}

	public class DragStateChangedEventArgs : EventArgs
	{
		private int state;

		public DragStateChangedEventArgs(int state)
		{
			this.state = state;
		}
	}

	[Register("mono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor")]
	internal sealed class IOnDismissListenerImplementor : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<DismissEventArgs>? OnDismissHandler;

		public EventHandler<DragStateChangedEventArgs>? OnDragStateChangedHandler;

		public unsafe IOnDismissListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnDismiss(View? view)
		{
			OnDismissHandler?.Invoke(sender, new DismissEventArgs(view));
		}

		public void OnDragStateChanged(int state)
		{
			OnDragStateChangedHandler?.Invoke(sender, new DragStateChangedEventArgs(state));
		}

		internal static bool __IsEmpty(IOnDismissListenerImplementor value)
		{
			if (value.OnDismissHandler == null)
			{
				return value.OnDragStateChangedHandler == null;
			}
			return false;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/behavior/SwipeDismissBehavior", typeof(SwipeDismissBehavior));

	private static Delegate? cb_getDragState_GetDragState_I;

	private static Delegate? cb_getListener_GetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_;

	private static Delegate? cb_setListener_SetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener__V;

	private static Delegate? cb_canSwipeDismissView_CanSwipeDismissView_Landroid_view_View__Z;

	private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onLayoutChild_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I_Z;

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_setDragDismissDistance_SetDragDismissDistance_F_V;

	private static Delegate? cb_setEndAlphaSwipeDistance_SetEndAlphaSwipeDistance_F_V;

	private static Delegate? cb_setSensitivity_SetSensitivity_F_V;

	private static Delegate? cb_setStartAlphaSwipeDistance_SetStartAlphaSwipeDistance_F_V;

	private static Delegate? cb_setSwipeDirection_SetSwipeDirection_I_V;

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

	public unsafe virtual int DragState
	{
		[Register("getDragState", "()I", "GetGetDragStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDragState.()I", this, null);
		}
	}

	public unsafe virtual IOnDismissListener? Listener
	{
		[Register("getListener", "()Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;", "GetGetListenerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IOnDismissListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListener.()Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setListener", "(Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;)V", "GetSetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setListener.(Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected SwipeDismissBehavior(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SwipeDismissBehavior()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetDragStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDragState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDragState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragState;
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

	private static Delegate GetGetListenerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetListener);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetListener(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Listener);
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

	private static Delegate GetSetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeDismissBehavior? swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnDismissListener listener = Java.Lang.Object.GetObject<IOnDismissListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			swipeDismissBehavior.Listener = listener;
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

	private static Delegate GetCanSwipeDismissView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_CanSwipeDismissView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanSwipeDismissView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SwipeDismissBehavior? swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.CanSwipeDismissView(view) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canSwipeDismissView", "(Landroid/view/View;)Z", "GetCanSwipeDismissView_Landroid_view_View_Handler")]
	public unsafe virtual bool CanSwipeDismissView(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canSwipeDismissView.(Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
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
			SwipeDismissBehavior? swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.OnInterceptTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLLI_B(n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I(nint jnienv, nint native__this, nint native_parent, nint native_child, int layoutDirection)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SwipeDismissBehavior? swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.OnLayoutChild(parent, child, layoutDirection) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onLayoutChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", "GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler")]
	public unsafe override bool OnLayoutChild(CoordinatorLayout parent, Java.Lang.Object child, int layoutDirection)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(layoutDirection);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onLayoutChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
	{
		return new global::_JniMarshal_PPLLL_B(n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SwipeDismissBehavior? swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.OnTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool OnTouchEvent(CoordinatorLayout? parent, Java.Lang.Object? child, MotionEvent? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetSetDragDismissDistance_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetDragDismissDistance_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDragDismissDistance_F(nint jnienv, nint native__this, float distance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDragDismissDistance(distance);
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

	[Register("setDragDismissDistance", "(F)V", "GetSetDragDismissDistance_FHandler")]
	public unsafe virtual void SetDragDismissDistance(float distance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(distance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDragDismissDistance.(F)V", this, ptr);
	}

	private static Delegate GetSetEndAlphaSwipeDistance_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetEndAlphaSwipeDistance_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndAlphaSwipeDistance_F(nint jnienv, nint native__this, float fraction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEndAlphaSwipeDistance(fraction);
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

	[Register("setEndAlphaSwipeDistance", "(F)V", "GetSetEndAlphaSwipeDistance_FHandler")]
	public unsafe virtual void SetEndAlphaSwipeDistance(float fraction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(fraction);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEndAlphaSwipeDistance.(F)V", this, ptr);
	}

	private static Delegate GetSetSensitivity_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetSensitivity_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSensitivity_F(nint jnienv, nint native__this, float sensitivity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSensitivity(sensitivity);
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

	[Register("setSensitivity", "(F)V", "GetSetSensitivity_FHandler")]
	public unsafe virtual void SetSensitivity(float sensitivity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(sensitivity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSensitivity.(F)V", this, ptr);
	}

	private static Delegate GetSetStartAlphaSwipeDistance_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetStartAlphaSwipeDistance_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartAlphaSwipeDistance_F(nint jnienv, nint native__this, float fraction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStartAlphaSwipeDistance(fraction);
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

	[Register("setStartAlphaSwipeDistance", "(F)V", "GetSetStartAlphaSwipeDistance_FHandler")]
	public unsafe virtual void SetStartAlphaSwipeDistance(float fraction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(fraction);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStartAlphaSwipeDistance.(F)V", this, ptr);
	}

	private static Delegate GetSetSwipeDirection_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSwipeDirection_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwipeDirection_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSwipeDirection(direction);
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

	[Register("setSwipeDirection", "(I)V", "GetSetSwipeDirection_IHandler")]
	public unsafe virtual void SetSwipeDirection(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSwipeDirection.(I)V", this, ptr);
	}

	private IOnDismissListenerImplementor __CreateIOnDismissListenerImplementor()
	{
		return new IOnDismissListenerImplementor(this);
	}
}
