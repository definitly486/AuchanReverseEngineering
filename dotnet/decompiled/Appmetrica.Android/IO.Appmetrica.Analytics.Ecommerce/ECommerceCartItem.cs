using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Math;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceCartItem", DoNotGenerateAcw = true)]
public class ECommerceCartItem : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceCartItem", typeof(ECommerceCartItem));

	private static Delegate? cb_getProduct_GetProduct_Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;

	private static Delegate? cb_getQuantity_GetQuantity_Ljava_math_BigDecimal_;

	private static Delegate? cb_getReferrer_GetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;

	private static Delegate? cb_getRevenue_GetRevenue_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;

	private static Delegate? cb_setReferrer_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer__Lio_appmetrica_analytics_ecommerce_ECommerceCartItem_;

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

	public unsafe virtual ECommerceProduct Product
	{
		[Register("getProduct", "()Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", "GetGetProductHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommerceProduct>(_members.InstanceMethods.InvokeVirtualObjectMethod("getProduct.()Lio/appmetrica/analytics/ecommerce/ECommerceProduct;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual BigDecimal Quantity
	{
		[Register("getQuantity", "()Ljava/math/BigDecimal;", "GetGetQuantityHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BigDecimal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getQuantity.()Ljava/math/BigDecimal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ECommerceReferrer? Referrer
	{
		[Register("getReferrer", "()Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", "GetGetReferrerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommerceReferrer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReferrer.()Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ECommercePrice Revenue
	{
		[Register("getRevenue", "()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", "GetGetRevenueHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommercePrice>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRevenue.()Lio/appmetrica/analytics/ecommerce/ECommercePrice;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceCartItem(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;D)V", "")]
	public unsafe ECommerceCartItem(ECommerceProduct product, ECommercePrice revenue, double quantity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(product?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(revenue?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(quantity);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;D)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;D)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(product);
			GC.KeepAlive(revenue);
		}
	}

	[Register(".ctor", "(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;Ljava/math/BigDecimal;)V", "")]
	public unsafe ECommerceCartItem(ECommerceProduct product, ECommercePrice revenue, BigDecimal quantity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(product?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(revenue?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(quantity?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;Ljava/math/BigDecimal;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;Ljava/math/BigDecimal;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(product);
			GC.KeepAlive(revenue);
			GC.KeepAlive(quantity);
		}
	}

	[Register(".ctor", "(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;J)V", "")]
	public unsafe ECommerceCartItem(ECommerceProduct product, ECommercePrice revenue, long quantityMicros)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(product?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(revenue?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(quantityMicros);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommercePrice;J)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(product);
			GC.KeepAlive(revenue);
		}
	}

	private static Delegate GetGetProductHandler()
	{
		if ((object)cb_getProduct_GetProduct_Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ == null)
		{
			cb_getProduct_GetProduct_Lio_appmetrica_analytics_ecommerce_ECommerceProduct_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetProduct));
		}
		return cb_getProduct_GetProduct_Lio_appmetrica_analytics_ecommerce_ECommerceProduct_;
	}

	private static nint n_GetProduct(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceCartItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Product);
	}

	private static Delegate GetGetQuantityHandler()
	{
		if ((object)cb_getQuantity_GetQuantity_Ljava_math_BigDecimal_ == null)
		{
			cb_getQuantity_GetQuantity_Ljava_math_BigDecimal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetQuantity));
		}
		return cb_getQuantity_GetQuantity_Ljava_math_BigDecimal_;
	}

	private static nint n_GetQuantity(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceCartItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Quantity);
	}

	private static Delegate GetGetReferrerHandler()
	{
		if ((object)cb_getReferrer_GetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ == null)
		{
			cb_getReferrer_GetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReferrer));
		}
		return cb_getReferrer_GetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_;
	}

	private static nint n_GetReferrer(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceCartItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Referrer);
	}

	private static Delegate GetGetRevenueHandler()
	{
		if ((object)cb_getRevenue_GetRevenue_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ == null)
		{
			cb_getRevenue_GetRevenue_Lio_appmetrica_analytics_ecommerce_ECommercePrice_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRevenue));
		}
		return cb_getRevenue_GetRevenue_Lio_appmetrica_analytics_ecommerce_ECommercePrice_;
	}

	private static nint n_GetRevenue(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceCartItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Revenue);
	}

	private static Delegate GetSetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_Handler()
	{
		if ((object)cb_setReferrer_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer__Lio_appmetrica_analytics_ecommerce_ECommerceCartItem_ == null)
		{
			cb_setReferrer_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer__Lio_appmetrica_analytics_ecommerce_ECommerceCartItem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_));
		}
		return cb_setReferrer_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer__Lio_appmetrica_analytics_ecommerce_ECommerceCartItem_;
	}

	private static nint n_SetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_(nint jnienv, nint native__this, nint native_referrer)
	{
		ECommerceCartItem? eCommerceCartItem = Java.Lang.Object.GetObject<ECommerceCartItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ECommerceReferrer referrer = Java.Lang.Object.GetObject<ECommerceReferrer>(native_referrer, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceCartItem.SetReferrer(referrer));
	}

	[Register("setReferrer", "(Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;)Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;", "GetSetReferrer_Lio_appmetrica_analytics_ecommerce_ECommerceReferrer_Handler")]
	public unsafe virtual ECommerceCartItem SetReferrer(ECommerceReferrer? referrer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(referrer?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceCartItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setReferrer.(Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;)Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(referrer);
		}
	}
}
