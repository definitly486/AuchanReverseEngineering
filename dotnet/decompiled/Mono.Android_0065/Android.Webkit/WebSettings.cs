using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebSettings", DoNotGenerateAcw = true)]
public abstract class WebSettings : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebSettings", typeof(WebSettings));

	private static Delegate? cb_setBuiltInZoomControls_SetBuiltInZoomControls_Z_V;

	private static Delegate? cb_setDefaultTextEncodingName_SetDefaultTextEncodingName_Ljava_lang_String__V;

	private static Delegate? cb_setDisplayZoomControls_SetDisplayZoomControls_Z_V;

	private static Delegate? cb_setDomStorageEnabled_SetDomStorageEnabled_Z_V;

	private static Delegate? cb_setJavaScriptEnabled_SetJavaScriptEnabled_Z_V;

	private static Delegate? cb_setLoadWithOverviewMode_SetLoadWithOverviewMode_Z_V;

	private static Delegate? cb_setMixedContentMode_SetMixedContentMode_I_V;

	private static Delegate? cb_setUseWideViewPort_SetUseWideViewPort_Z_V;

	private static Delegate? cb_setUserAgentString_SetUserAgentString_Ljava_lang_String__V;

	private static Delegate? cb_setSupportMultipleWindows_SetSupportMultipleWindows_Z_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract bool BuiltInZoomControls { set; }

	public abstract string? DefaultTextEncodingName { set; }

	public abstract bool DisplayZoomControls { set; }

	public abstract bool DomStorageEnabled { set; }

	public abstract bool JavaScriptEnabled { set; }

	public abstract bool LoadWithOverviewMode { set; }

	public abstract MixedContentHandling MixedContentMode { set; }

	public abstract bool UseWideViewPort { set; }

	public abstract string? UserAgentString { set; }

	protected WebSettings(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetBuiltInZoomControls_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetBuiltInZoomControls_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBuiltInZoomControls_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool builtInZoomControls = native_enabled != 0;
			webSettings.BuiltInZoomControls = builtInZoomControls;
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

	private static Delegate GetSetDefaultTextEncodingName_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetDefaultTextEncodingName_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDefaultTextEncodingName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_encoding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string defaultTextEncodingName = JNIEnv.GetString(native_encoding, JniHandleOwnership.DoNotTransfer);
			webSettings.DefaultTextEncodingName = defaultTextEncodingName;
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

	private static Delegate GetSetDisplayZoomControls_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetDisplayZoomControls_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayZoomControls_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayZoomControls = native_enabled != 0;
			webSettings.DisplayZoomControls = displayZoomControls;
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

	private static Delegate GetSetDomStorageEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetDomStorageEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDomStorageEnabled_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool domStorageEnabled = native_flag != 0;
			webSettings.DomStorageEnabled = domStorageEnabled;
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

	private static Delegate GetSetJavaScriptEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetJavaScriptEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetJavaScriptEnabled_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool javaScriptEnabled = native_flag != 0;
			webSettings.JavaScriptEnabled = javaScriptEnabled;
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

	private static Delegate GetSetLoadWithOverviewMode_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetLoadWithOverviewMode_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLoadWithOverviewMode_Z(nint jnienv, nint native__this, sbyte native_overview)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool loadWithOverviewMode = native_overview != 0;
			webSettings.LoadWithOverviewMode = loadWithOverviewMode;
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

	private static Delegate GetSetMixedContentMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMixedContentMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMixedContentMode_I(nint jnienv, nint native__this, int native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MixedContentMode = (MixedContentHandling)native_mode;
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

	private static Delegate GetSetUseWideViewPort_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetUseWideViewPort_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseWideViewPort_Z(nint jnienv, nint native__this, sbyte native_use)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useWideViewPort = native_use != 0;
			webSettings.UseWideViewPort = useWideViewPort;
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

	private static Delegate GetSetUserAgentString_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetUserAgentString_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUserAgentString_Ljava_lang_String_(nint jnienv, nint native__this, nint native_ua)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string userAgentString = JNIEnv.GetString(native_ua, JniHandleOwnership.DoNotTransfer);
			webSettings.UserAgentString = userAgentString;
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

	private static Delegate GetSetSupportMultipleWindows_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetSupportMultipleWindows_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportMultipleWindows_Z(nint jnienv, nint native__this, sbyte native_support)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebSettings? webSettings = Java.Lang.Object.GetObject<WebSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool supportMultipleWindows = native_support != 0;
			webSettings.SetSupportMultipleWindows(supportMultipleWindows);
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

	public abstract void SetSupportMultipleWindows(bool support);
}
