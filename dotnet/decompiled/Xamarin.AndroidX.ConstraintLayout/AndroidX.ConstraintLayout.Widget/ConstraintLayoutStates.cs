using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintLayoutStates", DoNotGenerateAcw = true)]
public class ConstraintLayoutStates : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayoutStates", typeof(ConstraintLayoutStates));

	private static Delegate? cb_needsToChange_NeedsToChange_IFF_Z;

	private static Delegate? cb_setOnConstraintsChanged_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener__V;

	private static Delegate? cb_updateConstraints_UpdateConstraints_IFF_V;

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

	protected ConstraintLayoutStates(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetNeedsToChange_IFFHandler()
	{
		return new _JniMarshal_PPIFF_B(n_NeedsToChange_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_NeedsToChange_IFF(nint jnienv, nint native__this, int id, float width, float height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NeedsToChange(id, width, height) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("needsToChange", "(IFF)Z", "GetNeedsToChange_IFFHandler")]
	public unsafe virtual bool NeedsToChange(int id, float width, float height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(width);
		ptr[2] = new JniArgumentValue(height);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("needsToChange.(IFF)Z", this, ptr);
	}

	private static Delegate GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_(nint jnienv, nint native__this, nint native_constraintsChangedListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayoutStates? constraintLayoutStates = Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintsChangedListener onConstraintsChanged = Java.Lang.Object.GetObject<ConstraintsChangedListener>(native_constraintsChangedListener, JniHandleOwnership.DoNotTransfer);
			constraintLayoutStates.SetOnConstraintsChanged(onConstraintsChanged);
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

	[Register("setOnConstraintsChanged", "(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", "GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler")]
	public unsafe virtual void SetOnConstraintsChanged(ConstraintsChangedListener? constraintsChangedListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintsChangedListener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnConstraintsChanged.(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintsChangedListener);
		}
	}

	private static Delegate GetUpdateConstraints_IFFHandler()
	{
		return new _JniMarshal_PPIFF_V(n_UpdateConstraints_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateConstraints_IFF(nint jnienv, nint native__this, int id, float width, float height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateConstraints(id, width, height);
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

	[Register("updateConstraints", "(IFF)V", "GetUpdateConstraints_IFFHandler")]
	public unsafe virtual void UpdateConstraints(int id, float width, float height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(width);
		ptr[2] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateConstraints.(IFF)V", this, ptr);
	}
}
