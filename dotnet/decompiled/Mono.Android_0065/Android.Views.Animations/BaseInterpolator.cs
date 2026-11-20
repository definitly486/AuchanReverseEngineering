using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Animation;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views.Animations;

[SupportedOSPlatform("android22.0")]
[Register("android/view/animation/BaseInterpolator", DoNotGenerateAcw = true, ApiSince = 22)]
public abstract class BaseInterpolator : Java.Lang.Object, IInterpolator, ITimeInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/animation/BaseInterpolator", typeof(BaseInterpolator));

	private static Delegate? cb_getInterpolation_GetInterpolation_F_F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BaseInterpolator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetInterpolation_FHandler()
	{
		return new _JniMarshal_PPF_F(n_GetInterpolation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetInterpolation_F(nint jnienv, nint native__this, float input)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseInterpolator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInterpolation(input);
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

	public abstract float GetInterpolation(float input);

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
