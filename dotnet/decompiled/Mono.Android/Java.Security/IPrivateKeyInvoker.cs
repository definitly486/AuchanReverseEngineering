using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Security;

[Register("java/security/PrivateKey", DoNotGenerateAcw = true)]
internal class IPrivateKeyInvoker : Java.Lang.Object, IPrivateKey, IKey, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_io_Serializable = new XAPeerMembers("java/io/Serializable", typeof(IPrivateKeyInvoker));

	private static readonly JniPeerMembers _members_java_security_Key = new XAPeerMembers("java/security/Key", typeof(IPrivateKeyInvoker));

	private static readonly JniPeerMembers _members_java_security_PrivateKey = new XAPeerMembers("java/security/PrivateKey", typeof(IPrivateKeyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_security_PrivateKey;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_security_PrivateKey.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_security_PrivateKey.ManagedPeerType;

	public unsafe string? Algorithm => JNIEnv.GetString(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getAlgorithm.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Format => JNIEnv.GetString(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getFormat.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IPrivateKeyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe byte[]? GetEncoded()
	{
		return (byte[])JNIEnv.GetArray(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getEncoded.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
