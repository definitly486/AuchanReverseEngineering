using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Net;

[Register("android/net/ConnectivityManager", DoNotGenerateAcw = true)]
public class ConnectivityManager : Java.Lang.Object
{
	[Register("android/net/ConnectivityManager$NetworkCallback", DoNotGenerateAcw = true)]
	public class NetworkCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/ConnectivityManager$NetworkCallback", typeof(NetworkCallback));

		private static Delegate? cb_onAvailable_OnAvailable_Landroid_net_Network__V;

		private static Delegate? cb_onCapabilitiesChanged_OnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities__V;

		private static Delegate? cb_onLinkPropertiesChanged_OnLinkPropertiesChanged_Landroid_net_Network_Landroid_net_LinkProperties__V;

		private static Delegate? cb_onLosing_OnLosing_Landroid_net_Network_I_V;

		private static Delegate? cb_onLost_OnLost_Landroid_net_Network__V;

		private static Delegate? cb_onUnavailable_OnUnavailable_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NetworkCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NetworkCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAvailable_Landroid_net_Network_(nint jnienv, nint native__this, nint native_network)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				NetworkCallback? networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
				networkCallback.OnAvailable(network);
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

		[Register("onAvailable", "(Landroid/net/Network;)V", "GetOnAvailable_Landroid_net_Network_Handler")]
		public unsafe virtual void OnAvailable(Network network)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAvailable.(Landroid/net/Network;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(network);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities_(nint jnienv, nint native__this, nint native_network, nint native_networkCapabilities)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				NetworkCallback? networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
				NetworkCapabilities networkCapabilities = Java.Lang.Object.GetObject<NetworkCapabilities>(native_networkCapabilities, JniHandleOwnership.DoNotTransfer);
				networkCallback.OnCapabilitiesChanged(network, networkCapabilities);
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

		[Register("onCapabilitiesChanged", "(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V", "GetOnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities_Handler")]
		public unsafe virtual void OnCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(networkCapabilities?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCapabilitiesChanged.(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(network);
				GC.KeepAlive(networkCapabilities);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLinkPropertiesChanged_Landroid_net_Network_Landroid_net_LinkProperties_(nint jnienv, nint native__this, nint native_network, nint native_linkProperties)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				NetworkCallback? networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
				LinkProperties linkProperties = Java.Lang.Object.GetObject<LinkProperties>(native_linkProperties, JniHandleOwnership.DoNotTransfer);
				networkCallback.OnLinkPropertiesChanged(network, linkProperties);
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

		[Register("onLinkPropertiesChanged", "(Landroid/net/Network;Landroid/net/LinkProperties;)V", "GetOnLinkPropertiesChanged_Landroid_net_Network_Landroid_net_LinkProperties_Handler")]
		public unsafe virtual void OnLinkPropertiesChanged(Network network, LinkProperties linkProperties)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(linkProperties?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLinkPropertiesChanged.(Landroid/net/Network;Landroid/net/LinkProperties;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(network);
				GC.KeepAlive(linkProperties);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLosing_Landroid_net_Network_I(nint jnienv, nint native__this, nint native_network, int maxMsToLive)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				NetworkCallback? networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
				networkCallback.OnLosing(network, maxMsToLive);
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

		[Register("onLosing", "(Landroid/net/Network;I)V", "GetOnLosing_Landroid_net_Network_IHandler")]
		public unsafe virtual void OnLosing(Network network, int maxMsToLive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(maxMsToLive);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLosing.(Landroid/net/Network;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(network);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLost_Landroid_net_Network_(nint jnienv, nint native__this, nint native_network)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				NetworkCallback? networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
				networkCallback.OnLost(network);
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

		[Register("onLost", "(Landroid/net/Network;)V", "GetOnLost_Landroid_net_Network_Handler")]
		public unsafe virtual void OnLost(Network network)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLost.(Landroid/net/Network;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(network);
			}
		}

		[SupportedOSPlatform("android26.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnUnavailable(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<NetworkCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnUnavailable();
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
		[Register("onUnavailable", "()V", "GetOnUnavailableHandler", ApiSince = 26)]
		public unsafe virtual void OnUnavailable()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onUnavailable.()V", this, null);
		}

		[UnmanagedCallersOnly]
		private static void n_OnAvailable_Landroid_net_Network__mm_wrapper(nint jnienv, nint native__this, nint native_network)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAvailable_Landroid_net_Network_(jnienv, native__this, native_network);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLost_Landroid_net_Network__mm_wrapper(nint jnienv, nint native__this, nint native_network)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLost_Landroid_net_Network_(jnienv, native__this, native_network);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities__mm_wrapper(nint jnienv, nint native__this, nint native_network, nint native_networkCapabilities)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities_(jnienv, native__this, native_network, native_networkCapabilities);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnUnavailable_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnUnavailable(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLinkPropertiesChanged_Landroid_net_Network_Landroid_net_LinkProperties__mm_wrapper(nint jnienv, nint native__this, nint native_network, nint native_linkProperties)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLinkPropertiesChanged_Landroid_net_Network_Landroid_net_LinkProperties_(jnienv, native__this, native_network, native_linkProperties);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLosing_Landroid_net_Network_I_mm_wrapper(nint jnienv, nint native__this, nint native_network, int maxMsToLive)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLosing_Landroid_net_Network_I(jnienv, native__this, native_network, maxMsToLive);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/ConnectivityManager", typeof(ConnectivityManager));

	private static Delegate? cb_getAllNetworkInfo_GetAllNetworkInfo_arrayLandroid_net_NetworkInfo_;

	private static Delegate? cb_getAllNetworks_GetAllNetworks_arrayLandroid_net_Network_;

	private static Delegate? cb_getNetworkCapabilities_GetNetworkCapabilities_Landroid_net_Network__Landroid_net_NetworkCapabilities_;

	private static Delegate? cb_getNetworkInfo_GetNetworkInfo_Landroid_net_Network__Landroid_net_NetworkInfo_;

	private static Delegate? cb_registerNetworkCallback_RegisterNetworkCallback_Landroid_net_NetworkRequest_Landroid_net_ConnectivityManager_NetworkCallback__V;

	private static Delegate? cb_unregisterNetworkCallback_UnregisterNetworkCallback_Landroid_net_ConnectivityManager_NetworkCallback__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ConnectivityManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android23.0")]
	private static Delegate GetGetAllNetworkInfoHandler()
	{
		return new _JniMarshal_PP_L(n_GetAllNetworkInfo);
	}

	[ObsoletedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAllNetworkInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAllNetworkInfo());
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

	[ObsoletedOSPlatform("android23.0")]
	[RequiresPermission("android.permission.ACCESS_NETWORK_STATE")]
	public unsafe virtual NetworkInfo[] GetAllNetworkInfo()
	{
		return (NetworkInfo[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getAllNetworkInfo.()[Landroid/net/NetworkInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(NetworkInfo));
	}

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetGetAllNetworksHandler()
	{
		return new _JniMarshal_PP_L(n_GetAllNetworks);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAllNetworks(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAllNetworks());
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

	[ObsoletedOSPlatform("android31.0")]
	[RequiresPermission("android.permission.ACCESS_NETWORK_STATE")]
	public unsafe virtual Network[] GetAllNetworks()
	{
		return (Network[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getAllNetworks.()[Landroid/net/Network;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Network));
	}

	private static Delegate GetGetNetworkCapabilities_Landroid_net_Network_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetNetworkCapabilities_Landroid_net_Network_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNetworkCapabilities_Landroid_net_Network_(nint jnienv, nint native__this, nint native_network)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConnectivityManager? connectivityManager = Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectivityManager.GetNetworkCapabilities(network));
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

	[RequiresPermission("android.permission.ACCESS_NETWORK_STATE")]
	public unsafe virtual NetworkCapabilities? GetNetworkCapabilities(Network? network)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<NetworkCapabilities>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNetworkCapabilities.(Landroid/net/Network;)Landroid/net/NetworkCapabilities;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(network);
		}
	}

	[ObsoletedOSPlatform("android29.0")]
	private static Delegate GetGetNetworkInfo_Landroid_net_Network_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetNetworkInfo_Landroid_net_Network_);
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNetworkInfo_Landroid_net_Network_(nint jnienv, nint native__this, nint native_network)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConnectivityManager? connectivityManager = Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Network network = Java.Lang.Object.GetObject<Network>(native_network, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectivityManager.GetNetworkInfo(network));
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

	[ObsoletedOSPlatform("android29.0")]
	[RequiresPermission("android.permission.ACCESS_NETWORK_STATE")]
	public unsafe virtual NetworkInfo? GetNetworkInfo(Network? network)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(network?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<NetworkInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNetworkInfo.(Landroid/net/Network;)Landroid/net/NetworkInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(network);
		}
	}

	private static Delegate GetRegisterNetworkCallback_Landroid_net_NetworkRequest_Landroid_net_ConnectivityManager_NetworkCallback_Handler()
	{
		return new _JniMarshal_PPLL_V(n_RegisterNetworkCallback_Landroid_net_NetworkRequest_Landroid_net_ConnectivityManager_NetworkCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterNetworkCallback_Landroid_net_NetworkRequest_Landroid_net_ConnectivityManager_NetworkCallback_(nint jnienv, nint native__this, nint native_request, nint native_networkCallback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConnectivityManager? connectivityManager = Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkRequest request = Java.Lang.Object.GetObject<NetworkRequest>(native_request, JniHandleOwnership.DoNotTransfer);
			NetworkCallback networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(native_networkCallback, JniHandleOwnership.DoNotTransfer);
			connectivityManager.RegisterNetworkCallback(request, networkCallback);
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

	[RequiresPermission("android.permission.ACCESS_NETWORK_STATE")]
	public unsafe virtual void RegisterNetworkCallback(NetworkRequest request, NetworkCallback networkCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(networkCallback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerNetworkCallback.(Landroid/net/NetworkRequest;Landroid/net/ConnectivityManager$NetworkCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(networkCallback);
		}
	}

	private static Delegate GetUnregisterNetworkCallback_Landroid_net_ConnectivityManager_NetworkCallback_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterNetworkCallback_Landroid_net_ConnectivityManager_NetworkCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterNetworkCallback_Landroid_net_ConnectivityManager_NetworkCallback_(nint jnienv, nint native__this, nint native_networkCallback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConnectivityManager? connectivityManager = Java.Lang.Object.GetObject<ConnectivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkCallback networkCallback = Java.Lang.Object.GetObject<NetworkCallback>(native_networkCallback, JniHandleOwnership.DoNotTransfer);
			connectivityManager.UnregisterNetworkCallback(networkCallback);
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

	public unsafe virtual void UnregisterNetworkCallback(NetworkCallback networkCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(networkCallback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterNetworkCallback.(Landroid/net/ConnectivityManager$NetworkCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(networkCallback);
		}
	}
}
