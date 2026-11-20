using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/MeteringPoint", DoNotGenerateAcw = true)]
public class MeteringPoint : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/MeteringPoint", typeof(MeteringPoint));

	private static Delegate? cb_getSize;

	private static Delegate? cb_getSurfaceAspectRatio;

	private static Delegate? cb_getX;

	private static Delegate? cb_getY;

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

	public unsafe virtual float Size
	{
		[Register("getSize", "()F", "GetGetSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSize.()F", this, null);
		}
	}

	public unsafe virtual Rational? SurfaceAspectRatio
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSurfaceAspectRatio", "()Landroid/util/Rational;", "GetGetSurfaceAspectRatioHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rational>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSurfaceAspectRatio.()Landroid/util/Rational;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected MeteringPoint(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetSizeHandler()
	{
		if ((object)cb_getSize == null)
		{
			cb_getSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetSize));
		}
		return cb_getSize;
	}

	private static float n_GetSize(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MeteringPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size;
	}

	private static Delegate GetGetSurfaceAspectRatioHandler()
	{
		if ((object)cb_getSurfaceAspectRatio == null)
		{
			cb_getSurfaceAspectRatio = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurfaceAspectRatio));
		}
		return cb_getSurfaceAspectRatio;
	}

	private static nint n_GetSurfaceAspectRatio(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MeteringPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceAspectRatio);
	}

	private static Delegate GetGetXHandler()
	{
		if ((object)cb_getX == null)
		{
			cb_getX = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetX));
		}
		return cb_getX;
	}

	private static float n_GetX(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MeteringPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getX", "()F", "GetGetXHandler")]
	public unsafe virtual float GetX()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getX.()F", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		if ((object)cb_getY == null)
		{
			cb_getY = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetY));
		}
		return cb_getY;
	}

	private static float n_GetY(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MeteringPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getY", "()F", "GetGetYHandler")]
	public unsafe virtual float GetY()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getY.()F", this, null);
	}
}
