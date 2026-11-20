using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/ConstraintWidgetContainer", DoNotGenerateAcw = true)]
public class ConstraintWidgetContainer : WidgetContainer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/ConstraintWidgetContainer", typeof(ConstraintWidgetContainer));

	private static Delegate? cb_getHorizontalGuidelines_GetHorizontalGuidelines_Ljava_util_ArrayList_;

	private static Delegate? cb_isHeightMeasuredTooSmall_IsHeightMeasuredTooSmall_Z;

	private static Delegate? cb_isWidthMeasuredTooSmall_IsWidthMeasuredTooSmall_Z;

	private static Delegate? cb_getMeasurer_GetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_;

	private static Delegate? cb_setMeasurer_SetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer__V;

	private static Delegate? cb_getOptimizationLevel_GetOptimizationLevel_I;

	private static Delegate? cb_setOptimizationLevel_SetOptimizationLevel_I_V;

	private static Delegate? cb_isRtl_IsRtl_Z;

	private static Delegate? cb_setRtl_SetRtl_Z_V;

	private static Delegate? cb_getSystem_GetSystem_Landroidx_constraintlayout_core_LinearSystem_;

	private static Delegate? cb_getVerticalGuidelines_GetVerticalGuidelines_Ljava_util_ArrayList_;

	private static Delegate? cb_addChildrenToSolver_AddChildrenToSolver_Landroidx_constraintlayout_core_LinearSystem__Z;

	private static Delegate? cb_addHorizontalWrapMaxVariable_AddHorizontalWrapMaxVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__V;

	private static Delegate? cb_addHorizontalWrapMinVariable_AddHorizontalWrapMinVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__V;

	private static Delegate? cb_defineTerminalWidgets_DefineTerminalWidgets_V;

	private static Delegate? cb_directMeasure_DirectMeasure_Z_Z;

	private static Delegate? cb_directMeasureSetup_DirectMeasureSetup_Z_Z;

	private static Delegate? cb_directMeasureWithOrientation_DirectMeasureWithOrientation_ZI_Z;

	private static Delegate? cb_fillMetrics_FillMetrics_Landroidx_constraintlayout_core_Metrics__V;

	private static Delegate? cb_handlesInternalConstraints_HandlesInternalConstraints_Z;

	private static Delegate? cb_invalidateGraph_InvalidateGraph_V;

	private static Delegate? cb_invalidateMeasures_InvalidateMeasures_V;

	private static Delegate? cb_measure_Measure_IIIIIIIII_J;

	private static Delegate? cb_optimizeFor_OptimizeFor_I_Z;

	private static Delegate? cb_setPadding_SetPadding_IIII_V;

	private static Delegate? cb_setPass_SetPass_I_V;

	private static Delegate? cb_updateChildrenFromSolver_UpdateChildrenFromSolver_Landroidx_constraintlayout_core_LinearSystem_arrayZ_Z;

	private static Delegate? cb_updateHierarchy_UpdateHierarchy_V;

	[Register("mDependencyGraph")]
	public DependencyGraph? MDependencyGraph
	{
		get
		{
			return Java.Lang.Object.GetObject<DependencyGraph>(_members.InstanceFields.GetObjectValue("mDependencyGraph.Landroidx/constraintlayout/core/widgets/analyzer/DependencyGraph;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mDependencyGraph.Landroidx/constraintlayout/core/widgets/analyzer/DependencyGraph;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mGroupsWrapOptimized")]
	public bool MGroupsWrapOptimized
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mGroupsWrapOptimized.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mGroupsWrapOptimized.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mHorizontalChainsSize")]
	public int MHorizontalChainsSize
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mHorizontalChainsSize.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mHorizontalChainsSize.I", this, value);
		}
	}

	[Register("mHorizontalWrapOptimized")]
	public bool MHorizontalWrapOptimized
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mHorizontalWrapOptimized.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mHorizontalWrapOptimized.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mMeasure")]
	public BasicMeasure.Measure? MMeasure
	{
		get
		{
			return Java.Lang.Object.GetObject<BasicMeasure.Measure>(_members.InstanceFields.GetObjectValue("mMeasure.Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mMeasure.Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mMeasurer")]
	protected BasicMeasure.IMeasurer? MMeasurer
	{
		get
		{
			return Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(_members.InstanceFields.GetObjectValue("mMeasurer.Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mMeasurer.Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mMetrics")]
	public Metrics? MMetrics
	{
		get
		{
			return Java.Lang.Object.GetObject<Metrics>(_members.InstanceFields.GetObjectValue("mMetrics.Landroidx/constraintlayout/core/Metrics;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mMetrics.Landroidx/constraintlayout/core/Metrics;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mSkipSolver")]
	public bool MSkipSolver
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mSkipSolver.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mSkipSolver.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mSystem")]
	protected LinearSystem? MSystem
	{
		get
		{
			return Java.Lang.Object.GetObject<LinearSystem>(_members.InstanceFields.GetObjectValue("mSystem.Landroidx/constraintlayout/core/LinearSystem;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mSystem.Landroidx/constraintlayout/core/LinearSystem;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mVerticalChainsSize")]
	public int MVerticalChainsSize
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mVerticalChainsSize.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mVerticalChainsSize.I", this, value);
		}
	}

	[Register("mVerticalWrapOptimized")]
	public bool MVerticalWrapOptimized
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mVerticalWrapOptimized.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mVerticalWrapOptimized.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mWrapFixedHeight")]
	public int MWrapFixedHeight
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mWrapFixedHeight.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mWrapFixedHeight.I", this, value);
		}
	}

	[Register("mWrapFixedWidth")]
	public int MWrapFixedWidth
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mWrapFixedWidth.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mWrapFixedWidth.I", this, value);
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

	public unsafe virtual IList<Guideline>? HorizontalGuidelines
	{
		[Register("getHorizontalGuidelines", "()Ljava/util/ArrayList;", "GetGetHorizontalGuidelinesHandler")]
		get
		{
			return JavaList<Guideline>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalGuidelines.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsHeightMeasuredTooSmall
	{
		[Register("isHeightMeasuredTooSmall", "()Z", "GetIsHeightMeasuredTooSmallHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeightMeasuredTooSmall.()Z", this, null);
		}
	}

	public unsafe virtual bool IsWidthMeasuredTooSmall
	{
		[Register("isWidthMeasuredTooSmall", "()Z", "GetIsWidthMeasuredTooSmallHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isWidthMeasuredTooSmall.()Z", this, null);
		}
	}

	public unsafe virtual BasicMeasure.IMeasurer? Measurer
	{
		[Register("getMeasurer", "()Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;", "GetGetMeasurerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMeasurer.()Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setMeasurer", "(Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;)V", "GetSetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurer.(Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int OptimizationLevel
	{
		[Register("getOptimizationLevel", "()I", "GetGetOptimizationLevelHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizationLevel.()I", this, null);
		}
		[Register("setOptimizationLevel", "(I)V", "GetSetOptimizationLevel_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOptimizationLevel.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool Rtl
	{
		[Register("isRtl", "()Z", "GetIsRtlHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRtl.()Z", this, null);
		}
		[Register("setRtl", "(Z)V", "GetSetRtl_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRtl.(Z)V", this, ptr);
		}
	}

	public unsafe virtual LinearSystem? System
	{
		[Register("getSystem", "()Landroidx/constraintlayout/core/LinearSystem;", "GetGetSystemHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LinearSystem>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystem.()Landroidx/constraintlayout/core/LinearSystem;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<Guideline>? VerticalGuidelines
	{
		[Register("getVerticalGuidelines", "()Ljava/util/ArrayList;", "GetGetVerticalGuidelinesHandler")]
		get
		{
			return JavaList<Guideline>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalGuidelines.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ConstraintWidgetContainer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ConstraintWidgetContainer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe ConstraintWidgetContainer(int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	[Register(".ctor", "(IIII)V", "")]
	public unsafe ConstraintWidgetContainer(int x, int y, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;II)V", "")]
	public unsafe ConstraintWidgetContainer(string? debugName, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(debugName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(width);
			ptr[2] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetHorizontalGuidelinesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHorizontalGuidelines);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHorizontalGuidelines(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Guideline>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalGuidelines);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsHeightMeasuredTooSmallHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHeightMeasuredTooSmall);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHeightMeasuredTooSmall(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHeightMeasuredTooSmall ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsWidthMeasuredTooSmallHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsWidthMeasuredTooSmall);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsWidthMeasuredTooSmall(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsWidthMeasuredTooSmall ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMeasurerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMeasurer);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMeasurer(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Measurer);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_(nint jnienv, nint native__this, nint native_measurer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BasicMeasure.IMeasurer measurer = Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(native_measurer, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.Measurer = measurer;
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetOptimizationLevelHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOptimizationLevel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOptimizationLevel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel;
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetOptimizationLevel_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOptimizationLevel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOptimizationLevel_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel = value;
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsRtlHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRtl);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRtl(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rtl ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetRtl_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRtl_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRtl_Z(nint jnienv, nint native__this, sbyte native_isRtl)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool rtl = native_isRtl != 0;
			constraintWidgetContainer.Rtl = rtl;
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetSystemHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSystem);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSystem(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).System);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalGuidelinesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVerticalGuidelines);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVerticalGuidelines(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Guideline>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalGuidelines);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetAddChildrenToSolver_Landroidx_constraintlayout_core_LinearSystem_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_AddChildrenToSolver_Landroidx_constraintlayout_core_LinearSystem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AddChildrenToSolver_Landroidx_constraintlayout_core_LinearSystem_(nint jnienv, nint native__this, nint native_system)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return constraintWidgetContainer.AddChildrenToSolver(system) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addChildrenToSolver", "(Landroidx/constraintlayout/core/LinearSystem;)Z", "GetAddChildrenToSolver_Landroidx_constraintlayout_core_LinearSystem_Handler")]
	public unsafe virtual bool AddChildrenToSolver(LinearSystem? system)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("addChildrenToSolver.(Landroidx/constraintlayout/core/LinearSystem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetAddHorizontalWrapMaxVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddHorizontalWrapMaxVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddHorizontalWrapMaxVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_right)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor right = Java.Lang.Object.GetObject<ConstraintAnchor>(native_right, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.AddHorizontalWrapMaxVariable(right);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addHorizontalWrapMaxVariable", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", "GetAddHorizontalWrapMaxVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual void AddHorizontalWrapMaxVariable(ConstraintAnchor? right)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(right?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addHorizontalWrapMaxVariable.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(right);
		}
	}

	private static Delegate GetAddHorizontalWrapMinVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddHorizontalWrapMinVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddHorizontalWrapMinVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_left)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor left = Java.Lang.Object.GetObject<ConstraintAnchor>(native_left, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.AddHorizontalWrapMinVariable(left);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addHorizontalWrapMinVariable", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", "GetAddHorizontalWrapMinVariable_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual void AddHorizontalWrapMinVariable(ConstraintAnchor? left)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(left?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addHorizontalWrapMinVariable.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(left);
		}
	}

	private static Delegate GetDefineTerminalWidgetsHandler()
	{
		return new global::_JniMarshal_PP_V(n_DefineTerminalWidgets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DefineTerminalWidgets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefineTerminalWidgets();
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("defineTerminalWidgets", "()V", "GetDefineTerminalWidgetsHandler")]
	public unsafe virtual void DefineTerminalWidgets()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("defineTerminalWidgets.()V", this, null);
	}

	private static Delegate GetDirectMeasure_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_DirectMeasure_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DirectMeasure_Z(nint jnienv, nint native__this, sbyte native_optimizeWrap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return constraintWidgetContainer.DirectMeasure(optimizeWrap) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("directMeasure", "(Z)Z", "GetDirectMeasure_ZHandler")]
	public unsafe virtual bool DirectMeasure(bool optimizeWrap)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(optimizeWrap ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasure.(Z)Z", this, ptr);
	}

	private static Delegate GetDirectMeasureSetup_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_DirectMeasureSetup_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DirectMeasureSetup_Z(nint jnienv, nint native__this, sbyte native_optimizeWrap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return constraintWidgetContainer.DirectMeasureSetup(optimizeWrap) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("directMeasureSetup", "(Z)Z", "GetDirectMeasureSetup_ZHandler")]
	public unsafe virtual bool DirectMeasureSetup(bool optimizeWrap)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(optimizeWrap ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureSetup.(Z)Z", this, ptr);
	}

	private static Delegate GetDirectMeasureWithOrientation_ZIHandler()
	{
		return new _JniMarshal_PPBI_B(n_DirectMeasureWithOrientation_ZI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DirectMeasureWithOrientation_ZI(nint jnienv, nint native__this, sbyte native_optimizeWrap, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return constraintWidgetContainer.DirectMeasureWithOrientation(optimizeWrap, orientation) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("directMeasureWithOrientation", "(ZI)Z", "GetDirectMeasureWithOrientation_ZIHandler")]
	public unsafe virtual bool DirectMeasureWithOrientation(bool optimizeWrap, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(optimizeWrap ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureWithOrientation.(ZI)Z", this, ptr);
	}

	private static Delegate GetFillMetrics_Landroidx_constraintlayout_core_Metrics_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_FillMetrics_Landroidx_constraintlayout_core_Metrics_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FillMetrics_Landroidx_constraintlayout_core_Metrics_(nint jnienv, nint native__this, nint native_metrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.FillMetrics(metrics);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("fillMetrics", "(Landroidx/constraintlayout/core/Metrics;)V", "GetFillMetrics_Landroidx_constraintlayout_core_Metrics_Handler")]
	public unsafe virtual void FillMetrics(Metrics? metrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillMetrics.(Landroidx/constraintlayout/core/Metrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(metrics);
		}
	}

	private static Delegate GetHandlesInternalConstraintsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HandlesInternalConstraints);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HandlesInternalConstraints(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandlesInternalConstraints() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("handlesInternalConstraints", "()Z", "GetHandlesInternalConstraintsHandler")]
	public unsafe virtual bool HandlesInternalConstraints()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("handlesInternalConstraints.()Z", this, null);
	}

	private static Delegate GetInvalidateGraphHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateGraph);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateGraph(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateGraph();
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("invalidateGraph", "()V", "GetInvalidateGraphHandler")]
	public unsafe virtual void InvalidateGraph()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateGraph.()V", this, null);
	}

	private static Delegate GetInvalidateMeasuresHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateMeasures);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateMeasures(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMeasures();
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("invalidateMeasures", "()V", "GetInvalidateMeasuresHandler")]
	public unsafe virtual void InvalidateMeasures()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMeasures.()V", this, null);
	}

	[Register("measure", "(ILandroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;I)Z", "")]
	public unsafe static bool Measure(int level, ConstraintWidget? widget, BasicMeasure.IMeasurer? measurer, BasicMeasure.Measure? measure, int measureStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(level);
			ptr[1] = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((measurer == null) ? IntPtr.Zero : ((Java.Lang.Object)measurer).Handle);
			ptr[3] = new JniArgumentValue(measure?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(measureStrategy);
			return _members.StaticMethods.InvokeBooleanMethod("measure.(ILandroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(measurer);
			GC.KeepAlive(measure);
		}
	}

	private static Delegate GetMeasure_IIIIIIIIIHandler()
	{
		return new _JniMarshal_PPIIIIIIIII_J(n_Measure_IIIIIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_Measure_IIIIIIIII(nint jnienv, nint native__this, int optimizationLevel, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight, int paddingX, int paddingY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Measure(optimizationLevel, widthMode, widthSize, heightMode, heightSize, lastMeasureWidth, lastMeasureHeight, paddingX, paddingY);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("measure", "(IIIIIIIII)J", "GetMeasure_IIIIIIIIIHandler")]
	public unsafe virtual long Measure(int optimizationLevel, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight, int paddingX, int paddingY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
		*ptr = new JniArgumentValue(optimizationLevel);
		ptr[1] = new JniArgumentValue(widthMode);
		ptr[2] = new JniArgumentValue(widthSize);
		ptr[3] = new JniArgumentValue(heightMode);
		ptr[4] = new JniArgumentValue(heightSize);
		ptr[5] = new JniArgumentValue(lastMeasureWidth);
		ptr[6] = new JniArgumentValue(lastMeasureHeight);
		ptr[7] = new JniArgumentValue(paddingX);
		ptr[8] = new JniArgumentValue(paddingY);
		return _members.InstanceMethods.InvokeVirtualInt64Method("measure.(IIIIIIIII)J", this, ptr);
	}

	private static Delegate GetOptimizeFor_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_OptimizeFor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OptimizeFor_I(nint jnienv, nint native__this, int feature)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizeFor(feature) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("optimizeFor", "(I)Z", "GetOptimizeFor_IHandler")]
	public unsafe virtual bool OptimizeFor(int feature)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(feature);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("optimizeFor.(I)Z", this, ptr);
	}

	private static Delegate GetSetPadding_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetPadding_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPadding_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPadding(left, top, right, bottom);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setPadding", "(IIII)V", "GetSetPadding_IIIIHandler")]
	public unsafe virtual void SetPadding(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPadding.(IIII)V", this, ptr);
	}

	private static Delegate GetSetPass_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPass_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPass_I(nint jnienv, nint native__this, int pass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPass(pass);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setPass", "(I)V", "GetSetPass_IHandler")]
	public unsafe virtual void SetPass(int pass)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pass);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPass.(I)V", this, ptr);
	}

	private static Delegate GetUpdateChildrenFromSolver_Landroidx_constraintlayout_core_LinearSystem_arrayZHandler()
	{
		return new global::_JniMarshal_PPLL_B(n_UpdateChildrenFromSolver_Landroidx_constraintlayout_core_LinearSystem_arrayZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_UpdateChildrenFromSolver_Landroidx_constraintlayout_core_LinearSystem_arrayZ(nint jnienv, nint native__this, nint native_system, nint native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidgetContainer? constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool[] array = (bool[])JNIEnv.GetArray(native_flags, JniHandleOwnership.DoNotTransfer, typeof(bool));
			sbyte result = (constraintWidgetContainer.UpdateChildrenFromSolver(system, array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_flags);
			}
			return result;
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("updateChildrenFromSolver", "(Landroidx/constraintlayout/core/LinearSystem;[Z)Z", "GetUpdateChildrenFromSolver_Landroidx_constraintlayout_core_LinearSystem_arrayZHandler")]
	public unsafe virtual bool UpdateChildrenFromSolver(LinearSystem? system, bool[]? flags)
	{
		nint num = JNIEnv.NewArray(flags);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("updateChildrenFromSolver.(Landroidx/constraintlayout/core/LinearSystem;[Z)Z", this, ptr);
		}
		finally
		{
			if (flags != null)
			{
				JNIEnv.CopyArray(num, flags);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(system);
			GC.KeepAlive(flags);
		}
	}

	private static Delegate GetUpdateHierarchyHandler()
	{
		return new global::_JniMarshal_PP_V(n_UpdateHierarchy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateHierarchy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateHierarchy();
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("updateHierarchy", "()V", "GetUpdateHierarchyHandler")]
	public unsafe virtual void UpdateHierarchy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateHierarchy.()V", this, null);
	}
}
