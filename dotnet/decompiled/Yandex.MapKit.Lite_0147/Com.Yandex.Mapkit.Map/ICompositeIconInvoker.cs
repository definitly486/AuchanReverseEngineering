using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CompositeIcon", DoNotGenerateAcw = true)]
internal class ICompositeIconInvoker : Java.Lang.Object, ICompositeIcon, IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_CompositeIcon = new XAPeerMembers("com/yandex/mapkit/map/CompositeIcon", typeof(ICompositeIconInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkPresentation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkPresentation", typeof(ICompositeIconInvoker));

	private static Delegate? cb_icon_Icon_Ljava_lang_String__Lcom_yandex_mapkit_map_Icon_;

	private static Delegate? cb_removeAll_RemoveAll_V;

	private static Delegate? cb_removeIcon_RemoveIcon_Ljava_lang_String__V;

	private static Delegate? cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setIconStyle_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_CompositeIcon.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_CompositeIcon;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_CompositeIcon.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_CompositeIcon.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public ICompositeIconInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIcon_Ljava_lang_String_Handler()
	{
		if ((object)cb_icon_Icon_Ljava_lang_String__Lcom_yandex_mapkit_map_Icon_ == null)
		{
			cb_icon_Icon_Ljava_lang_String__Lcom_yandex_mapkit_map_Icon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Icon_Ljava_lang_String_));
		}
		return cb_icon_Icon_Ljava_lang_String__Lcom_yandex_mapkit_map_Icon_;
	}

	private static nint n_Icon_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		ICompositeIcon? compositeIcon = Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(compositeIcon.Icon(p));
	}

	public unsafe IIcon Icon(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IIcon>(_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractObjectMethod("icon.(Ljava/lang/String;)Lcom/yandex/mapkit/map/Icon;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetRemoveAllHandler()
	{
		if ((object)cb_removeAll_RemoveAll_V == null)
		{
			cb_removeAll_RemoveAll_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RemoveAll));
		}
		return cb_removeAll_RemoveAll_V;
	}

	private static void n_RemoveAll(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAll();
	}

	public unsafe void RemoveAll()
	{
		_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractVoidMethod("removeAll.()V", this, null);
	}

	private static Delegate GetRemoveIcon_Ljava_lang_String_Handler()
	{
		if ((object)cb_removeIcon_RemoveIcon_Ljava_lang_String__V == null)
		{
			cb_removeIcon_RemoveIcon_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveIcon_Ljava_lang_String_));
		}
		return cb_removeIcon_RemoveIcon_Ljava_lang_String__V;
	}

	private static void n_RemoveIcon_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		ICompositeIcon? compositeIcon = Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		compositeIcon.RemoveIcon(p);
	}

	public unsafe void RemoveIcon(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractVoidMethod("removeIcon.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		ICompositeIcon? compositeIcon = Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		ImageProvider p2 = Java.Lang.Object.GetObject<ImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		compositeIcon.SetIcon(p, p2, p3);
	}

	public unsafe void SetIcon(string p0, ImageProvider p1, IconStyle p2)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Ljava/lang/String;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetSetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setIcon_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3)
	{
		ICompositeIcon? compositeIcon = Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		ImageProvider p2 = Java.Lang.Object.GetObject<ImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		ICallback p4 = Java.Lang.Object.GetObject<ICallback>(native_p3, JniHandleOwnership.DoNotTransfer);
		compositeIcon.SetIcon(p, p2, p3, p4);
	}

	public unsafe void SetIcon(string p0, ImageProvider p1, IconStyle p2, ICallback p3)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
			_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Ljava/lang/String;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			GC.KeepAlive(p3);
		}
	}

	private static Delegate GetSetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIconStyle_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIconStyle_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIconStyle_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ICompositeIcon? compositeIcon = Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		compositeIcon.SetIconStyle(p, p2);
	}

	public unsafe void SetIconStyle(string p0, IconStyle p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_CompositeIcon.InstanceMethods.InvokeAbstractVoidMethod("setIconStyle.(Ljava/lang/String;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
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
		return Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetRemoveHandler()
	{
		if ((object)cb_remove_Remove_V == null)
		{
			cb_remove_Remove_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Remove));
		}
		return cb_remove_Remove_V;
	}

	private static void n_Remove(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICompositeIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}
