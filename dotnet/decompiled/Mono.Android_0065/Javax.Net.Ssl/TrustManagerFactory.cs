using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/TrustManagerFactory", DoNotGenerateAcw = true)]
public class TrustManagerFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/TrustManagerFactory", typeof(TrustManagerFactory));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static string? DefaultAlgorithm => JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDefaultAlgorithm.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);

	protected TrustManagerFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static TrustManagerFactory? GetInstance(string? algorithm)
	{
		nint num = JNIEnv.NewString(algorithm);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<TrustManagerFactory>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Ljavax/net/ssl/TrustManagerFactory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	public unsafe ITrustManager[]? GetTrustManagers()
	{
		return (ITrustManager[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTrustManagers.()[Ljavax/net/ssl/TrustManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ITrustManager));
	}

	public unsafe void Init(KeyStore? ks)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ks?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("init.(Ljava/security/KeyStore;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ks);
		}
	}
}
