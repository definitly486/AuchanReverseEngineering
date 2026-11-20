using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/SnapHelper", DoNotGenerateAcw = true)]
public abstract class SnapHelper : RecyclerView.OnFlingListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/SnapHelper", typeof(SnapHelper));

	private static Delegate? cb_attachToRecyclerView_AttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView__V;

	private static Delegate? cb_calculateDistanceToFinalSnap_CalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View__arrayI;

	private static Delegate? cb_calculateScrollDistance_CalculateScrollDistance_II_arrayI;

	private static Delegate? cb_createScroller_CreateScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager__Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_;

	private static Delegate? cb_createSnapScroller_CreateSnapScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager__Landroidx_recyclerview_widget_LinearSmoothScroller_;

	private static Delegate? cb_findSnapView_FindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager__Landroid_view_View_;

	private static Delegate? cb_findTargetSnapPosition_FindTargetSnapPosition_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_II_I;

	private static Delegate? cb_onFling_OnFling_II_Z;

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

	protected SnapHelper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SnapHelper()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_recyclerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			snapHelper.AttachToRecyclerView(recyclerView);
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

	[Register("attachToRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetAttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
	public unsafe virtual void AttachToRecyclerView(RecyclerView? recyclerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("attachToRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recyclerView);
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
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			View targetView = Java.Lang.Object.GetObject<View>(native_targetView, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(snapHelper.CalculateDistanceToFinalSnap(layoutManager, targetView));
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
	public abstract int[]? CalculateDistanceToFinalSnap(RecyclerView.LayoutManager layoutManager, View targetView);

	private static Delegate GetCalculateScrollDistance_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_CalculateScrollDistance_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CalculateScrollDistance_II(nint jnienv, nint native__this, int velocityX, int velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateScrollDistance(velocityX, velocityY));
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

	[Register("calculateScrollDistance", "(II)[I", "GetCalculateScrollDistance_IIHandler")]
	public unsafe virtual int[]? CalculateScrollDistance(int velocityX, int velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(velocityX);
		ptr[1] = new JniArgumentValue(velocityY);
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("calculateScrollDistance.(II)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetCreateScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_(nint jnienv, nint native__this, nint native_layoutManager)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(snapHelper.CreateScroller(layoutManager));
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

	[Register("createScroller", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;", "GetCreateScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	protected unsafe virtual RecyclerView.SmoothScroller? CreateScroller(RecyclerView.LayoutManager layoutManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RecyclerView.SmoothScroller>(_members.InstanceMethods.InvokeVirtualObjectMethod("createScroller.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
		}
	}

	[Obsolete]
	private static Delegate GetCreateSnapScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateSnapScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateSnapScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_(nint jnienv, nint native__this, nint native_layoutManager)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(snapHelper.CreateSnapScroller(layoutManager));
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

	[Obsolete("deprecated")]
	[Register("createSnapScroller", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroidx/recyclerview/widget/LinearSmoothScroller;", "GetCreateSnapScroller_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	protected unsafe virtual LinearSmoothScroller? CreateSnapScroller(RecyclerView.LayoutManager layoutManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LinearSmoothScroller>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSnapScroller.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroidx/recyclerview/widget/LinearSmoothScroller;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
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
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(snapHelper.FindSnapView(layoutManager));
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
	public abstract View? FindSnapView(RecyclerView.LayoutManager? layoutManager);

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
			SnapHelper? snapHelper = Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.LayoutManager layoutManager = Java.Lang.Object.GetObject<RecyclerView.LayoutManager>(native_layoutManager, JniHandleOwnership.DoNotTransfer);
			return snapHelper.FindTargetSnapPosition(layoutManager, velocityX, velocityY);
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
	public abstract int FindTargetSnapPosition(RecyclerView.LayoutManager? layoutManager, int velocityX, int velocityY);

	private static Delegate GetOnFling_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_OnFling_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnFling_II(nint jnienv, nint native__this, int velocityX, int velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SnapHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFling(velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onFling", "(II)Z", "GetOnFling_IIHandler")]
	public unsafe override bool OnFling(int velocityX, int velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(velocityX);
		ptr[1] = new JniArgumentValue(velocityY);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onFling.(II)Z", this, ptr);
	}
}
