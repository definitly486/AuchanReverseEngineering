using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Vibrator", DoNotGenerateAcw = true)]
public abstract class Vibrator : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Vibrator", typeof(Vibrator));

	private static Delegate? cb_vibrate_Vibrate_Landroid_os_VibrationEffect__V;

	private static Delegate? cb_vibrate_Vibrate_J_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Vibrator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetVibrate_Landroid_os_VibrationEffect_Handler()
	{
		return new _JniMarshal_PPL_V(n_Vibrate_Landroid_os_VibrationEffect_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Vibrate_Landroid_os_VibrationEffect_(nint jnienv, nint native__this, nint native_vibe)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Vibrator? vibrator = Java.Lang.Object.GetObject<Vibrator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			VibrationEffect vibe = Java.Lang.Object.GetObject<VibrationEffect>(native_vibe, JniHandleOwnership.DoNotTransfer);
			vibrator.Vibrate(vibe);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android26.0")]
	[Register("vibrate", "(Landroid/os/VibrationEffect;)V", "GetVibrate_Landroid_os_VibrationEffect_Handler", ApiSince = 26)]
	[RequiresPermission("android.permission.VIBRATE")]
	public unsafe virtual void Vibrate(VibrationEffect? vibe)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(vibe?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("vibrate.(Landroid/os/VibrationEffect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(vibe);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	private static Delegate GetVibrate_JHandler()
	{
		return new _JniMarshal_PPJ_V(n_Vibrate_J);
	}

	[ObsoletedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Vibrate_J(nint jnienv, nint native__this, long milliseconds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Vibrator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Vibrate(milliseconds);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	[Register("vibrate", "(J)V", "GetVibrate_JHandler")]
	[RequiresPermission("android.permission.VIBRATE")]
	public unsafe virtual void Vibrate(long milliseconds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(milliseconds);
		_members.InstanceMethods.InvokeVirtualVoidMethod("vibrate.(J)V", this, ptr);
	}
}
