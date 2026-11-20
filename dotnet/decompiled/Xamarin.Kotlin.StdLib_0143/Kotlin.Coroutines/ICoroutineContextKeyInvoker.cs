using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Coroutines;

[Register("kotlin/coroutines/CoroutineContext$Key", DoNotGenerateAcw = true)]
internal class ICoroutineContextKeyInvoker : Java.Lang.Object, ICoroutineContextKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_coroutines_CoroutineContext_Key = new XAPeerMembers("kotlin/coroutines/CoroutineContext$Key", typeof(ICoroutineContextKeyInvoker));

	private static nint java_class_ref => _members_kotlin_coroutines_CoroutineContext_Key.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_coroutines_CoroutineContext_Key;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_coroutines_CoroutineContext_Key.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_coroutines_CoroutineContext_Key.ManagedPeerType;

	public ICoroutineContextKeyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
