using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/RecyclerViewAccessibilityDelegate", DoNotGenerateAcw = true)]
public class RecyclerViewAccessibilityDelegate : AccessibilityDelegateCompat
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerViewAccessibilityDelegate", typeof(RecyclerViewAccessibilityDelegate));

	private static Delegate? cb_getItemDelegate_GetItemDelegate_Landroidx_core_view_AccessibilityDelegateCompat_;

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

	protected RecyclerViewAccessibilityDelegate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView;)V", "")]
	public unsafe RecyclerViewAccessibilityDelegate(RecyclerView recyclerView)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/RecyclerView;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recyclerView);
		}
	}

	private static Delegate GetGetItemDelegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemDelegate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemDelegate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemDelegate());
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

	[Register("getItemDelegate", "()Landroidx/core/view/AccessibilityDelegateCompat;", "GetGetItemDelegateHandler")]
	public unsafe virtual AccessibilityDelegateCompat GetItemDelegate()
	{
		return Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemDelegate.()Landroidx/core/view/AccessibilityDelegateCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
