using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Android.Net;
using Android.Runtime;
using Java.Interop;

namespace Android.Webkit;

[Register("android/webkit/WebResourceRequest", "", "Android.Webkit.IWebResourceRequestInvoker")]
public interface IWebResourceRequest : IJavaObject, IDisposable, IJavaPeerable
{
	bool HasGesture
	{
		[Register("hasGesture", "()Z", "GetHasGestureHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsForMainFrame
	{
		[Register("isForMainFrame", "()Z", "GetIsForMainFrameHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsRedirect
	{
		[SupportedOSPlatform("android24.0")]
		[Register("isRedirect", "()Z", "GetIsRedirectHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
		get;
	}

	string? Method
	{
		[Register("getMethod", "()Ljava/lang/String;", "GetGetMethodHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IDictionary<string, string>? RequestHeaders
	{
		[Register("getRequestHeaders", "()Ljava/util/Map;", "GetGetRequestHeadersHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	Android.Net.Uri? Url
	{
		[Register("getUrl", "()Landroid/net/Uri;", "GetGetUrlHandler:Android.Webkit.IWebResourceRequestInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}
}
