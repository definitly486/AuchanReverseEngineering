using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebViewClient", DoNotGenerateAcw = true)]
public class WebViewClient : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebViewClient", typeof(WebViewClient));

	private static Delegate? cb_onLoadResource_OnLoadResource_Landroid_webkit_WebView_Ljava_lang_String__V;

	private static Delegate? cb_onPageFinished_OnPageFinished_Landroid_webkit_WebView_Ljava_lang_String__V;

	private static Delegate? cb_onPageStarted_OnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap__V;

	private static Delegate? cb_onReceivedError_OnReceivedError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceError__V;

	private static Delegate? cb_onReceivedHttpAuthRequest_OnReceivedHttpAuthRequest_Landroid_webkit_WebView_Landroid_webkit_HttpAuthHandler_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_onReceivedHttpError_OnReceivedHttpError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceResponse__V;

	private static Delegate? cb_shouldOverrideUrlLoading_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest__Z;

	private static Delegate? cb_shouldOverrideUrlLoading_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected WebViewClient(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe WebViewClient()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadResource_Landroid_webkit_WebView_Ljava_lang_String_(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnLoadResource(view, url);
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

	public unsafe virtual void OnLoadResource(WebView? view, string? url)
	{
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLoadResource.(Landroid/webkit/WebView;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnPageFinished(view, url);
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

	public unsafe virtual void OnPageFinished(WebView? view, string? url)
	{
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageFinished.(Landroid/webkit/WebView;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_view, nint native_url, nint native_favicon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			Bitmap favicon = Java.Lang.Object.GetObject<Bitmap>(native_favicon, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnPageStarted(view, url, favicon);
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

	public unsafe virtual void OnPageStarted(WebView? view, string? url, Bitmap? favicon)
	{
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(favicon?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageStarted.(Landroid/webkit/WebView;Ljava/lang/String;Landroid/graphics/Bitmap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(favicon);
		}
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReceivedError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceError_(nint jnienv, nint native__this, nint native_view, nint native_request, nint native_error)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			IWebResourceRequest request = Java.Lang.Object.GetObject<IWebResourceRequest>(native_request, JniHandleOwnership.DoNotTransfer);
			WebResourceError error = Java.Lang.Object.GetObject<WebResourceError>(native_error, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnReceivedError(view, request, error);
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

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual void OnReceivedError(WebView? view, IWebResourceRequest? request, WebResourceError? error)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[2] = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onReceivedError.(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;Landroid/webkit/WebResourceError;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(request);
			GC.KeepAlive(error);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReceivedHttpAuthRequest_Landroid_webkit_WebView_Landroid_webkit_HttpAuthHandler_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_view, nint native_handler, nint native_host, nint native_realm)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			HttpAuthHandler handler = Java.Lang.Object.GetObject<HttpAuthHandler>(native_handler, JniHandleOwnership.DoNotTransfer);
			string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
			string realm = JNIEnv.GetString(native_realm, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnReceivedHttpAuthRequest(view, handler, host, realm);
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

	public unsafe virtual void OnReceivedHttpAuthRequest(WebView? view, HttpAuthHandler? handler, string? host, string? realm)
	{
		nint num = JNIEnv.NewString(host);
		nint num2 = JNIEnv.NewString(realm);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onReceivedHttpAuthRequest.(Landroid/webkit/WebView;Landroid/webkit/HttpAuthHandler;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(view);
			GC.KeepAlive(handler);
		}
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReceivedHttpError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceResponse_(nint jnienv, nint native__this, nint native_view, nint native_request, nint native_errorResponse)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			IWebResourceRequest request = Java.Lang.Object.GetObject<IWebResourceRequest>(native_request, JniHandleOwnership.DoNotTransfer);
			WebResourceResponse errorResponse = Java.Lang.Object.GetObject<WebResourceResponse>(native_errorResponse, JniHandleOwnership.DoNotTransfer);
			webViewClient.OnReceivedHttpError(view, request, errorResponse);
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

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual void OnReceivedHttpError(WebView? view, IWebResourceRequest? request, WebResourceResponse? errorResponse)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[2] = new JniArgumentValue(errorResponse?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onReceivedHttpError.(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;Landroid/webkit/WebResourceResponse;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(request);
			GC.KeepAlive(errorResponse);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_(nint jnienv, nint native__this, nint native_view, nint native_request)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			IWebResourceRequest request = Java.Lang.Object.GetObject<IWebResourceRequest>(native_request, JniHandleOwnership.DoNotTransfer);
			return webViewClient.ShouldOverrideUrlLoading(view, request) ? ((sbyte)1) : ((sbyte)0);
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
	public unsafe virtual bool ShouldOverrideUrlLoading(WebView? view, IWebResourceRequest? request)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldOverrideUrlLoading.(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(request);
		}
	}

	[ObsoletedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WebViewClient? webViewClient = Java.Lang.Object.GetObject<WebViewClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			return webViewClient.ShouldOverrideUrlLoading(view, url) ? ((sbyte)1) : ((sbyte)0);
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

	[ObsoletedOSPlatform("android24.0")]
	public unsafe virtual bool ShouldOverrideUrlLoading(WebView? view, string? url)
	{
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldOverrideUrlLoading.(Landroid/webkit/WebView;Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_(jnienv, native__this, native_view, native_url);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_request)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_ShouldOverrideUrlLoading_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_(jnienv, native__this, native_view, native_request);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_url, nint native_favicon)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_(jnienv, native__this, native_view, native_url, native_favicon);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnPageFinished_Landroid_webkit_WebView_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_(jnienv, native__this, native_view, native_url);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnLoadResource_Landroid_webkit_WebView_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_url)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnLoadResource_Landroid_webkit_WebView_Ljava_lang_String_(jnienv, native__this, native_view, native_url);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnReceivedError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceError__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_request, nint native_error)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnReceivedError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceError_(jnienv, native__this, native_view, native_request, native_error);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnReceivedHttpError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceResponse__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_request, nint native_errorResponse)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnReceivedHttpError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceResponse_(jnienv, native__this, native_view, native_request, native_errorResponse);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnReceivedHttpAuthRequest_Landroid_webkit_WebView_Landroid_webkit_HttpAuthHandler_Ljava_lang_String_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_handler, nint native_host, nint native_realm)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnReceivedHttpAuthRequest_Landroid_webkit_WebView_Landroid_webkit_HttpAuthHandler_Ljava_lang_String_Ljava_lang_String_(jnienv, native__this, native_view, native_handler, native_host, native_realm);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
