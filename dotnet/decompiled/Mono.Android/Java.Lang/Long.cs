using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Long", DoNotGenerateAcw = true)]
public sealed class Long : Number, IConvertible, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Long", typeof(Long));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static explicit operator long(Long value)
	{
		return value.LongValue();
	}

	TypeCode IConvertible.GetTypeCode()
	{
		return TypeCode.Int64;
	}

	bool IConvertible.ToBoolean(IFormatProvider? provider)
	{
		return Convert.ToBoolean(LongValue());
	}

	byte IConvertible.ToByte(IFormatProvider? provider)
	{
		return Convert.ToByte(LongValue());
	}

	char IConvertible.ToChar(IFormatProvider? provider)
	{
		return Convert.ToChar(LongValue());
	}

	DateTime IConvertible.ToDateTime(IFormatProvider? provider)
	{
		return Convert.ToDateTime(LongValue());
	}

	decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		return Convert.ToDecimal(LongValue());
	}

	double IConvertible.ToDouble(IFormatProvider? provider)
	{
		return Convert.ToDouble(LongValue());
	}

	short IConvertible.ToInt16(IFormatProvider? provider)
	{
		return Convert.ToInt16(LongValue());
	}

	int IConvertible.ToInt32(IFormatProvider? provider)
	{
		return Convert.ToInt32(LongValue());
	}

	long IConvertible.ToInt64(IFormatProvider? provider)
	{
		return Convert.ToInt64(LongValue());
	}

	sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		return Convert.ToSByte(LongValue());
	}

	float IConvertible.ToSingle(IFormatProvider? provider)
	{
		return Convert.ToSingle(LongValue());
	}

	string IConvertible.ToString(IFormatProvider? provider)
	{
		return Convert.ToString(LongValue(), CultureInfo.InvariantCulture);
	}

	object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
	{
		return Convert.ChangeType(LongValue(), conversionType, provider);
	}

	ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		return Convert.ToUInt16(LongValue());
	}

	uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		return Convert.ToUInt32(LongValue());
	}

	ulong IConvertible.ToUInt64(IFormatProvider? provider)
	{
		return Convert.ToUInt64(LongValue());
	}

	internal Long(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(J)V", "")]
	[ObsoletedOSPlatform("android33.0")]
	public unsafe Long(long value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(J)V", this, ptr);
		}
	}

	[Register("doubleValue", "()D", "")]
	public unsafe override double DoubleValue()
	{
		return _members.InstanceMethods.InvokeAbstractDoubleMethod("doubleValue.()D", this, null);
	}

	[Register("floatValue", "()F", "")]
	public unsafe override float FloatValue()
	{
		return _members.InstanceMethods.InvokeAbstractSingleMethod("floatValue.()F", this, null);
	}

	[Register("intValue", "()I", "")]
	public unsafe override int IntValue()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("intValue.()I", this, null);
	}

	[Register("longValue", "()J", "")]
	public unsafe override long LongValue()
	{
		return _members.InstanceMethods.InvokeAbstractInt64Method("longValue.()J", this, null);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
