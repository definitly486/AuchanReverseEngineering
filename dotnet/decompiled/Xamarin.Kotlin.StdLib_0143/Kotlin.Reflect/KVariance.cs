using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KVariance", DoNotGenerateAcw = true)]
public sealed class KVariance : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("kotlin/reflect/KVariance", typeof(KVariance));

	[Register("IN")]
	public static KVariance? In => Java.Lang.Object.GetObject<KVariance>(_members.StaticFields.GetObjectValue("IN.Lkotlin/reflect/KVariance;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INVARIANT")]
	public static KVariance? Invariant => Java.Lang.Object.GetObject<KVariance>(_members.StaticFields.GetObjectValue("INVARIANT.Lkotlin/reflect/KVariance;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OUT")]
	public static KVariance? Out => Java.Lang.Object.GetObject<KVariance>(_members.StaticFields.GetObjectValue("OUT.Lkotlin/reflect/KVariance;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe static IEnumEntries Entries
	{
		[Register("getEntries", "()Lkotlin/enums/EnumEntries;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IEnumEntries>(_members.StaticMethods.InvokeObjectMethod("getEntries.()Lkotlin/enums/EnumEntries;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal KVariance(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lkotlin/reflect/KVariance;", "")]
	public unsafe static KVariance? ValueOf(string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KVariance>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlin/reflect/KVariance;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lkotlin/reflect/KVariance;", "")]
	public unsafe static KVariance[]? Values()
	{
		return (KVariance[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlin/reflect/KVariance;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(KVariance));
	}
}
