using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebResourceResponse", DoNotGenerateAcw = true)]
public class WebResourceResponse : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebResourceResponse", typeof(WebResourceResponse));

	private static Delegate? cb_getReasonPhrase_GetReasonPhrase_Ljava_lang_String_;

	private static Delegate? cb_getStatusCode_GetStatusCode_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual string? ReasonPhrase
	{
		[Register("getReasonPhrase", "()Ljava/lang/String;", "GetGetReasonPhraseHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getReasonPhrase.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int StatusCode
	{
		[Register("getStatusCode", "()I", "GetGetStatusCodeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStatusCode.()I", this, null);
		}
	}

	protected WebResourceResponse(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetReasonPhraseHandler()
	{
		return new _JniMarshal_PP_L(n_GetReasonPhrase);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReasonPhrase(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<WebResourceResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReasonPhrase);
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

	private static Delegate GetGetStatusCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetStatusCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStatusCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WebResourceResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusCode;
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
}
