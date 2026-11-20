using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/GnssStatusCompat", DoNotGenerateAcw = true)]
internal class GnssStatusCompatInvoker : GnssStatusCompat
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/GnssStatusCompat", typeof(GnssStatusCompatInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int SatelliteCount
	{
		[Register("getSatelliteCount", "()I", "GetGetSatelliteCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSatelliteCount.()I", this, null);
		}
	}

	public GnssStatusCompatInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getAzimuthDegrees", "(I)F", "GetGetAzimuthDegrees_IHandler")]
	public unsafe override float GetAzimuthDegrees(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getAzimuthDegrees.(I)F", this, ptr);
	}

	[Register("getBasebandCn0DbHz", "(I)F", "GetGetBasebandCn0DbHz_IHandler")]
	public unsafe override float GetBasebandCn0DbHz(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getBasebandCn0DbHz.(I)F", this, ptr);
	}

	[Register("getCarrierFrequencyHz", "(I)F", "GetGetCarrierFrequencyHz_IHandler")]
	public unsafe override float GetCarrierFrequencyHz(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getCarrierFrequencyHz.(I)F", this, ptr);
	}

	[Register("getCn0DbHz", "(I)F", "GetGetCn0DbHz_IHandler")]
	public unsafe override float GetCn0DbHz(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getCn0DbHz.(I)F", this, ptr);
	}

	[Register("getConstellationType", "(I)I", "GetGetConstellationType_IHandler")]
	public unsafe override int GetConstellationType(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getConstellationType.(I)I", this, ptr);
	}

	[Register("getElevationDegrees", "(I)F", "GetGetElevationDegrees_IHandler")]
	public unsafe override float GetElevationDegrees(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getElevationDegrees.(I)F", this, ptr);
	}

	[Register("getSvid", "(I)I", "GetGetSvid_IHandler")]
	public unsafe override int GetSvid(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getSvid.(I)I", this, ptr);
	}

	[Register("hasAlmanacData", "(I)Z", "GetHasAlmanacData_IHandler")]
	public unsafe override bool HasAlmanacData(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasAlmanacData.(I)Z", this, ptr);
	}

	[Register("hasBasebandCn0DbHz", "(I)Z", "GetHasBasebandCn0DbHz_IHandler")]
	public unsafe override bool HasBasebandCn0DbHz(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasBasebandCn0DbHz.(I)Z", this, ptr);
	}

	[Register("hasCarrierFrequencyHz", "(I)Z", "GetHasCarrierFrequencyHz_IHandler")]
	public unsafe override bool HasCarrierFrequencyHz(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasCarrierFrequencyHz.(I)Z", this, ptr);
	}

	[Register("hasEphemerisData", "(I)Z", "GetHasEphemerisData_IHandler")]
	public unsafe override bool HasEphemerisData(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasEphemerisData.(I)Z", this, ptr);
	}

	[Register("usedInFix", "(I)Z", "GetUsedInFix_IHandler")]
	public unsafe override bool UsedInFix(int satelliteIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(satelliteIndex);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("usedInFix.(I)Z", this, ptr);
	}
}
