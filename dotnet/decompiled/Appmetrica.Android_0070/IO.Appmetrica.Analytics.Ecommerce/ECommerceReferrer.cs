using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceReferrer", DoNotGenerateAcw = true)]
public class ECommerceReferrer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceReferrer", typeof(ECommerceReferrer));

	private static Delegate? cb_getIdentifier_GetIdentifier_Ljava_lang_String_;

	private static Delegate? cb_getScreen_GetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;

	private static Delegate? cb_getType_GetType_Ljava_lang_String_;

	private static Delegate? cb_setIdentifier_SetIdentifier_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;

	private static Delegate? cb_setScreen_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;

	private static Delegate? cb_setType_SetType_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;

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

	public unsafe virtual string? Identifier
	{
		[Register("getIdentifier", "()Ljava/lang/String;", "GetGetIdentifierHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIdentifier.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ECommerceScreen? Screen
	{
		[Register("getScreen", "()Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", "GetGetScreenHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommerceScreen>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScreen.()Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Type
	{
		[Register("getType", "()Ljava/lang/String;", "GetGetTypeHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceReferrer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ECommerceReferrer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetIdentifierHandler()
	{
		if ((object)cb_getIdentifier_GetIdentifier_Ljava_lang_String_ == null)
		{
			cb_getIdentifier_GetIdentifier_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIdentifier));
		}
		return cb_getIdentifier_GetIdentifier_Ljava_lang_String_;
	}

	private static nint n_GetIdentifier(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Identifier);
	}

	private static Delegate GetGetScreenHandler()
	{
		if ((object)cb_getScreen_GetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ == null)
		{
			cb_getScreen_GetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetScreen));
		}
		return cb_getScreen_GetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;
	}

	private static nint n_GetScreen(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Screen);
	}

	private static Delegate GetGetTypeHandler()
	{
		if ((object)cb_getType_GetType_Ljava_lang_String_ == null)
		{
			cb_getType_GetType_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
		}
		return cb_getType_GetType_Ljava_lang_String_;
	}

	private static nint n_GetType(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
	}

	private static Delegate GetSetIdentifier_Ljava_lang_String_Handler()
	{
		if ((object)cb_setIdentifier_SetIdentifier_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ == null)
		{
			cb_setIdentifier_SetIdentifier_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetIdentifier_Ljava_lang_String_));
		}
		return cb_setIdentifier_SetIdentifier_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;
	}

	private static nint n_SetIdentifier_Ljava_lang_String_(nint jnienv, nint native__this, nint native_identifier)
	{
		ECommerceReferrer? eCommerceReferrer = Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string identifier = JNIEnv.GetString(native_identifier, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceReferrer.SetIdentifier(identifier));
	}

	[Register("setIdentifier", "(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", "GetSetIdentifier_Ljava_lang_String_Handler")]
	public unsafe virtual ECommerceReferrer SetIdentifier(string? identifier)
	{
		nint num = JNIEnv.NewString(identifier);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceReferrer>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIdentifier.(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_Handler()
	{
		if ((object)cb_setScreen_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ == null)
		{
			cb_setScreen_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_));
		}
		return cb_setScreen_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;
	}

	private static nint n_SetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_(nint jnienv, nint native__this, nint native_screen)
	{
		ECommerceReferrer? eCommerceReferrer = Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ECommerceScreen screen = Java.Lang.Object.GetObject<ECommerceScreen>(native_screen, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceReferrer.SetScreen(screen));
	}

	[Register("setScreen", "(Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", "GetSetScreen_Lio_appmetrica_analytics_ecommerce_ECommerceScreen_Handler")]
	public unsafe virtual ECommerceReferrer SetScreen(ECommerceScreen? screen)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(screen?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceReferrer>(_members.InstanceMethods.InvokeVirtualObjectMethod("setScreen.(Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(screen);
		}
	}

	private static Delegate GetSetType_Ljava_lang_String_Handler()
	{
		if ((object)cb_setType_SetType_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ == null)
		{
			cb_setType_SetType_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetType_Ljava_lang_String_));
		}
		return cb_setType_SetType_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;
	}

	private static nint n_SetType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type)
	{
		ECommerceReferrer? eCommerceReferrer = Java.Lang.Object.GetObject<ECommerceReferrer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceReferrer.SetType(type));
	}

	[Register("setType", "(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", "GetSetType_Ljava_lang_String_Handler")]
	public unsafe virtual ECommerceReferrer SetType(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceReferrer>(_members.InstanceMethods.InvokeVirtualObjectMethod("setType.(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
