using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Number", DoNotGenerateAcw = true)]
internal class NumberInvoker : Number
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Number", typeof(NumberInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public NumberInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("doubleValue", "()D", "GetDoubleValueHandler")]
	public unsafe override double DoubleValue()
	{
		return _members.InstanceMethods.InvokeAbstractDoubleMethod("doubleValue.()D", this, null);
	}

	[Register("floatValue", "()F", "GetFloatValueHandler")]
	public unsafe override float FloatValue()
	{
		return _members.InstanceMethods.InvokeAbstractSingleMethod("floatValue.()F", this, null);
	}

	[Register("intValue", "()I", "GetIntValueHandler")]
	public unsafe override int IntValue()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("intValue.()I", this, null);
	}

	[Register("longValue", "()J", "GetLongValueHandler")]
	public unsafe override long LongValue()
	{
		return _members.InstanceMethods.InvokeAbstractInt64Method("longValue.()J", this, null);
	}
}
