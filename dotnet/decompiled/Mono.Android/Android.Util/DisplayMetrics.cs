using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/DisplayMetrics", DoNotGenerateAcw = true)]
public class DisplayMetrics : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/DisplayMetrics", typeof(DisplayMetrics));

	[Register("density")]
	public float Density => _members.InstanceFields.GetSingleValue("density.F", this);

	[Register("heightPixels")]
	public int HeightPixels => _members.InstanceFields.GetInt32Value("heightPixels.I", this);

	[Register("scaledDensity")]
	[ObsoletedOSPlatform("android34.0")]
	public float ScaledDensity
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("scaledDensity.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("scaledDensity.F", this, value);
		}
	}

	[Register("widthPixels")]
	public int WidthPixels => _members.InstanceFields.GetInt32Value("widthPixels.I", this);

	[Register("xdpi")]
	public float Xdpi => _members.InstanceFields.GetSingleValue("xdpi.F", this);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected DisplayMetrics(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DisplayMetrics()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}
}
