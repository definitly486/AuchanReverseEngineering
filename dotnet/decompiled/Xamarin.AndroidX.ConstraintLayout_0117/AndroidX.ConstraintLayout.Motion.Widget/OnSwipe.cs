using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/OnSwipe", DoNotGenerateAcw = true)]
public class OnSwipe : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/OnSwipe", typeof(OnSwipe));

	private static Delegate? cb_getAutoCompleteMode_GetAutoCompleteMode_I;

	private static Delegate? cb_setAutoCompleteMode_SetAutoCompleteMode_I_V;

	private static Delegate? cb_getDragDirection_GetDragDirection_I;

	private static Delegate? cb_getDragScale_GetDragScale_F;

	private static Delegate? cb_getDragThreshold_GetDragThreshold_F;

	private static Delegate? cb_getLimitBoundsTo_GetLimitBoundsTo_I;

	private static Delegate? cb_getMaxAcceleration_GetMaxAcceleration_F;

	private static Delegate? cb_getMaxVelocity_GetMaxVelocity_F;

	private static Delegate? cb_getMoveWhenScrollAtTop_GetMoveWhenScrollAtTop_Z;

	private static Delegate? cb_getNestedScrollFlags_GetNestedScrollFlags_I;

	private static Delegate? cb_getOnTouchUp_GetOnTouchUp_I;

	private static Delegate? cb_getRotationCenterId_GetRotationCenterId_I;

	private static Delegate? cb_getSpringBoundary_GetSpringBoundary_I;

	private static Delegate? cb_getSpringDamping_GetSpringDamping_F;

	private static Delegate? cb_getSpringMass_GetSpringMass_F;

	private static Delegate? cb_getSpringStiffness_GetSpringStiffness_F;

	private static Delegate? cb_getSpringStopThreshold_GetSpringStopThreshold_F;

	private static Delegate? cb_getTouchAnchorId_GetTouchAnchorId_I;

	private static Delegate? cb_getTouchAnchorSide_GetTouchAnchorSide_I;

	private static Delegate? cb_getTouchRegionId_GetTouchRegionId_I;

	private static Delegate? cb_setDragDirection_SetDragDirection_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setDragScale_SetDragScale_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setDragThreshold_SetDragThreshold_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setLimitBoundsTo_SetLimitBoundsTo_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setMaxAcceleration_SetMaxAcceleration_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setMaxVelocity_SetMaxVelocity_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setMoveWhenScrollAtTop_SetMoveWhenScrollAtTop_Z_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setNestedScrollFlags_SetNestedScrollFlags_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setOnTouchUp_SetOnTouchUp_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setRotateCenter_SetRotateCenter_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setSpringBoundary_SetSpringBoundary_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setSpringDamping_SetSpringDamping_F_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setSpringMass_SetSpringMass_F_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setSpringStiffness_SetSpringStiffness_F_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setSpringStopThreshold_SetSpringStopThreshold_F_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setTouchAnchorId_SetTouchAnchorId_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setTouchAnchorSide_SetTouchAnchorSide_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

	private static Delegate? cb_setTouchRegionId_SetTouchRegionId_I_Landroidx_constraintlayout_motion_widget_OnSwipe_;

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

	public unsafe virtual int AutoCompleteMode
	{
		[Register("getAutoCompleteMode", "()I", "GetGetAutoCompleteModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAutoCompleteMode.()I", this, null);
		}
		[Register("setAutoCompleteMode", "(I)V", "GetSetAutoCompleteMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoCompleteMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual int DragDirection
	{
		[Register("getDragDirection", "()I", "GetGetDragDirectionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDragDirection.()I", this, null);
		}
	}

	public unsafe virtual float DragScale
	{
		[Register("getDragScale", "()F", "GetGetDragScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getDragScale.()F", this, null);
		}
	}

	public unsafe virtual float DragThreshold
	{
		[Register("getDragThreshold", "()F", "GetGetDragThresholdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getDragThreshold.()F", this, null);
		}
	}

	public unsafe virtual int LimitBoundsTo
	{
		[Register("getLimitBoundsTo", "()I", "GetGetLimitBoundsToHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLimitBoundsTo.()I", this, null);
		}
	}

	public unsafe virtual float MaxAcceleration
	{
		[Register("getMaxAcceleration", "()F", "GetGetMaxAccelerationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMaxAcceleration.()F", this, null);
		}
	}

	public unsafe virtual float MaxVelocity
	{
		[Register("getMaxVelocity", "()F", "GetGetMaxVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMaxVelocity.()F", this, null);
		}
	}

	public unsafe virtual bool MoveWhenScrollAtTop
	{
		[Register("getMoveWhenScrollAtTop", "()Z", "GetGetMoveWhenScrollAtTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getMoveWhenScrollAtTop.()Z", this, null);
		}
	}

	public unsafe virtual int NestedScrollFlags
	{
		[Register("getNestedScrollFlags", "()I", "GetGetNestedScrollFlagsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNestedScrollFlags.()I", this, null);
		}
	}

	public unsafe virtual int OnTouchUp
	{
		[Register("getOnTouchUp", "()I", "GetGetOnTouchUpHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOnTouchUp.()I", this, null);
		}
	}

	public unsafe virtual int RotationCenterId
	{
		[Register("getRotationCenterId", "()I", "GetGetRotationCenterIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRotationCenterId.()I", this, null);
		}
	}

	public unsafe virtual int SpringBoundary
	{
		[Register("getSpringBoundary", "()I", "GetGetSpringBoundaryHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpringBoundary.()I", this, null);
		}
	}

	public unsafe virtual float SpringDamping
	{
		[Register("getSpringDamping", "()F", "GetGetSpringDampingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSpringDamping.()F", this, null);
		}
	}

	public unsafe virtual float SpringMass
	{
		[Register("getSpringMass", "()F", "GetGetSpringMassHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSpringMass.()F", this, null);
		}
	}

	public unsafe virtual float SpringStiffness
	{
		[Register("getSpringStiffness", "()F", "GetGetSpringStiffnessHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSpringStiffness.()F", this, null);
		}
	}

	public unsafe virtual float SpringStopThreshold
	{
		[Register("getSpringStopThreshold", "()F", "GetGetSpringStopThresholdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSpringStopThreshold.()F", this, null);
		}
	}

	public unsafe virtual int TouchAnchorId
	{
		[Register("getTouchAnchorId", "()I", "GetGetTouchAnchorIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTouchAnchorId.()I", this, null);
		}
	}

	public unsafe virtual int TouchAnchorSide
	{
		[Register("getTouchAnchorSide", "()I", "GetGetTouchAnchorSideHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTouchAnchorSide.()I", this, null);
		}
	}

	public unsafe virtual int TouchRegionId
	{
		[Register("getTouchRegionId", "()I", "GetGetTouchRegionIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTouchRegionId.()I", this, null);
		}
	}

	protected OnSwipe(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe OnSwipe()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetAutoCompleteModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetAutoCompleteMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAutoCompleteMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoCompleteMode;
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

	private static Delegate GetSetAutoCompleteMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetAutoCompleteMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAutoCompleteMode_I(nint jnienv, nint native__this, int autoCompleteMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoCompleteMode = autoCompleteMode;
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

	private static Delegate GetGetDragDirectionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDragDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDragDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragDirection;
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

	private static Delegate GetGetDragScaleHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetDragScale);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDragScale(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragScale;
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

	private static Delegate GetGetDragThresholdHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetDragThreshold);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDragThreshold(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragThreshold;
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

	private static Delegate GetGetLimitBoundsToHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLimitBoundsTo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLimitBoundsTo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LimitBoundsTo;
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

	private static Delegate GetGetMaxAccelerationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetMaxAcceleration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetMaxAcceleration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxAcceleration;
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

	private static Delegate GetGetMaxVelocityHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetMaxVelocity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetMaxVelocity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxVelocity;
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

	private static Delegate GetGetMoveWhenScrollAtTopHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetMoveWhenScrollAtTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetMoveWhenScrollAtTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveWhenScrollAtTop ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNestedScrollFlagsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNestedScrollFlags);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNestedScrollFlags(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NestedScrollFlags;
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

	private static Delegate GetGetOnTouchUpHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOnTouchUp);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOnTouchUp(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTouchUp;
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

	private static Delegate GetGetRotationCenterIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRotationCenterId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRotationCenterId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationCenterId;
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

	private static Delegate GetGetSpringBoundaryHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSpringBoundary);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpringBoundary(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpringBoundary;
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

	private static Delegate GetGetSpringDampingHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetSpringDamping);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSpringDamping(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpringDamping;
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

	private static Delegate GetGetSpringMassHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetSpringMass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSpringMass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpringMass;
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

	private static Delegate GetGetSpringStiffnessHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetSpringStiffness);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSpringStiffness(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpringStiffness;
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

	private static Delegate GetGetSpringStopThresholdHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetSpringStopThreshold);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetSpringStopThreshold(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpringStopThreshold;
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

	private static Delegate GetGetTouchAnchorIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTouchAnchorId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTouchAnchorId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchAnchorId;
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

	private static Delegate GetGetTouchAnchorSideHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTouchAnchorSide);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTouchAnchorSide(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchAnchorSide;
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

	private static Delegate GetGetTouchRegionIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTouchRegionId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTouchRegionId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchRegionId;
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

	private static Delegate GetSetDragDirection_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetDragDirection_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDragDirection_I(nint jnienv, nint native__this, int dragDirection)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDragDirection(dragDirection));
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

	[Register("setDragDirection", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetDragDirection_IHandler")]
	public unsafe virtual OnSwipe? SetDragDirection(int dragDirection)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dragDirection);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDragDirection.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDragScale_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetDragScale_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDragScale_I(nint jnienv, nint native__this, int dragScale)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDragScale(dragScale));
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

	[Register("setDragScale", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetDragScale_IHandler")]
	public unsafe virtual OnSwipe? SetDragScale(int dragScale)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dragScale);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDragScale.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDragThreshold_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetDragThreshold_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDragThreshold_I(nint jnienv, nint native__this, int dragThreshold)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDragThreshold(dragThreshold));
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

	[Register("setDragThreshold", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetDragThreshold_IHandler")]
	public unsafe virtual OnSwipe? SetDragThreshold(int dragThreshold)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dragThreshold);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDragThreshold.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetLimitBoundsTo_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetLimitBoundsTo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetLimitBoundsTo_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLimitBoundsTo(id));
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

	[Register("setLimitBoundsTo", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetLimitBoundsTo_IHandler")]
	public unsafe virtual OnSwipe? SetLimitBoundsTo(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLimitBoundsTo.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMaxAcceleration_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetMaxAcceleration_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMaxAcceleration_I(nint jnienv, nint native__this, int maxAcceleration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxAcceleration(maxAcceleration));
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

	[Register("setMaxAcceleration", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetMaxAcceleration_IHandler")]
	public unsafe virtual OnSwipe? SetMaxAcceleration(int maxAcceleration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(maxAcceleration);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaxAcceleration.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMaxVelocity_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetMaxVelocity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMaxVelocity_I(nint jnienv, nint native__this, int maxVelocity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxVelocity(maxVelocity));
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

	[Register("setMaxVelocity", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetMaxVelocity_IHandler")]
	public unsafe virtual OnSwipe? SetMaxVelocity(int maxVelocity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(maxVelocity);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaxVelocity.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMoveWhenScrollAtTop_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SetMoveWhenScrollAtTop_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMoveWhenScrollAtTop_Z(nint jnienv, nint native__this, sbyte native_moveWhenScrollAtTop)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			OnSwipe? onSwipe = Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool moveWhenScrollAtTop = native_moveWhenScrollAtTop != 0;
			return JNIEnv.ToLocalJniHandle(onSwipe.SetMoveWhenScrollAtTop(moveWhenScrollAtTop));
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

	[Register("setMoveWhenScrollAtTop", "(Z)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetMoveWhenScrollAtTop_ZHandler")]
	public unsafe virtual OnSwipe? SetMoveWhenScrollAtTop(bool moveWhenScrollAtTop)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(moveWhenScrollAtTop ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMoveWhenScrollAtTop.(Z)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetNestedScrollFlags_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetNestedScrollFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetNestedScrollFlags_I(nint jnienv, nint native__this, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNestedScrollFlags(flags));
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

	[Register("setNestedScrollFlags", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetNestedScrollFlags_IHandler")]
	public unsafe virtual OnSwipe? SetNestedScrollFlags(int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flags);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNestedScrollFlags.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetOnTouchUp_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetOnTouchUp_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetOnTouchUp_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnTouchUp(mode));
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

	[Register("setOnTouchUp", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetOnTouchUp_IHandler")]
	public unsafe virtual OnSwipe? SetOnTouchUp(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnTouchUp.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetRotateCenter_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetRotateCenter_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetRotateCenter_I(nint jnienv, nint native__this, int rotationCenterId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotateCenter(rotationCenterId));
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

	[Register("setRotateCenter", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetRotateCenter_IHandler")]
	public unsafe virtual OnSwipe? SetRotateCenter(int rotationCenterId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rotationCenterId);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRotateCenter.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpringBoundary_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetSpringBoundary_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetSpringBoundary_I(nint jnienv, nint native__this, int springBoundary)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSpringBoundary(springBoundary));
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

	[Register("setSpringBoundary", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetSpringBoundary_IHandler")]
	public unsafe virtual OnSwipe? SetSpringBoundary(int springBoundary)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(springBoundary);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSpringBoundary.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpringDamping_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_SetSpringDamping_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetSpringDamping_F(nint jnienv, nint native__this, float springDamping)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSpringDamping(springDamping));
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

	[Register("setSpringDamping", "(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetSpringDamping_FHandler")]
	public unsafe virtual OnSwipe? SetSpringDamping(float springDamping)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(springDamping);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSpringDamping.(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpringMass_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_SetSpringMass_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetSpringMass_F(nint jnienv, nint native__this, float springMass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSpringMass(springMass));
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

	[Register("setSpringMass", "(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetSpringMass_FHandler")]
	public unsafe virtual OnSwipe? SetSpringMass(float springMass)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(springMass);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSpringMass.(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpringStiffness_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_SetSpringStiffness_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetSpringStiffness_F(nint jnienv, nint native__this, float springStiffness)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSpringStiffness(springStiffness));
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

	[Register("setSpringStiffness", "(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetSpringStiffness_FHandler")]
	public unsafe virtual OnSwipe? SetSpringStiffness(float springStiffness)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(springStiffness);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSpringStiffness.(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpringStopThreshold_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_SetSpringStopThreshold_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetSpringStopThreshold_F(nint jnienv, nint native__this, float springStopThreshold)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSpringStopThreshold(springStopThreshold));
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

	[Register("setSpringStopThreshold", "(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetSpringStopThreshold_FHandler")]
	public unsafe virtual OnSwipe? SetSpringStopThreshold(float springStopThreshold)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(springStopThreshold);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSpringStopThreshold.(F)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTouchAnchorId_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetTouchAnchorId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTouchAnchorId_I(nint jnienv, nint native__this, int side)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTouchAnchorId(side));
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

	[Register("setTouchAnchorId", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetTouchAnchorId_IHandler")]
	public unsafe virtual OnSwipe? SetTouchAnchorId(int side)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(side);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTouchAnchorId.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTouchAnchorSide_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetTouchAnchorSide_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTouchAnchorSide_I(nint jnienv, nint native__this, int side)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTouchAnchorSide(side));
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

	[Register("setTouchAnchorSide", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetTouchAnchorSide_IHandler")]
	public unsafe virtual OnSwipe? SetTouchAnchorSide(int side)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(side);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTouchAnchorSide.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTouchRegionId_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetTouchRegionId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTouchRegionId_I(nint jnienv, nint native__this, int side)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OnSwipe>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTouchRegionId(side));
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

	[Register("setTouchRegionId", "(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", "GetSetTouchRegionId_IHandler")]
	public unsafe virtual OnSwipe? SetTouchRegionId(int side)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(side);
		return Java.Lang.Object.GetObject<OnSwipe>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTouchRegionId.(I)Landroidx/constraintlayout/motion/widget/OnSwipe;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
