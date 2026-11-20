using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/WidgetGroup", DoNotGenerateAcw = true)]
public class WidgetGroup : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/WidgetGroup", typeof(WidgetGroup));

	private static Delegate? cb_isAuthoritative_IsAuthoritative_Z;

	private static Delegate? cb_setAuthoritative_SetAuthoritative_Z_V;

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_getOrientation_GetOrientation_I;

	private static Delegate? cb_setOrientation_SetOrientation_I_V;

	private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Z;

	private static Delegate? cb_apply_Apply_V;

	private static Delegate? cb_cleanup_Cleanup_Ljava_util_ArrayList__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_intersectWith_IntersectWith_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup__Z;

	private static Delegate? cb_measureWrap_MeasureWrap_Landroidx_constraintlayout_core_LinearSystem_I_I;

	private static Delegate? cb_moveTo_MoveTo_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup__V;

	private static Delegate? cb_size_Size_I;

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

	public unsafe virtual bool Authoritative
	{
		[Register("isAuthoritative", "()Z", "GetIsAuthoritativeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAuthoritative.()Z", this, null);
		}
		[Register("setAuthoritative", "(Z)V", "GetSetAuthoritative_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAuthoritative.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
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

	protected WidgetGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe WidgetGroup(int orientation)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetIsAuthoritativeHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAuthoritative);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAuthoritative(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Authoritative ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAuthoritative_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAuthoritative_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAuthoritative_Z(nint jnienv, nint native__this, sbyte native_isAuthoritative)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool authoritative = native_isAuthoritative != 0;
			widgetGroup.Authoritative = authoritative;
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

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
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
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
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

	private static Delegate GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.Add(widget) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("add", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Z", "GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual bool Add(ConstraintWidget? widget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("add.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetApplyHandler()
	{
		return new global::_JniMarshal_PP_V(n_Apply);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Apply(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Apply();
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

	[Register("apply", "()V", "GetApplyHandler")]
	public unsafe virtual void Apply()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("apply.()V", this, null);
	}

	private static Delegate GetCleanup_Ljava_util_ArrayList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Cleanup_Ljava_util_ArrayList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cleanup_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_dependencyLists)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> dependencyLists = JavaList<WidgetGroup>.FromJniHandle(native_dependencyLists, JniHandleOwnership.DoNotTransfer);
			widgetGroup.Cleanup(dependencyLists);
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

	[Register("cleanup", "(Ljava/util/ArrayList;)V", "GetCleanup_Ljava_util_ArrayList_Handler")]
	public unsafe virtual void Cleanup(IList<WidgetGroup>? dependencyLists)
	{
		nint num = JavaList<WidgetGroup>.ToLocalJniHandle(dependencyLists);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("cleanup.(Ljava/util/ArrayList;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(dependencyLists);
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
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	private static Delegate GetIntersectWith_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IntersectWith_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IntersectWith_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_(nint jnienv, nint native__this, nint native_group)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup2 = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.IntersectWith(widgetGroup2) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("intersectWith", "(Landroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)Z", "GetIntersectWith_Landroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler")]
	public unsafe virtual bool IntersectWith(WidgetGroup? group)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("intersectWith.(Landroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(group);
		}
	}

	private static Delegate GetMeasureWrap_Landroidx_constraintlayout_core_LinearSystem_IHandler()
	{
		return new global::_JniMarshal_PPLI_I(n_MeasureWrap_Landroidx_constraintlayout_core_LinearSystem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_MeasureWrap_Landroidx_constraintlayout_core_LinearSystem_I(nint jnienv, nint native__this, nint native_system, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.MeasureWrap(system, orientation);
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

	[Register("measureWrap", "(Landroidx/constraintlayout/core/LinearSystem;I)I", "GetMeasureWrap_Landroidx_constraintlayout_core_LinearSystem_IHandler")]
	public unsafe virtual int MeasureWrap(LinearSystem? system, int orientation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualInt32Method("measureWrap.(Landroidx/constraintlayout/core/LinearSystem;I)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetMoveTo_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_MoveTo_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MoveTo_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_(nint jnienv, nint native__this, int orientation, nint native_widgetGroup)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetGroup? widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup2 = Java.Lang.Object.GetObject<WidgetGroup>(native_widgetGroup, JniHandleOwnership.DoNotTransfer);
			widgetGroup.MoveTo(orientation, widgetGroup2);
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

	[Register("moveTo", "(ILandroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", "GetMoveTo_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler")]
	public unsafe virtual void MoveTo(int orientation, WidgetGroup? widgetGroup)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(orientation);
			ptr[1] = new JniArgumentValue(widgetGroup?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("moveTo.(ILandroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widgetGroup);
		}
	}

	private static Delegate GetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe virtual int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}
}
