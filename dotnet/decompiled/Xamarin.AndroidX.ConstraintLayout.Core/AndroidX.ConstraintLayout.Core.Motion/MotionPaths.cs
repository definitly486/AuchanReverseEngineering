using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Key;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion;

[Register("androidx/constraintlayout/core/motion/MotionPaths", DoNotGenerateAcw = true)]
public class MotionPaths : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/MotionPaths", typeof(MotionPaths));

	private static Delegate? cb_applyParameters_ApplyParameters_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_compareTo_CompareTo_Landroidx_constraintlayout_core_motion_MotionPaths__I;

	private static Delegate? cb_configureRelativeTo_ConfigureRelativeTo_Landroidx_constraintlayout_core_motion_Motion__V;

	private static Delegate? cb_setupRelative_SetupRelative_Landroidx_constraintlayout_core_motion_Motion_Landroidx_constraintlayout_core_motion_MotionPaths__V;

	[Register("mId")]
	public string? MId
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mId.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected MotionPaths(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MotionPaths()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(IILandroidx/constraintlayout/core/motion/key/MotionKeyPosition;Landroidx/constraintlayout/core/motion/MotionPaths;Landroidx/constraintlayout/core/motion/MotionPaths;)V", "")]
	public unsafe MotionPaths(int parentWidth, int parentHeight, MotionKeyPosition? c, MotionPaths? startTimePoint, MotionPaths? endTimePoint)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(parentWidth);
			ptr[1] = new JniArgumentValue(parentHeight);
			ptr[2] = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(startTimePoint?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(endTimePoint?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IILandroidx/constraintlayout/core/motion/key/MotionKeyPosition;Landroidx/constraintlayout/core/motion/MotionPaths;Landroidx/constraintlayout/core/motion/MotionPaths;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IILandroidx/constraintlayout/core/motion/key/MotionKeyPosition;Landroidx/constraintlayout/core/motion/MotionPaths;Landroidx/constraintlayout/core/motion/MotionPaths;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
			GC.KeepAlive(startTimePoint);
			GC.KeepAlive(endTimePoint);
		}
	}

	private static Delegate GetApplyParameters_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyParameters_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyParameters_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionPaths? motionPaths = Java.Lang.Object.GetObject<MotionPaths>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget c = Java.Lang.Object.GetObject<MotionWidget>(native_c, JniHandleOwnership.DoNotTransfer);
			motionPaths.ApplyParameters(c);
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

	[Register("applyParameters", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetApplyParameters_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
	public unsafe virtual void ApplyParameters(MotionWidget? c)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyParameters.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetCompareTo_Landroidx_constraintlayout_core_motion_MotionPaths_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_CompareTo_Landroidx_constraintlayout_core_motion_MotionPaths_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompareTo_Landroidx_constraintlayout_core_motion_MotionPaths_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionPaths? motionPaths = Java.Lang.Object.GetObject<MotionPaths>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionPaths o = Java.Lang.Object.GetObject<MotionPaths>(native_o, JniHandleOwnership.DoNotTransfer);
			return motionPaths.CompareTo(o);
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

	[Register("compareTo", "(Landroidx/constraintlayout/core/motion/MotionPaths;)I", "GetCompareTo_Landroidx_constraintlayout_core_motion_MotionPaths_Handler")]
	public unsafe virtual int CompareTo(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compareTo.(Landroidx/constraintlayout/core/motion/MotionPaths;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetConfigureRelativeTo_Landroidx_constraintlayout_core_motion_Motion_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ConfigureRelativeTo_Landroidx_constraintlayout_core_motion_Motion_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConfigureRelativeTo_Landroidx_constraintlayout_core_motion_Motion_(nint jnienv, nint native__this, nint native_toOrbit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionPaths? motionPaths = Java.Lang.Object.GetObject<MotionPaths>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Motion toOrbit = Java.Lang.Object.GetObject<Motion>(native_toOrbit, JniHandleOwnership.DoNotTransfer);
			motionPaths.ConfigureRelativeTo(toOrbit);
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

	[Register("configureRelativeTo", "(Landroidx/constraintlayout/core/motion/Motion;)V", "GetConfigureRelativeTo_Landroidx_constraintlayout_core_motion_Motion_Handler")]
	public unsafe virtual void ConfigureRelativeTo(Motion? toOrbit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(toOrbit?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("configureRelativeTo.(Landroidx/constraintlayout/core/motion/Motion;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toOrbit);
		}
	}

	private static Delegate GetSetupRelative_Landroidx_constraintlayout_core_motion_Motion_Landroidx_constraintlayout_core_motion_MotionPaths_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetupRelative_Landroidx_constraintlayout_core_motion_Motion_Landroidx_constraintlayout_core_motion_MotionPaths_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupRelative_Landroidx_constraintlayout_core_motion_Motion_Landroidx_constraintlayout_core_motion_MotionPaths_(nint jnienv, nint native__this, nint native_mc, nint native_relative)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionPaths? motionPaths = Java.Lang.Object.GetObject<MotionPaths>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Motion mc = Java.Lang.Object.GetObject<Motion>(native_mc, JniHandleOwnership.DoNotTransfer);
			MotionPaths relative = Java.Lang.Object.GetObject<MotionPaths>(native_relative, JniHandleOwnership.DoNotTransfer);
			motionPaths.SetupRelative(mc, relative);
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

	[Register("setupRelative", "(Landroidx/constraintlayout/core/motion/Motion;Landroidx/constraintlayout/core/motion/MotionPaths;)V", "GetSetupRelative_Landroidx_constraintlayout_core_motion_Motion_Landroidx_constraintlayout_core_motion_MotionPaths_Handler")]
	public unsafe virtual void SetupRelative(Motion? mc, MotionPaths? relative)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(mc?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(relative?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupRelative.(Landroidx/constraintlayout/core/motion/Motion;Landroidx/constraintlayout/core/motion/MotionPaths;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mc);
			GC.KeepAlive(relative);
		}
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
