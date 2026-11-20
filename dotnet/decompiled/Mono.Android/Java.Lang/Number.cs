using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Number", DoNotGenerateAcw = true)]
public abstract class Number : Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Number", typeof(Number));

	private static Delegate? cb_byteValue_ByteValue_B;

	private static Delegate? cb_doubleValue_DoubleValue_D;

	private static Delegate? cb_floatValue_FloatValue_F;

	private static Delegate? cb_intValue_IntValue_I;

	private static Delegate? cb_longValue_LongValue_J;

	private static Delegate? cb_shortValue_ShortValue_S;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Number(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetByteValueHandler()
	{
		return new _JniMarshal_PP_B(n_ByteValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ByteValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ByteValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("byteValue", "()B", "GetByteValueHandler")]
	public unsafe virtual sbyte ByteValue()
	{
		return _members.InstanceMethods.InvokeVirtualSByteMethod("byteValue.()B", this, null);
	}

	private static Delegate GetDoubleValueHandler()
	{
		return new _JniMarshal_PP_D(n_DoubleValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_DoubleValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoubleValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("doubleValue", "()D", "GetDoubleValueHandler")]
	public abstract double DoubleValue();

	private static Delegate GetFloatValueHandler()
	{
		return new _JniMarshal_PP_F(n_FloatValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_FloatValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("floatValue", "()F", "GetFloatValueHandler")]
	public abstract float FloatValue();

	private static Delegate GetIntValueHandler()
	{
		return new _JniMarshal_PP_I(n_IntValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_IntValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("intValue", "()I", "GetIntValueHandler")]
	public abstract int IntValue();

	private static Delegate GetLongValueHandler()
	{
		return new _JniMarshal_PP_J(n_LongValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_LongValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LongValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("longValue", "()J", "GetLongValueHandler")]
	public abstract long LongValue();

	private static Delegate GetShortValueHandler()
	{
		return new _JniMarshal_PP_S(n_ShortValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static short n_ShortValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Object.GetObject<Number>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShortValue();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("shortValue", "()S", "GetShortValueHandler")]
	public unsafe virtual short ShortValue()
	{
		return _members.InstanceMethods.InvokeVirtualInt16Method("shortValue.()S", this, null);
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
