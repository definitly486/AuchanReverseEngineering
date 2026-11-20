using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/GnssStatusCompat", DoNotGenerateAcw = true)]
public abstract class GnssStatusCompat : Java.Lang.Object
{
	[Register("androidx/core/location/GnssStatusCompat$Callback", DoNotGenerateAcw = true)]
	public abstract class Callback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/GnssStatusCompat$Callback", typeof(Callback));

		private static Delegate? cb_onFirstFix_OnFirstFix_I_V;

		private static Delegate? cb_onSatelliteStatusChanged_OnSatelliteStatusChanged_Landroidx_core_location_GnssStatusCompat__V;

		private static Delegate? cb_onStarted_OnStarted_V;

		private static Delegate? cb_onStopped_OnStopped_V;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Callback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Callback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnFirstFix_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_OnFirstFix_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFirstFix_I(nint jnienv, nint native__this, int ttffMillis)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFirstFix(ttffMillis);
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

		[Register("onFirstFix", "(I)V", "GetOnFirstFix_IHandler")]
		public unsafe virtual void OnFirstFix(int ttffMillis)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ttffMillis);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onFirstFix.(I)V", this, ptr);
		}

		private static Delegate GetOnSatelliteStatusChanged_Landroidx_core_location_GnssStatusCompat_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnSatelliteStatusChanged_Landroidx_core_location_GnssStatusCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSatelliteStatusChanged_Landroidx_core_location_GnssStatusCompat_(nint jnienv, nint native__this, nint native_status)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Callback? callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				GnssStatusCompat status = Java.Lang.Object.GetObject<GnssStatusCompat>(native_status, JniHandleOwnership.DoNotTransfer);
				callback.OnSatelliteStatusChanged(status);
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

		[Register("onSatelliteStatusChanged", "(Landroidx/core/location/GnssStatusCompat;)V", "GetOnSatelliteStatusChanged_Landroidx_core_location_GnssStatusCompat_Handler")]
		public unsafe virtual void OnSatelliteStatusChanged(GnssStatusCompat? status)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(status?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onSatelliteStatusChanged.(Landroidx/core/location/GnssStatusCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(status);
			}
		}

		private static Delegate GetOnStartedHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnStarted);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStarted(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStarted();
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

		[Register("onStarted", "()V", "GetOnStartedHandler")]
		public unsafe virtual void OnStarted()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStarted.()V", this, null);
		}

		private static Delegate GetOnStoppedHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnStopped);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStopped(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStopped();
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

		[Register("onStopped", "()V", "GetOnStoppedHandler")]
		public unsafe virtual void OnStopped()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopped.()V", this, null);
		}
	}

	[Register("androidx/core/location/GnssStatusCompat$Callback", DoNotGenerateAcw = true)]
	internal class CallbackInvoker : Callback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/GnssStatusCompat$Callback", typeof(CallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/GnssStatusCompat", typeof(GnssStatusCompat));

	private static Delegate? cb_getSatelliteCount_GetSatelliteCount_I;

	private static Delegate? cb_getAzimuthDegrees_GetAzimuthDegrees_I_F;

	private static Delegate? cb_getBasebandCn0DbHz_GetBasebandCn0DbHz_I_F;

	private static Delegate? cb_getCarrierFrequencyHz_GetCarrierFrequencyHz_I_F;

	private static Delegate? cb_getCn0DbHz_GetCn0DbHz_I_F;

	private static Delegate? cb_getConstellationType_GetConstellationType_I_I;

	private static Delegate? cb_getElevationDegrees_GetElevationDegrees_I_F;

	private static Delegate? cb_getSvid_GetSvid_I_I;

	private static Delegate? cb_hasAlmanacData_HasAlmanacData_I_Z;

	private static Delegate? cb_hasBasebandCn0DbHz_HasBasebandCn0DbHz_I_Z;

	private static Delegate? cb_hasCarrierFrequencyHz_HasCarrierFrequencyHz_I_Z;

	private static Delegate? cb_hasEphemerisData_HasEphemerisData_I_Z;

	private static Delegate? cb_usedInFix_UsedInFix_I_Z;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract int SatelliteCount
	{
		[Register("getSatelliteCount", "()I", "GetGetSatelliteCountHandler")]
		get;
	}

	protected GnssStatusCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetSatelliteCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSatelliteCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSatelliteCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SatelliteCount;
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

	private static Delegate GetGetAzimuthDegrees_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetAzimuthDegrees_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAzimuthDegrees_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAzimuthDegrees(satelliteIndex);
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

	[Register("getAzimuthDegrees", "(I)F", "GetGetAzimuthDegrees_IHandler")]
	public abstract float GetAzimuthDegrees(int satelliteIndex);

	private static Delegate GetGetBasebandCn0DbHz_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetBasebandCn0DbHz_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBasebandCn0DbHz_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBasebandCn0DbHz(satelliteIndex);
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

	[Register("getBasebandCn0DbHz", "(I)F", "GetGetBasebandCn0DbHz_IHandler")]
	public abstract float GetBasebandCn0DbHz(int satelliteIndex);

	private static Delegate GetGetCarrierFrequencyHz_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetCarrierFrequencyHz_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCarrierFrequencyHz_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetCarrierFrequencyHz(satelliteIndex);
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

	[Register("getCarrierFrequencyHz", "(I)F", "GetGetCarrierFrequencyHz_IHandler")]
	public abstract float GetCarrierFrequencyHz(int satelliteIndex);

	private static Delegate GetGetCn0DbHz_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetCn0DbHz_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCn0DbHz_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetCn0DbHz(satelliteIndex);
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

	[Register("getCn0DbHz", "(I)F", "GetGetCn0DbHz_IHandler")]
	public abstract float GetCn0DbHz(int satelliteIndex);

	private static Delegate GetGetConstellationType_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetConstellationType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetConstellationType_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstellationType(satelliteIndex);
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

	[Register("getConstellationType", "(I)I", "GetGetConstellationType_IHandler")]
	public abstract int GetConstellationType(int satelliteIndex);

	private static Delegate GetGetElevationDegrees_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetElevationDegrees_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetElevationDegrees_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetElevationDegrees(satelliteIndex);
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

	[Register("getElevationDegrees", "(I)F", "GetGetElevationDegrees_IHandler")]
	public abstract float GetElevationDegrees(int satelliteIndex);

	private static Delegate GetGetSvid_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetSvid_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSvid_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSvid(satelliteIndex);
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

	[Register("getSvid", "(I)I", "GetGetSvid_IHandler")]
	public abstract int GetSvid(int satelliteIndex);

	private static Delegate GetHasAlmanacData_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasAlmanacData_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasAlmanacData_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasAlmanacData(satelliteIndex) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasAlmanacData", "(I)Z", "GetHasAlmanacData_IHandler")]
	public abstract bool HasAlmanacData(int satelliteIndex);

	private static Delegate GetHasBasebandCn0DbHz_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasBasebandCn0DbHz_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasBasebandCn0DbHz_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBasebandCn0DbHz(satelliteIndex) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasBasebandCn0DbHz", "(I)Z", "GetHasBasebandCn0DbHz_IHandler")]
	public abstract bool HasBasebandCn0DbHz(int satelliteIndex);

	private static Delegate GetHasCarrierFrequencyHz_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasCarrierFrequencyHz_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasCarrierFrequencyHz_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCarrierFrequencyHz(satelliteIndex) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasCarrierFrequencyHz", "(I)Z", "GetHasCarrierFrequencyHz_IHandler")]
	public abstract bool HasCarrierFrequencyHz(int satelliteIndex);

	private static Delegate GetHasEphemerisData_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasEphemerisData_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasEphemerisData_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasEphemerisData(satelliteIndex) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasEphemerisData", "(I)Z", "GetHasEphemerisData_IHandler")]
	public abstract bool HasEphemerisData(int satelliteIndex);

	private static Delegate GetUsedInFix_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_UsedInFix_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_UsedInFix_I(nint jnienv, nint native__this, int satelliteIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GnssStatusCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UsedInFix(satelliteIndex) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("usedInFix", "(I)Z", "GetUsedInFix_IHandler")]
	public abstract bool UsedInFix(int satelliteIndex);

	[Register("wrap", "(Landroid/location/GnssStatus;)Landroidx/core/location/GnssStatusCompat;", "")]
	public unsafe static GnssStatusCompat? Wrap(GnssStatus? gnssStatus)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(gnssStatus?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GnssStatusCompat>(_members.StaticMethods.InvokeObjectMethod("wrap.(Landroid/location/GnssStatus;)Landroidx/core/location/GnssStatusCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(gnssStatus);
		}
	}

	[Register("wrap", "(Landroid/location/GpsStatus;)Landroidx/core/location/GnssStatusCompat;", "")]
	public unsafe static GnssStatusCompat? Wrap(GpsStatus? gpsStatus)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(gpsStatus?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GnssStatusCompat>(_members.StaticMethods.InvokeObjectMethod("wrap.(Landroid/location/GpsStatus;)Landroidx/core/location/GnssStatusCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(gpsStatus);
		}
	}
}
