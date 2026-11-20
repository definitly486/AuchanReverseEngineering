using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLContext", DoNotGenerateAcw = true)]
public class SSLContext : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/SSLContext", typeof(SSLContext));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe SSLSocketFactory? SocketFactory => Java.Lang.Object.GetObject<SSLSocketFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSocketFactory.()Ljavax/net/ssl/SSLSocketFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	protected SSLContext(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static SSLContext? GetInstance(string? protocol)
	{
		nint num = JNIEnv.NewString(protocol);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<SSLContext>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Ljavax/net/ssl/SSLContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	public unsafe void Init(IKeyManager[]? km, ITrustManager[]? tm, SecureRandom? random)
	{
		nint num = JNIEnv.NewArray(km);
		nint num2 = JNIEnv.NewArray(tm);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(random?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("init.([Ljavax/net/ssl/KeyManager;[Ljavax/net/ssl/TrustManager;Ljava/security/SecureRandom;)V", this, ptr);
		}
		finally
		{
			if (km != null)
			{
				JNIEnv.CopyArray(num, km);
				JNIEnv.DeleteLocalRef(num);
			}
			if (tm != null)
			{
				JNIEnv.CopyArray(num2, tm);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(km);
			GC.KeepAlive(tm);
			GC.KeepAlive(random);
		}
	}
}
