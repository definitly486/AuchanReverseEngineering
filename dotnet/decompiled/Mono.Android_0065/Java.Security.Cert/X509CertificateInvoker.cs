using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security.Cert;

[Register("java/security/cert/X509Certificate", DoNotGenerateAcw = true)]
internal class X509CertificateInvoker : X509Certificate
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/cert/X509Certificate", typeof(X509CertificateInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public X509CertificateInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override byte[]? GetEncoded()
	{
		return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEncoded.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	public unsafe override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
