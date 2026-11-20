using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy", "", "AndroidX.Camera.Core.Impl.IEncoderProfilesProxyInvoker")]
public interface IEncoderProfilesProxy : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy", typeof(IEncoderProfilesProxy), isInterface: true);

	IList<EncoderProfilesProxyAudioProfileProxy> AudioProfiles
	{
		[Register("getAudioProfiles", "()Ljava/util/List;", "GetGetAudioProfilesHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int DefaultDurationSeconds
	{
		[Register("getDefaultDurationSeconds", "()I", "GetGetDefaultDurationSecondsHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int RecommendedFileFormat
	{
		[Register("getRecommendedFileFormat", "()I", "GetGetRecommendedFileFormatHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IList<EncoderProfilesProxyVideoProfileProxy> VideoProfiles
	{
		[Register("getVideoProfiles", "()Ljava/util/List;", "GetGetVideoProfilesHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	[Register("getAudioCodecMimeType", "(I)Ljava/lang/String;", "")]
	static unsafe string GetAudioCodecMimeType(int codec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(codec);
		return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getAudioCodecMimeType.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getRequiredAudioProfile", "(I)I", "")]
	static unsafe int GetRequiredAudioProfile(int codec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(codec);
		return _members.StaticMethods.InvokeInt32Method("getRequiredAudioProfile.(I)I", ptr);
	}

	[Register("getVideoCodecMimeType", "(I)Ljava/lang/String;", "")]
	static unsafe string GetVideoCodecMimeType(int codec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(codec);
		return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getVideoCodecMimeType.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
