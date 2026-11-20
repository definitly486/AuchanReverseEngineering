using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceOrder", DoNotGenerateAcw = true)]
public class ECommerceOrder : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceOrder", typeof(ECommerceOrder));

	private static Delegate? cb_getCartItems_GetCartItems_Ljava_util_List_;

	private static Delegate? cb_getIdentifier_GetIdentifier_Ljava_lang_String_;

	private static Delegate? cb_getPayload_GetPayload_Ljava_util_Map_;

	private static Delegate? cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceOrder_;

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

	public unsafe virtual IList<ECommerceCartItem> CartItems
	{
		[Register("getCartItems", "()Ljava/util/List;", "GetGetCartItemsHandler")]
		get
		{
			return JavaList<ECommerceCartItem>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCartItems.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string Identifier
	{
		[Register("getIdentifier", "()Ljava/lang/String;", "GetGetIdentifierHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIdentifier.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	protected ECommerceOrder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;)V", "")]
	public unsafe ECommerceOrder(string identifier, IList<ECommerceCartItem> cartItems)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(identifier);
		nint num2 = JavaList<ECommerceCartItem>.ToLocalJniHandle(cartItems);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(cartItems);
		}
	}

	private static Delegate GetGetCartItemsHandler()
	{
		if ((object)cb_getCartItems_GetCartItems_Ljava_util_List_ == null)
		{
			cb_getCartItems_GetCartItems_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCartItems));
		}
		return cb_getCartItems_GetCartItems_Ljava_util_List_;
	}

	private static nint n_GetCartItems(nint jnienv, nint native__this)
	{
		return JavaList<ECommerceCartItem>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceOrder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CartItems);
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceOrder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Identifier);
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
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceOrder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Payload);
	}

	private static Delegate GetSetPayload_Ljava_util_Map_Handler()
	{
		if ((object)cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceOrder_ == null)
		{
			cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceOrder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPayload_Ljava_util_Map_));
		}
		return cb_setPayload_SetPayload_Ljava_util_Map__Lio_appmetrica_analytics_ecommerce_ECommerceOrder_;
	}

	private static nint n_SetPayload_Ljava_util_Map_(nint jnienv, nint native__this, nint native_payload)
	{
		ECommerceOrder? eCommerceOrder = Java.Lang.Object.GetObject<ECommerceOrder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> payload = JavaDictionary<string, string>.FromJniHandle(native_payload, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(eCommerceOrder.SetPayload(payload));
	}

	[Register("setPayload", "(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceOrder;", "GetSetPayload_Ljava_util_Map_Handler")]
	public unsafe virtual ECommerceOrder? SetPayload(IDictionary<string, string>? payload)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(payload);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ECommerceOrder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPayload.(Ljava/util/Map;)Lio/appmetrica/analytics/ecommerce/ECommerceOrder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(payload);
		}
	}
}
