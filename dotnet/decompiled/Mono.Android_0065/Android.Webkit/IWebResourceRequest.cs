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
	bool HasGesture { get; }

	bool IsForMainFrame { get; }

	bool IsRedirect
	{
		[SupportedOSPlatform("android24.0")]
		get;
	}

	string? Method { get; }

	IDictionary<string, string>? RequestHeaders { get; }

	Android.Net.Uri? Url { get; }
}
