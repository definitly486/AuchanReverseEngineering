using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry.Geo;

[Register("com/yandex/mapkit/geometry/geo/XYPoint", DoNotGenerateAcw = true)]
public class XYPoint : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/geo/XYPoint", typeof(XYPoint));

	private static Delegate? cb_getX_GetX_D;

	private static Delegate? cb_getY_GetY_D;

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

	protected XYPoint(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe XYPoint()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(DD)V", "")]
	public unsafe XYPoint(double x, double y)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(DD)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(DD)V", this, ptr);
		}
	}

	private static Delegate GetGetXHandler()
	{
		if ((object)cb_getX_GetX_D == null)
		{
			cb_getX_GetX_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetX));
		}
		return cb_getX_GetX_D;
	}

	private static double n_GetX(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<XYPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
	}

	[Register("getX", "()D", "GetGetXHandler")]
	public unsafe virtual double GetX()
	{
		return _members.InstanceMethods.InvokeVirtualDoubleMethod("getX.()D", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		if ((object)cb_getY_GetY_D == null)
		{
			cb_getY_GetY_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetY));
		}
		return cb_getY_GetY_D;
	}

	private static double n_GetY(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<XYPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
	}

	[Register("getY", "()D", "GetGetYHandler")]
	public unsafe virtual double GetY()
	{
		return _members.InstanceMethods.InvokeVirtualDoubleMethod("getY.()D", this, null);
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
		XYPoint? xYPoint = Java.Lang.Object.GetObject<XYPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		xYPoint.Serialize(archive);
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
