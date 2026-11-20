using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Storage;

[Register("com/yandex/mapkit/storage/StorageManager", "", "Com.Yandex.Mapkit.Storage.IStorageManagerInvoker")]
public interface IStorageManager : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/storage/StorageManager$ClearListener", "", "Com.Yandex.Mapkit.Storage.IStorageManager/IClearListenerInvoker")]
	public interface IClearListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClearCompleted", "()V", "GetOnClearCompletedHandler:Com.Yandex.Mapkit.Storage.IStorageManager/IClearListenerInvoker, Yandex.MapKit.Lite")]
		void OnClearCompleted();
	}

	[Register("com/yandex/mapkit/storage/StorageManager$ClearListener", DoNotGenerateAcw = true)]
	internal class IClearListenerInvoker : Java.Lang.Object, IClearListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_storage_StorageManager_ClearListener = new XAPeerMembers("com/yandex/mapkit/storage/StorageManager$ClearListener", typeof(IClearListenerInvoker));

		private static Delegate? cb_onClearCompleted_OnClearCompleted_V;

		private static nint java_class_ref => _members_com_yandex_mapkit_storage_StorageManager_ClearListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_storage_StorageManager_ClearListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_storage_StorageManager_ClearListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_storage_StorageManager_ClearListener.ManagedPeerType;

		public IClearListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnClearCompletedHandler()
		{
			if ((object)cb_onClearCompleted_OnClearCompleted_V == null)
			{
				cb_onClearCompleted_OnClearCompleted_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnClearCompleted));
			}
			return cb_onClearCompleted_OnClearCompleted_V;
		}

		private static void n_OnClearCompleted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IClearListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnClearCompleted();
		}

		public unsafe void OnClearCompleted()
		{
			_members_com_yandex_mapkit_storage_StorageManager_ClearListener.InstanceMethods.InvokeAbstractVoidMethod("onClearCompleted.()V", this, null);
		}
	}

	[Register("com/yandex/mapkit/storage/StorageManager$SizeListener", "", "Com.Yandex.Mapkit.Storage.IStorageManager/ISizeListenerInvoker")]
	public interface ISizeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onError", "(Lcom/yandex/runtime/Error;)V", "GetOnError_Lcom_yandex_runtime_Error_Handler:Com.Yandex.Mapkit.Storage.IStorageManager/ISizeListenerInvoker, Yandex.MapKit.Lite")]
		void OnError(IError p0);

		[Register("onSuccess", "(Ljava/lang/Long;)V", "GetOnSuccess_Ljava_lang_Long_Handler:Com.Yandex.Mapkit.Storage.IStorageManager/ISizeListenerInvoker, Yandex.MapKit.Lite")]
		void OnSuccess(Long? p0);
	}

	[Register("com/yandex/mapkit/storage/StorageManager$SizeListener", DoNotGenerateAcw = true)]
	internal class ISizeListenerInvoker : Java.Lang.Object, ISizeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_storage_StorageManager_SizeListener = new XAPeerMembers("com/yandex/mapkit/storage/StorageManager$SizeListener", typeof(ISizeListenerInvoker));

		private static Delegate? cb_onError_OnError_Lcom_yandex_runtime_Error__V;

		private static Delegate? cb_onSuccess_OnSuccess_Ljava_lang_Long__V;

		private static nint java_class_ref => _members_com_yandex_mapkit_storage_StorageManager_SizeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_storage_StorageManager_SizeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_storage_StorageManager_SizeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_storage_StorageManager_SizeListener.ManagedPeerType;

		public ISizeListenerInvoker(nint handle, JniHandleOwnership transfer)
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
			ISizeListener? sizeListener = Java.Lang.Object.GetObject<ISizeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IError p = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
			sizeListener.OnError(p);
		}

		public unsafe void OnError(IError p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members_com_yandex_mapkit_storage_StorageManager_SizeListener.InstanceMethods.InvokeAbstractVoidMethod("onError.(Lcom/yandex/runtime/Error;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnSuccess_Ljava_lang_Long_Handler()
		{
			if ((object)cb_onSuccess_OnSuccess_Ljava_lang_Long__V == null)
			{
				cb_onSuccess_OnSuccess_Ljava_lang_Long__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_Long_));
			}
			return cb_onSuccess_OnSuccess_Ljava_lang_Long__V;
		}

		private static void n_OnSuccess_Ljava_lang_Long_(nint jnienv, nint native__this, nint native_p0)
		{
			ISizeListener? sizeListener = Java.Lang.Object.GetObject<ISizeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Long p = Java.Lang.Object.GetObject<Long>(native_p0, JniHandleOwnership.DoNotTransfer);
			sizeListener.OnSuccess(p);
		}

		public unsafe void OnSuccess(Long? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_storage_StorageManager_SizeListener.InstanceMethods.InvokeAbstractVoidMethod("onSuccess.(Ljava/lang/Long;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("addStorageErrorListener", "(Lcom/yandex/mapkit/storage/StorageErrorListener;)V", "GetAddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void AddStorageErrorListener(IStorageErrorListener p0);

	[Register("clear", "(Lcom/yandex/mapkit/storage/StorageManager$ClearListener;)V", "GetClear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void Clear(IClearListener p0);

	[Register("computeSize", "(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", "GetComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void ComputeSize(ISizeListener p0);

	[Register("maxTileStorageSize", "(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", "GetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void MaxTileStorageSize(ISizeListener p0);

	[Register("removeStorageErrorListener", "(Lcom/yandex/mapkit/storage/StorageErrorListener;)V", "GetRemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void RemoveStorageErrorListener(IStorageErrorListener p0);

	[Register("resetMaxTileStorageSize", "(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", "GetResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void ResetMaxTileStorageSize(ISizeListener p0);

	[Register("setMaxTileStorageSize", "(JLcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", "GetSetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler:Com.Yandex.Mapkit.Storage.IStorageManagerInvoker, Yandex.MapKit.Lite")]
	void SetMaxTileStorageSize(long p0, ISizeListener p1);
}
