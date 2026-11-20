using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Cluster", DoNotGenerateAcw = true)]
internal class IClusterInvoker : Java.Lang.Object, ICluster, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Cluster = new XAPeerMembers("com/yandex/mapkit/map/Cluster", typeof(IClusterInvoker));

	private static Delegate? cb_getAppearance_GetAppearance_Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getPlacemarks_GetPlacemarks_Ljava_util_List_;

	private static Delegate? cb_getSize_GetSize_I;

	private static Delegate? cb_addClusterTapListener_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V;

	private static Delegate? cb_removeClusterTapListener_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Cluster.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Cluster;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Cluster.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Cluster.ManagedPeerType;

	public unsafe IPlacemarkMapObject Appearance => Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractObjectMethod("getAppearance.()Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IList<IPlacemarkMapObject> Placemarks => JavaList<IPlacemarkMapObject>.FromJniHandle(_members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractObjectMethod("getPlacemarks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int Size => _members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);

	public IClusterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAppearanceHandler()
	{
		if ((object)cb_getAppearance_GetAppearance_Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_getAppearance_GetAppearance_Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAppearance));
		}
		return cb_getAppearance_GetAppearance_Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	private static nint n_GetAppearance(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Appearance);
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
		return Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetPlacemarksHandler()
	{
		if ((object)cb_getPlacemarks_GetPlacemarks_Ljava_util_List_ == null)
		{
			cb_getPlacemarks_GetPlacemarks_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlacemarks));
		}
		return cb_getPlacemarks_GetPlacemarks_Ljava_util_List_;
	}

	private static nint n_GetPlacemarks(nint jnienv, nint native__this)
	{
		return JavaList<IPlacemarkMapObject>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Placemarks);
	}

	private static Delegate GetGetSizeHandler()
	{
		if ((object)cb_getSize_GetSize_I == null)
		{
			cb_getSize_GetSize_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSize));
		}
		return cb_getSize_GetSize_I;
	}

	private static int n_GetSize(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size;
	}

	private static Delegate GetAddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_Handler()
	{
		if ((object)cb_addClusterTapListener_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V == null)
		{
			cb_addClusterTapListener_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_));
		}
		return cb_addClusterTapListener_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V;
	}

	private static void n_AddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ICluster? cluster = Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IClusterTapListener p = Java.Lang.Object.GetObject<IClusterTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		cluster.AddClusterTapListener(p);
	}

	public unsafe void AddClusterTapListener(IClusterTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractVoidMethod("addClusterTapListener.(Lcom/yandex/mapkit/map/ClusterTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_Handler()
	{
		if ((object)cb_removeClusterTapListener_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V == null)
		{
			cb_removeClusterTapListener_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_));
		}
		return cb_removeClusterTapListener_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener__V;
	}

	private static void n_RemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ICluster? cluster = Java.Lang.Object.GetObject<ICluster>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IClusterTapListener p = Java.Lang.Object.GetObject<IClusterTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		cluster.RemoveClusterTapListener(p);
	}

	public unsafe void RemoveClusterTapListener(IClusterTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Cluster.InstanceMethods.InvokeAbstractVoidMethod("removeClusterTapListener.(Lcom/yandex/mapkit/map/ClusterTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
