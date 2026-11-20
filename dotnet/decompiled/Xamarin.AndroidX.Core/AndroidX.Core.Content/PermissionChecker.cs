using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Content;

[Register("androidx/core/content/PermissionChecker", DoNotGenerateAcw = true)]
public sealed class PermissionChecker : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/PermissionChecker", typeof(PermissionChecker));

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

	internal PermissionChecker(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("checkCallingOrSelfPermission", "(Landroid/content/Context;Ljava/lang/String;)I", "")]
	public unsafe static int CheckCallingOrSelfPermission(Context? context, string? permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeInt32Method("checkCallingOrSelfPermission.(Landroid/content/Context;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("checkCallingPermission", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)I", "")]
	public unsafe static int CheckCallingPermission(Context? context, string? permission, string? packageName)
	{
		nint num = JNIEnv.NewString(permission);
		nint num2 = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("checkCallingPermission.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(context);
		}
	}

	[Register("checkPermission", "(Landroid/content/Context;Ljava/lang/String;IILjava/lang/String;)I", "")]
	public unsafe static int CheckPermission(Context? context, string? permission, int pid, int uid, string? packageName)
	{
		nint num = JNIEnv.NewString(permission);
		nint num2 = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(pid);
			ptr[3] = new JniArgumentValue(uid);
			ptr[4] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("checkPermission.(Landroid/content/Context;Ljava/lang/String;IILjava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(context);
		}
	}

	[Register("checkSelfPermission", "(Landroid/content/Context;Ljava/lang/String;)I", "")]
	public unsafe static int CheckSelfPermission(Context? context, string? permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeInt32Method("checkSelfPermission.(Landroid/content/Context;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}
}
