using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/Point", DoNotGenerateAcw = true)]
public class Point : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/Point", typeof(Point));

	private static Delegate? cb_getLatitude_GetLatitude_D;

	private static Delegate? cb_getLongitude_GetLongitude_D;

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

	public unsafe virtual double Latitude
	{
		[Register("getLatitude", "()D", "GetGetLatitudeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualDoubleMethod("getLatitude.()D", this, null);
		}
	}

	public unsafe virtual double Longitude
	{
		[Register("getLongitude", "()D", "GetGetLongitudeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualDoubleMethod("getLongitude.()D", this, null);
		}
	}

	protected Point(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Point()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(DD)V", "")]
	public unsafe Point(double latitude, double longitude)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(latitude);
			ptr[1] = new JniArgumentValue(longitude);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(DD)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(DD)V", this, ptr);
		}
	}

	private static Delegate GetGetLatitudeHandler()
	{
		if ((object)cb_getLatitude_GetLatitude_D == null)
		{
			cb_getLatitude_GetLatitude_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetLatitude));
		}
		return cb_getLatitude_GetLatitude_D;
	}

	private static double n_GetLatitude(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Point>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Latitude;
	}

	private static Delegate GetGetLongitudeHandler()
	{
		if ((object)cb_getLongitude_GetLongitude_D == null)
		{
			cb_getLongitude_GetLongitude_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetLongitude));
		}
		return cb_getLongitude_GetLongitude_D;
	}

	private static double n_GetLongitude(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Point>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Longitude;
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
		Point? point = Java.Lang.Object.GetObject<Point>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		point.Serialize(archive);
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
