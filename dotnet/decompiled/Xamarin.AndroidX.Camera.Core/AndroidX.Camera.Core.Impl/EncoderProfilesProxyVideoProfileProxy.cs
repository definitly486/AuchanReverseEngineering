using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy", DoNotGenerateAcw = true)]
public abstract class EncoderProfilesProxyVideoProfileProxy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy", typeof(EncoderProfilesProxyVideoProfileProxy));

	private static Delegate? cb_getBitDepth;

	private static Delegate? cb_getBitrate;

	private static Delegate? cb_getChromaSubsampling;

	private static Delegate? cb_getCodec;

	private static Delegate? cb_getFrameRate;

	private static Delegate? cb_getHdrFormat;

	private static Delegate? cb_getHeight;

	private static Delegate? cb_getMediaType;

	private static Delegate? cb_getProfile;

	private static Delegate? cb_getWidth;

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

	public abstract int BitDepth
	{
		[Register("getBitDepth", "()I", "GetGetBitDepthHandler")]
		get;
	}

	public abstract int Bitrate
	{
		[Register("getBitrate", "()I", "GetGetBitrateHandler")]
		get;
	}

	public abstract int ChromaSubsampling
	{
		[Register("getChromaSubsampling", "()I", "GetGetChromaSubsamplingHandler")]
		get;
	}

	public abstract int Codec
	{
		[Register("getCodec", "()I", "GetGetCodecHandler")]
		get;
	}

	public abstract int FrameRate
	{
		[Register("getFrameRate", "()I", "GetGetFrameRateHandler")]
		get;
	}

	public abstract int HdrFormat
	{
		[Register("getHdrFormat", "()I", "GetGetHdrFormatHandler")]
		get;
	}

	public abstract int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
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

	public abstract int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get;
	}

	protected EncoderProfilesProxyVideoProfileProxy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe EncoderProfilesProxyVideoProfileProxy()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBitDepthHandler()
	{
		if ((object)cb_getBitDepth == null)
		{
			cb_getBitDepth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBitDepth));
		}
		return cb_getBitDepth;
	}

	private static int n_GetBitDepth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BitDepth;
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
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bitrate;
	}

	private static Delegate GetGetChromaSubsamplingHandler()
	{
		if ((object)cb_getChromaSubsampling == null)
		{
			cb_getChromaSubsampling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetChromaSubsampling));
		}
		return cb_getChromaSubsampling;
	}

	private static int n_GetChromaSubsampling(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChromaSubsampling;
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
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Codec;
	}

	private static Delegate GetGetFrameRateHandler()
	{
		if ((object)cb_getFrameRate == null)
		{
			cb_getFrameRate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFrameRate));
		}
		return cb_getFrameRate;
	}

	private static int n_GetFrameRate(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FrameRate;
	}

	private static Delegate GetGetHdrFormatHandler()
	{
		if ((object)cb_getHdrFormat == null)
		{
			cb_getHdrFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHdrFormat));
		}
		return cb_getHdrFormat;
	}

	private static int n_GetHdrFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HdrFormat;
	}

	private static Delegate GetGetHeightHandler()
	{
		if ((object)cb_getHeight == null)
		{
			cb_getHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHeight));
		}
		return cb_getHeight;
	}

	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediaType);
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
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Profile;
	}

	private static Delegate GetGetWidthHandler()
	{
		if ((object)cb_getWidth == null)
		{
			cb_getWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetWidth));
		}
		return cb_getWidth;
	}

	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
	}

	[Register("create", "(ILjava/lang/String;IIIIIIII)Landroidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy;", "")]
	public unsafe static EncoderProfilesProxyVideoProfileProxy Create(int codec, string mediaType, int bitrate, int frameRate, int width, int height, int profile, int bitDepth, int chromaSubsampling, int hdrFormat)
	{
		nint num = JNIEnv.NewString(mediaType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(codec);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(bitrate);
			ptr[3] = new JniArgumentValue(frameRate);
			ptr[4] = new JniArgumentValue(width);
			ptr[5] = new JniArgumentValue(height);
			ptr[6] = new JniArgumentValue(profile);
			ptr[7] = new JniArgumentValue(bitDepth);
			ptr[8] = new JniArgumentValue(chromaSubsampling);
			ptr[9] = new JniArgumentValue(hdrFormat);
			return Java.Lang.Object.GetObject<EncoderProfilesProxyVideoProfileProxy>(_members.StaticMethods.InvokeObjectMethod("create.(ILjava/lang/String;IIIIIIII)Landroidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
