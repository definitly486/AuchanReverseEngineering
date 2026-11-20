using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/OutputOptions", DoNotGenerateAcw = true)]
public abstract class OutputOptions : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/OutputOptions", typeof(OutputOptions));

	private static Delegate? cb_getDurationLimitMillis;

	private static Delegate? cb_getFileSizeLimit;

	private static Delegate? cb_getLocation;

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

	public unsafe virtual long DurationLimitMillis
	{
		[Register("getDurationLimitMillis", "()J", "GetGetDurationLimitMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getDurationLimitMillis.()J", this, null);
		}
	}

	public unsafe virtual long FileSizeLimit
	{
		[Register("getFileSizeLimit", "()J", "GetGetFileSizeLimitHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getFileSizeLimit.()J", this, null);
		}
	}

	public unsafe virtual Location? Location
	{
		[Register("getLocation", "()Landroid/location/Location;", "GetGetLocationHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Location>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLocation.()Landroid/location/Location;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected OutputOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetDurationLimitMillisHandler()
	{
		if ((object)cb_getDurationLimitMillis == null)
		{
			cb_getDurationLimitMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetDurationLimitMillis));
		}
		return cb_getDurationLimitMillis;
	}

	private static long n_GetDurationLimitMillis(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<OutputOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DurationLimitMillis;
	}

	private static Delegate GetGetFileSizeLimitHandler()
	{
		if ((object)cb_getFileSizeLimit == null)
		{
			cb_getFileSizeLimit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetFileSizeLimit));
		}
		return cb_getFileSizeLimit;
	}

	private static long n_GetFileSizeLimit(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<OutputOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FileSizeLimit;
	}

	private static Delegate GetGetLocationHandler()
	{
		if ((object)cb_getLocation == null)
		{
			cb_getLocation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLocation));
		}
		return cb_getLocation;
	}

	private static nint n_GetLocation(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Location);
	}
}
