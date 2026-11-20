using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/LocationRequestCompat", DoNotGenerateAcw = true)]
public sealed class LocationRequestCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/LocationRequestCompat", typeof(LocationRequestCompat));

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

	public unsafe long DurationMillis
	{
		[Register("getDurationMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getDurationMillis.()J", this, null);
		}
	}

	public unsafe long IntervalMillis
	{
		[Register("getIntervalMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getIntervalMillis.()J", this, null);
		}
	}

	public unsafe long MaxUpdateDelayMillis
	{
		[Register("getMaxUpdateDelayMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getMaxUpdateDelayMillis.()J", this, null);
		}
	}

	public unsafe int MaxUpdates
	{
		[Register("getMaxUpdates", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxUpdates.()I", this, null);
		}
	}

	public unsafe float MinUpdateDistanceMeters
	{
		[Register("getMinUpdateDistanceMeters", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getMinUpdateDistanceMeters.()F", this, null);
		}
	}

	public unsafe long MinUpdateIntervalMillis
	{
		[Register("getMinUpdateIntervalMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getMinUpdateIntervalMillis.()J", this, null);
		}
	}

	public unsafe int Quality
	{
		[Register("getQuality", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getQuality.()I", this, null);
		}
	}

	internal LocationRequestCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("toLocationRequest", "()Landroid/location/LocationRequest;", "")]
	public unsafe LocationRequest? ToLocationRequest()
	{
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("toLocationRequest.()Landroid/location/LocationRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toLocationRequest", "(Ljava/lang/String;)Landroid/location/LocationRequest;", "")]
	public unsafe LocationRequest? ToLocationRequest(string? provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("toLocationRequest.(Ljava/lang/String;)Landroid/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
