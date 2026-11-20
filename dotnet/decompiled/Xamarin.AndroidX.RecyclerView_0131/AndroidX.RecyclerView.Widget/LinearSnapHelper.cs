using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/LinearSnapHelper", DoNotGenerateAcw = true)]
public class LinearSnapHelper : SnapHelper
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/LinearSnapHelper", typeof(LinearSnapHelper));

	private static Delegate? cb_calculateDistanceToFinalSnap_CalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View__arrayI;

	private static Delegate? cb_findSnapView_FindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager__Landroid_view_View_;

	private static Delegate? cb_findTargetSnapPosition_FindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_II_I;

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

	protected LinearSnapHelper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LinearSnapHelper()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetCalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_CalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View_(nint jnienv, nint native__this, nint native_layoutManager, nint native_targetView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSnapHelper? linearSnapHelper = Java.Lang.Object.GetObject<LinearSnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			View targetView = Java.Lang.Object.GetObject<View>(native_targetView, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(linearSnapHelper.CalculateDistanceToFinalSnap(layoutManager, targetView));
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

	[Register("calculateDistanceToFinalSnap", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I", "GetCalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View_Handler")]
	public unsafe override int[]? CalculateDistanceToFinalSnap(RecyclerView.LayoutManager layoutManager, View targetView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(targetView?.Handle ?? IntPtr.Zero);
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("calculateDistanceToFinalSnap.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
		finally
		{
			GC.KeepAlive(layoutManager);
			GC.KeepAlive(targetView);
		}
	}

	private static Delegate GetFindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_(nint jnienv, nint native__this, nint native_layoutManager)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSnapHelper? linearSnapHelper = Java.Lang.Object.GetObject<LinearSnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSnapHelper.FindSnapView(layoutManager));
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

	[Register("findSnapView", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroid/view/View;", "GetFindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	public unsafe override View? FindSnapView(RecyclerView.LayoutManager? layoutManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findSnapView.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
		}
	}

	private static Delegate GetFindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_IIHandler()
	{
		return new global::_JniMarshal_PPLII_I(n_FindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_II(nint jnienv, nint native__this, nint native_layoutManager, int velocityX, int velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSnapHelper? linearSnapHelper = Java.Lang.Object.GetObject<LinearSnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return linearSnapHelper.FindTargetSnapPosition(layoutManager, velocityX, velocityY);
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

	[Register("findTargetSnapPosition", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;II)I", "GetFindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_IIHandler")]
	public unsafe override int FindTargetSnapPosition(RecyclerView.LayoutManager? layoutManager, int velocityX, int velocityY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			return _members.InstanceMethods.InvokeVirtualInt32Method("findTargetSnapPosition.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;II)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
		}
	}
}
