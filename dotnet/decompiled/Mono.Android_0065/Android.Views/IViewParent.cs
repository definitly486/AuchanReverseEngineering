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

	bool IsLayoutDirectionResolved { get; }

	bool IsLayoutRequested { get; }

	bool IsTextAlignmentResolved { get; }

	bool IsTextDirectionResolved { get; }

	LayoutDirection LayoutDirection { get; }

	IViewParent? Parent { get; }

	IViewParent? ParentForAccessibility { get; }

	TextAlignment TextAlignment { get; }

	TextDirection TextDirection { get; }

	void BringChildToFront(View? child);

	bool CanResolveLayoutDirection();

	bool CanResolveTextAlignment();

	bool CanResolveTextDirection();

	void ChildDrawableStateChanged(View child);

	void ChildHasTransientStateChanged(View child, bool hasTransientState);

	void ClearChildFocus(View? child);

	void CreateContextMenu(IContextMenu? menu);

	void FocusableViewAvailable(View? v);

	View? FocusSearch(View? v, FocusSearchDirection direction);

	bool GetChildVisibleRect(View? child, Rect? r, Point? offset);

	[ObsoletedOSPlatform("android26.0")]
	void InvalidateChild(View? child, Rect? r);

	[ObsoletedOSPlatform("android26.0")]
	IViewParent? InvalidateChildInParent(int[]? location, Rect? r);

	[SupportedOSPlatform("android26.0")]
	View? KeyboardNavigationClusterSearch(View? currentCluster, FocusSearchDirection direction);

	void NotifySubtreeAccessibilityStateChanged(View child, View source, ContentChangeTypes changeType);

	bool OnNestedFling(View target, float velocityX, float velocityY, bool consumed);

	bool OnNestedPreFling(View target, float velocityX, float velocityY);

	[SupportedOSPlatform("android22.0")]
	bool OnNestedPrePerformAccessibilityAction(View target, Android.Views.Accessibility.Action action, Bundle? arguments);

	void OnNestedPreScroll(View target, int dx, int dy, int[] consumed);

	void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed);

	void OnNestedScrollAccepted(View child, View target, ScrollAxis nestedScrollAxes);

	bool OnStartNestedScroll(View child, View target, ScrollAxis nestedScrollAxes);

	void OnStopNestedScroll(View target);

	void RecomputeViewAttributes(View? child);

	void RequestChildFocus(View? child, View? focused);

	bool RequestChildRectangleOnScreen(View child, Rect? rectangle, bool immediate);

	void RequestDisallowInterceptTouchEvent(bool disallowIntercept);

	void RequestFitSystemWindows();

	void RequestLayout();

	bool RequestSendAccessibilityEvent(View child, AccessibilityEvent? e);

	void RequestTransparentRegion(View? child);

	[SupportedOSPlatform("android24.0")]
	bool ShowContextMenuForChild(View? originalView, float x, float y);

	bool ShowContextMenuForChild(View? originalView);

	[SupportedOSPlatform("android23.0")]
	ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback, ActionModeType type);

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
