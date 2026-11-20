using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Net;

[Register("java/net/HttpURLConnection", DoNotGenerateAcw = true)]
public abstract class HttpURLConnection : URLConnection
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/HttpURLConnection", typeof(HttpURLConnection));

	private static Delegate? cb_getErrorStream_GetErrorStream_Ljava_io_InputStream_;

	private static Delegate? cb_setInstanceFollowRedirects_SetInstanceFollowRedirects_Z_V;

	private static Delegate? cb_getRequestMethod_GetRequestMethod_Ljava_lang_String_;

	private static Delegate? cb_setRequestMethod_SetRequestMethod_Ljava_lang_String__V;

	private static Delegate? cb_getResponseCode_GetResponseCode_I;

	private static Delegate? cb_getResponseMessage_GetResponseMessage_Ljava_lang_String_;

	private static Delegate? cb_disconnect_Disconnect_V;

	private static Delegate? cb_setChunkedStreamingMode_SetChunkedStreamingMode_I_V;

	private static Delegate? cb_setFixedLengthStreamingMode_SetFixedLengthStreamingMode_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual Stream? ErrorStream => InputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorStream.()Ljava/io/InputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual bool InstanceFollowRedirects
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInstanceFollowRedirects.(Z)V", this, ptr);
		}
	}

	public unsafe virtual string? RequestMethod
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getRequestMethod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRequestMethod.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual HttpStatus ResponseCode => (HttpStatus)_members.InstanceMethods.InvokeVirtualInt32Method("getResponseCode.()I", this, null);

	public unsafe virtual string? ResponseMessage => JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getResponseMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	protected HttpURLConnection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	protected unsafe HttpURLConnection(URL? u)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(u?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/net/URL;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/net/URL;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(u);
		}
	}

	private static Delegate GetGetErrorStreamHandler()
	{
		return new _JniMarshal_PP_L(n_GetErrorStream);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetErrorStream(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return InputStreamAdapter.ToLocalJniHandle(Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorStream);
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

	private static Delegate GetSetInstanceFollowRedirects_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetInstanceFollowRedirects_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInstanceFollowRedirects_Z(nint jnienv, nint native__this, sbyte native_followRedirects)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HttpURLConnection? httpURLConnection = Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool instanceFollowRedirects = native_followRedirects != 0;
			httpURLConnection.InstanceFollowRedirects = instanceFollowRedirects;
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

	private static Delegate GetGetRequestMethodHandler()
	{
		return new _JniMarshal_PP_L(n_GetRequestMethod);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRequestMethod(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestMethod);
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

	private static Delegate GetSetRequestMethod_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetRequestMethod_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRequestMethod_Ljava_lang_String_(nint jnienv, nint native__this, nint native_method)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HttpURLConnection? httpURLConnection = Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string requestMethod = JNIEnv.GetString(native_method, JniHandleOwnership.DoNotTransfer);
			httpURLConnection.RequestMethod = requestMethod;
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

	private static Delegate GetGetResponseCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetResponseCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetResponseCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseCode;
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

	private static Delegate GetGetResponseMessageHandler()
	{
		return new _JniMarshal_PP_L(n_GetResponseMessage);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResponseMessage(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseMessage);
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

	private static Delegate GetDisconnectHandler()
	{
		return new _JniMarshal_PP_V(n_Disconnect);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Disconnect(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Disconnect();
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

	public abstract void Disconnect();

	private static Delegate GetSetChunkedStreamingMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetChunkedStreamingMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChunkedStreamingMode_I(nint jnienv, nint native__this, int chunklen)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetChunkedStreamingMode(chunklen);
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

	public unsafe virtual void SetChunkedStreamingMode(int chunklen)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(chunklen);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setChunkedStreamingMode.(I)V", this, ptr);
	}

	private static Delegate GetSetFixedLengthStreamingMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetFixedLengthStreamingMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFixedLengthStreamingMode_I(nint jnienv, nint native__this, int contentLength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<HttpURLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFixedLengthStreamingMode(contentLength);
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

	public unsafe virtual void SetFixedLengthStreamingMode(int contentLength)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(contentLength);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFixedLengthStreamingMode.(I)V", this, ptr);
	}
}
