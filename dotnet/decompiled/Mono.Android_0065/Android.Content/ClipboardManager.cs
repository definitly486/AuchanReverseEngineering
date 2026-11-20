using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Text;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/ClipboardManager", DoNotGenerateAcw = true)]
public class ClipboardManager : Android.Text.ClipboardManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ClipboardManager", typeof(ClipboardManager));

	private static Delegate? cb_setPrimaryClip_SetPrimaryClip_Landroid_content_ClipData__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual ClipData? PrimaryClip
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimaryClip.(Landroid/content/ClipData;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ClipboardManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetPrimaryClip_Landroid_content_ClipData_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetPrimaryClip_Landroid_content_ClipData_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrimaryClip_Landroid_content_ClipData_(nint jnienv, nint native__this, nint native_clip)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ClipboardManager? clipboardManager = Java.Lang.Object.GetObject<ClipboardManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ClipData primaryClip = Java.Lang.Object.GetObject<ClipData>(native_clip, JniHandleOwnership.DoNotTransfer);
			clipboardManager.PrimaryClip = primaryClip;
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
}
