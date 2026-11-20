using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[SupportedOSPlatform("android31.0")]
[Register("android/os/VibratorManager", DoNotGenerateAcw = true, ApiSince = 31)]
public abstract class VibratorManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/VibratorManager", typeof(VibratorManager));

	private static Delegate? cb_getDefaultVibrator_GetDefaultVibrator_Landroid_os_Vibrator_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract Vibrator DefaultVibrator
	{
		[SupportedOSPlatform("android31.0")]
		get;
	}

	protected VibratorManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetGetDefaultVibratorHandler()
	{
		return new _JniMarshal_PP_L(n_GetDefaultVibrator);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultVibrator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<VibratorManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultVibrator);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}
}
