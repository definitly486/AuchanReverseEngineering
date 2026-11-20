using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Animation;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views.Animations;

[Register("android/view/animation/Interpolator", DoNotGenerateAcw = true)]
internal class IInterpolatorInvoker : Java.Lang.Object, IInterpolator, ITimeInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_animation_TimeInterpolator = new XAPeerMembers("android/animation/TimeInterpolator", typeof(IInterpolatorInvoker));

	private static readonly JniPeerMembers _members_android_view_animation_Interpolator = new XAPeerMembers("android/view/animation/Interpolator", typeof(IInterpolatorInvoker));

	private static Delegate? cb_getInterpolation_GetInterpolation_F_F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_animation_Interpolator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_animation_Interpolator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_animation_Interpolator.ManagedPeerType;

	public IInterpolatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
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
			return Java.Lang.Object.GetObject<IInterpolator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInterpolation(input);
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

	public unsafe float GetInterpolation(float input)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(input);
		return _members_android_view_animation_Interpolator.InstanceMethods.InvokeAbstractSingleMethod("getInterpolation.(F)F", this, ptr);
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
