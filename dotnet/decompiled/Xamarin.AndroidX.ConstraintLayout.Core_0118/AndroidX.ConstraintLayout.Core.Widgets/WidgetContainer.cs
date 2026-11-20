using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/WidgetContainer", DoNotGenerateAcw = true)]
public class WidgetContainer : ConstraintWidget
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/WidgetContainer", typeof(WidgetContainer));

	private static Delegate? cb_getChildren_GetChildren_Ljava_util_ArrayList_;

	private static Delegate? cb_getRootConstraintContainer_GetRootConstraintContainer_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_;

	private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_add_Add_arrayLandroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_layout_Layout_V;

	private static Delegate? cb_remove_Remove_Landroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_removeAllChildren_RemoveAllChildren_V;

	[Register("mChildren")]
	public IList? MChildren
	{
		get
		{
			return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("mChildren.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mChildren.Ljava/util/ArrayList;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
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

	public unsafe virtual IList<ConstraintWidget>? Children
	{
		[Register("getChildren", "()Ljava/util/ArrayList;", "GetGetChildrenHandler")]
		get
		{
			return JavaList<ConstraintWidget>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildren.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ConstraintWidgetContainer? RootConstraintContainer
	{
		[Register("getRootConstraintContainer", "()Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;", "GetGetRootConstraintContainerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRootConstraintContainer.()Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected WidgetContainer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe WidgetContainer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe WidgetContainer(int width, int height)
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
	public unsafe WidgetContainer(int x, int y, int width, int height)
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

	private static Delegate GetGetChildrenHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetChildren);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChildren(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<ConstraintWidget>.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Children);
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

	private static Delegate GetGetRootConstraintContainerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRootConstraintContainer);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRootConstraintContainer(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootConstraintContainer);
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
			WidgetContainer? widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			widgetContainer.Add(widget);
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

	private static Delegate GetAdd_arrayLandroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Add_arrayLandroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_arrayLandroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widgets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetContainer? widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget[] array = (ConstraintWidget[])JNIEnv.GetArray(native_widgets, JniHandleOwnership.DoNotTransfer, typeof(ConstraintWidget));
			widgetContainer.Add(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_widgets);
			}
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

	[Register("add", "([Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "GetAdd_arrayLandroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual void Add(params ConstraintWidget[]? widgets)
	{
		nint num = JNIEnv.NewArray(widgets);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("add.([Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			if (widgets != null)
			{
				JNIEnv.CopyArray(num, widgets);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(widgets);
		}
	}

	private static Delegate GetLayoutHandler()
	{
		return new global::_JniMarshal_PP_V(n_Layout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Layout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Layout();
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

	[Register("layout", "()V", "GetLayoutHandler")]
	public unsafe virtual void Layout()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("layout.()V", this, null);
	}

	private static Delegate GetRemove_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Remove_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Remove_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetContainer? widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			widgetContainer.Remove(widget);
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

	[Register("remove", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "GetRemove_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual void Remove(ConstraintWidget? widget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetRemoveAllChildrenHandler()
	{
		return new global::_JniMarshal_PP_V(n_RemoveAllChildren);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllChildren(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllChildren();
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

	[Register("removeAllChildren", "()V", "GetRemoveAllChildrenHandler")]
	public unsafe virtual void RemoveAllChildren()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllChildren.()V", this, null);
	}
}
