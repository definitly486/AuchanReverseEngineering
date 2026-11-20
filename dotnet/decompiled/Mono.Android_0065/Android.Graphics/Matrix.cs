using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Matrix", DoNotGenerateAcw = true)]
public class Matrix : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Matrix", typeof(Matrix));

	private static Delegate? cb_setTranslate_SetTranslate_FF_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Matrix(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Matrix()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetSetTranslate_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_SetTranslate_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslate_FF(nint jnienv, nint native__this, float dx, float dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Matrix>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslate(dx, dy);
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

	public unsafe virtual void SetTranslate(float dx, float dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslate.(FF)V", this, ptr);
	}
}
