using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.View.Transform;

[Register("androidx/camera/view/transform/OutputTransform", DoNotGenerateAcw = true)]
public sealed class OutputTransform : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/transform/OutputTransform", typeof(OutputTransform));

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

	public unsafe Matrix Matrix
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getMatrix", "()Landroid/graphics/Matrix;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal OutputTransform(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/graphics/Matrix;Landroid/util/Size;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe OutputTransform(Matrix matrix, Size viewPortSize)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(viewPortSize?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Matrix;Landroid/util/Size;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Matrix;Landroid/util/Size;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(matrix);
			GC.KeepAlive(viewPortSize);
		}
	}
}
