using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/DataMoveListener", DoNotGenerateAcw = true)]
internal class IDataMoveListenerInvoker : Java.Lang.Object, IDataMoveListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_DataMoveListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/DataMoveListener", typeof(IDataMoveListenerInvoker));

	private static Delegate? cb_onDataMoveCompleted_OnDataMoveCompleted_V;

	private static Delegate? cb_onDataMoveError_OnDataMoveError_Lcom_yandex_runtime_Error__V;

	private static Delegate? cb_onDataMoveProgress_OnDataMoveProgress_I_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_DataMoveListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_DataMoveListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_DataMoveListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_DataMoveListener.ManagedPeerType;

	public IDataMoveListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnDataMoveCompletedHandler()
	{
		if ((object)cb_onDataMoveCompleted_OnDataMoveCompleted_V == null)
		{
			cb_onDataMoveCompleted_OnDataMoveCompleted_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDataMoveCompleted));
		}
		return cb_onDataMoveCompleted_OnDataMoveCompleted_V;
	}

	private static void n_OnDataMoveCompleted(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IDataMoveListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDataMoveCompleted();
	}

	public unsafe void OnDataMoveCompleted()
	{
		_members_com_yandex_mapkit_offline_cache_DataMoveListener.InstanceMethods.InvokeAbstractVoidMethod("onDataMoveCompleted.()V", this, null);
	}

	private static Delegate GetOnDataMoveError_Lcom_yandex_runtime_Error_Handler()
	{
		if ((object)cb_onDataMoveError_OnDataMoveError_Lcom_yandex_runtime_Error__V == null)
		{
			cb_onDataMoveError_OnDataMoveError_Lcom_yandex_runtime_Error__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDataMoveError_Lcom_yandex_runtime_Error_));
		}
		return cb_onDataMoveError_OnDataMoveError_Lcom_yandex_runtime_Error__V;
	}

	private static void n_OnDataMoveError_Lcom_yandex_runtime_Error_(nint jnienv, nint native__this, nint native_p0)
	{
		IDataMoveListener? dataMoveListener = Java.Lang.Object.GetObject<IDataMoveListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IError p = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
		dataMoveListener.OnDataMoveError(p);
	}

	public unsafe void OnDataMoveError(IError p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_DataMoveListener.InstanceMethods.InvokeAbstractVoidMethod("onDataMoveError.(Lcom/yandex/runtime/Error;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnDataMoveProgress_IHandler()
	{
		if ((object)cb_onDataMoveProgress_OnDataMoveProgress_I_V == null)
		{
			cb_onDataMoveProgress_OnDataMoveProgress_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnDataMoveProgress_I));
		}
		return cb_onDataMoveProgress_OnDataMoveProgress_I_V;
	}

	private static void n_OnDataMoveProgress_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IDataMoveListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDataMoveProgress(p0);
	}

	public unsafe void OnDataMoveProgress(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_DataMoveListener.InstanceMethods.InvokeAbstractVoidMethod("onDataMoveProgress.(I)V", this, ptr);
	}
}
