using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/HostnameVerifier", DoNotGenerateAcw = true)]
internal class IHostnameVerifierInvoker : Java.Lang.Object, IHostnameVerifier, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_net_ssl_HostnameVerifier = new XAPeerMembers("javax/net/ssl/HostnameVerifier", typeof(IHostnameVerifierInvoker));

	private static Delegate? cb_verify_Verify_Ljava_lang_String_Ljavax_net_ssl_SSLSession__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_net_ssl_HostnameVerifier;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_net_ssl_HostnameVerifier.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_net_ssl_HostnameVerifier.ManagedPeerType;

	public IHostnameVerifierInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Verify_Ljava_lang_String_Ljavax_net_ssl_SSLSession_(nint jnienv, nint native__this, nint native_hostname, nint native_session)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IHostnameVerifier? hostnameVerifier = Java.Lang.Object.GetObject<IHostnameVerifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string hostname = JNIEnv.GetString(native_hostname, JniHandleOwnership.DoNotTransfer);
			ISSLSession session = Java.Lang.Object.GetObject<ISSLSession>(native_session, JniHandleOwnership.DoNotTransfer);
			return hostnameVerifier.Verify(hostname, session) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool Verify(string? hostname, ISSLSession? session)
	{
		nint num = JNIEnv.NewString(hostname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((session == null) ? IntPtr.Zero : ((Java.Lang.Object)session).Handle);
			return _members_javax_net_ssl_HostnameVerifier.InstanceMethods.InvokeAbstractBooleanMethod("verify.(Ljava/lang/String;Ljavax/net/ssl/SSLSession;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(session);
		}
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

	[UnmanagedCallersOnly]
	private static sbyte n_Verify_Ljava_lang_String_Ljavax_net_ssl_SSLSession__mm_wrapper(nint jnienv, nint native__this, nint native_hostname, nint native_session)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Verify_Ljava_lang_String_Ljavax_net_ssl_SSLSession_(jnienv, native__this, native_hostname, native_session);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
