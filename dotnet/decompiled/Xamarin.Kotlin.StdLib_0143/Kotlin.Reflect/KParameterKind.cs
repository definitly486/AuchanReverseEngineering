using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KParameter$Kind", DoNotGenerateAcw = true)]
public sealed class KParameterKind : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("kotlin/reflect/KParameter$Kind", typeof(KParameterKind));

	[Register("CONTEXT")]
	public static KParameterKind? Context => Java.Lang.Object.GetObject<KParameterKind>(_members.StaticFields.GetObjectValue("CONTEXT.Lkotlin/reflect/KParameter$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EXTENSION_RECEIVER")]
	public static KParameterKind? ExtensionReceiver => Java.Lang.Object.GetObject<KParameterKind>(_members.StaticFields.GetObjectValue("EXTENSION_RECEIVER.Lkotlin/reflect/KParameter$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INSTANCE")]
	public static KParameterKind? Instance => Java.Lang.Object.GetObject<KParameterKind>(_members.StaticFields.GetObjectValue("INSTANCE.Lkotlin/reflect/KParameter$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VALUE")]
	public static KParameterKind? Value => Java.Lang.Object.GetObject<KParameterKind>(_members.StaticFields.GetObjectValue("VALUE.Lkotlin/reflect/KParameter$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal KParameterKind(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lkotlin/reflect/KParameter$Kind;", "")]
	public unsafe static KParameterKind? ValueOf(string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KParameterKind>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlin/reflect/KParameter$Kind;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lkotlin/reflect/KParameter$Kind;", "")]
	public unsafe static KParameterKind[]? Values()
	{
		return (KParameterKind[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlin/reflect/KParameter$Kind;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(KParameterKind));
	}
}
