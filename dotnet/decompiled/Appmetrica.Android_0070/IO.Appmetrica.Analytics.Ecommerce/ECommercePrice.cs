using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommercePrice", DoNotGenerateAcw = true)]
public class ECommercePrice : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommercePrice", typeof(ECommercePrice));

	private static Delegate? cb_getFiat_GetFiat_Lio_appmetrica_analytics_ecommerce_ECommerceAmount_;

	private static Delegate? cb_getInternalComponents_GetInternalComponents_Ljava_util_List_;

	private static Delegate? cb_setInternalComponents_SetInternalComponents_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommercePrice_;

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

	public unsafe virtual ECommerceAmount Fiat
	{
		[Register("getFiat", "()Lio/appmetrica/analytics/ecommerce/ECommerceAmount;", "GetGetFiatHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ECommerceAmount>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFiat.()Lio/appmetrica/analytics/ecommerce/ECommerceAmount;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<ECommerceAmount>? InternalComponents
	{
		[Register("getInternalComponents", "()Ljava/util/List;", "GetGetInternalComponentsHandler")]
		get
		{
			return JavaList<ECommerceAmount>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getInternalComponents.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommercePrice(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lio/appmetrica/analytics/ecommerce/ECommerceAmount;)V", "")]
	public unsafe ECommercePrice(ECommerceAmount fiat)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fiat?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceAmount;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lio/appmetrica/analytics/ecommerce/ECommerceAmount;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fiat);
		}
	}

	private static Delegate GetGetFiatHandler()
	{
		if ((object)cb_getFiat_GetFiat_Lio_appmetrica_analytics_ecommerce_ECommerceAmount_ == null)
		{
			cb_getFiat_GetFiat_Lio_appmetrica_analytics_ecommerce_ECommerceAmount_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFiat));
		}
		return cb_getFiat_GetFiat_Lio_appmetrica_analytics_ecommerce_ECommerceAmount_;
	}

	private static nint n_GetFiat(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommercePrice>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fiat);
	}

	private static Delegate GetGetInternalComponentsHandler()
	{
		if ((object)cb_getInternalComponents_GetInternalComponents_Ljava_util_List_ == null)
		{
			cb_getInternalComponents_GetInternalComponents_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInternalComponents));
		}
		return cb_getInternalComponents_GetInternalComponents_Ljava_util_List_;
	}

	private static nint n_GetInternalComponents(nint jnienv, nint native__this)
	{
		return JavaList<ECommerceAmount>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommercePrice>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InternalComponents);
	}

	private static Delegate GetSetInternalComponents_Ljava_util_List_Handler()
	{
		if ((object)cb_setInternalComponents_SetInternalComponents_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommercePrice_ == null)
		{
			cb_setInternalComponents_SetInternalComponents_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommercePrice_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetInternalComponents_Ljava_util_List_));
		}
		return cb_setInternalComponents_SetInternalComponents_Ljava_util_List__Lio_appmetrica_analytics_ecommerce_ECommercePrice_;
	}

	private static nint n_SetInternalComponents_Ljava_util_List_(nint jnienv, nint native__this, nint native_internalComponents)
	{
		ECommercePrice? eCommercePrice = Java.Lang.Object.GetObject<ECommercePrice>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<ECommerceAmount> internalComponents = JavaList<ECommerceAmount>.FromJniHandle(native_internalComponents, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommercePrice.SetInternalComponents(internalComponents));
	}

	[Register("setInternalComponents", "(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommercePrice;", "GetSetInternalComponents_Ljava_util_List_Handler")]
	public unsafe virtual ECommercePrice? SetInternalComponents(IList<ECommerceAmount>? internalComponents)
	{
		nint num = JavaList<ECommerceAmount>.ToLocalJniHandle(internalComponents);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommercePrice>(_members.InstanceMethods.InvokeVirtualObjectMethod("setInternalComponents.(Ljava/util/List;)Lio/appmetrica/analytics/ecommerce/ECommercePrice;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(internalComponents);
		}
	}
}
