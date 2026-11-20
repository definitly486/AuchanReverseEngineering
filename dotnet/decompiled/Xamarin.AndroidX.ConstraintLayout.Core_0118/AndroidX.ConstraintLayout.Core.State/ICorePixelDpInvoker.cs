using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/CorePixelDp", DoNotGenerateAcw = true)]
internal class ICorePixelDpInvoker : Java.Lang.Object, ICorePixelDp, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_constraintlayout_core_state_CorePixelDp = new XAPeerMembers("androidx/constraintlayout/core/state/CorePixelDp", typeof(ICorePixelDpInvoker));

	private static Delegate? cb_toPixels_ToPixels_F_F;

	private static nint java_class_ref => _members_androidx_constraintlayout_core_state_CorePixelDp.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_state_CorePixelDp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_constraintlayout_core_state_CorePixelDp.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_constraintlayout_core_state_CorePixelDp.ManagedPeerType;

	public ICorePixelDpInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetToPixels_FHandler()
	{
		return new global::_JniMarshal_PPF_F(n_ToPixels_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_ToPixels_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICorePixelDp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToPixels(p0);
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

	public unsafe float ToPixels(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_androidx_constraintlayout_core_state_CorePixelDp.InstanceMethods.InvokeAbstractSingleMethod("toPixels.(F)F", this, ptr);
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
