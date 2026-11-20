using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Views.Accessibility;
using AndroidX.Core.OS;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityWindowInfoCompat", DoNotGenerateAcw = true)]
public class AccessibilityWindowInfoCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityWindowInfoCompat", typeof(AccessibilityWindowInfoCompat));

	private static Delegate? cb_getAnchor_GetAnchor_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getChildCount_GetChildCount_I;

	private static Delegate? cb_getDisplayId_GetDisplayId_I;

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_isAccessibilityFocused_IsAccessibilityFocused_Z;

	private static Delegate? cb_isActive_IsActive_Z;

	private static Delegate? cb_isFocused_IsFocused_Z;

	private static Delegate? cb_isInPictureInPictureMode_IsInPictureInPictureMode_Z;

	private static Delegate? cb_getLayer_GetLayer_I;

	private static Delegate? cb_getLocales_GetLocales_Landroidx_core_os_LocaleListCompat_;

	private static Delegate? cb_getParent_GetParent_Landroidx_core_view_accessibility_AccessibilityWindowInfoCompat_;

	private static Delegate? cb_getRoot_GetRoot_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_getTransitionTimeMillis_GetTransitionTimeMillis_J;

	private static Delegate? cb_getType_GetType_I;

	private static Delegate? cb_getBoundsInScreen_GetBoundsInScreen_Landroid_graphics_Rect__V;

	private static Delegate? cb_getChild_GetChild_I_Landroidx_core_view_accessibility_AccessibilityWindowInfoCompat_;

	private static Delegate? cb_getRegionInScreen_GetRegionInScreen_Landroid_graphics_Region__V;

	private static Delegate? cb_getRoot_GetRoot_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_recycle_Recycle_V;

	private static Delegate? cb_unwrap_Unwrap_Landroid_view_accessibility_AccessibilityWindowInfo_;

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

	public unsafe virtual AccessibilityNodeInfoCompat? Anchor
	{
		[Register("getAnchor", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetAnchorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchor.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int ChildCount
	{
		[Register("getChildCount", "()I", "GetGetChildCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
		}
	}

	public unsafe virtual int DisplayId
	{
		[Register("getDisplayId", "()I", "GetGetDisplayIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDisplayId.()I", this, null);
		}
	}

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
		}
	}

	public unsafe virtual bool IsAccessibilityFocused
	{
		[Register("isAccessibilityFocused", "()Z", "GetIsAccessibilityFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAccessibilityFocused.()Z", this, null);
		}
	}

	public unsafe virtual bool IsActive
	{
		[Register("isActive", "()Z", "GetIsActiveHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isActive.()Z", this, null);
		}
	}

	public unsafe virtual bool IsFocused
	{
		[Register("isFocused", "()Z", "GetIsFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocused.()Z", this, null);
		}
	}

	public unsafe virtual bool IsInPictureInPictureMode
	{
		[Register("isInPictureInPictureMode", "()Z", "GetIsInPictureInPictureModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInPictureInPictureMode.()Z", this, null);
		}
	}

	public unsafe virtual int Layer
	{
		[Register("getLayer", "()I", "GetGetLayerHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLayer.()I", this, null);
		}
	}

	public unsafe virtual LocaleListCompat? Locales
	{
		[Register("getLocales", "()Landroidx/core/os/LocaleListCompat;", "GetGetLocalesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLocales.()Landroidx/core/os/LocaleListCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AccessibilityWindowInfoCompat? Parent
	{
		[Register("getParent", "()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", "GetGetParentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? Root
	{
		[Register("getRoot", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetRootHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRoot.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe virtual long TransitionTimeMillis
	{
		[Register("getTransitionTimeMillis", "()J", "GetGetTransitionTimeMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTransitionTimeMillis.()J", this, null);
		}
	}

	public unsafe virtual int Type
	{
		[Register("getType", "()I", "GetGetTypeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getType.()I", this, null);
		}
	}

	protected AccessibilityWindowInfoCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AccessibilityWindowInfoCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetAnchorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnchor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnchor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Anchor);
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

	private static Delegate GetGetChildCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetChildCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetChildCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
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

	private static Delegate GetGetDisplayIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDisplayId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDisplayId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayId;
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

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

	private static Delegate GetIsAccessibilityFocusedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAccessibilityFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAccessibilityFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAccessibilityFocused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsActiveHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsActive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsActive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsActive ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsFocusedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFocused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsInPictureInPictureModeHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInPictureInPictureMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInPictureInPictureMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInPictureInPictureMode ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLayerHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLayer);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLayer(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Layer;
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

	private static Delegate GetGetLocalesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLocales);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLocales(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Locales);
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

	private static Delegate GetGetParentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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

	private static Delegate GetGetRootHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRoot);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRoot(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Root);
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

	private static Delegate GetGetTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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

	private static Delegate GetGetTransitionTimeMillisHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetTransitionTimeMillis);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTransitionTimeMillis(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionTimeMillis;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTypeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type;
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

	private static Delegate GetGetBoundsInScreen_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetBoundsInScreen_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetBoundsInScreen_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityWindowInfoCompat? accessibilityWindowInfoCompat = Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			accessibilityWindowInfoCompat.GetBoundsInScreen(outBounds);
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

	[Register("getBoundsInScreen", "(Landroid/graphics/Rect;)V", "GetGetBoundsInScreen_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetBoundsInScreen(Rect? outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getBoundsInScreen.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetChild_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetChild_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChild_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChild(index));
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

	[Register("getChild", "(I)Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", "GetGetChild_IHandler")]
	public unsafe virtual AccessibilityWindowInfoCompat? GetChild(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChild.(I)Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetRegionInScreen_Landroid_graphics_Region_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetRegionInScreen_Landroid_graphics_Region_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetRegionInScreen_Landroid_graphics_Region_(nint jnienv, nint native__this, nint native_outRegion)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityWindowInfoCompat? accessibilityWindowInfoCompat = Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Region outRegion = Java.Lang.Object.GetObject<Region>(native_outRegion, JniHandleOwnership.DoNotTransfer);
			accessibilityWindowInfoCompat.GetRegionInScreen(outRegion);
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

	[Register("getRegionInScreen", "(Landroid/graphics/Region;)V", "GetGetRegionInScreen_Landroid_graphics_Region_Handler")]
	public unsafe virtual void GetRegionInScreen(Region? outRegion)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outRegion?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getRegionInScreen.(Landroid/graphics/Region;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outRegion);
		}
	}

	private static Delegate GetGetRoot_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetRoot_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRoot_I(nint jnienv, nint native__this, int prefetchingStrategy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRoot(prefetchingStrategy));
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

	[Register("getRoot", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetRoot_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? GetRoot(int prefetchingStrategy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(prefetchingStrategy);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRoot.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("obtain", "()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", "")]
	public unsafe static AccessibilityWindowInfoCompat? Obtain()
	{
		return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("obtain", "(Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;)Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", "")]
	public unsafe static AccessibilityWindowInfoCompat? Obtain(AccessibilityWindowInfoCompat? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;)Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	[Obsolete]
	private static Delegate GetRecycleHandler()
	{
		return new global::_JniMarshal_PP_V(n_Recycle);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Recycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
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

	[Obsolete("deprecated")]
	[Register("recycle", "()V", "GetRecycleHandler")]
	public unsafe virtual void Recycle()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("recycle.()V", this, null);
	}

	private static Delegate GetUnwrapHandler()
	{
		return new global::_JniMarshal_PP_L(n_Unwrap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Unwrap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Unwrap());
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

	[Register("unwrap", "()Landroid/view/accessibility/AccessibilityWindowInfo;", "GetUnwrapHandler")]
	public unsafe virtual AccessibilityWindowInfo? Unwrap()
	{
		return Java.Lang.Object.GetObject<AccessibilityWindowInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("unwrap.()Landroid/view/accessibility/AccessibilityWindowInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
