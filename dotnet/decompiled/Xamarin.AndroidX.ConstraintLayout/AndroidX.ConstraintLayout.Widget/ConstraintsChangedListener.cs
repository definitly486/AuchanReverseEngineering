using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintsChangedListener", DoNotGenerateAcw = true)]
public abstract class ConstraintsChangedListener : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintsChangedListener", typeof(ConstraintsChangedListener));

	private static Delegate? cb_postLayoutChange_PostLayoutChange_II_V;

	private static Delegate? cb_preLayoutChange_PreLayoutChange_II_V;

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

	protected ConstraintsChangedListener(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ConstraintsChangedListener()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetPostLayoutChange_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_PostLayoutChange_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PostLayoutChange_II(nint jnienv, nint native__this, int stateId, int constraintId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostLayoutChange(stateId, constraintId);
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

	[Register("postLayoutChange", "(II)V", "GetPostLayoutChange_IIHandler")]
	public unsafe virtual void PostLayoutChange(int stateId, int constraintId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(stateId);
		ptr[1] = new JniArgumentValue(constraintId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("postLayoutChange.(II)V", this, ptr);
	}

	private static Delegate GetPreLayoutChange_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_PreLayoutChange_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PreLayoutChange_II(nint jnienv, nint native__this, int stateId, int constraintId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreLayoutChange(stateId, constraintId);
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

	[Register("preLayoutChange", "(II)V", "GetPreLayoutChange_IIHandler")]
	public unsafe virtual void PreLayoutChange(int stateId, int constraintId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(stateId);
		ptr[1] = new JniArgumentValue(constraintId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("preLayoutChange.(II)V", this, ptr);
	}
}
