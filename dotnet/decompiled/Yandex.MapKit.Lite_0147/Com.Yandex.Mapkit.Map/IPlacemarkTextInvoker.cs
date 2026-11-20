using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkText", DoNotGenerateAcw = true)]
internal class IPlacemarkTextInvoker : Java.Lang.Object, IPlacemarkText, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkText = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkText", typeof(IPlacemarkTextInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_TextStyle_;

	private static Delegate? cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_TextStyle__V;

	private static Delegate? cb_getText_GetText_Ljava_lang_String_;

	private static Delegate? cb_setText_SetText_Ljava_lang_String__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarkText.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarkText;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarkText.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarkText.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkText.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe TextStyle Style
	{
		get
		{
			return Java.Lang.Object.GetObject<TextStyle>(_members_com_yandex_mapkit_map_PlacemarkText.InstanceMethods.InvokeAbstractObjectMethod("getStyle.()Lcom/yandex/mapkit/map/TextStyle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_PlacemarkText.InstanceMethods.InvokeAbstractVoidMethod("setStyle.(Lcom/yandex/mapkit/map/TextStyle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe string Text
	{
		get
		{
			return JNIEnv.GetString(_members_com_yandex_mapkit_map_PlacemarkText.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_yandex_mapkit_map_PlacemarkText.InstanceMethods.InvokeAbstractVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public IPlacemarkTextInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IPlacemarkText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetStyleHandler()
	{
		if ((object)cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_TextStyle_ == null)
		{
			cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_TextStyle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStyle));
		}
		return cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_TextStyle_;
	}

	private static nint n_GetStyle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Style);
	}

	private static Delegate GetSetStyle_Lcom_yandex_mapkit_map_TextStyle_Handler()
	{
		if ((object)cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_TextStyle__V == null)
		{
			cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_TextStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStyle_Lcom_yandex_mapkit_map_TextStyle_));
		}
		return cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_TextStyle__V;
	}

	private static void n_SetStyle_Lcom_yandex_mapkit_map_TextStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkText? placemarkText = Java.Lang.Object.GetObject<IPlacemarkText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TextStyle style = Java.Lang.Object.GetObject<TextStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkText.Style = style;
	}

	private static Delegate GetGetTextHandler()
	{
		if ((object)cb_getText_GetText_Ljava_lang_String_ == null)
		{
			cb_getText_GetText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetText));
		}
		return cb_getText_GetText_Ljava_lang_String_;
	}

	private static nint n_GetText(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IPlacemarkText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Text);
	}

	private static Delegate GetSetText_Ljava_lang_String_Handler()
	{
		if ((object)cb_setText_SetText_Ljava_lang_String__V == null)
		{
			cb_setText_SetText_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetText_Ljava_lang_String_));
		}
		return cb_setText_SetText_Ljava_lang_String__V;
	}

	private static void n_SetText_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkText? placemarkText = Java.Lang.Object.GetObject<IPlacemarkText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string text = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkText.Text = text;
	}
}
