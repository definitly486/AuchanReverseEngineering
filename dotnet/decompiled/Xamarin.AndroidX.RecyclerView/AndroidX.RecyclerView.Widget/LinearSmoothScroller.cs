using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/LinearSmoothScroller", DoNotGenerateAcw = true)]
public class LinearSmoothScroller : RecyclerView.SmoothScroller
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/LinearSmoothScroller", typeof(LinearSmoothScroller));

	private static Delegate? cb_getHorizontalSnapPreference_GetHorizontalSnapPreference_I;

	private static Delegate? cb_getVerticalSnapPreference_GetVerticalSnapPreference_I;

	private static Delegate? cb_calculateDtToFit_CalculateDtToFit_IIIII_I;

	private static Delegate? cb_calculateDxToMakeVisible_CalculateDxToMakeVisible_Landroid_view_View_I_I;

	private static Delegate? cb_calculateDyToMakeVisible_CalculateDyToMakeVisible_Landroid_view_View_I_I;

	private static Delegate? cb_calculateSpeedPerPixel_CalculateSpeedPerPixel_Landroid_util_DisplayMetrics__F;

	private static Delegate? cb_calculateTimeForDeceleration_CalculateTimeForDeceleration_I_I;

	private static Delegate? cb_calculateTimeForScrolling_CalculateTimeForScrolling_I_I;

	private static Delegate? cb_onSeekTargetStep_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action__V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onTargetFound_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action__V;

	private static Delegate? cb_updateActionForInterimTarget_UpdateActionForInterimTarget_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action__V;

	[Register("mDecelerateInterpolator")]
	protected DecelerateInterpolator? MDecelerateInterpolator
	{
		get
		{
			return Java.Lang.Object.GetObject<DecelerateInterpolator>(_members.InstanceFields.GetObjectValue("mDecelerateInterpolator.Landroid/view/animation/DecelerateInterpolator;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mDecelerateInterpolator.Landroid/view/animation/DecelerateInterpolator;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mInterimTargetDx")]
	protected int MInterimTargetDx
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mInterimTargetDx.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mInterimTargetDx.I", this, value);
		}
	}

	[Register("mInterimTargetDy")]
	protected int MInterimTargetDy
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mInterimTargetDy.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mInterimTargetDy.I", this, value);
		}
	}

	[Register("mLinearInterpolator")]
	protected LinearInterpolator? MLinearInterpolator
	{
		get
		{
			return Java.Lang.Object.GetObject<LinearInterpolator>(_members.InstanceFields.GetObjectValue("mLinearInterpolator.Landroid/view/animation/LinearInterpolator;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mLinearInterpolator.Landroid/view/animation/LinearInterpolator;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mTargetVector")]
	protected PointF? MTargetVector
	{
		get
		{
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceFields.GetObjectValue("mTargetVector.Landroid/graphics/PointF;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mTargetVector.Landroid/graphics/PointF;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe virtual int HorizontalSnapPreference
	{
		[Register("getHorizontalSnapPreference", "()I", "GetGetHorizontalSnapPreferenceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalSnapPreference.()I", this, null);
		}
	}

	protected unsafe virtual int VerticalSnapPreference
	{
		[Register("getVerticalSnapPreference", "()I", "GetGetVerticalSnapPreferenceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalSnapPreference.()I", this, null);
		}
	}

	protected LinearSmoothScroller(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe LinearSmoothScroller(Context? context)
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

	private static Delegate GetGetHorizontalSnapPreferenceHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalSnapPreference);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalSnapPreference(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalSnapPreference;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalSnapPreference(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalSnapPreference;
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

	private static Delegate GetCalculateDtToFit_IIIIIHandler()
	{
		return new _JniMarshal_PPIIIII_I(n_CalculateDtToFit_IIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateDtToFit_IIIII(nint jnienv, nint native__this, int viewStart, int viewEnd, int boxStart, int boxEnd, int snapPreference)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateDtToFit(viewStart, viewEnd, boxStart, boxEnd, snapPreference);
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

	[Register("calculateDtToFit", "(IIIII)I", "GetCalculateDtToFit_IIIIIHandler")]
	public unsafe virtual int CalculateDtToFit(int viewStart, int viewEnd, int boxStart, int boxEnd, int snapPreference)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(viewStart);
		ptr[1] = new JniArgumentValue(viewEnd);
		ptr[2] = new JniArgumentValue(boxStart);
		ptr[3] = new JniArgumentValue(boxEnd);
		ptr[4] = new JniArgumentValue(snapPreference);
		return _members.InstanceMethods.InvokeVirtualInt32Method("calculateDtToFit.(IIIII)I", this, ptr);
	}

	private static Delegate GetCalculateDxToMakeVisible_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_I(n_CalculateDxToMakeVisible_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateDxToMakeVisible_Landroid_view_View_I(nint jnienv, nint native__this, nint native_view, int snapPreference)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return linearSmoothScroller.CalculateDxToMakeVisible(view, snapPreference);
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

	[Register("calculateDxToMakeVisible", "(Landroid/view/View;I)I", "GetCalculateDxToMakeVisible_Landroid_view_View_IHandler")]
	public unsafe virtual int CalculateDxToMakeVisible(View? view, int snapPreference)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(snapPreference);
			return _members.InstanceMethods.InvokeVirtualInt32Method("calculateDxToMakeVisible.(Landroid/view/View;I)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetCalculateDyToMakeVisible_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_I(n_CalculateDyToMakeVisible_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateDyToMakeVisible_Landroid_view_View_I(nint jnienv, nint native__this, nint native_view, int snapPreference)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return linearSmoothScroller.CalculateDyToMakeVisible(view, snapPreference);
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

	[Register("calculateDyToMakeVisible", "(Landroid/view/View;I)I", "GetCalculateDyToMakeVisible_Landroid_view_View_IHandler")]
	public unsafe virtual int CalculateDyToMakeVisible(View? view, int snapPreference)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(snapPreference);
			return _members.InstanceMethods.InvokeVirtualInt32Method("calculateDyToMakeVisible.(Landroid/view/View;I)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetCalculateSpeedPerPixel_Landroid_util_DisplayMetrics_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_CalculateSpeedPerPixel_Landroid_util_DisplayMetrics_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_CalculateSpeedPerPixel_Landroid_util_DisplayMetrics_(nint jnienv, nint native__this, nint native_displayMetrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DisplayMetrics displayMetrics = Java.Lang.Object.GetObject<DisplayMetrics>(native_displayMetrics, JniHandleOwnership.DoNotTransfer);
			return linearSmoothScroller.CalculateSpeedPerPixel(displayMetrics);
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

	[Register("calculateSpeedPerPixel", "(Landroid/util/DisplayMetrics;)F", "GetCalculateSpeedPerPixel_Landroid_util_DisplayMetrics_Handler")]
	protected unsafe virtual float CalculateSpeedPerPixel(DisplayMetrics? displayMetrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(displayMetrics?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("calculateSpeedPerPixel.(Landroid/util/DisplayMetrics;)F", this, ptr);
		}
		finally
		{
			GC.KeepAlive(displayMetrics);
		}
	}

	private static Delegate GetCalculateTimeForDeceleration_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_CalculateTimeForDeceleration_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateTimeForDeceleration_I(nint jnienv, nint native__this, int dx)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateTimeForDeceleration(dx);
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

	[Register("calculateTimeForDeceleration", "(I)I", "GetCalculateTimeForDeceleration_IHandler")]
	protected unsafe virtual int CalculateTimeForDeceleration(int dx)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dx);
		return _members.InstanceMethods.InvokeVirtualInt32Method("calculateTimeForDeceleration.(I)I", this, ptr);
	}

	private static Delegate GetCalculateTimeForScrolling_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_CalculateTimeForScrolling_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateTimeForScrolling_I(nint jnienv, nint native__this, int dx)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateTimeForScrolling(dx);
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

	[Register("calculateTimeForScrolling", "(I)I", "GetCalculateTimeForScrolling_IHandler")]
	protected unsafe virtual int CalculateTimeForScrolling(int dx)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dx);
		return _members.InstanceMethods.InvokeVirtualInt32Method("calculateTimeForScrolling.(I)I", this, ptr);
	}

	private static Delegate GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
	{
		return new _JniMarshal_PPIILL_V(n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(nint jnienv, nint native__this, int dx, int dy, nint native_state, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.State p = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
			Action p2 = Java.Lang.Object.GetObject<Action>(native_action, JniHandleOwnership.DoNotTransfer);
			linearSmoothScroller.OnSeekTargetStep(dx, dy, p, p2);
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

	[Register("onSeekTargetStep", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
	protected unsafe override void OnSeekTargetStep(int dx, int dy, RecyclerView.State? state, Action? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSeekTargetStep.(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetOnStartHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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

	[Register("onStart", "()V", "GetOnStartHandler")]
	protected unsafe override void OnStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	[Register("onStop", "()V", "GetOnStopHandler")]
	protected unsafe override void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(nint jnienv, nint native__this, nint native_targetView, nint native_state, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View p = Java.Lang.Object.GetObject<View>(native_targetView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.State p2 = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
			Action p3 = Java.Lang.Object.GetObject<Action>(native_action, JniHandleOwnership.DoNotTransfer);
			linearSmoothScroller.OnTargetFound(p, p2, p3);
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

	[Register("onTargetFound", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
	protected unsafe override void OnTargetFound(View? targetView, RecyclerView.State? state, Action? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(targetView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onTargetFound.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(targetView);
			GC.KeepAlive(state);
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetUpdateActionForInterimTarget_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateActionForInterimTarget_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateActionForInterimTarget_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSmoothScroller? linearSmoothScroller = Java.Lang.Object.GetObject<LinearSmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Action action = Java.Lang.Object.GetObject<Action>(native_action, JniHandleOwnership.DoNotTransfer);
			linearSmoothScroller.UpdateActionForInterimTarget(action);
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

	[Register("updateActionForInterimTarget", "(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetUpdateActionForInterimTarget_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
	protected unsafe virtual void UpdateActionForInterimTarget(Action? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateActionForInterimTarget.(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetVerticalSnapPreference_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetVerticalSnapPreference(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
