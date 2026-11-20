using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebView", DoNotGenerateAcw = true)]
public class WebView : AbsoluteLayout, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/webkit/WebView$WebViewTransport", DoNotGenerateAcw = true)]
	public class WebViewTransport : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebView$WebViewTransport", typeof(WebViewTransport));

		private static Delegate? cb_setWebView_SetWebView_Landroid_webkit_WebView__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual WebView? WebView
		{
			[Register("setWebView", "(Landroid/webkit/WebView;)V", "GetSetWebView_Landroid_webkit_WebView_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setWebView.(Landroid/webkit/WebView;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected WebViewTransport(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetSetWebView_Landroid_webkit_WebView_Handler()
		{
			return new _JniMarshal_PPL_V(n_SetWebView_Landroid_webkit_WebView_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetWebView_Landroid_webkit_WebView_(nint jnienv, nint native__this, nint native_webview)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WebViewTransport? webViewTransport = Java.Lang.Object.GetObject<WebViewTransport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WebView webView = Java.Lang.Object.GetObject<WebView>(native_webview, JniHandleOwnership.DoNotTransfer);
				webViewTransport.WebView = webView;
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebView", typeof(WebView));

	private static Delegate? cb_getSettings_GetSettings_Landroid_webkit_WebSettings_;

	private static Delegate? cb_addJavascriptInterface_AddJavascriptInterface_Ljava_lang_Object_Ljava_lang_String__V;

	private static Delegate? cb_destroy_Destroy_V;

	private static Delegate? cb_evaluateJavascript_EvaluateJavascript_Ljava_lang_String_Landroid_webkit_ValueCallback__V;

	private static Delegate? cb_loadData_LoadData_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_loadUrl_LoadUrl_Ljava_lang_String_Ljava_util_Map__V;

	private static Delegate? cb_loadUrl_LoadUrl_Ljava_lang_String__V;

	private static Delegate? cb_reload_Reload_V;

	private static Delegate? cb_setInitialScale_SetInitialScale_I_V;

	private static Delegate? cb_setWebChromeClient_SetWebChromeClient_Landroid_webkit_WebChromeClient__V;

	private static Delegate? cb_setWebViewClient_SetWebViewClient_Landroid_webkit_WebViewClient__V;

	private static Delegate? cb_stopLoading_StopLoading_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual WebSettings Settings
	{
		[Register("getSettings", "()Landroid/webkit/WebSettings;", "GetGetSettingsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<WebSettings>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSettings.()Landroid/webkit/WebSettings;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected WebView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;IZ)V", "")]
	[Obsolete("deprecated")]
	public unsafe WebView(Context context, IAttributeSet? attrs, int defStyleAttr, bool privateBrowsing)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(privateBrowsing ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe WebView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe WebView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe WebView(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe WebView(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetSettingsHandler()
	{
		return new _JniMarshal_PP_L(n_GetSettings);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSettings(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Settings);
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

	private static Delegate GetAddJavascriptInterface_Ljava_lang_Object_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddJavascriptInterface_Ljava_lang_Object_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddJavascriptInterface_Ljava_lang_Object_Ljava_lang_String_(nint jnienv, nint native__this, nint native__object, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			webView.AddJavascriptInterface(obj, name);
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

	[Register("addJavascriptInterface", "(Ljava/lang/Object;Ljava/lang/String;)V", "GetAddJavascriptInterface_Ljava_lang_Object_Ljava_lang_String_Handler")]
	public unsafe virtual void AddJavascriptInterface(Java.Lang.Object @object, string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addJavascriptInterface.(Ljava/lang/Object;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(@object);
		}
	}

	private static Delegate GetDestroyHandler()
	{
		return new _JniMarshal_PP_V(n_Destroy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Destroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Destroy();
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

	[Register("destroy", "()V", "GetDestroyHandler")]
	public unsafe virtual void Destroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("destroy.()V", this, null);
	}

	private static Delegate GetEvaluateJavascript_Ljava_lang_String_Landroid_webkit_ValueCallback_Handler()
	{
		return new _JniMarshal_PPLL_V(n_EvaluateJavascript_Ljava_lang_String_Landroid_webkit_ValueCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EvaluateJavascript_Ljava_lang_String_Landroid_webkit_ValueCallback_(nint jnienv, nint native__this, nint native_script, nint native_resultCallback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string script = JNIEnv.GetString(native_script, JniHandleOwnership.DoNotTransfer);
			IValueCallback resultCallback = Java.Lang.Object.GetObject<IValueCallback>(native_resultCallback, JniHandleOwnership.DoNotTransfer);
			webView.EvaluateJavascript(script, resultCallback);
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

	[Register("evaluateJavascript", "(Ljava/lang/String;Landroid/webkit/ValueCallback;)V", "GetEvaluateJavascript_Ljava_lang_String_Landroid_webkit_ValueCallback_Handler")]
	public unsafe virtual void EvaluateJavascript(string script, IValueCallback? resultCallback)
	{
		nint num = JNIEnv.NewString(script);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((resultCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)resultCallback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("evaluateJavascript.(Ljava/lang/String;Landroid/webkit/ValueCallback;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(resultCallback);
		}
	}

	private static Delegate GetLoadData_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_LoadData_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadData_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_data, nint native_mimeType, nint native_encoding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string data = JNIEnv.GetString(native_data, JniHandleOwnership.DoNotTransfer);
			string mimeType = JNIEnv.GetString(native_mimeType, JniHandleOwnership.DoNotTransfer);
			string encoding = JNIEnv.GetString(native_encoding, JniHandleOwnership.DoNotTransfer);
			webView.LoadData(data, mimeType, encoding);
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

	[Register("loadData", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetLoadData_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void LoadData(string data, string? mimeType, string? encoding)
	{
		nint num = JNIEnv.NewString(data);
		nint num2 = JNIEnv.NewString(mimeType);
		nint num3 = JNIEnv.NewString(encoding);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadData.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	private static Delegate GetLoadUrl_Ljava_lang_String_Ljava_util_Map_Handler()
	{
		return new _JniMarshal_PPLL_V(n_LoadUrl_Ljava_lang_String_Ljava_util_Map_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadUrl_Ljava_lang_String_Ljava_util_Map_(nint jnienv, nint native__this, nint native_url, nint native_additionalHttpHeaders)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, string> additionalHttpHeaders = JavaDictionary<string, string>.FromJniHandle(native_additionalHttpHeaders, JniHandleOwnership.DoNotTransfer);
			webView.LoadUrl(url, additionalHttpHeaders);
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

	[Register("loadUrl", "(Ljava/lang/String;Ljava/util/Map;)V", "GetLoadUrl_Ljava_lang_String_Ljava_util_Map_Handler")]
	public unsafe virtual void LoadUrl(string url, IDictionary<string, string> additionalHttpHeaders)
	{
		nint num = JNIEnv.NewString(url);
		nint num2 = JavaDictionary<string, string>.ToLocalJniHandle(additionalHttpHeaders);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadUrl.(Ljava/lang/String;Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(additionalHttpHeaders);
		}
	}

	private static Delegate GetLoadUrl_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_LoadUrl_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadUrl_Ljava_lang_String_(nint jnienv, nint native__this, nint native_url)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			webView.LoadUrl(url);
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

	[Register("loadUrl", "(Ljava/lang/String;)V", "GetLoadUrl_Ljava_lang_String_Handler")]
	public unsafe virtual void LoadUrl(string url)
	{
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadUrl.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetReloadHandler()
	{
		return new _JniMarshal_PP_V(n_Reload);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reload(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reload();
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

	[Register("reload", "()V", "GetReloadHandler")]
	public unsafe virtual void Reload()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reload.()V", this, null);
	}

	[SupportedOSPlatform("android28.0")]
	[Register("setDataDirectorySuffix", "(Ljava/lang/String;)V", "", ApiSince = 28)]
	public unsafe static void SetDataDirectorySuffix(string suffix)
	{
		nint num = JNIEnv.NewString(suffix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setDataDirectorySuffix.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetInitialScale_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetInitialScale_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInitialScale_I(nint jnienv, nint native__this, int scaleInPercent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetInitialScale(scaleInPercent);
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

	[Register("setInitialScale", "(I)V", "GetSetInitialScale_IHandler")]
	public unsafe virtual void SetInitialScale(int scaleInPercent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(scaleInPercent);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setInitialScale.(I)V", this, ptr);
	}

	private static Delegate GetSetWebChromeClient_Landroid_webkit_WebChromeClient_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetWebChromeClient_Landroid_webkit_WebChromeClient_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWebChromeClient_Landroid_webkit_WebChromeClient_(nint jnienv, nint native__this, nint native_client)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebChromeClient webChromeClient = Java.Lang.Object.GetObject<WebChromeClient>(native_client, JniHandleOwnership.DoNotTransfer);
			webView.SetWebChromeClient(webChromeClient);
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

	[Register("setWebChromeClient", "(Landroid/webkit/WebChromeClient;)V", "GetSetWebChromeClient_Landroid_webkit_WebChromeClient_Handler")]
	public unsafe virtual void SetWebChromeClient(WebChromeClient? client)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(client?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWebChromeClient.(Landroid/webkit/WebChromeClient;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(client);
		}
	}

	private static Delegate GetSetWebViewClient_Landroid_webkit_WebViewClient_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetWebViewClient_Landroid_webkit_WebViewClient_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWebViewClient_Landroid_webkit_WebViewClient_(nint jnienv, nint native__this, nint native_client)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WebView? webView = Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebViewClient webViewClient = Java.Lang.Object.GetObject<WebViewClient>(native_client, JniHandleOwnership.DoNotTransfer);
			webView.SetWebViewClient(webViewClient);
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

	[Register("setWebViewClient", "(Landroid/webkit/WebViewClient;)V", "GetSetWebViewClient_Landroid_webkit_WebViewClient_Handler")]
	public unsafe virtual void SetWebViewClient(WebViewClient client)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(client?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWebViewClient.(Landroid/webkit/WebViewClient;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(client);
		}
	}

	private static Delegate GetStopLoadingHandler()
	{
		return new _JniMarshal_PP_V(n_StopLoading);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopLoading(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopLoading();
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

	[Register("stopLoading", "()V", "GetStopLoadingHandler")]
	public unsafe virtual void StopLoading()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopLoading.()V", this, null);
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
