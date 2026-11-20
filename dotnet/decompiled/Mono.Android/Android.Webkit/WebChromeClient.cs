using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebChromeClient", DoNotGenerateAcw = true)]
public class WebChromeClient : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebChromeClient", typeof(WebChromeClient));

	private static Delegate? cb_onCreateWindow_OnCreateWindow_Landroid_webkit_WebView_ZZLandroid_os_Message__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected WebChromeClient(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe WebChromeClient()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnCreateWindow_Landroid_webkit_WebView_ZZLandroid_os_Message_(nint jnienv, nint native__this, nint native_view, sbyte native_isDialog, sbyte native_isUserGesture, nint native_resultMsg)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WebChromeClient? webChromeClient = Java.Lang.Object.GetObject<WebChromeClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebView view = Java.Lang.Object.GetObject<WebView>(native_view, JniHandleOwnership.DoNotTransfer);
			bool isDialog = native_isDialog != 0;
			bool isUserGesture = native_isUserGesture != 0;
			Message resultMsg = Java.Lang.Object.GetObject<Message>(native_resultMsg, JniHandleOwnership.DoNotTransfer);
			return webChromeClient.OnCreateWindow(view, isDialog, isUserGesture, resultMsg) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onCreateWindow", "(Landroid/webkit/WebView;ZZLandroid/os/Message;)Z", "GetOnCreateWindow_Landroid_webkit_WebView_ZZLandroid_os_Message_Handler")]
	public unsafe virtual bool OnCreateWindow(WebView? view, bool isDialog, bool isUserGesture, Message? resultMsg)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isDialog ? ((sbyte)1) : ((sbyte)0));
			ptr[2] = new JniArgumentValue(isUserGesture ? ((sbyte)1) : ((sbyte)0));
			ptr[3] = new JniArgumentValue(resultMsg?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onCreateWindow.(Landroid/webkit/WebView;ZZLandroid/os/Message;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(resultMsg);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_OnCreateWindow_Landroid_webkit_WebView_ZZLandroid_os_Message__mm_wrapper(nint jnienv, nint native__this, nint native_view, sbyte native_isDialog, sbyte native_isUserGesture, nint native_resultMsg)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnCreateWindow_Landroid_webkit_WebView_ZZLandroid_os_Message_(jnienv, native__this, native_view, native_isDialog, native_isUserGesture, native_resultMsg);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
