using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/OffsetEdgeTreatment", DoNotGenerateAcw = true)]
public sealed class OffsetEdgeTreatment : EdgeTreatment
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/OffsetEdgeTreatment", typeof(OffsetEdgeTreatment));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal OffsetEdgeTreatment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/google/android/material/shape/EdgeTreatment;F)V", "")]
	public unsafe OffsetEdgeTreatment(EdgeTreatment other, float offset)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(offset);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/EdgeTreatment;F)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/EdgeTreatment;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}
}
