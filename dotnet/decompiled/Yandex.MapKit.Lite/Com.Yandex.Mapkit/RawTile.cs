using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/RawTile", DoNotGenerateAcw = true)]
public class RawTile : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/RawTile$State", DoNotGenerateAcw = true)]
	public sealed class State : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/RawTile$State", typeof(State));

		[Register("ERROR")]
		public static State? Error => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("ERROR.Lcom/yandex/mapkit/RawTile$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NOT_MODIFIED")]
		public static State? NotModified => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("NOT_MODIFIED.Lcom/yandex/mapkit/RawTile$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OK")]
		public static State? Ok => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("OK.Lcom/yandex/mapkit/RawTile$State;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal State(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/RawTile$State;", "")]
		public unsafe static State? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<State>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/RawTile$State;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/RawTile$State;", "")]
		public unsafe static State[]? Values()
		{
			return (State[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/RawTile$State;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(State));
		}
	}

	[Register("com/yandex/mapkit/RawTile$UseCache", DoNotGenerateAcw = true)]
	public sealed class UseCache : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/RawTile$UseCache", typeof(UseCache));

		[Register("NO")]
		public static UseCache? No => Java.Lang.Object.GetObject<UseCache>(_members.StaticFields.GetObjectValue("NO.Lcom/yandex/mapkit/RawTile$UseCache;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("YES")]
		public static UseCache? Yes => Java.Lang.Object.GetObject<UseCache>(_members.StaticFields.GetObjectValue("YES.Lcom/yandex/mapkit/RawTile$UseCache;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal UseCache(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/RawTile$UseCache;", "")]
		public unsafe static UseCache? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<UseCache>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/RawTile$UseCache;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/RawTile$UseCache;", "")]
		public unsafe static UseCache[]? Values()
		{
			return (UseCache[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/RawTile$UseCache;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(UseCache));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/RawTile", typeof(RawTile));

	private static Delegate? cb_getEtag_GetEtag_Ljava_lang_String_;

	private static Delegate? cb_getFeatures_GetFeatures_Ljava_util_Map_;

	private static Delegate? cb_getVersion_GetVersion_Lcom_yandex_mapkit_Version_;

	private static Delegate? cb_getRawData_GetRawData_arrayB;

	private static Delegate? cb_getState_GetState_Lcom_yandex_mapkit_RawTile_State_;

	private static Delegate? cb_getUseCache_GetUseCache_Lcom_yandex_mapkit_RawTile_UseCache_;

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

	public unsafe virtual string Etag
	{
		[Register("getEtag", "()Ljava/lang/String;", "GetGetEtagHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEtag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IDictionary<string, string> Features
	{
		[Register("getFeatures", "()Ljava/util/Map;", "GetGetFeaturesHandler")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFeatures.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual Version Version
	{
		[Register("getVersion", "()Lcom/yandex/mapkit/Version;", "GetGetVersionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Version>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVersion.()Lcom/yandex/mapkit/Version;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected RawTile(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe RawTile()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/Version;Ljava/util/Map;Ljava/lang/String;Lcom/yandex/mapkit/RawTile$UseCache;Lcom/yandex/mapkit/RawTile$State;[B)V", "")]
	public unsafe RawTile(Version version, IDictionary<string, string> features, string etag, UseCache useCache, State state, byte[] rawData)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(features);
		nint num2 = JNIEnv.NewString(etag);
		nint num3 = JNIEnv.NewArray(rawData);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(version?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(useCache?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(num3);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/Version;Ljava/util/Map;Ljava/lang/String;Lcom/yandex/mapkit/RawTile$UseCache;Lcom/yandex/mapkit/RawTile$State;[B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/Version;Ljava/util/Map;Ljava/lang/String;Lcom/yandex/mapkit/RawTile$UseCache;Lcom/yandex/mapkit/RawTile$State;[B)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			if (rawData != null)
			{
				JNIEnv.CopyArray(num3, rawData);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(version);
			GC.KeepAlive(features);
			GC.KeepAlive(useCache);
			GC.KeepAlive(state);
			GC.KeepAlive(rawData);
		}
	}

	private static Delegate GetGetEtagHandler()
	{
		if ((object)cb_getEtag_GetEtag_Ljava_lang_String_ == null)
		{
			cb_getEtag_GetEtag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEtag));
		}
		return cb_getEtag_GetEtag_Ljava_lang_String_;
	}

	private static nint n_GetEtag(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Etag);
	}

	private static Delegate GetGetFeaturesHandler()
	{
		if ((object)cb_getFeatures_GetFeatures_Ljava_util_Map_ == null)
		{
			cb_getFeatures_GetFeatures_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFeatures));
		}
		return cb_getFeatures_GetFeatures_Ljava_util_Map_;
	}

	private static nint n_GetFeatures(nint jnienv, nint native__this)
	{
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Features);
	}

	private static Delegate GetGetVersionHandler()
	{
		if ((object)cb_getVersion_GetVersion_Lcom_yandex_mapkit_Version_ == null)
		{
			cb_getVersion_GetVersion_Lcom_yandex_mapkit_Version_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVersion));
		}
		return cb_getVersion_GetVersion_Lcom_yandex_mapkit_Version_;
	}

	private static nint n_GetVersion(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Version);
	}

	private static Delegate GetGetRawDataHandler()
	{
		if ((object)cb_getRawData_GetRawData_arrayB == null)
		{
			cb_getRawData_GetRawData_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRawData));
		}
		return cb_getRawData_GetRawData_arrayB;
	}

	private static nint n_GetRawData(nint jnienv, nint native__this)
	{
		return JNIEnv.NewArray(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRawData());
	}

	[Register("getRawData", "()[B", "GetGetRawDataHandler")]
	public unsafe virtual byte[] GetRawData()
	{
		return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getRawData.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	private static Delegate GetGetStateHandler()
	{
		if ((object)cb_getState_GetState_Lcom_yandex_mapkit_RawTile_State_ == null)
		{
			cb_getState_GetState_Lcom_yandex_mapkit_RawTile_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetState));
		}
		return cb_getState_GetState_Lcom_yandex_mapkit_RawTile_State_;
	}

	private static nint n_GetState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetState());
	}

	[Register("getState", "()Lcom/yandex/mapkit/RawTile$State;", "GetGetStateHandler")]
	public unsafe virtual State GetState()
	{
		return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeVirtualObjectMethod("getState.()Lcom/yandex/mapkit/RawTile$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetUseCacheHandler()
	{
		if ((object)cb_getUseCache_GetUseCache_Lcom_yandex_mapkit_RawTile_UseCache_ == null)
		{
			cb_getUseCache_GetUseCache_Lcom_yandex_mapkit_RawTile_UseCache_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUseCache));
		}
		return cb_getUseCache_GetUseCache_Lcom_yandex_mapkit_RawTile_UseCache_;
	}

	private static nint n_GetUseCache(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetUseCache());
	}

	[Register("getUseCache", "()Lcom/yandex/mapkit/RawTile$UseCache;", "GetGetUseCacheHandler")]
	public unsafe virtual UseCache GetUseCache()
	{
		return Java.Lang.Object.GetObject<UseCache>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUseCache.()Lcom/yandex/mapkit/RawTile$UseCache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		RawTile? rawTile = Java.Lang.Object.GetObject<RawTile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		rawTile.Serialize(archive);
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
