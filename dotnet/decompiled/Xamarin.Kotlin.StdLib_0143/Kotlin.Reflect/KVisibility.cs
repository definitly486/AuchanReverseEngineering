using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KVisibility", DoNotGenerateAcw = true)]
public sealed class KVisibility : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("kotlin/reflect/KVisibility", typeof(KVisibility));

	[Register("INTERNAL")]
	public static KVisibility? Internal => Java.Lang.Object.GetObject<KVisibility>(_members.StaticFields.GetObjectValue("INTERNAL.Lkotlin/reflect/KVisibility;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PRIVATE")]
	public static KVisibility? Private => Java.Lang.Object.GetObject<KVisibility>(_members.StaticFields.GetObjectValue("PRIVATE.Lkotlin/reflect/KVisibility;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PROTECTED")]
	public static KVisibility? Protected => Java.Lang.Object.GetObject<KVisibility>(_members.StaticFields.GetObjectValue("PROTECTED.Lkotlin/reflect/KVisibility;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PUBLIC")]
	public static KVisibility? Public => Java.Lang.Object.GetObject<KVisibility>(_members.StaticFields.GetObjectValue("PUBLIC.Lkotlin/reflect/KVisibility;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal KVisibility(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lkotlin/reflect/KVisibility;", "")]
	public unsafe static KVisibility? ValueOf(string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KVisibility>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlin/reflect/KVisibility;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lkotlin/reflect/KVisibility;", "")]
	public unsafe static KVisibility[]? Values()
	{
		return (KVisibility[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlin/reflect/KVisibility;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(KVisibility));
	}
}
