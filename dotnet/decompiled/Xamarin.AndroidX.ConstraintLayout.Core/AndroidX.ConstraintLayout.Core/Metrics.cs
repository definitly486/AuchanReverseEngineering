using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core;

[Register("androidx/constraintlayout/core/Metrics", DoNotGenerateAcw = true)]
public class Metrics : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/Metrics", typeof(Metrics));

	private static Delegate? cb_copy_Copy_Landroidx_constraintlayout_core_Metrics__V;

	private static Delegate? cb_reset_Reset_V;

	[Register("additionalMeasures")]
	public long AdditionalMeasures
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("additionalMeasures.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("additionalMeasures.J", this, value);
		}
	}

	[Register("bfs")]
	public long Bfs
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("bfs.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("bfs.J", this, value);
		}
	}

	[Register("constraints")]
	public long Constraints
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("constraints.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("constraints.J", this, value);
		}
	}

	[Register("determineGroups")]
	public long DetermineGroups
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("determineGroups.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("determineGroups.J", this, value);
		}
	}

	[Register("errors")]
	public long Errors
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("errors.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("errors.J", this, value);
		}
	}

	[Register("extravariables")]
	public long Extravariables
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("extravariables.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("extravariables.J", this, value);
		}
	}

	[Register("fullySolved")]
	public long FullySolved
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("fullySolved.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("fullySolved.J", this, value);
		}
	}

	[Register("graphOptimizer")]
	public long GraphOptimizer
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("graphOptimizer.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("graphOptimizer.J", this, value);
		}
	}

	[Register("graphSolved")]
	public long GraphSolved
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("graphSolved.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("graphSolved.J", this, value);
		}
	}

	[Register("grouping")]
	public long Grouping
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("grouping.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("grouping.J", this, value);
		}
	}

	[Register("infeasibleDetermineGroups")]
	public long InfeasibleDetermineGroups
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("infeasibleDetermineGroups.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("infeasibleDetermineGroups.J", this, value);
		}
	}

	[Register("iterations")]
	public long Iterations
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("iterations.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("iterations.J", this, value);
		}
	}

	[Register("lastTableSize")]
	public long LastTableSize
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("lastTableSize.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("lastTableSize.J", this, value);
		}
	}

	[Register("layouts")]
	public long Layouts
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("layouts.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("layouts.J", this, value);
		}
	}

	[Register("linearSolved")]
	public long LinearSolved
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("linearSolved.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("linearSolved.J", this, value);
		}
	}

	[Register("maxRows")]
	public long MaxRows
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("maxRows.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("maxRows.J", this, value);
		}
	}

	[Register("maxTableSize")]
	public long MaxTableSize
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("maxTableSize.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("maxTableSize.J", this, value);
		}
	}

	[Register("maxVariables")]
	public long MaxVariables
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("maxVariables.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("maxVariables.J", this, value);
		}
	}

	[Register("mChildCount")]
	public long MChildCount
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mChildCount.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mChildCount.J", this, value);
		}
	}

	[Register("measuredMatchWidgets")]
	public long MeasuredMatchWidgets
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuredMatchWidgets.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuredMatchWidgets.J", this, value);
		}
	}

	[Register("measuredWidgets")]
	public long MeasuredWidgets
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuredWidgets.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuredWidgets.J", this, value);
		}
	}

	[Register("measures")]
	public long Measures
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measures.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measures.J", this, value);
		}
	}

	[Register("measuresLayoutDuration")]
	public long MeasuresLayoutDuration
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuresLayoutDuration.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuresLayoutDuration.J", this, value);
		}
	}

	[Register("measuresWidgetsDuration")]
	public long MeasuresWidgetsDuration
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuresWidgetsDuration.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuresWidgetsDuration.J", this, value);
		}
	}

	[Register("measuresWrap")]
	public long MeasuresWrap
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuresWrap.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuresWrap.J", this, value);
		}
	}

	[Register("measuresWrapInfeasible")]
	public long MeasuresWrapInfeasible
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("measuresWrapInfeasible.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measuresWrapInfeasible.J", this, value);
		}
	}

	[Register("mEquations")]
	public long MEquations
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mEquations.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mEquations.J", this, value);
		}
	}

	[Register("minimize")]
	public long Minimize
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("minimize.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("minimize.J", this, value);
		}
	}

	[Register("minimizeGoal")]
	public long MinimizeGoal
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("minimizeGoal.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("minimizeGoal.J", this, value);
		}
	}

	[Register("mMeasureCalls")]
	public long MMeasureCalls
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mMeasureCalls.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMeasureCalls.J", this, value);
		}
	}

	[Register("mMeasureDuration")]
	public long MMeasureDuration
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mMeasureDuration.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMeasureDuration.J", this, value);
		}
	}

	[Register("mNumberOfLayouts")]
	public int MNumberOfLayouts
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mNumberOfLayouts.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mNumberOfLayouts.I", this, value);
		}
	}

	[Register("mNumberOfMeasures")]
	public int MNumberOfMeasures
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mNumberOfMeasures.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mNumberOfMeasures.I", this, value);
		}
	}

	[Register("mSimpleEquations")]
	public long MSimpleEquations
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mSimpleEquations.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mSimpleEquations.J", this, value);
		}
	}

	[Register("mSolverPasses")]
	public long MSolverPasses
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mSolverPasses.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mSolverPasses.J", this, value);
		}
	}

	[Register("mVariables")]
	public long MVariables
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mVariables.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mVariables.J", this, value);
		}
	}

	[Register("nonresolvedWidgets")]
	public long NonresolvedWidgets
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("nonresolvedWidgets.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("nonresolvedWidgets.J", this, value);
		}
	}

	[Register("optimize")]
	public long Optimize
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("optimize.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("optimize.J", this, value);
		}
	}

	[Register("pivots")]
	public long Pivots
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("pivots.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("pivots.J", this, value);
		}
	}

	[Register("problematicLayouts")]
	public IList? ProblematicLayouts
	{
		get
		{
			return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("problematicLayouts.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("problematicLayouts.Ljava/util/ArrayList;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("resolutions")]
	public long Resolutions
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("resolutions.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("resolutions.J", this, value);
		}
	}

	[Register("resolvedWidgets")]
	public long ResolvedWidgets
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("resolvedWidgets.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("resolvedWidgets.J", this, value);
		}
	}

	[Register("simpleconstraints")]
	public long Simpleconstraints
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("simpleconstraints.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("simpleconstraints.J", this, value);
		}
	}

	[Register("slackvariables")]
	public long Slackvariables
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("slackvariables.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("slackvariables.J", this, value);
		}
	}

	[Register("tableSizeIncrease")]
	public long TableSizeIncrease
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("tableSizeIncrease.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("tableSizeIncrease.J", this, value);
		}
	}

	[Register("variables")]
	public long Variables
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("variables.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("variables.J", this, value);
		}
	}

	[Register("widgets")]
	public long Widgets
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("widgets.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("widgets.J", this, value);
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

	protected Metrics(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Metrics()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetCopy_Landroidx_constraintlayout_core_Metrics_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Copy_Landroidx_constraintlayout_core_Metrics_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Copy_Landroidx_constraintlayout_core_Metrics_(nint jnienv, nint native__this, nint native_metrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Metrics? metrics = Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics2 = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			metrics.Copy(metrics2);
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

	[Register("copy", "(Landroidx/constraintlayout/core/Metrics;)V", "GetCopy_Landroidx_constraintlayout_core_Metrics_Handler")]
	public unsafe virtual void Copy(Metrics? metrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("copy.(Landroidx/constraintlayout/core/Metrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(metrics);
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
			Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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
}
