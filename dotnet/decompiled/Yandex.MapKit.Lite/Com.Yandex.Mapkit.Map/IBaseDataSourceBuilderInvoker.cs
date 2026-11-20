using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Images;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/BaseDataSourceBuilder", DoNotGenerateAcw = true)]
internal class IBaseDataSourceBuilderInvoker : Java.Lang.Object, IBaseDataSourceBuilder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_BaseDataSourceBuilder = new XAPeerMembers("com/yandex/mapkit/map/BaseDataSourceBuilder", typeof(IBaseDataSourceBuilderInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_BaseDataSourceBuilder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_BaseDataSourceBuilder;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_BaseDataSourceBuilder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_BaseDataSourceBuilder.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_BaseDataSourceBuilder.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IBaseDataSourceBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IBaseDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetSetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_Handler()
	{
		if ((object)cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V == null)
		{
			cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_));
		}
		return cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V;
	}

	private static void n_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseDataSourceBuilder? baseDataSourceBuilder = Java.Lang.Object.GetObject<IBaseDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IImageUrlProvider imageUrlProvider = Java.Lang.Object.GetObject<IImageUrlProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseDataSourceBuilder.SetImageUrlProvider(imageUrlProvider);
	}

	public unsafe void SetImageUrlProvider(IImageUrlProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setImageUrlProvider.(Lcom/yandex/mapkit/images/ImageUrlProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
