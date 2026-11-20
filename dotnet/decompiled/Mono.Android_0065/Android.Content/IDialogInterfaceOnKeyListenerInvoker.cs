using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/DialogInterface$OnKeyListener", DoNotGenerateAcw = true)]
internal class IDialogInterfaceOnKeyListenerInvoker : Java.Lang.Object, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_DialogInterface_OnKeyListener = new XAPeerMembers("android/content/DialogInterface$OnKeyListener", typeof(IDialogInterfaceOnKeyListenerInvoker));

	private static Delegate? cb_onKey_OnKey_Landroid_content_DialogInterface_ILandroid_view_KeyEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_DialogInterface_OnKeyListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_DialogInterface_OnKeyListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_DialogInterface_OnKeyListener.ManagedPeerType;

	public IDialogInterfaceOnKeyListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKey_Landroid_content_DialogInterface_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_dialog, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IDialogInterfaceOnKeyListener? dialogInterfaceOnKeyListener = Java.Lang.Object.GetObject<IDialogInterfaceOnKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return dialogInterfaceOnKeyListener.OnKey(dialog, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool OnKey(IDialogInterface? dialog, Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			ptr[1] = new JniArgumentValue((int)keyCode);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_content_DialogInterface_OnKeyListener.InstanceMethods.InvokeAbstractBooleanMethod("onKey.(Landroid/content/DialogInterface;ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
			GC.KeepAlive(e);
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
	private static sbyte n_OnKey_Landroid_content_DialogInterface_ILandroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, nint native_dialog, int native_keyCode, nint native_e)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnKey_Landroid_content_DialogInterface_ILandroid_view_KeyEvent_(jnienv, native__this, native_dialog, native_keyCode, native_e);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
