using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security.Cert;

[Register("java/security/cert/Certificate", DoNotGenerateAcw = true)]
internal class CertificateInvoker : Certificate
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/cert/Certificate", typeof(CertificateInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CertificateInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getEncoded", "()[B", "GetGetEncodedHandler")]
	public unsafe override byte[]? GetEncoded()
	{
		return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEncoded.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler")]
	public unsafe override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
