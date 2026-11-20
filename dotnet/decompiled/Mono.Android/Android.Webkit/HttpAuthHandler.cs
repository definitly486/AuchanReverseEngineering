using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/HttpAuthHandler", DoNotGenerateAcw = true)]
public class HttpAuthHandler : Handler
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/HttpAuthHandler", typeof(HttpAuthHandler));

	private static Delegate? cb_proceed_Proceed_Ljava_lang_String_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected HttpAuthHandler(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetProceed_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_Proceed_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Proceed_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_username, nint native_password)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HttpAuthHandler? httpAuthHandler = Java.Lang.Object.GetObject<HttpAuthHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string username = JNIEnv.GetString(native_username, JniHandleOwnership.DoNotTransfer);
			string password = JNIEnv.GetString(native_password, JniHandleOwnership.DoNotTransfer);
			httpAuthHandler.Proceed(username, password);
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

	[Register("proceed", "(Ljava/lang/String;Ljava/lang/String;)V", "GetProceed_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void Proceed(string? username, string? password)
	{
		nint num = JNIEnv.NewString(username);
		nint num2 = JNIEnv.NewString(password);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("proceed.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}
