using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Identifier", DoNotGenerateAcw = true)]
public abstract class Identifier : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Identifier", typeof(Identifier));

	private static Delegate? cb_getValue;

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

	public abstract Java.Lang.Object Value
	{
		[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler")]
		get;
	}

	protected Identifier(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Identifier()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetValueHandler()
	{
		if ((object)cb_getValue == null)
		{
			cb_getValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetValue));
		}
		return cb_getValue;
	}

	private static nint n_GetValue(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Identifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
	}

	[Register("create", "(Ljava/lang/Object;)Landroidx/camera/core/impl/Identifier;", "")]
	public unsafe static Identifier Create(Java.Lang.Object value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Identifier>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/Object;)Landroidx/camera/core/impl/Identifier;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}
}
