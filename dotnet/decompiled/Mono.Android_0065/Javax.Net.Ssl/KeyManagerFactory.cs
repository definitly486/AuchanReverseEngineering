using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/KeyManagerFactory", DoNotGenerateAcw = true)]
public class KeyManagerFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/KeyManagerFactory", typeof(KeyManagerFactory));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected KeyManagerFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static KeyManagerFactory? GetInstance(string? algorithm)
	{
		nint num = JNIEnv.NewString(algorithm);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KeyManagerFactory>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Ljavax/net/ssl/KeyManagerFactory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	public unsafe IKeyManager[]? GetKeyManagers()
	{
		return (IKeyManager[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getKeyManagers.()[Ljavax/net/ssl/KeyManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(IKeyManager));
	}

	public unsafe void Init(KeyStore? ks, char[]? password)
	{
		nint num = JNIEnv.NewArray(password);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(ks?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("init.(Ljava/security/KeyStore;[C)V", this, ptr);
		}
		finally
		{
			if (password != null)
			{
				JNIEnv.CopyArray(num, password);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(ks);
			GC.KeepAlive(password);
		}
	}
}
