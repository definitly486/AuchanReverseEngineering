using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSessionContext", DoNotGenerateAcw = true)]
internal class ISSLSessionContextInvoker : Java.Lang.Object, ISSLSessionContext, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_net_ssl_SSLSessionContext = new XAPeerMembers("javax/net/ssl/SSLSessionContext", typeof(ISSLSessionContextInvoker));

	private static Delegate? cb_getIds_GetIds_Ljava_util_Enumeration_;

	private static Delegate? cb_getSessionCacheSize_GetSessionCacheSize_I;

	private static Delegate? cb_setSessionCacheSize_SetSessionCacheSize_I_V;

	private static Delegate? cb_getSessionTimeout_GetSessionTimeout_I;

	private static Delegate? cb_setSessionTimeout_SetSessionTimeout_I_V;

	private static Delegate? cb_getSession_GetSession_arrayB_Ljavax_net_ssl_SSLSession_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_net_ssl_SSLSessionContext;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_net_ssl_SSLSessionContext.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_net_ssl_SSLSessionContext.ManagedPeerType;

	public unsafe IEnumeration? Ids => Java.Lang.Object.GetObject<IEnumeration>(_members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractObjectMethod("getIds.()Ljava/util/Enumeration;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int SessionCacheSize
	{
		get
		{
			return _members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractInt32Method("getSessionCacheSize.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractVoidMethod("setSessionCacheSize.(I)V", this, ptr);
		}
	}

	public unsafe int SessionTimeout
	{
		get
		{
			return _members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractInt32Method("getSessionTimeout.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractVoidMethod("setSessionTimeout.(I)V", this, ptr);
		}
	}

	public ISSLSessionContextInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetIdsHandler()
	{
		return new _JniMarshal_PP_L(n_GetIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Ids);
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

	private static Delegate GetGetSessionCacheSizeHandler()
	{
		return new _JniMarshal_PP_I(n_GetSessionCacheSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSessionCacheSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionCacheSize;
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

	private static Delegate GetSetSessionCacheSize_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSessionCacheSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSessionCacheSize_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionCacheSize = size;
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

	private static Delegate GetGetSessionTimeoutHandler()
	{
		return new _JniMarshal_PP_I(n_GetSessionTimeout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSessionTimeout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionTimeout;
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

	private static Delegate GetSetSessionTimeout_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSessionTimeout_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSessionTimeout_I(nint jnienv, nint native__this, int seconds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionTimeout = seconds;
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

	private static Delegate GetGetSession_arrayBHandler()
	{
		return new _JniMarshal_PPL_L(n_GetSession_arrayB);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSession_arrayB(nint jnienv, nint native__this, nint native_sessionId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISSLSessionContext? iSSLSessionContext = Java.Lang.Object.GetObject<ISSLSessionContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_sessionId, JniHandleOwnership.DoNotTransfer, typeof(byte));
			nint result = JNIEnv.ToLocalJniHandle(iSSLSessionContext.GetSession(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_sessionId);
			}
			return result;
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

	public unsafe ISSLSession? GetSession(byte[]? sessionId)
	{
		nint num = JNIEnv.NewArray(sessionId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISSLSession>(_members_javax_net_ssl_SSLSessionContext.InstanceMethods.InvokeAbstractObjectMethod("getSession.([B)Ljavax/net/ssl/SSLSession;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (sessionId != null)
			{
				JNIEnv.CopyArray(num, sessionId);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(sessionId);
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
}
