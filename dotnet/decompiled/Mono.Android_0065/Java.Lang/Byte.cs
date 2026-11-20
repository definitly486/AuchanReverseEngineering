using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Byte", DoNotGenerateAcw = true)]
public sealed class Byte : Number, IConvertible, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Byte", typeof(Byte));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static explicit operator sbyte(Byte value)
	{
		return (sbyte)value.IntValue();
	}

	TypeCode IConvertible.GetTypeCode()
	{
		return TypeCode.SByte;
	}

	bool IConvertible.ToBoolean(IFormatProvider? provider)
	{
		return Convert.ToBoolean(IntValue());
	}

	byte IConvertible.ToByte(IFormatProvider? provider)
	{
		return Convert.ToByte(IntValue());
	}

	char IConvertible.ToChar(IFormatProvider? provider)
	{
		return Convert.ToChar(IntValue());
	}

	DateTime IConvertible.ToDateTime(IFormatProvider? provider)
	{
		return Convert.ToDateTime(IntValue());
	}

	decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		return Convert.ToDecimal(IntValue());
	}

	double IConvertible.ToDouble(IFormatProvider? provider)
	{
		return Convert.ToDouble(IntValue());
	}

	short IConvertible.ToInt16(IFormatProvider? provider)
	{
		return Convert.ToInt16(IntValue());
	}

	int IConvertible.ToInt32(IFormatProvider? provider)
	{
		return IntValue();
	}

	long IConvertible.ToInt64(IFormatProvider? provider)
	{
		return Convert.ToInt64(IntValue());
	}

	sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		return Convert.ToSByte(IntValue());
	}

	float IConvertible.ToSingle(IFormatProvider? provider)
	{
		return Convert.ToSingle(IntValue());
	}

	string IConvertible.ToString(IFormatProvider? provider)
	{
		return Convert.ToString(IntValue(), provider);
	}

	object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
	{
		return Convert.ChangeType(IntValue(), conversionType, provider);
	}

	ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		return Convert.ToUInt16(IntValue());
	}

	uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		return Convert.ToUInt32(IntValue());
	}

	ulong IConvertible.ToUInt64(IFormatProvider? provider)
	{
		return Convert.ToUInt64(IntValue());
	}

	internal Byte(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe Byte(sbyte value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(B)V", this, ptr);
		}
	}

	public unsafe override double DoubleValue()
	{
		return _members.InstanceMethods.InvokeAbstractDoubleMethod("doubleValue.()D", this, null);
	}

	public unsafe override float FloatValue()
	{
		return _members.InstanceMethods.InvokeAbstractSingleMethod("floatValue.()F", this, null);
	}

	public unsafe override int IntValue()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("intValue.()I", this, null);
	}

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
