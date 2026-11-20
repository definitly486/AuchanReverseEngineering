using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceEvent", DoNotGenerateAcw = true)]
public abstract class ECommerceEvent : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceEvent", typeof(ECommerceEvent));

	private static Delegate? cb_getPublicDescription_GetPublicDescription_Ljava_lang_String_;

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

	public unsafe virtual string PublicDescription
	{
		[Register("getPublicDescription", "()Ljava/lang/String;", "GetGetPublicDescriptionHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPublicDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceEvent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe ECommerceEvent()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetPublicDescriptionHandler()
	{
		if ((object)cb_getPublicDescription_GetPublicDescription_Ljava_lang_String_ == null)
		{
			cb_getPublicDescription_GetPublicDescription_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPublicDescription));
		}
		return cb_getPublicDescription_GetPublicDescription_Ljava_lang_String_;
	}

	private static nint n_GetPublicDescription(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PublicDescription);
	}

	[Register("addCartItemEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent AddCartItemEvent(ECommerceCartItem cartItem)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cartItem?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("addCartItemEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cartItem);
		}
	}

	[Register("beginCheckoutEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceOrder;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent BeginCheckoutEvent(ECommerceOrder order)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(order?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("beginCheckoutEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceOrder;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(order);
		}
	}

	[Register("purchaseEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceOrder;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent PurchaseEvent(ECommerceOrder order)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(order?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("purchaseEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceOrder;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(order);
		}
	}

	[Register("removeCartItemEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent RemoveCartItemEvent(ECommerceCartItem cartItem)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cartItem?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("removeCartItemEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceCartItem;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cartItem);
		}
	}

	[Register("showProductCardEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent ShowProductCardEvent(ECommerceProduct product, ECommerceScreen screen)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(product?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(screen?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("showProductCardEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(product);
			GC.KeepAlive(screen);
		}
	}

	[Register("showProductDetailsEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent ShowProductDetailsEvent(ECommerceProduct product, ECommerceReferrer? referrer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(product?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(referrer?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("showProductDetailsEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceProduct;Lio/appmetrica/analytics/ecommerce/ECommerceReferrer;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(product);
			GC.KeepAlive(referrer);
		}
	}

	[Register("showScreenEvent", "(Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", "")]
	public unsafe static ECommerceEvent ShowScreenEvent(ECommerceScreen screen)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(screen?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ECommerceEvent>(_members.StaticMethods.InvokeObjectMethod("showScreenEvent.(Lio/appmetrica/analytics/ecommerce/ECommerceScreen;)Lio/appmetrica/analytics/ecommerce/ECommerceEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(screen);
		}
	}
}
