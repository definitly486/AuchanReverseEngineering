using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/DialogInterface$OnMultiChoiceClickListener", DoNotGenerateAcw = true)]
internal class IDialogInterfaceOnMultiChoiceClickListenerInvoker : Java.Lang.Object, IDialogInterfaceOnMultiChoiceClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_DialogInterface_OnMultiChoiceClickListener = new XAPeerMembers("android/content/DialogInterface$OnMultiChoiceClickListener", typeof(IDialogInterfaceOnMultiChoiceClickListenerInvoker));

	private static Delegate? cb_onClick_OnClick_Landroid_content_DialogInterface_IZ_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_DialogInterface_OnMultiChoiceClickListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_DialogInterface_OnMultiChoiceClickListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_DialogInterface_OnMultiChoiceClickListener.ManagedPeerType;

	public IDialogInterfaceOnMultiChoiceClickListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnClick_Landroid_content_DialogInterface_IZ(nint jnienv, nint native__this, nint native_dialog, int which, sbyte native_isChecked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDialogInterfaceOnMultiChoiceClickListener? dialogInterfaceOnMultiChoiceClickListener = Java.Lang.Object.GetObject<IDialogInterfaceOnMultiChoiceClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			bool isChecked = native_isChecked != 0;
			dialogInterfaceOnMultiChoiceClickListener.OnClick(dialog, which, isChecked);
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

	public unsafe void OnClick(IDialogInterface? dialog, int which, bool isChecked)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			ptr[1] = new JniArgumentValue(which);
			ptr[2] = new JniArgumentValue(isChecked ? ((sbyte)1) : ((sbyte)0));
			_members_android_content_DialogInterface_OnMultiChoiceClickListener.InstanceMethods.InvokeAbstractVoidMethod("onClick.(Landroid/content/DialogInterface;IZ)V", this, ptr);
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
	private static void n_OnClick_Landroid_content_DialogInterface_IZ_mm_wrapper(nint jnienv, nint native__this, nint native_dialog, int which, sbyte native_isChecked)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnClick_Landroid_content_DialogInterface_IZ(jnienv, native__this, native_dialog, which, native_isChecked);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
