using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Double", DoNotGenerateAcw = true)]
public sealed class Double : Number, IConvertible, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Double", typeof(Double));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static explicit operator double(Double value)
	{
		return value.DoubleValue();
	}

	TypeCode IConvertible.GetTypeCode()
	{
		return TypeCode.Double;
	}

	bool IConvertible.ToBoolean(IFormatProvider? provider)
	{
		return Convert.ToBoolean(DoubleValue());
	}

	byte IConvertible.ToByte(IFormatProvider? provider)
	{
		return Convert.ToByte(DoubleValue());
	}

	char IConvertible.ToChar(IFormatProvider? provider)
	{
		return Convert.ToChar(DoubleValue());
	}

	DateTime IConvertible.ToDateTime(IFormatProvider? provider)
	{
		return Convert.ToDateTime(DoubleValue());
	}

	decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		return Convert.ToDecimal(DoubleValue());
	}

	double IConvertible.ToDouble(IFormatProvider? provider)
	{
		return Convert.ToDouble(DoubleValue());
	}

	short IConvertible.ToInt16(IFormatProvider? provider)
	{
		return Convert.ToInt16(DoubleValue());
	}

	int IConvertible.ToInt32(IFormatProvider? provider)
	{
		return Convert.ToInt32(DoubleValue());
	}

	long IConvertible.ToInt64(IFormatProvider? provider)
	{
		return Convert.ToInt64(DoubleValue());
	}

	sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		return Convert.ToSByte(DoubleValue());
	}

	float IConvertible.ToSingle(IFormatProvider? provider)
	{
		return Convert.ToSingle(DoubleValue());
	}

	string IConvertible.ToString(IFormatProvider? provider)
	{
		return Convert.ToString(DoubleValue(), provider);
	}

	object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
	{
		return Convert.ChangeType(DoubleValue(), conversionType, provider);
	}

	ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		return Convert.ToUInt16(DoubleValue());
	}

	uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		return Convert.ToUInt32(DoubleValue());
	}

	ulong IConvertible.ToUInt64(IFormatProvider? provider)
	{
		return Convert.ToUInt64(DoubleValue());
	}

	internal Double(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android33.0")]
	public unsafe Double(double value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(D)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(D)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android33.0")]
	public unsafe Double(string s)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(s);
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
