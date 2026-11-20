using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceProduct", DoNotGenerateAcw = true)]
public class ECommerceProduct : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceProduct", typeof(ECommerceProduct));

	private static Delegate? cb_getActualPrice_GetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;

	private static Delegate? cb_getCategoriesPath_GetCategoriesPath_Ljava_util_List_;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getOriginalPrice_GetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;

	private static Delegate? cb_getPayload_GetPayload_Ljava_util_Map_;

	private static Delegate? cb_getPromocodes_GetPromocodes_Ljava_util_List_;

	private static Delegate? cb_getSku_GetSku_Ljava_lang_String_;

	private static Delegate? cb_setActualPrice_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_setOriginalPrice_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_setPromocodes_SetPromocodes_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

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

	public unsafe virtual ECommercePrice? ActualPrice
	{
		[Register("getActualPrice", "()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", "GetGetActualPriceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommercePrice>(_members.InstanceMethods.InvokeVirtualObjectMethod("getActualPrice.()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

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

	public unsafe virtual ECommercePrice? OriginalPrice
	{
		[Register("getOriginalPrice", "()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", "GetGetOriginalPriceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommercePrice>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOriginalPrice.()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual IList<string>? Promocodes
	{
		[Register("getPromocodes", "()Ljava/util/List;", "GetGetPromocodesHandler")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPromocodes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string Sku
	{
		[Register("getSku", "()Ljava/lang/String;", "GetGetSkuHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSku.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceProduct(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe ECommerceProduct(string sku)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(sku);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetActualPriceHandler()
	{
		if ((object)cb_getActualPrice_GetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ == null)
		{
			cb_getActualPrice_GetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActualPrice));
		}
		return cb_getActualPrice_GetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;
	}

	private static nint n_GetActualPrice(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActualPrice);
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
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CategoriesPath);
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
	}

	private static Delegate GetGetOriginalPriceHandler()
	{
		if ((object)cb_getOriginalPrice_GetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ == null)
		{
			cb_getOriginalPrice_GetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOriginalPrice));
		}
		return cb_getOriginalPrice_GetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;
	}

	private static nint n_GetOriginalPrice(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalPrice);
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
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Payload);
	}

	private static Delegate GetGetPromocodesHandler()
	{
		if ((object)cb_getPromocodes_GetPromocodes_Ljava_util_List_ == null)
		{
			cb_getPromocodes_GetPromocodes_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPromocodes));
		}
		return cb_getPromocodes_GetPromocodes_Ljava_util_List_;
	}

	private static nint n_GetPromocodes(nint jnienv, nint native__this)
	{
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Promocodes);
	}

	private static Delegate GetGetSkuHandler()
	{
		if ((object)cb_getSku_GetSku_Ljava_lang_String_ == null)
		{
			cb_getSku_GetSku_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSku));
		}
		return cb_getSku_GetSku_Ljava_lang_String_;
	}

	private static nint n_GetSku(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Sku);
	}

	private static Delegate GetSetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_Handler()
	{
		if ((object)cb_setActualPrice_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setActualPrice_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_));
		}
		return cb_setActualPrice_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_(nint jnienv, nint native__this, nint native_actualPrice)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ECommercePrice actualPrice = Java.Lang.Object.GetObject<ECommercePrice>(native_actualPrice, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetActualPrice(actualPrice));
	}

	[Register("setActualPrice", "(Lio/appmetrica/analytics/ecommerce/ECommercePrice;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetActualPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_Handler")]
	public unsafe virtual ECommerceProduct SetActualPrice(ECommercePrice? actualPrice)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(actualPrice?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setActualPrice.(Lio/appmetrica/analytics/ecommerce/ECommercePrice;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(actualPrice);
		}
	}

	private static Delegate GetSetCategoriesPath_Ljava_util_List_Handler()
	{
		if ((object)cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCategoriesPath_Ljava_util_List_));
		}
		return cb_setCategoriesPath_SetCategoriesPath_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetCategoriesPath_Ljava_util_List_(nint jnienv, nint native__this, nint native_categoriesPath)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<string> categoriesPath = JavaList<string>.FromJniHandle(native_categoriesPath, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetCategoriesPath(categoriesPath));
	}

	[Register("setCategoriesPath", "(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetCategoriesPath_Ljava_util_List_Handler")]
	public unsafe virtual ECommerceProduct SetCategoriesPath(IList<string>? categoriesPath)
	{
		nint num = JavaList<string>.ToLocalJniHandle(categoriesPath);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCategoriesPath.(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(categoriesPath);
		}
	}

	private static Delegate GetSetName_Ljava_lang_String_Handler()
	{
		if ((object)cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetName_Ljava_lang_String_));
		}
		return cb_setName_SetName_Ljava_lang_String__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetName(name));
	}

	[Register("setName", "(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetName_Ljava_lang_String_Handler")]
	public unsafe virtual ECommerceProduct SetName(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setName.(Ljava/lang/String;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_Handler()
	{
		if ((object)cb_setOriginalPrice_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setOriginalPrice_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_));
		}
		return cb_setOriginalPrice_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_(nint jnienv, nint native__this, nint native_originalPrice)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ECommercePrice originalPrice = Java.Lang.Object.GetObject<ECommercePrice>(native_originalPrice, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetOriginalPrice(originalPrice));
	}

	[Register("setOriginalPrice", "(Lio/appmetrica/analytics/ecommerce/ECommercePrice;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetOriginalPrice_Lio_appmetrica_analytics_ecommerce_ECommercePrice_Handler")]
	public unsafe virtual ECommerceProduct SetOriginalPrice(ECommercePrice? originalPrice)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(originalPrice?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOriginalPrice.(Lio/appmetrica/analytics/ecommerce/ECommercePrice;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(originalPrice);
		}
	}

	private static Delegate GetSetPayload_Ljava_util_Map_Handler()
	{
		if ((object)cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPayload_Ljava_util_Map_));
		}
		return cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetPayload_Ljava_util_Map_(nint jnienv, nint native__this, nint native_payload)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> payload = JavaDictionary<string, string>.FromJniHandle(native_payload, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetPayload(payload));
	}

	[Register("setPayload", "(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetPayload_Ljava_util_Map_Handler")]
	public unsafe virtual ECommerceProduct SetPayload(IDictionary<string, string>? payload)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(payload);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPayload.(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(payload);
		}
	}

	private static Delegate GetSetPromocodes_Ljava_util_List_Handler()
	{
		if ((object)cb_setPromocodes_SetPromocodes_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_setPromocodes_SetPromocodes_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPromocodes_Ljava_util_List_));
		}
		return cb_setPromocodes_SetPromocodes_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_SetPromocodes_Ljava_util_List_(nint jnienv, nint native__this, nint native_promocodes)
	{
		ECommerceProduct? eCommerceProduct = Java.Lang.Object.GetObject<ECommerceProduct>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<string> promocodes = JavaList<string>.FromJniHandle(native_promocodes, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceProduct.SetPromocodes(promocodes));
	}

	[Register("setPromocodes", "(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetSetPromocodes_Ljava_util_List_Handler")]
	public unsafe virtual ECommerceProduct SetPromocodes(IList<string>? promocodes)
	{
		nint num = JavaList<string>.ToLocalJniHandle(promocodes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPromocodes.(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(promocodes);
		}
	}
}
