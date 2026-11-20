using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/DependencyGraph", DoNotGenerateAcw = true)]
public class DependencyGraph : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/DependencyGraph", typeof(DependencyGraph));

	private static Delegate? cb_buildGraph_BuildGraph_V;

	private static Delegate? cb_buildGraph_BuildGraph_Ljava_util_ArrayList__V;

	private static Delegate? cb_defineTerminalWidgets_DefineTerminalWidgets_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour__V;

	private static Delegate? cb_directMeasure_DirectMeasure_Z_Z;

	private static Delegate? cb_directMeasureSetup_DirectMeasureSetup_Z_Z;

	private static Delegate? cb_directMeasureWithOrientation_DirectMeasureWithOrientation_ZI_Z;

	private static Delegate? cb_invalidateGraph_InvalidateGraph_V;

	private static Delegate? cb_invalidateMeasures_InvalidateMeasures_V;

	private static Delegate? cb_measureWidgets_MeasureWidgets_V;

	private static Delegate? cb_setMeasurer_SetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer__V;

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

	protected DependencyGraph(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", "")]
	public unsafe DependencyGraph(ConstraintWidgetContainer? container)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetBuildGraphHandler()
	{
		return new global::_JniMarshal_PP_V(n_BuildGraph);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BuildGraph(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuildGraph();
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

	[Register("buildGraph", "()V", "GetBuildGraphHandler")]
	public unsafe virtual void BuildGraph()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("buildGraph.()V", this, null);
	}

	private static Delegate GetBuildGraph_Ljava_util_ArrayList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_BuildGraph_Ljava_util_ArrayList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BuildGraph_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_runs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetRun> runs = JavaList<WidgetRun>.FromJniHandle(native_runs, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.BuildGraph(runs);
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

	[Register("buildGraph", "(Ljava/util/ArrayList;)V", "GetBuildGraph_Ljava_util_ArrayList_Handler")]
	public unsafe virtual void BuildGraph(IList<WidgetRun>? runs)
	{
		nint num = JavaList<WidgetRun>.ToLocalJniHandle(runs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("buildGraph.(Ljava/util/ArrayList;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(runs);
		}
	}

	private static Delegate GetDefineTerminalWidgets_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_DefineTerminalWidgets_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DefineTerminalWidgets_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_(nint jnienv, nint native__this, nint native_horizontalBehavior, nint native_verticalBehavior)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget.DimensionBehaviour horizontalBehavior = Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(native_horizontalBehavior, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget.DimensionBehaviour verticalBehavior = Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(native_verticalBehavior, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.DefineTerminalWidgets(horizontalBehavior, verticalBehavior);
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

	[Register("defineTerminalWidgets", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetDefineTerminalWidgets_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
	public unsafe virtual void DefineTerminalWidgets(ConstraintWidget.DimensionBehaviour? horizontalBehavior, ConstraintWidget.DimensionBehaviour? verticalBehavior)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(horizontalBehavior?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(verticalBehavior?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("defineTerminalWidgets.(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(horizontalBehavior);
			GC.KeepAlive(verticalBehavior);
		}
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
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return dependencyGraph.DirectMeasure(optimizeWrap) ? ((sbyte)1) : ((sbyte)0);
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
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return dependencyGraph.DirectMeasureSetup(optimizeWrap) ? ((sbyte)1) : ((sbyte)0);
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
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optimizeWrap = native_optimizeWrap != 0;
			return dependencyGraph.DirectMeasureWithOrientation(optimizeWrap, orientation) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("directMeasureWithOrientation", "(ZI)Z", "GetDirectMeasureWithOrientation_ZIHandler")]
	public unsafe virtual bool DirectMeasureWithOrientation(bool optimizeWrap, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(optimizeWrap ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureWithOrientation.(ZI)Z", this, ptr);
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
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateGraph();
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
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMeasures();
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

	[Register("invalidateMeasures", "()V", "GetInvalidateMeasuresHandler")]
	public unsafe virtual void InvalidateMeasures()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMeasures.()V", this, null);
	}

	private static Delegate GetMeasureWidgetsHandler()
	{
		return new global::_JniMarshal_PP_V(n_MeasureWidgets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MeasureWidgets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureWidgets();
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

	[Register("measureWidgets", "()V", "GetMeasureWidgetsHandler")]
	public unsafe virtual void MeasureWidgets()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("measureWidgets.()V", this, null);
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
			DependencyGraph? dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BasicMeasure.IMeasurer measurer = Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(native_measurer, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.SetMeasurer(measurer);
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

	[Register("setMeasurer", "(Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;)V", "GetSetMeasurer_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer_Handler")]
	public unsafe virtual void SetMeasurer(BasicMeasure.IMeasurer? measurer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((measurer == null) ? IntPtr.Zero : ((Java.Lang.Object)measurer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurer.(Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(measurer);
		}
	}
}
