using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionsAtPointListener", DoNotGenerateAcw = true)]
internal class IRegionsAtPointListenerInvoker : Java.Lang.Object, IRegionsAtPointListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_RegionsAtPointListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/RegionsAtPointListener", typeof(IRegionsAtPointListenerInvoker));

	private static Delegate? cb_onError_OnError_Lcom_yandex_runtime_Error__V;

	private static Delegate? cb_onRegions_OnRegions_Ljava_util_List__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_RegionsAtPointListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_RegionsAtPointListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_RegionsAtPointListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_RegionsAtPointListener.ManagedPeerType;

	public IRegionsAtPointListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnError_Lcom_yandex_runtime_Error_Handler()
	{
		if ((object)cb_onError_OnError_Lcom_yandex_runtime_Error__V == null)
		{
			cb_onError_OnError_Lcom_yandex_runtime_Error__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_yandex_runtime_Error_));
		}
		return cb_onError_OnError_Lcom_yandex_runtime_Error__V;
	}

	private static void n_OnError_Lcom_yandex_runtime_Error_(nint jnienv, nint native__this, nint native_p0)
	{
		IRegionsAtPointListener? regionsAtPointListener = Java.Lang.Object.GetObject<IRegionsAtPointListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IError p = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
		regionsAtPointListener.OnError(p);
	}

	public unsafe void OnError(IError p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_RegionsAtPointListener.InstanceMethods.InvokeAbstractVoidMethod("onError.(Lcom/yandex/runtime/Error;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnRegions_Ljava_util_List_Handler()
	{
		if ((object)cb_onRegions_OnRegions_Ljava_util_List__V == null)
		{
			cb_onRegions_OnRegions_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnRegions_Ljava_util_List_));
		}
		return cb_onRegions_OnRegions_Ljava_util_List__V;
	}

	private static void n_OnRegions_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IRegionsAtPointListener? regionsAtPointListener = Java.Lang.Object.GetObject<IRegionsAtPointListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Integer> p = JavaList<Integer>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		regionsAtPointListener.OnRegions(p);
	}

	public unsafe void OnRegions(IList<Integer> p0)
	{
		nint num = JavaList<Integer>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_offline_cache_RegionsAtPointListener.InstanceMethods.InvokeAbstractVoidMethod("onRegions.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}
}
