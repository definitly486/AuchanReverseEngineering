using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewOutlineProvider", DoNotGenerateAcw = true)]
public abstract class ViewOutlineProvider : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewOutlineProvider", typeof(ViewOutlineProvider));

	private static Delegate? cb_getOutline_GetOutline_Landroid_view_View_Landroid_graphics_Outline__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ViewOutlineProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe ViewOutlineProvider()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetOutline_Landroid_view_View_Landroid_graphics_Outline_(nint jnienv, nint native__this, nint native_view, nint native_outline)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewOutlineProvider? viewOutlineProvider = Java.Lang.Object.GetObject<ViewOutlineProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Outline outline = Java.Lang.Object.GetObject<Outline>(native_outline, JniHandleOwnership.DoNotTransfer);
			viewOutlineProvider.GetOutline(view, outline);
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

	public abstract void GetOutline(View? view, Outline? outline);

	[UnmanagedCallersOnly]
	private static void n_GetOutline_Landroid_view_View_Landroid_graphics_Outline__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_outline)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_GetOutline_Landroid_view_View_Landroid_graphics_Outline_(jnienv, native__this, native_view, native_outline);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
