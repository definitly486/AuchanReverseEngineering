using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewTreeLifecycleOwner", DoNotGenerateAcw = true)]
public sealed class ViewTreeLifecycleOwner : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewTreeLifecycleOwner", typeof(ViewTreeLifecycleOwner));

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

	internal ViewTreeLifecycleOwner(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("get", "(Landroid/view/View;)Landroidx/lifecycle/LifecycleOwner;", "")]
	public unsafe static ILifecycleOwner? Get(View obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ILifecycleOwner>(_members.StaticMethods.InvokeObjectMethod("get.(Landroid/view/View;)Landroidx/lifecycle/LifecycleOwner;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	[Register("set", "(Landroid/view/View;Landroidx/lifecycle/LifecycleOwner;)V", "")]
	public unsafe static void Set(View obj, ILifecycleOwner? lifecycleOwner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((lifecycleOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycleOwner).Handle);
			_members.StaticMethods.InvokeVoidMethod("set.(Landroid/view/View;Landroidx/lifecycle/LifecycleOwner;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
			GC.KeepAlive(lifecycleOwner);
		}
	}
}
