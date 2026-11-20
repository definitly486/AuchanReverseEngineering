using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager", DoNotGenerateAcw = true)]
internal class IOfflineCacheManagerInvoker : Java.Lang.Object, IOfflineCacheManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager", typeof(IOfflineCacheManagerInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_addErrorListener_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V;

	private static Delegate? cb_addRegionListUpdatesListener_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V;

	private static Delegate? cb_addRegionListener_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V;

	private static Delegate? cb_allowUseCellularNetwork_AllowUseCellularNetwork_Z_V;

	private static Delegate? cb_clear_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener__V;

	private static Delegate? cb_computeCacheSize_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener__V;

	private static Delegate? cb_drop_Drop_I_V;

	private static Delegate? cb_enableAutoUpdate_EnableAutoUpdate_Z_V;

	private static Delegate? cb_getCities_GetCities_I_Ljava_util_List_;

	private static Delegate? cb_getDownloadedReleaseTime_GetDownloadedReleaseTime_I_Ljava_lang_Long_;

	private static Delegate? cb_getProgress_GetProgress_I_F;

	private static Delegate? cb_getState_GetState_I_Lcom_yandex_mapkit_offline_cache_RegionState_;

	private static Delegate? cb_isLegacyPath_IsLegacyPath_I_Z;

	private static Delegate? cb_mayBeOutOfAvailableSpace_MayBeOutOfAvailableSpace_I_Z;

	private static Delegate? cb_moveData_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener__V;

	private static Delegate? cb_pauseDownload_PauseDownload_I_V;

	private static Delegate? cb_regions_Regions_Ljava_util_List_;

	private static Delegate? cb_removeErrorListener_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V;

	private static Delegate? cb_removeRegionListUpdatesListener_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V;

	private static Delegate? cb_removeRegionListener_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V;

	private static Delegate? cb_requestPath_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener__V;

	private static Delegate? cb_requestRegionsAtPoint_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener__V;

	private static Delegate? cb_setCachePath_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener__V;

	private static Delegate? cb_startDownload_StartDownload_I_V;

	private static Delegate? cb_stopDownload_StopDownload_I_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IOfflineCacheManagerInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetAddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_Handler()
	{
		if ((object)cb_addErrorListener_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V == null)
		{
			cb_addErrorListener_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_));
		}
		return cb_addErrorListener_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V;
	}

	private static void n_AddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.IErrorListener p = Java.Lang.Object.GetObject<IOfflineCacheManager.IErrorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.AddErrorListener(p);
	}

	public unsafe void AddErrorListener(IOfflineCacheManager.IErrorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("addErrorListener.(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_Handler()
	{
		if ((object)cb_addRegionListUpdatesListener_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V == null)
		{
			cb_addRegionListUpdatesListener_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_));
		}
		return cb_addRegionListUpdatesListener_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V;
	}

	private static void n_AddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRegionListUpdatesListener p = Java.Lang.Object.GetObject<IRegionListUpdatesListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.AddRegionListUpdatesListener(p);
	}

	public unsafe void AddRegionListUpdatesListener(IRegionListUpdatesListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("addRegionListUpdatesListener.(Lcom/yandex/mapkit/offline_cache/RegionListUpdatesListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_Handler()
	{
		if ((object)cb_addRegionListener_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V == null)
		{
			cb_addRegionListener_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_));
		}
		return cb_addRegionListener_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V;
	}

	private static void n_AddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRegionListener p = Java.Lang.Object.GetObject<IRegionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.AddRegionListener(p);
	}

	public unsafe void AddRegionListener(IRegionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("addRegionListener.(Lcom/yandex/mapkit/offline_cache/RegionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAllowUseCellularNetwork_ZHandler()
	{
		if ((object)cb_allowUseCellularNetwork_AllowUseCellularNetwork_Z_V == null)
		{
			cb_allowUseCellularNetwork_AllowUseCellularNetwork_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_AllowUseCellularNetwork_Z));
		}
		return cb_allowUseCellularNetwork_AllowUseCellularNetwork_Z_V;
	}

	private static void n_AllowUseCellularNetwork_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowUseCellularNetwork(p0);
	}

	public unsafe void AllowUseCellularNetwork(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("allowUseCellularNetwork.(Z)V", this, ptr);
	}

	private static Delegate GetClear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener_Handler()
	{
		if ((object)cb_clear_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener__V == null)
		{
			cb_clear_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener_));
		}
		return cb_clear_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener__V;
	}

	private static void n_Clear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.IClearListener p = Java.Lang.Object.GetObject<IOfflineCacheManager.IClearListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.Clear(p);
	}

	public unsafe void Clear(IOfflineCacheManager.IClearListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("clear.(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ClearListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener_Handler()
	{
		if ((object)cb_computeCacheSize_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener__V == null)
		{
			cb_computeCacheSize_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener_));
		}
		return cb_computeCacheSize_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener__V;
	}

	private static void n_ComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.ISizeListener p = Java.Lang.Object.GetObject<IOfflineCacheManager.ISizeListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.ComputeCacheSize(p);
	}

	public unsafe void ComputeCacheSize(IOfflineCacheManager.ISizeListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("computeCacheSize.(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$SizeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetDrop_IHandler()
	{
		if ((object)cb_drop_Drop_I_V == null)
		{
			cb_drop_Drop_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Drop_I));
		}
		return cb_drop_Drop_I_V;
	}

	private static void n_Drop_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Drop(p0);
	}

	public unsafe void Drop(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("drop.(I)V", this, ptr);
	}

	private static Delegate GetEnableAutoUpdate_ZHandler()
	{
		if ((object)cb_enableAutoUpdate_EnableAutoUpdate_Z_V == null)
		{
			cb_enableAutoUpdate_EnableAutoUpdate_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_EnableAutoUpdate_Z));
		}
		return cb_enableAutoUpdate_EnableAutoUpdate_Z_V;
	}

	private static void n_EnableAutoUpdate_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableAutoUpdate(p0);
	}

	public unsafe void EnableAutoUpdate(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("enableAutoUpdate.(Z)V", this, ptr);
	}

	private static Delegate GetGetCities_IHandler()
	{
		if ((object)cb_getCities_GetCities_I_Ljava_util_List_ == null)
		{
			cb_getCities_GetCities_I_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetCities_I));
		}
		return cb_getCities_GetCities_I_Ljava_util_List_;
	}

	private static nint n_GetCities_I(nint jnienv, nint native__this, int p0)
	{
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetCities(p0));
	}

	public unsafe IList<string> GetCities(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return JavaList<string>.FromJniHandle(_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractObjectMethod("getCities.(I)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetDownloadedReleaseTime_IHandler()
	{
		if ((object)cb_getDownloadedReleaseTime_GetDownloadedReleaseTime_I_Ljava_lang_Long_ == null)
		{
			cb_getDownloadedReleaseTime_GetDownloadedReleaseTime_I_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetDownloadedReleaseTime_I));
		}
		return cb_getDownloadedReleaseTime_GetDownloadedReleaseTime_I_Ljava_lang_Long_;
	}

	private static nint n_GetDownloadedReleaseTime_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDownloadedReleaseTime(p0));
	}

	public unsafe Long? GetDownloadedReleaseTime(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return Java.Lang.Object.GetObject<Long>(_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractObjectMethod("getDownloadedReleaseTime.(I)Ljava/lang/Long;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetProgress_IHandler()
	{
		if ((object)cb_getProgress_GetProgress_I_F == null)
		{
			cb_getProgress_GetProgress_I_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetProgress_I));
		}
		return cb_getProgress_GetProgress_I_F;
	}

	private static float n_GetProgress_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetProgress(p0);
	}

	public unsafe float GetProgress(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractSingleMethod("getProgress.(I)F", this, ptr);
	}

	private static Delegate GetGetState_IHandler()
	{
		if ((object)cb_getState_GetState_I_Lcom_yandex_mapkit_offline_cache_RegionState_ == null)
		{
			cb_getState_GetState_I_Lcom_yandex_mapkit_offline_cache_RegionState_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetState_I));
		}
		return cb_getState_GetState_I_Lcom_yandex_mapkit_offline_cache_RegionState_;
	}

	private static nint n_GetState_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetState(p0));
	}

	public unsafe RegionState GetState(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return Java.Lang.Object.GetObject<RegionState>(_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractObjectMethod("getState.(I)Lcom/yandex/mapkit/offline_cache/RegionState;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsLegacyPath_IHandler()
	{
		if ((object)cb_isLegacyPath_IsLegacyPath_I_Z == null)
		{
			cb_isLegacyPath_IsLegacyPath_I_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPI_Z(n_IsLegacyPath_I));
		}
		return cb_isLegacyPath_IsLegacyPath_I_Z;
	}

	private static bool n_IsLegacyPath_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLegacyPath(p0);
	}

	public unsafe bool IsLegacyPath(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractBooleanMethod("isLegacyPath.(I)Z", this, ptr);
	}

	private static Delegate GetMayBeOutOfAvailableSpace_IHandler()
	{
		if ((object)cb_mayBeOutOfAvailableSpace_MayBeOutOfAvailableSpace_I_Z == null)
		{
			cb_mayBeOutOfAvailableSpace_MayBeOutOfAvailableSpace_I_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPI_Z(n_MayBeOutOfAvailableSpace_I));
		}
		return cb_mayBeOutOfAvailableSpace_MayBeOutOfAvailableSpace_I_Z;
	}

	private static bool n_MayBeOutOfAvailableSpace_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MayBeOutOfAvailableSpace(p0);
	}

	public unsafe bool MayBeOutOfAvailableSpace(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractBooleanMethod("mayBeOutOfAvailableSpace.(I)Z", this, ptr);
	}

	private static Delegate GetMoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener_Handler()
	{
		if ((object)cb_moveData_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener__V == null)
		{
			cb_moveData_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener_));
		}
		return cb_moveData_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener__V;
	}

	private static void n_MoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		IDataMoveListener p2 = Java.Lang.Object.GetObject<IDataMoveListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.MoveData(p, p2);
	}

	public unsafe void MoveData(string p0, IDataMoveListener p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("moveData.(Ljava/lang/String;Lcom/yandex/mapkit/offline_cache/DataMoveListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetPauseDownload_IHandler()
	{
		if ((object)cb_pauseDownload_PauseDownload_I_V == null)
		{
			cb_pauseDownload_PauseDownload_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_PauseDownload_I));
		}
		return cb_pauseDownload_PauseDownload_I_V;
	}

	private static void n_PauseDownload_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseDownload(p0);
	}

	public unsafe void PauseDownload(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("pauseDownload.(I)V", this, ptr);
	}

	private static Delegate GetRegionsHandler()
	{
		if ((object)cb_regions_Regions_Ljava_util_List_ == null)
		{
			cb_regions_Regions_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Regions));
		}
		return cb_regions_Regions_Ljava_util_List_;
	}

	private static nint n_Regions(nint jnienv, nint native__this)
	{
		return JavaList<Region>.ToLocalJniHandle(Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Regions());
	}

	public unsafe IList<Region> Regions()
	{
		return JavaList<Region>.FromJniHandle(_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractObjectMethod("regions.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_Handler()
	{
		if ((object)cb_removeErrorListener_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V == null)
		{
			cb_removeErrorListener_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_));
		}
		return cb_removeErrorListener_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener__V;
	}

	private static void n_RemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.IErrorListener p = Java.Lang.Object.GetObject<IOfflineCacheManager.IErrorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.RemoveErrorListener(p);
	}

	public unsafe void RemoveErrorListener(IOfflineCacheManager.IErrorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("removeErrorListener.(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_Handler()
	{
		if ((object)cb_removeRegionListUpdatesListener_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V == null)
		{
			cb_removeRegionListUpdatesListener_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_));
		}
		return cb_removeRegionListUpdatesListener_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener__V;
	}

	private static void n_RemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRegionListUpdatesListener p = Java.Lang.Object.GetObject<IRegionListUpdatesListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.RemoveRegionListUpdatesListener(p);
	}

	public unsafe void RemoveRegionListUpdatesListener(IRegionListUpdatesListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("removeRegionListUpdatesListener.(Lcom/yandex/mapkit/offline_cache/RegionListUpdatesListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_Handler()
	{
		if ((object)cb_removeRegionListener_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V == null)
		{
			cb_removeRegionListener_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_));
		}
		return cb_removeRegionListener_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener__V;
	}

	private static void n_RemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRegionListener p = Java.Lang.Object.GetObject<IRegionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.RemoveRegionListener(p);
	}

	public unsafe void RemoveRegionListener(IRegionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("removeRegionListener.(Lcom/yandex/mapkit/offline_cache/RegionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener_Handler()
	{
		if ((object)cb_requestPath_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener__V == null)
		{
			cb_requestPath_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener_));
		}
		return cb_requestPath_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener__V;
	}

	private static void n_RequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.IPathGetterListener p = Java.Lang.Object.GetObject<IOfflineCacheManager.IPathGetterListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.RequestPath(p);
	}

	public unsafe void RequestPath(IOfflineCacheManager.IPathGetterListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("requestPath.(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$PathGetterListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener_Handler()
	{
		if ((object)cb_requestRegionsAtPoint_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener__V == null)
		{
			cb_requestRegionsAtPoint_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener_));
		}
		return cb_requestRegionsAtPoint_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener__V;
	}

	private static void n_RequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		IRegionsAtPointListener p2 = Java.Lang.Object.GetObject<IRegionsAtPointListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.RequestRegionsAtPoint(p, p2);
	}

	public unsafe void RequestRegionsAtPoint(Point p0, IRegionsAtPointListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("requestRegionsAtPoint.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/offline_cache/RegionsAtPointListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener_Handler()
	{
		if ((object)cb_setCachePath_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener__V == null)
		{
			cb_setCachePath_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener_));
		}
		return cb_setCachePath_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener__V;
	}

	private static void n_SetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IOfflineCacheManager? offlineCacheManager = Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		IOfflineCacheManager.IPathSetterListener p2 = Java.Lang.Object.GetObject<IOfflineCacheManager.IPathSetterListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		offlineCacheManager.SetCachePath(p, p2);
	}

	public unsafe void SetCachePath(string p0, IOfflineCacheManager.IPathSetterListener p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("setCachePath.(Ljava/lang/String;Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$PathSetterListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetStartDownload_IHandler()
	{
		if ((object)cb_startDownload_StartDownload_I_V == null)
		{
			cb_startDownload_StartDownload_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_StartDownload_I));
		}
		return cb_startDownload_StartDownload_I_V;
	}

	private static void n_StartDownload_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDownload(p0);
	}

	public unsafe void StartDownload(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("startDownload.(I)V", this, ptr);
	}

	private static Delegate GetStopDownload_IHandler()
	{
		if ((object)cb_stopDownload_StopDownload_I_V == null)
		{
			cb_stopDownload_StopDownload_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_StopDownload_I));
		}
		return cb_stopDownload_StopDownload_I_V;
	}

	private static void n_StopDownload_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IOfflineCacheManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopDownload(p0);
	}

	public unsafe void StopDownload(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_OfflineCacheManager.InstanceMethods.InvokeAbstractVoidMethod("stopDownload.(I)V", this, ptr);
	}
}
