using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Jvm.Functions;

namespace AndroidX.Activity;

[Register("androidx/activity/SystemBarStyle", DoNotGenerateAcw = true)]
public sealed class SystemBarStyle : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/SystemBarStyle", typeof(SystemBarStyle));

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

	internal SystemBarStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("auto", "(II)Landroidx/activity/SystemBarStyle;", "")]
	public unsafe static SystemBarStyle Auto(int lightScrim, int darkScrim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(lightScrim);
		ptr[1] = new JniArgumentValue(darkScrim);
		return Java.Lang.Object.GetObject<SystemBarStyle>(_members.StaticMethods.InvokeObjectMethod("auto.(II)Landroidx/activity/SystemBarStyle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("auto", "(IILkotlin/jvm/functions/Function1;)Landroidx/activity/SystemBarStyle;", "")]
	public unsafe static SystemBarStyle Auto(int lightScrim, int darkScrim, IFunction1 detectDarkMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(lightScrim);
			ptr[1] = new JniArgumentValue(darkScrim);
			ptr[2] = new JniArgumentValue((detectDarkMode == null) ? IntPtr.Zero : ((Java.Lang.Object)detectDarkMode).Handle);
			return Java.Lang.Object.GetObject<SystemBarStyle>(_members.StaticMethods.InvokeObjectMethod("auto.(IILkotlin/jvm/functions/Function1;)Landroidx/activity/SystemBarStyle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(detectDarkMode);
		}
	}

	[Register("dark", "(I)Landroidx/activity/SystemBarStyle;", "")]
	public unsafe static SystemBarStyle Dark(int scrim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(scrim);
		return Java.Lang.Object.GetObject<SystemBarStyle>(_members.StaticMethods.InvokeObjectMethod("dark.(I)Landroidx/activity/SystemBarStyle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("light", "(II)Landroidx/activity/SystemBarStyle;", "")]
	public unsafe static SystemBarStyle Light(int scrim, int darkScrim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(scrim);
		ptr[1] = new JniArgumentValue(darkScrim);
		return Java.Lang.Object.GetObject<SystemBarStyle>(_members.StaticMethods.InvokeObjectMethod("light.(II)Landroidx/activity/SystemBarStyle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
