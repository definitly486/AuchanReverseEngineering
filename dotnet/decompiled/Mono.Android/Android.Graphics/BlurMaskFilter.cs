using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/BlurMaskFilter", DoNotGenerateAcw = true)]
public class BlurMaskFilter : MaskFilter
{
	[Register("android/graphics/BlurMaskFilter$Blur", DoNotGenerateAcw = true)]
	public sealed class Blur : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/BlurMaskFilter$Blur", typeof(Blur));

		[Register("NORMAL")]
		public static Blur? Normal => Java.Lang.Object.GetObject<Blur>(_members.StaticFields.GetObjectValue("NORMAL.Landroid/graphics/BlurMaskFilter$Blur;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Blur(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/BlurMaskFilter", typeof(BlurMaskFilter));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BlurMaskFilter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(FLandroid/graphics/BlurMaskFilter$Blur;)V", "")]
	public unsafe BlurMaskFilter(float radius, Blur? style)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(radius);
			ptr[1] = new JniArgumentValue(style?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FLandroid/graphics/BlurMaskFilter$Blur;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FLandroid/graphics/BlurMaskFilter$Blur;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(style);
		}
	}
}
