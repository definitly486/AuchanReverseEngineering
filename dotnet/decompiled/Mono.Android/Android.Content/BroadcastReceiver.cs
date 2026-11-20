using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/BroadcastReceiver", DoNotGenerateAcw = true)]
public abstract class BroadcastReceiver : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/BroadcastReceiver", typeof(BroadcastReceiver));

	private static Delegate? cb_onReceive_OnReceive_Landroid_content_Context_Landroid_content_Intent__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BroadcastReceiver(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BroadcastReceiver()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_context, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BroadcastReceiver? broadcastReceiver = Java.Lang.Object.GetObject<BroadcastReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			broadcastReceiver.OnReceive(context, intent);
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

	[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
	public abstract void OnReceive(Context? context, Intent? intent);

	[UnmanagedCallersOnly]
	private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent__mm_wrapper(nint jnienv, nint native__this, nint native_context, nint native_intent)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(jnienv, native__this, native_context, native_intent);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
