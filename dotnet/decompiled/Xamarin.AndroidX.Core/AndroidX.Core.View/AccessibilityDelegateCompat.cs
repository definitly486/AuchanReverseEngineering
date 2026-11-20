using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using AndroidX.Core.View.Accessibility;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/AccessibilityDelegateCompat", DoNotGenerateAcw = true)]
public class AccessibilityDelegateCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/AccessibilityDelegateCompat", typeof(AccessibilityDelegateCompat));

	private static Delegate? cb_dispatchPopulateAccessibilityEvent_DispatchPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_getAccessibilityNodeProvider_GetAccessibilityNodeProvider_Landroid_view_View__Landroidx_core_view_accessibility_AccessibilityNodeProviderCompat_;

	private static Delegate? cb_onInitializeAccessibilityEvent_OnInitializeAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__V;

	private static Delegate? cb_onInitializeAccessibilityNodeInfo_OnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat__V;

	private static Delegate? cb_onPopulateAccessibilityEvent_OnPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__V;

	private static Delegate? cb_onRequestSendAccessibilityEvent_OnRequestSendAccessibilityEvent_Landroid_view_ViewGroup_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_performAccessibilityAction_PerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle__Z;

	private static Delegate? cb_sendAccessibilityEvent_SendAccessibilityEvent_Landroid_view_View_I_V;

	private static Delegate? cb_sendAccessibilityEventUnchecked_SendAccessibilityEventUnchecked_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__V;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AccessibilityDelegateCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AccessibilityDelegateCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/view/View$AccessibilityDelegate;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe AccessibilityDelegateCompat(Android.Views.View.AccessibilityDelegate? originalDelegate)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(originalDelegate?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View$AccessibilityDelegate;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View$AccessibilityDelegate;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(originalDelegate);
		}
	}

	private static Delegate GetDispatchPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_DispatchPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_host, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return accessibilityDelegateCompat.DispatchPopulateAccessibilityEvent(host, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchPopulateAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", "GetDispatchPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual bool DispatchPopulateAccessibilityEvent(Android.Views.View? host, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchPopulateAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetGetAccessibilityNodeProvider_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetAccessibilityNodeProvider_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAccessibilityNodeProvider_Landroid_view_View_(nint jnienv, nint native__this, nint native_host)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(accessibilityDelegateCompat.GetAccessibilityNodeProvider(host));
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

	[Register("getAccessibilityNodeProvider", "(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeProviderCompat;", "GetGetAccessibilityNodeProvider_Landroid_view_View_Handler")]
	public unsafe virtual AccessibilityNodeProviderCompat? GetAccessibilityNodeProvider(Android.Views.View? host)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAccessibilityNodeProvider.(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeProviderCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(host);
		}
	}

	private static Delegate GetOnInitializeAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnInitializeAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInitializeAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_host, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			accessibilityDelegateCompat.OnInitializeAccessibilityEvent(host, e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onInitializeAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnInitializeAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual void OnInitializeAccessibilityEvent(Android.Views.View? host, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_(nint jnienv, nint native__this, nint native_host, nint native_info)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
			accessibilityDelegateCompat.OnInitializeAccessibilityNodeInfo(host, info);
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

	[Register("onInitializeAccessibilityNodeInfo", "(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler")]
	public unsafe virtual void OnInitializeAccessibilityNodeInfo(Android.Views.View? host, AccessibilityNodeInfoCompat? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfo.(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetOnPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_host, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			accessibilityDelegateCompat.OnPopulateAccessibilityEvent(host, e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onPopulateAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnPopulateAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual void OnPopulateAccessibilityEvent(Android.Views.View? host, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPopulateAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnRequestSendAccessibilityEvent_Landroid_view_ViewGroup_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new global::_JniMarshal_PPLLL_B(n_OnRequestSendAccessibilityEvent_Landroid_view_ViewGroup_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnRequestSendAccessibilityEvent_Landroid_view_ViewGroup_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_host, nint native_child, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup host = Java.Lang.Object.GetObject<ViewGroup>(native_host, JniHandleOwnership.DoNotTransfer);
			Android.Views.View child = Java.Lang.Object.GetObject<Android.Views.View>(native_child, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return accessibilityDelegateCompat.OnRequestSendAccessibilityEvent(host, child, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onRequestSendAccessibilityEvent", "(Landroid/view/ViewGroup;Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", "GetOnRequestSendAccessibilityEvent_Landroid_view_ViewGroup_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual bool OnRequestSendAccessibilityEvent(ViewGroup? host, Android.Views.View? child, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestSendAccessibilityEvent.(Landroid/view/ViewGroup;Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetPerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLIL_B(n_PerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_host, int action, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return accessibilityDelegateCompat.PerformAccessibilityAction(host, action, args) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performAccessibilityAction", "(Landroid/view/View;ILandroid/os/Bundle;)Z", "GetPerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_Handler")]
	public unsafe virtual bool PerformAccessibilityAction(Android.Views.View? host, int action, Bundle? args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(action);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAccessibilityAction.(Landroid/view/View;ILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetSendAccessibilityEvent_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SendAccessibilityEvent_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SendAccessibilityEvent_Landroid_view_View_I(nint jnienv, nint native__this, nint native_host, int eventType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			accessibilityDelegateCompat.SendAccessibilityEvent(host, eventType);
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

	[Register("sendAccessibilityEvent", "(Landroid/view/View;I)V", "GetSendAccessibilityEvent_Landroid_view_View_IHandler")]
	public unsafe virtual void SendAccessibilityEvent(Android.Views.View? host, int eventType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(eventType);
			_members.InstanceMethods.InvokeVirtualVoidMethod("sendAccessibilityEvent.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
		}
	}

	private static Delegate GetSendAccessibilityEventUnchecked_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SendAccessibilityEventUnchecked_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SendAccessibilityEventUnchecked_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_host, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityDelegateCompat? accessibilityDelegateCompat = Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View host = Java.Lang.Object.GetObject<Android.Views.View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			accessibilityDelegateCompat.SendAccessibilityEventUnchecked(host, e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("sendAccessibilityEventUnchecked", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", "GetSendAccessibilityEventUnchecked_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual void SendAccessibilityEventUnchecked(Android.Views.View? host, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("sendAccessibilityEventUnchecked.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(host);
			GC.KeepAlive(e);
		}
	}
}
