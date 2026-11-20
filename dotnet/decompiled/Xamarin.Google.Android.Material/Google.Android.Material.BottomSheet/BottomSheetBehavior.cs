using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Activity;
using AndroidX.CoordinatorLayout.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.BottomSheet;

[Register("com/google/android/material/bottomsheet/BottomSheetBehavior", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "V extends android.view.View" })]
public class BottomSheetBehavior : CoordinatorLayout.Behavior, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback", DoNotGenerateAcw = true)]
	public abstract class BottomSheetCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback", typeof(BottomSheetCallback));

		private static Delegate? cb_onSlide_OnSlide_Landroid_view_View_F_V;

		private static Delegate? cb_onStateChanged_OnStateChanged_Landroid_view_View_I_V;

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

		protected BottomSheetCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BottomSheetCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSlide_Landroid_view_View_F(nint jnienv, nint native__this, nint native_bottomSheet, float newState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				BottomSheetCallback? bottomSheetCallback = Java.Lang.Object.GetObject<BottomSheetCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View bottomSheet = Java.Lang.Object.GetObject<View>(native_bottomSheet, JniHandleOwnership.DoNotTransfer);
				bottomSheetCallback.OnSlide(bottomSheet, newState);
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

		[Register("onSlide", "(Landroid/view/View;F)V", "GetOnSlide_Landroid_view_View_FHandler")]
		public abstract void OnSlide(View bottomSheet, float newState);

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStateChanged_Landroid_view_View_I(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				BottomSheetCallback? bottomSheetCallback = Java.Lang.Object.GetObject<BottomSheetCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p2 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
				bottomSheetCallback.OnStateChanged(p2, p1);
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

		[Register("onStateChanged", "(Landroid/view/View;I)V", "GetOnStateChanged_Landroid_view_View_IHandler")]
		public abstract void OnStateChanged(View p0, int p1);

		[UnmanagedCallersOnly]
		private static void n_OnSlide_Landroid_view_View_F_mm_wrapper(nint jnienv, nint native__this, nint native_bottomSheet, float newState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnSlide_Landroid_view_View_F(jnienv, native__this, native_bottomSheet, newState);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnStateChanged_Landroid_view_View_I_mm_wrapper(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnStateChanged_Landroid_view_View_I(jnienv, native__this, native_p0, p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("com/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback", DoNotGenerateAcw = true)]
	internal class BottomSheetCallbackInvoker : BottomSheetCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback", typeof(BottomSheetCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public BottomSheetCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onSlide", "(Landroid/view/View;F)V", "GetOnSlide_Landroid_view_View_FHandler")]
		public unsafe override void OnSlide(View bottomSheet, float newState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bottomSheet?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newState);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onSlide.(Landroid/view/View;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bottomSheet);
			}
		}

		[Register("onStateChanged", "(Landroid/view/View;I)V", "GetOnStateChanged_Landroid_view_View_IHandler")]
		public unsafe override void OnStateChanged(View p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onStateChanged.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomsheet/BottomSheetBehavior", typeof(BottomSheetBehavior));

	private static Delegate? cb_isDraggable_IsDraggable_Z;

	private static Delegate? cb_setDraggable_SetDraggable_Z_V;

	private static Delegate? cb_getExpandedOffset_GetExpandedOffset_I;

	private static Delegate? cb_setExpandedOffset_SetExpandedOffset_I_V;

	private static Delegate? cb_isFitToContents_IsFitToContents_Z;

	private static Delegate? cb_setFitToContents_SetFitToContents_Z_V;

	private static Delegate? cb_isGestureInsetBottomIgnored_IsGestureInsetBottomIgnored_Z;

	private static Delegate? cb_setGestureInsetBottomIgnored_SetGestureInsetBottomIgnored_Z_V;

	private static Delegate? cb_getHalfExpandedRatio_GetHalfExpandedRatio_F;

	private static Delegate? cb_setHalfExpandedRatio_SetHalfExpandedRatio_F_V;

	private static Delegate? cb_getHideFriction_GetHideFriction_F;

	private static Delegate? cb_setHideFriction_SetHideFriction_F_V;

	private static Delegate? cb_isHideable_IsHideable_Z;

	private static Delegate? cb_setHideable_SetHideable_Z_V;

	private static Delegate? cb_isHideableWhenDragging_IsHideableWhenDragging_Z;

	private static Delegate? cb_isNestedScrollingCheckEnabled_IsNestedScrollingCheckEnabled_Z;

	private static Delegate? cb_getLastStableState_GetLastStableState_I;

	private static Delegate? cb_getMaxHeight_GetMaxHeight_I;

	private static Delegate? cb_setMaxHeight_SetMaxHeight_I_V;

	private static Delegate? cb_getMaxWidth_GetMaxWidth_I;

	private static Delegate? cb_setMaxWidth_SetMaxWidth_I_V;

	private static Delegate? cb_getPeekHeight_GetPeekHeight_I;

	private static Delegate? cb_setPeekHeight_SetPeekHeight_I_V;

	private static Delegate? cb_getSaveFlags_GetSaveFlags_I;

	private static Delegate? cb_setSaveFlags_SetSaveFlags_I_V;

	private static Delegate? cb_isShouldRemoveExpandedCorners_IsShouldRemoveExpandedCorners_Z;

	private static Delegate? cb_setShouldRemoveExpandedCorners_SetShouldRemoveExpandedCorners_Z_V;

	private static Delegate? cb_getSignificantVelocityThreshold_GetSignificantVelocityThreshold_I;

	private static Delegate? cb_setSignificantVelocityThreshold_SetSignificantVelocityThreshold_I_V;

	private static Delegate? cb_getSkipCollapsed_GetSkipCollapsed_Z;

	private static Delegate? cb_setSkipCollapsed_SetSkipCollapsed_Z_V;

	private static Delegate? cb_getState_GetState_I;

	private static Delegate? cb_setState_SetState_I_V;

	private static Delegate? cb_addBottomSheetCallback_AddBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback__V;

	private static Delegate? cb_calculateSlideOffset_CalculateSlideOffset_F;

	private static Delegate? cb_cancelBackProgress_CancelBackProgress_V;

	private static Delegate? cb_disableShapeAnimations_DisableShapeAnimations_V;

	private static Delegate? cb_handleBackInvoked_HandleBackInvoked_V;

	private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onLayoutChild_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I_Z;

	private static Delegate? cb_onMeasureChild_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII_Z;

	private static Delegate? cb_onNestedPreFling_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF_Z;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View__Landroid_os_Parcelable_;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I_V;

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_removeBottomSheetCallback_RemoveBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback__V;

	private static Delegate? cb_setBottomSheetCallback_SetBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback__V;

	private static Delegate? cb_setHideableInternal_SetHideableInternal_Z_V;

	private static Delegate? cb_setUpdateImportantForAccessibilityOnSiblings_SetUpdateImportantForAccessibilityOnSiblings_Z_V;

	private static Delegate? cb_shouldExpandOnUpwardDrag_ShouldExpandOnUpwardDrag_JF_Z;

	private static Delegate? cb_shouldSkipHalfExpandedStateWhenDragging_ShouldSkipHalfExpandedStateWhenDragging_Z;

	private static Delegate? cb_shouldSkipSmoothAnimation_ShouldSkipSmoothAnimation_Z;

	private static Delegate? cb_startBackProgress_StartBackProgress_Landroidx_activity_BackEventCompat__V;

	private static Delegate? cb_updateBackProgress_UpdateBackProgress_Landroidx_activity_BackEventCompat__V;

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

	public unsafe virtual bool Draggable
	{
		[Register("isDraggable", "()Z", "GetIsDraggableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDraggable.()Z", this, null);
		}
		[Register("setDraggable", "(Z)V", "GetSetDraggable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDraggable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ExpandedOffset
	{
		[Register("getExpandedOffset", "()I", "GetGetExpandedOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getExpandedOffset.()I", this, null);
		}
		[Register("setExpandedOffset", "(I)V", "GetSetExpandedOffset_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpandedOffset.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool FitToContents
	{
		[Register("isFitToContents", "()Z", "GetIsFitToContentsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFitToContents.()Z", this, null);
		}
		[Register("setFitToContents", "(Z)V", "GetSetFitToContents_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFitToContents.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool GestureInsetBottomIgnored
	{
		[Register("isGestureInsetBottomIgnored", "()Z", "GetIsGestureInsetBottomIgnoredHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isGestureInsetBottomIgnored.()Z", this, null);
		}
		[Register("setGestureInsetBottomIgnored", "(Z)V", "GetSetGestureInsetBottomIgnored_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGestureInsetBottomIgnored.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float HalfExpandedRatio
	{
		[Register("getHalfExpandedRatio", "()F", "GetGetHalfExpandedRatioHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getHalfExpandedRatio.()F", this, null);
		}
		[Register("setHalfExpandedRatio", "(F)V", "GetSetHalfExpandedRatio_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHalfExpandedRatio.(F)V", this, ptr);
		}
	}

	public unsafe virtual float HideFriction
	{
		[Register("getHideFriction", "()F", "GetGetHideFrictionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getHideFriction.()F", this, null);
		}
		[Register("setHideFriction", "(F)V", "GetSetHideFriction_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHideFriction.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool Hideable
	{
		[Register("isHideable", "()Z", "GetIsHideableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHideable.()Z", this, null);
		}
		[Register("setHideable", "(Z)V", "GetSetHideable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHideable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool IsHideableWhenDragging
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isHideableWhenDragging", "()Z", "GetIsHideableWhenDraggingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHideableWhenDragging.()Z", this, null);
		}
	}

	public unsafe virtual bool IsNestedScrollingCheckEnabled
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isNestedScrollingCheckEnabled", "()Z", "GetIsNestedScrollingCheckEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isNestedScrollingCheckEnabled.()Z", this, null);
		}
	}

	public unsafe virtual int LastStableState
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getLastStableState", "()I", "GetGetLastStableStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLastStableState.()I", this, null);
		}
	}

	public unsafe virtual int MaxHeight
	{
		[Register("getMaxHeight", "()I", "GetGetMaxHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxHeight.()I", this, null);
		}
		[Register("setMaxHeight", "(I)V", "GetSetMaxHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxWidth
	{
		[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
		}
		[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int PeekHeight
	{
		[Register("getPeekHeight", "()I", "GetGetPeekHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPeekHeight.()I", this, null);
		}
		[Register("setPeekHeight", "(I)V", "GetSetPeekHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPeekHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int SaveFlags
	{
		[Register("getSaveFlags", "()I", "GetGetSaveFlagsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSaveFlags.()I", this, null);
		}
		[Register("setSaveFlags", "(I)V", "GetSetSaveFlags_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSaveFlags.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool ShouldRemoveExpandedCorners
	{
		[Register("isShouldRemoveExpandedCorners", "()Z", "GetIsShouldRemoveExpandedCornersHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShouldRemoveExpandedCorners.()Z", this, null);
		}
		[Register("setShouldRemoveExpandedCorners", "(Z)V", "GetSetShouldRemoveExpandedCorners_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShouldRemoveExpandedCorners.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int SignificantVelocityThreshold
	{
		[Register("getSignificantVelocityThreshold", "()I", "GetGetSignificantVelocityThresholdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSignificantVelocityThreshold.()I", this, null);
		}
		[Register("setSignificantVelocityThreshold", "(I)V", "GetSetSignificantVelocityThreshold_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSignificantVelocityThreshold.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool SkipCollapsed
	{
		[Register("getSkipCollapsed", "()Z", "GetGetSkipCollapsedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getSkipCollapsed.()Z", this, null);
		}
		[Register("setSkipCollapsed", "(Z)V", "GetSetSkipCollapsed_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSkipCollapsed.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int State
	{
		[Register("getState", "()I", "GetGetStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getState.()I", this, null);
		}
		[Register("setState", "(I)V", "GetSetState_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setState.(I)V", this, ptr);
		}
	}

	protected BottomSheetBehavior(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BottomSheetBehavior()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe BottomSheetBehavior(Context context, IAttributeSet? attrs)
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

	private static Delegate GetIsDraggableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDraggable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDraggable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDraggable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDraggable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDraggable_Z(nint jnienv, nint native__this, sbyte native_draggable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool draggable = native_draggable != 0;
			bottomSheetBehavior.Draggable = draggable;
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

	private static Delegate GetGetExpandedOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetExpandedOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetExpandedOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedOffset;
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

	private static Delegate GetSetExpandedOffset_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetExpandedOffset_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExpandedOffset_I(nint jnienv, nint native__this, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedOffset = offset;
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

	private static Delegate GetIsFitToContentsHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFitToContents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFitToContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FitToContents ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetFitToContents_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetFitToContents_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFitToContents_Z(nint jnienv, nint native__this, sbyte native_fitToContents)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool fitToContents = native_fitToContents != 0;
			bottomSheetBehavior.FitToContents = fitToContents;
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

	private static Delegate GetIsGestureInsetBottomIgnoredHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsGestureInsetBottomIgnored);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsGestureInsetBottomIgnored(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GestureInsetBottomIgnored ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetGestureInsetBottomIgnored_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetGestureInsetBottomIgnored_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGestureInsetBottomIgnored_Z(nint jnienv, nint native__this, sbyte native_gestureInsetBottomIgnored)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool gestureInsetBottomIgnored = native_gestureInsetBottomIgnored != 0;
			bottomSheetBehavior.GestureInsetBottomIgnored = gestureInsetBottomIgnored;
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

	private static Delegate GetGetHalfExpandedRatioHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetHalfExpandedRatio);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetHalfExpandedRatio(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HalfExpandedRatio;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHalfExpandedRatio_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetHalfExpandedRatio_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHalfExpandedRatio_F(nint jnienv, nint native__this, float ratio)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HalfExpandedRatio = ratio;
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

	private static Delegate GetGetHideFrictionHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetHideFriction);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetHideFriction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideFriction;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHideFriction_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetHideFriction_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideFriction_F(nint jnienv, nint native__this, float hideFriction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideFriction = hideFriction;
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

	private static Delegate GetIsHideableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHideable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHideable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hideable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHideable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHideable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideable_Z(nint jnienv, nint native__this, sbyte native_hideable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hideable = native_hideable != 0;
			bottomSheetBehavior.Hideable = hideable;
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

	private static Delegate GetIsHideableWhenDraggingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHideableWhenDragging);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHideableWhenDragging(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHideableWhenDragging ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsNestedScrollingCheckEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsNestedScrollingCheckEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsNestedScrollingCheckEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsNestedScrollingCheckEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLastStableStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLastStableState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLastStableState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastStableState;
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

	private static Delegate GetGetMaxHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight;
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

	private static Delegate GetSetMaxHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxHeight_I(nint jnienv, nint native__this, int maxHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight = maxHeight;
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

	private static Delegate GetGetMaxWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
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

	private static Delegate GetSetMaxWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidth_I(nint jnienv, nint native__this, int maxWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = maxWidth;
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

	private static Delegate GetGetPeekHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetPeekHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPeekHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekHeight;
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

	private static Delegate GetSetPeekHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPeekHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPeekHeight_I(nint jnienv, nint native__this, int peekHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekHeight = peekHeight;
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

	private static Delegate GetGetSaveFlagsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSaveFlags);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSaveFlags(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveFlags;
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

	private static Delegate GetSetSaveFlags_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSaveFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSaveFlags_I(nint jnienv, nint native__this, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveFlags = flags;
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

	private static Delegate GetIsShouldRemoveExpandedCornersHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShouldRemoveExpandedCorners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShouldRemoveExpandedCorners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldRemoveExpandedCorners ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetShouldRemoveExpandedCorners_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShouldRemoveExpandedCorners_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShouldRemoveExpandedCorners_Z(nint jnienv, nint native__this, sbyte native_shouldRemoveExpandedCorners)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shouldRemoveExpandedCorners = native_shouldRemoveExpandedCorners != 0;
			bottomSheetBehavior.ShouldRemoveExpandedCorners = shouldRemoveExpandedCorners;
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

	private static Delegate GetGetSignificantVelocityThresholdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSignificantVelocityThreshold);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSignificantVelocityThreshold(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SignificantVelocityThreshold;
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

	private static Delegate GetSetSignificantVelocityThreshold_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSignificantVelocityThreshold_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSignificantVelocityThreshold_I(nint jnienv, nint native__this, int significantVelocityThreshold)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SignificantVelocityThreshold = significantVelocityThreshold;
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

	private static Delegate GetGetSkipCollapsedHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetSkipCollapsed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetSkipCollapsed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SkipCollapsed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSkipCollapsed_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSkipCollapsed_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSkipCollapsed_Z(nint jnienv, nint native__this, sbyte native_skipCollapsed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool skipCollapsed = native_skipCollapsed != 0;
			bottomSheetBehavior.SkipCollapsed = skipCollapsed;
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

	private static Delegate GetGetStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).State;
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

	private static Delegate GetSetState_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetState_I(nint jnienv, nint native__this, int state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).State = state;
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

	private static Delegate GetAddBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BottomSheetCallback callback = Java.Lang.Object.GetObject<BottomSheetCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.AddBottomSheetCallback(callback);
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

	[Register("addBottomSheetCallback", "(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", "GetAddBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler")]
	public unsafe virtual void AddBottomSheetCallback(BottomSheetCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addBottomSheetCallback.(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetCalculateSlideOffsetHandler()
	{
		return new global::_JniMarshal_PP_F(n_CalculateSlideOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_CalculateSlideOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateSlideOffset();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("calculateSlideOffset", "()F", "GetCalculateSlideOffsetHandler")]
	public unsafe virtual float CalculateSlideOffset()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("calculateSlideOffset.()F", this, null);
	}

	private static Delegate GetCancelBackProgressHandler()
	{
		return new global::_JniMarshal_PP_V(n_CancelBackProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CancelBackProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelBackProgress();
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

	[Register("cancelBackProgress", "()V", "GetCancelBackProgressHandler")]
	public unsafe virtual void CancelBackProgress()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cancelBackProgress.()V", this, null);
	}

	private static Delegate GetDisableShapeAnimationsHandler()
	{
		return new global::_JniMarshal_PP_V(n_DisableShapeAnimations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DisableShapeAnimations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableShapeAnimations();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("disableShapeAnimations", "()V", "GetDisableShapeAnimationsHandler")]
	public unsafe virtual void DisableShapeAnimations()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("disableShapeAnimations.()V", this, null);
	}

	[Register("from", "(Landroid/view/View;)Lcom/google/android/material/bottomsheet/BottomSheetBehavior;", "")]
	[JavaTypeParameters(new string[] { "V extends android.view.View" })]
	public unsafe static BottomSheetBehavior From(Java.Lang.Object view)
	{
		nint num = JNIEnv.ToLocalJniHandle(view);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/view/View;)Lcom/google/android/material/bottomsheet/BottomSheetBehavior;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetHandleBackInvokedHandler()
	{
		return new global::_JniMarshal_PP_V(n_HandleBackInvoked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_HandleBackInvoked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleBackInvoked();
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

	[Register("handleBackInvoked", "()V", "GetHandleBackInvokedHandler")]
	public unsafe virtual void HandleBackInvoked()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("handleBackInvoked.()V", this, null);
	}

	private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
	{
		return new global::_JniMarshal_PPLLL_B(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnInterceptTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool OnInterceptTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLLI_B(n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I(nint jnienv, nint native__this, nint native_parent, nint native_child, int layoutDirection)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnLayoutChild(parent, child, layoutDirection) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onLayoutChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", "GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler")]
	public unsafe override bool OnLayoutChild(CoordinatorLayout parent, Java.Lang.Object child, int layoutDirection)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(layoutDirection);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onLayoutChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler()
	{
		return new global::_JniMarshal_PPLLIIII_B(n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_parent, nint native_child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnMeasureChild(parent, child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onMeasureChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", "GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler")]
	public unsafe override bool OnMeasureChild(CoordinatorLayout parent, Java.Lang.Object child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(parentWidthMeasureSpec);
			ptr[3] = new JniArgumentValue(widthUsed);
			ptr[4] = new JniArgumentValue(parentHeightMeasureSpec);
			ptr[5] = new JniArgumentValue(heightUsed);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMeasureChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler()
	{
		return new global::_JniMarshal_PPLLLFF_B(n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, float velocityX, float velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnNestedPreFling(coordinatorLayout, child, target, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onNestedPreFling", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", "GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler")]
	public unsafe override bool OnNestedPreFling(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, float velocityX, float velocityY)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(velocityX);
			ptr[4] = new JniArgumentValue(velocityY);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedPreFling.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(coordinatorLayout);
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler()
	{
		return new global::_JniMarshal_PPLLLIILI_V(n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dx, int dy, nint native_consumed, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			bottomSheetBehavior.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, array, type);
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

	[Register("onNestedPreScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler")]
	public unsafe override void OnNestedPreScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dx, int dy, int[] consumed, int type)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		nint num2 = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(dx);
			ptr[4] = new JniArgumentValue(dy);
			ptr[5] = new JniArgumentValue(num2);
			ptr[6] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (consumed != null)
			{
				JNIEnv.CopyArray(num2, consumed);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(coordinatorLayout);
			GC.KeepAlive(child);
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler()
	{
		return new global::_JniMarshal_PPLLLIIIIIL_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, nint native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			bottomSheetBehavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
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

	[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler")]
	public unsafe override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[] consumed)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		nint num2 = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(dxConsumed);
			ptr[4] = new JniArgumentValue(dyConsumed);
			ptr[5] = new JniArgumentValue(dxUnconsumed);
			ptr[6] = new JniArgumentValue(dyUnconsumed);
			ptr[7] = new JniArgumentValue(type);
			ptr[8] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (consumed != null)
			{
				JNIEnv.CopyArray(num2, consumed);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(coordinatorLayout);
			GC.KeepAlive(child);
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.OnRestoreInstanceState(parent, child, state);
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

	[Register("onRestoreInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler")]
	public unsafe override void OnRestoreInstanceState(CoordinatorLayout parent, Java.Lang.Object child, IParcelable state)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bottomSheetBehavior.OnSaveInstanceState(parent, child));
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

	[Register("onSaveInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", "GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
	public unsafe override IParcelable OnSaveInstanceState(CoordinatorLayout parent, Java.Lang.Object child)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLLLLII_B(n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_directTargetChild, nint native_target, int axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes, type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onStartNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int axes, int type)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(axes);
			ptr[5] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(coordinatorLayout);
			GC.KeepAlive(child);
			GC.KeepAlive(directTargetChild);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLLLI_V(n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.OnStopNestedScroll(coordinatorLayout, child, target, type);
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

	[Register("onStopNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler")]
	public unsafe override void OnStopNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int type)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(coordinatorLayout);
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
	{
		return new global::_JniMarshal_PPLLL_B(n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return bottomSheetBehavior.OnTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool OnTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
	{
		nint num = JNIEnv.ToLocalJniHandle(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetRemoveBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BottomSheetCallback callback = Java.Lang.Object.GetObject<BottomSheetCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.RemoveBottomSheetCallback(callback);
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

	[Register("removeBottomSheetCallback", "(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", "GetRemoveBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler")]
	public unsafe virtual void RemoveBottomSheetCallback(BottomSheetCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeBottomSheetCallback.(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Obsolete]
	private static Delegate GetSetBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BottomSheetCallback bottomSheetCallback = Java.Lang.Object.GetObject<BottomSheetCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.SetBottomSheetCallback(bottomSheetCallback);
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
	[Register("setBottomSheetCallback", "(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", "GetSetBottomSheetCallback_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_BottomSheetCallback_Handler")]
	public unsafe virtual void SetBottomSheetCallback(BottomSheetCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBottomSheetCallback.(Lcom/google/android/material/bottomsheet/BottomSheetBehavior$BottomSheetCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetHideableInternal_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHideableInternal_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideableInternal_Z(nint jnienv, nint native__this, sbyte native_hideable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hideableInternal = native_hideable != 0;
			bottomSheetBehavior.SetHideableInternal(hideableInternal);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setHideableInternal", "(Z)V", "GetSetHideableInternal_ZHandler")]
	public unsafe virtual void SetHideableInternal(bool hideable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(hideable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHideableInternal.(Z)V", this, ptr);
	}

	[Register("setPeekHeight", "(IZ)V", "")]
	public unsafe void SetPeekHeight(int peekHeight, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(peekHeight);
		ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPeekHeight.(IZ)V", this, ptr);
	}

	private static Delegate GetSetUpdateImportantForAccessibilityOnSiblings_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUpdateImportantForAccessibilityOnSiblings_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUpdateImportantForAccessibilityOnSiblings_Z(nint jnienv, nint native__this, sbyte native_updateImportantForAccessibilityOnSiblings)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool updateImportantForAccessibilityOnSiblings = native_updateImportantForAccessibilityOnSiblings != 0;
			bottomSheetBehavior.SetUpdateImportantForAccessibilityOnSiblings(updateImportantForAccessibilityOnSiblings);
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

	[Register("setUpdateImportantForAccessibilityOnSiblings", "(Z)V", "GetSetUpdateImportantForAccessibilityOnSiblings_ZHandler")]
	public unsafe virtual void SetUpdateImportantForAccessibilityOnSiblings(bool updateImportantForAccessibilityOnSiblings)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(updateImportantForAccessibilityOnSiblings ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setUpdateImportantForAccessibilityOnSiblings.(Z)V", this, ptr);
	}

	private static Delegate GetShouldExpandOnUpwardDrag_JFHandler()
	{
		return new _JniMarshal_PPJF_B(n_ShouldExpandOnUpwardDrag_JF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldExpandOnUpwardDrag_JF(nint jnienv, nint native__this, long dragDurationMillis, float yPositionPercentage)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldExpandOnUpwardDrag(dragDurationMillis, yPositionPercentage) ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("shouldExpandOnUpwardDrag", "(JF)Z", "GetShouldExpandOnUpwardDrag_JFHandler")]
	public unsafe virtual bool ShouldExpandOnUpwardDrag(long dragDurationMillis, float yPositionPercentage)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dragDurationMillis);
		ptr[1] = new JniArgumentValue(yPositionPercentage);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldExpandOnUpwardDrag.(JF)Z", this, ptr);
	}

	private static Delegate GetShouldSkipHalfExpandedStateWhenDraggingHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShouldSkipHalfExpandedStateWhenDragging);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldSkipHalfExpandedStateWhenDragging(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldSkipHalfExpandedStateWhenDragging() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("shouldSkipHalfExpandedStateWhenDragging", "()Z", "GetShouldSkipHalfExpandedStateWhenDraggingHandler")]
	public unsafe virtual bool ShouldSkipHalfExpandedStateWhenDragging()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldSkipHalfExpandedStateWhenDragging.()Z", this, null);
	}

	private static Delegate GetShouldSkipSmoothAnimationHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShouldSkipSmoothAnimation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldSkipSmoothAnimation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldSkipSmoothAnimation() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("shouldSkipSmoothAnimation", "()Z", "GetShouldSkipSmoothAnimationHandler")]
	public unsafe virtual bool ShouldSkipSmoothAnimation()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldSkipSmoothAnimation.()Z", this, null);
	}

	private static Delegate GetStartBackProgress_Landroidx_activity_BackEventCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_StartBackProgress_Landroidx_activity_BackEventCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartBackProgress_Landroidx_activity_BackEventCompat_(nint jnienv, nint native__this, nint native_backEvent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BackEventCompat backEvent = Java.Lang.Object.GetObject<BackEventCompat>(native_backEvent, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.StartBackProgress(backEvent);
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

	[Register("startBackProgress", "(Landroidx/activity/BackEventCompat;)V", "GetStartBackProgress_Landroidx_activity_BackEventCompat_Handler")]
	public unsafe virtual void StartBackProgress(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startBackProgress.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	private static Delegate GetUpdateBackProgress_Landroidx_activity_BackEventCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateBackProgress_Landroidx_activity_BackEventCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateBackProgress_Landroidx_activity_BackEventCompat_(nint jnienv, nint native__this, nint native_backEvent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetBehavior? bottomSheetBehavior = Java.Lang.Object.GetObject<BottomSheetBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BackEventCompat backEvent = Java.Lang.Object.GetObject<BackEventCompat>(native_backEvent, JniHandleOwnership.DoNotTransfer);
			bottomSheetBehavior.UpdateBackProgress(backEvent);
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

	[Register("updateBackProgress", "(Landroidx/activity/BackEventCompat;)V", "GetUpdateBackProgress_Landroidx_activity_BackEventCompat_Handler")]
	public unsafe virtual void UpdateBackProgress(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateBackProgress.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
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
