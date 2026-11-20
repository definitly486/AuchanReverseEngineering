using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views.Accessibility;
using Android.Window;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewParent", "", "Android.Views.IViewParentInvoker")]
public interface IViewParent : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewParent", typeof(IViewParent), isInterface: true);

	private static Delegate? cb_findOnBackInvokedDispatcherForChild_FindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View__Landroid_window_OnBackInvokedDispatcher_;

	private static Delegate? cb_onDescendantInvalidated_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View__V;

	bool IsLayoutDirectionResolved
	{
		[Register("isLayoutDirectionResolved", "()Z", "GetIsLayoutDirectionResolvedHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsLayoutRequested
	{
		[Register("isLayoutRequested", "()Z", "GetIsLayoutRequestedHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsTextAlignmentResolved
	{
		[Register("isTextAlignmentResolved", "()Z", "GetIsTextAlignmentResolvedHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsTextDirectionResolved
	{
		[Register("isTextDirectionResolved", "()Z", "GetIsTextDirectionResolvedHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	LayoutDirection LayoutDirection
	{
		[Register("getLayoutDirection", "()I", "GetGetLayoutDirectionHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IViewParent? Parent
	{
		[Register("getParent", "()Landroid/view/ViewParent;", "GetGetParentHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IViewParent? ParentForAccessibility
	{
		[Register("getParentForAccessibility", "()Landroid/view/ViewParent;", "GetGetParentForAccessibilityHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	TextAlignment TextAlignment
	{
		[Register("getTextAlignment", "()I", "GetGetTextAlignmentHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	TextDirection TextDirection
	{
		[Register("getTextDirection", "()I", "GetGetTextDirectionHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("bringChildToFront", "(Landroid/view/View;)V", "GetBringChildToFront_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void BringChildToFront(View? child);

	[Register("canResolveLayoutDirection", "()Z", "GetCanResolveLayoutDirectionHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool CanResolveLayoutDirection();

	[Register("canResolveTextAlignment", "()Z", "GetCanResolveTextAlignmentHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool CanResolveTextAlignment();

	[Register("canResolveTextDirection", "()Z", "GetCanResolveTextDirectionHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool CanResolveTextDirection();

	[Register("childDrawableStateChanged", "(Landroid/view/View;)V", "GetChildDrawableStateChanged_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ChildDrawableStateChanged(View child);

	[Register("childHasTransientStateChanged", "(Landroid/view/View;Z)V", "GetChildHasTransientStateChanged_Landroid_view_View_ZHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ChildHasTransientStateChanged(View child, bool hasTransientState);

	[Register("clearChildFocus", "(Landroid/view/View;)V", "GetClearChildFocus_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ClearChildFocus(View? child);

	[Register("createContextMenu", "(Landroid/view/ContextMenu;)V", "GetCreateContextMenu_Landroid_view_ContextMenu_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void CreateContextMenu(IContextMenu? menu);

	[Register("focusableViewAvailable", "(Landroid/view/View;)V", "GetFocusableViewAvailable_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void FocusableViewAvailable(View? v);

	[Register("focusSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetFocusSearch_Landroid_view_View_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	View? FocusSearch(View? v, FocusSearchDirection direction);

	[Register("getChildVisibleRect", "(Landroid/view/View;Landroid/graphics/Rect;Landroid/graphics/Point;)Z", "GetGetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetChildVisibleRect(View? child, Rect? r, Point? offset);

	[ObsoletedOSPlatform("android26.0")]
	[Register("invalidateChild", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetInvalidateChild_Landroid_view_View_Landroid_graphics_Rect_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void InvalidateChild(View? child, Rect? r);

	[ObsoletedOSPlatform("android26.0")]
	[Register("invalidateChildInParent", "([ILandroid/graphics/Rect;)Landroid/view/ViewParent;", "GetInvalidateChildInParent_arrayILandroid_graphics_Rect_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IViewParent? InvalidateChildInParent(int[]? location, Rect? r);

	[SupportedOSPlatform("android26.0")]
	[Register("keyboardNavigationClusterSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetKeyboardNavigationClusterSearch_Landroid_view_View_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
	View? KeyboardNavigationClusterSearch(View? currentCluster, FocusSearchDirection direction);

	[Register("notifySubtreeAccessibilityStateChanged", "(Landroid/view/View;Landroid/view/View;I)V", "GetNotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void NotifySubtreeAccessibilityStateChanged(View child, View source, ContentChangeTypes changeType);

	[Register("onNestedFling", "(Landroid/view/View;FFZ)Z", "GetOnNestedFling_Landroid_view_View_FFZHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnNestedFling(View target, float velocityX, float velocityY, bool consumed);

	[Register("onNestedPreFling", "(Landroid/view/View;FF)Z", "GetOnNestedPreFling_Landroid_view_View_FFHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnNestedPreFling(View target, float velocityX, float velocityY);

	[SupportedOSPlatform("android22.0")]
	[Register("onNestedPrePerformAccessibilityAction", "(Landroid/view/View;ILandroid/os/Bundle;)Z", "GetOnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 22)]
	bool OnNestedPrePerformAccessibilityAction(View target, Android.Views.Accessibility.Action action, Bundle? arguments);

	[Register("onNestedPreScroll", "(Landroid/view/View;II[I)V", "GetOnNestedPreScroll_Landroid_view_View_IIarrayIHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnNestedPreScroll(View target, int dx, int dy, int[] consumed);

	[Register("onNestedScroll", "(Landroid/view/View;IIII)V", "GetOnNestedScroll_Landroid_view_View_IIIIHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed);

	[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;I)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnNestedScrollAccepted(View child, View target, ScrollAxis nestedScrollAxes);

	[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;I)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnStartNestedScroll(View child, View target, ScrollAxis nestedScrollAxes);

	[Register("onStopNestedScroll", "(Landroid/view/View;)V", "GetOnStopNestedScroll_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnStopNestedScroll(View target);

	[Register("recomputeViewAttributes", "(Landroid/view/View;)V", "GetRecomputeViewAttributes_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RecomputeViewAttributes(View? child);

	[Register("requestChildFocus", "(Landroid/view/View;Landroid/view/View;)V", "GetRequestChildFocus_Landroid_view_View_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RequestChildFocus(View? child, View? focused);

	[Register("requestChildRectangleOnScreen", "(Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetRequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_ZHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool RequestChildRectangleOnScreen(View child, Rect? rectangle, bool immediate);

	[Register("requestDisallowInterceptTouchEvent", "(Z)V", "GetRequestDisallowInterceptTouchEvent_ZHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RequestDisallowInterceptTouchEvent(bool disallowIntercept);

	[Register("requestFitSystemWindows", "()V", "GetRequestFitSystemWindowsHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RequestFitSystemWindows();

	[Register("requestLayout", "()V", "GetRequestLayoutHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RequestLayout();

	[Register("requestSendAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", "GetRequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool RequestSendAccessibilityEvent(View child, AccessibilityEvent? e);

	[Register("requestTransparentRegion", "(Landroid/view/View;)V", "GetRequestTransparentRegion_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RequestTransparentRegion(View? child);

	[SupportedOSPlatform("android24.0")]
	[Register("showContextMenuForChild", "(Landroid/view/View;FF)Z", "GetShowContextMenuForChild_Landroid_view_View_FFHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	bool ShowContextMenuForChild(View? originalView, float x, float y);

	[Register("showContextMenuForChild", "(Landroid/view/View;)Z", "GetShowContextMenuForChild_Landroid_view_View_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool ShowContextMenuForChild(View? originalView);

	[SupportedOSPlatform("android23.0")]
	[Register("startActionModeForChild", "(Landroid/view/View;Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", "GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_IHandler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 23)]
	ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback, ActionModeType type);

	[Register("startActionModeForChild", "(Landroid/view/View;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", "GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_Handler:Android.Views.IViewParentInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback);

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetFindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPLL_L(n_FindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View_);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_child, nint native_requester)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IViewParent? viewParent = Java.Lang.Object.GetObject<IViewParent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View requester = Java.Lang.Object.GetObject<View>(native_requester, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewParent.FindOnBackInvokedDispatcherForChild(child, requester));
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

	[SupportedOSPlatform("android33.0")]
	[Register("findOnBackInvokedDispatcherForChild", "(Landroid/view/View;Landroid/view/View;)Landroid/window/OnBackInvokedDispatcher;", "GetFindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View_Handler:Android.Views.IViewParent, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 33)]
	unsafe IOnBackInvokedDispatcher? FindOnBackInvokedDispatcherForChild(View child, View requester)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requester?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IOnBackInvokedDispatcher>(_members.InstanceMethods.InvokeVirtualObjectMethod("findOnBackInvokedDispatcherForChild.(Landroid/view/View;Landroid/view/View;)Landroid/window/OnBackInvokedDispatcher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(requester);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetOnDescendantInvalidated_Landroid_view_View_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPLL_V(n_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_child, nint native_target)
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
			viewParent.OnDescendantInvalidated(child, target);
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

	[SupportedOSPlatform("android26.0")]
	[Register("onDescendantInvalidated", "(Landroid/view/View;Landroid/view/View;)V", "GetOnDescendantInvalidated_Landroid_view_View_Landroid_view_View_Handler:Android.Views.IViewParent, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
	unsafe void OnDescendantInvalidated(View child, View target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDescendantInvalidated.(Landroid/view/View;Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}
}
