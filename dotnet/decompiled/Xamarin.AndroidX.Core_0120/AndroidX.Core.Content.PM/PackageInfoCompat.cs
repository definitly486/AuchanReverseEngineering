using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content.PM;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Content.PM;

[Register("androidx/core/content/pm/PackageInfoCompat", DoNotGenerateAcw = true)]
public sealed class PackageInfoCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/pm/PackageInfoCompat", typeof(PackageInfoCompat));

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

	internal PackageInfoCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getLongVersionCode", "(Landroid/content/pm/PackageInfo;)J", "")]
	public unsafe static long GetLongVersionCode(PackageInfo? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt64Method("getLongVersionCode.(Landroid/content/pm/PackageInfo;)J", ptr);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	[Register("getSignatures", "(Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/util/List;", "")]
	public unsafe static IList<Signature>? GetSignatures(PackageManager? packageManager, string? packageName)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(packageManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return JavaList<Signature>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getSignatures.(Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(packageManager);
		}
	}

	[Register("hasSignatures", "(Landroid/content/pm/PackageManager;Ljava/lang/String;Ljava/util/Map;Z)Z", "")]
	public unsafe static bool HasSignatures(PackageManager? packageManager, string? packageName, IDictionary<byte[], Integer>? certificatesAndType, bool matchExact)
	{
		nint num = JNIEnv.NewString(packageName);
		nint num2 = JavaDictionary<byte[], Integer>.ToLocalJniHandle(certificatesAndType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(packageManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(matchExact ? ((sbyte)1) : ((sbyte)0));
			return _members.StaticMethods.InvokeBooleanMethod("hasSignatures.(Landroid/content/pm/PackageManager;Ljava/lang/String;Ljava/util/Map;Z)Z", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(packageManager);
			GC.KeepAlive(certificatesAndType);
		}
	}
}
