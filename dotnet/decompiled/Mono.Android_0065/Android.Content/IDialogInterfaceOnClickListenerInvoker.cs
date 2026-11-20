using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/DialogInterface$OnClickListener", DoNotGenerateAcw = true)]
internal class IDialogInterfaceOnClickListenerInvoker : Java.Lang.Object, IDialogInterfaceOnClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_DialogInterface_OnClickListener = new XAPeerMembers("android/content/DialogInterface$OnClickListener", typeof(IDialogInterfaceOnClickListenerInvoker));

	private static Delegate? cb_onClick_OnClick_Landroid_content_DialogInterface_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_DialogInterface_OnClickListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_DialogInterface_OnClickListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_DialogInterface_OnClickListener.ManagedPeerType;

	public IDialogInterfaceOnClickListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnClick_Landroid_content_DialogInterface_I(nint jnienv, nint native__this, nint native_dialog, int which)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDialogInterfaceOnClickListener? dialogInterfaceOnClickListener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			dialogInterfaceOnClickListener.OnClick(dialog, which);
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

	public unsafe void OnClick(IDialogInterface? dialog, int which)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			ptr[1] = new JniArgumentValue(which);
			_members_android_content_DialogInterface_OnClickListener.InstanceMethods.InvokeAbstractVoidMethod("onClick.(Landroid/content/DialogInterface;I)V", this, ptr);
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
	private static void n_OnClick_Landroid_content_DialogInterface_I_mm_wrapper(nint jnienv, nint native__this, nint native_dialog, int which)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnClick_Landroid_content_DialogInterface_I(jnienv, native__this, native_dialog, which);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
