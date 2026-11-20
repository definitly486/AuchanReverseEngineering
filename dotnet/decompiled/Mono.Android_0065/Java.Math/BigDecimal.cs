using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Math;

[Register("java/math/BigDecimal", DoNotGenerateAcw = true)]
public class BigDecimal : Number, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/math/BigDecimal", typeof(BigDecimal));

	private static Delegate? cb_doubleValue_DoubleValue_D;

	private static Delegate? cb_floatValue_FloatValue_F;

	private static Delegate? cb_intValue_IntValue_I;

	private static Delegate? cb_longValue_LongValue_J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BigDecimal(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe BigDecimal(string? val)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(val);
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
			return Java.Lang.Object.GetObject<BigDecimal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoubleValue();
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

	public unsafe override double DoubleValue()
	{
		return _members.InstanceMethods.InvokeVirtualDoubleMethod("doubleValue.()D", this, null);
	}

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
			return Java.Lang.Object.GetObject<BigDecimal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue();
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

	public unsafe override float FloatValue()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("floatValue.()F", this, null);
	}

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
			return Java.Lang.Object.GetObject<BigDecimal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntValue();
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

	public unsafe override int IntValue()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("intValue.()I", this, null);
	}

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
			return Java.Lang.Object.GetObject<BigDecimal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LongValue();
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

	public unsafe override long LongValue()
	{
		return _members.InstanceMethods.InvokeVirtualInt64Method("longValue.()J", this, null);
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
