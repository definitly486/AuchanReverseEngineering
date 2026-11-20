using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/DataSource", DoNotGenerateAcw = true)]
public sealed class DataSource : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/DataSource", typeof(DataSource));

	[Register("DATA_DISK_CACHE")]
	public static DataSource? DataDiskCache => Java.Lang.Object.GetObject<DataSource>(_members.StaticFields.GetObjectValue("DATA_DISK_CACHE.Lcom/bumptech/glide/load/DataSource;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LOCAL")]
	public static DataSource? Local => Java.Lang.Object.GetObject<DataSource>(_members.StaticFields.GetObjectValue("LOCAL.Lcom/bumptech/glide/load/DataSource;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MEMORY_CACHE")]
	public static DataSource? MemoryCache => Java.Lang.Object.GetObject<DataSource>(_members.StaticFields.GetObjectValue("MEMORY_CACHE.Lcom/bumptech/glide/load/DataSource;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("REMOTE")]
	public static DataSource? Remote => Java.Lang.Object.GetObject<DataSource>(_members.StaticFields.GetObjectValue("REMOTE.Lcom/bumptech/glide/load/DataSource;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RESOURCE_DISK_CACHE")]
	public static DataSource? ResourceDiskCache => Java.Lang.Object.GetObject<DataSource>(_members.StaticFields.GetObjectValue("RESOURCE_DISK_CACHE.Lcom/bumptech/glide/load/DataSource;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal DataSource(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/load/DataSource;", "")]
	public unsafe static DataSource? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DataSource>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/load/DataSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/load/DataSource;", "")]
	public unsafe static DataSource[]? Values()
	{
		return (DataSource[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/load/DataSource;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DataSource));
	}
}
