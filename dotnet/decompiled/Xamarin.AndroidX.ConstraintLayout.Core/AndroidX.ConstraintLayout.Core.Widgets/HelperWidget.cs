using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/HelperWidget", DoNotGenerateAcw = true)]
public class HelperWidget : ConstraintWidget, IHelper, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/HelperWidget", typeof(HelperWidget));

	private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_addDependents_AddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup__V;

	private static Delegate? cb_findGroupInDependents_FindGroupInDependents_I_I;

	private static Delegate? cb_removeAllIds_RemoveAllIds_V;

	private static Delegate? cb_updateConstraints_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer__V;

	[Register("mWidgets")]
	public IList<ConstraintWidget>? MWidgets
	{
		get
		{
			return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mWidgets.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mWidgets.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mWidgetsCount")]
	public int MWidgetsCount
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mWidgetsCount.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mWidgetsCount.I", this, value);
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

	protected HelperWidget(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe HelperWidget()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HelperWidget? helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			helperWidget.Add(widget);
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

	[Register("add", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual void Add(ConstraintWidget? widget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("add.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetAddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_AddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_(nint jnienv, nint native__this, nint native_dependencyLists, int orientation, nint native_group)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HelperWidget? helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> dependencyLists = JavaList<WidgetGroup>.FromJniHandle(native_dependencyLists, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			helperWidget.AddDependents(dependencyLists, orientation, widgetGroup);
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

	[Register("addDependents", "(Ljava/util/ArrayList;ILandroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", "GetAddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_core_widgets_analyzer_WidgetGroup_Handler")]
	public unsafe virtual void AddDependents(IList<WidgetGroup>? dependencyLists, int orientation, WidgetGroup? group)
	{
		nint num = JavaList<WidgetGroup>.ToLocalJniHandle(dependencyLists);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(orientation);
			ptr[2] = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addDependents.(Ljava/util/ArrayList;ILandroidx/constraintlayout/core/widgets/analyzer/WidgetGroup;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(dependencyLists);
			GC.KeepAlive(group);
		}
	}

	private static Delegate GetFindGroupInDependents_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_FindGroupInDependents_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindGroupInDependents_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindGroupInDependents(orientation);
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

	[Register("findGroupInDependents", "(I)I", "GetFindGroupInDependents_IHandler")]
	public unsafe virtual int FindGroupInDependents(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("findGroupInDependents.(I)I", this, ptr);
	}

	private static Delegate GetRemoveAllIdsHandler()
	{
		return new global::_JniMarshal_PP_V(n_RemoveAllIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllIds();
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

	[Register("removeAllIds", "()V", "GetRemoveAllIdsHandler")]
	public unsafe virtual void RemoveAllIds()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllIds.()V", this, null);
	}

	private static Delegate GetUpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			HelperWidget? helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			helperWidget.UpdateConstraints(container);
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

	[Register("updateConstraints", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", "GetUpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler")]
	public unsafe virtual void UpdateConstraints(ConstraintWidgetContainer? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateConstraints.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
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
