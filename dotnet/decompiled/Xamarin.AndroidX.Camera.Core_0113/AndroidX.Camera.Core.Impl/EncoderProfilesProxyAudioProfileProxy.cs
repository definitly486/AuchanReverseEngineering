using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy", DoNotGenerateAcw = true)]
public abstract class EncoderProfilesProxyAudioProfileProxy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy", typeof(EncoderProfilesProxyAudioProfileProxy));

	private static Delegate? cb_getBitrate;

	private static Delegate? cb_getChannels;

	private static Delegate? cb_getCodec;

	private static Delegate? cb_getMediaType;

	private static Delegate? cb_getProfile;

	private static Delegate? cb_getSampleRate;

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

	public abstract int Bitrate
	{
		[Register("getBitrate", "()I", "GetGetBitrateHandler")]
		get;
	}

	public abstract int Channels
	{
		[Register("getChannels", "()I", "GetGetChannelsHandler")]
		get;
	}

	public abstract int Codec
	{
		[Register("getCodec", "()I", "GetGetCodecHandler")]
		get;
	}

	public abstract string MediaType
	{
		[Register("getMediaType", "()Ljava/lang/String;", "GetGetMediaTypeHandler")]
		get;
	}

	public abstract int Profile
	{
		[Register("getProfile", "()I", "GetGetProfileHandler")]
		get;
	}

	public abstract int SampleRate
	{
		[Register("getSampleRate", "()I", "GetGetSampleRateHandler")]
		get;
	}

	protected EncoderProfilesProxyAudioProfileProxy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe EncoderProfilesProxyAudioProfileProxy()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBitrateHandler()
	{
		if ((object)cb_getBitrate == null)
		{
			cb_getBitrate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBitrate));
		}
		return cb_getBitrate;
	}

	private static int n_GetBitrate(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bitrate;
	}

	private static Delegate GetGetChannelsHandler()
	{
		if ((object)cb_getChannels == null)
		{
			cb_getChannels = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetChannels));
		}
		return cb_getChannels;
	}

	private static int n_GetChannels(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Channels;
	}

	private static Delegate GetGetCodecHandler()
	{
		if ((object)cb_getCodec == null)
		{
			cb_getCodec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCodec));
		}
		return cb_getCodec;
	}

	private static int n_GetCodec(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Codec;
	}

	private static Delegate GetGetMediaTypeHandler()
	{
		if ((object)cb_getMediaType == null)
		{
			cb_getMediaType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMediaType));
		}
		return cb_getMediaType;
	}

	private static nint n_GetMediaType(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediaType);
	}

	private static Delegate GetGetProfileHandler()
	{
		if ((object)cb_getProfile == null)
		{
			cb_getProfile = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetProfile));
		}
		return cb_getProfile;
	}

	private static int n_GetProfile(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Profile;
	}

	private static Delegate GetGetSampleRateHandler()
	{
		if ((object)cb_getSampleRate == null)
		{
			cb_getSampleRate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSampleRate));
		}
		return cb_getSampleRate;
	}

	private static int n_GetSampleRate(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SampleRate;
	}

	[Register("create", "(ILjava/lang/String;IIII)Landroidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy;", "")]
	public unsafe static EncoderProfilesProxyAudioProfileProxy Create(int codec, string mediaType, int bitRate, int sampleRate, int channels, int profile)
	{
		nint num = JNIEnv.NewString(mediaType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(codec);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(bitRate);
			ptr[3] = new JniArgumentValue(sampleRate);
			ptr[4] = new JniArgumentValue(channels);
			ptr[5] = new JniArgumentValue(profile);
			return Java.Lang.Object.GetObject<EncoderProfilesProxyAudioProfileProxy>(_members.StaticMethods.InvokeObjectMethod("create.(ILjava/lang/String;IIII)Landroidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
