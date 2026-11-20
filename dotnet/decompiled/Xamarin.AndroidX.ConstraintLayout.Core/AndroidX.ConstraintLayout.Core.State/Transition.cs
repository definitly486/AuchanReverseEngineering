using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using AndroidX.ConstraintLayout.Core.Widgets;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/Transition", DoNotGenerateAcw = true)]
public class Transition : Java.Lang.Object, ITypedValues, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/constraintlayout/core/state/Transition$WidgetState", DoNotGenerateAcw = true)]
	public class WidgetState : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/state/Transition$WidgetState", typeof(WidgetState));

		private static Delegate? cb_getFrame_GetFrame_I_Landroidx_constraintlayout_core_state_WidgetFrame_;

		private static Delegate? cb_interpolate_Interpolate_IIFLandroidx_constraintlayout_core_state_Transition__V;

		private static Delegate? cb_setKeyAttribute_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

		private static Delegate? cb_setKeyAttribute_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable__V;

		private static Delegate? cb_setKeyCycle_SetKeyCycle_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

		private static Delegate? cb_setKeyPosition_SetKeyPosition_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

		private static Delegate? cb_setPathRelative_SetPathRelative_Landroidx_constraintlayout_core_state_Transition_WidgetState__V;

		private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I_V;

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

		protected WidgetState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WidgetState()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetFrame_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_GetFrame_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetFrame_I(nint jnienv, nint native__this, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFrame(type));
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

		[Register("getFrame", "(I)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetFrame_IHandler")]
		public unsafe virtual WidgetFrame? GetFrame(int type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(type);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrame.(I)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetInterpolate_IIFLandroidx_constraintlayout_core_state_Transition_Handler()
		{
			return new _JniMarshal_PPIIFL_V(n_Interpolate_IIFLandroidx_constraintlayout_core_state_Transition_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Interpolate_IIFLandroidx_constraintlayout_core_state_Transition_(nint jnienv, nint native__this, int parentWidth, int parentHeight, float progress, nint native_transition)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition2 = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				widgetState.Interpolate(parentWidth, parentHeight, progress, transition2);
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

		[Register("interpolate", "(IIFLandroidx/constraintlayout/core/state/Transition;)V", "GetInterpolate_IIFLandroidx_constraintlayout_core_state_Transition_Handler")]
		public unsafe virtual void Interpolate(int parentWidth, int parentHeight, float progress, Transition? transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parentWidth);
				ptr[1] = new JniArgumentValue(parentHeight);
				ptr[2] = new JniArgumentValue(progress);
				ptr[3] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("interpolate.(IIFLandroidx/constraintlayout/core/state/Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_prop)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TypedBundle keyAttribute = Java.Lang.Object.GetObject<TypedBundle>(native_prop, JniHandleOwnership.DoNotTransfer);
				widgetState.SetKeyAttribute(keyAttribute);
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

		[Register("setKeyAttribute", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetSetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
		public unsafe virtual void SetKeyAttribute(TypedBundle? prop)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(prop?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyAttribute.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(prop);
			}
		}

		private static Delegate GetSetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_(nint jnienv, nint native__this, nint native_prop, nint native_custom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TypedBundle prop = Java.Lang.Object.GetObject<TypedBundle>(native_prop, JniHandleOwnership.DoNotTransfer);
				CustomVariable[] array = (CustomVariable[])JNIEnv.GetArray(native_custom, JniHandleOwnership.DoNotTransfer, typeof(CustomVariable));
				widgetState.SetKeyAttribute(prop, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_custom);
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

		[Register("setKeyAttribute", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;[Landroidx/constraintlayout/core/motion/CustomVariable;)V", "GetSetKeyAttribute_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_Handler")]
		public unsafe virtual void SetKeyAttribute(TypedBundle? prop, CustomVariable[]? custom)
		{
			nint num = JNIEnv.NewArray(custom);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(prop?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyAttribute.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;[Landroidx/constraintlayout/core/motion/CustomVariable;)V", this, ptr);
			}
			finally
			{
				if (custom != null)
				{
					JNIEnv.CopyArray(num, custom);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(prop);
				GC.KeepAlive(custom);
			}
		}

		private static Delegate GetSetKeyCycle_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetKeyCycle_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetKeyCycle_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_prop)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TypedBundle keyCycle = Java.Lang.Object.GetObject<TypedBundle>(native_prop, JniHandleOwnership.DoNotTransfer);
				widgetState.SetKeyCycle(keyCycle);
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

		[Register("setKeyCycle", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetSetKeyCycle_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
		public unsafe virtual void SetKeyCycle(TypedBundle? prop)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(prop?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyCycle.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(prop);
			}
		}

		private static Delegate GetSetKeyPosition_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetKeyPosition_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetKeyPosition_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_prop)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TypedBundle keyPosition = Java.Lang.Object.GetObject<TypedBundle>(native_prop, JniHandleOwnership.DoNotTransfer);
				widgetState.SetKeyPosition(keyPosition);
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

		[Register("setKeyPosition", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetSetKeyPosition_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
		public unsafe virtual void SetKeyPosition(TypedBundle? prop)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(prop?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyPosition.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(prop);
			}
		}

		private static Delegate GetSetPathRelative_Landroidx_constraintlayout_core_state_Transition_WidgetState_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetPathRelative_Landroidx_constraintlayout_core_state_Transition_WidgetState_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetPathRelative_Landroidx_constraintlayout_core_state_Transition_WidgetState_(nint jnienv, nint native__this, nint native_widgetState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WidgetState pathRelative = Java.Lang.Object.GetObject<WidgetState>(native_widgetState, JniHandleOwnership.DoNotTransfer);
				widgetState.SetPathRelative(pathRelative);
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

		[Register("setPathRelative", "(Landroidx/constraintlayout/core/state/Transition$WidgetState;)V", "GetSetPathRelative_Landroidx_constraintlayout_core_state_Transition_WidgetState_Handler")]
		public unsafe virtual void SetPathRelative(WidgetState? widgetState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widgetState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPathRelative.(Landroidx/constraintlayout/core/state/Transition$WidgetState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widgetState);
			}
		}

		private static Delegate GetUpdate_Landroidx_constraintlayout_core_widgets_ConstraintWidget_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I(nint jnienv, nint native__this, nint native_child, int state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				WidgetState? widgetState = Java.Lang.Object.GetObject<WidgetState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
				widgetState.Update(child, state);
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

		[Register("update", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;I)V", "GetUpdate_Landroidx_constraintlayout_core_widgets_ConstraintWidget_IHandler")]
		public unsafe virtual void Update(ConstraintWidget? child, int state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state);
				_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/state/Transition", typeof(Transition));

	private static Delegate? cb_getAutoTransition_GetAutoTransition_I;

	private static Delegate? cb_hasOnSwipe_HasOnSwipe_Z;

	private static Delegate? cb_hasPositionKeyframes_HasPositionKeyframes_Z;

	private static Delegate? cb_getInterpolatedHeight_GetInterpolatedHeight_I;

	private static Delegate? cb_getInterpolatedWidth_GetInterpolatedWidth_I;

	private static Delegate? cb_getInterpolator_GetInterpolator_Landroidx_constraintlayout_core_state_Interpolator_;

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_addCustomColor_AddCustomColor_ILjava_lang_String_Ljava_lang_String_I_V;

	private static Delegate? cb_addCustomFloat_AddCustomFloat_ILjava_lang_String_Ljava_lang_String_F_V;

	private static Delegate? cb_addKeyAttribute_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

	private static Delegate? cb_addKeyAttribute_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable__V;

	private static Delegate? cb_addKeyCycle_AddKeyCycle_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

	private static Delegate? cb_addKeyPosition_AddKeyPosition_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

	private static Delegate? cb_addKeyPosition_AddKeyPosition_Ljava_lang_String_IIFF_V;

	private static Delegate? cb_calcStagger_CalcStagger_V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_contains_Contains_Ljava_lang_String__Z;

	private static Delegate? cb_dragToProgress_DragToProgress_FIIFF_F;

	private static Delegate? cb_fillKeyPositions_FillKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_arrayFarrayFarrayF_V;

	private static Delegate? cb_findNextPosition_FindNextPosition_Ljava_lang_String_I_Ljava_lang_Object_;

	private static Delegate? cb_findPreviousPosition_FindPreviousPosition_Ljava_lang_String_I_Ljava_lang_Object_;

	private static Delegate? cb_getEnd_GetEnd_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getEnd_GetEnd_Ljava_lang_String__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	private static Delegate? cb_getInterpolated_GetInterpolated_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getInterpolated_GetInterpolated_Ljava_lang_String__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getKeyFrames_GetKeyFrames_Ljava_lang_String_arrayFarrayIarrayI_I;

	private static Delegate? cb_getMotion_GetMotion_Ljava_lang_String__Landroidx_constraintlayout_core_motion_Motion_;

	private static Delegate? cb_getNumberKeyPositions_GetNumberKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame__I;

	private static Delegate? cb_getPath_GetPath_Ljava_lang_String__arrayF;

	private static Delegate? cb_getStart_GetStart_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getStart_GetStart_Ljava_lang_String__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getTouchUpProgress_GetTouchUpProgress_J_F;

	private static Delegate? cb_getWidgetState_GetWidgetState_Ljava_lang_String_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I_Landroidx_constraintlayout_core_state_Transition_WidgetState_;

	private static Delegate? cb_interpolate_Interpolate_IIF_V;

	private static Delegate? cb_isFirstDownAccepted_IsFirstDownAccepted_FF_Z;

	private static Delegate? cb_isTouchNotDone_IsTouchNotDone_F_Z;

	private static Delegate? cb_setTouchUp_SetTouchUp_FJFF_V;

	private static Delegate? cb_setTransitionProperties_SetTransitionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

	private static Delegate? cb_setValue_SetValue_IZ_Z;

	private static Delegate? cb_setValue_SetValue_IF_Z;

	private static Delegate? cb_setValue_SetValue_II_Z;

	private static Delegate? cb_setValue_SetValue_ILjava_lang_String__Z;

	private static Delegate? cb_updateFrom_UpdateFrom_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_I_V;

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

	public unsafe virtual int AutoTransition
	{
		[Register("getAutoTransition", "()I", "GetGetAutoTransitionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAutoTransition.()I", this, null);
		}
	}

	public unsafe virtual bool HasOnSwipe
	{
		[Register("hasOnSwipe", "()Z", "GetHasOnSwipeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasOnSwipe.()Z", this, null);
		}
	}

	public unsafe virtual bool HasPositionKeyframes
	{
		[Register("hasPositionKeyframes", "()Z", "GetHasPositionKeyframesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPositionKeyframes.()Z", this, null);
		}
	}

	public unsafe virtual int InterpolatedHeight
	{
		[Register("getInterpolatedHeight", "()I", "GetGetInterpolatedHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInterpolatedHeight.()I", this, null);
		}
	}

	public unsafe virtual int InterpolatedWidth
	{
		[Register("getInterpolatedWidth", "()I", "GetGetInterpolatedWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInterpolatedWidth.()I", this, null);
		}
	}

	public unsafe virtual IInterpolator? Interpolator
	{
		[Register("getInterpolator", "()Landroidx/constraintlayout/core/state/Interpolator;", "GetGetInterpolatorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroidx/constraintlayout/core/state/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	protected Transition(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/state/CorePixelDp;)V", "")]
	public unsafe Transition(ICorePixelDp dpToPixel)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dpToPixel == null) ? IntPtr.Zero : ((Java.Lang.Object)dpToPixel).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/state/CorePixelDp;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/state/CorePixelDp;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dpToPixel);
		}
	}

	private static Delegate GetGetAutoTransitionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetAutoTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAutoTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoTransition;
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

	private static Delegate GetHasOnSwipeHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasOnSwipe);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasOnSwipe(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasOnSwipe ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasPositionKeyframesHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasPositionKeyframes);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasPositionKeyframes(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasPositionKeyframes ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetInterpolatedHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInterpolatedHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInterpolatedHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InterpolatedHeight;
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

	private static Delegate GetGetInterpolatedWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInterpolatedWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInterpolatedWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InterpolatedWidth;
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

	private static Delegate GetGetInterpolatorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetInterpolator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterpolator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
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

	private static Delegate GetIsEmptyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEmpty);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAddCustomColor_ILjava_lang_String_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPILLI_V(n_AddCustomColor_ILjava_lang_String_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCustomColor_ILjava_lang_String_Ljava_lang_String_I(nint jnienv, nint native__this, int state, nint native_widgetId, nint native_property, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string widgetId = JNIEnv.GetString(native_widgetId, JniHandleOwnership.DoNotTransfer);
			string property = JNIEnv.GetString(native_property, JniHandleOwnership.DoNotTransfer);
			transition2.AddCustomColor(state, widgetId, property, color);
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

	[Register("addCustomColor", "(ILjava/lang/String;Ljava/lang/String;I)V", "GetAddCustomColor_ILjava_lang_String_Ljava_lang_String_IHandler")]
	public unsafe virtual void AddCustomColor(int state, string? widgetId, string? property, int color)
	{
		nint num = JNIEnv.NewString(widgetId);
		nint num2 = JNIEnv.NewString(property);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(state);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCustomColor.(ILjava/lang/String;Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetAddCustomFloat_ILjava_lang_String_Ljava_lang_String_FHandler()
	{
		return new _JniMarshal_PPILLF_V(n_AddCustomFloat_ILjava_lang_String_Ljava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCustomFloat_ILjava_lang_String_Ljava_lang_String_F(nint jnienv, nint native__this, int state, nint native_widgetId, nint native_property, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string widgetId = JNIEnv.GetString(native_widgetId, JniHandleOwnership.DoNotTransfer);
			string property = JNIEnv.GetString(native_property, JniHandleOwnership.DoNotTransfer);
			transition2.AddCustomFloat(state, widgetId, property, value);
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

	[Register("addCustomFloat", "(ILjava/lang/String;Ljava/lang/String;F)V", "GetAddCustomFloat_ILjava_lang_String_Ljava_lang_String_FHandler")]
	public unsafe virtual void AddCustomFloat(int state, string? widgetId, string? property, float value)
	{
		nint num = JNIEnv.NewString(widgetId);
		nint num2 = JNIEnv.NewString(property);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(state);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCustomFloat.(ILjava/lang/String;Ljava/lang/String;F)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetAddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_target, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			TypedBundle bundle = Java.Lang.Object.GetObject<TypedBundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			transition2.AddKeyAttribute(target, bundle);
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

	[Register("addKeyAttribute", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetAddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
	public unsafe virtual void AddKeyAttribute(string? target, TypedBundle? bundle)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyAttribute.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bundle);
		}
	}

	private static Delegate GetAddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_(nint jnienv, nint native__this, nint native_target, nint native_bundle, nint native_custom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			TypedBundle bundle = Java.Lang.Object.GetObject<TypedBundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			CustomVariable[] array = (CustomVariable[])JNIEnv.GetArray(native_custom, JniHandleOwnership.DoNotTransfer, typeof(CustomVariable));
			transition2.AddKeyAttribute(target, bundle, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_custom);
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

	[Register("addKeyAttribute", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;[Landroidx/constraintlayout/core/motion/CustomVariable;)V", "GetAddKeyAttribute_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_arrayLandroidx_constraintlayout_core_motion_CustomVariable_Handler")]
	public unsafe virtual void AddKeyAttribute(string? target, TypedBundle? bundle, CustomVariable[]? custom)
	{
		nint num = JNIEnv.NewString(target);
		nint num2 = JNIEnv.NewArray(custom);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyAttribute.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;[Landroidx/constraintlayout/core/motion/CustomVariable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (custom != null)
			{
				JNIEnv.CopyArray(num2, custom);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(bundle);
			GC.KeepAlive(custom);
		}
	}

	private static Delegate GetAddKeyCycle_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddKeyCycle_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKeyCycle_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_target, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			TypedBundle bundle = Java.Lang.Object.GetObject<TypedBundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			transition2.AddKeyCycle(target, bundle);
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

	[Register("addKeyCycle", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetAddKeyCycle_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
	public unsafe virtual void AddKeyCycle(string? target, TypedBundle? bundle)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyCycle.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bundle);
		}
	}

	private static Delegate GetAddKeyPosition_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddKeyPosition_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKeyPosition_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_target, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			TypedBundle bundle = Java.Lang.Object.GetObject<TypedBundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			transition2.AddKeyPosition(target, bundle);
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

	[Register("addKeyPosition", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetAddKeyPosition_Ljava_lang_String_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
	public unsafe virtual void AddKeyPosition(string? target, TypedBundle? bundle)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyPosition.(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bundle);
		}
	}

	private static Delegate GetAddKeyPosition_Ljava_lang_String_IIFFHandler()
	{
		return new _JniMarshal_PPLIIFF_V(n_AddKeyPosition_Ljava_lang_String_IIFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKeyPosition_Ljava_lang_String_IIFF(nint jnienv, nint native__this, nint native_target, int frame, int type, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			transition2.AddKeyPosition(target, frame, type, x, y);
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

	[Register("addKeyPosition", "(Ljava/lang/String;IIFF)V", "GetAddKeyPosition_Ljava_lang_String_IIFFHandler")]
	public unsafe virtual void AddKeyPosition(string? target, int frame, int type, float x, float y)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(frame);
			ptr[2] = new JniArgumentValue(type);
			ptr[3] = new JniArgumentValue(x);
			ptr[4] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyPosition.(Ljava/lang/String;IIFF)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetCalcStaggerHandler()
	{
		return new global::_JniMarshal_PP_V(n_CalcStagger);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CalcStagger(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalcStagger();
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

	[Register("calcStagger", "()V", "GetCalcStaggerHandler")]
	public unsafe virtual void CalcStagger()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("calcStagger.()V", this, null);
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetContains_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Contains_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Contains_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return transition2.Contains(key) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("contains", "(Ljava/lang/String;)Z", "GetContains_Ljava_lang_String_Handler")]
	public unsafe virtual bool Contains(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("contains.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetDragToProgress_FIIFFHandler()
	{
		return new _JniMarshal_PPFIIFF_F(n_DragToProgress_FIIFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_DragToProgress_FIIFF(nint jnienv, nint native__this, float currentProgress, int baseW, int baseH, float dx, float dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragToProgress(currentProgress, baseW, baseH, dx, dy);
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

	[Register("dragToProgress", "(FIIFF)F", "GetDragToProgress_FIIFFHandler")]
	public unsafe virtual float DragToProgress(float currentProgress, int baseW, int baseH, float dx, float dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(currentProgress);
		ptr[1] = new JniArgumentValue(baseW);
		ptr[2] = new JniArgumentValue(baseH);
		ptr[3] = new JniArgumentValue(dx);
		ptr[4] = new JniArgumentValue(dy);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("dragToProgress.(FIIFF)F", this, ptr);
	}

	private static Delegate GetFillKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_arrayFarrayFarrayFHandler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_FillKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_arrayFarrayFarrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FillKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_arrayFarrayFarrayF(nint jnienv, nint native__this, nint native_frame, nint native_x, nint native_y, nint native_pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetFrame frame = Java.Lang.Object.GetObject<WidgetFrame>(native_frame, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_x, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array2 = (float[])JNIEnv.GetArray(native_y, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array3 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			transition2.FillKeyPositions(frame, array, array2, array3);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_x);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_y);
			}
			if (array3 != null)
			{
				JNIEnv.CopyArray(array3, native_pos);
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

	[Register("fillKeyPositions", "(Landroidx/constraintlayout/core/state/WidgetFrame;[F[F[F)V", "GetFillKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_arrayFarrayFarrayFHandler")]
	public unsafe virtual void FillKeyPositions(WidgetFrame? frame, float[]? x, float[]? y, float[]? pos)
	{
		nint num = JNIEnv.NewArray(x);
		nint num2 = JNIEnv.NewArray(y);
		nint num3 = JNIEnv.NewArray(pos);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(frame?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(num3);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillKeyPositions.(Landroidx/constraintlayout/core/state/WidgetFrame;[F[F[F)V", this, ptr);
		}
		finally
		{
			if (x != null)
			{
				JNIEnv.CopyArray(num, x);
				JNIEnv.DeleteLocalRef(num);
			}
			if (y != null)
			{
				JNIEnv.CopyArray(num2, y);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (pos != null)
			{
				JNIEnv.CopyArray(num3, pos);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(frame);
			GC.KeepAlive(x);
			GC.KeepAlive(y);
			GC.KeepAlive(pos);
		}
	}

	private static Delegate GetFindNextPosition_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_FindNextPosition_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindNextPosition_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_target, int frameNumber)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.FindNextPosition(target, frameNumber));
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

	[Register("findNextPosition", "(Ljava/lang/String;I)Ljava/lang/Object;", "GetFindNextPosition_Ljava_lang_String_IHandler")]
	public unsafe virtual Java.Lang.Object? FindNextPosition(string? target, int frameNumber)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(frameNumber);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("findNextPosition.(Ljava/lang/String;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetFindPreviousPosition_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_FindPreviousPosition_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindPreviousPosition_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_target, int frameNumber)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.FindPreviousPosition(target, frameNumber));
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

	[Register("findPreviousPosition", "(Ljava/lang/String;I)Ljava/lang/Object;", "GetFindPreviousPosition_Ljava_lang_String_IHandler")]
	public unsafe virtual Java.Lang.Object? FindPreviousPosition(string? target, int frameNumber)
	{
		nint num = JNIEnv.NewString(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(frameNumber);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("findPreviousPosition.(Ljava/lang/String;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetEnd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetEnd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEnd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetEnd(child));
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

	[Register("getEnd", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetEnd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual WidgetFrame? GetEnd(ConstraintWidget? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnd.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetEnd_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetEnd_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEnd_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetEnd(id));
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

	[Register("getEnd", "(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetEnd_Ljava_lang_String_Handler")]
	public unsafe virtual WidgetFrame? GetEnd(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnd.(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return transition2.GetId(name);
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

	private static Delegate GetGetInterpolated_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetInterpolated_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterpolated_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetInterpolated(child));
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

	[Register("getInterpolated", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetInterpolated_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual WidgetFrame? GetInterpolated(ConstraintWidget? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolated.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetInterpolated_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetInterpolated_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterpolated_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetInterpolated(id));
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

	[Register("getInterpolated", "(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetInterpolated_Ljava_lang_String_Handler")]
	public unsafe virtual WidgetFrame? GetInterpolated(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolated.(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getInterpolator", "(ILjava/lang/String;)Landroidx/constraintlayout/core/state/Interpolator;", "")]
	public unsafe static IInterpolator? GetInterpolator(int interpolator, string? interpolatorString)
	{
		nint num = JNIEnv.NewString(interpolatorString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(interpolator);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IInterpolator>(_members.StaticMethods.InvokeObjectMethod("getInterpolator.(ILjava/lang/String;)Landroidx/constraintlayout/core/state/Interpolator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetKeyFrames_Ljava_lang_String_arrayFarrayIarrayIHandler()
	{
		return new global::_JniMarshal_PPLLLL_I(n_GetKeyFrames_Ljava_lang_String_arrayFarrayIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetKeyFrames_Ljava_lang_String_arrayFarrayIarrayI(nint jnienv, nint native__this, nint native_id, nint native_rectangles, nint native_pathMode, nint native_position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_rectangles, JniHandleOwnership.DoNotTransfer, typeof(float));
			int[] array2 = (int[])JNIEnv.GetArray(native_pathMode, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array3 = (int[])JNIEnv.GetArray(native_position, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrames = transition2.GetKeyFrames(id, array, array2, array3);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_rectangles);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_pathMode);
			}
			if (array3 != null)
			{
				JNIEnv.CopyArray(array3, native_position);
			}
			return keyFrames;
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

	[Register("getKeyFrames", "(Ljava/lang/String;[F[I[I)I", "GetGetKeyFrames_Ljava_lang_String_arrayFarrayIarrayIHandler")]
	public unsafe virtual int GetKeyFrames(string? id, float[]? rectangles, int[]? pathMode, int[]? position)
	{
		nint num = JNIEnv.NewString(id);
		nint num2 = JNIEnv.NewArray(rectangles);
		nint num3 = JNIEnv.NewArray(pathMode);
		nint num4 = JNIEnv.NewArray(position);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFrames.(Ljava/lang/String;[F[I[I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (rectangles != null)
			{
				JNIEnv.CopyArray(num2, rectangles);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (pathMode != null)
			{
				JNIEnv.CopyArray(num3, pathMode);
				JNIEnv.DeleteLocalRef(num3);
			}
			if (position != null)
			{
				JNIEnv.CopyArray(num4, position);
				JNIEnv.DeleteLocalRef(num4);
			}
			GC.KeepAlive(rectangles);
			GC.KeepAlive(pathMode);
			GC.KeepAlive(position);
		}
	}

	private static Delegate GetGetMotion_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetMotion_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMotion_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetMotion(id));
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

	[Register("getMotion", "(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/Motion;", "GetGetMotion_Ljava_lang_String_Handler")]
	public unsafe virtual AndroidX.ConstraintLayout.Core.Motion.Motion? GetMotion(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AndroidX.ConstraintLayout.Core.Motion.Motion>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMotion.(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/Motion;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetNumberKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetNumberKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNumberKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_(nint jnienv, nint native__this, nint native_frame)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetFrame frame = Java.Lang.Object.GetObject<WidgetFrame>(native_frame, JniHandleOwnership.DoNotTransfer);
			return transition2.GetNumberKeyPositions(frame);
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

	[Register("getNumberKeyPositions", "(Landroidx/constraintlayout/core/state/WidgetFrame;)I", "GetGetNumberKeyPositions_Landroidx_constraintlayout_core_state_WidgetFrame_Handler")]
	public unsafe virtual int GetNumberKeyPositions(WidgetFrame? frame)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(frame?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNumberKeyPositions.(Landroidx/constraintlayout/core/state/WidgetFrame;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(frame);
		}
	}

	private static Delegate GetGetPath_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetPath_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPath_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(transition2.GetPath(id));
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

	[Register("getPath", "(Ljava/lang/String;)[F", "GetGetPath_Ljava_lang_String_Handler")]
	public unsafe virtual float[]? GetPath(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getPath.(Ljava/lang/String;)[F", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetStart_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetStart_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStart_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetStart(child));
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

	[Register("getStart", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetStart_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual WidgetFrame? GetStart(ConstraintWidget? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStart.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetStart_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetStart_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStart_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetStart(id));
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

	[Register("getStart", "(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetStart_Ljava_lang_String_Handler")]
	public unsafe virtual WidgetFrame? GetStart(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStart.(Ljava/lang/String;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetTouchUpProgress_JHandler()
	{
		return new _JniMarshal_PPJ_F(n_GetTouchUpProgress_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTouchUpProgress_J(nint jnienv, nint native__this, long currentTime)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTouchUpProgress(currentTime);
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

	[Register("getTouchUpProgress", "(J)F", "GetGetTouchUpProgress_JHandler")]
	public unsafe virtual float GetTouchUpProgress(long currentTime)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(currentTime);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getTouchUpProgress.(J)F", this, ptr);
	}

	private static Delegate GetGetWidgetState_Ljava_lang_String_Landroidx_constraintlayout_core_widgets_ConstraintWidget_IHandler()
	{
		return new global::_JniMarshal_PPLLI_L(n_GetWidgetState_Ljava_lang_String_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWidgetState_Ljava_lang_String_Landroidx_constraintlayout_core_widgets_ConstraintWidget_I(nint jnienv, nint native__this, nint native_widgetId, nint native_child, int transitionState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string widgetId = JNIEnv.GetString(native_widgetId, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition2.GetWidgetState(widgetId, child, transitionState));
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

	[Register("getWidgetState", "(Ljava/lang/String;Landroidx/constraintlayout/core/widgets/ConstraintWidget;I)Landroidx/constraintlayout/core/state/Transition$WidgetState;", "GetGetWidgetState_Ljava_lang_String_Landroidx_constraintlayout_core_widgets_ConstraintWidget_IHandler")]
	public unsafe virtual WidgetState? GetWidgetState(string? widgetId, ConstraintWidget? child, int transitionState)
	{
		nint num = JNIEnv.NewString(widgetId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(transitionState);
			return Java.Lang.Object.GetObject<WidgetState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWidgetState.(Ljava/lang/String;Landroidx/constraintlayout/core/widgets/ConstraintWidget;I)Landroidx/constraintlayout/core/state/Transition$WidgetState;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetInterpolate_IIFHandler()
	{
		return new global::_JniMarshal_PPIIF_V(n_Interpolate_IIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Interpolate_IIF(nint jnienv, nint native__this, int parentWidth, int parentHeight, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolate(parentWidth, parentHeight, progress);
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

	[Register("interpolate", "(IIF)V", "GetInterpolate_IIFHandler")]
	public unsafe virtual void Interpolate(int parentWidth, int parentHeight, float progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(parentWidth);
		ptr[1] = new JniArgumentValue(parentHeight);
		ptr[2] = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("interpolate.(IIF)V", this, ptr);
	}

	private static Delegate GetIsFirstDownAccepted_FFHandler()
	{
		return new _JniMarshal_PPFF_B(n_IsFirstDownAccepted_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFirstDownAccepted_FF(nint jnienv, nint native__this, float posX, float posY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFirstDownAccepted(posX, posY) ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isFirstDownAccepted", "(FF)Z", "GetIsFirstDownAccepted_FFHandler")]
	public unsafe virtual bool IsFirstDownAccepted(float posX, float posY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(posX);
		ptr[1] = new JniArgumentValue(posY);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFirstDownAccepted.(FF)Z", this, ptr);
	}

	private static Delegate GetIsTouchNotDone_FHandler()
	{
		return new _JniMarshal_PPF_B(n_IsTouchNotDone_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTouchNotDone_F(nint jnienv, nint native__this, float currentProgress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTouchNotDone(currentProgress) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isTouchNotDone", "(F)Z", "GetIsTouchNotDone_FHandler")]
	public unsafe virtual bool IsTouchNotDone(float currentProgress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(currentProgress);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTouchNotDone.(F)Z", this, ptr);
	}

	private static Delegate GetSetTouchUp_FJFFHandler()
	{
		return new _JniMarshal_PPFJFF_V(n_SetTouchUp_FJFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTouchUp_FJFF(nint jnienv, nint native__this, float currentProgress, long currentTime, float velocityX, float velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTouchUp(currentProgress, currentTime, velocityX, velocityY);
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

	[Register("setTouchUp", "(FJFF)V", "GetSetTouchUp_FJFFHandler")]
	public unsafe virtual void SetTouchUp(float currentProgress, long currentTime, float velocityX, float velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(currentProgress);
		ptr[1] = new JniArgumentValue(currentTime);
		ptr[2] = new JniArgumentValue(velocityX);
		ptr[3] = new JniArgumentValue(velocityY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTouchUp.(FJFF)V", this, ptr);
	}

	private static Delegate GetSetTransitionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTransitionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransitionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TypedBundle transitionProperties = Java.Lang.Object.GetObject<TypedBundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			transition2.SetTransitionProperties(transitionProperties);
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

	[Register("setTransitionProperties", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetSetTransitionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
	public unsafe virtual void SetTransitionProperties(TypedBundle? bundle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionProperties.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bundle);
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
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return transition2.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return transition2.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetUpdateFrom_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_UpdateFrom_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFrom_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_I(nint jnienv, nint native__this, nint native_container, int state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			transition2.UpdateFrom(container, state);
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

	[Register("updateFrom", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;I)V", "GetUpdateFrom_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IHandler")]
	public unsafe virtual void UpdateFrom(ConstraintWidgetContainer? container, int state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(state);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFrom.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
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
