using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewParent", DoNotGenerateAcw = true)]
internal class IViewParentInvoker : Java.Lang.Object, IViewParent, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_ViewParent = new XAPeerMembers("android/view/ViewParent", typeof(IViewParentInvoker));

	private static Delegate? cb_isLayoutDirectionResolved_IsLayoutDirectionResolved_Z;

	private static Delegate? cb_isLayoutRequested_IsLayoutRequested_Z;

	private static Delegate? cb_isTextAlignmentResolved_IsTextAlignmentResolved_Z;

	private static Delegate? cb_isTextDirectionResolved_IsTextDirectionResolved_Z;

	private static Delegate? cb_getLayoutDirection_GetLayoutDirection_I;

	private static Delegate? cb_getParent_GetParent_Landroid_view_ViewParent_;

	private static Delegate? cb_getParentForAccessibility_GetParentForAccessibility_Landroid_view_ViewParent_;

	private static Delegate? cb_getTextAlignment_GetTextAlignment_I;

	private static Delegate? cb_getTextDirection_GetTextDirection_I;

	private static Delegate? cb_bringChildToFront_BringChildToFront_Landroid_view_View__V;

	private static Delegate? cb_canResolveLayoutDirection_CanResolveLayoutDirection_Z;

	private static Delegate? cb_canResolveTextAlignment_CanResolveTextAlignment_Z;

	private static Delegate? cb_canResolveTextDirection_CanResolveTextDirection_Z;

	private static Delegate? cb_childDrawableStateChanged_ChildDrawableStateChanged_Landroid_view_View__V;

	private static Delegate? cb_childHasTransientStateChanged_ChildHasTransientStateChanged_Landroid_view_View_Z_V;

	private static Delegate? cb_clearChildFocus_ClearChildFocus_Landroid_view_View__V;

	private static Delegate? cb_createContextMenu_CreateContextMenu_Landroid_view_ContextMenu__V;

	private static Delegate? cb_focusableViewAvailable_FocusableViewAvailable_Landroid_view_View__V;

	private static Delegate? cb_focusSearch_FocusSearch_Landroid_view_View_I_Landroid_view_View_;

	private static Delegate? cb_getChildVisibleRect_GetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point__Z;

	private static Delegate? cb_invalidateChild_InvalidateChild_Landroid_view_View_Landroid_graphics_Rect__V;

	private static Delegate? cb_invalidateChildInParent_InvalidateChildInParent_arrayILandroid_graphics_Rect__Landroid_view_ViewParent_;

	private static Delegate? cb_keyboardNavigationClusterSearch_KeyboardNavigationClusterSearch_Landroid_view_View_I_Landroid_view_View_;

	private static Delegate? cb_notifySubtreeAccessibilityStateChanged_NotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_I_V;

	private static Delegate? cb_onNestedFling_OnNestedFling_Landroid_view_View_FFZ_Z;

	private static Delegate? cb_onNestedPreFling_OnNestedPreFling_Landroid_view_View_FF_Z;

	private static Delegate? cb_onNestedPrePerformAccessibilityAction_OnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle__Z;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayI_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIII_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_I_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_I_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View__V;

	private static Delegate? cb_recomputeViewAttributes_RecomputeViewAttributes_Landroid_view_View__V;

	private static Delegate? cb_requestChildFocus_RequestChildFocus_Landroid_view_View_Landroid_view_View__V;

	private static Delegate? cb_requestChildRectangleOnScreen_RequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_Z_Z;

	private static Delegate? cb_requestDisallowInterceptTouchEvent_RequestDisallowInterceptTouchEvent_Z_V;

	private static Delegate? cb_requestFitSystemWindows_RequestFitSystemWindows_V;

	private static Delegate? cb_requestLayout_RequestLayout_V;

	private static Delegate? cb_requestSendAccessibilityEvent_RequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_requestTransparentRegion_RequestTransparentRegion_Landroid_view_View__V;

	private static Delegate? cb_showContextMenuForChild_ShowContextMenuForChild_Landroid_view_View_FF_Z;

	private static Delegate? cb_showContextMenuForChild_ShowContextMenuForChild_Landroid_view_View__Z;

	private static Delegate? cb_startActionModeForChild_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_I_Landroid_view_ActionMode_;

	private static Delegate? cb_startActionModeForChild_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback__Landroid_view_ActionMode_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_ViewParent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_ViewParent.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_ViewParent.ManagedPeerType;

	public unsafe bool IsLayoutDirectionResolved => _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("isLayoutDirectionResolved.()Z", this, null);

	public unsafe bool IsLayoutRequested => _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("isLayoutRequested.()Z", this, null);

	public unsafe bool IsTextAlignmentResolved => _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("isTextAlignmentResolved.()Z", this, null);

	public unsafe bool IsTextDirectionResolved => _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("isTextDirectionResolved.()Z", this, null);

	public unsafe LayoutDirection LayoutDirection => (LayoutDirection)_members_android_view_ViewParent.InstanceMethods.InvokeAbstractInt32Method("getLayoutDirection.()I", this, null);

	public unsafe IViewParent? Parent => Java.Lang.Object.GetObject<IViewParent>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("getParent.()Landroid/view/ViewParent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IViewParent? ParentForAccessibility => Java.Lang.Object.GetObject<IViewParent>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("getParentForAccessibility.()Landroid/view/ViewParent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe TextAlignment TextAlignment => (TextAlignment)_members_android_view_ViewParent.InstanceMethods.InvokeAbstractInt32Method("getTextAlignment.()I", this, null);

	public unsafe TextDirection TextDirection => (TextDirection)_members_android_view_ViewParent.InstanceMethods.InvokeAbstractInt32Method("getTextDirection.()I", this, null);

	public IViewParentInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsLayoutDirectionResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsLayoutDirectionResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutDirectionResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutDirectionResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsLayoutRequestedHandler()
	{
		return new _JniMarshal_PP_B(n_IsLayoutRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutRequested ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTextAlignmentResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsTextAlignmentResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextAlignmentResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTextAlignmentResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTextDirectionResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsTextDirectionResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextDirectionResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTextDirectionResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLayoutDirectionHandler()
	{
		return new _JniMarshal_PP_I(n_GetLayoutDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLayoutDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection;
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
		return new _JniMarshal_PP_L(n_GetParent);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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

	private static Delegate GetGetParentForAccessibilityHandler()
	{
		return new _JniMarshal_PP_L(n_GetParentForAccessibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParentForAccessibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentForAccessibility);
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

	private static Delegate GetGetTextAlignmentHandler()
	{
		return new _JniMarshal_PP_I(n_GetTextAlignment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextAlignment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextAlignment;
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

	private static Delegate GetGetTextDirectionHandler()
	{
		return new _JniMarshal_PP_I(n_GetTextDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextDirection;
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

	private static Delegate GetBringChildToFront_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_BringChildToFront_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BringChildToFront_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewParent.BringChildToFront(child);
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

	public unsafe void BringChildToFront(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("bringChildToFront.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetCanResolveLayoutDirectionHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveLayoutDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveLayoutDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveLayoutDirection() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CanResolveLayoutDirection()
	{
		return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("canResolveLayoutDirection.()Z", this, null);
	}

	private static Delegate GetCanResolveTextAlignmentHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveTextAlignment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveTextAlignment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveTextAlignment() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CanResolveTextAlignment()
	{
		return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("canResolveTextAlignment.()Z", this, null);
	}

	private static Delegate GetCanResolveTextDirectionHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveTextDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveTextDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveTextDirection() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CanResolveTextDirection()
	{
		return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("canResolveTextDirection.()Z", this, null);
	}

	private static Delegate GetChildDrawableStateChanged_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_ChildDrawableStateChanged_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ChildDrawableStateChanged_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewParent.ChildDrawableStateChanged(child);
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

	public unsafe void ChildDrawableStateChanged(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("childDrawableStateChanged.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetChildHasTransientStateChanged_Landroid_view_View_ZHandler()
	{
		return new _JniMarshal_PPLB_V(n_ChildHasTransientStateChanged_Landroid_view_View_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ChildHasTransientStateChanged_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_child, sbyte native_hasTransientState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			bool hasTransientState = native_hasTransientState != 0;
			viewParent.ChildHasTransientStateChanged(child, hasTransientState);
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

	public unsafe void ChildHasTransientStateChanged(View child, bool hasTransientState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(hasTransientState ? ((sbyte)1) : ((sbyte)0));
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("childHasTransientStateChanged.(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetClearChildFocus_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_ClearChildFocus_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearChildFocus_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewParent.ClearChildFocus(child);
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

	public unsafe void ClearChildFocus(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("clearChildFocus.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetCreateContextMenu_Landroid_view_ContextMenu_Handler()
	{
		return new _JniMarshal_PPL_V(n_CreateContextMenu_Landroid_view_ContextMenu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateContextMenu_Landroid_view_ContextMenu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContextMenu menu = Java.Lang.Object.GetObject<IContextMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			viewParent.CreateContextMenu(menu);
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

	public unsafe void CreateContextMenu(IContextMenu? menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("createContextMenu.(Landroid/view/ContextMenu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetFocusableViewAvailable_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_FocusableViewAvailable_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FocusableViewAvailable_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			viewParent.FocusableViewAvailable(v);
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

	public unsafe void FocusableViewAvailable(View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("focusableViewAvailable.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetFocusSearch_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_FocusSearch_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FocusSearch_Landroid_view_View_I(nint jnienv, nint native__this, nint native_v, int native_direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewParent.FocusSearch(v, (FocusSearchDirection)native_direction));
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

	public unsafe View? FocusSearch(View? v, FocusSearchDirection direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)direction);
			return Java.Lang.Object.GetObject<View>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("focusSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetGetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_GetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point_(nint jnienv, nint native__this, nint native_child, nint native_r, nint native_offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect r = Java.Lang.Object.GetObject<Rect>(native_r, JniHandleOwnership.DoNotTransfer);
			Point offset = Java.Lang.Object.GetObject<Point>(native_offset, JniHandleOwnership.DoNotTransfer);
			return viewParent.GetChildVisibleRect(child, r, offset) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool GetChildVisibleRect(View? child, Rect? r, Point? offset)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(offset?.Handle ?? IntPtr.Zero);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("getChildVisibleRect.(Landroid/view/View;Landroid/graphics/Rect;Landroid/graphics/Point;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(r);
			GC.KeepAlive(offset);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	private static Delegate GetInvalidateChild_Landroid_view_View_Landroid_graphics_Rect_Handler()
	{
		return new _JniMarshal_PPLL_V(n_InvalidateChild_Landroid_view_View_Landroid_graphics_Rect_);
	}

	[ObsoletedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateChild_Landroid_view_View_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_child, nint native_r)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect r = Java.Lang.Object.GetObject<Rect>(native_r, JniHandleOwnership.DoNotTransfer);
			viewParent.InvalidateChild(child, r);
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

	public unsafe void InvalidateChild(View? child, Rect? r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("invalidateChild.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(r);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	private static Delegate GetInvalidateChildInParent_arrayILandroid_graphics_Rect_Handler()
	{
		return new _JniMarshal_PPLL_L(n_InvalidateChildInParent_arrayILandroid_graphics_Rect_);
	}

	[ObsoletedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvalidateChildInParent_arrayILandroid_graphics_Rect_(nint jnienv, nint native__this, nint native_location, nint native_r)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_location, JniHandleOwnership.DoNotTransfer, typeof(int));
			Rect r = Java.Lang.Object.GetObject<Rect>(native_r, JniHandleOwnership.DoNotTransfer);
			nint result = JNIEnv.ToLocalJniHandle(viewParent.InvalidateChildInParent(array, r));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_location);
			}
			return result;
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

	public unsafe IViewParent? InvalidateChildInParent(int[]? location, Rect? r)
	{
		nint num = JNIEnv.NewArray(location);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IViewParent>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("invalidateChildInParent.([ILandroid/graphics/Rect;)Landroid/view/ViewParent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (location != null)
			{
				JNIEnv.CopyArray(num, location);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(location);
			GC.KeepAlive(r);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetKeyboardNavigationClusterSearch_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_KeyboardNavigationClusterSearch_Landroid_view_View_I);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_KeyboardNavigationClusterSearch_Landroid_view_View_I(nint jnienv, nint native__this, nint native_currentCluster, int native_direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View currentCluster = Java.Lang.Object.GetObject<View>(native_currentCluster, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewParent.KeyboardNavigationClusterSearch(currentCluster, (FocusSearchDirection)native_direction));
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

	[SupportedOSPlatform("android26.0")]
	public unsafe View? KeyboardNavigationClusterSearch(View? currentCluster, FocusSearchDirection direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(currentCluster?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)direction);
			return Java.Lang.Object.GetObject<View>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("keyboardNavigationClusterSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(currentCluster);
		}
	}

	private static Delegate GetNotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLLI_V(n_NotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, nint native_source, int native_changeType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View source = Java.Lang.Object.GetObject<View>(native_source, JniHandleOwnership.DoNotTransfer);
			viewParent.NotifySubtreeAccessibilityStateChanged(child, source, (ContentChangeTypes)native_changeType);
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

	public unsafe void NotifySubtreeAccessibilityStateChanged(View child, View source, ContentChangeTypes changeType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)changeType);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("notifySubtreeAccessibilityStateChanged.(Landroid/view/View;Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(source);
		}
	}

	private static Delegate GetOnNestedFling_Landroid_view_View_FFZHandler()
	{
		return new _JniMarshal_PPLFFB_B(n_OnNestedFling_Landroid_view_View_FFZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnNestedFling_Landroid_view_View_FFZ(nint jnienv, nint native__this, nint native_target, float velocityX, float velocityY, sbyte native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			bool consumed = native_consumed != 0;
			return viewParent.OnNestedFling(target, velocityX, velocityY, consumed) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnNestedFling(View target, float velocityX, float velocityY, bool consumed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			ptr[3] = new JniArgumentValue(consumed ? ((sbyte)1) : ((sbyte)0));
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("onNestedFling.(Landroid/view/View;FFZ)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnNestedPreFling_Landroid_view_View_FFHandler()
	{
		return new _JniMarshal_PPLFF_B(n_OnNestedPreFling_Landroid_view_View_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnNestedPreFling_Landroid_view_View_FF(nint jnienv, nint native__this, nint native_target, float velocityX, float velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return viewParent.OnNestedPreFling(target, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnNestedPreFling(View target, float velocityX, float velocityY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("onNestedPreFling.(Landroid/view/View;FF)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	[SupportedOSPlatform("android22.0")]
	private static Delegate GetOnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLIL_B(n_OnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_);
	}

	[SupportedOSPlatform("android22.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_target, int native_action, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
			return viewParent.OnNestedPrePerformAccessibilityAction(target, (Android.Views.Accessibility.Action)native_action, arguments) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android22.0")]
	public unsafe bool OnNestedPrePerformAccessibilityAction(View target, Android.Views.Accessibility.Action action, Bundle? arguments)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)action);
			ptr[2] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("onNestedPrePerformAccessibilityAction.(Landroid/view/View;ILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
			GC.KeepAlive(arguments);
		}
	}

	private static Delegate GetOnNestedPreScroll_Landroid_view_View_IIarrayIHandler()
	{
		return new _JniMarshal_PPLIIL_V(n_OnNestedPreScroll_Landroid_view_View_IIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedPreScroll_Landroid_view_View_IIarrayI(nint jnienv, nint native__this, nint native_target, int dx, int dy, nint native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			viewParent.OnNestedPreScroll(target, dx, dy, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
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

	public unsafe void OnNestedPreScroll(View target, int dx, int dy, int[] consumed)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("onNestedPreScroll.(Landroid/view/View;II[I)V", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIHandler()
	{
		return new _JniMarshal_PPLIIII_V(n_OnNestedScroll_Landroid_view_View_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewParent.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);
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

	public unsafe void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("onNestedScroll.(Landroid/view/View;IIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLLI_V(n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, nint native_target, int native_nestedScrollAxes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewParent.OnNestedScrollAccepted(child, target, (ScrollAxis)native_nestedScrollAxes);
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

	public unsafe void OnNestedScrollAccepted(View child, View target, ScrollAxis nestedScrollAxes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)nestedScrollAxes);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("onNestedScrollAccepted.(Landroid/view/View;Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLLI_B(n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, nint native_target, int native_nestedScrollAxes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return viewParent.OnStartNestedScroll(child, target, (ScrollAxis)native_nestedScrollAxes) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnStartNestedScroll(View child, View target, ScrollAxis nestedScrollAxes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)nestedScrollAxes);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("onStartNestedScroll.(Landroid/view/View;Landroid/view/View;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStopNestedScroll_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnStopNestedScroll_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStopNestedScroll_Landroid_view_View_(nint jnienv, nint native__this, nint native_target)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewParent.OnStopNestedScroll(target);
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

	public unsafe void OnStopNestedScroll(View target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("onStopNestedScroll.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetRecomputeViewAttributes_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_RecomputeViewAttributes_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RecomputeViewAttributes_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewParent.RecomputeViewAttributes(child);
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

	public unsafe void RecomputeViewAttributes(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("recomputeViewAttributes.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetRequestChildFocus_Landroid_view_View_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPLL_V(n_RequestChildFocus_Landroid_view_View_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestChildFocus_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_child, nint native_focused)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			viewParent.RequestChildFocus(child, focused);
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

	public unsafe void RequestChildFocus(View? child, View? focused)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("requestChildFocus.(Landroid/view/View;Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(focused);
		}
	}

	private static Delegate GetRequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_ZHandler()
	{
		return new _JniMarshal_PPLLB_B(n_RequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_Z(nint jnienv, nint native__this, nint native_child, nint native_rectangle, sbyte native_immediate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect rectangle = Java.Lang.Object.GetObject<Rect>(native_rectangle, JniHandleOwnership.DoNotTransfer);
			bool immediate = native_immediate != 0;
			return viewParent.RequestChildRectangleOnScreen(child, rectangle, immediate) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool RequestChildRectangleOnScreen(View child, Rect? rectangle, bool immediate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(rectangle?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(immediate ? ((sbyte)1) : ((sbyte)0));
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("requestChildRectangleOnScreen.(Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(rectangle);
		}
	}

	private static Delegate GetRequestDisallowInterceptTouchEvent_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_RequestDisallowInterceptTouchEvent_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestDisallowInterceptTouchEvent_Z(nint jnienv, nint native__this, sbyte native_disallowIntercept)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool disallowIntercept = native_disallowIntercept != 0;
			viewParent.RequestDisallowInterceptTouchEvent(disallowIntercept);
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

	public unsafe void RequestDisallowInterceptTouchEvent(bool disallowIntercept)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(disallowIntercept ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("requestDisallowInterceptTouchEvent.(Z)V", this, ptr);
	}

	private static Delegate GetRequestFitSystemWindowsHandler()
	{
		return new _JniMarshal_PP_V(n_RequestFitSystemWindows);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestFitSystemWindows(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestFitSystemWindows();
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

	public unsafe void RequestFitSystemWindows()
	{
		_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("requestFitSystemWindows.()V", this, null);
	}

	private static Delegate GetRequestLayoutHandler()
	{
		return new _JniMarshal_PP_V(n_RequestLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestLayout();
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

	public unsafe void RequestLayout()
	{
		_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("requestLayout.()V", this, null);
	}

	private static Delegate GetRequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler()
	{
		return new _JniMarshal_PPLL_B(n_RequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_child, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return viewParent.RequestSendAccessibilityEvent(child, e) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool RequestSendAccessibilityEvent(View child, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("requestSendAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetRequestTransparentRegion_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_RequestTransparentRegion_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestTransparentRegion_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewParent.RequestTransparentRegion(child);
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

	public unsafe void RequestTransparentRegion(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewParent.InstanceMethods.InvokeAbstractVoidMethod("requestTransparentRegion.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetShowContextMenuForChild_Landroid_view_View_FFHandler()
	{
		return new _JniMarshal_PPLFF_B(n_ShowContextMenuForChild_Landroid_view_View_FF);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShowContextMenuForChild_Landroid_view_View_FF(nint jnienv, nint native__this, nint native_originalView, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			return viewParent.ShowContextMenuForChild(originalView, x, y) ? ((sbyte)1) : ((sbyte)0);
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
	public unsafe bool ShowContextMenuForChild(View? originalView, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("showContextMenuForChild.(Landroid/view/View;FF)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(originalView);
		}
	}

	private static Delegate GetShowContextMenuForChild_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_B(n_ShowContextMenuForChild_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShowContextMenuForChild_Landroid_view_View_(nint jnienv, nint native__this, nint native_originalView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			return viewParent.ShowContextMenuForChild(originalView) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool ShowContextMenuForChild(View? originalView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			return _members_android_view_ViewParent.InstanceMethods.InvokeAbstractBooleanMethod("showContextMenuForChild.(Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(originalView);
		}
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_IHandler()
	{
		return new _JniMarshal_PPLLI_L(n_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_I);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_I(nint jnienv, nint native__this, nint native_originalView, nint native__callback, int native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewParent.StartActionModeForChild(originalView, callback, (ActionModeType)native_type));
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

	[SupportedOSPlatform("android23.0")]
	public unsafe ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback, ActionModeType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[2] = new JniArgumentValue((int)type);
			return Java.Lang.Object.GetObject<ActionMode>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("startActionModeForChild.(Landroid/view/View;Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(originalView);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_Handler()
	{
		return new _JniMarshal_PPLL_L(n_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native_originalView, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewParent.StartActionModeForChild(originalView, callback));
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

	public unsafe ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode>(_members_android_view_ViewParent.InstanceMethods.InvokeAbstractObjectMethod("startActionModeForChild.(Landroid/view/View;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(originalView);
			GC.KeepAlive(callback);
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
