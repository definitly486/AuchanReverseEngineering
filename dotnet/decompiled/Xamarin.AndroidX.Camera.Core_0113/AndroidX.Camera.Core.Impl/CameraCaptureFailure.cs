using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraCaptureFailure", DoNotGenerateAcw = true)]
public class CameraCaptureFailure : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/CameraCaptureFailure$Reason", DoNotGenerateAcw = true)]
	public sealed class Reason : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureFailure$Reason", typeof(Reason));

		[Register("ERROR")]
		public static Reason? Error => Java.Lang.Object.GetObject<Reason>(_members.StaticFields.GetObjectValue("ERROR.Landroidx/camera/core/impl/CameraCaptureFailure$Reason;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal Reason(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", "")]
		public unsafe static Reason? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Reason>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", "")]
		public unsafe static Reason[]? Values()
		{
			return (Reason[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Reason));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureFailure", typeof(CameraCaptureFailure));

	private static Delegate? cb_getCaptureFailure;

	private static Delegate? cb_getReason;

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

	public unsafe virtual Java.Lang.Object? CaptureFailure
	{
		[Register("getCaptureFailure", "()Ljava/lang/Object;", "GetGetCaptureFailureHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCaptureFailure.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected CameraCaptureFailure(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/core/impl/CameraCaptureFailure$Reason;)V", "")]
	public unsafe CameraCaptureFailure(Reason reason)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(reason?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/camera/core/impl/CameraCaptureFailure$Reason;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/camera/core/impl/CameraCaptureFailure$Reason;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(reason);
		}
	}

	private static Delegate GetGetCaptureFailureHandler()
	{
		if ((object)cb_getCaptureFailure == null)
		{
			cb_getCaptureFailure = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureFailure));
		}
		return cb_getCaptureFailure;
	}

	private static nint n_GetCaptureFailure(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraCaptureFailure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureFailure);
	}

	private static Delegate GetGetReasonHandler()
	{
		if ((object)cb_getReason == null)
		{
			cb_getReason = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReason));
		}
		return cb_getReason;
	}

	private static nint n_GetReason(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraCaptureFailure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReason());
	}

	[Register("getReason", "()Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", "GetGetReasonHandler")]
	public unsafe virtual Reason GetReason()
	{
		return Java.Lang.Object.GetObject<Reason>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReason.()Landroidx/camera/core/impl/CameraCaptureFailure$Reason;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
