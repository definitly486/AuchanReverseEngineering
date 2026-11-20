using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Widgets;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core;

[Register("androidx/constraintlayout/core/LinearSystem", DoNotGenerateAcw = true)]
public class LinearSystem : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/LinearSystem", typeof(LinearSystem));

	private static Delegate? cb_getCache_GetCache_Landroidx_constraintlayout_core_Cache_;

	private static Delegate? cb_getMemoryUsed_GetMemoryUsed_I;

	private static Delegate? cb_getNumEquations_GetNumEquations_I;

	private static Delegate? cb_getNumVariables_GetNumVariables_I;

	private static Delegate? cb_addCenterPoint_AddCenterPoint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI_V;

	private static Delegate? cb_addCentering_AddCentering_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II_V;

	private static Delegate? cb_addConstraint_AddConstraint_Landroidx_constraintlayout_core_ArrayRow__V;

	private static Delegate? cb_addEquality_AddEquality_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_addEquality_AddEquality_Landroidx_constraintlayout_core_SolverVariable_I_V;

	private static Delegate? cb_addGreaterBarrier_AddGreaterBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ_V;

	private static Delegate? cb_addGreaterThan_AddGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II_V;

	private static Delegate? cb_addLowerBarrier_AddLowerBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ_V;

	private static Delegate? cb_addLowerThan_AddLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II_V;

	private static Delegate? cb_addRatio_AddRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FI_V;

	private static Delegate? cb_addSynonym_AddSynonym_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I_V;

	private static Delegate? cb_createErrorVariable_CreateErrorVariable_ILjava_lang_String__Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_createExtraVariable_CreateExtraVariable_Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_createObjectVariable_CreateObjectVariable_Ljava_lang_Object__Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_createRow_CreateRow_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createSlackVariable_CreateSlackVariable_Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_displayReadableRows_DisplayReadableRows_V;

	private static Delegate? cb_displayVariablesReadableRows_DisplayVariablesReadableRows_V;

	private static Delegate? cb_fillMetrics_FillMetrics_Landroidx_constraintlayout_core_Metrics__V;

	private static Delegate? cb_getObjectVariableValue_GetObjectVariableValue_Ljava_lang_Object__I;

	private static Delegate? cb_minimize_Minimize_V;

	private static Delegate? cb_removeRow_RemoveRow_Landroidx_constraintlayout_core_ArrayRow__V;

	private static Delegate? cb_reset_Reset_V;

	[Register("ARRAY_ROW_CREATION")]
	public static long ArrayRowCreation
	{
		get
		{
			return _members.StaticFields.GetInt64Value("ARRAY_ROW_CREATION.J");
		}
		set
		{
			_members.StaticFields.SetValue("ARRAY_ROW_CREATION.J", value);
		}
	}

	[Register("graphOptimizer")]
	public bool GraphOptimizer
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("graphOptimizer.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("graphOptimizer.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("hasSimpleDefinition")]
	public bool HasSimpleDefinition
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("hasSimpleDefinition.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("hasSimpleDefinition.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("newgraphOptimizer")]
	public bool NewgraphOptimizer
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("newgraphOptimizer.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("newgraphOptimizer.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("OPTIMIZED_ARRAY_ROW_CREATION")]
	public static long OptimizedArrayRowCreation
	{
		get
		{
			return _members.StaticFields.GetInt64Value("OPTIMIZED_ARRAY_ROW_CREATION.J");
		}
		set
		{
			_members.StaticFields.SetValue("OPTIMIZED_ARRAY_ROW_CREATION.J", value);
		}
	}

	[Register("OPTIMIZED_ENGINE")]
	public static bool OptimizedEngine
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("OPTIMIZED_ENGINE.Z");
		}
		set
		{
			_members.StaticFields.SetValue("OPTIMIZED_ENGINE.Z", value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("SIMPLIFY_SYNONYMS")]
	public static bool SimplifySynonyms
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("SIMPLIFY_SYNONYMS.Z");
		}
		set
		{
			_members.StaticFields.SetValue("SIMPLIFY_SYNONYMS.Z", value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("SKIP_COLUMNS")]
	public static bool SkipColumns
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("SKIP_COLUMNS.Z");
		}
		set
		{
			_members.StaticFields.SetValue("SKIP_COLUMNS.Z", value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("sMetrics")]
	public static Metrics? SMetrics
	{
		get
		{
			return Java.Lang.Object.GetObject<Metrics>(_members.StaticFields.GetObjectValue("sMetrics.Landroidx/constraintlayout/core/Metrics;").Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.StaticFields.SetValue("sMetrics.Landroidx/constraintlayout/core/Metrics;", new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("USE_BASIC_SYNONYMS")]
	public static bool UseBasicSynonyms
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("USE_BASIC_SYNONYMS.Z");
		}
		set
		{
			_members.StaticFields.SetValue("USE_BASIC_SYNONYMS.Z", value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("USE_DEPENDENCY_ORDERING")]
	public static bool UseDependencyOrdering
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("USE_DEPENDENCY_ORDERING.Z");
		}
		set
		{
			_members.StaticFields.SetValue("USE_DEPENDENCY_ORDERING.Z", value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("USE_SYNONYMS")]
	public static bool UseSynonyms
	{
		get
		{
			return _members.StaticFields.GetBooleanValue("USE_SYNONYMS.Z");
		}
		set
		{
			_members.StaticFields.SetValue("USE_SYNONYMS.Z", value ? ((sbyte)1) : ((sbyte)0));
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

	public unsafe virtual Cache? Cache
	{
		[Register("getCache", "()Landroidx/constraintlayout/core/Cache;", "GetGetCacheHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Cache>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCache.()Landroidx/constraintlayout/core/Cache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int MemoryUsed
	{
		[Register("getMemoryUsed", "()I", "GetGetMemoryUsedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMemoryUsed.()I", this, null);
		}
	}

	public unsafe static Metrics? Metrics
	{
		[Register("getMetrics", "()Landroidx/constraintlayout/core/Metrics;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Metrics>(_members.StaticMethods.InvokeObjectMethod("getMetrics.()Landroidx/constraintlayout/core/Metrics;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int NumEquations
	{
		[Register("getNumEquations", "()I", "GetGetNumEquationsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNumEquations.()I", this, null);
		}
	}

	public unsafe virtual int NumVariables
	{
		[Register("getNumVariables", "()I", "GetGetNumVariablesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNumVariables.()I", this, null);
		}
	}

	protected LinearSystem(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LinearSystem()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCacheHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCache);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCache(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cache);
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

	private static Delegate GetGetMemoryUsedHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMemoryUsed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMemoryUsed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MemoryUsed;
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

	private static Delegate GetGetNumEquationsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNumEquations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNumEquations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumEquations;
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

	private static Delegate GetGetNumVariablesHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNumVariables);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNumVariables(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumVariables;
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

	private static Delegate GetAddCenterPoint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FIHandler()
	{
		return new _JniMarshal_PPLLFI_V(n_AddCenterPoint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCenterPoint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI(nint jnienv, nint native__this, nint native_widget, nint native_target, float angle, int radius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddCenterPoint(widget, target, angle, radius);
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

	[Register("addCenterPoint", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintWidget;FI)V", "GetAddCenterPoint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FIHandler")]
	public unsafe virtual void AddCenterPoint(ConstraintWidget? widget, ConstraintWidget? target, float angle, int radius)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(angle);
			ptr[3] = new JniArgumentValue(radius);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCenterPoint.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintWidget;FI)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetAddCentering_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler()
	{
		return new _JniMarshal_PPLLIFLLII_V(n_AddCentering_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCentering_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II(nint jnienv, nint native__this, nint native_a, nint native_b, int m1, float bias, nint native_c, nint native_d, int m2, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			SolverVariable c = Java.Lang.Object.GetObject<SolverVariable>(native_c, JniHandleOwnership.DoNotTransfer);
			SolverVariable d = Java.Lang.Object.GetObject<SolverVariable>(native_d, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddCentering(a, b, m1, bias, c, d, m2, strength);
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

	[Register("addCentering", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IFLandroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", "GetAddCentering_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler")]
	public unsafe virtual void AddCentering(SolverVariable? a, SolverVariable? b, int m1, float bias, SolverVariable? c, SolverVariable? d, int m2, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(m1);
			ptr[3] = new JniArgumentValue(bias);
			ptr[4] = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(m2);
			ptr[7] = new JniArgumentValue(strength);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCentering.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IFLandroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
			GC.KeepAlive(c);
			GC.KeepAlive(d);
		}
	}

	private static Delegate GetAddConstraint_Landroidx_constraintlayout_core_ArrayRow_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddConstraint_Landroidx_constraintlayout_core_ArrayRow_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddConstraint_Landroidx_constraintlayout_core_ArrayRow_(nint jnienv, nint native__this, nint native_row)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ArrayRow row = Java.Lang.Object.GetObject<ArrayRow>(native_row, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddConstraint(row);
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

	[Register("addConstraint", "(Landroidx/constraintlayout/core/ArrayRow;)V", "GetAddConstraint_Landroidx_constraintlayout_core_ArrayRow_Handler")]
	public unsafe virtual void AddConstraint(ArrayRow? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addConstraint.(Landroidx/constraintlayout/core/ArrayRow;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(row);
		}
	}

	private static Delegate GetAddEquality_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler()
	{
		return new _JniMarshal_PPLLII_L(n_AddEquality_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddEquality_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II(nint jnienv, nint native__this, nint native_a, nint native_b, int margin, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.AddEquality(a, b, margin, strength));
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

	[Register("addEquality", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)Landroidx/constraintlayout/core/ArrayRow;", "GetAddEquality_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler")]
	public unsafe virtual ArrayRow? AddEquality(SolverVariable? a, SolverVariable? b, int margin, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(strength);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("addEquality.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetAddEquality_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddEquality_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddEquality_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_a, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddEquality(a, value);
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

	[Register("addEquality", "(Landroidx/constraintlayout/core/SolverVariable;I)V", "GetAddEquality_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual void AddEquality(SolverVariable? a, int value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addEquality.(Landroidx/constraintlayout/core/SolverVariable;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
		}
	}

	private static Delegate GetAddGreaterBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZHandler()
	{
		return new _JniMarshal_PPLLIB_V(n_AddGreaterBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddGreaterBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ(nint jnienv, nint native__this, nint native_a, nint native_b, int margin, sbyte native_hasMatchConstraintWidgets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			bool hasMatchConstraintWidgets = native_hasMatchConstraintWidgets != 0;
			linearSystem.AddGreaterBarrier(a, b, margin, hasMatchConstraintWidgets);
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

	[Register("addGreaterBarrier", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IZ)V", "GetAddGreaterBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZHandler")]
	public unsafe virtual void AddGreaterBarrier(SolverVariable? a, SolverVariable? b, int margin, bool hasMatchConstraintWidgets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(hasMatchConstraintWidgets ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addGreaterBarrier.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetAddGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler()
	{
		return new _JniMarshal_PPLLII_V(n_AddGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II(nint jnienv, nint native__this, nint native_a, nint native_b, int margin, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddGreaterThan(a, b, margin, strength);
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

	[Register("addGreaterThan", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", "GetAddGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler")]
	public unsafe virtual void AddGreaterThan(SolverVariable? a, SolverVariable? b, int margin, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(strength);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addGreaterThan.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetAddLowerBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZHandler()
	{
		return new _JniMarshal_PPLLIB_V(n_AddLowerBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddLowerBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZ(nint jnienv, nint native__this, nint native_a, nint native_b, int margin, sbyte native_hasMatchConstraintWidgets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			bool hasMatchConstraintWidgets = native_hasMatchConstraintWidgets != 0;
			linearSystem.AddLowerBarrier(a, b, margin, hasMatchConstraintWidgets);
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

	[Register("addLowerBarrier", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IZ)V", "GetAddLowerBarrier_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IZHandler")]
	public unsafe virtual void AddLowerBarrier(SolverVariable? a, SolverVariable? b, int margin, bool hasMatchConstraintWidgets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(hasMatchConstraintWidgets ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLowerBarrier.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetAddLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler()
	{
		return new _JniMarshal_PPLLII_V(n_AddLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_II(nint jnienv, nint native__this, nint native_a, nint native_b, int margin, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddLowerThan(a, b, margin, strength);
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

	[Register("addLowerThan", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", "GetAddLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IIHandler")]
	public unsafe virtual void AddLowerThan(SolverVariable? a, SolverVariable? b, int margin, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(strength);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLowerThan.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetAddRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FIHandler()
	{
		return new _JniMarshal_PPLLLLFI_V(n_AddRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FI(nint jnienv, nint native__this, nint native_a, nint native_b, nint native_c, nint native_d, float ratio, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			SolverVariable c = Java.Lang.Object.GetObject<SolverVariable>(native_c, JniHandleOwnership.DoNotTransfer);
			SolverVariable d = Java.Lang.Object.GetObject<SolverVariable>(native_d, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddRatio(a, b, c, d, ratio, strength);
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

	[Register("addRatio", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;FI)V", "GetAddRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FIHandler")]
	public unsafe virtual void AddRatio(SolverVariable? a, SolverVariable? b, SolverVariable? c, SolverVariable? d, float ratio, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(ratio);
			ptr[5] = new JniArgumentValue(strength);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addRatio.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;FI)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
			GC.KeepAlive(c);
			GC.KeepAlive(d);
		}
	}

	private static Delegate GetAddSynonym_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_AddSynonym_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddSynonym_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_a, nint native_b, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddSynonym(a, b, margin);
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

	[Register("addSynonym", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)V", "GetAddSynonym_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual void AddSynonym(SolverVariable? a, SolverVariable? b, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addSynonym.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	private static Delegate GetCreateErrorVariable_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_CreateErrorVariable_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateErrorVariable_ILjava_lang_String_(nint jnienv, nint native__this, int strength, nint native_prefix)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.CreateErrorVariable(strength, prefix));
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

	[Register("createErrorVariable", "(ILjava/lang/String;)Landroidx/constraintlayout/core/SolverVariable;", "GetCreateErrorVariable_ILjava_lang_String_Handler")]
	public unsafe virtual SolverVariable? CreateErrorVariable(int strength, string? prefix)
	{
		nint num = JNIEnv.NewString(prefix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(strength);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createErrorVariable.(ILjava/lang/String;)Landroidx/constraintlayout/core/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetCreateExtraVariableHandler()
	{
		return new global::_JniMarshal_PP_L(n_CreateExtraVariable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateExtraVariable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateExtraVariable());
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

	[Register("createExtraVariable", "()Landroidx/constraintlayout/core/SolverVariable;", "GetCreateExtraVariableHandler")]
	public unsafe virtual SolverVariable? CreateExtraVariable()
	{
		return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createExtraVariable.()Landroidx/constraintlayout/core/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCreateObjectVariable_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateObjectVariable_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateObjectVariable_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object anchor = Java.Lang.Object.GetObject<Java.Lang.Object>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.CreateObjectVariable(anchor));
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

	[Register("createObjectVariable", "(Ljava/lang/Object;)Landroidx/constraintlayout/core/SolverVariable;", "GetCreateObjectVariable_Ljava_lang_Object_Handler")]
	public unsafe virtual SolverVariable? CreateObjectVariable(Java.Lang.Object? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createObjectVariable.(Ljava/lang/Object;)Landroidx/constraintlayout/core/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetCreateRowHandler()
	{
		return new global::_JniMarshal_PP_L(n_CreateRow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateRow());
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

	[Register("createRow", "()Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowHandler")]
	public unsafe virtual ArrayRow? CreateRow()
	{
		return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRow.()Landroidx/constraintlayout/core/ArrayRow;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("createRowDimensionPercent", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", "")]
	public unsafe static ArrayRow? CreateRowDimensionPercent(LinearSystem? linearSystem, SolverVariable? variableA, SolverVariable? variableC, float percent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(linearSystem?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(variableC?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(percent);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.StaticMethods.InvokeObjectMethod("createRowDimensionPercent.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(linearSystem);
			GC.KeepAlive(variableA);
			GC.KeepAlive(variableC);
		}
	}

	private static Delegate GetCreateSlackVariableHandler()
	{
		return new global::_JniMarshal_PP_L(n_CreateSlackVariable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateSlackVariable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateSlackVariable());
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

	[Register("createSlackVariable", "()Landroidx/constraintlayout/core/SolverVariable;", "GetCreateSlackVariableHandler")]
	public unsafe virtual SolverVariable? CreateSlackVariable()
	{
		return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSlackVariable.()Landroidx/constraintlayout/core/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDisplayReadableRowsHandler()
	{
		return new global::_JniMarshal_PP_V(n_DisplayReadableRows);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DisplayReadableRows(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayReadableRows();
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

	[Register("displayReadableRows", "()V", "GetDisplayReadableRowsHandler")]
	public unsafe virtual void DisplayReadableRows()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("displayReadableRows.()V", this, null);
	}

	private static Delegate GetDisplayVariablesReadableRowsHandler()
	{
		return new global::_JniMarshal_PP_V(n_DisplayVariablesReadableRows);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DisplayVariablesReadableRows(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayVariablesReadableRows();
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

	[Register("displayVariablesReadableRows", "()V", "GetDisplayVariablesReadableRowsHandler")]
	public unsafe virtual void DisplayVariablesReadableRows()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("displayVariablesReadableRows.()V", this, null);
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
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			linearSystem.FillMetrics(metrics);
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

	private static Delegate GetGetObjectVariableValue_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetObjectVariableValue_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetObjectVariableValue_Ljava_lang_Object_(nint jnienv, nint native__this, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			return linearSystem.GetObjectVariableValue(obj);
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

	[Register("getObjectVariableValue", "(Ljava/lang/Object;)I", "GetGetObjectVariableValue_Ljava_lang_Object_Handler")]
	public unsafe virtual int GetObjectVariableValue(Java.Lang.Object? @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getObjectVariableValue.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@object);
		}
	}

	private static Delegate GetMinimizeHandler()
	{
		return new global::_JniMarshal_PP_V(n_Minimize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Minimize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Minimize();
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

	[Register("minimize", "()V", "GetMinimizeHandler")]
	public unsafe virtual void Minimize()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("minimize.()V", this, null);
	}

	private static Delegate GetRemoveRow_Landroidx_constraintlayout_core_ArrayRow_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveRow_Landroidx_constraintlayout_core_ArrayRow_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveRow_Landroidx_constraintlayout_core_ArrayRow_(nint jnienv, nint native__this, nint native_row)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearSystem? linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ArrayRow row = Java.Lang.Object.GetObject<ArrayRow>(native_row, JniHandleOwnership.DoNotTransfer);
			linearSystem.RemoveRow(row);
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

	[Register("removeRow", "(Landroidx/constraintlayout/core/ArrayRow;)V", "GetRemoveRow_Landroidx_constraintlayout_core_ArrayRow_Handler")]
	public unsafe virtual void RemoveRow(ArrayRow? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeRow.(Landroidx/constraintlayout/core/ArrayRow;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(row);
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
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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
