using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Storage;

[Register("com/yandex/mapkit/storage/StorageErrorListener", DoNotGenerateAcw = true)]
internal class IStorageErrorListenerInvoker : Java.Lang.Object, IStorageErrorListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_storage_StorageErrorListener = new XAPeerMembers("com/yandex/mapkit/storage/StorageErrorListener", typeof(IStorageErrorListenerInvoker));

	private static Delegate? cb_onStorageError_OnStorageError_Lcom_yandex_runtime_LocalError__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_storage_StorageErrorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_storage_StorageErrorListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_storage_StorageErrorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_storage_StorageErrorListener.ManagedPeerType;

	public IStorageErrorListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnStorageError_Lcom_yandex_runtime_LocalError_Handler()
	{
		if ((object)cb_onStorageError_OnStorageError_Lcom_yandex_runtime_LocalError__V == null)
		{
			cb_onStorageError_OnStorageError_Lcom_yandex_runtime_LocalError__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnStorageError_Lcom_yandex_runtime_LocalError_));
		}
		return cb_onStorageError_OnStorageError_Lcom_yandex_runtime_LocalError__V;
	}

	private static void n_OnStorageError_Lcom_yandex_runtime_LocalError_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageErrorListener? storageErrorListener = Java.Lang.Object.GetObject<IStorageErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocalError p = Java.Lang.Object.GetObject<ILocalError>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageErrorListener.OnStorageError(p);
	}

	public unsafe void OnStorageError(ILocalError p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageErrorListener.InstanceMethods.InvokeAbstractVoidMethod("onStorageError.(Lcom/yandex/runtime/LocalError;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
