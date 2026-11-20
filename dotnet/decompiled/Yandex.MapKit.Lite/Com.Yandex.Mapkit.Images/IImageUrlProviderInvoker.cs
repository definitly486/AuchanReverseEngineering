using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Images;

[Register("com/yandex/mapkit/images/ImageUrlProvider", DoNotGenerateAcw = true)]
internal class IImageUrlProviderInvoker : Java.Lang.Object, IImageUrlProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_images_ImageUrlProvider = new XAPeerMembers("com/yandex/mapkit/images/ImageUrlProvider", typeof(IImageUrlProviderInvoker));

	private static Delegate? cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor__Ljava_lang_String_;

	private static nint java_class_ref => _members_com_yandex_mapkit_images_ImageUrlProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_images_ImageUrlProvider;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_images_ImageUrlProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_images_ImageUrlProvider.ManagedPeerType;

	public IImageUrlProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetFormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor_Handler()
	{
		if ((object)cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor__Ljava_lang_String_ == null)
		{
			cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor__Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor_));
		}
		return cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor__Ljava_lang_String_;
	}

	private static nint n_FormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor_(nint jnienv, nint native__this, nint native_p0)
	{
		IImageUrlProvider? imageUrlProvider = Java.Lang.Object.GetObject<IImageUrlProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageDataDescriptor p = Java.Lang.Object.GetObject<ImageDataDescriptor>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.NewString(imageUrlProvider.FormatUrl(p));
	}

	public unsafe string FormatUrl(ImageDataDescriptor p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members_com_yandex_mapkit_images_ImageUrlProvider.InstanceMethods.InvokeAbstractObjectMethod("formatUrl.(Lcom/yandex/mapkit/images/ImageDataDescriptor;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
