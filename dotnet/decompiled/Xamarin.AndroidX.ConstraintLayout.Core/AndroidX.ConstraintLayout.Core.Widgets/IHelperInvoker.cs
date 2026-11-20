using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/Helper", DoNotGenerateAcw = true)]
internal class IHelperInvoker : Java.Lang.Object, IHelper, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_constraintlayout_core_widgets_Helper = new XAPeerMembers("androidx/constraintlayout/core/widgets/Helper", typeof(IHelperInvoker));

	private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_removeAllIds_RemoveAllIds_V;

	private static Delegate? cb_updateConstraints_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer__V;

	private static nint java_class_ref => _members_androidx_constraintlayout_core_widgets_Helper.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_widgets_Helper;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_constraintlayout_core_widgets_Helper.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_constraintlayout_core_widgets_Helper.ManagedPeerType;

	public IHelperInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IHelper? helper = Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget p = Java.Lang.Object.GetObject<ConstraintWidget>(native_p0, JniHandleOwnership.DoNotTransfer);
			helper.Add(p);
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

	public unsafe void Add(ConstraintWidget? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_constraintlayout_core_widgets_Helper.InstanceMethods.InvokeAbstractVoidMethod("add.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
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
			Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllIds();
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

	public unsafe void RemoveAllIds()
	{
		_members_androidx_constraintlayout_core_widgets_Helper.InstanceMethods.InvokeAbstractVoidMethod("removeAllIds.()V", this, null);
	}

	private static Delegate GetUpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IHelper? helper = Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer p = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_p0, JniHandleOwnership.DoNotTransfer);
			helper.UpdateConstraints(p);
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

	public unsafe void UpdateConstraints(ConstraintWidgetContainer? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_constraintlayout_core_widgets_Helper.InstanceMethods.InvokeAbstractVoidMethod("updateConstraints.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
