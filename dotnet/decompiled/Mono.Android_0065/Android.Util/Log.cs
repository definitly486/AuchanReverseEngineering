using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/Log", DoNotGenerateAcw = true)]
public sealed class Log : Java.Lang.Object
{
	[CompilerGenerated]
	private static IFormatProvider _003CFormatProvider_003Ek__BackingField = CultureInfo.CurrentCulture;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/Log", typeof(Log));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal Log(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static int Debug(string? tag, string msg)
	{
		nint num = JNIEnv.NewString(tag);
		nint num2 = JNIEnv.NewString(msg);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("d.(Ljava/lang/String;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe static int Error(string? tag, string msg)
	{
		nint num = JNIEnv.NewString(tag);
		nint num2 = JNIEnv.NewString(msg);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("e.(Ljava/lang/String;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe static int Info(string? tag, string msg)
	{
		nint num = JNIEnv.NewString(tag);
		nint num2 = JNIEnv.NewString(msg);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("i.(Ljava/lang/String;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}
