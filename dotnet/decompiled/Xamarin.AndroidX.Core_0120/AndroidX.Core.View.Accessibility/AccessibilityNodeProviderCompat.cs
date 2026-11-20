using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityNodeProviderCompat", DoNotGenerateAcw = true)]
public class AccessibilityNodeProviderCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeProviderCompat", typeof(AccessibilityNodeProviderCompat));

	private static Delegate? cb_getProvider_GetProvider_Ljava_lang_Object_;

	private static Delegate? cb_addExtraDataToAccessibilityNodeInfo_AddExtraDataToAccessibilityNodeInfo_ILandroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Ljava_lang_String_Landroid_os_Bundle__V;

	private static Delegate? cb_createAccessibilityNodeInfo_CreateAccessibilityNodeInfo_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_findAccessibilityNodeInfosByText_FindAccessibilityNodeInfosByText_Ljava_lang_String_I_Ljava_util_List_;

	private static Delegate? cb_findFocus_FindFocus_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_performAction_PerformAction_IILandroid_os_Bundle__Z;

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

	public unsafe virtual Java.Lang.Object? Provider
	{
		[Register("getProvider", "()Ljava/lang/Object;", "GetGetProviderHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getProvider.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected AccessibilityNodeProviderCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AccessibilityNodeProviderCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/Object;)V", "")]
	public unsafe AccessibilityNodeProviderCompat(Java.Lang.Object? provider)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(provider?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	private static Delegate GetGetProviderHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetProvider);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProvider(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Provider);
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

	private static Delegate GetAddExtraDataToAccessibilityNodeInfo_ILandroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPILLL_V(n_AddExtraDataToAccessibilityNodeInfo_ILandroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Ljava_lang_String_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddExtraDataToAccessibilityNodeInfo_ILandroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Ljava_lang_String_Landroid_os_Bundle_(nint jnienv, nint native__this, int virtualViewId, nint native_info, nint native_extraDataKey, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeProviderCompat? accessibilityNodeProviderCompat = Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
			string extraDataKey = JNIEnv.GetString(native_extraDataKey, JniHandleOwnership.DoNotTransfer);
			Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeProviderCompat.AddExtraDataToAccessibilityNodeInfo(virtualViewId, info, extraDataKey, arguments);
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

	[Register("addExtraDataToAccessibilityNodeInfo", "(ILandroidx/core/view/accessibility/AccessibilityNodeInfoCompat;Ljava/lang/String;Landroid/os/Bundle;)V", "GetAddExtraDataToAccessibilityNodeInfo_ILandroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Ljava_lang_String_Landroid_os_Bundle_Handler")]
	public unsafe virtual void AddExtraDataToAccessibilityNodeInfo(int virtualViewId, AccessibilityNodeInfoCompat? info, string? extraDataKey, Bundle? arguments)
	{
		nint num = JNIEnv.NewString(extraDataKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(virtualViewId);
			ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addExtraDataToAccessibilityNodeInfo.(ILandroidx/core/view/accessibility/AccessibilityNodeInfoCompat;Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(info);
			GC.KeepAlive(arguments);
		}
	}

	private static Delegate GetCreateAccessibilityNodeInfo_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_CreateAccessibilityNodeInfo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateAccessibilityNodeInfo_I(nint jnienv, nint native__this, int virtualViewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateAccessibilityNodeInfo(virtualViewId));
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

	[Register("createAccessibilityNodeInfo", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetCreateAccessibilityNodeInfo_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? CreateAccessibilityNodeInfo(int virtualViewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(virtualViewId);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("createAccessibilityNodeInfo.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindAccessibilityNodeInfosByText_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_FindAccessibilityNodeInfosByText_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindAccessibilityNodeInfosByText_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_text, int virtualViewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeProviderCompat? accessibilityNodeProviderCompat = Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return JavaList<AccessibilityNodeInfoCompat>.ToLocalJniHandle(accessibilityNodeProviderCompat.FindAccessibilityNodeInfosByText(text, virtualViewId));
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

	[Register("findAccessibilityNodeInfosByText", "(Ljava/lang/String;I)Ljava/util/List;", "GetFindAccessibilityNodeInfosByText_Ljava_lang_String_IHandler")]
	public unsafe virtual IList<AccessibilityNodeInfoCompat>? FindAccessibilityNodeInfosByText(string? text, int virtualViewId)
	{
		nint num = JNIEnv.NewString(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(virtualViewId);
			return JavaList<AccessibilityNodeInfoCompat>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("findAccessibilityNodeInfosByText.(Ljava/lang/String;I)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetFindFocus_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindFocus_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindFocus_I(nint jnienv, nint native__this, int focus)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFocus(focus));
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

	[Register("findFocus", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetFindFocus_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? FindFocus(int focus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(focus);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFocus.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPerformAction_IILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPIIL_B(n_PerformAction_IILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformAction_IILandroid_os_Bundle_(nint jnienv, nint native__this, int virtualViewId, int action, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeProviderCompat? accessibilityNodeProviderCompat = Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
			return accessibilityNodeProviderCompat.PerformAction(virtualViewId, action, arguments) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performAction", "(IILandroid/os/Bundle;)Z", "GetPerformAction_IILandroid_os_Bundle_Handler")]
	public unsafe virtual bool PerformAction(int virtualViewId, int action, Bundle? arguments)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(virtualViewId);
			ptr[1] = new JniArgumentValue(action);
			ptr[2] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAction.(IILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(arguments);
		}
	}
}
