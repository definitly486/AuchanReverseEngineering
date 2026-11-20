using System;
using System.Collections;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProvider", "", "AndroidX.Camera.Core.Impl.IEncoderProfilesProviderInvoker")]
public interface IEncoderProfilesProvider : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProvider", typeof(IEncoderProfilesProvider), isInterface: true);

	[Register("EMPTY")]
	static IEncoderProfilesProvider? Empty => Java.Lang.Object.GetObject<IEncoderProfilesProvider>(_members.StaticFields.GetObjectValue("EMPTY.Landroidx/camera/core/impl/EncoderProfilesProvider;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QUALITY_HIGH_TO_LOW")]
	static IList? QualityHighToLow => JavaList.FromJniHandle(_members.StaticFields.GetObjectValue("QUALITY_HIGH_TO_LOW.Ljava/util/List;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("getAll", "(I)Landroidx/camera/core/impl/EncoderProfilesProxy;", "GetGetAll_IHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProviderInvoker, Xamarin.AndroidX.Camera.Core")]
	IEncoderProfilesProxy? GetAll(int p0);

	[Register("hasProfile", "(I)Z", "GetHasProfile_IHandler:AndroidX.Camera.Core.Impl.IEncoderProfilesProviderInvoker, Xamarin.AndroidX.Camera.Core")]
	bool HasProfile(int p0);
}
