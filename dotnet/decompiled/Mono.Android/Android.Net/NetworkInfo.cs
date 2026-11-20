using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Net;

[ObsoletedOSPlatform("android29.0", "This class is obsoleted in this android platform")]
[Register("android/net/NetworkInfo", DoNotGenerateAcw = true)]
public class NetworkInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/NetworkInfo", typeof(NetworkInfo));

	private static Delegate? cb_isAvailable_IsAvailable_Z;

	private static Delegate? cb_isConnected_IsConnected_Z;

	private static Delegate? cb_isConnectedOrConnecting_IsConnectedOrConnecting_Z;

	private static Delegate? cb_getType_GetType_I;

	private static Delegate? cb_getTypeName_GetTypeName_Ljava_lang_String_;

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[ObsoletedOSPlatform("android28.0")]
	public unsafe virtual bool IsAvailable
	{
		[Register("isAvailable", "()Z", "GetIsAvailableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAvailable.()Z", this, null);
		}
	}

	[ObsoletedOSPlatform("android29.0")]
	public unsafe virtual bool IsConnected
	{
		[Register("isConnected", "()Z", "GetIsConnectedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnected.()Z", this, null);
		}
	}

	[ObsoletedOSPlatform("android28.0")]
	public unsafe virtual bool IsConnectedOrConnecting
	{
		[Register("isConnectedOrConnecting", "()Z", "GetIsConnectedOrConnectingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnectedOrConnecting.()Z", this, null);
		}
	}

	[ObsoletedOSPlatform("android28.0")]
	public unsafe virtual ConnectivityType Type
	{
		[Register("getType", "()I", "GetGetTypeHandler")]
		get
		{
			return (ConnectivityType)_members.InstanceMethods.InvokeVirtualInt32Method("getType.()I", this, null);
		}
	}

	[ObsoletedOSPlatform("android28.0")]
	public unsafe virtual string? TypeName
	{
		[Register("getTypeName", "()Ljava/lang/String;", "GetGetTypeNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTypeName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected NetworkInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android28.0")]
	private static Delegate GetIsAvailableHandler()
	{
		return new _JniMarshal_PP_B(n_IsAvailable);
	}

	[ObsoletedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAvailable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAvailable ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetIsConnectedHandler()
	{
		return new _JniMarshal_PP_B(n_IsConnected);
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConnected(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnected ? ((sbyte)1) : ((sbyte)0);
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

	[ObsoletedOSPlatform("android28.0")]
	private static Delegate GetIsConnectedOrConnectingHandler()
	{
		return new _JniMarshal_PP_B(n_IsConnectedOrConnecting);
	}

	[ObsoletedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConnectedOrConnecting(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnectedOrConnecting ? ((sbyte)1) : ((sbyte)0);
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

	[ObsoletedOSPlatform("android28.0")]
	private static Delegate GetGetTypeHandler()
	{
		return new _JniMarshal_PP_I(n_GetType);
	}

	[ObsoletedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type;
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

	[ObsoletedOSPlatform("android28.0")]
	private static Delegate GetGetTypeNameHandler()
	{
		return new _JniMarshal_PP_L(n_GetTypeName);
	}

	[ObsoletedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTypeName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TypeName);
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
	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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
	[Register("describeContents", "()I", "GetDescribeContentsHandler")]
	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	[ObsoletedOSPlatform("android29.0")]
	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_dest, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NetworkInfo? networkInfo = Java.Lang.Object.GetObject<NetworkInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			networkInfo.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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

	[ObsoletedOSPlatform("android29.0")]
	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public unsafe virtual void WriteToParcel(Parcel? dest, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
