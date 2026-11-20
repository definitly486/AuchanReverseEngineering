using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Net;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/HttpsURLConnection", DoNotGenerateAcw = true)]
public abstract class HttpsURLConnection : HttpURLConnection
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/HttpsURLConnection", typeof(HttpsURLConnection));

	private static Delegate? cb_setHostnameVerifier_SetHostnameVerifier_Ljavax_net_ssl_HostnameVerifier__V;

	private static Delegate? cb_setSSLSocketFactory_SetSSLSocketFactory_Ljavax_net_ssl_SSLSocketFactory__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static IHostnameVerifier? DefaultHostnameVerifier => Java.Lang.Object.GetObject<IHostnameVerifier>(_members.StaticMethods.InvokeObjectMethod("getDefaultHostnameVerifier.()Ljavax/net/ssl/HostnameVerifier;", null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual IHostnameVerifier? HostnameVerifier
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHostnameVerifier.(Ljavax/net/ssl/HostnameVerifier;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual SSLSocketFactory? SSLSocketFactory
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSSLSocketFactory.(Ljavax/net/ssl/SSLSocketFactory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected HttpsURLConnection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetHostnameVerifier_Ljavax_net_ssl_HostnameVerifier_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetHostnameVerifier_Ljavax_net_ssl_HostnameVerifier_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHostnameVerifier_Ljavax_net_ssl_HostnameVerifier_(nint jnienv, nint native__this, nint native_v)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HttpsURLConnection? httpsURLConnection = Java.Lang.Object.GetObject<HttpsURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IHostnameVerifier hostnameVerifier = Java.Lang.Object.GetObject<IHostnameVerifier>(native_v, JniHandleOwnership.DoNotTransfer);
			httpsURLConnection.HostnameVerifier = hostnameVerifier;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetSSLSocketFactory_Ljavax_net_ssl_SSLSocketFactory_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetSSLSocketFactory_Ljavax_net_ssl_SSLSocketFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSSLSocketFactory_Ljavax_net_ssl_SSLSocketFactory_(nint jnienv, nint native__this, nint native_sf)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HttpsURLConnection? httpsURLConnection = Java.Lang.Object.GetObject<HttpsURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SSLSocketFactory sSLSocketFactory = Java.Lang.Object.GetObject<SSLSocketFactory>(native_sf, JniHandleOwnership.DoNotTransfer);
			httpsURLConnection.SSLSocketFactory = sSLSocketFactory;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}
}
