using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Register("androidx/core/app/SharedElementCallback", DoNotGenerateAcw = true)]
public abstract class SharedElementCallback : Java.Lang.Object
{
	[Register("androidx/core/app/SharedElementCallback$OnSharedElementsReadyListener", "", "AndroidX.Core.App.SharedElementCallback/IOnSharedElementsReadyListenerInvoker")]
	public interface IOnSharedElementsReadyListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSharedElementsReady", "()V", "GetOnSharedElementsReadyHandler:AndroidX.Core.App.SharedElementCallback/IOnSharedElementsReadyListenerInvoker, Xamarin.AndroidX.Core")]
		void OnSharedElementsReady();
	}

	[Register("androidx/core/app/SharedElementCallback$OnSharedElementsReadyListener", DoNotGenerateAcw = true)]
	internal class IOnSharedElementsReadyListenerInvoker : Java.Lang.Object, IOnSharedElementsReadyListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener = new XAPeerMembers("androidx/core/app/SharedElementCallback$OnSharedElementsReadyListener", typeof(IOnSharedElementsReadyListenerInvoker));

		private static Delegate? cb_onSharedElementsReady_OnSharedElementsReady_V;

		private static nint java_class_ref => _members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener.ManagedPeerType;

		public IOnSharedElementsReadyListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnSharedElementsReadyHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnSharedElementsReady);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSharedElementsReady(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnSharedElementsReadyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSharedElementsReady();
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

		public unsafe void OnSharedElementsReady()
		{
			_members_androidx_core_app_SharedElementCallback_OnSharedElementsReadyListener.InstanceMethods.InvokeAbstractVoidMethod("onSharedElementsReady.()V", this, null);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/SharedElementCallback", typeof(SharedElementCallback));

	private static Delegate? cb_onCaptureSharedElementSnapshot_OnCaptureSharedElementSnapshot_Landroid_view_View_Landroid_graphics_Matrix_Landroid_graphics_RectF__Landroid_os_Parcelable_;

	private static Delegate? cb_onCreateSnapshotView_OnCreateSnapshotView_Landroid_content_Context_Landroid_os_Parcelable__Landroid_view_View_;

	private static Delegate? cb_onMapSharedElements_OnMapSharedElements_Ljava_util_List_Ljava_util_Map__V;

	private static Delegate? cb_onRejectSharedElements_OnRejectSharedElements_Ljava_util_List__V;

	private static Delegate? cb_onSharedElementEnd_OnSharedElementEnd_Ljava_util_List_Ljava_util_List_Ljava_util_List__V;

	private static Delegate? cb_onSharedElementStart_OnSharedElementStart_Ljava_util_List_Ljava_util_List_Ljava_util_List__V;

	private static Delegate? cb_onSharedElementsArrived_OnSharedElementsArrived_Ljava_util_List_Ljava_util_List_Landroidx_core_app_SharedElementCallback_OnSharedElementsReadyListener__V;

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

	protected SharedElementCallback(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SharedElementCallback()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetOnCaptureSharedElementSnapshot_Landroid_view_View_Landroid_graphics_Matrix_Landroid_graphics_RectF_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_OnCaptureSharedElementSnapshot_Landroid_view_View_Landroid_graphics_Matrix_Landroid_graphics_RectF_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCaptureSharedElementSnapshot_Landroid_view_View_Landroid_graphics_Matrix_Landroid_graphics_RectF_(nint jnienv, nint native__this, nint native_sharedElement, nint native_viewToGlobalMatrix, nint native_screenBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View sharedElement = Java.Lang.Object.GetObject<Android.Views.View>(native_sharedElement, JniHandleOwnership.DoNotTransfer);
			Matrix viewToGlobalMatrix = Java.Lang.Object.GetObject<Matrix>(native_viewToGlobalMatrix, JniHandleOwnership.DoNotTransfer);
			RectF screenBounds = Java.Lang.Object.GetObject<RectF>(native_screenBounds, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedElementCallback.OnCaptureSharedElementSnapshot(sharedElement, viewToGlobalMatrix, screenBounds));
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

	[Register("onCaptureSharedElementSnapshot", "(Landroid/view/View;Landroid/graphics/Matrix;Landroid/graphics/RectF;)Landroid/os/Parcelable;", "GetOnCaptureSharedElementSnapshot_Landroid_view_View_Landroid_graphics_Matrix_Landroid_graphics_RectF_Handler")]
	public unsafe virtual IParcelable? OnCaptureSharedElementSnapshot(Android.Views.View? sharedElement, Matrix? viewToGlobalMatrix, RectF? screenBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(sharedElement?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(viewToGlobalMatrix?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(screenBounds?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCaptureSharedElementSnapshot.(Landroid/view/View;Landroid/graphics/Matrix;Landroid/graphics/RectF;)Landroid/os/Parcelable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(sharedElement);
			GC.KeepAlive(viewToGlobalMatrix);
			GC.KeepAlive(screenBounds);
		}
	}

	private static Delegate GetOnCreateSnapshotView_Landroid_content_Context_Landroid_os_Parcelable_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_OnCreateSnapshotView_Landroid_content_Context_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateSnapshotView_Landroid_content_Context_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_context, nint native_snapshot)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			IParcelable snapshot = Java.Lang.Object.GetObject<IParcelable>(native_snapshot, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedElementCallback.OnCreateSnapshotView(context, snapshot));
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

	[Register("onCreateSnapshotView", "(Landroid/content/Context;Landroid/os/Parcelable;)Landroid/view/View;", "GetOnCreateSnapshotView_Landroid_content_Context_Landroid_os_Parcelable_Handler")]
	public unsafe virtual Android.Views.View? OnCreateSnapshotView(Context? context, IParcelable? snapshot)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((snapshot == null) ? IntPtr.Zero : ((Java.Lang.Object)snapshot).Handle);
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateSnapshotView.(Landroid/content/Context;Landroid/os/Parcelable;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(snapshot);
		}
	}

	private static Delegate GetOnMapSharedElements_Ljava_util_List_Ljava_util_Map_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnMapSharedElements_Ljava_util_List_Ljava_util_Map_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMapSharedElements_Ljava_util_List_Ljava_util_Map_(nint jnienv, nint native__this, nint native_names, nint native_sharedElements)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> names = JavaList<string>.FromJniHandle(native_names, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, Android.Views.View> sharedElements = JavaDictionary<string, Android.Views.View>.FromJniHandle(native_sharedElements, JniHandleOwnership.DoNotTransfer);
			sharedElementCallback.OnMapSharedElements(names, sharedElements);
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

	[Register("onMapSharedElements", "(Ljava/util/List;Ljava/util/Map;)V", "GetOnMapSharedElements_Ljava_util_List_Ljava_util_Map_Handler")]
	public unsafe virtual void OnMapSharedElements(IList<string>? names, IDictionary<string, Android.Views.View>? sharedElements)
	{
		nint num = JavaList<string>.ToLocalJniHandle(names);
		nint num2 = JavaDictionary<string, Android.Views.View>.ToLocalJniHandle(sharedElements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onMapSharedElements.(Ljava/util/List;Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(names);
			GC.KeepAlive(sharedElements);
		}
	}

	private static Delegate GetOnRejectSharedElements_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnRejectSharedElements_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRejectSharedElements_Ljava_util_List_(nint jnienv, nint native__this, nint native_rejectedSharedElements)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> rejectedSharedElements = JavaList<Android.Views.View>.FromJniHandle(native_rejectedSharedElements, JniHandleOwnership.DoNotTransfer);
			sharedElementCallback.OnRejectSharedElements(rejectedSharedElements);
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

	[Register("onRejectSharedElements", "(Ljava/util/List;)V", "GetOnRejectSharedElements_Ljava_util_List_Handler")]
	public unsafe virtual void OnRejectSharedElements(IList<Android.Views.View>? rejectedSharedElements)
	{
		nint num = JavaList<Android.Views.View>.ToLocalJniHandle(rejectedSharedElements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRejectSharedElements.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(rejectedSharedElements);
		}
	}

	private static Delegate GetOnSharedElementEnd_Ljava_util_List_Ljava_util_List_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnSharedElementEnd_Ljava_util_List_Ljava_util_List_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSharedElementEnd_Ljava_util_List_Ljava_util_List_Ljava_util_List_(nint jnienv, nint native__this, nint native_sharedElementNames, nint native_sharedElements, nint native_sharedElementSnapshots)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> sharedElementNames = JavaList<string>.FromJniHandle(native_sharedElementNames, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> sharedElements = JavaList<Android.Views.View>.FromJniHandle(native_sharedElements, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> sharedElementSnapshots = JavaList<Android.Views.View>.FromJniHandle(native_sharedElementSnapshots, JniHandleOwnership.DoNotTransfer);
			sharedElementCallback.OnSharedElementEnd(sharedElementNames, sharedElements, sharedElementSnapshots);
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

	[Register("onSharedElementEnd", "(Ljava/util/List;Ljava/util/List;Ljava/util/List;)V", "GetOnSharedElementEnd_Ljava_util_List_Ljava_util_List_Ljava_util_List_Handler")]
	public unsafe virtual void OnSharedElementEnd(IList<string>? sharedElementNames, IList<Android.Views.View>? sharedElements, IList<Android.Views.View>? sharedElementSnapshots)
	{
		nint num = JavaList<string>.ToLocalJniHandle(sharedElementNames);
		nint num2 = JavaList<Android.Views.View>.ToLocalJniHandle(sharedElements);
		nint num3 = JavaList<Android.Views.View>.ToLocalJniHandle(sharedElementSnapshots);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSharedElementEnd.(Ljava/util/List;Ljava/util/List;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(sharedElementNames);
			GC.KeepAlive(sharedElements);
			GC.KeepAlive(sharedElementSnapshots);
		}
	}

	private static Delegate GetOnSharedElementStart_Ljava_util_List_Ljava_util_List_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnSharedElementStart_Ljava_util_List_Ljava_util_List_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSharedElementStart_Ljava_util_List_Ljava_util_List_Ljava_util_List_(nint jnienv, nint native__this, nint native_sharedElementNames, nint native_sharedElements, nint native_sharedElementSnapshots)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> sharedElementNames = JavaList<string>.FromJniHandle(native_sharedElementNames, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> sharedElements = JavaList<Android.Views.View>.FromJniHandle(native_sharedElements, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> sharedElementSnapshots = JavaList<Android.Views.View>.FromJniHandle(native_sharedElementSnapshots, JniHandleOwnership.DoNotTransfer);
			sharedElementCallback.OnSharedElementStart(sharedElementNames, sharedElements, sharedElementSnapshots);
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

	[Register("onSharedElementStart", "(Ljava/util/List;Ljava/util/List;Ljava/util/List;)V", "GetOnSharedElementStart_Ljava_util_List_Ljava_util_List_Ljava_util_List_Handler")]
	public unsafe virtual void OnSharedElementStart(IList<string>? sharedElementNames, IList<Android.Views.View>? sharedElements, IList<Android.Views.View>? sharedElementSnapshots)
	{
		nint num = JavaList<string>.ToLocalJniHandle(sharedElementNames);
		nint num2 = JavaList<Android.Views.View>.ToLocalJniHandle(sharedElements);
		nint num3 = JavaList<Android.Views.View>.ToLocalJniHandle(sharedElementSnapshots);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSharedElementStart.(Ljava/util/List;Ljava/util/List;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(sharedElementNames);
			GC.KeepAlive(sharedElements);
			GC.KeepAlive(sharedElementSnapshots);
		}
	}

	private static Delegate GetOnSharedElementsArrived_Ljava_util_List_Ljava_util_List_Landroidx_core_app_SharedElementCallback_OnSharedElementsReadyListener_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnSharedElementsArrived_Ljava_util_List_Ljava_util_List_Landroidx_core_app_SharedElementCallback_OnSharedElementsReadyListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSharedElementsArrived_Ljava_util_List_Ljava_util_List_Landroidx_core_app_SharedElementCallback_OnSharedElementsReadyListener_(nint jnienv, nint native__this, nint native_sharedElementNames, nint native_sharedElements, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedElementCallback? sharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> sharedElementNames = JavaList<string>.FromJniHandle(native_sharedElementNames, JniHandleOwnership.DoNotTransfer);
			IList<Android.Views.View> sharedElements = JavaList<Android.Views.View>.FromJniHandle(native_sharedElements, JniHandleOwnership.DoNotTransfer);
			IOnSharedElementsReadyListener listener = Java.Lang.Object.GetObject<IOnSharedElementsReadyListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedElementCallback.OnSharedElementsArrived(sharedElementNames, sharedElements, listener);
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

	[Register("onSharedElementsArrived", "(Ljava/util/List;Ljava/util/List;Landroidx/core/app/SharedElementCallback$OnSharedElementsReadyListener;)V", "GetOnSharedElementsArrived_Ljava_util_List_Ljava_util_List_Landroidx_core_app_SharedElementCallback_OnSharedElementsReadyListener_Handler")]
	public unsafe virtual void OnSharedElementsArrived(IList<string>? sharedElementNames, IList<Android.Views.View>? sharedElements, IOnSharedElementsReadyListener? listener)
	{
		nint num = JavaList<string>.ToLocalJniHandle(sharedElementNames);
		nint num2 = JavaList<Android.Views.View>.ToLocalJniHandle(sharedElements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSharedElementsArrived.(Ljava/util/List;Ljava/util/List;Landroidx/core/app/SharedElementCallback$OnSharedElementsReadyListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(sharedElementNames);
			GC.KeepAlive(sharedElements);
			GC.KeepAlive(listener);
		}
	}
}
