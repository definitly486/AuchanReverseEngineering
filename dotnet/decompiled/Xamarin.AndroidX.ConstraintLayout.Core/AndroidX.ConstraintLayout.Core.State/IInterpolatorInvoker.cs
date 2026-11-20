using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/Interpolator", DoNotGenerateAcw = true)]
internal class IInterpolatorInvoker : Java.Lang.Object, IInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_constraintlayout_core_state_Interpolator = new XAPeerMembers("androidx/constraintlayout/core/state/Interpolator", typeof(IInterpolatorInvoker));

	private static Delegate? cb_getInterpolation_GetInterpolation_F_F;

	private static nint java_class_ref => _members_androidx_constraintlayout_core_state_Interpolator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_state_Interpolator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_constraintlayout_core_state_Interpolator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_constraintlayout_core_state_Interpolator.ManagedPeerType;

	public IInterpolatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetInterpolation_FHandler()
	{
		return new global::_JniMarshal_PPF_F(n_GetInterpolation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetInterpolation_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<IInterpolator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInterpolation(p0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe float GetInterpolation(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_androidx_constraintlayout_core_state_Interpolator.InstanceMethods.InvokeAbstractSingleMethod("getInterpolation.(F)F", this, ptr);
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
