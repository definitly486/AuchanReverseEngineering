using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebResourceRequest", DoNotGenerateAcw = true)]
internal class IWebResourceRequestInvoker : Java.Lang.Object, IWebResourceRequest, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_webkit_WebResourceRequest = new XAPeerMembers("android/webkit/WebResourceRequest", typeof(IWebResourceRequestInvoker));

	private static Delegate? cb_hasGesture_HasGesture_Z;

	private static Delegate? cb_isForMainFrame_IsForMainFrame_Z;

	private static Delegate? cb_isRedirect_IsRedirect_Z;

	private static Delegate? cb_getMethod_GetMethod_Ljava_lang_String_;

	private static Delegate? cb_getRequestHeaders_GetRequestHeaders_Ljava_util_Map_;

	private static Delegate? cb_getUrl_GetUrl_Landroid_net_Uri_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_webkit_WebResourceRequest;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_webkit_WebResourceRequest.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_webkit_WebResourceRequest.ManagedPeerType;

	public unsafe bool HasGesture => _members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractBooleanMethod("hasGesture.()Z", this, null);

	public unsafe bool IsForMainFrame => _members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractBooleanMethod("isForMainFrame.()Z", this, null);

	[SupportedOSPlatform("android24.0")]
	public unsafe bool IsRedirect => _members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractBooleanMethod("isRedirect.()Z", this, null);

	public unsafe string? Method => JNIEnv.GetString(_members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractObjectMethod("getMethod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IDictionary<string, string>? RequestHeaders => JavaDictionary<string, string>.FromJniHandle(_members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractObjectMethod("getRequestHeaders.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Android.Net.Uri? Url => Java.Lang.Object.GetObject<Android.Net.Uri>(_members_android_webkit_WebResourceRequest.InstanceMethods.InvokeAbstractObjectMethod("getUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IWebResourceRequestInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetHasGestureHandler()
	{
		return new _JniMarshal_PP_B(n_HasGesture);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasGesture(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasGesture ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsForMainFrameHandler()
	{
		return new _JniMarshal_PP_B(n_IsForMainFrame);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsForMainFrame(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsForMainFrame ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetIsRedirectHandler()
	{
		return new _JniMarshal_PP_B(n_IsRedirect);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRedirect(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRedirect ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMethodHandler()
	{
		return new _JniMarshal_PP_L(n_GetMethod);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMethod(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Method);
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

	private static Delegate GetGetRequestHeadersHandler()
	{
		return new _JniMarshal_PP_L(n_GetRequestHeaders);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRequestHeaders(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestHeaders);
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

	private static Delegate GetGetUrlHandler()
	{
		return new _JniMarshal_PP_L(n_GetUrl);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetUrl(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWebResourceRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Url);
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
