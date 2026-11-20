using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsets", DoNotGenerateAcw = true)]
public sealed class WindowInsets : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowInsets", typeof(WindowInsets));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[ObsoletedOSPlatform("android30.0")]
	public unsafe int SystemWindowInsetBottom
	{
		[Register("getSystemWindowInsetBottom", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSystemWindowInsetBottom.()I", this, null);
		}
	}

	[ObsoletedOSPlatform("android30.0")]
	public unsafe int SystemWindowInsetTop
	{
		[Register("getSystemWindowInsetTop", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSystemWindowInsetTop.()I", this, null);
		}
	}

	internal WindowInsets(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
