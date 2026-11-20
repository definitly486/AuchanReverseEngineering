using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Net;

[Register("java/net/URLConnection", DoNotGenerateAcw = true)]
public abstract class URLConnection : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/URLConnection", typeof(URLConnection));

	private static Delegate? cb_setConnectTimeout_SetConnectTimeout_I_V;

	private static Delegate? cb_getContentEncoding_GetContentEncoding_Ljava_lang_String_;

	private static Delegate? cb_getDoOutput_GetDoOutput_Z;

	private static Delegate? cb_setDoOutput_SetDoOutput_Z_V;

	private static Delegate? cb_getHeaderFields_GetHeaderFields_Ljava_util_Map_;

	private static Delegate? cb_getInputStream_GetInputStream_Ljava_io_InputStream_;

	private static Delegate? cb_getOutputStream_GetOutputStream_Ljava_io_OutputStream_;

	private static Delegate? cb_setReadTimeout_SetReadTimeout_I_V;

	private static Delegate? cb_getURL_GetURL_Ljava_net_URL_;

	private static Delegate? cb_connect_Connect_V;

	private static Delegate? cb_setRequestProperty_SetRequestProperty_Ljava_lang_String_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int ConnectTimeout
	{
		[Register("setConnectTimeout", "(I)V", "GetSetConnectTimeout_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setConnectTimeout.(I)V", this, ptr);
		}
	}

	public unsafe virtual string? ContentEncoding
	{
		[Register("getContentEncoding", "()Ljava/lang/String;", "GetGetContentEncodingHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentEncoding.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool DoOutput
	{
		[Register("getDoOutput", "()Z", "GetGetDoOutputHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getDoOutput.()Z", this, null);
		}
		[Register("setDoOutput", "(Z)V", "GetSetDoOutput_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDoOutput.(Z)V", this, ptr);
		}
	}

	public unsafe virtual IDictionary<string, IList<string>>? HeaderFields
	{
		[Register("getHeaderFields", "()Ljava/util/Map;", "GetGetHeaderFieldsHandler")]
		get
		{
			return JavaDictionary<string, IList<string>>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaderFields.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Stream? InputStream
	{
		[Register("getInputStream", "()Ljava/io/InputStream;", "GetGetInputStreamHandler")]
		get
		{
			return InputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getInputStream.()Ljava/io/InputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Stream? OutputStream
	{
		[Register("getOutputStream", "()Ljava/io/OutputStream;", "GetGetOutputStreamHandler")]
		get
		{
			return OutputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOutputStream.()Ljava/io/OutputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int ReadTimeout
	{
		[Register("setReadTimeout", "(I)V", "GetSetReadTimeout_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReadTimeout.(I)V", this, ptr);
		}
	}

	public unsafe virtual URL? URL
	{
		[Register("getURL", "()Ljava/net/URL;", "GetGetURLHandler")]
		get
		{
			return Java.Lang.Object.GetObject<URL>(_members.InstanceMethods.InvokeVirtualObjectMethod("getURL.()Ljava/net/URL;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected URLConnection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetConnectTimeout_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetConnectTimeout_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetConnectTimeout_I(nint jnienv, nint native__this, int timeout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConnectTimeout = timeout;
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

	private static Delegate GetGetContentEncodingHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentEncoding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentEncoding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentEncoding);
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

	private static Delegate GetGetDoOutputHandler()
	{
		return new _JniMarshal_PP_B(n_GetDoOutput);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetDoOutput(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoOutput ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDoOutput_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetDoOutput_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDoOutput_Z(nint jnienv, nint native__this, sbyte native_dooutput)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			URLConnection? uRLConnection = Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool doOutput = native_dooutput != 0;
			uRLConnection.DoOutput = doOutput;
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

	private static Delegate GetGetHeaderFieldsHandler()
	{
		return new _JniMarshal_PP_L(n_GetHeaderFields);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaderFields(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, IList<string>>.ToLocalJniHandle(Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeaderFields);
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

	private static Delegate GetGetInputStreamHandler()
	{
		return new _JniMarshal_PP_L(n_GetInputStream);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInputStream(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return InputStreamAdapter.ToLocalJniHandle(Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputStream);
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

	private static Delegate GetGetOutputStreamHandler()
	{
		return new _JniMarshal_PP_L(n_GetOutputStream);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOutputStream(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return OutputStreamAdapter.ToLocalJniHandle(Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputStream);
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

	private static Delegate GetSetReadTimeout_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetReadTimeout_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReadTimeout_I(nint jnienv, nint native__this, int timeout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadTimeout = timeout;
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

	private static Delegate GetGetURLHandler()
	{
		return new _JniMarshal_PP_L(n_GetURL);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetURL(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).URL);
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

	private static Delegate GetConnectHandler()
	{
		return new _JniMarshal_PP_V(n_Connect);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect();
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

	[Register("connect", "()V", "GetConnectHandler")]
	public abstract void Connect();

	private static Delegate GetSetRequestProperty_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_SetRequestProperty_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRequestProperty_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			URLConnection? uRLConnection = Java.Lang.Object.GetObject<URLConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			uRLConnection.SetRequestProperty(key, value);
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

	[Register("setRequestProperty", "(Ljava/lang/String;Ljava/lang/String;)V", "GetSetRequestProperty_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void SetRequestProperty(string? key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRequestProperty.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}
