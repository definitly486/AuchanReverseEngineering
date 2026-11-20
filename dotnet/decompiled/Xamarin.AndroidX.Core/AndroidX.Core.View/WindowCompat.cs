using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowCompat", DoNotGenerateAcw = true)]
public sealed class WindowCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowCompat", typeof(WindowCompat));

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

	internal WindowCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getInsetsController", "(Landroid/view/Window;Landroid/view/View;)Landroidx/core/view/WindowInsetsControllerCompat;", "")]
	public unsafe static WindowInsetsControllerCompat? GetInsetsController(Window? window, Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(window?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsControllerCompat>(_members.StaticMethods.InvokeObjectMethod("getInsetsController.(Landroid/view/Window;Landroid/view/View;)Landroidx/core/view/WindowInsetsControllerCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(window);
			GC.KeepAlive(view);
		}
	}

	[Register("requireViewById", "(Landroid/view/Window;I)Landroid/view/View;", "")]
	[JavaTypeParameters(new string[] { "T extends android.view.View" })]
	public unsafe static Java.Lang.Object? RequireViewById(Window? window, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(window?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("requireViewById.(Landroid/view/Window;I)Landroid/view/View;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(window);
		}
	}

	[Register("setDecorFitsSystemWindows", "(Landroid/view/Window;Z)V", "")]
	public unsafe static void SetDecorFitsSystemWindows(Window? window, bool decorFitsSystemWindows)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(window?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(decorFitsSystemWindows ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setDecorFitsSystemWindows.(Landroid/view/Window;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(window);
		}
	}
}
