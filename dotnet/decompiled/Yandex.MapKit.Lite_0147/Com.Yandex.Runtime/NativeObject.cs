using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/NativeObject", DoNotGenerateAcw = true)]
public sealed class NativeObject : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/NativeObject", typeof(NativeObject));

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

	public unsafe bool IsEmpty
	{
		[Register("isEmpty", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	internal NativeObject(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(JZ)V", "")]
	public unsafe NativeObject(long nativeObject, bool canBeDeletedInBackground)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(nativeObject);
			ptr[1] = new JniArgumentValue(canBeDeletedInBackground);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JZ)V", this, ptr);
		}
	}

	[Register("finalize", "()V", "")]
	public unsafe void Finalize()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("finalize.()V", this, null);
	}

	[Register("release", "()J", "")]
	public unsafe long Release()
	{
		return _members.InstanceMethods.InvokeAbstractInt64Method("release.()J", this, null);
	}

	[Register("reset", "()V", "")]
	public unsafe void Reset()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
	}
}
