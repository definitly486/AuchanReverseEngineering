using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Content;

[Register("androidx/core/content/LocusIdCompat", DoNotGenerateAcw = true)]
public sealed class LocusIdCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/LocusIdCompat", typeof(LocusIdCompat));

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

	public unsafe string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal LocusIdCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe LocusIdCompat(string? id)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("toLocusId", "()Landroid/content/LocusId;", "")]
	public unsafe LocusId? ToLocusId()
	{
		return Java.Lang.Object.GetObject<LocusId>(_members.InstanceMethods.InvokeAbstractObjectMethod("toLocusId.()Landroid/content/LocusId;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toLocusIdCompat", "(Landroid/content/LocusId;)Landroidx/core/content/LocusIdCompat;", "")]
	public unsafe static LocusIdCompat? ToLocusIdCompat(LocusId? locusId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locusId?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocusIdCompat>(_members.StaticMethods.InvokeObjectMethod("toLocusIdCompat.(Landroid/content/LocusId;)Landroidx/core/content/LocusIdCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(locusId);
		}
	}
}
