using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security.Spec;

namespace Java.Security;

[Register("java/security/KeyFactory", DoNotGenerateAcw = true)]
public class KeyFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/KeyFactory", typeof(KeyFactory));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected KeyFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe IPrivateKey? GeneratePrivate(IKeySpec? keySpec)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keySpec == null) ? IntPtr.Zero : ((Java.Lang.Object)keySpec).Handle);
			return Java.Lang.Object.GetObject<IPrivateKey>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("generatePrivate.(Ljava/security/spec/KeySpec;)Ljava/security/PrivateKey;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keySpec);
		}
	}

	public unsafe static KeyFactory? GetInstance(string? algorithm)
	{
		nint num = JNIEnv.NewString(algorithm);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KeyFactory>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Ljava/security/KeyFactory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
