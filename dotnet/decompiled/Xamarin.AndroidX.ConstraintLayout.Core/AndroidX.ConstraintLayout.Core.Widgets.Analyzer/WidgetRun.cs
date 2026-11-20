using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/WidgetRun", DoNotGenerateAcw = true)]
public abstract class WidgetRun : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType", DoNotGenerateAcw = true)]
	public sealed class RunType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType", typeof(RunType));

		[Register("CENTER")]
		public static RunType? Center => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("CENTER.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("END")]
		public static RunType? End => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("END.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static RunType? None => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("NONE.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("START")]
		public static RunType? Start => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("START.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal RunType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Ljava/lang/Enum;", "")]
		public unsafe static Java.Lang.Enum? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Java.Lang.Enum>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Ljava/lang/Enum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;", "")]
		public unsafe static RunType[]? Values()
		{
			return (RunType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(RunType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/WidgetRun", typeof(WidgetRun));

	private static Delegate? cb_isCenterConnection_IsCenterConnection_Z;

	private static Delegate? cb_isDimensionResolved_IsDimensionResolved_Z;

	private static Delegate? cb_isResolved_IsResolved_Z;

	private static Delegate? cb_getWrapDimension_GetWrapDimension_J;

	private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	private static Delegate? cb_updateRunCenter_UpdateRunCenter_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I_V;

	private static Delegate? cb_updateRunEnd_UpdateRunEnd_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	private static Delegate? cb_updateRunStart_UpdateRunStart_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	private static Delegate? cb_wrapSize_WrapSize_I_J;

	[Register("end")]
	public DependencyNode? End
	{
		get
		{
			return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("end.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("end.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("matchConstraintsType")]
	public int MatchConstraintsType
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("matchConstraintsType.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("matchConstraintsType.I", this, value);
		}
	}

	[Register("mDimensionBehavior")]
	protected ConstraintWidget.DimensionBehaviour? MDimensionBehavior
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("mDimensionBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mDimensionBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mRunType")]
	protected RunType? MRunType
	{
		get
		{
			return Java.Lang.Object.GetObject<RunType>(_members.InstanceFields.GetObjectValue("mRunType.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mRunType.Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun$RunType;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("orientation")]
	public int Orientation
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("orientation.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("orientation.I", this, value);
		}
	}

	[Register("start")]
	public DependencyNode? Start
	{
		get
		{
			return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("start.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("start.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this, new JniObjectReference(num));
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
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool IsCenterConnection
	{
		[Register("isCenterConnection", "()Z", "GetIsCenterConnectionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCenterConnection.()Z", this, null);
		}
	}

	public unsafe virtual bool IsDimensionResolved
	{
		[Register("isDimensionResolved", "()Z", "GetIsDimensionResolvedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDimensionResolved.()Z", this, null);
		}
	}

	public unsafe virtual bool IsResolved
	{
		[Register("isResolved", "()Z", "GetIsResolvedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolved.()Z", this, null);
		}
	}

	public unsafe virtual long WrapDimension
	{
		[Register("getWrapDimension", "()J", "GetGetWrapDimensionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getWrapDimension.()J", this, null);
		}
	}

	protected WidgetRun(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "")]
	public unsafe WidgetRun(ConstraintWidget? widget)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetIsCenterConnectionHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCenterConnection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCenterConnection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCenterConnection ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsDimensionResolvedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDimensionResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDimensionResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDimensionResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsResolvedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetWrapDimensionHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetWrapDimension);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetWrapDimension(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapDimension;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addTarget", "(Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;I)V", "")]
	protected unsafe void AddTarget(DependencyNode? node, DependencyNode? target, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(node?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addTarget.(Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(node);
			GC.KeepAlive(target);
		}
	}

	[Register("getLimitedDimension", "(II)I", "")]
	protected unsafe int GetLimitedDimension(int dimension, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dimension);
		ptr[1] = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLimitedDimension.(II)I", this, ptr);
	}

	[Register("getTarget", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", "")]
	protected unsafe DependencyNode? GetTarget(ConstraintAnchor? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTarget.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	[Register("getTarget", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", "")]
	protected unsafe DependencyNode? GetTarget(ConstraintAnchor? anchor, int orientation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(orientation);
			return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTarget.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetUpdate_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_dependency)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetRun? widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.Update(dependency);
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
	public unsafe virtual void Update(IDependency? dependency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dependency);
		}
	}

	private static Delegate GetUpdateRunCenter_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler()
	{
		return new _JniMarshal_PPLLLI_V(n_UpdateRunCenter_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateRunCenter_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I(nint jnienv, nint native__this, nint native_dependency, nint native_startAnchor, nint native_endAnchor, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetRun? widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor startAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_startAnchor, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor endAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_endAnchor, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunCenter(dependency, startAnchor, endAnchor, orientation);
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

	[Register("updateRunCenter", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)V", "GetUpdateRunCenter_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler")]
	protected unsafe virtual void UpdateRunCenter(IDependency? dependency, ConstraintAnchor? startAnchor, ConstraintAnchor? endAnchor, int orientation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
			ptr[1] = new JniArgumentValue(startAnchor?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(endAnchor?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(orientation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunCenter.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dependency);
			GC.KeepAlive(startAnchor);
			GC.KeepAlive(endAnchor);
		}
	}

	private static Delegate GetUpdateRunEnd_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateRunEnd_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateRunEnd_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_dependency)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetRun? widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunEnd(dependency);
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

	[Register("updateRunEnd", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", "GetUpdateRunEnd_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler")]
	protected unsafe virtual void UpdateRunEnd(IDependency? dependency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunEnd.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dependency);
		}
	}

	private static Delegate GetUpdateRunStart_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateRunStart_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateRunStart_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_dependency)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetRun? widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunStart(dependency);
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

	[Register("updateRunStart", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", "GetUpdateRunStart_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler")]
	protected unsafe virtual void UpdateRunStart(IDependency? dependency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunStart.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dependency);
		}
	}

	private static Delegate GetWrapSize_IHandler()
	{
		return new global::_JniMarshal_PPI_J(n_WrapSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_WrapSize_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapSize(direction);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("wrapSize", "(I)J", "GetWrapSize_IHandler")]
	public unsafe virtual long WrapSize(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualInt64Method("wrapSize.(I)J", this, ptr);
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
