using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Runtime", DoNotGenerateAcw = true)]
public class Runtime : Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Runtime", typeof(Runtime));

	private static Delegate? cb_exit_Exit_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Runtime(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetExit_IHandler()
	{
		return new _JniMarshal_PPI_V(n_Exit_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Exit_I(nint jnienv, nint native__this, int status)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Object.GetObject<Runtime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exit(status);
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

	public unsafe virtual void Exit(int status)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(status);
		_members.InstanceMethods.InvokeVirtualVoidMethod("exit.(I)V", this, ptr);
	}

	public unsafe static Runtime? GetRuntime()
	{
		return Object.GetObject<Runtime>(_members.StaticMethods.InvokeObjectMethod("getRuntime.()Ljava/lang/Runtime;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
