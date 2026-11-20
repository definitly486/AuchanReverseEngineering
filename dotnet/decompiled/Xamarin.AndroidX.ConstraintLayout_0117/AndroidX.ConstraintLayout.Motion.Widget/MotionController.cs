using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using AndroidX.ConstraintLayout.Motion.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/MotionController", DoNotGenerateAcw = true)]
public class MotionController : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionController", typeof(MotionController));

	private static Delegate? cb_getAnimateRelativeTo_GetAnimateRelativeTo_I;

	private static Delegate? cb_getCenterX_GetCenterX_F;

	private static Delegate? cb_getCenterY_GetCenterY_F;

	private static Delegate? cb_getDrawPath_GetDrawPath_I;

	private static Delegate? cb_setDrawPath_SetDrawPath_I_V;

	private static Delegate? cb_getFinalHeight_GetFinalHeight_F;

	private static Delegate? cb_getFinalWidth_GetFinalWidth_F;

	private static Delegate? cb_getFinalX_GetFinalX_F;

	private static Delegate? cb_getFinalY_GetFinalY_F;

	private static Delegate? cb_getStartHeight_GetStartHeight_F;

	private static Delegate? cb_getStartWidth_GetStartWidth_F;

	private static Delegate? cb_getStartX_GetStartX_F;

	private static Delegate? cb_getStartY_GetStartY_F;

	private static Delegate? cb_getTransformPivotTarget_GetTransformPivotTarget_I;

	private static Delegate? cb_setTransformPivotTarget_SetTransformPivotTarget_I_V;

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_setView_SetView_Landroid_view_View__V;

	private static Delegate? cb_addKey_AddKey_Landroidx_constraintlayout_motion_widget_Key__V;

	private static Delegate? cb_getCenter_GetCenter_DarrayFarrayF_V;

	private static Delegate? cb_getKeyFrameInfo_GetKeyFrameInfo_IarrayI_I;

	private static Delegate? cb_getKeyFramePositions_GetKeyFramePositions_arrayIarrayF_I;

	private static Delegate? cb_remeasure_Remeasure_V;

	private static Delegate? cb_setPathMotionArc_SetPathMotionArc_I_V;

	private static Delegate? cb_setStartState_SetStartState_Landroidx_constraintlayout_motion_utils_ViewState_Landroid_view_View_III_V;

	private static Delegate? cb_setup_Setup_IIFJ_V;

	private static Delegate? cb_setupRelative_SetupRelative_Landroidx_constraintlayout_motion_widget_MotionController__V;

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

	public unsafe virtual int AnimateRelativeTo
	{
		[Register("getAnimateRelativeTo", "()I", "GetGetAnimateRelativeToHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimateRelativeTo.()I", this, null);
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

	public unsafe virtual View? View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setView", "(Landroid/view/View;)V", "GetSetView_Landroid_view_View_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected MotionController(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetAnimateRelativeToHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetAnimateRelativeTo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAnimateRelativeTo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateRelativeTo;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterX;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterY;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath;
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
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath = debugMode;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalHeight;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalWidth;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalX;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalY;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartHeight;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartWidth;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartX;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartY;
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
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransformPivotTarget;
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
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransformPivotTarget = transformPivotTarget;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	private static Delegate GetSetView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			motionController.View = view;
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

	private static Delegate GetAddKey_Landroidx_constraintlayout_motion_widget_Key_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddKey_Landroidx_constraintlayout_motion_widget_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKey_Landroidx_constraintlayout_motion_widget_Key_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Key key = Java.Lang.Object.GetObject<Key>(native_key, JniHandleOwnership.DoNotTransfer);
			motionController.AddKey(key);
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

	[Register("addKey", "(Landroidx/constraintlayout/motion/widget/Key;)V", "GetAddKey_Landroidx_constraintlayout_motion_widget_Key_Handler")]
	public unsafe virtual void AddKey(Key? key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKey.(Landroidx/constraintlayout/motion/widget/Key;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetGetCenter_DarrayFarrayFHandler()
	{
		return new global::_JniMarshal_PPDLL_V(n_GetCenter_DarrayFarrayF);
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
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array2 = (float[])JNIEnv.GetArray(native_vel, JniHandleOwnership.DoNotTransfer, typeof(float));
			motionController.GetCenter(p, array, array2);
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
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_info, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrameInfo = motionController.GetKeyFrameInfo(type, array);
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
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_type, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			int keyFramePositions = motionController.GetKeyFramePositions(array, array2);
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

	private static Delegate GetRemeasureHandler()
	{
		return new global::_JniMarshal_PP_V(n_Remeasure);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Remeasure(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remeasure();
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

	[Register("remeasure", "()V", "GetRemeasureHandler")]
	public unsafe virtual void Remeasure()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("remeasure.()V", this, null);
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
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPathMotionArc(arc);
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

	private static Delegate GetSetStartState_Landroidx_constraintlayout_motion_utils_ViewState_Landroid_view_View_IIIHandler()
	{
		return new global::_JniMarshal_PPLLIII_V(n_SetStartState_Landroidx_constraintlayout_motion_utils_ViewState_Landroid_view_View_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartState_Landroidx_constraintlayout_motion_utils_ViewState_Landroid_view_View_III(nint jnienv, nint native__this, nint native_rect, nint native_v, int rotation, int preWidth, int preHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewState rect = Java.Lang.Object.GetObject<ViewState>(native_rect, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			motionController.SetStartState(rect, v, rotation, preWidth, preHeight);
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

	[Register("setStartState", "(Landroidx/constraintlayout/motion/utils/ViewState;Landroid/view/View;III)V", "GetSetStartState_Landroidx_constraintlayout_motion_utils_ViewState_Landroid_view_View_IIIHandler")]
	public unsafe virtual void SetStartState(ViewState? rect, View? v, int rotation, int preWidth, int preHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(rotation);
			ptr[3] = new JniArgumentValue(preWidth);
			ptr[4] = new JniArgumentValue(preHeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartState.(Landroidx/constraintlayout/motion/utils/ViewState;Landroid/view/View;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetSetup_IIFJHandler()
	{
		return new global::_JniMarshal_PPIIFJ_V(n_Setup_IIFJ);
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
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Setup(parentWidth, parentHeight, transitionDuration, currentTime);
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

	private static Delegate GetSetupRelative_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetupRelative_Landroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupRelative_Landroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionController? motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController2 = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			motionController.SetupRelative(motionController2);
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

	[Register("setupRelative", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetSetupRelative_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual void SetupRelative(MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupRelative.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}
}
