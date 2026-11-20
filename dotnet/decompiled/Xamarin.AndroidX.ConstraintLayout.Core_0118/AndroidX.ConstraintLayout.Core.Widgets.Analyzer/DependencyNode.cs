using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/DependencyNode", DoNotGenerateAcw = true)]
public class DependencyNode : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/DependencyNode", typeof(DependencyNode));

	private static Delegate? cb_addDependency_AddDependency_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_name_Name_Ljava_lang_String_;

	private static Delegate? cb_resolve_Resolve_I_V;

	private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	[Register("delegateToWidgetRun")]
	public bool DelegateToWidgetRun
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("delegateToWidgetRun.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("delegateToWidgetRun.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("readyToSolve")]
	public bool ReadyToSolve
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("readyToSolve.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("readyToSolve.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("resolved")]
	public bool Resolved
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("resolved.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("resolved.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("updateDelegate")]
	public IDependency? UpdateDelegate
	{
		get
		{
			return Java.Lang.Object.GetObject<IDependency>(_members.InstanceFields.GetObjectValue("updateDelegate.Landroidx/constraintlayout/core/widgets/analyzer/Dependency;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("updateDelegate.Landroidx/constraintlayout/core/widgets/analyzer/Dependency;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("value")]
	public int Value
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("value.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("value.I", this, value);
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

	protected DependencyNode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;)V", "")]
	public unsafe DependencyNode(WidgetRun? run)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(run?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(run);
		}
	}

	private static Delegate GetAddDependency_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddDependency_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddDependency_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_dependency)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DependencyNode? dependencyNode = Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			dependencyNode.AddDependency(dependency);
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

	[Register("addDependency", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", "GetAddDependency_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler")]
	public unsafe virtual void AddDependency(IDependency? dependency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addDependency.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dependency);
		}
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
			Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	private static Delegate GetNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_Name);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Name(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name());
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

	[Register("name", "()Ljava/lang/String;", "GetNameHandler")]
	public unsafe virtual string? Name()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("name.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetResolve_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_Resolve_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Resolve_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resolve(value);
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

	[Register("resolve", "(I)V", "GetResolve_IHandler")]
	public unsafe virtual void Resolve(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("resolve.(I)V", this, ptr);
	}

	private static Delegate GetUpdate_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_node)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DependencyNode? dependencyNode = Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency node = Java.Lang.Object.GetObject<IDependency>(native_node, JniHandleOwnership.DoNotTransfer);
			dependencyNode.Update(node);
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

	[Register("update", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", "GetUpdate_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler")]
	public unsafe virtual void Update(IDependency? node)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((node == null) ? IntPtr.Zero : ((Java.Lang.Object)node).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(node);
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
