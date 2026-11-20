using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security.Spec;

[Register("java/security/spec/PKCS8EncodedKeySpec", DoNotGenerateAcw = true)]
public class PKCS8EncodedKeySpec : EncodedKeySpec
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/spec/PKCS8EncodedKeySpec", typeof(PKCS8EncodedKeySpec));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PKCS8EncodedKeySpec(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([B)V", "")]
	public unsafe PKCS8EncodedKeySpec(byte[]? encodedKey)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(encodedKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([B)V", this, ptr);
		}
		finally
		{
			if (encodedKey != null)
			{
				JNIEnv.CopyArray(num, encodedKey);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(encodedKey);
		}
	}
}
