using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Math;

namespace IO.Appmetrica.Analytics.Ecommerce;

[Register("io/appmetrica/analytics/ecommerce/ECommerceAmount", DoNotGenerateAcw = true)]
public class ECommerceAmount : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ecommerce/ECommerceAmount", typeof(ECommerceAmount));

	private static Delegate? cb_getAmount_GetAmount_Ljava_math_BigDecimal_;

	private static Delegate? cb_getUnit_GetUnit_Ljava_lang_String_;

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

	public unsafe virtual BigDecimal Amount
	{
		[Register("getAmount", "()Ljava/math/BigDecimal;", "GetGetAmountHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BigDecimal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAmount.()Ljava/math/BigDecimal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string Unit
	{
		[Register("getUnit", "()Ljava/lang/String;", "GetGetUnitHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUnit.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ECommerceAmount(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(DLjava/lang/String;)V", "")]
	public unsafe ECommerceAmount(double amount, string unit)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(unit);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(amount);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(DLjava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(DLjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/math/BigDecimal;Ljava/lang/String;)V", "")]
	public unsafe ECommerceAmount(BigDecimal amount, string unit)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(unit);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(amount?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/math/BigDecimal;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/math/BigDecimal;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(amount);
		}
	}

	[Register(".ctor", "(JLjava/lang/String;)V", "")]
	public unsafe ECommerceAmount(long amountMicros, string unit)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(unit);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(amountMicros);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JLjava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JLjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetAmountHandler()
	{
		if ((object)cb_getAmount_GetAmount_Ljava_math_BigDecimal_ == null)
		{
			cb_getAmount_GetAmount_Ljava_math_BigDecimal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAmount));
		}
		return cb_getAmount_GetAmount_Ljava_math_BigDecimal_;
	}

	private static nint n_GetAmount(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ECommerceAmount>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Amount);
	}

	private static Delegate GetGetUnitHandler()
	{
		if ((object)cb_getUnit_GetUnit_Ljava_lang_String_ == null)
		{
			cb_getUnit_GetUnit_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUnit));
		}
		return cb_getUnit_GetUnit_Ljava_lang_String_;
	}

	private static nint n_GetUnit(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ECommerceAmount>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Unit);
	}
}
