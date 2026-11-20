using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Key;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion;

[Register("androidx/constraintlayout/core/motion/Motion", DoNotGenerateAcw = true)]
public class Motion : Java.Lang.Object, ITypedValues, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/Motion", typeof(Motion));

	private static Delegate? cb_getAnimateRelativeTo_GetAnimateRelativeTo_Ljava_lang_String_;

	private static Delegate? cb_getCenterX_GetCenterX_F;

	private static Delegate? cb_getCenterY_GetCenterY_F;

	private static Delegate? cb_getDrawPath_GetDrawPath_I;

	private static Delegate? cb_setDrawPath_SetDrawPath_I_V;

	private static Delegate? cb_getFinalHeight_GetFinalHeight_F;

	private static Delegate? cb_getFinalWidth_GetFinalWidth_F;

	private static Delegate? cb_getFinalX_GetFinalX_F;

	private static Delegate? cb_getFinalY_GetFinalY_F;

	private static Delegate? cb_getMotionStagger_GetMotionStagger_F;

	private static Delegate? cb_getStartHeight_GetStartHeight_F;

	private static Delegate? cb_getStartWidth_GetStartWidth_F;

	private static Delegate? cb_getStartX_GetStartX_F;

	private static Delegate? cb_getStartY_GetStartY_F;

	private static Delegate? cb_getTransformPivotTarget_GetTransformPivotTarget_I;

	private static Delegate? cb_setTransformPivotTarget_SetTransformPivotTarget_I_V;

	private static Delegate? cb_getView_GetView_Landroidx_constraintlayout_core_motion_MotionWidget_;

	private static Delegate? cb_setView_SetView_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_addKey_AddKey_Landroidx_constraintlayout_core_motion_key_MotionKey__V;

	private static Delegate? cb_buildKeyFrames_BuildKeyFrames_arrayFarrayIarrayI_I;

	private static Delegate? cb_buildPath_BuildPath_arrayFI_V;

	private static Delegate? cb_buildRect_BuildRect_FarrayFI_V;

	private static Delegate? cb_getCenter_GetCenter_DarrayFarrayF_V;

	private static Delegate? cb_getDpDt_GetDpDt_FFFarrayF_V;

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	private static Delegate? cb_getKeyFrame_GetKeyFrame_I_Landroidx_constraintlayout_core_motion_MotionPaths_;

	private static Delegate? cb_getKeyFrameInfo_GetKeyFrameInfo_IarrayI_I;

	private static Delegate? cb_getKeyFramePositions_GetKeyFramePositions_arrayIarrayF_I;

	private static Delegate? cb_interpolate_Interpolate_Landroidx_constraintlayout_core_motion_MotionWidget_FJLandroidx_constraintlayout_core_motion_utils_KeyCache__Z;

	private static Delegate? cb_setEnd_SetEnd_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_setIdString_SetIdString_Ljava_lang_String__V;

	private static Delegate? cb_setPathMotionArc_SetPathMotionArc_I_V;

	private static Delegate? cb_setStaggerOffset_SetStaggerOffset_F_V;

	private static Delegate? cb_setStaggerScale_SetStaggerScale_F_V;

	private static Delegate? cb_setStart_SetStart_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_setStartState_SetStartState_Landroidx_constraintlayout_core_motion_utils_ViewState_Landroidx_constraintlayout_core_motion_MotionWidget_III_V;

	private static Delegate? cb_setValue_SetValue_IZ_Z;

	private static Delegate? cb_setValue_SetValue_IF_Z;

	private static Delegate? cb_setValue_SetValue_II_Z;

	private static Delegate? cb_setValue_SetValue_ILjava_lang_String__Z;

	private static Delegate? cb_setup_Setup_IIFJ_V;

	private static Delegate? cb_setupRelative_SetupRelative_Landroidx_constraintlayout_core_motion_Motion__V;

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

	public unsafe virtual string? AnimateRelativeTo
	{
		[Register("getAnimateRelativeTo", "()Ljava/lang/String;", "GetGetAnimateRelativeToHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnimateRelativeTo.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float CenterX
	{
		[Register("getCenterX", "()F", "GetGetCenterXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCenterX.()F", this, null);
		}
	}

	public unsafe virtual float CenterY
	{
		[Register("getCenterY", "()F", "GetGetCenterYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCenterY.()F", this, null);
		}
	}

	public unsafe virtual int DrawPath
	{
		[Register("getDrawPath", "()I", "GetGetDrawPathHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawPath.()I", this, null);
		}
		[Register("setDrawPath", "(I)V", "GetSetDrawPath_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawPath.(I)V", this, ptr);
		}
	}

	public unsafe virtual float FinalHeight
	{
		[Register("getFinalHeight", "()F", "GetGetFinalHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFinalHeight.()F", this, null);
		}
	}

	public unsafe virtual float FinalWidth
	{
		[Register("getFinalWidth", "()F", "GetGetFinalWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFinalWidth.()F", this, null);
		}
	}

	public unsafe virtual float FinalX
	{
		[Register("getFinalX", "()F", "GetGetFinalXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFinalX.()F", this, null);
		}
	}

	public unsafe virtual float FinalY
	{
		[Register("getFinalY", "()F", "GetGetFinalYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFinalY.()F", this, null);
		}
	}

	public unsafe virtual float MotionStagger
	{
		[Register("getMotionStagger", "()F", "GetGetMotionStaggerHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMotionStagger.()F", this, null);
		}
	}

	public unsafe virtual float StartHeight
	{
		[Register("getStartHeight", "()F", "GetGetStartHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStartHeight.()F", this, null);
		}
	}

	public unsafe virtual float StartWidth
	{
		[Register("getStartWidth", "()F", "GetGetStartWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStartWidth.()F", this, null);
		}
	}

	public unsafe virtual float StartX
	{
		[Register("getStartX", "()F", "GetGetStartXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStartX.()F", this, null);
		}
	}

	public unsafe virtual float StartY
	{
		[Register("getStartY", "()F", "GetGetStartYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStartY.()F", this, null);
		}
	}

	public unsafe virtual int TransformPivotTarget
	{
		[Register("getTransformPivotTarget", "()I", "GetGetTransformPivotTargetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTransformPivotTarget.()I", this, null);
		}
		[Register("setTransformPivotTarget", "(I)V", "GetSetTransformPivotTarget_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivotTarget.(I)V", this, ptr);
		}
	}

	public unsafe virtual MotionWidget? View
	{
		[Register("getView", "()Landroidx/constraintlayout/core/motion/MotionWidget;", "GetGetViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MotionWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroidx/constraintlayout/core/motion/MotionWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setView", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetSetView_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setView.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected Motion(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "")]
	public unsafe Motion(MotionWidget? view)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/motion/MotionWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetAnimateRelativeToHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnimateRelativeTo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnimateRelativeTo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateRelativeTo);
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

	private static Delegate GetGetCenterXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCenterX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCenterX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterX;
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

	private static Delegate GetGetCenterYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCenterY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCenterY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterY;
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

	private static Delegate GetGetDrawPathHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDrawPath);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDrawPath(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath;
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

	private static Delegate GetSetDrawPath_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDrawPath_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawPath_I(nint jnienv, nint native__this, int debugMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath = debugMode;
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

	private static Delegate GetGetFinalHeightHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFinalHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFinalHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalHeight;
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

	private static Delegate GetGetFinalWidthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFinalWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFinalWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalWidth;
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

	private static Delegate GetGetFinalXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFinalX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFinalX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalX;
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

	private static Delegate GetGetFinalYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFinalY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFinalY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalY;
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

	private static Delegate GetGetMotionStaggerHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetMotionStagger);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetMotionStagger(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MotionStagger;
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

	private static Delegate GetGetStartHeightHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStartHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStartHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartHeight;
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

	private static Delegate GetGetStartWidthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStartWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStartWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartWidth;
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

	private static Delegate GetGetStartXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStartX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStartX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartX;
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

	private static Delegate GetGetStartYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStartY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStartY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartY;
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

	private static Delegate GetGetTransformPivotTargetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTransformPivotTarget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTransformPivotTarget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransformPivotTarget;
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

	private static Delegate GetSetTransformPivotTarget_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTransformPivotTarget_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransformPivotTarget_I(nint jnienv, nint native__this, int transformPivotTarget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransformPivotTarget = transformPivotTarget;
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

	private static Delegate GetGetViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	private static Delegate GetSetView_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetView_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetView_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget view = Java.Lang.Object.GetObject<MotionWidget>(native_view, JniHandleOwnership.DoNotTransfer);
			motion.View = view;
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

	private static Delegate GetAddKey_Landroidx_constraintlayout_core_motion_key_MotionKey_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddKey_Landroidx_constraintlayout_core_motion_key_MotionKey_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKey_Landroidx_constraintlayout_core_motion_key_MotionKey_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionKey key = Java.Lang.Object.GetObject<MotionKey>(native_key, JniHandleOwnership.DoNotTransfer);
			motion.AddKey(key);
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

	[Register("addKey", "(Landroidx/constraintlayout/core/motion/key/MotionKey;)V", "GetAddKey_Landroidx_constraintlayout_core_motion_key_MotionKey_Handler")]
	public unsafe virtual void AddKey(MotionKey? key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKey.(Landroidx/constraintlayout/core/motion/key/MotionKey;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetBuildKeyFrames_arrayFarrayIarrayIHandler()
	{
		return new global::_JniMarshal_PPLLL_I(n_BuildKeyFrames_arrayFarrayIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_BuildKeyFrames_arrayFarrayIarrayI(nint jnienv, nint native__this, nint native_keyFrames, nint native_mode, nint native_pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_keyFrames, JniHandleOwnership.DoNotTransfer, typeof(float));
			int[] array2 = (int[])JNIEnv.GetArray(native_mode, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array3 = (int[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(int));
			int result = motion.BuildKeyFrames(array, array2, array3);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_keyFrames);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_mode);
			}
			if (array3 != null)
			{
				JNIEnv.CopyArray(array3, native_pos);
			}
			return result;
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

	[Register("buildKeyFrames", "([F[I[I)I", "GetBuildKeyFrames_arrayFarrayIarrayIHandler")]
	public unsafe virtual int BuildKeyFrames(float[]? keyFrames, int[]? mode, int[]? pos)
	{
		nint num = JNIEnv.NewArray(keyFrames);
		nint num2 = JNIEnv.NewArray(mode);
		nint num3 = JNIEnv.NewArray(pos);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return _members.InstanceMethods.InvokeVirtualInt32Method("buildKeyFrames.([F[I[I)I", this, ptr);
		}
		finally
		{
			if (keyFrames != null)
			{
				JNIEnv.CopyArray(num, keyFrames);
				JNIEnv.DeleteLocalRef(num);
			}
			if (mode != null)
			{
				JNIEnv.CopyArray(num2, mode);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (pos != null)
			{
				JNIEnv.CopyArray(num3, pos);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(keyFrames);
			GC.KeepAlive(mode);
			GC.KeepAlive(pos);
		}
	}

	private static Delegate GetBuildPath_arrayFIHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_BuildPath_arrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BuildPath_arrayFI(nint jnienv, nint native__this, nint native_points, int pointCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_points, JniHandleOwnership.DoNotTransfer, typeof(float));
			motion.BuildPath(array, pointCount);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_points);
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

	[Register("buildPath", "([FI)V", "GetBuildPath_arrayFIHandler")]
	public unsafe virtual void BuildPath(float[]? points, int pointCount)
	{
		nint num = JNIEnv.NewArray(points);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(pointCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("buildPath.([FI)V", this, ptr);
		}
		finally
		{
			if (points != null)
			{
				JNIEnv.CopyArray(num, points);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(points);
		}
	}

	private static Delegate GetBuildRect_FarrayFIHandler()
	{
		return new _JniMarshal_PPFLI_V(n_BuildRect_FarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BuildRect_FarrayFI(nint jnienv, nint native__this, float p, nint native_path, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_path, JniHandleOwnership.DoNotTransfer, typeof(float));
			motion.BuildRect(p, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_path);
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

	[Register("buildRect", "(F[FI)V", "GetBuildRect_FarrayFIHandler")]
	public unsafe virtual void BuildRect(float p, float[]? path, int offset)
	{
		nint num = JNIEnv.NewArray(path);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members.InstanceMethods.InvokeVirtualVoidMethod("buildRect.(F[FI)V", this, ptr);
		}
		finally
		{
			if (path != null)
			{
				JNIEnv.CopyArray(num, path);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetGetCenter_DarrayFarrayFHandler()
	{
		return new _JniMarshal_PPDLL_V(n_GetCenter_DarrayFarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetCenter_DarrayFarrayF(nint jnienv, nint native__this, double p, nint native_pos, nint native_vel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array2 = (float[])JNIEnv.GetArray(native_vel, JniHandleOwnership.DoNotTransfer, typeof(float));
			motion.GetCenter(p, array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_pos);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_vel);
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

	[Register("getCenter", "(D[F[F)V", "GetGetCenter_DarrayFarrayFHandler")]
	public unsafe virtual void GetCenter(double p, float[]? pos, float[]? vel)
	{
		nint num = JNIEnv.NewArray(pos);
		nint num2 = JNIEnv.NewArray(vel);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getCenter.(D[F[F)V", this, ptr);
		}
		finally
		{
			if (pos != null)
			{
				JNIEnv.CopyArray(num, pos);
				JNIEnv.DeleteLocalRef(num);
			}
			if (vel != null)
			{
				JNIEnv.CopyArray(num2, vel);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(pos);
			GC.KeepAlive(vel);
		}
	}

	private static Delegate GetGetDpDt_FFFarrayFHandler()
	{
		return new global::_JniMarshal_PPFFFL_V(n_GetDpDt_FFFarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetDpDt_FFFarrayF(nint jnienv, nint native__this, float position, float locationX, float locationY, nint native_mAnchorDpDt)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_mAnchorDpDt, JniHandleOwnership.DoNotTransfer, typeof(float));
			motion.GetDpDt(position, locationX, locationY, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_mAnchorDpDt);
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

	[Register("getDpDt", "(FFF[F)V", "GetGetDpDt_FFFarrayFHandler")]
	public unsafe virtual void GetDpDt(float position, float locationX, float locationY, float[]? mAnchorDpDt)
	{
		nint num = JNIEnv.NewArray(mAnchorDpDt);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(locationX);
			ptr[2] = new JniArgumentValue(locationY);
			ptr[3] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getDpDt.(FFF[F)V", this, ptr);
		}
		finally
		{
			if (mAnchorDpDt != null)
			{
				JNIEnv.CopyArray(num, mAnchorDpDt);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(mAnchorDpDt);
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
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motion.GetId(name);
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
	public unsafe virtual int GetId(string? name)
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

	private static Delegate GetGetKeyFrame_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetKeyFrame_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeyFrame_I(nint jnienv, nint native__this, int i)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKeyFrame(i));
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

	[Register("getKeyFrame", "(I)Landroidx/constraintlayout/core/motion/MotionPaths;", "GetGetKeyFrame_IHandler")]
	public unsafe virtual MotionPaths? GetKeyFrame(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return Java.Lang.Object.GetObject<MotionPaths>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyFrame.(I)Landroidx/constraintlayout/core/motion/MotionPaths;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetKeyFrameInfo_IarrayIHandler()
	{
		return new global::_JniMarshal_PPIL_I(n_GetKeyFrameInfo_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetKeyFrameInfo_IarrayI(nint jnienv, nint native__this, int type, nint native_info)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_info, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrameInfo = motion.GetKeyFrameInfo(type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_info);
			}
			return keyFrameInfo;
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

	[Register("getKeyFrameInfo", "(I[I)I", "GetGetKeyFrameInfo_IarrayIHandler")]
	public unsafe virtual int GetKeyFrameInfo(int type, int[]? info)
	{
		nint num = JNIEnv.NewArray(info);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFrameInfo.(I[I)I", this, ptr);
		}
		finally
		{
			if (info != null)
			{
				JNIEnv.CopyArray(num, info);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetGetKeyFramePositions_arrayIarrayFHandler()
	{
		return new global::_JniMarshal_PPLL_I(n_GetKeyFramePositions_arrayIarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetKeyFramePositions_arrayIarrayF(nint jnienv, nint native__this, nint native_type, nint native_pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_type, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			int keyFramePositions = motion.GetKeyFramePositions(array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_type);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_pos);
			}
			return keyFramePositions;
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

	[Register("getKeyFramePositions", "([I[F)I", "GetGetKeyFramePositions_arrayIarrayFHandler")]
	public unsafe virtual int GetKeyFramePositions(int[]? type, float[]? pos)
	{
		nint num = JNIEnv.NewArray(type);
		nint num2 = JNIEnv.NewArray(pos);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFramePositions.([I[F)I", this, ptr);
		}
		finally
		{
			if (type != null)
			{
				JNIEnv.CopyArray(num, type);
				JNIEnv.DeleteLocalRef(num);
			}
			if (pos != null)
			{
				JNIEnv.CopyArray(num2, pos);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(type);
			GC.KeepAlive(pos);
		}
	}

	private static Delegate GetInterpolate_Landroidx_constraintlayout_core_motion_MotionWidget_FJLandroidx_constraintlayout_core_motion_utils_KeyCache_Handler()
	{
		return new _JniMarshal_PPLFJL_B(n_Interpolate_Landroidx_constraintlayout_core_motion_MotionWidget_FJLandroidx_constraintlayout_core_motion_utils_KeyCache_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Interpolate_Landroidx_constraintlayout_core_motion_MotionWidget_FJLandroidx_constraintlayout_core_motion_utils_KeyCache_(nint jnienv, nint native__this, nint native_child, float globalPosition, long time, nint native_keyCache)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget child = Java.Lang.Object.GetObject<MotionWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			KeyCache keyCache = Java.Lang.Object.GetObject<KeyCache>(native_keyCache, JniHandleOwnership.DoNotTransfer);
			return motion.Interpolate(child, globalPosition, time, keyCache) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("interpolate", "(Landroidx/constraintlayout/core/motion/MotionWidget;FJLandroidx/constraintlayout/core/motion/utils/KeyCache;)Z", "GetInterpolate_Landroidx_constraintlayout_core_motion_MotionWidget_FJLandroidx_constraintlayout_core_motion_utils_KeyCache_Handler")]
	public unsafe virtual bool Interpolate(MotionWidget? child, float globalPosition, long time, KeyCache? keyCache)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(globalPosition);
			ptr[2] = new JniArgumentValue(time);
			ptr[3] = new JniArgumentValue(keyCache?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("interpolate.(Landroidx/constraintlayout/core/motion/MotionWidget;FJLandroidx/constraintlayout/core/motion/utils/KeyCache;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(keyCache);
		}
	}

	private static Delegate GetSetEnd_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEnd_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnd_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_mw)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget end = Java.Lang.Object.GetObject<MotionWidget>(native_mw, JniHandleOwnership.DoNotTransfer);
			motion.SetEnd(end);
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

	[Register("setEnd", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetSetEnd_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
	public unsafe virtual void SetEnd(MotionWidget? mw)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mw?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnd.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mw);
		}
	}

	private static Delegate GetSetIdString_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIdString_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIdString_Ljava_lang_String_(nint jnienv, nint native__this, nint native_stringId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string idString = JNIEnv.GetString(native_stringId, JniHandleOwnership.DoNotTransfer);
			motion.SetIdString(idString);
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

	[Register("setIdString", "(Ljava/lang/String;)V", "GetSetIdString_Ljava_lang_String_Handler")]
	public unsafe virtual void SetIdString(string? stringId)
	{
		nint num = JNIEnv.NewString(stringId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIdString.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetPathMotionArc_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPathMotionArc_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPathMotionArc_I(nint jnienv, nint native__this, int arc)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPathMotionArc(arc);
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

	[Register("setPathMotionArc", "(I)V", "GetSetPathMotionArc_IHandler")]
	public unsafe virtual void SetPathMotionArc(int arc)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(arc);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPathMotionArc.(I)V", this, ptr);
	}

	private static Delegate GetSetStaggerOffset_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetStaggerOffset_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStaggerOffset_F(nint jnienv, nint native__this, float staggerOffset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStaggerOffset(staggerOffset);
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

	[Register("setStaggerOffset", "(F)V", "GetSetStaggerOffset_FHandler")]
	public unsafe virtual void SetStaggerOffset(float staggerOffset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(staggerOffset);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStaggerOffset.(F)V", this, ptr);
	}

	private static Delegate GetSetStaggerScale_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetStaggerScale_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStaggerScale_F(nint jnienv, nint native__this, float staggerScale)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStaggerScale(staggerScale);
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

	[Register("setStaggerScale", "(F)V", "GetSetStaggerScale_FHandler")]
	public unsafe virtual void SetStaggerScale(float staggerScale)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(staggerScale);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStaggerScale.(F)V", this, ptr);
	}

	private static Delegate GetSetStart_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStart_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStart_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_mw)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget start = Java.Lang.Object.GetObject<MotionWidget>(native_mw, JniHandleOwnership.DoNotTransfer);
			motion.SetStart(start);
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

	[Register("setStart", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetSetStart_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
	public unsafe virtual void SetStart(MotionWidget? mw)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mw?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStart.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mw);
		}
	}

	private static Delegate GetSetStartState_Landroidx_constraintlayout_core_motion_utils_ViewState_Landroidx_constraintlayout_core_motion_MotionWidget_IIIHandler()
	{
		return new _JniMarshal_PPLLIII_V(n_SetStartState_Landroidx_constraintlayout_core_motion_utils_ViewState_Landroidx_constraintlayout_core_motion_MotionWidget_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartState_Landroidx_constraintlayout_core_motion_utils_ViewState_Landroidx_constraintlayout_core_motion_MotionWidget_III(nint jnienv, nint native__this, nint native_rect, nint native_v, int rotation, int preWidth, int preHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewState rect = Java.Lang.Object.GetObject<ViewState>(native_rect, JniHandleOwnership.DoNotTransfer);
			MotionWidget v = Java.Lang.Object.GetObject<MotionWidget>(native_v, JniHandleOwnership.DoNotTransfer);
			motion.SetStartState(rect, v, rotation, preWidth, preHeight);
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

	[Register("setStartState", "(Landroidx/constraintlayout/core/motion/utils/ViewState;Landroidx/constraintlayout/core/motion/MotionWidget;III)V", "GetSetStartState_Landroidx_constraintlayout_core_motion_utils_ViewState_Landroidx_constraintlayout_core_motion_MotionWidget_IIIHandler")]
	public unsafe virtual void SetStartState(ViewState? rect, MotionWidget? v, int rotation, int preWidth, int preHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(rotation);
			ptr[3] = new JniArgumentValue(preWidth);
			ptr[4] = new JniArgumentValue(preHeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartState.(Landroidx/constraintlayout/core/motion/utils/ViewState;Landroidx/constraintlayout/core/motion/MotionWidget;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetSetValue_IZHandler()
	{
		return new global::_JniMarshal_PPIB_B(n_SetValue_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IZ(nint jnienv, nint native__this, int id, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return motion.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IZ)Z", "GetSetValue_IZHandler")]
	public unsafe virtual bool SetValue(int id, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IZ)Z", this, ptr);
	}

	private static Delegate GetSetValue_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValue_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IF(nint jnienv, nint native__this, int id, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IF)Z", "GetSetValue_IFHandler")]
	public unsafe virtual bool SetValue(int id, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValue_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_SetValue_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_II(nint jnienv, nint native__this, int id, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(II)Z", "GetSetValue_IIHandler")]
	public unsafe virtual bool SetValue(int id, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(II)Z", this, ptr);
	}

	private static Delegate GetSetValue_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_SetValue_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_ILjava_lang_String_(nint jnienv, nint native__this, int id, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return motion.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(ILjava/lang/String;)Z", "GetSetValue_ILjava_lang_String_Handler")]
	public unsafe virtual bool SetValue(int id, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetup_IIFJHandler()
	{
		return new _JniMarshal_PPIIFJ_V(n_Setup_IIFJ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Setup_IIFJ(nint jnienv, nint native__this, int parentWidth, int parentHeight, float transitionDuration, long currentTime)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Setup(parentWidth, parentHeight, transitionDuration, currentTime);
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

	[Register("setup", "(IIFJ)V", "GetSetup_IIFJHandler")]
	public unsafe virtual void Setup(int parentWidth, int parentHeight, float transitionDuration, long currentTime)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(parentWidth);
		ptr[1] = new JniArgumentValue(parentHeight);
		ptr[2] = new JniArgumentValue(transitionDuration);
		ptr[3] = new JniArgumentValue(currentTime);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setup.(IIFJ)V", this, ptr);
	}

	private static Delegate GetSetupRelative_Landroidx_constraintlayout_core_motion_Motion_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetupRelative_Landroidx_constraintlayout_core_motion_Motion_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupRelative_Landroidx_constraintlayout_core_motion_Motion_(nint jnienv, nint native__this, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Motion motionController = Java.Lang.Object.GetObject<Motion>(native_motionController, JniHandleOwnership.DoNotTransfer);
			motion.SetupRelative(motionController);
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

	[Register("setupRelative", "(Landroidx/constraintlayout/core/motion/Motion;)V", "GetSetupRelative_Landroidx_constraintlayout_core_motion_Motion_Handler")]
	public unsafe virtual void SetupRelative(Motion? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupRelative.(Landroidx/constraintlayout/core/motion/Motion;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
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
