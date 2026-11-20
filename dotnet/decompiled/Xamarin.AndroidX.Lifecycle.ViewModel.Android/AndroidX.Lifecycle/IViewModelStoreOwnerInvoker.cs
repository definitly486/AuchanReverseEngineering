using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModelStoreOwner", DoNotGenerateAcw = true)]
internal class IViewModelStoreOwnerInvoker : Java.Lang.Object, IViewModelStoreOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_lifecycle_ViewModelStoreOwner = new XAPeerMembers("androidx/lifecycle/ViewModelStoreOwner", typeof(IViewModelStoreOwnerInvoker));

	private static Delegate? cb_getViewModelStore_GetViewModelStore_Landroidx_lifecycle_ViewModelStore_;

	private static nint java_class_ref => _members_androidx_lifecycle_ViewModelStoreOwner.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_ViewModelStoreOwner;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_lifecycle_ViewModelStoreOwner.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_lifecycle_ViewModelStoreOwner.ManagedPeerType;

	public unsafe ViewModelStore ViewModelStore => Java.Lang.Object.GetObject<ViewModelStore>(_members_androidx_lifecycle_ViewModelStoreOwner.InstanceMethods.InvokeAbstractObjectMethod("getViewModelStore.()Landroidx/lifecycle/ViewModelStore;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IViewModelStoreOwnerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetViewModelStoreHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewModelStore);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewModelStore(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IViewModelStoreOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
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
