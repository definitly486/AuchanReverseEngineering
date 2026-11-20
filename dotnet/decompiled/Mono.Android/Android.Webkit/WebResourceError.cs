using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[SupportedOSPlatform("android23.0")]
[Register("android/webkit/WebResourceError", DoNotGenerateAcw = true, ApiSince = 23)]
public abstract class WebResourceError : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebResourceError", typeof(WebResourceError));

	private static Delegate? cb_getDescription_GetDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_getErrorCode_GetErrorCode_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract ICharSequence? DescriptionFormatted
	{
		[SupportedOSPlatform("android23.0")]
		[Register("getDescription", "()Ljava/lang/CharSequence;", "GetGetDescriptionHandler", ApiSince = 23)]
		get;
	}

	[SupportedOSPlatform("android23.0")]
	public string? Description
	{
		get
		{
			if (DescriptionFormatted != null)
			{
				return DescriptionFormatted.ToString();
			}
			return null;
		}
	}

	public abstract ClientError ErrorCode
	{
		[SupportedOSPlatform("android23.0")]
		[Register("getErrorCode", "()I", "GetGetErrorCodeHandler", ApiSince = 23)]
		get;
	}

	protected WebResourceError(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetGetDescriptionHandler()
	{
		return new _JniMarshal_PP_L(n_GetDescription);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<WebResourceError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescriptionFormatted);
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

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetGetErrorCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetErrorCode);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetErrorCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<WebResourceError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorCode;
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
