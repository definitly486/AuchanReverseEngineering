using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/Region", DoNotGenerateAcw = true)]
public class Region : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/offline_cache/Region", typeof(Region));

	private static Delegate? cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getCountry_GetCountry_Ljava_lang_String_;

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getParentId_GetParentId_Ljava_lang_Integer_;

	private static Delegate? cb_getReleaseTime_GetReleaseTime_J;

	private static Delegate? cb_getSize_GetSize_Lcom_yandex_mapkit_LocalizedValue_;

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

	public unsafe virtual Point Center
	{
		[Register("getCenter", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetCenterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCenter.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string Country
	{
		[Register("getCountry", "()Ljava/lang/String;", "GetGetCountryHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCountry.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
		}
	}

	public unsafe virtual string Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? ParentId
	{
		[Register("getParentId", "()Ljava/lang/Integer;", "GetGetParentIdHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParentId.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long ReleaseTime
	{
		[Register("getReleaseTime", "()J", "GetGetReleaseTimeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getReleaseTime.()J", this, null);
		}
	}

	public unsafe virtual LocalizedValue Size
	{
		[Register("getSize", "()Lcom/yandex/mapkit/LocalizedValue;", "GetGetSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LocalizedValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSize.()Lcom/yandex/mapkit/LocalizedValue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Region(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Region()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(ILjava/lang/String;Ljava/lang/String;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/LocalizedValue;JLjava/lang/Integer;)V", "")]
	public unsafe Region(int id, string name, string country, Point center, LocalizedValue size, long releaseTime, Integer? parentId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(country);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(center?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(size?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(releaseTime);
			ptr[6] = new JniArgumentValue(parentId?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/String;Ljava/lang/String;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/LocalizedValue;JLjava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/String;Ljava/lang/String;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/LocalizedValue;JLjava/lang/Integer;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(center);
			GC.KeepAlive(size);
			GC.KeepAlive(parentId);
		}
	}

	private static Delegate GetGetCenterHandler()
	{
		if ((object)cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCenter));
		}
		return cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetCenter(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Center);
	}

	private static Delegate GetGetCountryHandler()
	{
		if ((object)cb_getCountry_GetCountry_Ljava_lang_String_ == null)
		{
			cb_getCountry_GetCountry_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCountry));
		}
		return cb_getCountry_GetCountry_Ljava_lang_String_;
	}

	private static nint n_GetCountry(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Country);
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId_GetId_I == null)
		{
			cb_getId_GetId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetId));
		}
		return cb_getId_GetId_I;
	}

	private static int n_GetId(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
	}

	private static Delegate GetGetNameHandler()
	{
		if ((object)cb_getName_GetName_Ljava_lang_String_ == null)
		{
			cb_getName_GetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
		}
		return cb_getName_GetName_Ljava_lang_String_;
	}

	private static nint n_GetName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
	}

	private static Delegate GetGetParentIdHandler()
	{
		if ((object)cb_getParentId_GetParentId_Ljava_lang_Integer_ == null)
		{
			cb_getParentId_GetParentId_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParentId));
		}
		return cb_getParentId_GetParentId_Ljava_lang_Integer_;
	}

	private static nint n_GetParentId(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentId);
	}

	private static Delegate GetGetReleaseTimeHandler()
	{
		if ((object)cb_getReleaseTime_GetReleaseTime_J == null)
		{
			cb_getReleaseTime_GetReleaseTime_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetReleaseTime));
		}
		return cb_getReleaseTime_GetReleaseTime_J;
	}

	private static long n_GetReleaseTime(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReleaseTime;
	}

	private static Delegate GetGetSizeHandler()
	{
		if ((object)cb_getSize_GetSize_Lcom_yandex_mapkit_LocalizedValue_ == null)
		{
			cb_getSize_GetSize_Lcom_yandex_mapkit_LocalizedValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSize));
		}
		return cb_getSize_GetSize_Lcom_yandex_mapkit_LocalizedValue_;
	}

	private static nint n_GetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size);
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
		Region? region = Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		region.Serialize(archive);
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
