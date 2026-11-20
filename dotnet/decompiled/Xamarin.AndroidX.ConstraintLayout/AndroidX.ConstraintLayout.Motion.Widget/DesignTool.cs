using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/DesignTool", DoNotGenerateAcw = true)]
public class DesignTool : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/DesignTool", typeof(DesignTool));

	private static Delegate? cb_getEndState_GetEndState_Ljava_lang_String_;

	private static Delegate? cb_isInTransition_IsInTransition_Z;

	private static Delegate? cb_getProgress_GetProgress_F;

	private static Delegate? cb_getStartState_GetStartState_Ljava_lang_String_;

	private static Delegate? cb_getState_GetState_Ljava_lang_String_;

	private static Delegate? cb_setState_SetState_Ljava_lang_String__V;

	private static Delegate? cb_getTransitionTimeMs_GetTransitionTimeMs_J;

	private static Delegate? cb_designAccess_DesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI_I;

	private static Delegate? cb_disableAutoTransition_DisableAutoTransition_Z_V;

	private static Delegate? cb_dumpConstraintSet_DumpConstraintSet_Ljava_lang_String__V;

	private static Delegate? cb_getAnimationKeyFrames_GetAnimationKeyFrames_Ljava_lang_Object_arrayF_I;

	private static Delegate? cb_getAnimationPath_GetAnimationPath_Ljava_lang_Object_arrayFI_I;

	private static Delegate? cb_getAnimationRectangles_GetAnimationRectangles_Ljava_lang_Object_arrayF_V;

	private static Delegate? cb_getKeyFrameInfo_GetKeyFrameInfo_Ljava_lang_Object_IarrayI_I;

	private static Delegate? cb_getKeyFramePosition_GetKeyFramePosition_Ljava_lang_Object_IFF_F;

	private static Delegate? cb_getKeyFramePositions_GetKeyFramePositions_Ljava_lang_Object_arrayIarrayF_I;

	private static Delegate? cb_getKeyframe_GetKeyframe_III_Ljava_lang_Object_;

	private static Delegate? cb_getKeyframe_GetKeyframe_Ljava_lang_Object_II_Ljava_lang_Object_;

	private static Delegate? cb_getKeyframeAtLocation_GetKeyframeAtLocation_Ljava_lang_Object_FF_Ljava_lang_Object_;

	private static Delegate? cb_getPositionKeyframe_GetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF_Ljava_lang_Boolean_;

	private static Delegate? cb_setAttributes_SetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object__V;

	private static Delegate? cb_setKeyFrame_SetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object__V;

	private static Delegate? cb_setKeyFramePosition_SetKeyFramePosition_Ljava_lang_Object_IIFF_Z;

	private static Delegate? cb_setKeyframe_SetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object__V;

	private static Delegate? cb_setToolPosition_SetToolPosition_F_V;

	private static Delegate? cb_setTransition_SetTransition_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_setViewDebug_SetViewDebug_Ljava_lang_Object_I_V;

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

	public unsafe virtual string? EndState
	{
		[Register("getEndState", "()Ljava/lang/String;", "GetGetEndStateHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEndState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsInTransition
	{
		[Register("isInTransition", "()Z", "GetIsInTransitionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInTransition.()Z", this, null);
		}
	}

	public unsafe virtual float Progress
	{
		[Register("getProgress", "()F", "GetGetProgressHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
		}
	}

	public unsafe virtual string? StartState
	{
		[Register("getStartState", "()Ljava/lang/String;", "GetGetStartStateHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStartState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? State
	{
		[Register("getState", "()Ljava/lang/String;", "GetGetStateHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setState", "(Ljava/lang/String;)V", "GetSetState_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setState.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual long TransitionTimeMs
	{
		[Register("getTransitionTimeMs", "()J", "GetGetTransitionTimeMsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTransitionTimeMs.()J", this, null);
		}
	}

	protected DesignTool(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "")]
	public unsafe DesignTool(MotionLayout? motionLayout)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionLayout);
		}
	}

	private static Delegate GetGetEndStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEndState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEndState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndState);
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

	private static Delegate GetIsInTransitionHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInTransition ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetProgressHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
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

	private static Delegate GetGetStartStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStartState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStartState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartState);
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

	private static Delegate GetGetStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).State);
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

	private static Delegate GetSetState_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetState_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetState_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string state = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			designTool.State = state;
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

	private static Delegate GetGetTransitionTimeMsHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetTransitionTimeMs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTransitionTimeMs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionTimeMs;
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

	private static Delegate GetDesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFIHandler()
	{
		return new _JniMarshal_PPILLLILI_I(n_DesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI(nint jnienv, nint native__this, int cmd, nint native_type, nint native_viewObject, nint native__in, int inLength, nint native__out, int outLength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object viewObject = Java.Lang.Object.GetObject<Java.Lang.Object>(native_viewObject, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__in, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array2 = (float[])JNIEnv.GetArray(native__out, JniHandleOwnership.DoNotTransfer, typeof(float));
			int result = designTool.DesignAccess(cmd, type, viewObject, array, inLength, array2, outLength);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__in);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native__out);
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

	[Register("designAccess", "(ILjava/lang/String;Ljava/lang/Object;[FI[FI)I", "GetDesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFIHandler")]
	public unsafe virtual int DesignAccess(int cmd, string? type, Java.Lang.Object? viewObject, float[]? @in, int inLength, float[]? @out, int outLength)
	{
		nint num = JNIEnv.NewString(type);
		nint num2 = JNIEnv.NewArray(@in);
		nint num3 = JNIEnv.NewArray(@out);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(cmd);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(viewObject?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num2);
			ptr[4] = new JniArgumentValue(inLength);
			ptr[5] = new JniArgumentValue(num3);
			ptr[6] = new JniArgumentValue(outLength);
			return _members.InstanceMethods.InvokeVirtualInt32Method("designAccess.(ILjava/lang/String;Ljava/lang/Object;[FI[FI)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (@in != null)
			{
				JNIEnv.CopyArray(num2, @in);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (@out != null)
			{
				JNIEnv.CopyArray(num3, @out);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(viewObject);
			GC.KeepAlive(@in);
			GC.KeepAlive(@out);
		}
	}

	private static Delegate GetDisableAutoTransition_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_DisableAutoTransition_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DisableAutoTransition_Z(nint jnienv, nint native__this, sbyte native_disable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool disable = native_disable != 0;
			designTool.DisableAutoTransition(disable);
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

	[Register("disableAutoTransition", "(Z)V", "GetDisableAutoTransition_ZHandler")]
	public unsafe virtual void DisableAutoTransition(bool disable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(disable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("disableAutoTransition.(Z)V", this, ptr);
	}

	private static Delegate GetDumpConstraintSet_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DumpConstraintSet_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DumpConstraintSet_Ljava_lang_String_(nint jnienv, nint native__this, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string set = JNIEnv.GetString(native_set, JniHandleOwnership.DoNotTransfer);
			designTool.DumpConstraintSet(set);
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

	[Register("dumpConstraintSet", "(Ljava/lang/String;)V", "GetDumpConstraintSet_Ljava_lang_String_Handler")]
	public unsafe virtual void DumpConstraintSet(string? set)
	{
		nint num = JNIEnv.NewString(set);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dumpConstraintSet.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetAnimationKeyFrames_Ljava_lang_Object_arrayFHandler()
	{
		return new global::_JniMarshal_PPLL_I(n_GetAnimationKeyFrames_Ljava_lang_Object_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAnimationKeyFrames_Ljava_lang_Object_arrayF(nint jnienv, nint native__this, nint native_view, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_key, JniHandleOwnership.DoNotTransfer, typeof(float));
			int animationKeyFrames = designTool.GetAnimationKeyFrames(view, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_key);
			}
			return animationKeyFrames;
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

	[Register("getAnimationKeyFrames", "(Ljava/lang/Object;[F)I", "GetGetAnimationKeyFrames_Ljava_lang_Object_arrayFHandler")]
	public unsafe virtual int GetAnimationKeyFrames(Java.Lang.Object? view, float[]? key)
	{
		nint num = JNIEnv.NewArray(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimationKeyFrames.(Ljava/lang/Object;[F)I", this, ptr);
		}
		finally
		{
			if (key != null)
			{
				JNIEnv.CopyArray(num, key);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetGetAnimationPath_Ljava_lang_Object_arrayFIHandler()
	{
		return new global::_JniMarshal_PPLLI_I(n_GetAnimationPath_Ljava_lang_Object_arrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAnimationPath_Ljava_lang_Object_arrayFI(nint jnienv, nint native__this, nint native_view, nint native_path, int len)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_path, JniHandleOwnership.DoNotTransfer, typeof(float));
			int animationPath = designTool.GetAnimationPath(view, array, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_path);
			}
			return animationPath;
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

	[Register("getAnimationPath", "(Ljava/lang/Object;[FI)I", "GetGetAnimationPath_Ljava_lang_Object_arrayFIHandler")]
	public unsafe virtual int GetAnimationPath(Java.Lang.Object? view, float[]? path, int len)
	{
		nint num = JNIEnv.NewArray(path);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(len);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimationPath.(Ljava/lang/Object;[FI)I", this, ptr);
		}
		finally
		{
			if (path != null)
			{
				JNIEnv.CopyArray(num, path);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetGetAnimationRectangles_Ljava_lang_Object_arrayFHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_GetAnimationRectangles_Ljava_lang_Object_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetAnimationRectangles_Ljava_lang_Object_arrayF(nint jnienv, nint native__this, nint native_view, nint native_path)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_path, JniHandleOwnership.DoNotTransfer, typeof(float));
			designTool.GetAnimationRectangles(view, array);
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

	[Register("getAnimationRectangles", "(Ljava/lang/Object;[F)V", "GetGetAnimationRectangles_Ljava_lang_Object_arrayFHandler")]
	public unsafe virtual void GetAnimationRectangles(Java.Lang.Object? view, float[]? path)
	{
		nint num = JNIEnv.NewArray(path);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getAnimationRectangles.(Ljava/lang/Object;[F)V", this, ptr);
		}
		finally
		{
			if (path != null)
			{
				JNIEnv.CopyArray(num, path);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetGetKeyFrameInfo_Ljava_lang_Object_IarrayIHandler()
	{
		return new _JniMarshal_PPLIL_I(n_GetKeyFrameInfo_Ljava_lang_Object_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetKeyFrameInfo_Ljava_lang_Object_IarrayI(nint jnienv, nint native__this, nint native_view, int type, nint native_info)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_info, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrameInfo = designTool.GetKeyFrameInfo(view, type, array);
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

	[Register("getKeyFrameInfo", "(Ljava/lang/Object;I[I)I", "GetGetKeyFrameInfo_Ljava_lang_Object_IarrayIHandler")]
	public unsafe virtual int GetKeyFrameInfo(Java.Lang.Object? view, int type, int[]? info)
	{
		nint num = JNIEnv.NewArray(info);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFrameInfo.(Ljava/lang/Object;I[I)I", this, ptr);
		}
		finally
		{
			if (info != null)
			{
				JNIEnv.CopyArray(num, info);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetGetKeyFramePosition_Ljava_lang_Object_IFFHandler()
	{
		return new _JniMarshal_PPLIFF_F(n_GetKeyFramePosition_Ljava_lang_Object_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetKeyFramePosition_Ljava_lang_Object_IFF(nint jnienv, nint native__this, nint native_view, int type, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return designTool.GetKeyFramePosition(view, type, x, y);
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

	[Register("getKeyFramePosition", "(Ljava/lang/Object;IFF)F", "GetGetKeyFramePosition_Ljava_lang_Object_IFFHandler")]
	public unsafe virtual float GetKeyFramePosition(Java.Lang.Object? view, int type, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(x);
			ptr[3] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getKeyFramePosition.(Ljava/lang/Object;IFF)F", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetKeyFramePositions_Ljava_lang_Object_arrayIarrayFHandler()
	{
		return new global::_JniMarshal_PPLLL_I(n_GetKeyFramePositions_Ljava_lang_Object_arrayIarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetKeyFramePositions_Ljava_lang_Object_arrayIarrayF(nint jnienv, nint native__this, nint native_view, nint native_type, nint native_pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_type, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			int keyFramePositions = designTool.GetKeyFramePositions(view, array, array2);
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

	[Register("getKeyFramePositions", "(Ljava/lang/Object;[I[F)I", "GetGetKeyFramePositions_Ljava_lang_Object_arrayIarrayFHandler")]
	public unsafe virtual int GetKeyFramePositions(Java.Lang.Object? view, int[]? type, float[]? pos)
	{
		nint num = JNIEnv.NewArray(type);
		nint num2 = JNIEnv.NewArray(pos);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFramePositions.(Ljava/lang/Object;[I[F)I", this, ptr);
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
			GC.KeepAlive(view);
			GC.KeepAlive(type);
			GC.KeepAlive(pos);
		}
	}

	private static Delegate GetGetKeyframe_IIIHandler()
	{
		return new _JniMarshal_PPIII_L(n_GetKeyframe_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeyframe_III(nint jnienv, nint native__this, int type, int target, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKeyframe(type, target, position));
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

	[Register("getKeyframe", "(III)Ljava/lang/Object;", "GetGetKeyframe_IIIHandler")]
	public unsafe virtual Java.Lang.Object? GetKeyframe(int type, int target, int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(target);
		ptr[2] = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframe.(III)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetKeyframe_Ljava_lang_Object_IIHandler()
	{
		return new global::_JniMarshal_PPLII_L(n_GetKeyframe_Ljava_lang_Object_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeyframe_Ljava_lang_Object_II(nint jnienv, nint native__this, nint native_view, int type, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(designTool.GetKeyframe(view, type, position));
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

	[Register("getKeyframe", "(Ljava/lang/Object;II)Ljava/lang/Object;", "GetGetKeyframe_Ljava_lang_Object_IIHandler")]
	public unsafe virtual Java.Lang.Object? GetKeyframe(Java.Lang.Object? view, int type, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframe.(Ljava/lang/Object;II)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetKeyframeAtLocation_Ljava_lang_Object_FFHandler()
	{
		return new _JniMarshal_PPLFF_L(n_GetKeyframeAtLocation_Ljava_lang_Object_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeyframeAtLocation_Ljava_lang_Object_FF(nint jnienv, nint native__this, nint native_viewObject, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object viewObject = Java.Lang.Object.GetObject<Java.Lang.Object>(native_viewObject, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(designTool.GetKeyframeAtLocation(viewObject, x, y));
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

	[Register("getKeyframeAtLocation", "(Ljava/lang/Object;FF)Ljava/lang/Object;", "GetGetKeyframeAtLocation_Ljava_lang_Object_FFHandler")]
	public unsafe virtual Java.Lang.Object? GetKeyframeAtLocation(Java.Lang.Object? viewObject, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewObject?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframeAtLocation.(Ljava/lang/Object;FF)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(viewObject);
		}
	}

	private static Delegate GetGetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayFHandler()
	{
		return new _JniMarshal_PPLLFFLL_L(n_GetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF(nint jnienv, nint native__this, nint native_keyFrame, nint native_view, float x, float y, nint native_attribute, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object keyFrame = Java.Lang.Object.GetObject<Java.Lang.Object>(native_keyFrame, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attribute, JniHandleOwnership.DoNotTransfer, typeof(string));
			float[] array2 = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			nint result = JNIEnv.ToLocalJniHandle(designTool.GetPositionKeyframe(keyFrame, view, x, y, array, array2));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attribute);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_value);
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

	[Register("getPositionKeyframe", "(Ljava/lang/Object;Ljava/lang/Object;FF[Ljava/lang/String;[F)Ljava/lang/Boolean;", "GetGetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayFHandler")]
	public unsafe virtual Java.Lang.Boolean? GetPositionKeyframe(Java.Lang.Object? keyFrame, Java.Lang.Object? view, float x, float y, string[]? attribute, float[]? value)
	{
		nint num = JNIEnv.NewArray(attribute);
		nint num2 = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(keyFrame?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(x);
			ptr[3] = new JniArgumentValue(y);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPositionKeyframe.(Ljava/lang/Object;Ljava/lang/Object;FF[Ljava/lang/String;[F)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			GC.KeepAlive(keyFrame);
			GC.KeepAlive(view);
			GC.KeepAlive(attribute);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPILLL_V(n_SetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_(nint jnienv, nint native__this, int dpi, nint native_constraintSetId, nint native_opaqueView, nint native_opaqueAttributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string constraintSetId = JNIEnv.GetString(native_constraintSetId, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object opaqueView = Java.Lang.Object.GetObject<Java.Lang.Object>(native_opaqueView, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object opaqueAttributes = Java.Lang.Object.GetObject<Java.Lang.Object>(native_opaqueAttributes, JniHandleOwnership.DoNotTransfer);
			designTool.SetAttributes(dpi, constraintSetId, opaqueView, opaqueAttributes);
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

	[Register("setAttributes", "(ILjava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "GetSetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetAttributes(int dpi, string? constraintSetId, Java.Lang.Object? opaqueView, Java.Lang.Object? opaqueAttributes)
	{
		nint num = JNIEnv.NewString(constraintSetId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(dpi);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(opaqueView?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(opaqueAttributes?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAttributes.(ILjava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(opaqueView);
			GC.KeepAlive(opaqueAttributes);
		}
	}

	private static Delegate GetSetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLILL_V(n_SetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_view, int position, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			designTool.SetKeyFrame(view, position, name, value);
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

	[Register("setKeyFrame", "(Ljava/lang/Object;ILjava/lang/String;Ljava/lang/Object;)V", "GetSetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetKeyFrame(Java.Lang.Object? view, int position, string? name, Java.Lang.Object? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyFrame.(Ljava/lang/Object;ILjava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetKeyFramePosition_Ljava_lang_Object_IIFFHandler()
	{
		return new _JniMarshal_PPLIIFF_B(n_SetKeyFramePosition_Ljava_lang_Object_IIFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetKeyFramePosition_Ljava_lang_Object_IIFF(nint jnienv, nint native__this, nint native_view, int position, int type, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return designTool.SetKeyFramePosition(view, position, type, x, y) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setKeyFramePosition", "(Ljava/lang/Object;IIFF)Z", "GetSetKeyFramePosition_Ljava_lang_Object_IIFFHandler")]
	public unsafe virtual bool SetKeyFramePosition(Java.Lang.Object? view, int position, int type, float x, float y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(type);
			ptr[3] = new JniArgumentValue(x);
			ptr[4] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setKeyFramePosition.(Ljava/lang/Object;IIFF)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_SetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_keyFrame, nint native_tag, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object keyFrame = Java.Lang.Object.GetObject<Java.Lang.Object>(native_keyFrame, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			designTool.SetKeyframe(keyFrame, tag, value);
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

	[Register("setKeyframe", "(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)V", "GetSetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetKeyframe(Java.Lang.Object? keyFrame, string? tag, Java.Lang.Object? value)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(keyFrame?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyframe.(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(keyFrame);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetToolPosition_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetToolPosition_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetToolPosition_F(nint jnienv, nint native__this, float position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetToolPosition(position);
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

	[Register("setToolPosition", "(F)V", "GetSetToolPosition_FHandler")]
	public unsafe virtual void SetToolPosition(float position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setToolPosition.(F)V", this, ptr);
	}

	private static Delegate GetSetTransition_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetTransition_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransition_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_start, nint native_end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string start = JNIEnv.GetString(native_start, JniHandleOwnership.DoNotTransfer);
			string end = JNIEnv.GetString(native_end, JniHandleOwnership.DoNotTransfer);
			designTool.SetTransition(start, end);
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

	[Register("setTransition", "(Ljava/lang/String;Ljava/lang/String;)V", "GetSetTransition_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void SetTransition(string? start, string? end)
	{
		nint num = JNIEnv.NewString(start);
		nint num2 = JNIEnv.NewString(end);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetSetViewDebug_Ljava_lang_Object_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetViewDebug_Ljava_lang_Object_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetViewDebug_Ljava_lang_Object_I(nint jnienv, nint native__this, nint native_view, int debugMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DesignTool? designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			designTool.SetViewDebug(view, debugMode);
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

	[Register("setViewDebug", "(Ljava/lang/Object;I)V", "GetSetViewDebug_Ljava_lang_Object_IHandler")]
	public unsafe virtual void SetViewDebug(Java.Lang.Object? view, int debugMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(debugMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setViewDebug.(Ljava/lang/Object;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}
}
