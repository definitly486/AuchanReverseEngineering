using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/CurveFit", DoNotGenerateAcw = true)]
public abstract class CurveFit : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/CurveFit", typeof(CurveFit));

	private static Delegate? cb_getPos_GetPos_DarrayD_V;

	private static Delegate? cb_getPos_GetPos_DarrayF_V;

	private static Delegate? cb_getPos_GetPos_DI_D;

	private static Delegate? cb_getSlope_GetSlope_DarrayD_V;

	private static Delegate? cb_getSlope_GetSlope_DI_D;

	private static Delegate? cb_getTimePoints_GetTimePoints_arrayD;

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

	protected CurveFit(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CurveFit()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("get", "(I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;", "")]
	public unsafe static CurveFit? Get(int type, double[]? time, double[][]? y)
	{
		nint num = JNIEnv.NewArray(time);
		nint num2 = JNIEnv.NewArray(y);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<CurveFit>(_members.StaticMethods.InvokeObjectMethod("get.(I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (time != null)
			{
				JNIEnv.CopyArray(num, time);
				JNIEnv.DeleteLocalRef(num);
			}
			if (y != null)
			{
				JNIEnv.CopyArray(num2, y);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(time);
			GC.KeepAlive(y);
		}
	}

	[Register("getArc", "([I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;", "")]
	public unsafe static CurveFit? GetArc(int[]? arcModes, double[]? time, double[][]? y)
	{
		nint num = JNIEnv.NewArray(arcModes);
		nint num2 = JNIEnv.NewArray(time);
		nint num3 = JNIEnv.NewArray(y);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return Java.Lang.Object.GetObject<CurveFit>(_members.StaticMethods.InvokeObjectMethod("getArc.([I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (arcModes != null)
			{
				JNIEnv.CopyArray(num, arcModes);
				JNIEnv.DeleteLocalRef(num);
			}
			if (time != null)
			{
				JNIEnv.CopyArray(num2, time);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (y != null)
			{
				JNIEnv.CopyArray(num3, y);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(arcModes);
			GC.KeepAlive(time);
			GC.KeepAlive(y);
		}
	}

	private static Delegate GetGetPos_DarrayDHandler()
	{
		return new _JniMarshal_PPDL_V(n_GetPos_DarrayD);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetPos_DarrayD(nint jnienv, nint native__this, double p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CurveFit? curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] array = (double[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(double));
			curveFit.GetPos(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getPos", "(D[D)V", "GetGetPos_DarrayDHandler")]
	public abstract void GetPos(double p0, double[]? p1);

	private static Delegate GetGetPos_DarrayFHandler()
	{
		return new _JniMarshal_PPDL_V(n_GetPos_DarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetPos_DarrayF(nint jnienv, nint native__this, double p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CurveFit? curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(float));
			curveFit.GetPos(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getPos", "(D[F)V", "GetGetPos_DarrayFHandler")]
	public abstract void GetPos(double p0, float[]? p1);

	private static Delegate GetGetPos_DIHandler()
	{
		return new _JniMarshal_PPDI_D(n_GetPos_DI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetPos_DI(nint jnienv, nint native__this, double p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPos(p0, p1);
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

	[Register("getPos", "(DI)D", "GetGetPos_DIHandler")]
	public abstract double GetPos(double p0, int p1);

	private static Delegate GetGetSlope_DarrayDHandler()
	{
		return new _JniMarshal_PPDL_V(n_GetSlope_DarrayD);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetSlope_DarrayD(nint jnienv, nint native__this, double p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CurveFit? curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] array = (double[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(double));
			curveFit.GetSlope(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSlope", "(D[D)V", "GetGetSlope_DarrayDHandler")]
	public abstract void GetSlope(double p0, double[]? p1);

	private static Delegate GetGetSlope_DIHandler()
	{
		return new _JniMarshal_PPDI_D(n_GetSlope_DI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetSlope_DI(nint jnienv, nint native__this, double p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSlope(p0, p1);
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

	[Register("getSlope", "(DI)D", "GetGetSlope_DIHandler")]
	public abstract double GetSlope(double p0, int p1);

	private static Delegate GetGetTimePointsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTimePoints);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTimePoints(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTimePoints());
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

	[Register("getTimePoints", "()[D", "GetGetTimePointsHandler")]
	public abstract double[]? GetTimePoints();
}
