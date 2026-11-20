using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[Register("android/location/Location", DoNotGenerateAcw = true)]
public class Location : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/location/Location", typeof(Location));

	private static Delegate? cb_getAccuracy_GetAccuracy_F;

	private static Delegate? cb_getAltitude_GetAltitude_D;

	private static Delegate? cb_getBearing_GetBearing_F;

	private static Delegate? cb_hasAccuracy_HasAccuracy_Z;

	private static Delegate? cb_hasAltitude_HasAltitude_Z;

	private static Delegate? cb_hasBearing_HasBearing_Z;

	private static Delegate? cb_hasSpeed_HasSpeed_Z;

	private static Delegate? cb_hasVerticalAccuracy_HasVerticalAccuracy_Z;

	private static Delegate? cb_isFromMockProvider_IsFromMockProvider_Z;

	private static Delegate? cb_getLatitude_GetLatitude_D;

	private static Delegate? cb_getLongitude_GetLongitude_D;

	private static Delegate? cb_isMock_IsMock_Z;

	private static Delegate? cb_getProvider_GetProvider_Ljava_lang_String_;

	private static Delegate? cb_getSpeed_GetSpeed_F;

	private static Delegate? cb_getTime_GetTime_J;

	private static Delegate? cb_getVerticalAccuracyMeters_GetVerticalAccuracyMeters_F;

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

	public unsafe virtual float Accuracy => _members.InstanceMethods.InvokeVirtualSingleMethod("getAccuracy.()F", this, null);

	public unsafe virtual double Altitude => _members.InstanceMethods.InvokeVirtualDoubleMethod("getAltitude.()D", this, null);

	public unsafe virtual float Bearing => _members.InstanceMethods.InvokeVirtualSingleMethod("getBearing.()F", this, null);

	public unsafe virtual bool HasAccuracy => _members.InstanceMethods.InvokeVirtualBooleanMethod("hasAccuracy.()Z", this, null);

	public unsafe virtual bool HasAltitude => _members.InstanceMethods.InvokeVirtualBooleanMethod("hasAltitude.()Z", this, null);

	public unsafe virtual bool HasBearing => _members.InstanceMethods.InvokeVirtualBooleanMethod("hasBearing.()Z", this, null);

	public unsafe virtual bool HasSpeed => _members.InstanceMethods.InvokeVirtualBooleanMethod("hasSpeed.()Z", this, null);

	[SupportedOSPlatform("android26.0")]
	public unsafe virtual bool HasVerticalAccuracy => _members.InstanceMethods.InvokeVirtualBooleanMethod("hasVerticalAccuracy.()Z", this, null);

	[ObsoletedOSPlatform("android31.0")]
	public unsafe virtual bool IsFromMockProvider => _members.InstanceMethods.InvokeVirtualBooleanMethod("isFromMockProvider.()Z", this, null);

	public unsafe virtual double Latitude => _members.InstanceMethods.InvokeVirtualDoubleMethod("getLatitude.()D", this, null);

	public unsafe virtual double Longitude => _members.InstanceMethods.InvokeVirtualDoubleMethod("getLongitude.()D", this, null);

	[SupportedOSPlatform("android31.0")]
	public unsafe virtual bool Mock => _members.InstanceMethods.InvokeVirtualBooleanMethod("isMock.()Z", this, null);

	public unsafe virtual string? Provider => JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getProvider.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual float Speed => _members.InstanceMethods.InvokeVirtualSingleMethod("getSpeed.()F", this, null);

	public unsafe virtual long Time => _members.InstanceMethods.InvokeVirtualInt64Method("getTime.()J", this, null);

	[SupportedOSPlatform("android26.0")]
	public unsafe virtual float VerticalAccuracyMeters => _members.InstanceMethods.InvokeVirtualSingleMethod("getVerticalAccuracyMeters.()F", this, null);

	protected Location(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Location(Location location)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/location/Location;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/location/Location;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(location);
		}
	}

	public unsafe Location(string? provider)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetAccuracyHandler()
	{
		return new _JniMarshal_PP_F(n_GetAccuracy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAccuracy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Accuracy;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetAltitudeHandler()
	{
		return new _JniMarshal_PP_D(n_GetAltitude);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetAltitude(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Altitude;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBearingHandler()
	{
		return new _JniMarshal_PP_F(n_GetBearing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBearing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bearing;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasAccuracyHandler()
	{
		return new _JniMarshal_PP_B(n_HasAccuracy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasAccuracy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasAccuracy ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasAltitudeHandler()
	{
		return new _JniMarshal_PP_B(n_HasAltitude);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasAltitude(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasAltitude ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasBearingHandler()
	{
		return new _JniMarshal_PP_B(n_HasBearing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasBearing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBearing ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasSpeedHandler()
	{
		return new _JniMarshal_PP_B(n_HasSpeed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasSpeed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSpeed ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetHasVerticalAccuracyHandler()
	{
		return new _JniMarshal_PP_B(n_HasVerticalAccuracy);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasVerticalAccuracy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasVerticalAccuracy ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetIsFromMockProviderHandler()
	{
		return new _JniMarshal_PP_B(n_IsFromMockProvider);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFromMockProvider(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFromMockProvider ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLatitudeHandler()
	{
		return new _JniMarshal_PP_D(n_GetLatitude);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetLatitude(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Latitude;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetLongitudeHandler()
	{
		return new _JniMarshal_PP_D(n_GetLongitude);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetLongitude(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Longitude;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetIsMockHandler()
	{
		return new _JniMarshal_PP_B(n_IsMock);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMock(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mock ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetProviderHandler()
	{
		return new _JniMarshal_PP_L(n_GetProvider);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProvider(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Provider);
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

	private static Delegate GetGetSpeedHandler()
	{
		return new _JniMarshal_PP_F(n_GetSpeed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSpeed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Speed;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTimeHandler()
	{
		return new _JniMarshal_PP_J(n_GetTime);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTime(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Time;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetVerticalAccuracyMetersHandler()
	{
		return new _JniMarshal_PP_F(n_GetVerticalAccuracyMeters);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetVerticalAccuracyMeters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalAccuracyMeters;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_parcel, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Location? location = Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native_parcel, JniHandleOwnership.DoNotTransfer);
			location.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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

	public unsafe virtual void WriteToParcel(Parcel parcel, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parcel);
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
