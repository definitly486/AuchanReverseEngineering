using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Net.Wifi;

[Register("android/net/wifi/WifiManager", DoNotGenerateAcw = true)]
public class WifiManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/wifi/WifiManager", typeof(WifiManager));

	private static Delegate? cb_getConnectionInfo_GetConnectionInfo_Landroid_net_wifi_WifiInfo_;

	private static Delegate? cb_isWifiEnabled_IsWifiEnabled_Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[ObsoletedOSPlatform("android31.0")]
	public unsafe virtual WifiInfo? ConnectionInfo => Java.Lang.Object.GetObject<WifiInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConnectionInfo.()Landroid/net/wifi/WifiInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual bool IsWifiEnabled => _members.InstanceMethods.InvokeVirtualBooleanMethod("isWifiEnabled.()Z", this, null);

	public static WifiManager? FromContext(Context context)
	{
		return context.GetSystemService("wifi") as WifiManager;
	}

	protected WifiManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetGetConnectionInfoHandler()
	{
		return new _JniMarshal_PP_L(n_GetConnectionInfo);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConnectionInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WifiManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConnectionInfo);
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

	private static Delegate GetIsWifiEnabledHandler()
	{
		return new _JniMarshal_PP_B(n_IsWifiEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsWifiEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WifiManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsWifiEnabled ? ((sbyte)1) : ((sbyte)0);
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
