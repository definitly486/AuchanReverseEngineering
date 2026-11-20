using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[ObsoletedOSPlatform("android34.0", "This class is obsoleted in this android platform")]
[Register("android/location/Criteria", DoNotGenerateAcw = true)]
public class Criteria : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/location/Criteria", typeof(Criteria));

	private static Delegate? cb_setAccuracy_SetAccuracy_I_V;

	private static Delegate? cb_setAltitudeRequired_SetAltitudeRequired_Z_V;

	private static Delegate? cb_setBearingRequired_SetBearingRequired_Z_V;

	private static Delegate? cb_setHorizontalAccuracy_SetHorizontalAccuracy_I_V;

	private static Delegate? cb_setPowerRequirement_SetPowerRequirement_I_V;

	private static Delegate? cb_setSpeedRequired_SetSpeedRequired_Z_V;

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

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual Accuracy Accuracy
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccuracy.(I)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual bool AltitudeRequired
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAltitudeRequired.(Z)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual bool BearingRequired
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBearingRequired.(Z)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual Accuracy HorizontalAccuracy
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalAccuracy.(I)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual Power PowerRequirement
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPowerRequirement.(I)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual bool SpeedRequired
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpeedRequired.(Z)V", this, ptr);
		}
	}

	protected Criteria(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android34.0")]
	public unsafe Criteria()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetAccuracy_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetAccuracy_I);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAccuracy_I(nint jnienv, nint native__this, int native_accuracy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Accuracy = (Accuracy)native_accuracy;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetAltitudeRequired_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetAltitudeRequired_Z);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAltitudeRequired_Z(nint jnienv, nint native__this, sbyte native_altitudeRequired)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Criteria? criteria = Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool altitudeRequired = native_altitudeRequired != 0;
			criteria.AltitudeRequired = altitudeRequired;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetBearingRequired_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetBearingRequired_Z);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBearingRequired_Z(nint jnienv, nint native__this, sbyte native_bearingRequired)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Criteria? criteria = Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool bearingRequired = native_bearingRequired != 0;
			criteria.BearingRequired = bearingRequired;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetHorizontalAccuracy_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetHorizontalAccuracy_I);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalAccuracy_I(nint jnienv, nint native__this, int native_accuracy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalAccuracy = (Accuracy)native_accuracy;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetPowerRequirement_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetPowerRequirement_I);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPowerRequirement_I(nint jnienv, nint native__this, int native_powerRequirement)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PowerRequirement = (Power)native_powerRequirement;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetSetSpeedRequired_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetSpeedRequired_Z);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpeedRequired_Z(nint jnienv, nint native__this, sbyte native_speedRequired)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Criteria? criteria = Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool speedRequired = native_speedRequired != 0;
			criteria.SpeedRequired = speedRequired;
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

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_parcel, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Criteria? criteria = Java.Lang.Object.GetObject<Criteria>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native_parcel, JniHandleOwnership.DoNotTransfer);
			criteria.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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

	[ObsoletedOSPlatform("android34.0")]
	public unsafe virtual void WriteToParcel(Parcel? parcel, ParcelableWriteFlags flags)
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
