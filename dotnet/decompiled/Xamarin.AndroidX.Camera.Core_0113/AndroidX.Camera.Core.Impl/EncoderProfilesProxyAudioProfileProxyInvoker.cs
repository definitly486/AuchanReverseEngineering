using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy", DoNotGenerateAcw = true)]
internal class EncoderProfilesProxyAudioProfileProxyInvoker : EncoderProfilesProxyAudioProfileProxy
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy", typeof(EncoderProfilesProxyAudioProfileProxyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Bitrate
	{
		[Register("getBitrate", "()I", "GetGetBitrateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBitrate.()I", this, null);
		}
	}

	public unsafe override int Channels
	{
		[Register("getChannels", "()I", "GetGetChannelsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getChannels.()I", this, null);
		}
	}

	public unsafe override int Codec
	{
		[Register("getCodec", "()I", "GetGetCodecHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCodec.()I", this, null);
		}
	}

	public unsafe override string MediaType
	{
		[Register("getMediaType", "()Ljava/lang/String;", "GetGetMediaTypeHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMediaType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override int Profile
	{
		[Register("getProfile", "()I", "GetGetProfileHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getProfile.()I", this, null);
		}
	}

	public unsafe override int SampleRate
	{
		[Register("getSampleRate", "()I", "GetGetSampleRateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSampleRate.()I", this, null);
		}
	}

	public EncoderProfilesProxyAudioProfileProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
