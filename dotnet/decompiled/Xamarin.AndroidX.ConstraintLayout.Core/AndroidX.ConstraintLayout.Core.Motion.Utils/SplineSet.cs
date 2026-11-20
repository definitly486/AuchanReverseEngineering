using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/SplineSet", DoNotGenerateAcw = true)]
public abstract class SplineSet : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/SplineSet", typeof(SplineSet));

	private static Delegate? cb_getCurveFit_GetCurveFit_Landroidx_constraintlayout_core_motion_utils_CurveFit_;

	private static Delegate? cb_get_Get_F_F;

	private static Delegate? cb_getSlope_GetSlope_F_F;

	private static Delegate? cb_setPoint_SetPoint_IF_V;

	private static Delegate? cb_setProperty_SetProperty_Landroidx_constraintlayout_core_motion_utils_TypedValues_F_V;

	private static Delegate? cb_setType_SetType_Ljava_lang_String__V;

	private static Delegate? cb_setup_Setup_I_V;

	[Register("mCurveFit")]
	protected CurveFit? MCurveFit
	{
		get
		{
			return Java.Lang.Object.GetObject<CurveFit>(_members.InstanceFields.GetObjectValue("mCurveFit.Landroidx/constraintlayout/core/motion/utils/CurveFit;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mCurveFit.Landroidx/constraintlayout/core/motion/utils/CurveFit;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mTimePoints")]
	protected IList<int>? MTimePoints
	{
		get
		{
			return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mTimePoints.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mTimePoints.[I", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mValues")]
	protected IList<float>? MValues
	{
		get
		{
			return Android.Runtime.JavaArray<float>.FromJniHandle(_members.InstanceFields.GetObjectValue("mValues.[F", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<float>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mValues.[F", this, new JniObjectReference(num));
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

	public unsafe virtual CurveFit? CurveFit
	{
		[Register("getCurveFit", "()Landroidx/constraintlayout/core/motion/utils/CurveFit;", "GetGetCurveFitHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CurveFit>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurveFit.()Landroidx/constraintlayout/core/motion/utils/CurveFit;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected SplineSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SplineSet()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCurveFitHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCurveFit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurveFit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurveFit);
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

	private static Delegate GetGet_FHandler()
	{
		return new global::_JniMarshal_PPF_F(n_Get_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_Get_F(nint jnienv, nint native__this, float t)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(t);
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

	[Register("get", "(F)F", "GetGet_FHandler")]
	public unsafe virtual float Get(float t)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(t);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("get.(F)F", this, ptr);
	}

	private static Delegate GetGetSlope_FHandler()
	{
		return new global::_JniMarshal_PPF_F(n_GetSlope_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSlope_F(nint jnienv, nint native__this, float t)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSlope(t);
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

	[Register("getSlope", "(F)F", "GetGetSlope_FHandler")]
	public unsafe virtual float GetSlope(float t)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(t);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getSlope.(F)F", this, ptr);
	}

	[Register("makeCustomSpline", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomArray;)Landroidx/constraintlayout/core/motion/utils/SplineSet;", "")]
	public unsafe static SplineSet? MakeCustomSpline(string? str, KeyFrameArray.CustomArray? attrList)
	{
		nint num = JNIEnv.NewString(str);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attrList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SplineSet>(_members.StaticMethods.InvokeObjectMethod("makeCustomSpline.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomArray;)Landroidx/constraintlayout/core/motion/utils/SplineSet;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attrList);
		}
	}

	[Register("makeCustomSplineSet", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;)Landroidx/constraintlayout/core/motion/utils/SplineSet;", "")]
	public unsafe static SplineSet? MakeCustomSplineSet(string? str, KeyFrameArray.CustomVar? attrList)
	{
		nint num = JNIEnv.NewString(str);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attrList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SplineSet>(_members.StaticMethods.InvokeObjectMethod("makeCustomSplineSet.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;)Landroidx/constraintlayout/core/motion/utils/SplineSet;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attrList);
		}
	}

	[Register("makeSpline", "(Ljava/lang/String;J)Landroidx/constraintlayout/core/motion/utils/SplineSet;", "")]
	public unsafe static SplineSet? MakeSpline(string? str, long currentTime)
	{
		nint num = JNIEnv.NewString(str);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(currentTime);
			return Java.Lang.Object.GetObject<SplineSet>(_members.StaticMethods.InvokeObjectMethod("makeSpline.(Ljava/lang/String;J)Landroidx/constraintlayout/core/motion/utils/SplineSet;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetPoint_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetPoint_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPoint_IF(nint jnienv, nint native__this, int position, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPoint(position, value);
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

	[Register("setPoint", "(IF)V", "GetSetPoint_IFHandler")]
	public unsafe virtual void SetPoint(int position, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPoint.(IF)V", this, ptr);
	}

	private static Delegate GetSetProperty_Landroidx_constraintlayout_core_motion_utils_TypedValues_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_SetProperty_Landroidx_constraintlayout_core_motion_utils_TypedValues_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProperty_Landroidx_constraintlayout_core_motion_utils_TypedValues_F(nint jnienv, nint native__this, nint native_widget, float t)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SplineSet? splineSet = Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITypedValues widget = Java.Lang.Object.GetObject<ITypedValues>(native_widget, JniHandleOwnership.DoNotTransfer);
			splineSet.SetProperty(widget, t);
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

	[Register("setProperty", "(Landroidx/constraintlayout/core/motion/utils/TypedValues;F)V", "GetSetProperty_Landroidx_constraintlayout_core_motion_utils_TypedValues_FHandler")]
	public unsafe virtual void SetProperty(ITypedValues? widget, float t)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((widget == null) ? IntPtr.Zero : ((Java.Lang.Object)widget).Handle);
			ptr[1] = new JniArgumentValue(t);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProperty.(Landroidx/constraintlayout/core/motion/utils/TypedValues;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetSetType_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetType_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SplineSet? splineSet = Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			splineSet.SetType(type);
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

	[Register("setType", "(Ljava/lang/String;)V", "GetSetType_Ljava_lang_String_Handler")]
	public unsafe virtual void SetType(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetup_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_Setup_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Setup_I(nint jnienv, nint native__this, int curveType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Setup(curveType);
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

	[Register("setup", "(I)V", "GetSetup_IHandler")]
	public unsafe virtual void Setup(int curveType)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(curveType);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setup.(I)V", this, ptr);
	}
}
