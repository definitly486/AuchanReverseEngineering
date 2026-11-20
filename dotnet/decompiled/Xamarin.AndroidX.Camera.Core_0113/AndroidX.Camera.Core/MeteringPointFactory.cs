using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/MeteringPointFactory", DoNotGenerateAcw = true)]
public abstract class MeteringPointFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/MeteringPointFactory", typeof(MeteringPointFactory));

	private static Delegate? cb_convertPoint_FF;

	private static Delegate? cb_setSurfaceAspectRatio_Landroid_util_Rational_;

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

	public unsafe static float DefaultPointSize
	{
		[Register("getDefaultPointSize", "()F", "")]
		get
		{
			return _members.StaticMethods.InvokeSingleMethod("getDefaultPointSize.()F", null);
		}
	}

	protected MeteringPointFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe MeteringPointFactory()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/util/Rational;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe MeteringPointFactory(Rational? surfaceAspectRatio)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(surfaceAspectRatio?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Rational;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Rational;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(surfaceAspectRatio);
		}
	}

	private static Delegate GetConvertPoint_FFHandler()
	{
		if ((object)cb_convertPoint_FF == null)
		{
			cb_convertPoint_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFF_L(n_ConvertPoint_FF));
		}
		return cb_convertPoint_FF;
	}

	private static nint n_ConvertPoint_FF(nint jnienv, nint native__this, float p0, float p1)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MeteringPointFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConvertPoint(p0, p1));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("convertPoint", "(FF)Landroid/graphics/PointF;", "GetConvertPoint_FFHandler")]
	protected abstract PointF ConvertPoint(float p0, float p1);

	[Register("createPoint", "(FF)Landroidx/camera/core/MeteringPoint;", "")]
	public unsafe MeteringPoint CreatePoint(float x, float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return Java.Lang.Object.GetObject<MeteringPoint>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createPoint.(FF)Landroidx/camera/core/MeteringPoint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("createPoint", "(FFF)Landroidx/camera/core/MeteringPoint;", "")]
	public unsafe MeteringPoint CreatePoint(float x, float y, float size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(size);
		return Java.Lang.Object.GetObject<MeteringPoint>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createPoint.(FFF)Landroidx/camera/core/MeteringPoint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSurfaceAspectRatio_Landroid_util_Rational_Handler()
	{
		if ((object)cb_setSurfaceAspectRatio_Landroid_util_Rational_ == null)
		{
			cb_setSurfaceAspectRatio_Landroid_util_Rational_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSurfaceAspectRatio_Landroid_util_Rational_));
		}
		return cb_setSurfaceAspectRatio_Landroid_util_Rational_;
	}

	private static void n_SetSurfaceAspectRatio_Landroid_util_Rational_(nint jnienv, nint native__this, nint native_surfaceAspectRatio)
	{
		MeteringPointFactory? meteringPointFactory = Java.Lang.Object.GetObject<MeteringPointFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Rational surfaceAspectRatio = Java.Lang.Object.GetObject<Rational>(native_surfaceAspectRatio, JniHandleOwnership.DoNotTransfer);
		meteringPointFactory.SetSurfaceAspectRatio(surfaceAspectRatio);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setSurfaceAspectRatio", "(Landroid/util/Rational;)V", "GetSetSurfaceAspectRatio_Landroid_util_Rational_Handler")]
	protected unsafe virtual void SetSurfaceAspectRatio(Rational surfaceAspectRatio)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(surfaceAspectRatio?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSurfaceAspectRatio.(Landroid/util/Rational;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(surfaceAspectRatio);
		}
	}
}
