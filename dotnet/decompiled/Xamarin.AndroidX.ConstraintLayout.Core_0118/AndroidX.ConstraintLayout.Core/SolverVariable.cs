using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core;

[Register("androidx/constraintlayout/core/SolverVariable", DoNotGenerateAcw = true)]
public class SolverVariable : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/constraintlayout/core/SolverVariable$Type", DoNotGenerateAcw = true)]
	public sealed class Type : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/SolverVariable$Type", typeof(Type));

		[Register("CONSTANT")]
		public static Type? Constant => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CONSTANT.Landroidx/constraintlayout/core/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ERROR")]
		public static Type? Error => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("ERROR.Landroidx/constraintlayout/core/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SLACK")]
		public static Type? Slack => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("SLACK.Landroidx/constraintlayout/core/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static Type? Unknown => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/constraintlayout/core/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNRESTRICTED")]
		public static Type? Unrestricted => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("UNRESTRICTED.Landroidx/constraintlayout/core/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

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

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/core/SolverVariable$Type;", "")]
		public unsafe static Type? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/core/SolverVariable$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/core/SolverVariable$Type;", "")]
		public unsafe static Type[]? Values()
		{
			return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/core/SolverVariable$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/SolverVariable", typeof(SolverVariable));

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_setName_SetName_Ljava_lang_String__V;

	private static Delegate? cb_compareTo_CompareTo_Landroidx_constraintlayout_core_SolverVariable__I;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_setFinalValue_SetFinalValue_Landroidx_constraintlayout_core_LinearSystem_F_V;

	private static Delegate? cb_setSynonym_SetSynonym_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_F_V;

	private static Delegate? cb_setType_SetType_Landroidx_constraintlayout_core_SolverVariable_Type_Ljava_lang_String__V;

	[Register("computedValue")]
	public float ComputedValue
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("computedValue.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("computedValue.F", this, value);
		}
	}

	[Register("id")]
	public int Id
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("id.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("id.I", this, value);
		}
	}

	[Register("inGoal")]
	public bool InGoal
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("inGoal.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("inGoal.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("isFinalValue")]
	public bool IsFinalValue
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("isFinalValue.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("isFinalValue.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("strength")]
	public int Strength
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("strength.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("strength.I", this, value);
		}
	}

	[Register("usageInRowCount")]
	public int UsageInRowCount
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("usageInRowCount.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("usageInRowCount.I", this, value);
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

	public unsafe virtual string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setName", "(Ljava/lang/String;)V", "GetSetName_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	protected SolverVariable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/SolverVariable$Type;Ljava/lang/String;)V", "")]
	public unsafe SolverVariable(Type? type, string? prefix)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(prefix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/SolverVariable$Type;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/SolverVariable$Type;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(type);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/core/SolverVariable$Type;)V", "")]
	public unsafe SolverVariable(string? name, Type? type)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/SolverVariable$Type;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/SolverVariable$Type;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetGetNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetSetName_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetName_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SolverVariable? solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			solverVariable.Name = name;
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

	[Register("addToRow", "(Landroidx/constraintlayout/core/ArrayRow;)V", "")]
	public unsafe void AddToRow(ArrayRow? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addToRow.(Landroidx/constraintlayout/core/ArrayRow;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(row);
		}
	}

	private static Delegate GetCompareTo_Landroidx_constraintlayout_core_SolverVariable_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_CompareTo_Landroidx_constraintlayout_core_SolverVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompareTo_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_v)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SolverVariable? solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable v = Java.Lang.Object.GetObject<SolverVariable>(native_v, JniHandleOwnership.DoNotTransfer);
			return solverVariable.CompareTo(v);
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

	[Register("compareTo", "(Landroidx/constraintlayout/core/SolverVariable;)I", "GetCompareTo_Landroidx_constraintlayout_core_SolverVariable_Handler")]
	public unsafe virtual int CompareTo(Java.Lang.Object? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compareTo.(Landroidx/constraintlayout/core/SolverVariable;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("removeFromRow", "(Landroidx/constraintlayout/core/ArrayRow;)V", "")]
	public unsafe void RemoveFromRow(ArrayRow? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeFromRow.(Landroidx/constraintlayout/core/ArrayRow;)V", this, ptr);
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
			Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

	private static Delegate GetSetFinalValue_Landroidx_constraintlayout_core_LinearSystem_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_SetFinalValue_Landroidx_constraintlayout_core_LinearSystem_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalValue_Landroidx_constraintlayout_core_LinearSystem_F(nint jnienv, nint native__this, nint native_system, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SolverVariable? solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetFinalValue(system, value);
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

	[Register("setFinalValue", "(Landroidx/constraintlayout/core/LinearSystem;F)V", "GetSetFinalValue_Landroidx_constraintlayout_core_LinearSystem_FHandler")]
	public unsafe virtual void SetFinalValue(LinearSystem? system, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(Landroidx/constraintlayout/core/LinearSystem;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetSetSynonym_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_FHandler()
	{
		return new _JniMarshal_PPLLF_V(n_SetSynonym_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSynonym_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_F(nint jnienv, nint native__this, nint native_system, nint native_synonymVariable, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SolverVariable? solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable synonymVariable = Java.Lang.Object.GetObject<SolverVariable>(native_synonymVariable, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetSynonym(system, synonymVariable, value);
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

	[Register("setSynonym", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;F)V", "GetSetSynonym_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_FHandler")]
	public unsafe virtual void SetSynonym(LinearSystem? system, SolverVariable? synonymVariable, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(synonymVariable?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSynonym.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
			GC.KeepAlive(synonymVariable);
		}
	}

	private static Delegate GetSetType_Landroidx_constraintlayout_core_SolverVariable_Type_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetType_Landroidx_constraintlayout_core_SolverVariable_Type_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetType_Landroidx_constraintlayout_core_SolverVariable_Type_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type, nint native_prefix)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SolverVariable? solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Type type = Java.Lang.Object.GetObject<Type>(native_type, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetType(type, prefix);
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

	[Register("setType", "(Landroidx/constraintlayout/core/SolverVariable$Type;Ljava/lang/String;)V", "GetSetType_Landroidx_constraintlayout_core_SolverVariable_Type_Ljava_lang_String_Handler")]
	public unsafe virtual void SetType(Type? type, string? prefix)
	{
		nint num = JNIEnv.NewString(prefix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Landroidx/constraintlayout/core/SolverVariable$Type;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(type);
		}
	}

	[Register("updateReferencesWithNewDefinition", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/ArrayRow;)V", "")]
	public unsafe void UpdateReferencesWithNewDefinition(LinearSystem? system, ArrayRow? definition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(definition?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("updateReferencesWithNewDefinition.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/ArrayRow;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
			GC.KeepAlive(definition);
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
