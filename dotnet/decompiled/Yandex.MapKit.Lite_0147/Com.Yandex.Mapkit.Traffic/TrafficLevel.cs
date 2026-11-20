using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficLevel", DoNotGenerateAcw = true)]
public class TrafficLevel : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/traffic/TrafficLevel", typeof(TrafficLevel));

	private static Delegate? cb_getColor_GetColor_Lcom_yandex_mapkit_traffic_TrafficColor_;

	private static Delegate? cb_getLevel_GetLevel_I;

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

	public unsafe virtual TrafficColor Color
	{
		[Register("getColor", "()Lcom/yandex/mapkit/traffic/TrafficColor;", "GetGetColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<TrafficColor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getColor.()Lcom/yandex/mapkit/traffic/TrafficColor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Level
	{
		[Register("getLevel", "()I", "GetGetLevelHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLevel.()I", this, null);
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

	protected TrafficLevel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TrafficLevel()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/traffic/TrafficColor;I)V", "")]
	public unsafe TrafficLevel(TrafficColor color, int level)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(level);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/traffic/TrafficColor;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/traffic/TrafficColor;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(color);
		}
	}

	private static Delegate GetGetColorHandler()
	{
		if ((object)cb_getColor_GetColor_Lcom_yandex_mapkit_traffic_TrafficColor_ == null)
		{
			cb_getColor_GetColor_Lcom_yandex_mapkit_traffic_TrafficColor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetColor));
		}
		return cb_getColor_GetColor_Lcom_yandex_mapkit_traffic_TrafficColor_;
	}

	private static nint n_GetColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TrafficLevel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Color);
	}

	private static Delegate GetGetLevelHandler()
	{
		if ((object)cb_getLevel_GetLevel_I == null)
		{
			cb_getLevel_GetLevel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLevel));
		}
		return cb_getLevel_GetLevel_I;
	}

	private static int n_GetLevel(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TrafficLevel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Level;
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
		TrafficLevel? trafficLevel = Java.Lang.Object.GetObject<TrafficLevel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		trafficLevel.Serialize(archive);
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
