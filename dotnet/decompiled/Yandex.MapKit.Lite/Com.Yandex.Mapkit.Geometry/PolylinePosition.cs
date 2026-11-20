using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/PolylinePosition", DoNotGenerateAcw = true)]
public class PolylinePosition : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/PolylinePosition", typeof(PolylinePosition));

	private static Delegate? cb_getSegmentIndex_GetSegmentIndex_I;

	private static Delegate? cb_getSegmentPosition_GetSegmentPosition_D;

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

	public unsafe virtual int SegmentIndex
	{
		[Register("getSegmentIndex", "()I", "GetGetSegmentIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSegmentIndex.()I", this, null);
		}
	}

	public unsafe virtual double SegmentPosition
	{
		[Register("getSegmentPosition", "()D", "GetGetSegmentPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualDoubleMethod("getSegmentPosition.()D", this, null);
		}
	}

	protected PolylinePosition(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe PolylinePosition()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(ID)V", "")]
	public unsafe PolylinePosition(int segmentIndex, double segmentPosition)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(segmentIndex);
			ptr[1] = new JniArgumentValue(segmentPosition);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ID)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ID)V", this, ptr);
		}
	}

	private static Delegate GetGetSegmentIndexHandler()
	{
		if ((object)cb_getSegmentIndex_GetSegmentIndex_I == null)
		{
			cb_getSegmentIndex_GetSegmentIndex_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSegmentIndex));
		}
		return cb_getSegmentIndex_GetSegmentIndex_I;
	}

	private static int n_GetSegmentIndex(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<PolylinePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SegmentIndex;
	}

	private static Delegate GetGetSegmentPositionHandler()
	{
		if ((object)cb_getSegmentPosition_GetSegmentPosition_D == null)
		{
			cb_getSegmentPosition_GetSegmentPosition_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetSegmentPosition));
		}
		return cb_getSegmentPosition_GetSegmentPosition_D;
	}

	private static double n_GetSegmentPosition(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<PolylinePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SegmentPosition;
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
		PolylinePosition? polylinePosition = Java.Lang.Object.GetObject<PolylinePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		polylinePosition.Serialize(archive);
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
