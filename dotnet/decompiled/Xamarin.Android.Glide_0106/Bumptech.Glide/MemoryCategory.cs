using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/MemoryCategory", DoNotGenerateAcw = true)]
public sealed class MemoryCategory : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/MemoryCategory", typeof(MemoryCategory));

	[Register("HIGH")]
	public static MemoryCategory? High => Java.Lang.Object.GetObject<MemoryCategory>(_members.StaticFields.GetObjectValue("HIGH.Lcom/bumptech/glide/MemoryCategory;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LOW")]
	public static MemoryCategory? Low => Java.Lang.Object.GetObject<MemoryCategory>(_members.StaticFields.GetObjectValue("LOW.Lcom/bumptech/glide/MemoryCategory;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NORMAL")]
	public static MemoryCategory? Normal => Java.Lang.Object.GetObject<MemoryCategory>(_members.StaticFields.GetObjectValue("NORMAL.Lcom/bumptech/glide/MemoryCategory;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe float Multiplier
	{
		[Register("getMultiplier", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getMultiplier.()F", this, null);
		}
	}

	internal MemoryCategory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/MemoryCategory;", "")]
	public unsafe static MemoryCategory? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<MemoryCategory>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/MemoryCategory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/MemoryCategory;", "")]
	public unsafe static MemoryCategory[]? Values()
	{
		return (MemoryCategory[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/MemoryCategory;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MemoryCategory));
	}
}
