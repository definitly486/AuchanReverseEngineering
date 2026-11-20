using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/GeoObjectSelectionMetadata", DoNotGenerateAcw = true)]
public class GeoObjectSelectionMetadata : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/GeoObjectSelectionMetadata", typeof(GeoObjectSelectionMetadata));

	private static Delegate? cb_getDataSourceName_GetDataSourceName_Ljava_lang_String_;

	private static Delegate? cb_getGroupId_GetGroupId_Ljava_lang_Long_;

	private static Delegate? cb_getLayerId_GetLayerId_Ljava_lang_String_;

	private static Delegate? cb_getObjectId_GetObjectId_Ljava_lang_String_;

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

	public unsafe virtual string DataSourceName
	{
		[Register("getDataSourceName", "()Ljava/lang/String;", "GetGetDataSourceNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDataSourceName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Long? GroupId
	{
		[Register("getGroupId", "()Ljava/lang/Long;", "GetGetGroupIdHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeVirtualObjectMethod("getGroupId.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string LayerId
	{
		[Register("getLayerId", "()Ljava/lang/String;", "GetGetLayerIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayerId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static string? NativeName
	{
		[Register("getNativeName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getNativeName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string ObjectId
	{
		[Register("getObjectId", "()Ljava/lang/String;", "GetGetObjectIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getObjectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected GeoObjectSelectionMetadata(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe GeoObjectSelectionMetadata()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Long;)V", "")]
	public unsafe GeoObjectSelectionMetadata(string objectId, string dataSourceName, string layerId, Long? groupId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(objectId);
		nint num2 = JNIEnv.NewString(dataSourceName);
		nint num3 = JNIEnv.NewString(layerId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(groupId?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Long;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Long;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(groupId);
		}
	}

	private static Delegate GetGetDataSourceNameHandler()
	{
		if ((object)cb_getDataSourceName_GetDataSourceName_Ljava_lang_String_ == null)
		{
			cb_getDataSourceName_GetDataSourceName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDataSourceName));
		}
		return cb_getDataSourceName_GetDataSourceName_Ljava_lang_String_;
	}

	private static nint n_GetDataSourceName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataSourceName);
	}

	private static Delegate GetGetGroupIdHandler()
	{
		if ((object)cb_getGroupId_GetGroupId_Ljava_lang_Long_ == null)
		{
			cb_getGroupId_GetGroupId_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGroupId));
		}
		return cb_getGroupId_GetGroupId_Ljava_lang_Long_;
	}

	private static nint n_GetGroupId(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GroupId);
	}

	private static Delegate GetGetLayerIdHandler()
	{
		if ((object)cb_getLayerId_GetLayerId_Ljava_lang_String_ == null)
		{
			cb_getLayerId_GetLayerId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLayerId));
		}
		return cb_getLayerId_GetLayerId_Ljava_lang_String_;
	}

	private static nint n_GetLayerId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayerId);
	}

	private static Delegate GetGetObjectIdHandler()
	{
		if ((object)cb_getObjectId_GetObjectId_Ljava_lang_String_ == null)
		{
			cb_getObjectId_GetObjectId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetObjectId));
		}
		return cb_getObjectId_GetObjectId_Ljava_lang_String_;
	}

	private static nint n_GetObjectId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObjectId);
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
		GeoObjectSelectionMetadata? geoObjectSelectionMetadata = Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		geoObjectSelectionMetadata.Serialize(archive);
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
