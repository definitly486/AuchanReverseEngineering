using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapLoadStatistics", DoNotGenerateAcw = true)]
public class MapLoadStatistics : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/MapLoadStatistics", typeof(MapLoadStatistics));

	private static Delegate? cb_getCurZoomGeometryLoaded_GetCurZoomGeometryLoaded_J;

	private static Delegate? cb_getCurZoomLabelsLoaded_GetCurZoomLabelsLoaded_J;

	private static Delegate? cb_getCurZoomModelsLoaded_GetCurZoomModelsLoaded_J;

	private static Delegate? cb_getCurZoomPlacemarksLoaded_GetCurZoomPlacemarksLoaded_J;

	private static Delegate? cb_getDelayedGeometryLoaded_GetDelayedGeometryLoaded_J;

	private static Delegate? cb_getFullyAppeared_GetFullyAppeared_J;

	private static Delegate? cb_getFullyLoaded_GetFullyLoaded_J;

	private static Delegate? cb_getRenderObjectCount_GetRenderObjectCount_I;

	private static Delegate? cb_getTileMemoryUsage_GetTileMemoryUsage_I;

	private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

	public unsafe virtual long CurZoomGeometryLoaded
	{
		[Register("getCurZoomGeometryLoaded", "()J", "GetGetCurZoomGeometryLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getCurZoomGeometryLoaded.()J", this, null);
		}
	}

	public unsafe virtual long CurZoomLabelsLoaded
	{
		[Register("getCurZoomLabelsLoaded", "()J", "GetGetCurZoomLabelsLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getCurZoomLabelsLoaded.()J", this, null);
		}
	}

	public unsafe virtual long CurZoomModelsLoaded
	{
		[Register("getCurZoomModelsLoaded", "()J", "GetGetCurZoomModelsLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getCurZoomModelsLoaded.()J", this, null);
		}
	}

	public unsafe virtual long CurZoomPlacemarksLoaded
	{
		[Register("getCurZoomPlacemarksLoaded", "()J", "GetGetCurZoomPlacemarksLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getCurZoomPlacemarksLoaded.()J", this, null);
		}
	}

	public unsafe virtual long DelayedGeometryLoaded
	{
		[Register("getDelayedGeometryLoaded", "()J", "GetGetDelayedGeometryLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getDelayedGeometryLoaded.()J", this, null);
		}
	}

	public unsafe virtual long FullyAppeared
	{
		[Register("getFullyAppeared", "()J", "GetGetFullyAppearedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getFullyAppeared.()J", this, null);
		}
	}

	public unsafe virtual long FullyLoaded
	{
		[Register("getFullyLoaded", "()J", "GetGetFullyLoadedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getFullyLoaded.()J", this, null);
		}
	}

	public unsafe virtual int RenderObjectCount
	{
		[Register("getRenderObjectCount", "()I", "GetGetRenderObjectCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRenderObjectCount.()I", this, null);
		}
	}

	public unsafe virtual int TileMemoryUsage
	{
		[Register("getTileMemoryUsage", "()I", "GetGetTileMemoryUsageHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTileMemoryUsage.()I", this, null);
		}
	}

	protected MapLoadStatistics(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MapLoadStatistics()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(JJJJJJJII)V", "")]
	public unsafe MapLoadStatistics(long curZoomGeometryLoaded, long curZoomPlacemarksLoaded, long curZoomLabelsLoaded, long delayedGeometryLoaded, long curZoomModelsLoaded, long fullyLoaded, long fullyAppeared, int renderObjectCount, int tileMemoryUsage)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(curZoomGeometryLoaded);
			ptr[1] = new JniArgumentValue(curZoomPlacemarksLoaded);
			ptr[2] = new JniArgumentValue(curZoomLabelsLoaded);
			ptr[3] = new JniArgumentValue(delayedGeometryLoaded);
			ptr[4] = new JniArgumentValue(curZoomModelsLoaded);
			ptr[5] = new JniArgumentValue(fullyLoaded);
			ptr[6] = new JniArgumentValue(fullyAppeared);
			ptr[7] = new JniArgumentValue(renderObjectCount);
			ptr[8] = new JniArgumentValue(tileMemoryUsage);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JJJJJJJII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JJJJJJJII)V", this, ptr);
		}
	}

	private static Delegate GetGetCurZoomGeometryLoadedHandler()
	{
		if ((object)cb_getCurZoomGeometryLoaded_GetCurZoomGeometryLoaded_J == null)
		{
			cb_getCurZoomGeometryLoaded_GetCurZoomGeometryLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurZoomGeometryLoaded));
		}
		return cb_getCurZoomGeometryLoaded_GetCurZoomGeometryLoaded_J;
	}

	private static long n_GetCurZoomGeometryLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurZoomGeometryLoaded;
	}

	private static Delegate GetGetCurZoomLabelsLoadedHandler()
	{
		if ((object)cb_getCurZoomLabelsLoaded_GetCurZoomLabelsLoaded_J == null)
		{
			cb_getCurZoomLabelsLoaded_GetCurZoomLabelsLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurZoomLabelsLoaded));
		}
		return cb_getCurZoomLabelsLoaded_GetCurZoomLabelsLoaded_J;
	}

	private static long n_GetCurZoomLabelsLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurZoomLabelsLoaded;
	}

	private static Delegate GetGetCurZoomModelsLoadedHandler()
	{
		if ((object)cb_getCurZoomModelsLoaded_GetCurZoomModelsLoaded_J == null)
		{
			cb_getCurZoomModelsLoaded_GetCurZoomModelsLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurZoomModelsLoaded));
		}
		return cb_getCurZoomModelsLoaded_GetCurZoomModelsLoaded_J;
	}

	private static long n_GetCurZoomModelsLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurZoomModelsLoaded;
	}

	private static Delegate GetGetCurZoomPlacemarksLoadedHandler()
	{
		if ((object)cb_getCurZoomPlacemarksLoaded_GetCurZoomPlacemarksLoaded_J == null)
		{
			cb_getCurZoomPlacemarksLoaded_GetCurZoomPlacemarksLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurZoomPlacemarksLoaded));
		}
		return cb_getCurZoomPlacemarksLoaded_GetCurZoomPlacemarksLoaded_J;
	}

	private static long n_GetCurZoomPlacemarksLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurZoomPlacemarksLoaded;
	}

	private static Delegate GetGetDelayedGeometryLoadedHandler()
	{
		if ((object)cb_getDelayedGeometryLoaded_GetDelayedGeometryLoaded_J == null)
		{
			cb_getDelayedGeometryLoaded_GetDelayedGeometryLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetDelayedGeometryLoaded));
		}
		return cb_getDelayedGeometryLoaded_GetDelayedGeometryLoaded_J;
	}

	private static long n_GetDelayedGeometryLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DelayedGeometryLoaded;
	}

	private static Delegate GetGetFullyAppearedHandler()
	{
		if ((object)cb_getFullyAppeared_GetFullyAppeared_J == null)
		{
			cb_getFullyAppeared_GetFullyAppeared_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetFullyAppeared));
		}
		return cb_getFullyAppeared_GetFullyAppeared_J;
	}

	private static long n_GetFullyAppeared(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FullyAppeared;
	}

	private static Delegate GetGetFullyLoadedHandler()
	{
		if ((object)cb_getFullyLoaded_GetFullyLoaded_J == null)
		{
			cb_getFullyLoaded_GetFullyLoaded_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetFullyLoaded));
		}
		return cb_getFullyLoaded_GetFullyLoaded_J;
	}

	private static long n_GetFullyLoaded(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FullyLoaded;
	}

	private static Delegate GetGetRenderObjectCountHandler()
	{
		if ((object)cb_getRenderObjectCount_GetRenderObjectCount_I == null)
		{
			cb_getRenderObjectCount_GetRenderObjectCount_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRenderObjectCount));
		}
		return cb_getRenderObjectCount_GetRenderObjectCount_I;
	}

	private static int n_GetRenderObjectCount(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RenderObjectCount;
	}

	private static Delegate GetGetTileMemoryUsageHandler()
	{
		if ((object)cb_getTileMemoryUsage_GetTileMemoryUsage_I == null)
		{
			cb_getTileMemoryUsage_GetTileMemoryUsage_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTileMemoryUsage));
		}
		return cb_getTileMemoryUsage_GetTileMemoryUsage_I;
	}

	private static int n_GetTileMemoryUsage(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TileMemoryUsage;
	}

	private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
	{
		if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
		{
			cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
		}
		return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
	}

	private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
	{
		MapLoadStatistics? mapLoadStatistics = Java.Lang.Object.GetObject<MapLoadStatistics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		mapLoadStatistics.Serialize(archive);
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
	public unsafe virtual void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}
}
