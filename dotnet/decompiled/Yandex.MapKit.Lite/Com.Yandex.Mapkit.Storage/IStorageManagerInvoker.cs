using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Storage;

[Register("com/yandex/mapkit/storage/StorageManager", DoNotGenerateAcw = true)]
internal class IStorageManagerInvoker : Java.Lang.Object, IStorageManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_storage_StorageManager = new XAPeerMembers("com/yandex/mapkit/storage/StorageManager", typeof(IStorageManagerInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_addStorageErrorListener_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V;

	private static Delegate? cb_clear_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener__V;

	private static Delegate? cb_computeSize_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;

	private static Delegate? cb_maxTileStorageSize_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;

	private static Delegate? cb_removeStorageErrorListener_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V;

	private static Delegate? cb_resetMaxTileStorageSize_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;

	private static Delegate? cb_setMaxTileStorageSize_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_storage_StorageManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_storage_StorageManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_storage_StorageManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_storage_StorageManager.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IStorageManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetAddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_Handler()
	{
		if ((object)cb_addStorageErrorListener_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V == null)
		{
			cb_addStorageErrorListener_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_));
		}
		return cb_addStorageErrorListener_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V;
	}

	private static void n_AddStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageErrorListener p = Java.Lang.Object.GetObject<IStorageErrorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.AddStorageErrorListener(p);
	}

	public unsafe void AddStorageErrorListener(IStorageErrorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("addStorageErrorListener.(Lcom/yandex/mapkit/storage/StorageErrorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetClear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener_Handler()
	{
		if ((object)cb_clear_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener__V == null)
		{
			cb_clear_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener_));
		}
		return cb_clear_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener__V;
	}

	private static void n_Clear_Lcom_yandex_mapkit_storage_StorageManager_ClearListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageManager.IClearListener p = Java.Lang.Object.GetObject<IStorageManager.IClearListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.Clear(p);
	}

	public unsafe void Clear(IStorageManager.IClearListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("clear.(Lcom/yandex/mapkit/storage/StorageManager$ClearListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler()
	{
		if ((object)cb_computeSize_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V == null)
		{
			cb_computeSize_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_));
		}
		return cb_computeSize_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;
	}

	private static void n_ComputeSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageManager.ISizeListener p = Java.Lang.Object.GetObject<IStorageManager.ISizeListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.ComputeSize(p);
	}

	public unsafe void ComputeSize(IStorageManager.ISizeListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("computeSize.(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler()
	{
		if ((object)cb_maxTileStorageSize_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V == null)
		{
			cb_maxTileStorageSize_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_));
		}
		return cb_maxTileStorageSize_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;
	}

	private static void n_MaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageManager.ISizeListener p = Java.Lang.Object.GetObject<IStorageManager.ISizeListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.MaxTileStorageSize(p);
	}

	public unsafe void MaxTileStorageSize(IStorageManager.ISizeListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("maxTileStorageSize.(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_Handler()
	{
		if ((object)cb_removeStorageErrorListener_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V == null)
		{
			cb_removeStorageErrorListener_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_));
		}
		return cb_removeStorageErrorListener_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener__V;
	}

	private static void n_RemoveStorageErrorListener_Lcom_yandex_mapkit_storage_StorageErrorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageErrorListener p = Java.Lang.Object.GetObject<IStorageErrorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.RemoveStorageErrorListener(p);
	}

	public unsafe void RemoveStorageErrorListener(IStorageErrorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("removeStorageErrorListener.(Lcom/yandex/mapkit/storage/StorageErrorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler()
	{
		if ((object)cb_resetMaxTileStorageSize_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V == null)
		{
			cb_resetMaxTileStorageSize_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_));
		}
		return cb_resetMaxTileStorageSize_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener__V;
	}

	private static void n_ResetMaxTileStorageSize_Lcom_yandex_mapkit_storage_StorageManager_SizeListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageManager.ISizeListener p = Java.Lang.Object.GetObject<IStorageManager.ISizeListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		storageManager.ResetMaxTileStorageSize(p);
	}

	public unsafe void ResetMaxTileStorageSize(IStorageManager.ISizeListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("resetMaxTileStorageSize.(Lcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener_Handler()
	{
		if ((object)cb_setMaxTileStorageSize_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener__V == null)
		{
			cb_setMaxTileStorageSize_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener__V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener_));
		}
		return cb_setMaxTileStorageSize_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener__V;
	}

	private static void n_SetMaxTileStorageSize_JLcom_yandex_mapkit_storage_StorageManager_SizeListener_(nint jnienv, nint native__this, long p0, nint native_p1)
	{
		IStorageManager? storageManager = Java.Lang.Object.GetObject<IStorageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStorageManager.ISizeListener p1 = Java.Lang.Object.GetObject<IStorageManager.ISizeListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		storageManager.SetMaxTileStorageSize(p0, p1);
	}

	public unsafe void SetMaxTileStorageSize(long p0, IStorageManager.ISizeListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_storage_StorageManager.InstanceMethods.InvokeAbstractVoidMethod("setMaxTileStorageSize.(JLcom/yandex/mapkit/storage/StorageManager$SizeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}
}
