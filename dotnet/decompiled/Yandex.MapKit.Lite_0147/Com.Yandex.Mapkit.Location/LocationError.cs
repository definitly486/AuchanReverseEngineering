using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationError", DoNotGenerateAcw = true)]
public class LocationError : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/LocationError", typeof(LocationError));

	private static Delegate? cb_getLateralErrorRange_GetLateralErrorRange_Lcom_yandex_mapkit_location_Range_;

	private static Delegate? cb_getLongitudinalErrorRange_GetLongitudinalErrorRange_Lcom_yandex_mapkit_location_Range_;

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

	public unsafe virtual Range LateralErrorRange
	{
		[Register("getLateralErrorRange", "()Lcom/yandex/mapkit/location/Range;", "GetGetLateralErrorRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLateralErrorRange.()Lcom/yandex/mapkit/location/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Range LongitudinalErrorRange
	{
		[Register("getLongitudinalErrorRange", "()Lcom/yandex/mapkit/location/Range;", "GetGetLongitudinalErrorRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLongitudinalErrorRange.()Lcom/yandex/mapkit/location/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	protected LocationError(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LocationError()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/Range;)V", "")]
	public unsafe LocationError(Range lateralErrorRange, Range longitudinalErrorRange)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(lateralErrorRange?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(longitudinalErrorRange?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/Range;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/Range;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(lateralErrorRange);
			GC.KeepAlive(longitudinalErrorRange);
		}
	}

	private static Delegate GetGetLateralErrorRangeHandler()
	{
		if ((object)cb_getLateralErrorRange_GetLateralErrorRange_Lcom_yandex_mapkit_location_Range_ == null)
		{
			cb_getLateralErrorRange_GetLateralErrorRange_Lcom_yandex_mapkit_location_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLateralErrorRange));
		}
		return cb_getLateralErrorRange_GetLateralErrorRange_Lcom_yandex_mapkit_location_Range_;
	}

	private static nint n_GetLateralErrorRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LocationError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LateralErrorRange);
	}

	private static Delegate GetGetLongitudinalErrorRangeHandler()
	{
		if ((object)cb_getLongitudinalErrorRange_GetLongitudinalErrorRange_Lcom_yandex_mapkit_location_Range_ == null)
		{
			cb_getLongitudinalErrorRange_GetLongitudinalErrorRange_Lcom_yandex_mapkit_location_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLongitudinalErrorRange));
		}
		return cb_getLongitudinalErrorRange_GetLongitudinalErrorRange_Lcom_yandex_mapkit_location_Range_;
	}

	private static nint n_GetLongitudinalErrorRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LocationError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LongitudinalErrorRange);
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
		LocationError? locationError = Java.Lang.Object.GetObject<LocationError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		locationError.Serialize(archive);
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
