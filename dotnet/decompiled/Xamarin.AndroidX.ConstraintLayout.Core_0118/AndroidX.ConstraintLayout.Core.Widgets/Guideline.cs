using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/Guideline", DoNotGenerateAcw = true)]
public class Guideline : ConstraintWidget
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/Guideline", typeof(Guideline));

	private static Delegate? cb_getAnchor_GetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_;

	private static Delegate? cb_isPercent_IsPercent_Z;

	private static Delegate? cb_getMinimumPosition_GetMinimumPosition_I;

	private static Delegate? cb_setMinimumPosition_SetMinimumPosition_I_V;

	private static Delegate? cb_getOrientation_GetOrientation_I;

	private static Delegate? cb_setOrientation_SetOrientation_I_V;

	private static Delegate? cb_getRelativeBegin_GetRelativeBegin_I;

	private static Delegate? cb_getRelativeBehaviour_GetRelativeBehaviour_I;

	private static Delegate? cb_getRelativeEnd_GetRelativeEnd_I;

	private static Delegate? cb_getRelativePercent_GetRelativePercent_F;

	private static Delegate? cb_cyclePosition_CyclePosition_V;

	private static Delegate? cb_setFinalValue_SetFinalValue_I_V;

	private static Delegate? cb_setGuideBegin_SetGuideBegin_I_V;

	private static Delegate? cb_setGuideEnd_SetGuideEnd_I_V;

	private static Delegate? cb_setGuidePercent_SetGuidePercent_F_V;

	private static Delegate? cb_setGuidePercent_SetGuidePercent_I_V;

	[Register("mGuidelineUseRtl")]
	protected bool MGuidelineUseRtl
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mGuidelineUseRtl.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mGuidelineUseRtl.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mRelativeBegin")]
	protected int MRelativeBegin
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mRelativeBegin.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mRelativeBegin.I", this, value);
		}
	}

	[Register("mRelativeEnd")]
	protected int MRelativeEnd
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mRelativeEnd.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mRelativeEnd.I", this, value);
		}
	}

	[Register("mRelativePercent")]
	protected float MRelativePercent
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mRelativePercent.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mRelativePercent.F", this, value);
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

	public unsafe virtual ConstraintAnchor? Anchor
	{
		[Register("getAnchor", "()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", "GetGetAnchorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchor.()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsPercent
	{
		[Register("isPercent", "()Z", "GetIsPercentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPercent.()Z", this, null);
		}
	}

	public unsafe virtual int MinimumPosition
	{
		[Register("getMinimumPosition", "()I", "GetGetMinimumPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumPosition.()I", this, null);
		}
		[Register("setMinimumPosition", "(I)V", "GetSetMinimumPosition_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinimumPosition.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Orientation
	{
		[Register("getOrientation", "()I", "GetGetOrientationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
		}
		[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
		}
	}

	public unsafe virtual int RelativeBegin
	{
		[Register("getRelativeBegin", "()I", "GetGetRelativeBeginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeBegin.()I", this, null);
		}
	}

	public unsafe virtual int RelativeBehaviour
	{
		[Register("getRelativeBehaviour", "()I", "GetGetRelativeBehaviourHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeBehaviour.()I", this, null);
		}
	}

	public unsafe virtual int RelativeEnd
	{
		[Register("getRelativeEnd", "()I", "GetGetRelativeEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeEnd.()I", this, null);
		}
	}

	public unsafe virtual float RelativePercent
	{
		[Register("getRelativePercent", "()F", "GetGetRelativePercentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRelativePercent.()F", this, null);
		}
	}

	protected Guideline(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Guideline()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetAnchorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnchor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnchor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Anchor);
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

	private static Delegate GetIsPercentHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsPercent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPercent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPercent ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMinimumPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinimumPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinimumPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumPosition;
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

	private static Delegate GetSetMinimumPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinimumPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinimumPosition_I(nint jnienv, nint native__this, int minimum)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumPosition = minimum;
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

	private static Delegate GetGetOrientationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOrientation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrientation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
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

	private static Delegate GetSetOrientation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOrientation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOrientation_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
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

	private static Delegate GetGetRelativeBeginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRelativeBegin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRelativeBegin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeBegin;
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

	private static Delegate GetGetRelativeBehaviourHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRelativeBehaviour);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRelativeBehaviour(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeBehaviour;
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

	private static Delegate GetGetRelativeEndHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRelativeEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRelativeEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeEnd;
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

	private static Delegate GetGetRelativePercentHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetRelativePercent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRelativePercent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativePercent;
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

	private static Delegate GetCyclePositionHandler()
	{
		return new global::_JniMarshal_PP_V(n_CyclePosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CyclePosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CyclePosition();
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

	[Register("cyclePosition", "()V", "GetCyclePositionHandler")]
	public unsafe virtual void CyclePosition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cyclePosition.()V", this, null);
	}

	private static Delegate GetSetFinalValue_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFinalValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalValue_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalValue(position);
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

	[Register("setFinalValue", "(I)V", "GetSetFinalValue_IHandler")]
	public unsafe virtual void SetFinalValue(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(I)V", this, ptr);
	}

	private static Delegate GetSetGuideBegin_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetGuideBegin_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuideBegin_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuideBegin(value);
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

	[Register("setGuideBegin", "(I)V", "GetSetGuideBegin_IHandler")]
	public unsafe virtual void SetGuideBegin(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuideBegin.(I)V", this, ptr);
	}

	private static Delegate GetSetGuideEnd_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetGuideEnd_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuideEnd_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuideEnd(value);
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

	[Register("setGuideEnd", "(I)V", "GetSetGuideEnd_IHandler")]
	public unsafe virtual void SetGuideEnd(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuideEnd.(I)V", this, ptr);
	}

	private static Delegate GetSetGuidePercent_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetGuidePercent_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuidePercent_F(nint jnienv, nint native__this, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidePercent(value);
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

	[Register("setGuidePercent", "(F)V", "GetSetGuidePercent_FHandler")]
	public unsafe virtual void SetGuidePercent(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidePercent.(F)V", this, ptr);
	}

	private static Delegate GetSetGuidePercent_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetGuidePercent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuidePercent_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidePercent(value);
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

	[Register("setGuidePercent", "(I)V", "GetSetGuidePercent_IHandler")]
	public unsafe virtual void SetGuidePercent(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidePercent.(I)V", this, ptr);
	}
}
