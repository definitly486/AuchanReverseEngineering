using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/CurveFit", DoNotGenerateAcw = true)]
internal class CurveFitInvoker : CurveFit
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/CurveFit", typeof(CurveFitInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CurveFitInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getPos", "(D[D)V", "GetGetPos_DarrayDHandler")]
	public unsafe override void GetPos(double p0, double[]? p1)
	{
		nint num = JNIEnv.NewArray(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getPos.(D[D)V", this, ptr);
		}
		finally
		{
			if (p1 != null)
			{
				JNIEnv.CopyArray(num, p1);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(p1);
		}
	}

	[Register("getPos", "(D[F)V", "GetGetPos_DarrayFHandler")]
	public unsafe override void GetPos(double p0, float[]? p1)
	{
		nint num = JNIEnv.NewArray(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getPos.(D[F)V", this, ptr);
		}
		finally
		{
			if (p1 != null)
			{
				JNIEnv.CopyArray(num, p1);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(p1);
		}
	}

	[Register("getPos", "(DI)D", "GetGetPos_DIHandler")]
	public unsafe override double GetPos(double p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return _members.InstanceMethods.InvokeAbstractDoubleMethod("getPos.(DI)D", this, ptr);
	}

	[Register("getSlope", "(D[D)V", "GetGetSlope_DarrayDHandler")]
	public unsafe override void GetSlope(double p0, double[]? p1)
	{
		nint num = JNIEnv.NewArray(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getSlope.(D[D)V", this, ptr);
		}
		finally
		{
			if (p1 != null)
			{
				JNIEnv.CopyArray(num, p1);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(p1);
		}
	}

	[Register("getSlope", "(DI)D", "GetGetSlope_DIHandler")]
	public unsafe override double GetSlope(double p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return _members.InstanceMethods.InvokeAbstractDoubleMethod("getSlope.(DI)D", this, ptr);
	}

	[Register("getTimePoints", "()[D", "GetGetTimePointsHandler")]
	public unsafe override double[]? GetTimePoints()
	{
		return (double[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getTimePoints.()[D", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(double));
	}
}
