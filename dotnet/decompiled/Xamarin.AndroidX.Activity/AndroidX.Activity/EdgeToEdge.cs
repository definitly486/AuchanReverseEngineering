using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/EdgeToEdge", DoNotGenerateAcw = true)]
public sealed class EdgeToEdge : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/EdgeToEdge", typeof(EdgeToEdge));

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

	public unsafe static int DefaultDarkScrim
	{
		[Register("getDefaultDarkScrim", "()I", "")]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getDefaultDarkScrim.()I", null);
		}
	}

	public unsafe static int DefaultLightScrim
	{
		[Register("getDefaultLightScrim", "()I", "")]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getDefaultLightScrim.()I", null);
		}
	}

	internal EdgeToEdge(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("enable", "(Landroidx/activity/ComponentActivity;)V", "")]
	public unsafe static void Enable(ComponentActivity obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("enable.(Landroidx/activity/ComponentActivity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	[Register("enable", "(Landroidx/activity/ComponentActivity;Landroidx/activity/SystemBarStyle;)V", "")]
	public unsafe static void Enable(ComponentActivity obj, SystemBarStyle statusBarStyle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(statusBarStyle?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("enable.(Landroidx/activity/ComponentActivity;Landroidx/activity/SystemBarStyle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
			GC.KeepAlive(statusBarStyle);
		}
	}

	[Register("enable", "(Landroidx/activity/ComponentActivity;Landroidx/activity/SystemBarStyle;Landroidx/activity/SystemBarStyle;)V", "")]
	public unsafe static void Enable(ComponentActivity obj, SystemBarStyle statusBarStyle, SystemBarStyle navigationBarStyle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(statusBarStyle?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(navigationBarStyle?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("enable.(Landroidx/activity/ComponentActivity;Landroidx/activity/SystemBarStyle;Landroidx/activity/SystemBarStyle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
			GC.KeepAlive(statusBarStyle);
			GC.KeepAlive(navigationBarStyle);
		}
	}
}
