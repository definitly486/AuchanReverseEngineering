using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Float", DoNotGenerateAcw = true)]
public sealed class Float : Number, IConvertible, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Float", typeof(Float));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static explicit operator float(Float value)
	{
		return value.FloatValue();
	}

	TypeCode IConvertible.GetTypeCode()
	{
		return TypeCode.Single;
	}

	bool IConvertible.ToBoolean(IFormatProvider? provider)
	{
		return Convert.ToBoolean(FloatValue());
	}

	byte IConvertible.ToByte(IFormatProvider? provider)
	{
		return Convert.ToByte(FloatValue());
	}

	char IConvertible.ToChar(IFormatProvider? provider)
	{
		return Convert.ToChar(FloatValue());
	}

	DateTime IConvertible.ToDateTime(IFormatProvider? provider)
	{
		return Convert.ToDateTime(FloatValue());
	}

	decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		return Convert.ToDecimal(FloatValue());
	}

	double IConvertible.ToDouble(IFormatProvider? provider)
	{
		return Convert.ToDouble(FloatValue());
	}

	short IConvertible.ToInt16(IFormatProvider? provider)
	{
		return Convert.ToInt16(FloatValue());
	}

	int IConvertible.ToInt32(IFormatProvider? provider)
	{
		return Convert.ToInt32(FloatValue());
	}

	long IConvertible.ToInt64(IFormatProvider? provider)
	{
		return Convert.ToInt64(FloatValue());
	}

	sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		return Convert.ToSByte(FloatValue());
	}

	float IConvertible.ToSingle(IFormatProvider? provider)
	{
		return Convert.ToSingle(FloatValue());
	}

	string IConvertible.ToString(IFormatProvider? provider)
	{
		return Convert.ToString(FloatValue(), provider);
	}

	object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
	{
		return Convert.ChangeType(FloatValue(), conversionType, provider);
	}

	ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		return Convert.ToUInt16(FloatValue());
	}

	uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		return Convert.ToUInt32(FloatValue());
	}

	ulong IConvertible.ToUInt64(IFormatProvider? provider)
	{
		return Convert.ToUInt64(FloatValue());
	}

	internal Float(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android33.0")]
	public unsafe Float(float value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(F)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(F)V", this, ptr);
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
