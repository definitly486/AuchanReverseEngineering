using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/DialogInterface$OnShowListener", DoNotGenerateAcw = true)]
internal class IDialogInterfaceOnShowListenerInvoker : Java.Lang.Object, IDialogInterfaceOnShowListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_DialogInterface_OnShowListener = new XAPeerMembers("android/content/DialogInterface$OnShowListener", typeof(IDialogInterfaceOnShowListenerInvoker));

	private static Delegate? cb_onShow_OnShow_Landroid_content_DialogInterface__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_DialogInterface_OnShowListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_DialogInterface_OnShowListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_DialogInterface_OnShowListener.ManagedPeerType;

	public IDialogInterfaceOnShowListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnShow_Landroid_content_DialogInterface_(nint jnienv, nint native__this, nint native_dialog)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDialogInterfaceOnShowListener? dialogInterfaceOnShowListener = Java.Lang.Object.GetObject<IDialogInterfaceOnShowListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			dialogInterfaceOnShowListener.OnShow(dialog);
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

	public unsafe void OnShow(IDialogInterface? dialog)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			_members_android_content_DialogInterface_OnShowListener.InstanceMethods.InvokeAbstractVoidMethod("onShow.(Landroid/content/DialogInterface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
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
	private static void n_OnShow_Landroid_content_DialogInterface__mm_wrapper(nint jnienv, nint native__this, nint native_dialog)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnShow_Landroid_content_DialogInterface_(jnienv, native__this, native_dialog);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
