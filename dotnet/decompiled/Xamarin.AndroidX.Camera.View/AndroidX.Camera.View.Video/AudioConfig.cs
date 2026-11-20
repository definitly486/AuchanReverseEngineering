using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.View.Video;

[Register("androidx/camera/view/video/AudioConfig", DoNotGenerateAcw = true)]
public class AudioConfig : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/video/AudioConfig", typeof(AudioConfig));

	private static Delegate? cb_getAudioEnabled;

	[Register("AUDIO_DISABLED")]
	public static AudioConfig AudioDisabled => Java.Lang.Object.GetObject<AudioConfig>(_members.StaticFields.GetObjectValue("AUDIO_DISABLED.Landroidx/camera/view/video/AudioConfig;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe virtual bool AudioEnabled
	{
		[Register("getAudioEnabled", "()Z", "GetGetAudioEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAudioEnabled.()Z", this, null);
		}
	}

	protected AudioConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetAudioEnabledHandler()
	{
		if ((object)cb_getAudioEnabled == null)
		{
			cb_getAudioEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetAudioEnabled));
		}
		return cb_getAudioEnabled;
	}

	private static bool n_GetAudioEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<AudioConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AudioEnabled;
	}

	[Register("create", "(Z)Landroidx/camera/view/video/AudioConfig;", "")]
	public unsafe static AudioConfig Create(bool enableAudio)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableAudio);
		return Java.Lang.Object.GetObject<AudioConfig>(_members.StaticMethods.InvokeObjectMethod("create.(Z)Landroidx/camera/view/video/AudioConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
