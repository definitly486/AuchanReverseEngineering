using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/SnapHelper", DoNotGenerateAcw = true)]
internal class SnapHelperInvoker : SnapHelper
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/SnapHelper", typeof(SnapHelperInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SnapHelperInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("calculateDistanceToFinalSnap", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I", "GetCalculateDistanceToFinalSnap_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Landroid_view_View_Handler")]
	public unsafe override int[]? CalculateDistanceToFinalSnap(RecyclerView.LayoutManager layoutManager, View targetView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(targetView?.Handle ?? IntPtr.Zero);
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("calculateDistanceToFinalSnap.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
		finally
		{
			GC.KeepAlive(layoutManager);
			GC.KeepAlive(targetView);
		}
	}

	[Register("findSnapView", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroid/view/View;", "GetFindSnapView_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	public unsafe override View? FindSnapView(RecyclerView.LayoutManager? layoutManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutManager?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("findSnapView.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
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
			return _members.InstanceMethods.InvokeAbstractInt32Method("findTargetSnapPosition.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;II)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layoutManager);
		}
	}
}
