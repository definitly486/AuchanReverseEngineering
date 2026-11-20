using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker")]
public interface IOfflineCacheManager : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$ClearListener", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IClearListenerInvoker")]
	public interface IClearListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClearCompleted", "()V", "GetOnClearCompletedHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IClearListenerInvoker, Yandex.MapKit.Lite")]
		void OnClearCompleted();
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$ClearListener", DoNotGenerateAcw = true)]
	internal class IClearListenerInvoker : Java.Lang.Object, IClearListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager$ClearListener", typeof(IClearListenerInvoker));

		private static Delegate? cb_onClearCompleted_OnClearCompleted_V;

		private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener.ManagedPeerType;

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
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener.InstanceMethods.InvokeAbstractVoidMethod("onClearCompleted.()V", this, null);
		}
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IErrorListenerInvoker")]
	public interface IErrorListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onError", "(Lcom/yandex/runtime/Error;)V", "GetOnError_Lcom_yandex_runtime_Error_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IErrorListenerInvoker, Yandex.MapKit.Lite")]
		void OnError(IError p0);

		[Register("onRegionError", "(Lcom/yandex/runtime/Error;I)V", "GetOnRegionError_Lcom_yandex_runtime_Error_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IErrorListenerInvoker, Yandex.MapKit.Lite")]
		void OnRegionError(IError p0, int p1);
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener", DoNotGenerateAcw = true)]
	internal class IErrorListenerInvoker : Java.Lang.Object, IErrorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener", typeof(IErrorListenerInvoker));

		private static Delegate? cb_onError_OnError_Lcom_yandex_runtime_Error__V;

		private static Delegate? cb_onRegionError_OnRegionError_Lcom_yandex_runtime_Error_I_V;

		private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener.ManagedPeerType;

		public IErrorListenerInvoker(nint handle, JniHandleOwnership transfer)
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
			IErrorListener? errorListener = Java.Lang.Object.GetObject<IErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IError p = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
			errorListener.OnError(p);
		}

		public unsafe void OnError(IError p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener.InstanceMethods.InvokeAbstractVoidMethod("onError.(Lcom/yandex/runtime/Error;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnRegionError_Lcom_yandex_runtime_Error_IHandler()
		{
			if ((object)cb_onRegionError_OnRegionError_Lcom_yandex_runtime_Error_I_V == null)
			{
				cb_onRegionError_OnRegionError_Lcom_yandex_runtime_Error_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnRegionError_Lcom_yandex_runtime_Error_I));
			}
			return cb_onRegionError_OnRegionError_Lcom_yandex_runtime_Error_I_V;
		}

		private static void n_OnRegionError_Lcom_yandex_runtime_Error_I(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			IErrorListener? errorListener = Java.Lang.Object.GetObject<IErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IError p2 = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
			errorListener.OnRegionError(p2, p1);
		}

		public unsafe void OnRegionError(IError p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(p1);
				_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener.InstanceMethods.InvokeAbstractVoidMethod("onRegionError.(Lcom/yandex/runtime/Error;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathGetterListener", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IPathGetterListenerInvoker")]
	public interface IPathGetterListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPathReceived", "(Ljava/lang/String;)V", "GetOnPathReceived_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IPathGetterListenerInvoker, Yandex.MapKit.Lite")]
		void OnPathReceived(string p0);
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathGetterListener", DoNotGenerateAcw = true)]
	internal class IPathGetterListenerInvoker : Java.Lang.Object, IPathGetterListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathGetterListener", typeof(IPathGetterListenerInvoker));

		private static Delegate? cb_onPathReceived_OnPathReceived_Ljava_lang_String__V;

		private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener.ManagedPeerType;

		public IPathGetterListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnPathReceived_Ljava_lang_String_Handler()
		{
			if ((object)cb_onPathReceived_OnPathReceived_Ljava_lang_String__V == null)
			{
				cb_onPathReceived_OnPathReceived_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPathReceived_Ljava_lang_String_));
			}
			return cb_onPathReceived_OnPathReceived_Ljava_lang_String__V;
		}

		private static void n_OnPathReceived_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
		{
			IPathGetterListener? pathGetterListener = Java.Lang.Object.GetObject<IPathGetterListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			pathGetterListener.OnPathReceived(p);
		}

		public unsafe void OnPathReceived(string p0)
		{
			nint num = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener.InstanceMethods.InvokeAbstractVoidMethod("onPathReceived.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathSetterListener", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IPathSetterListenerInvoker")]
	public interface IPathSetterListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPathSet", "()V", "GetOnPathSetHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IPathSetterListenerInvoker, Yandex.MapKit.Lite")]
		void OnPathSet();

		[Register("onPathSetError", "(Lcom/yandex/runtime/Error;)V", "GetOnPathSetError_Lcom_yandex_runtime_Error_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/IPathSetterListenerInvoker, Yandex.MapKit.Lite")]
		void OnPathSetError(IError p0);
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathSetterListener", DoNotGenerateAcw = true)]
	internal class IPathSetterListenerInvoker : Java.Lang.Object, IPathSetterListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager$PathSetterListener", typeof(IPathSetterListenerInvoker));

		private static Delegate? cb_onPathSet_OnPathSet_V;

		private static Delegate? cb_onPathSetError_OnPathSetError_Lcom_yandex_runtime_Error__V;

		private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener.ManagedPeerType;

		public IPathSetterListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnPathSetHandler()
		{
			if ((object)cb_onPathSet_OnPathSet_V == null)
			{
				cb_onPathSet_OnPathSet_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnPathSet));
			}
			return cb_onPathSet_OnPathSet_V;
		}

		private static void n_OnPathSet(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IPathSetterListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPathSet();
		}

		public unsafe void OnPathSet()
		{
			_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener.InstanceMethods.InvokeAbstractVoidMethod("onPathSet.()V", this, null);
		}

		private static Delegate GetOnPathSetError_Lcom_yandex_runtime_Error_Handler()
		{
			if ((object)cb_onPathSetError_OnPathSetError_Lcom_yandex_runtime_Error__V == null)
			{
				cb_onPathSetError_OnPathSetError_Lcom_yandex_runtime_Error__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPathSetError_Lcom_yandex_runtime_Error_));
			}
			return cb_onPathSetError_OnPathSetError_Lcom_yandex_runtime_Error__V;
		}

		private static void n_OnPathSetError_Lcom_yandex_runtime_Error_(nint jnienv, nint native__this, nint native_p0)
		{
			IPathSetterListener? pathSetterListener = Java.Lang.Object.GetObject<IPathSetterListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IError p = Java.Lang.Object.GetObject<IError>(native_p0, JniHandleOwnership.DoNotTransfer);
			pathSetterListener.OnPathSetError(p);
		}

		public unsafe void OnPathSetError(IError p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener.InstanceMethods.InvokeAbstractVoidMethod("onPathSetError.(Lcom/yandex/runtime/Error;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$SizeListener", "", "Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/ISizeListenerInvoker")]
	public interface ISizeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSizeComputed", "(Ljava/lang/Long;)V", "GetOnSizeComputed_Ljava_lang_Long_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManager/ISizeListenerInvoker, Yandex.MapKit.Lite")]
		void OnSizeComputed(Long? p0);
	}

	[Register("com/yandex/mapkit/offline_cache/OfflineCacheManager$SizeListener", DoNotGenerateAcw = true)]
	internal class ISizeListenerInvoker : Java.Lang.Object, ISizeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/OfflineCacheManager$SizeListener", typeof(ISizeListenerInvoker));

		private static Delegate? cb_onSizeComputed_OnSizeComputed_Ljava_lang_Long__V;

		private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener.ManagedPeerType;

		public ISizeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnSizeComputed_Ljava_lang_Long_Handler()
		{
			if ((object)cb_onSizeComputed_OnSizeComputed_Ljava_lang_Long__V == null)
			{
				cb_onSizeComputed_OnSizeComputed_Ljava_lang_Long__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSizeComputed_Ljava_lang_Long_));
			}
			return cb_onSizeComputed_OnSizeComputed_Ljava_lang_Long__V;
		}

		private static void n_OnSizeComputed_Ljava_lang_Long_(nint jnienv, nint native__this, nint native_p0)
		{
			ISizeListener? sizeListener = Java.Lang.Object.GetObject<ISizeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Long p = Java.Lang.Object.GetObject<Long>(native_p0, JniHandleOwnership.DoNotTransfer);
			sizeListener.OnSizeComputed(p);
		}

		public unsafe void OnSizeComputed(Long? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener.InstanceMethods.InvokeAbstractVoidMethod("onSizeComputed.(Ljava/lang/Long;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("addErrorListener", "(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener;)V", "GetAddErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void AddErrorListener(IErrorListener p0);

	[Register("addRegionListUpdatesListener", "(Lcom/yandex/mapkit/offline_cache/RegionListUpdatesListener;)V", "GetAddRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void AddRegionListUpdatesListener(IRegionListUpdatesListener p0);

	[Register("addRegionListener", "(Lcom/yandex/mapkit/offline_cache/RegionListener;)V", "GetAddRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void AddRegionListener(IRegionListener p0);

	[Register("allowUseCellularNetwork", "(Z)V", "GetAllowUseCellularNetwork_ZHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void AllowUseCellularNetwork(bool p0);

	[Register("clear", "(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ClearListener;)V", "GetClear_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ClearListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void Clear(IClearListener p0);

	[Register("computeCacheSize", "(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$SizeListener;)V", "GetComputeCacheSize_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_SizeListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void ComputeCacheSize(ISizeListener p0);

	[Register("drop", "(I)V", "GetDrop_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void Drop(int p0);

	[Register("enableAutoUpdate", "(Z)V", "GetEnableAutoUpdate_ZHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void EnableAutoUpdate(bool p0);

	[Register("getCities", "(I)Ljava/util/List;", "GetGetCities_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	IList<string> GetCities(int p0);

	[Register("getDownloadedReleaseTime", "(I)Ljava/lang/Long;", "GetGetDownloadedReleaseTime_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	Long? GetDownloadedReleaseTime(int p0);

	[Register("getProgress", "(I)F", "GetGetProgress_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	float GetProgress(int p0);

	[Register("getState", "(I)Lcom/yandex/mapkit/offline_cache/RegionState;", "GetGetState_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	RegionState GetState(int p0);

	[Register("isLegacyPath", "(I)Z", "GetIsLegacyPath_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	bool IsLegacyPath(int p0);

	[Register("mayBeOutOfAvailableSpace", "(I)Z", "GetMayBeOutOfAvailableSpace_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	bool MayBeOutOfAvailableSpace(int p0);

	[Register("moveData", "(Ljava/lang/String;Lcom/yandex/mapkit/offline_cache/DataMoveListener;)V", "GetMoveData_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_DataMoveListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void MoveData(string p0, IDataMoveListener p1);

	[Register("pauseDownload", "(I)V", "GetPauseDownload_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void PauseDownload(int p0);

	[Register("regions", "()Ljava/util/List;", "GetRegionsHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	IList<Region> Regions();

	[Register("removeErrorListener", "(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$ErrorListener;)V", "GetRemoveErrorListener_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ErrorListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void RemoveErrorListener(IErrorListener p0);

	[Register("removeRegionListUpdatesListener", "(Lcom/yandex/mapkit/offline_cache/RegionListUpdatesListener;)V", "GetRemoveRegionListUpdatesListener_Lcom_yandex_mapkit_offline_cache_RegionListUpdatesListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void RemoveRegionListUpdatesListener(IRegionListUpdatesListener p0);

	[Register("removeRegionListener", "(Lcom/yandex/mapkit/offline_cache/RegionListener;)V", "GetRemoveRegionListener_Lcom_yandex_mapkit_offline_cache_RegionListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void RemoveRegionListener(IRegionListener p0);

	[Register("requestPath", "(Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$PathGetterListener;)V", "GetRequestPath_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathGetterListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void RequestPath(IPathGetterListener p0);

	[Register("requestRegionsAtPoint", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/offline_cache/RegionsAtPointListener;)V", "GetRequestRegionsAtPoint_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_mapkit_offline_cache_RegionsAtPointListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void RequestRegionsAtPoint(Point p0, IRegionsAtPointListener p1);

	[Register("setCachePath", "(Ljava/lang/String;Lcom/yandex/mapkit/offline_cache/OfflineCacheManager$PathSetterListener;)V", "GetSetCachePath_Ljava_lang_String_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_PathSetterListener_Handler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void SetCachePath(string p0, IPathSetterListener p1);

	[Register("startDownload", "(I)V", "GetStartDownload_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void StartDownload(int p0);

	[Register("stopDownload", "(I)V", "GetStopDownload_IHandler:Com.Yandex.Mapkit.Offline_cache.IOfflineCacheManagerInvoker, Yandex.MapKit.Lite")]
	void StopDownload(int p0);
}
