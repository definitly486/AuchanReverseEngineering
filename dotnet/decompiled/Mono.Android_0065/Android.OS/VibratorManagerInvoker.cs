using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/VibratorManager", DoNotGenerateAcw = true, ApiSince = 31)]
[SupportedOSPlatform("android31.0")]
internal class VibratorManagerInvoker : VibratorManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/VibratorManager", typeof(VibratorManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android31.0")]
	public unsafe override Vibrator DefaultVibrator => Java.Lang.Object.GetObject<Vibrator>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultVibrator.()Landroid/os/Vibrator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public VibratorManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
