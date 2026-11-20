using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views.Accessibility;
using Android.Window;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewGroup", DoNotGenerateAcw = true)]
public abstract class ViewGroup : View, IViewManager, IJavaObject, IDisposable, IJavaPeerable, IViewParent
{
	[Register("android/view/ViewGroup$LayoutParams", DoNotGenerateAcw = true)]
	public class LayoutParams : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewGroup$LayoutParams", typeof(LayoutParams));

		[Register("height")]
		public int Height
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("height.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("height.I", this, value);
			}
		}

		[Register("width")]
		public int Width
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("width.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("width.I", this, value);
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected LayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context? c, IAttributeSet? attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(LayoutParams? source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe LayoutParams(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}
	}

	[Register("android/view/ViewGroup$MarginLayoutParams", DoNotGenerateAcw = true)]
	public class MarginLayoutParams : LayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewGroup$MarginLayoutParams", typeof(MarginLayoutParams));

		private static Delegate? cb_getMarginEnd_GetMarginEnd_I;

		private static Delegate? cb_setMarginEnd_SetMarginEnd_I_V;

		private static Delegate? cb_getMarginStart_GetMarginStart_I;

		private static Delegate? cb_setMarginStart_SetMarginStart_I_V;

		private static Delegate? cb_setMargins_SetMargins_IIII_V;

		[Register("bottomMargin")]
		public int BottomMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("bottomMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bottomMargin.I", this, value);
			}
		}

		[Register("leftMargin")]
		public int LeftMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("leftMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("leftMargin.I", this, value);
			}
		}

		[Register("rightMargin")]
		public int RightMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("rightMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rightMargin.I", this, value);
			}
		}

		[Register("topMargin")]
		public int TopMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("topMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("topMargin.I", this, value);
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int MarginEnd
		{
			[Register("getMarginEnd", "()I", "GetGetMarginEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMarginEnd.()I", this, null);
			}
			[Register("setMarginEnd", "(I)V", "GetSetMarginEnd_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMarginEnd.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MarginStart
		{
			[Register("getMarginStart", "()I", "GetGetMarginStartHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMarginStart.()I", this, null);
			}
			[Register("setMarginStart", "(I)V", "GetSetMarginStart_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMarginStart.(I)V", this, ptr);
			}
		}

		protected MarginLayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe MarginLayoutParams(Context? c, IAttributeSet? attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe MarginLayoutParams(LayoutParams? source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		private static Delegate GetGetMarginEndHandler()
		{
			return new _JniMarshal_PP_I(n_GetMarginEnd);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMarginEnd(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<MarginLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarginEnd;
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

		private static Delegate GetSetMarginEnd_IHandler()
		{
			return new _JniMarshal_PPI_V(n_SetMarginEnd_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMarginEnd_I(nint jnienv, nint native__this, int end)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<MarginLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarginEnd = end;
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

		private static Delegate GetGetMarginStartHandler()
		{
			return new _JniMarshal_PP_I(n_GetMarginStart);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMarginStart(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<MarginLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarginStart;
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

		private static Delegate GetSetMarginStart_IHandler()
		{
			return new _JniMarshal_PPI_V(n_SetMarginStart_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMarginStart_I(nint jnienv, nint native__this, int start)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<MarginLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarginStart = start;
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

		private static Delegate GetSetMargins_IIIIHandler()
		{
			return new _JniMarshal_PPIIII_V(n_SetMargins_IIII);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMargins_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<MarginLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMargins(left, top, right, bottom);
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

		[Register("setMargins", "(IIII)V", "GetSetMargins_IIIIHandler")]
		public unsafe virtual void SetMargins(int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMargins.(IIII)V", this, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewGroup", typeof(ViewGroup));

	private static Delegate? cb_getChildCount_GetChildCount_I;

	private static Delegate? cb_setDescendantFocusability_SetDescendantFocusability_I_V;

	private static Delegate? cb_isLayoutSuppressed_IsLayoutSuppressed_Z;

	private static Delegate? cb_getLayoutTransition_GetLayoutTransition_Landroid_animation_LayoutTransition_;

	private static Delegate? cb_setLayoutTransition_SetLayoutTransition_Landroid_animation_LayoutTransition__V;

	private static Delegate? cb_addView_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_addView_AddView_Landroid_view_View__V;

	private static Delegate? cb_bringChildToFront_BringChildToFront_Landroid_view_View__V;

	private static Delegate? cb_childDrawableStateChanged_ChildDrawableStateChanged_Landroid_view_View__V;

	private static Delegate? cb_childHasTransientStateChanged_ChildHasTransientStateChanged_Landroid_view_View_Z_V;

	private static Delegate? cb_clearChildFocus_ClearChildFocus_Landroid_view_View__V;

	private static Delegate? cb_drawChild_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J_Z;

	private static Delegate? cb_findOnBackInvokedDispatcherForChild_FindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View__Landroid_window_OnBackInvokedDispatcher_;

	private static Delegate? cb_focusableViewAvailable_FocusableViewAvailable_Landroid_view_View__V;

	private static Delegate? cb_focusSearch_FocusSearch_Landroid_view_View_I_Landroid_view_View_;

	private static Delegate? cb_getChildAt_GetChildAt_I_Landroid_view_View_;

	private static Delegate? cb_getChildVisibleRect_GetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point__Z;

	private static Delegate? cb_indexOfChild_IndexOfChild_Landroid_view_View__I;

	private static Delegate? cb_invalidateChildInParent_InvalidateChildInParent_arrayILandroid_graphics_Rect__Landroid_view_ViewParent_;

	private static Delegate? cb_notifySubtreeAccessibilityStateChanged_NotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_I_V;

	private static Delegate? cb_onDescendantInvalidated_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View__V;

	private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onNestedFling_OnNestedFling_Landroid_view_View_FFZ_Z;

	private static Delegate? cb_onNestedPreFling_OnNestedPreFling_Landroid_view_View_FF_Z;

	private static Delegate? cb_onNestedPrePerformAccessibilityAction_OnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle__Z;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayI_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIII_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_I_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_I_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View__V;

	private static Delegate? cb_recomputeViewAttributes_RecomputeViewAttributes_Landroid_view_View__V;

	private static Delegate? cb_removeAllViews_RemoveAllViews_V;

	private static Delegate? cb_removeView_RemoveView_Landroid_view_View__V;

	private static Delegate? cb_removeViewAt_RemoveViewAt_I_V;

	private static Delegate? cb_requestChildFocus_RequestChildFocus_Landroid_view_View_Landroid_view_View__V;

	private static Delegate? cb_requestChildRectangleOnScreen_RequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_Z_Z;

	private static Delegate? cb_requestDisallowInterceptTouchEvent_RequestDisallowInterceptTouchEvent_Z_V;

	private static Delegate? cb_requestSendAccessibilityEvent_RequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent__Z;

	private static Delegate? cb_requestTransparentRegion_RequestTransparentRegion_Landroid_view_View__V;

	private static Delegate? cb_setClipChildren_SetClipChildren_Z_V;

	private static Delegate? cb_setClipToPadding_SetClipToPadding_Z_V;

	private static Delegate? cb_showContextMenuForChild_ShowContextMenuForChild_Landroid_view_View_FF_Z;

	private static Delegate? cb_showContextMenuForChild_ShowContextMenuForChild_Landroid_view_View__Z;

	private static Delegate? cb_startActionModeForChild_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_I_Landroid_view_ActionMode_;

	private static Delegate? cb_startActionModeForChild_StartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback__Landroid_view_ActionMode_;

	private static Delegate? cb_suppressLayout_SuppressLayout_Z_V;

	private static Delegate? cb_updateViewLayout_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int ChildCount
	{
		[Register("getChildCount", "()I", "GetGetChildCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
		}
	}

	public unsafe virtual DescendantFocusability DescendantFocusability
	{
		[Register("setDescendantFocusability", "(I)V", "GetSetDescendantFocusability_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDescendantFocusability.(I)V", this, ptr);
		}
	}

	[SupportedOSPlatform("android29.0")]
	public unsafe virtual bool IsLayoutSuppressed
	{
		[Register("isLayoutSuppressed", "()Z", "GetIsLayoutSuppressedHandler", ApiSince = 29)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutSuppressed.()Z", this, null);
		}
	}

	public unsafe virtual LayoutTransition? LayoutTransition
	{
		[Register("getLayoutTransition", "()Landroid/animation/LayoutTransition;", "GetGetLayoutTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LayoutTransition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutTransition.()Landroid/animation/LayoutTransition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setLayoutTransition", "(Landroid/animation/LayoutTransition;)V", "GetSetLayoutTransition_Landroid_animation_LayoutTransition_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutTransition.(Landroid/animation/LayoutTransition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ViewGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe ViewGroup(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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
	public unsafe ViewGroup(Context? context, IAttributeSet? attrs, int defStyleAttr)
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
	public unsafe ViewGroup(Context? context, IAttributeSet? attrs)
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
	public unsafe ViewGroup(Context? context)
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

	private static Delegate GetGetChildCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetChildCount);
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
			return Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
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

	private static Delegate GetSetDescendantFocusability_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetDescendantFocusability_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDescendantFocusability_I(nint jnienv, nint native__this, int native_focusability)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescendantFocusability = (DescendantFocusability)native_focusability;
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

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetIsLayoutSuppressedHandler()
	{
		return new _JniMarshal_PP_B(n_IsLayoutSuppressed);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutSuppressed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutSuppressed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLayoutTransitionHandler()
	{
		return new _JniMarshal_PP_L(n_GetLayoutTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLayoutTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutTransition);
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

	private static Delegate GetSetLayoutTransition_Landroid_animation_LayoutTransition_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetLayoutTransition_Landroid_animation_LayoutTransition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayoutTransition_Landroid_animation_LayoutTransition_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LayoutTransition layoutTransition = Java.Lang.Object.GetObject<LayoutTransition>(native_transition, JniHandleOwnership.DoNotTransfer);
			viewGroup.LayoutTransition = layoutTransition;
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

	private static Delegate GetAddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_child, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			viewGroup.AddView(child, layoutParams);
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

	[Register("addView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetAddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public unsafe virtual void AddView(View? child, LayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetAddView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.AddView(child);
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

	[Register("addView", "(Landroid/view/View;)V", "GetAddView_Landroid_view_View_Handler")]
	public unsafe virtual void AddView(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.BringChildToFront(child);
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

	[Register("bringChildToFront", "(Landroid/view/View;)V", "GetBringChildToFront_Landroid_view_View_Handler")]
	public unsafe virtual void BringChildToFront(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("bringChildToFront.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.ChildDrawableStateChanged(child);
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

	[Register("childDrawableStateChanged", "(Landroid/view/View;)V", "GetChildDrawableStateChanged_Landroid_view_View_Handler")]
	public unsafe virtual void ChildDrawableStateChanged(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("childDrawableStateChanged.(Landroid/view/View;)V", this, ptr);
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
	private static void n_ChildHasTransientStateChanged_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_child, sbyte native_childHasTransientState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			bool childHasTransientState = native_childHasTransientState != 0;
			viewGroup.ChildHasTransientStateChanged(child, childHasTransientState);
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

	[Register("childHasTransientStateChanged", "(Landroid/view/View;Z)V", "GetChildHasTransientStateChanged_Landroid_view_View_ZHandler")]
	public unsafe virtual void ChildHasTransientStateChanged(View? child, bool childHasTransientState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(childHasTransientState ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("childHasTransientStateChanged.(Landroid/view/View;Z)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.ClearChildFocus(child);
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

	[Register("clearChildFocus", "(Landroid/view/View;)V", "GetClearChildFocus_Landroid_view_View_Handler")]
	public unsafe virtual void ClearChildFocus(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearChildFocus.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler()
	{
		return new _JniMarshal_PPLLJ_B(n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J(nint jnienv, nint native__this, nint native_canvas, nint native_child, long drawingTime)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return viewGroup.DrawChild(canvas, child, drawingTime) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("drawChild", "(Landroid/graphics/Canvas;Landroid/view/View;J)Z", "GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler")]
	protected unsafe virtual bool DrawChild(Canvas canvas, View? child, long drawingTime)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(drawingTime);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("drawChild.(Landroid/graphics/Canvas;Landroid/view/View;J)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
			GC.KeepAlive(child);
		}
	}

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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View requester = Java.Lang.Object.GetObject<View>(native_requester, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewGroup.FindOnBackInvokedDispatcherForChild(child, requester));
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
	[Register("findOnBackInvokedDispatcherForChild", "(Landroid/view/View;Landroid/view/View;)Landroid/window/OnBackInvokedDispatcher;", "GetFindOnBackInvokedDispatcherForChild_Landroid_view_View_Landroid_view_View_Handler", ApiSince = 33)]
	public unsafe virtual IOnBackInvokedDispatcher? FindOnBackInvokedDispatcherForChild(View child, View requester)
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			viewGroup.FocusableViewAvailable(v);
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

	[Register("focusableViewAvailable", "(Landroid/view/View;)V", "GetFocusableViewAvailable_Landroid_view_View_Handler")]
	public unsafe virtual void FocusableViewAvailable(View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("focusableViewAvailable.(Landroid/view/View;)V", this, ptr);
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
	private static nint n_FocusSearch_Landroid_view_View_I(nint jnienv, nint native__this, nint native_focused, int native_direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewGroup.FocusSearch(focused, (FocusSearchDirection)native_direction));
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

	[Register("focusSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetFocusSearch_Landroid_view_View_IHandler")]
	public unsafe virtual View? FocusSearch(View? focused, FocusSearchDirection direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)direction);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("focusSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(focused);
		}
	}

	private static Delegate GetGetChildAt_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetChildAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChildAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChildAt(index));
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

	[Register("getChildAt", "(I)Landroid/view/View;", "GetGetChildAt_IHandler")]
	public unsafe virtual View? GetChildAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildAt.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect r = Java.Lang.Object.GetObject<Rect>(native_r, JniHandleOwnership.DoNotTransfer);
			Point offset = Java.Lang.Object.GetObject<Point>(native_offset, JniHandleOwnership.DoNotTransfer);
			return viewGroup.GetChildVisibleRect(child, r, offset) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getChildVisibleRect", "(Landroid/view/View;Landroid/graphics/Rect;Landroid/graphics/Point;)Z", "GetGetChildVisibleRect_Landroid_view_View_Landroid_graphics_Rect_Landroid_graphics_Point_Handler")]
	public unsafe virtual bool GetChildVisibleRect(View? child, Rect? r, Point? offset)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(offset?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getChildVisibleRect.(Landroid/view/View;Landroid/graphics/Rect;Landroid/graphics/Point;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(r);
			GC.KeepAlive(offset);
		}
	}

	private static Delegate GetIndexOfChild_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_I(n_IndexOfChild_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_IndexOfChild_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return viewGroup.IndexOfChild(child);
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

	[Register("indexOfChild", "(Landroid/view/View;)I", "GetIndexOfChild_Landroid_view_View_Handler")]
	public unsafe virtual int IndexOfChild(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("indexOfChild.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	[Register("invalidateChild", "(Landroid/view/View;Landroid/graphics/Rect;)V", "")]
	public unsafe void InvalidateChild(View? child, Rect? dirty)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dirty?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("invalidateChild.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(dirty);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvalidateChildInParent_arrayILandroid_graphics_Rect_(nint jnienv, nint native__this, nint native_location, nint native_dirty)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_location, JniHandleOwnership.DoNotTransfer, typeof(int));
			Rect dirty = Java.Lang.Object.GetObject<Rect>(native_dirty, JniHandleOwnership.DoNotTransfer);
			nint result = JNIEnv.ToLocalJniHandle(viewGroup.InvalidateChildInParent(array, dirty));
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

	[ObsoletedOSPlatform("android26.0")]
	[Register("invalidateChildInParent", "([ILandroid/graphics/Rect;)Landroid/view/ViewParent;", "GetInvalidateChildInParent_arrayILandroid_graphics_Rect_Handler")]
	public unsafe virtual IViewParent? InvalidateChildInParent(int[]? location, Rect? dirty)
	{
		nint num = JNIEnv.NewArray(location);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(dirty?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IViewParent>(_members.InstanceMethods.InvokeVirtualObjectMethod("invalidateChildInParent.([ILandroid/graphics/Rect;)Landroid/view/ViewParent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (location != null)
			{
				JNIEnv.CopyArray(num, location);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(location);
			GC.KeepAlive(dirty);
		}
	}

	[Register("layout", "(IIII)V", "")]
	public unsafe sealed override void Layout(int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(l);
		ptr[1] = new JniArgumentValue(t);
		ptr[2] = new JniArgumentValue(r);
		ptr[3] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("layout.(IIII)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View source = Java.Lang.Object.GetObject<View>(native_source, JniHandleOwnership.DoNotTransfer);
			viewGroup.NotifySubtreeAccessibilityStateChanged(child, source, (ContentChangeTypes)native_changeType);
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

	[Register("notifySubtreeAccessibilityStateChanged", "(Landroid/view/View;Landroid/view/View;I)V", "GetNotifySubtreeAccessibilityStateChanged_Landroid_view_View_Landroid_view_View_IHandler")]
	public unsafe virtual void NotifySubtreeAccessibilityStateChanged(View? child, View? source, ContentChangeTypes changeType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)changeType);
			_members.InstanceMethods.InvokeVirtualVoidMethod("notifySubtreeAccessibilityStateChanged.(Landroid/view/View;Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(source);
		}
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewGroup.OnDescendantInvalidated(child, target);
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
	[Register("onDescendantInvalidated", "(Landroid/view/View;Landroid/view/View;)V", "GetOnDescendantInvalidated_Landroid_view_View_Landroid_view_View_Handler", ApiSince = 26)]
	public unsafe virtual void OnDescendantInvalidated(View child, View target)
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

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnInterceptTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return viewGroup.OnInterceptTouchEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onInterceptTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool OnInterceptTouchEvent(MotionEvent? ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new _JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			viewGroup.OnLayout(changed, l, t, r, b);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected new abstract void OnLayout(bool changed, int l, int t, int r, int b);

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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			bool consumed = native_consumed != 0;
			return viewGroup.OnNestedFling(target, velocityX, velocityY, consumed) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onNestedFling", "(Landroid/view/View;FFZ)Z", "GetOnNestedFling_Landroid_view_View_FFZHandler")]
	public unsafe virtual bool OnNestedFling(View? target, float velocityX, float velocityY, bool consumed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			ptr[3] = new JniArgumentValue(consumed ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedFling.(Landroid/view/View;FFZ)Z", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return viewGroup.OnNestedPreFling(target, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onNestedPreFling", "(Landroid/view/View;FF)Z", "GetOnNestedPreFling_Landroid_view_View_FFHandler")]
	public unsafe virtual bool OnNestedPreFling(View? target, float velocityX, float velocityY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedPreFling.(Landroid/view/View;FF)Z", this, ptr);
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
	private static sbyte n_OnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_target, int native_action, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return viewGroup.OnNestedPrePerformAccessibilityAction(target, (Android.Views.Accessibility.Action)native_action, args) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("onNestedPrePerformAccessibilityAction", "(Landroid/view/View;ILandroid/os/Bundle;)Z", "GetOnNestedPrePerformAccessibilityAction_Landroid_view_View_ILandroid_os_Bundle_Handler", ApiSince = 22)]
	public unsafe virtual bool OnNestedPrePerformAccessibilityAction(View? target, Android.Views.Accessibility.Action action, Bundle? args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)action);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedPrePerformAccessibilityAction.(Landroid/view/View;ILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
			GC.KeepAlive(args);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			viewGroup.OnNestedPreScroll(target, dx, dy, array);
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

	[Register("onNestedPreScroll", "(Landroid/view/View;II[I)V", "GetOnNestedPreScroll_Landroid_view_View_IIarrayIHandler")]
	public unsafe virtual void OnNestedPreScroll(View? target, int dx, int dy, int[]? consumed)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroid/view/View;II[I)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewGroup.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);
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

	[Register("onNestedScroll", "(Landroid/view/View;IIII)V", "GetOnNestedScroll_Landroid_view_View_IIIIHandler")]
	public unsafe virtual void OnNestedScroll(View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIII)V", this, ptr);
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
	private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, nint native_target, int native_axes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			viewGroup.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes);
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

	[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;I)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IHandler")]
	public unsafe virtual void OnNestedScrollAccepted(View? child, View? target, ScrollAxis axes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)axes);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroid/view/View;Landroid/view/View;I)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return viewGroup.OnStartNestedScroll(child, target, (ScrollAxis)native_nestedScrollAxes) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;I)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IHandler")]
	public unsafe virtual bool OnStartNestedScroll(View? child, View? target, ScrollAxis nestedScrollAxes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)nestedScrollAxes);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroid/view/View;Landroid/view/View;I)Z", this, ptr);
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
	private static void n_OnStopNestedScroll_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.OnStopNestedScroll(child);
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

	[Register("onStopNestedScroll", "(Landroid/view/View;)V", "GetOnStopNestedScroll_Landroid_view_View_Handler")]
	public unsafe virtual void OnStopNestedScroll(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.RecomputeViewAttributes(child);
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

	[Register("recomputeViewAttributes", "(Landroid/view/View;)V", "GetRecomputeViewAttributes_Landroid_view_View_Handler")]
	public unsafe virtual void RecomputeViewAttributes(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("recomputeViewAttributes.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetRemoveAllViewsHandler()
	{
		return new _JniMarshal_PP_V(n_RemoveAllViews);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllViews(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllViews();
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

	[Register("removeAllViews", "()V", "GetRemoveAllViewsHandler")]
	public unsafe virtual void RemoveAllViews()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllViews.()V", this, null);
	}

	private static Delegate GetRemoveView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewGroup.RemoveView(view);
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

	[Register("removeView", "(Landroid/view/View;)V", "GetRemoveView_Landroid_view_View_Handler")]
	public unsafe virtual void RemoveView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetRemoveViewAt_IHandler()
	{
		return new _JniMarshal_PPI_V(n_RemoveViewAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveViewAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveViewAt(index);
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

	[Register("removeViewAt", "(I)V", "GetRemoveViewAt_IHandler")]
	public unsafe virtual void RemoveViewAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeViewAt.(I)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			viewGroup.RequestChildFocus(child, focused);
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

	[Register("requestChildFocus", "(Landroid/view/View;Landroid/view/View;)V", "GetRequestChildFocus_Landroid_view_View_Landroid_view_View_Handler")]
	public unsafe virtual void RequestChildFocus(View? child, View? focused)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestChildFocus.(Landroid/view/View;Landroid/view/View;)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect rectangle = Java.Lang.Object.GetObject<Rect>(native_rectangle, JniHandleOwnership.DoNotTransfer);
			bool immediate = native_immediate != 0;
			return viewGroup.RequestChildRectangleOnScreen(child, rectangle, immediate) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("requestChildRectangleOnScreen", "(Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetRequestChildRectangleOnScreen_Landroid_view_View_Landroid_graphics_Rect_ZHandler")]
	public unsafe virtual bool RequestChildRectangleOnScreen(View? child, Rect? rectangle, bool immediate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(rectangle?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(immediate ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestChildRectangleOnScreen.(Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool disallowIntercept = native_disallowIntercept != 0;
			viewGroup.RequestDisallowInterceptTouchEvent(disallowIntercept);
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

	[Register("requestDisallowInterceptTouchEvent", "(Z)V", "GetRequestDisallowInterceptTouchEvent_ZHandler")]
	public unsafe virtual void RequestDisallowInterceptTouchEvent(bool disallowIntercept)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(disallowIntercept ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("requestDisallowInterceptTouchEvent.(Z)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return viewGroup.RequestSendAccessibilityEvent(child, e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("requestSendAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", "GetRequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler")]
	public unsafe virtual bool RequestSendAccessibilityEvent(View? child, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestSendAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			viewGroup.RequestTransparentRegion(child);
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

	[Register("requestTransparentRegion", "(Landroid/view/View;)V", "GetRequestTransparentRegion_Landroid_view_View_Handler")]
	public unsafe virtual void RequestTransparentRegion(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestTransparentRegion.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetSetClipChildren_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetClipChildren_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClipChildren_Z(nint jnienv, nint native__this, sbyte native_clipChildren)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool clipChildren = native_clipChildren != 0;
			viewGroup.SetClipChildren(clipChildren);
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

	[Register("setClipChildren", "(Z)V", "GetSetClipChildren_ZHandler")]
	public unsafe virtual void SetClipChildren(bool clipChildren)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(clipChildren ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setClipChildren.(Z)V", this, ptr);
	}

	private static Delegate GetSetClipToPadding_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetClipToPadding_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClipToPadding_Z(nint jnienv, nint native__this, sbyte native_clipToPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool clipToPadding = native_clipToPadding != 0;
			viewGroup.SetClipToPadding(clipToPadding);
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

	[Register("setClipToPadding", "(Z)V", "GetSetClipToPadding_ZHandler")]
	public unsafe virtual void SetClipToPadding(bool clipToPadding)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(clipToPadding ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setClipToPadding.(Z)V", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			return viewGroup.ShowContextMenuForChild(originalView, x, y) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("showContextMenuForChild", "(Landroid/view/View;FF)Z", "GetShowContextMenuForChild_Landroid_view_View_FFHandler", ApiSince = 24)]
	public unsafe virtual bool ShowContextMenuForChild(View? originalView, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("showContextMenuForChild.(Landroid/view/View;FF)Z", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			return viewGroup.ShowContextMenuForChild(originalView) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("showContextMenuForChild", "(Landroid/view/View;)Z", "GetShowContextMenuForChild_Landroid_view_View_Handler")]
	public unsafe virtual bool ShowContextMenuForChild(View? originalView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("showContextMenuForChild.(Landroid/view/View;)Z", this, ptr);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewGroup.StartActionModeForChild(originalView, callback, (ActionModeType)native_type));
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
	[Register("startActionModeForChild", "(Landroid/view/View;Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", "GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_IHandler", ApiSince = 23)]
	public unsafe virtual ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback, ActionModeType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[2] = new JniArgumentValue((int)type);
			return Java.Lang.Object.GetObject<ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("startActionModeForChild.(Landroid/view/View;Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View originalView = Java.Lang.Object.GetObject<View>(native_originalView, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewGroup.StartActionModeForChild(originalView, callback));
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

	[Register("startActionModeForChild", "(Landroid/view/View;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", "GetStartActionModeForChild_Landroid_view_View_Landroid_view_ActionMode_Callback_Handler")]
	public unsafe virtual ActionMode? StartActionModeForChild(View? originalView, ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(originalView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("startActionModeForChild.(Landroid/view/View;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(originalView);
			GC.KeepAlive(callback);
		}
	}

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetSuppressLayout_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SuppressLayout_Z);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SuppressLayout_Z(nint jnienv, nint native__this, sbyte native_suppress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool suppress = native_suppress != 0;
			viewGroup.SuppressLayout(suppress);
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

	[SupportedOSPlatform("android29.0")]
	[Register("suppressLayout", "(Z)V", "GetSuppressLayout_ZHandler", ApiSince = 29)]
	public unsafe virtual void SuppressLayout(bool suppress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(suppress ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("suppressLayout.(Z)V", this, ptr);
	}

	private static Delegate GetUpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new _JniMarshal_PPLL_V(n_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_view, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewGroup? viewGroup = Java.Lang.Object.GetObject<ViewGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			viewGroup.UpdateViewLayout(view, layoutParams);
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

	[Register("updateViewLayout", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetUpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public unsafe virtual void UpdateViewLayout(View? view, LayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateViewLayout.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@params);
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

	[UnmanagedCallersOnly]
	private static sbyte n_OnInterceptTouchEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_ev)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnInterceptTouchEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_ev);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_child, nint native_target)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDescendantInvalidated_Landroid_view_View_Landroid_view_View_(jnienv, native__this, native_child, native_target);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_InvalidateChildInParent_arrayILandroid_graphics_Rect__mm_wrapper(nint jnienv, nint native__this, nint native_location, nint native_dirty)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_InvalidateChildInParent_arrayILandroid_graphics_Rect_(jnienv, native__this, native_location, native_dirty);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
