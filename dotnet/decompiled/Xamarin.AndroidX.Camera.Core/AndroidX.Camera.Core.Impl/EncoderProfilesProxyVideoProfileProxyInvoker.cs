using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy", DoNotGenerateAcw = true)]
internal class EncoderProfilesProxyVideoProfileProxyInvoker : EncoderProfilesProxyVideoProfileProxy
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy", typeof(EncoderProfilesProxyVideoProfileProxyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int BitDepth
	{
		[Register("getBitDepth", "()I", "GetGetBitDepthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBitDepth.()I", this, null);
		}
	}

	public unsafe override int Bitrate
	{
		[Register("getBitrate", "()I", "GetGetBitrateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBitrate.()I", this, null);
		}
	}

	public unsafe override int ChromaSubsampling
	{
		[Register("getChromaSubsampling", "()I", "GetGetChromaSubsamplingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getChromaSubsampling.()I", this, null);
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

	public unsafe override int FrameRate
	{
		[Register("getFrameRate", "()I", "GetGetFrameRateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFrameRate.()I", this, null);
		}
	}

	public unsafe override int HdrFormat
	{
		[Register("getHdrFormat", "()I", "GetGetHdrFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getHdrFormat.()I", this, null);
		}
	}

	public unsafe override int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
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

	public unsafe override int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
		}
	}

	public EncoderProfilesProxyVideoProfileProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
