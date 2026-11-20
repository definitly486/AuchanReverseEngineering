using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Reflect;

[Register("java/lang/reflect/AccessibleObject", DoNotGenerateAcw = true)]
public class AccessibleObject : Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/reflect/AccessibleObject", typeof(AccessibleObject));

	private static Delegate? cb_setAccessible_SetAccessible_Z_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool Accessible
	{
		[Register("setAccessible", "(Z)V", "GetSetAccessible_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccessible.(Z)V", this, ptr);
		}
	}

	protected AccessibleObject(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetAccessible_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetAccessible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAccessible_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibleObject? accessibleObject = Object.GetObject<AccessibleObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool accessible = native_flag != 0;
			accessibleObject.Accessible = accessible;
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
