using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceScreen", DoNotGenerateAcw = true)]
public class ECommerceScreen : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceScreen", typeof(ECommerceScreen));

	private static Delegate? cb_getCategoriesPath_GetCategoriesPath_Ljava_util_List_;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getPayload_GetPayload_Ljava_util_Map_;

	private static Delegate? cb_getSearchQuery_GetSearchQuery_Ljava_lang_String_;

	private static Delegate? cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;

	private static Delegate? cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;

	private static Delegate? cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;

	private static Delegate? cb_setSearchQuery_SetSearchQuery_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;

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

	public unsafe virtual IList<string>? CategoriesPath
	{
		[Register("getCategoriesPath", "()Ljava/util/List;", "GetGetCategoriesPathHandler")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCategoriesPath.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IDictionary<string, string>? Payload
	{
		[Register("getPayload", "()Ljava/util/Map;", "GetGetPayloadHandler")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPayload.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? SearchQuery
	{
		[Register("getSearchQuery", "()Ljava/lang/String;", "GetGetSearchQueryHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSearchQuery.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceScreen(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ECommerceScreen()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCategoriesPathHandler()
	{
		if ((object)cb_getCategoriesPath_GetCategoriesPath_Ljava_util_List_ == null)
		{
			cb_getCategoriesPath_GetCategoriesPath_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCategoriesPath));
		}
		return cb_getCategoriesPath_GetCategoriesPath_Ljava_util_List_;
	}

	private static nint n_GetCategoriesPath(nint jnienv, nint native__this)
	{
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CategoriesPath);
	}

	private static Delegate GetGetNameHandler()
	{
		if ((object)cb_getName_GetName_Ljava_lang_String_ == null)
		{
			cb_getName_GetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
		}
		return cb_getName_GetName_Ljava_lang_String_;
	}

	private static nint n_GetName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
	}

	private static Delegate GetGetPayloadHandler()
	{
		if ((object)cb_getPayload_GetPayload_Ljava_util_Map_ == null)
		{
			cb_getPayload_GetPayload_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPayload));
		}
		return cb_getPayload_GetPayload_Ljava_util_Map_;
	}

	private static nint n_GetPayload(nint jnienv, nint native__this)
	{
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Payload);
	}

	private static Delegate GetGetSearchQueryHandler()
	{
		if ((object)cb_getSearchQuery_GetSearchQuery_Ljava_lang_String_ == null)
		{
			cb_getSearchQuery_GetSearchQuery_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSearchQuery));
		}
		return cb_getSearchQuery_GetSearchQuery_Ljava_lang_String_;
	}

	private static nint n_GetSearchQuery(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SearchQuery);
	}

	private static Delegate GetSetCategoriesPath_Ljava_util_List_Handler()
	{
		if ((object)cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ == null)
		{
			cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCategoriesPath_Ljava_util_List_));
		}
		return cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;
	}

	private static nint n_SetCategoriesPath_Ljava_util_List_(nint jnienv, nint native__this, nint native_categoriesPath)
	{
		ECommerceScreen? eCommerceScreen = Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<string> categoriesPath = JavaList<string>.FromJniHandle(native_categoriesPath, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceScreen.SetCategoriesPath(categoriesPath));
	}

	[Register("setCategoriesPath", "(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", "GetSetCategoriesPath_Ljava_util_List_Handler")]
	public unsafe virtual ECommerceScreen? SetCategoriesPath(IList<string>? categoriesPath)
	{
		nint num = JavaList<string>.ToLocalJniHandle(categoriesPath);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceScreen>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCategoriesPath.(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(categoriesPath);
		}
	}

	private static Delegate GetSetName_Ljava_lang_String_Handler()
	{
		if ((object)cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ == null)
		{
			cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetName_Ljava_lang_String_));
		}
		return cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;
	}

	private static nint n_SetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		ECommerceScreen? eCommerceScreen = Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceScreen.SetName(name));
	}

	[Register("setName", "(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", "GetSetName_Ljava_lang_String_Handler")]
	public unsafe virtual ECommerceScreen? SetName(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceScreen>(_members.InstanceMethods.InvokeVirtualObjectMethod("setName.(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetPayload_Ljava_util_Map_Handler()
	{
		if ((object)cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ == null)
		{
			cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPayload_Ljava_util_Map_));
		}
		return cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;
	}

	private static nint n_SetPayload_Ljava_util_Map_(nint jnienv, nint native__this, nint native_payload)
	{
		ECommerceScreen? eCommerceScreen = Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> payload = JavaDictionary<string, string>.FromJniHandle(native_payload, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceScreen.SetPayload(payload));
	}

	[Register("setPayload", "(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", "GetSetPayload_Ljava_util_Map_Handler")]
	public unsafe virtual ECommerceScreen? SetPayload(IDictionary<string, string>? payload)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(payload);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceScreen>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPayload.(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(payload);
		}
	}

	private static Delegate GetSetSearchQuery_Ljava_lang_String_Handler()
	{
		if ((object)cb_setSearchQuery_SetSearchQuery_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ == null)
		{
			cb_setSearchQuery_SetSearchQuery_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSearchQuery_Ljava_lang_String_));
		}
		return cb_setSearchQuery_SetSearchQuery_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceScreen_;
	}

	private static nint n_SetSearchQuery_Ljava_lang_String_(nint jnienv, nint native__this, nint native_searchQuery)
	{
		ECommerceScreen? eCommerceScreen = Java.Lang.Object.GetObject<ECommerceScreen>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string searchQuery = JNIEnv.GetString(native_searchQuery, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceScreen.SetSearchQuery(searchQuery));
	}

	[Register("setSearchQuery", "(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", "GetSetSearchQuery_Ljava_lang_String_Handler")]
	public unsafe virtual ECommerceScreen? SetSearchQuery(string? searchQuery)
	{
		nint num = JNIEnv.NewString(searchQuery);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceScreen>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSearchQuery.(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceScreen;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
