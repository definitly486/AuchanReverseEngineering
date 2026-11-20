using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/Polygon", DoNotGenerateAcw = true)]
public class Polygon : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/Polygon", typeof(Polygon));

	private static Delegate? cb_getInnerRings_GetInnerRings_Ljava_util_List_;

	private static Delegate? cb_getOuterRing_GetOuterRing_Lcom_yandex_mapkit_geometry_LinearRing_;

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

	public unsafe virtual IList<LinearRing> InnerRings
	{
		[Register("getInnerRings", "()Ljava/util/List;", "GetGetInnerRingsHandler")]
		get
		{
			return JavaList<LinearRing>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getInnerRings.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual LinearRing OuterRing
	{
		[Register("getOuterRing", "()Lcom/yandex/mapkit/geometry/LinearRing;", "GetGetOuterRingHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LinearRing>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOuterRing.()Lcom/yandex/mapkit/geometry/LinearRing;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Polygon(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Polygon()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/LinearRing;Ljava/util/List;)V", "")]
	public unsafe Polygon(LinearRing outerRing, IList<LinearRing> innerRings)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<LinearRing>.ToLocalJniHandle(innerRings);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(outerRing?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/LinearRing;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/LinearRing;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(outerRing);
			GC.KeepAlive(innerRings);
		}
	}

	private static Delegate GetGetInnerRingsHandler()
	{
		if ((object)cb_getInnerRings_GetInnerRings_Ljava_util_List_ == null)
		{
			cb_getInnerRings_GetInnerRings_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInnerRings));
		}
		return cb_getInnerRings_GetInnerRings_Ljava_util_List_;
	}

	private static nint n_GetInnerRings(nint jnienv, nint native__this)
	{
		return JavaList<LinearRing>.ToLocalJniHandle(Java.Lang.Object.GetObject<Polygon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InnerRings);
	}

	private static Delegate GetGetOuterRingHandler()
	{
		if ((object)cb_getOuterRing_GetOuterRing_Lcom_yandex_mapkit_geometry_LinearRing_ == null)
		{
			cb_getOuterRing_GetOuterRing_Lcom_yandex_mapkit_geometry_LinearRing_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOuterRing));
		}
		return cb_getOuterRing_GetOuterRing_Lcom_yandex_mapkit_geometry_LinearRing_;
	}

	private static nint n_GetOuterRing(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Polygon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OuterRing);
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
		Polygon? polygon = Java.Lang.Object.GetObject<Polygon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		polygon.Serialize(archive);
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
