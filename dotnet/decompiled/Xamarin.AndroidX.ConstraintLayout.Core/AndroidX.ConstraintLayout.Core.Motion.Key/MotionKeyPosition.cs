using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Motion.Key;

[Register("androidx/constraintlayout/core/motion/key/MotionKeyPosition", DoNotGenerateAcw = true)]
public class MotionKeyPosition : MotionKey
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/key/MotionKeyPosition", typeof(MotionKeyPosition));

	private static Delegate? cb_addValues_AddValues_Ljava_util_HashMap__V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_core_motion_key_MotionKey_;

	private static Delegate? cb_getAttributeNames_GetAttributeNames_Ljava_util_HashSet__V;

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	private static Delegate? cb_intersects_Intersects_IILandroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FF_Z;

	private static Delegate? cb_positionAttributes_PositionAttributes_Landroidx_constraintlayout_core_motion_MotionWidget_Landroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFarrayLjava_lang_String_arrayF_V;

	[Register("mAltPercentX")]
	public float MAltPercentX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mAltPercentX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mAltPercentX.F", this, value);
		}
	}

	[Register("mAltPercentY")]
	public float MAltPercentY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mAltPercentY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mAltPercentY.F", this, value);
		}
	}

	[Register("mCurveFit")]
	public int MCurveFit
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mCurveFit.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mCurveFit.I", this, value);
		}
	}

	[Register("mDrawPath")]
	public int MDrawPath
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mDrawPath.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mDrawPath.I", this, value);
		}
	}

	[Register("mPathMotionArc")]
	public int MPathMotionArc
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mPathMotionArc.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPathMotionArc.I", this, value);
		}
	}

	[Register("mPercentHeight")]
	public float MPercentHeight
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mPercentHeight.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPercentHeight.F", this, value);
		}
	}

	[Register("mPercentWidth")]
	public float MPercentWidth
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mPercentWidth.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPercentWidth.F", this, value);
		}
	}

	[Register("mPercentX")]
	public float MPercentX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mPercentX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPercentX.F", this, value);
		}
	}

	[Register("mPercentY")]
	public float MPercentY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mPercentY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPercentY.F", this, value);
		}
	}

	[Register("mPositionType")]
	public int MPositionType
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mPositionType.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mPositionType.I", this, value);
		}
	}

	[Register("mTransitionEasing")]
	public string? MTransitionEasing
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mTransitionEasing.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mTransitionEasing.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected MotionKeyPosition(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MotionKeyPosition()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAddValues_Ljava_util_HashMap_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddValues_Ljava_util_HashMap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddValues_Ljava_util_HashMap_(nint jnienv, nint native__this, nint native_splines)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKeyPosition? motionKeyPosition = Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, SplineSet> p = JavaDictionary<string, SplineSet>.FromJniHandle(native_splines, JniHandleOwnership.DoNotTransfer);
			motionKeyPosition.AddValues(p);
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

	[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
	public unsafe override void AddValues(IDictionary<string, SplineSet>? splines)
	{
		nint num = JavaDictionary<string, SplineSet>.ToLocalJniHandle(splines);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addValues.(Ljava/util/HashMap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(splines);
		}
	}

	private static Delegate GetCloneHandler()
	{
		return new global::_JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Landroidx/constraintlayout/core/motion/key/MotionKey;", "GetCloneHandler")]
	public unsafe override MotionKey? Clone()
	{
		return Java.Lang.Object.GetObject<MotionKey>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/constraintlayout/core/motion/key/MotionKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetAttributeNames_Ljava_util_HashSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetAttributeNames_Ljava_util_HashSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetAttributeNames_Ljava_util_HashSet_(nint jnienv, nint native__this, nint native_attributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKeyPosition? motionKeyPosition = Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HashSet p = Java.Lang.Object.GetObject<HashSet>(native_attributes, JniHandleOwnership.DoNotTransfer);
			motionKeyPosition.GetAttributeNames(p);
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

	[Register("getAttributeNames", "(Ljava/util/HashSet;)V", "GetGetAttributeNames_Ljava_util_HashSet_Handler")]
	public unsafe override void GetAttributeNames(HashSet? attributes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(attributes?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getAttributeNames.(Ljava/util/HashSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(attributes);
		}
	}

	private static Delegate GetGetId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKeyPosition? motionKeyPosition = Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motionKeyPosition.GetId(p);
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

	[Register("getId", "(Ljava/lang/String;)I", "GetGetId_Ljava_lang_String_Handler")]
	public unsafe override int GetId(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetIntersects_IILandroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFHandler()
	{
		return new _JniMarshal_PPIILLFF_B(n_Intersects_IILandroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Intersects_IILandroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FF(nint jnienv, nint native__this, int layoutWidth, int layoutHeight, nint native_start, nint native_end, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKeyPosition? motionKeyPosition = Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatRect start = Java.Lang.Object.GetObject<FloatRect>(native_start, JniHandleOwnership.DoNotTransfer);
			FloatRect end = Java.Lang.Object.GetObject<FloatRect>(native_end, JniHandleOwnership.DoNotTransfer);
			return motionKeyPosition.Intersects(layoutWidth, layoutHeight, start, end, x, y) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("intersects", "(IILandroidx/constraintlayout/core/motion/utils/FloatRect;Landroidx/constraintlayout/core/motion/utils/FloatRect;FF)Z", "GetIntersects_IILandroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFHandler")]
	public unsafe virtual bool Intersects(int layoutWidth, int layoutHeight, FloatRect? start, FloatRect? end, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(layoutWidth);
			ptr[1] = new JniArgumentValue(layoutHeight);
			ptr[2] = new JniArgumentValue(start?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(x);
			ptr[5] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("intersects.(IILandroidx/constraintlayout/core/motion/utils/FloatRect;Landroidx/constraintlayout/core/motion/utils/FloatRect;FF)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(start);
			GC.KeepAlive(end);
		}
	}

	private static Delegate GetPositionAttributes_Landroidx_constraintlayout_core_motion_MotionWidget_Landroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFarrayLjava_lang_String_arrayFHandler()
	{
		return new _JniMarshal_PPLLLFFLL_V(n_PositionAttributes_Landroidx_constraintlayout_core_motion_MotionWidget_Landroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFarrayLjava_lang_String_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PositionAttributes_Landroidx_constraintlayout_core_motion_MotionWidget_Landroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFarrayLjava_lang_String_arrayF(nint jnienv, nint native__this, nint native_view, nint native_start, nint native_end, float x, float y, nint native_attribute, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKeyPosition? motionKeyPosition = Java.Lang.Object.GetObject<MotionKeyPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget view = Java.Lang.Object.GetObject<MotionWidget>(native_view, JniHandleOwnership.DoNotTransfer);
			FloatRect start = Java.Lang.Object.GetObject<FloatRect>(native_start, JniHandleOwnership.DoNotTransfer);
			FloatRect end = Java.Lang.Object.GetObject<FloatRect>(native_end, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attribute, JniHandleOwnership.DoNotTransfer, typeof(string));
			float[] array2 = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			motionKeyPosition.PositionAttributes(view, start, end, x, y, array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attribute);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_value);
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

	[Register("positionAttributes", "(Landroidx/constraintlayout/core/motion/MotionWidget;Landroidx/constraintlayout/core/motion/utils/FloatRect;Landroidx/constraintlayout/core/motion/utils/FloatRect;FF[Ljava/lang/String;[F)V", "GetPositionAttributes_Landroidx_constraintlayout_core_motion_MotionWidget_Landroidx_constraintlayout_core_motion_utils_FloatRect_Landroidx_constraintlayout_core_motion_utils_FloatRect_FFarrayLjava_lang_String_arrayFHandler")]
	public unsafe virtual void PositionAttributes(MotionWidget? view, FloatRect? start, FloatRect? end, float x, float y, string[]? attribute, float[]? value)
	{
		nint num = JNIEnv.NewArray(attribute);
		nint num2 = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(x);
			ptr[4] = new JniArgumentValue(y);
			ptr[5] = new JniArgumentValue(num);
			ptr[6] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("positionAttributes.(Landroidx/constraintlayout/core/motion/MotionWidget;Landroidx/constraintlayout/core/motion/utils/FloatRect;Landroidx/constraintlayout/core/motion/utils/FloatRect;FF[Ljava/lang/String;[F)V", this, ptr);
		}
		finally
		{
			if (attribute != null)
			{
				JNIEnv.CopyArray(num, attribute);
				JNIEnv.DeleteLocalRef(num);
			}
			if (value != null)
			{
				JNIEnv.CopyArray(num2, value);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(start);
			GC.KeepAlive(end);
			GC.KeepAlive(attribute);
			GC.KeepAlive(value);
		}
	}
}
