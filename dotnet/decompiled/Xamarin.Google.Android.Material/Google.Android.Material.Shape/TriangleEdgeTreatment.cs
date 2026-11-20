using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/TriangleEdgeTreatment", DoNotGenerateAcw = true)]
public class TriangleEdgeTreatment : EdgeTreatment
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/TriangleEdgeTreatment", typeof(TriangleEdgeTreatment));

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

	protected TriangleEdgeTreatment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(FZ)V", "")]
	public unsafe TriangleEdgeTreatment(float size, bool inside)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue(inside ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FZ)V", this, ptr);
		}
	}
}
