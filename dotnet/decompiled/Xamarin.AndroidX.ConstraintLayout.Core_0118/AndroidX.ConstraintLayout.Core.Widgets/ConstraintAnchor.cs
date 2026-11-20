using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/ConstraintAnchor", DoNotGenerateAcw = true)]
public class ConstraintAnchor : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/widgets/ConstraintAnchor$Type", DoNotGenerateAcw = true)]
	public sealed class Type : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/ConstraintAnchor$Type", typeof(Type));

		[Register("BASELINE")]
		public static Type? Baseline => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("BASELINE.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BOTTOM")]
		public static Type? Bottom => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("BOTTOM.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CENTER")]
		public static Type? Center => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CENTER_X")]
		public static Type? CenterX => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER_X.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CENTER_Y")]
		public static Type? CenterY => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER_Y.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LEFT")]
		public static Type? Left => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("LEFT.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static Type? None => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("NONE.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RIGHT")]
		public static Type? Right => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("RIGHT.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOP")]
		public static Type? Top => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("TOP.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		internal Type(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", "")]
		public unsafe static Type? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", "")]
		public unsafe static Type[]? Values()
		{
			return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/ConstraintAnchor", typeof(ConstraintAnchor));

	private static Delegate? cb_getDependents_GetDependents_Ljava_util_HashSet_;

	private static Delegate? cb_getFinalValue_GetFinalValue_I;

	private static Delegate? cb_setFinalValue_SetFinalValue_I_V;

	private static Delegate? cb_hasCenteredDependents_HasCenteredDependents_Z;

	private static Delegate? cb_hasDependents_HasDependents_Z;

	private static Delegate? cb_hasFinalValue_HasFinalValue_Z;

	private static Delegate? cb_isConnected_IsConnected_Z;

	private static Delegate? cb_isSideAnchor_IsSideAnchor_Z;

	private static Delegate? cb_isVerticalAnchor_IsVerticalAnchor_Z;

	private static Delegate? cb_getMargin_GetMargin_I;

	private static Delegate? cb_setMargin_SetMargin_I_V;

	private static Delegate? cb_getOwner_GetOwner_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_getSolverVariable_GetSolverVariable_Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_getTarget_GetTarget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_;

	private static Delegate? cb_connect_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I_Z;

	private static Delegate? cb_connect_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IIZ_Z;

	private static Delegate? cb_copyFrom_CopyFrom_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Ljava_util_HashMap__V;

	private static Delegate? cb_findDependents_FindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup__V;

	private static Delegate? cb_getType_GetType_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_;

	private static Delegate? cb_isConnectionAllowed_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Z;

	private static Delegate? cb_isConnectionAllowed_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__Z;

	private static Delegate? cb_isSimilarDimensionConnection_IsSimilarDimensionConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__Z;

	private static Delegate? cb_isValidConnection_IsValidConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__Z;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_resetFinalResolution_ResetFinalResolution_V;

	private static Delegate? cb_resetSolverVariable_ResetSolverVariable_Landroidx_constraintlayout_core_Cache__V;

	private static Delegate? cb_setGoneMargin_SetGoneMargin_I_V;

	[Register("mMargin")]
	public int MMargin
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMargin.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMargin.I", this, value);
		}
	}

	[Register("mOwner")]
	public ConstraintWidget? MOwner
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceFields.GetObjectValue("mOwner.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mOwner.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mTarget")]
	public ConstraintAnchor? MTarget
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mTarget.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mTarget.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mType")]
	public Type? MType
	{
		get
		{
			return Java.Lang.Object.GetObject<Type>(_members.InstanceFields.GetObjectValue("mType.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mType.Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", this, new JniObjectReference(num));
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
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual HashSet? Dependents
	{
		[Register("getDependents", "()Ljava/util/HashSet;", "GetGetDependentsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<HashSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependents.()Ljava/util/HashSet;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int FinalValue
	{
		[Register("getFinalValue", "()I", "GetGetFinalValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFinalValue.()I", this, null);
		}
		[Register("setFinalValue", "(I)V", "GetSetFinalValue_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool HasCenteredDependents
	{
		[Register("hasCenteredDependents", "()Z", "GetHasCenteredDependentsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasCenteredDependents.()Z", this, null);
		}
	}

	public unsafe virtual bool HasDependents
	{
		[Register("hasDependents", "()Z", "GetHasDependentsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDependents.()Z", this, null);
		}
	}

	public unsafe virtual bool HasFinalValue
	{
		[Register("hasFinalValue", "()Z", "GetHasFinalValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFinalValue.()Z", this, null);
		}
	}

	public unsafe virtual bool IsConnected
	{
		[Register("isConnected", "()Z", "GetIsConnectedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnected.()Z", this, null);
		}
	}

	public unsafe virtual bool IsSideAnchor
	{
		[Register("isSideAnchor", "()Z", "GetIsSideAnchorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSideAnchor.()Z", this, null);
		}
	}

	public unsafe virtual bool IsVerticalAnchor
	{
		[Register("isVerticalAnchor", "()Z", "GetIsVerticalAnchorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVerticalAnchor.()Z", this, null);
		}
	}

	public unsafe virtual int Margin
	{
		[Register("getMargin", "()I", "GetGetMarginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMargin.()I", this, null);
		}
		[Register("setMargin", "(I)V", "GetSetMargin_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMargin.(I)V", this, ptr);
		}
	}

	public unsafe ConstraintAnchor? Opposite
	{
		[Register("getOpposite", "()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOpposite.()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ConstraintWidget? Owner
	{
		[Register("getOwner", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetOwnerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOwner.()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual SolverVariable? SolverVariable
	{
		[Register("getSolverVariable", "()Landroidx/constraintlayout/core/SolverVariable;", "GetGetSolverVariableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSolverVariable.()Landroidx/constraintlayout/core/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ConstraintAnchor? Target
	{
		[Register("getTarget", "()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", "GetGetTargetHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTarget.()Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ConstraintAnchor(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)V", "")]
	public unsafe ConstraintAnchor(ConstraintWidget? owner, Type? type)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(owner?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)V", base.GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetGetDependentsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDependents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDependents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dependents);
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

	private static Delegate GetGetFinalValueHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetFinalValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetFinalValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalValue;
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

	private static Delegate GetSetFinalValue_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFinalValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalValue_I(nint jnienv, nint native__this, int finalValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalValue = finalValue;
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

	private static Delegate GetHasCenteredDependentsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasCenteredDependents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasCenteredDependents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCenteredDependents ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasDependentsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasDependents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasDependents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDependents ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasFinalValueHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasFinalValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasFinalValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFinalValue ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsConnectedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsConnected);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConnected(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnected ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsSideAnchorHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSideAnchor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSideAnchor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSideAnchor ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsVerticalAnchorHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsVerticalAnchor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVerticalAnchor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVerticalAnchor ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMarginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMargin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMargin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Margin;
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

	private static Delegate GetSetMargin_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMargin_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMargin_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Margin = margin;
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

	private static Delegate GetGetOwnerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetOwner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOwner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Owner);
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

	private static Delegate GetGetSolverVariableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSolverVariable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSolverVariable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SolverVariable);
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

	private static Delegate GetGetTargetHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTarget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTarget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Target);
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

	private static Delegate GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler()
	{
		return new global::_JniMarshal_PPLI_B(n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I(nint jnienv, nint native__this, nint native_toAnchor, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor toAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_toAnchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.Connect(toAnchor, margin) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("connect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)Z", "GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler")]
	public unsafe virtual bool Connect(ConstraintAnchor? toAnchor, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(toAnchor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(margin);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("connect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toAnchor);
		}
	}

	private static Delegate GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IIZHandler()
	{
		return new _JniMarshal_PPLIIB_B(n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IIZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IIZ(nint jnienv, nint native__this, nint native_toAnchor, int margin, int goneMargin, sbyte native_forceConnection)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor toAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_toAnchor, JniHandleOwnership.DoNotTransfer);
			bool forceConnection = native_forceConnection != 0;
			return constraintAnchor.Connect(toAnchor, margin, goneMargin, forceConnection) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("connect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;IIZ)Z", "GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IIZHandler")]
	public unsafe virtual bool Connect(ConstraintAnchor? toAnchor, int margin, int goneMargin, bool forceConnection)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(toAnchor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(margin);
			ptr[2] = new JniArgumentValue(goneMargin);
			ptr[3] = new JniArgumentValue(forceConnection ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("connect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;IIZ)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toAnchor);
		}
	}

	private static Delegate GetCopyFrom_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Ljava_util_HashMap_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_CopyFrom_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Ljava_util_HashMap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CopyFrom_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Ljava_util_HashMap_(nint jnienv, nint native__this, nint native_source, nint native_map)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor source = Java.Lang.Object.GetObject<ConstraintAnchor>(native_source, JniHandleOwnership.DoNotTransfer);
			IDictionary<ConstraintWidget, ConstraintWidget> map = JavaDictionary<ConstraintWidget, ConstraintWidget>.FromJniHandle(native_map, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.CopyFrom(source, map);
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

	[Register("copyFrom", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Ljava/util/HashMap;)V", "GetCopyFrom_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Ljava_util_HashMap_Handler")]
	public unsafe virtual void CopyFrom(ConstraintAnchor? source, IDictionary<ConstraintWidget, ConstraintWidget>? map)
	{
		nint num = JavaDictionary<ConstraintWidget, ConstraintWidget>.ToLocalJniHandle(map);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Ljava/util/HashMap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(source);
			GC.KeepAlive(map);
		}
	}

	private static Delegate GetFindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler()
	{
		return new global::_JniMarshal_PPILL_V(n_FindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_(nint jnienv, nint native__this, int orientation, nint native_list, nint native_group)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> list = JavaList<WidgetGroup>.FromJniHandle(native_list, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.FindDependents(orientation, list, widgetGroup);
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

	[Register("findDependents", "(ILjava/util/ArrayList;Landroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", "GetFindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler")]
	public unsafe virtual void FindDependents(int orientation, IList<WidgetGroup>? list, WidgetGroup? group)
	{
		nint num = JavaList<WidgetGroup>.ToLocalJniHandle(list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(orientation);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("findDependents.(ILjava/util/ArrayList;Landroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(list);
			GC.KeepAlive(group);
		}
	}

	private static Delegate GetGetTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetType());
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

	[Register("getType", "()Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", "GetGetTypeHandler")]
	public new unsafe virtual Type? GetType()
	{
		return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_target)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsConnectionAllowed(target) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isConnectionAllowed", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Z", "GetIsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual bool IsConnectionAllowed(ConstraintWidget? target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnectionAllowed.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetIsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_target, nint native_anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsConnectionAllowed(target, anchor) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isConnectionAllowed", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", "GetIsConnectionAllowed_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual bool IsConnectionAllowed(ConstraintWidget? target, ConstraintAnchor? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnectionAllowed.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetIsSimilarDimensionConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsSimilarDimensionConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSimilarDimensionConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsSimilarDimensionConnection(anchor) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isSimilarDimensionConnection", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", "GetIsSimilarDimensionConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual bool IsSimilarDimensionConnection(ConstraintAnchor? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSimilarDimensionConnection.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetIsValidConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsValidConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsValidConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsValidConnection(anchor) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isValidConnection", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", "GetIsValidConnection_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual bool IsValidConnection(ConstraintAnchor? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isValidConnection.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetResetFinalResolutionHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResetFinalResolution);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetFinalResolution(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetFinalResolution();
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

	[Register("resetFinalResolution", "()V", "GetResetFinalResolutionHandler")]
	public unsafe virtual void ResetFinalResolution()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resetFinalResolution.()V", this, null);
	}

	private static Delegate GetResetSolverVariable_Landroidx_constraintlayout_core_Cache_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ResetSolverVariable_Landroidx_constraintlayout_core_Cache_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetSolverVariable_Landroidx_constraintlayout_core_Cache_(nint jnienv, nint native__this, nint native_cache)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintAnchor? constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Cache cache = Java.Lang.Object.GetObject<Cache>(native_cache, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.ResetSolverVariable(cache);
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

	[Register("resetSolverVariable", "(Landroidx/constraintlayout/core/Cache;)V", "GetResetSolverVariable_Landroidx_constraintlayout_core_Cache_Handler")]
	public unsafe virtual void ResetSolverVariable(Cache? cache)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetSolverVariable.(Landroidx/constraintlayout/core/Cache;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cache);
		}
	}

	private static Delegate GetSetGoneMargin_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetGoneMargin_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGoneMargin_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGoneMargin(margin);
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

	[Register("setGoneMargin", "(I)V", "GetSetGoneMargin_IHandler")]
	public unsafe virtual void SetGoneMargin(int margin)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(margin);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(I)V", this, ptr);
	}
}
