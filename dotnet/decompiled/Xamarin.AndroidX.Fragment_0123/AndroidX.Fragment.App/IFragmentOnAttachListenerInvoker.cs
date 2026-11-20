using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentOnAttachListener", DoNotGenerateAcw = true)]
internal class IFragmentOnAttachListenerInvoker : Java.Lang.Object, IFragmentOnAttachListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_fragment_app_FragmentOnAttachListener = new XAPeerMembers("androidx/fragment/app/FragmentOnAttachListener", typeof(IFragmentOnAttachListenerInvoker));

	private static Delegate? cb_onAttachFragment_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

	private static nint java_class_ref => _members_androidx_fragment_app_FragmentOnAttachListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_fragment_app_FragmentOnAttachListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_fragment_app_FragmentOnAttachListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_fragment_app_FragmentOnAttachListener.ManagedPeerType;

	public IFragmentOnAttachListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFragmentOnAttachListener? fragmentOnAttachListener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager p = Java.Lang.Object.GetObject<FragmentManager>(native_p0, JniHandleOwnership.DoNotTransfer);
			Fragment p2 = Java.Lang.Object.GetObject<Fragment>(native_p1, JniHandleOwnership.DoNotTransfer);
			fragmentOnAttachListener.OnAttachFragment(p, p2);
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

	public unsafe void OnAttachFragment(FragmentManager p0, Fragment p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_androidx_fragment_app_FragmentOnAttachListener.InstanceMethods.InvokeAbstractVoidMethod("onAttachFragment.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
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

	[UnmanagedCallersOnly]
	private static void n_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(jnienv, native__this, native_p0, native_p1);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
