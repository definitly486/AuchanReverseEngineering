using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/GeoObject", DoNotGenerateAcw = true)]
public class GeoObject : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/GeoObject", typeof(GeoObject));

	private static Delegate? cb_getAref_GetAref_Ljava_util_List_;

	private static Delegate? cb_getAttributionMap_GetAttributionMap_Ljava_util_Map_;

	private static Delegate? cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_;

	private static Delegate? cb_getDescriptionText_GetDescriptionText_Ljava_lang_String_;

	private static Delegate? cb_getGeometry_GetGeometry_Ljava_util_List_;

	private static Delegate? cb_getMetadataContainer_GetMetadataContainer_Lcom_yandex_runtime_TypeDictionary_;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

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

	public unsafe virtual IList<string> Aref
	{
		[Register("getAref", "()Ljava/util/List;", "GetGetArefHandler")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAref.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IDictionary<string, Attribution> AttributionMap
	{
		[Register("getAttributionMap", "()Ljava/util/Map;", "GetGetAttributionMapHandler")]
		get
		{
			return JavaDictionary<string, Attribution>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttributionMap.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual BoundingBox? BoundingBox
	{
		[Register("getBoundingBox", "()Lcom/yandex/mapkit/geometry/BoundingBox;", "GetGetBoundingBoxHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BoundingBox>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBoundingBox.()Lcom/yandex/mapkit/geometry/BoundingBox;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? DescriptionText
	{
		[Register("getDescriptionText", "()Ljava/lang/String;", "GetGetDescriptionTextHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDescriptionText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<Com.Yandex.Mapkit.Geometry.Geometry> Geometry
	{
		[Register("getGeometry", "()Ljava/util/List;", "GetGetGeometryHandler")]
		get
		{
			return JavaList<Com.Yandex.Mapkit.Geometry.Geometry>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getGeometry.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ITypeDictionary MetadataContainer
	{
		[Register("getMetadataContainer", "()Lcom/yandex/runtime/TypeDictionary;", "GetGetMetadataContainerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ITypeDictionary>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMetadataContainer.()Lcom/yandex/runtime/TypeDictionary;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	protected GeoObject(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe GeoObject()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/util/List;Lcom/yandex/mapkit/geometry/BoundingBox;Ljava/util/Map;Lcom/yandex/runtime/TypeDictionary;Ljava/util/List;)V", "")]
	public unsafe GeoObject(string? name, string? descriptionText, IList<Com.Yandex.Mapkit.Geometry.Geometry> geometry, BoundingBox? boundingBox, IDictionary<string, Attribution> attributionMap, ITypeDictionary metadataContainer, IList<string> aref)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(descriptionText);
		nint num3 = JavaList<Com.Yandex.Mapkit.Geometry.Geometry>.ToLocalJniHandle(geometry);
		nint num4 = JavaDictionary<string, Attribution>.ToLocalJniHandle(attributionMap);
		nint num5 = JavaList<string>.ToLocalJniHandle(aref);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(boundingBox?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(num4);
			ptr[5] = new JniArgumentValue((metadataContainer == null) ? IntPtr.Zero : ((Java.Lang.Object)metadataContainer).Handle);
			ptr[6] = new JniArgumentValue(num5);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/util/List;Lcom/yandex/mapkit/geometry/BoundingBox;Ljava/util/Map;Lcom/yandex/runtime/TypeDictionary;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/util/List;Lcom/yandex/mapkit/geometry/BoundingBox;Ljava/util/Map;Lcom/yandex/runtime/TypeDictionary;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			GC.KeepAlive(geometry);
			GC.KeepAlive(boundingBox);
			GC.KeepAlive(attributionMap);
			GC.KeepAlive(metadataContainer);
			GC.KeepAlive(aref);
		}
	}

	private static Delegate GetGetArefHandler()
	{
		if ((object)cb_getAref_GetAref_Ljava_util_List_ == null)
		{
			cb_getAref_GetAref_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAref));
		}
		return cb_getAref_GetAref_Ljava_util_List_;
	}

	private static nint n_GetAref(nint jnienv, nint native__this)
	{
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Aref);
	}

	private static Delegate GetGetAttributionMapHandler()
	{
		if ((object)cb_getAttributionMap_GetAttributionMap_Ljava_util_Map_ == null)
		{
			cb_getAttributionMap_GetAttributionMap_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAttributionMap));
		}
		return cb_getAttributionMap_GetAttributionMap_Ljava_util_Map_;
	}

	private static nint n_GetAttributionMap(nint jnienv, nint native__this)
	{
		return JavaDictionary<string, Attribution>.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AttributionMap);
	}

	private static Delegate GetGetBoundingBoxHandler()
	{
		if ((object)cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_ == null)
		{
			cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBoundingBox));
		}
		return cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_;
	}

	private static nint n_GetBoundingBox(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoundingBox);
	}

	private static Delegate GetGetDescriptionTextHandler()
	{
		if ((object)cb_getDescriptionText_GetDescriptionText_Ljava_lang_String_ == null)
		{
			cb_getDescriptionText_GetDescriptionText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDescriptionText));
		}
		return cb_getDescriptionText_GetDescriptionText_Ljava_lang_String_;
	}

	private static nint n_GetDescriptionText(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescriptionText);
	}

	private static Delegate GetGetGeometryHandler()
	{
		if ((object)cb_getGeometry_GetGeometry_Ljava_util_List_ == null)
		{
			cb_getGeometry_GetGeometry_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeometry));
		}
		return cb_getGeometry_GetGeometry_Ljava_util_List_;
	}

	private static nint n_GetGeometry(nint jnienv, nint native__this)
	{
		return JavaList<Com.Yandex.Mapkit.Geometry.Geometry>.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Geometry);
	}

	private static Delegate GetGetMetadataContainerHandler()
	{
		if ((object)cb_getMetadataContainer_GetMetadataContainer_Lcom_yandex_runtime_TypeDictionary_ == null)
		{
			cb_getMetadataContainer_GetMetadataContainer_Lcom_yandex_runtime_TypeDictionary_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMetadataContainer));
		}
		return cb_getMetadataContainer_GetMetadataContainer_Lcom_yandex_runtime_TypeDictionary_;
	}

	private static nint n_GetMetadataContainer(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MetadataContainer);
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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
		GeoObject? geoObject = Java.Lang.Object.GetObject<GeoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		geoObject.Serialize(archive);
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
