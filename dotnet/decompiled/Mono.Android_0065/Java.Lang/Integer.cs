using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Integer", DoNotGenerateAcw = true)]
public sealed class Integer : Number, IConvertible, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Integer", typeof(Integer));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static explicit operator int(Integer value)
	{
		return value.IntValue();
	}

	TypeCode IConvertible.GetTypeCode()
	{
		return TypeCode.Int32;
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
		return Convert.ToInt32(IntValue());
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

	internal Integer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android33.0")]
	public unsafe Integer(int value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[ObsoletedOSPlatform("android33.0")]
	public unsafe Integer(string s)
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

	public unsafe static Integer ValueOf(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return Object.GetObject<Integer>(_members.StaticMethods.InvokeObjectMethod("valueOf.(I)Ljava/lang/Integer;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
